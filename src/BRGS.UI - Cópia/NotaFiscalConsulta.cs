using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.Entity;
using BRGS.BIZ;
using BRGS.Util;
using System.Data.SqlClient;
using System.Reflection;

namespace BRGS.UI
{
    public partial class NotaFiscalConsulta : Form
    {        
        private BIZNotaFiscal bizNotaFiscal = new BIZNotaFiscal();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        
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

        private void CarregarGrid(NotaFiscal nfsFiltro)
        {
            List<NotaFiscal> lstNFS = new List<NotaFiscal>();           

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstNFS = bizNotaFiscal.PesquisarNotaFiscal(nfsFiltro).OrderBy(nfs => nfs.numeroNota).ToList();

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
                        itemNota.Cancelado == 1 ? "CANCELADO" :helper.FormatarValorMoeda(itemNota.valorPago.ToString()),
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
    }
}
