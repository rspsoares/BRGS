using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class MultaConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public MultaConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Multa());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Multa multaFiltro = new Multa();
                multaFiltro = (Multa)new ClassProperties().RetornarObjetoFiltro(new Multa(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (multaFiltro != null)
                    CarregarGrid(multaFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Multa multaFiltro)
        {
            List<Multa> lstMultas = new List<Multa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstMultas = bizVeiculo.PesquisarMultas(multaFiltro).OrderBy(x => x.Codigo).ThenBy(x => x.Desdobramento).ToList();

                LimparGrid();

                gvMultas.Columns[7].DefaultCellStyle.Format = "N2";

                foreach (Multa itemMulta in lstMultas)
                {
                    gvMultas.Rows.Add(new object[] 
                    {
                        itemMulta.idMulta,
                        itemMulta.Codigo,
                        itemMulta.Desdobramento,
                        itemMulta.Descricao,
                        itemMulta.Infrator,
                        itemMulta.descricaoGravidade,
                        itemMulta.Pontos, 
                        helper.FormatarValorMoeda(itemMulta.Valor.ToString()) 
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
            while (gvMultas.Rows.Count > 0)
                gvMultas.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            MultaManutencao form = new MultaManutencao(new Multa());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarMulta();
        }

        private void VisualizarMulta()
        {
            int linhaGrid = 0;

            if (gvMultas.RowCount == 0)
                return;

            linhaGrid = gvMultas.SelectedCells[0].RowIndex;

            Multa multa = new Multa()
            {
                idMulta = int.Parse(gvMultas[0, linhaGrid].Value.ToString())
            };

            MultaManutencao form = new MultaManutencao(multa);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvMultas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarMulta();
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

        private void MultaConsulta_Load(object sender, EventArgs e)
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