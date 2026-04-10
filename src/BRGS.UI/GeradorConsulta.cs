using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class GeradorConsulta : Form
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        private BIZGerador bizGerador = new BIZGerador();

        public GeradorConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Gerador());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, System.EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Gerador geradorFiltro = new Gerador();
                geradorFiltro = (Gerador)new ClassProperties().RetornarObjetoFiltro(new Gerador(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (geradorFiltro != null)
                    CarregarGrid(geradorFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Gerador geradorFiltro)
        {
            List<Gerador> lstGerador = new List<Gerador>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstGerador = bizGerador.PesquisarGeradores(geradorFiltro).OrderBy(x => x.NumeroSerie).ToList();

                LimparGrid();

                foreach (Gerador itemGerador in lstGerador)
                {
                    gvGeradores.Rows.Add(new object[]
                    {
                        itemGerador.ID,
                        itemGerador.NumeroSerie,
                        itemGerador.Marca,
                        itemGerador.Modelo,
                        itemGerador.Lotado,
                        string.IsNullOrEmpty(itemGerador.Cliente) ? "DISPONÍVEL" : itemGerador.Cliente
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
            while (gvGeradores.Rows.Count > 0)
                gvGeradores.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            GeradorManutencao form = new GeradorManutencao(new Gerador());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarGerador();
        }

        private void VisualizarGerador()
        {
            int linhaGrid = 0;

            if (gvGeradores.RowCount == 0)
                return;

            linhaGrid = gvGeradores.SelectedCells[0].RowIndex;

            Gerador gerador = new Gerador()
            {
                ID = int.Parse(gvGeradores[0, linhaGrid].Value.ToString())
            };

            GeradorManutencao form = new GeradorManutencao(gerador);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvGeradores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarGerador();
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

        private void GeradorConsulta_Load(object sender, EventArgs e)
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