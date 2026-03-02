using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class NotaFiscalConsulta : Form
    {        
        private BIZNotaFiscal bizNotaFiscal = new BIZNotaFiscal();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private GridPagination _pagination = new GridPagination();
        
        public NotaFiscalConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesNFS = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesNFS = new ClassProperties().RetornarPropriedadesClasse(new NotaFiscal());

            cbPesquisaCampo.DataSource = lstPropriedadesNFS;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarGrid();
        }

        private void PesquisarGrid(bool isPaginacao = false)
        {
            if (!isPaginacao)
            {
                _pagination.Skip = 0;
                _pagination.Take = 10;
            }

            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                NotaFiscal nfsFiltro = new NotaFiscal();
                nfsFiltro = (NotaFiscal)new ClassProperties().RetornarObjetoFiltro(new NotaFiscal(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (nfsFiltro != null)
                    CarregarGrid(nfsFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void AtualizarInfoPaginacao(int currentPage, int totalPages, int totalLines)
        {
            lbGridTotalRegistros.Text = $"Total de registros: {totalLines}";
            lbGridPaginas.Text = $"Página {currentPage} / {totalPages}";

            cmdGridPrimeira.Enabled = currentPage > 1;
            cmdGridAnterior.Enabled = currentPage > 1;

            cmdGridProxima.Enabled = currentPage < totalPages;
            cmdGridUltima.Enabled = currentPage < totalPages;
        }

        private void CarregarGrid(NotaFiscal nfsFiltro)
        {
            List<NotaFiscal> lstNFS = new List<NotaFiscal>();           

            this.Cursor = Cursors.WaitCursor;

            try
            {   
                lstNFS = bizNotaFiscal.GridNotaFiscal(nfsFiltro, _pagination.Take, _pagination.Skip, _pagination.Sort, out int totalLines, out int currentPage, out int totalPages);

                _pagination.TotalLines = totalLines;

                AtualizarInfoPaginacao(currentPage, totalPages, totalLines);

                LimparGrid();

                gvNFS.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvNFS.Columns[7].DefaultCellStyle.Format = "N2";
                gvNFS.Columns[8].DefaultCellStyle.Format = "N2";
                gvNFS.Columns[9].DefaultCellStyle.Format = "N2";

                foreach (NotaFiscal itemNota in lstNFS)
                {                  
                    gvNFS.Rows.Add(new object[] 
                    {
                        itemNota.idEmpresa, 
                        itemNota.nomeEmpresa,
                        itemNota.descTipoNota, 
                        itemNota.numeroNota,
                        itemNota.dataEmissao.Date,
                        itemNota.Nome,
                        itemNota.Empenho, 
                        decimal.Parse(helper.FormatarValorMoeda(itemNota.valorNota.ToString())),
                        itemNota.Cancelado == 1 ? "CANCELADO" : helper.FormatarValorMoeda(itemNota.valorPago.ToString()),
                        itemNota.Cancelado == 1 ? decimal.Zero : decimal.Parse(helper.FormatarValorMoeda((itemNota.valorNota - itemNota.valorPago).ToString())), 
                        itemNota.idNota 
                    });
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void LimparGrid()
        {
            while (gvNFS.Rows.Count > 0)
                gvNFS.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            NotaFiscalManutencao form = new NotaFiscalManutencao(new NotaFiscal());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarNotaFiscal();
        }

        private void VisualizarNotaFiscal()
        {
            int linhaGrid = 0;
            
            if (gvNFS.RowCount == 0)
                return;

            linhaGrid = gvNFS.SelectedCells[0].RowIndex;

            NotaFiscal nfSelecionada = new NotaFiscal()
            {
                idNota = int.Parse(gvNFS[10, linhaGrid].Value.ToString())                
            };

            NotaFiscalManutencao form = new NotaFiscalManutencao(nfSelecionada);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvNFS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarNotaFiscal();
        }

        private void cbPesquisaCampo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPesquisaValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void gvNFS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gvNFS.Columns["Diferenca"].Index)
            {
                DataGridViewRow linhaGrid = gvNFS.Rows[e.RowIndex];

                if (decimal.Parse(linhaGrid.Cells["Diferenca"].Value.ToString()) < decimal.Zero)
                    gvNFS.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void NotaFiscalServicoConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                _pagination.Skip = 0;
                _pagination.Take = 10;
                _pagination.Sort = "NF.idNota DESC";

                CarregarCamposPesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogErro logErro = new LogErro()
                {
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(logErro);
            }			
        }

        private void gvNFS_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {       
            var field = (GridColumns)Enum.Parse(typeof(GridColumns), e.ColumnIndex.ToString());

            var direction = ((SortedDataGridView)sender)
                .Columns[e.ColumnIndex]
                .HeaderCell
                .SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending
                ? "ASC"
                : "DESC";                

            _pagination.Sort = $"{field} {direction}";

            PesquisarGrid();            
        }

        private void cmdGridPrimeira_Click(object sender, EventArgs e)
        {
            _pagination.Skip = 0;
            PesquisarGrid(true);
        }

        private void cmdGridAnterior_Click(object sender, EventArgs e)
        {
            _pagination.Skip -= _pagination.Take;
            PesquisarGrid(true);
        }

        private void cmdGridProxima_Click(object sender, EventArgs e)
        {
            _pagination.Skip += _pagination.Take;
            PesquisarGrid(true);
        }

        private void cmdGridUltima_Click(object sender, EventArgs e)
        {
            _pagination.Skip = _pagination.TotalLines - _pagination.Take;
            PesquisarGrid(true);
        }
        
        private class GridPagination
        {
            public int Take { get; set; }
            public int Skip { get; set; }
            public int TotalLines { get; set; }
            public string Sort { get; set; }
        }

        private enum GridColumns
        {
            RazaoSocial = 1,
            TipoNota = 2,
            NumeroNota = 3,
            DataEmissao = 4,
            NomeCliente = 5,
            Empenho = 6,
            ValorNota = 7,
            ValorPago = 8
        }
    }   
}
