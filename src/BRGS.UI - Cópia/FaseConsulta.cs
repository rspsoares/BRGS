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
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class FaseConsulta : Form
    {
        private BIZFase bizFase = new BIZFase();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public FaseConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Fase());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Fase faseFiltro = new Fase();
                faseFiltro = (Fase)new ClassProperties().RetornarObjetoFiltro(new Fase(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (faseFiltro != null)
                    CarregarGrid(faseFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Fase faseFiltro)
        {
            List<Fase> lstFase = new List<Fase>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFase = bizFase.PesquisarFases(faseFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                foreach (Fase itemDespesa in lstFase)
                {
                    gvFases.Rows.Add(new object[] 
                    {
                        itemDespesa.idFase, 
                        itemDespesa.Descricao
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
            while (gvFases.Rows.Count > 0)
                gvFases.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            FaseManutencao form = new FaseManutencao(new Fase());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarFase();
        }

        private void VisualizarFase()
        {
            int linhaGrid = 0;

            if (gvFases.RowCount == 0)
                return;

            linhaGrid = gvFases.SelectedCells[0].RowIndex;

            Fase fase = new Fase()
            {
                idFase = int.Parse(gvFases[0, linhaGrid].Value.ToString()),
                Descricao = gvFases[1, linhaGrid].Value.ToString()
            };

            FaseManutencao form = new FaseManutencao(fase);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvFases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarFase();
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

        private void FaseConsulta_Load(object sender, EventArgs e)
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
