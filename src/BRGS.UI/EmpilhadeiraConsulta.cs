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
    public partial class EmpilhadeiraConsulta : Form
    {        
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        private BIZEmpilhadeira bizEmpilhadeira = new BIZEmpilhadeira();

        public EmpilhadeiraConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Empilhadeira());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, System.EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Empilhadeira empilhadeiraFiltro = new Empilhadeira();
                empilhadeiraFiltro = (Empilhadeira)new ClassProperties().RetornarObjetoFiltro(new Empilhadeira(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (empilhadeiraFiltro != null)
                    CarregarGrid(empilhadeiraFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Empilhadeira empilhadeiraFiltro)
        {
            List<Empilhadeira> lstEmpilhadeiras = new List<Empilhadeira>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstEmpilhadeiras = bizEmpilhadeira.PesquisarEmpilhadeiras(empilhadeiraFiltro).OrderBy(x => x.NumeroSerie).ToList();

                LimparGrid();

                foreach (Empilhadeira itemEmpilhadeira in lstEmpilhadeiras)
                {
                    gvEmpilhadeiras.Rows.Add(new object[]
                    {
                        itemEmpilhadeira.ID,
                        itemEmpilhadeira.NumeroSerie,
                        itemEmpilhadeira.Marca,
                        itemEmpilhadeira.Modelo,
                        itemEmpilhadeira.Lotada,
                        string.IsNullOrEmpty(itemEmpilhadeira.Cliente) ? "DISPONÍVEL" : itemEmpilhadeira.Cliente                        
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
            while (gvEmpilhadeiras.Rows.Count > 0)
                gvEmpilhadeiras.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            //AbastecimentoManutencao form = new AbastecimentoManutencao(new Abastecimento());
            //form.ShowDialog();

            //btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarEmpilhadeira();
        }

        private void VisualizarEmpilhadeira()
        {
            int linhaGrid = 0;

            if (gvEmpilhadeiras.RowCount == 0)
                return;

            linhaGrid = gvEmpilhadeiras.SelectedCells[0].RowIndex;

            Empilhadeira empilhadeira = new Empilhadeira()
            {
                ID = int.Parse(gvEmpilhadeiras[0, linhaGrid].Value.ToString())
            };

            //AbastecimentoManutencao form = new AbastecimentoManutencao(abastecimento);
            //form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvEmpilhadeiras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarEmpilhadeira();
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

        private void EmpilhadeiraConsulta_Load(object sender, EventArgs e)
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
