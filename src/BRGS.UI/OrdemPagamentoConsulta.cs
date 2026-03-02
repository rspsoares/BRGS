using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class OrdemPagamentoConsulta : Form
    {
        private BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZParametrizacao bizParametrizacao = new BIZParametrizacao();
        private GridPagination _pagination = new GridPagination();

        public OrdemPagamentoConsulta()
        {
            InitializeComponent();
            bizParametrizacao.ObterParametrizacao();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesOP = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesOP = new ClassProperties().RetornarPropriedadesClasse(new OrdemPagamento());

            cbPesquisaCampo.DataSource = lstPropriedadesOP;
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
                OrdemPagamento ordemPagamentoFiltro = new OrdemPagamento();
                ordemPagamentoFiltro = (OrdemPagamento)new ClassProperties().RetornarObjetoFiltro(new OrdemPagamento(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (ordemPagamentoFiltro != null)
                    CarregarGrid(ordemPagamentoFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void CarregarGrid(OrdemPagamento ordemPagamentoFiltro)
        {
            List<OrdemPagamento> lstOrdemPagamento = new List<OrdemPagamento>();
            
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstOrdemPagamento = bizOP.GridOrdemPagamento(ordemPagamentoFiltro, _pagination.Take, _pagination.Skip, _pagination.Sort, out int totalLines, out int currentPage, out int totalPages);

                _pagination.TotalLines = totalLines;

                AtualizarInfoPaginacao(currentPage, totalPages, totalLines);

                LimparGrid();

                gvOrdensPagamentos.Columns[8].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvOrdensPagamentos.Columns[10].DefaultCellStyle.Format = "dd/MM/yyyy";                

                foreach (OrdemPagamento itemOrdemPagamento in lstOrdemPagamento)
                {   
                    gvOrdensPagamentos.Rows.Add(new object[] 
                    {
                        itemOrdemPagamento.idOrdemPagamento,
                        itemOrdemPagamento.numeroOP,
                        itemOrdemPagamento.razaoSocial,
                        itemOrdemPagamento.nomeCliente,
                        itemOrdemPagamento.nomeEvento,
                        itemOrdemPagamento.nomeFavorecido,
                        itemOrdemPagamento.valorTotal,
                        itemOrdemPagamento.Status,
                        itemOrdemPagamento.Status == "PAGA" ? itemOrdemPagamento.dataPagamentoParcela: (DateTime?)null,
                        itemOrdemPagamento.Observacao,
                        itemOrdemPagamento.dataVencimentoParcela
                    });
                }

                helper.VerificarCorLinhaGrid(gvOrdensPagamentos);
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

        private void AtualizarInfoPaginacao(int currentPage, int totalPages, int totalLines)
        {
            lbGridTotalRegistros.Text = $"Total de registros: {totalLines}";
            lbGridPaginas.Text = $"Página {currentPage} / {totalPages}";

            cmdGridPrimeira.Enabled = currentPage > 1;
            cmdGridAnterior.Enabled = currentPage > 1;

            cmdGridProxima.Enabled = currentPage < totalPages;
            cmdGridUltima.Enabled = currentPage < totalPages;
        }

        private void LimparGrid()
        {
            while (gvOrdensPagamentos.Rows.Count > 0)
                gvOrdensPagamentos.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            OrdemPagamentoManutencao form = new OrdemPagamentoManutencao(new OrdemPagamento(),true);
            form.ShowDialog();
            btPesquisar_Click(null, null);                            
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarLancamento();
        }

        private void VisualizarLancamento()
        {
            OrdemPagamento ordemPagamentoSelecionada = new OrdemPagamento();
            int linhaGrid = 0;
            int idOrdemPagamentoSelecionada = 0;

            try
            {
                if (gvOrdensPagamentos.RowCount == 0)
                    return;

                linhaGrid = gvOrdensPagamentos.SelectedCells[0].RowIndex;
                idOrdemPagamentoSelecionada = int.Parse(gvOrdensPagamentos[0, linhaGrid].Value.ToString());

                ordemPagamentoSelecionada = bizOP.PesquisarOrdemPagamento(new OrdemPagamento() { idOrdemPagamento = idOrdemPagamentoSelecionada })[0];
                ordemPagamentoSelecionada.lstItens = new List<OrdemPagamentoItem>();
                ordemPagamentoSelecionada.lstItens = bizOP.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idOrdemPagamento = idOrdemPagamentoSelecionada });

                OrdemPagamentoManutencao form = new OrdemPagamentoManutencao(ordemPagamentoSelecionada,true);
                form.ShowDialog();

                btPesquisar_Click(null, null);                
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void gvOrdensPagamentos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarLancamento();
        }

        private void OrdemPagamentoConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                _pagination.Skip = 0;
                _pagination.Take = 10;
                _pagination.Sort = "E.RazaoSocial ASC";

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
 
        private void gvOrdensPagamentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            NumeroOP = 1,
            RazaoSocial = 2,
            NomeCliente = 3,
            NomeEvento = 4,
            NomeFavorecido = 5,
            ValorTotal = 6,
            Status = 7,
            DataPagamentoParcela = 8,
            Observacao = 9
        }
    }   
}
