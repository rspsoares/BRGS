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
    public partial class MotoristaConsulta : Form
    {
        private BIZMotorista bizMotorista = new BIZMotorista();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public MotoristaConsulta()
        {
            InitializeComponent();
        }
        
        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Motorista());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Motorista motoristaFiltro = new Motorista();
                motoristaFiltro = (Motorista)new ClassProperties().RetornarObjetoFiltro(new Motorista(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (motoristaFiltro != null)
                    CarregarGrid(motoristaFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Motorista motoristaFiltro)
        {
            List<Motorista> lstMotoristas = new List<Motorista>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstMotoristas = bizMotorista.PesquisarMotorista(motoristaFiltro).OrderBy(x => x.Nome).ToList();

                LimparGrid();

                foreach (Motorista itemMotorista in lstMotoristas)
                {
                    gvMotoristas.Rows.Add(new object[] 
                    {
                        itemMotorista.idMotorista, 
                        itemMotorista.Nome,
                        itemMotorista.Telefone
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
            while (gvMotoristas.Rows.Count > 0)
                gvMotoristas.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            MotoristaManutencao form = new MotoristaManutencao(new Motorista());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarMotorista();
        }

        private void VisualizarMotorista()
        {
            int linhaGrid = 0;

            if (gvMotoristas.RowCount == 0)
                return;

            linhaGrid = gvMotoristas.SelectedCells[0].RowIndex;

            Motorista motorista = new Motorista()
            {                
                idMotorista = int.Parse(gvMotoristas[0, linhaGrid].Value.ToString())                
            };

            MotoristaManutencao form = new MotoristaManutencao(motorista);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvMotoristas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarMotorista();
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

        private void MotoristaConsulta_Load(object sender, EventArgs e)
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