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
    public partial class FornecedorConsulta : Form
    {
        private BIZFornecedor bizFornecedor = new BIZFornecedor();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public FornecedorConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesClientes = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesClientes = new ClassProperties().RetornarPropriedadesClasse(new Fornecedor());

            cbPesquisaCampo.DataSource = lstPropriedadesClientes;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Fornecedor fornecedorFiltro = new Fornecedor();
                fornecedorFiltro = (Fornecedor)new ClassProperties().RetornarObjetoFiltro(new Fornecedor(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (fornecedorFiltro != null)
                    CarregarGrid(fornecedorFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Fornecedor fornecedorFiltro)
        {
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFornecedores = bizFornecedor.PesquisarFornecedor(fornecedorFiltro).OrderBy(x => x.Nome).ToList();

                LimparGrid();

                foreach (Fornecedor itemFornecedor in lstFornecedores)
                {
                    gvFornecedores.Rows.Add(new object[] 
                    {
                        itemFornecedor.idFornecedor, 
                        itemFornecedor.Nome,
                        itemFornecedor.CPF_CNPJ,
                        itemFornecedor.Telefone, 
                        itemFornecedor.Status                        
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
            while (gvFornecedores.Rows.Count > 0)
                gvFornecedores.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            FornecedorManutencao form = new FornecedorManutencao(new Fornecedor());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarCliente();
        }

        private void VisualizarCliente()
        {
            int linhaGrid = 0;

            if (gvFornecedores.RowCount == 0)
                return;

            linhaGrid = gvFornecedores.SelectedCells[0].RowIndex;

            Fornecedor fornecedor = new Fornecedor()
            {
                idFornecedor = int.Parse(gvFornecedores[0, linhaGrid].Value.ToString())
            };

            FornecedorManutencao form = new FornecedorManutencao(fornecedor);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvFornecedores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarCliente();
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

        private void FornecedorConsulta_Load(object sender, EventArgs e)
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

