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
    public partial class ClienteConsulta : Form
    {
        private BIZCliente bizCliente = new BIZCliente();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public ClienteConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesClientes = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesClientes = new ClassProperties().RetornarPropriedadesClasse(new Cliente());

            cbPesquisaCampo.DataSource = lstPropriedadesClientes;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Cliente clienteFiltro = new Cliente();
                clienteFiltro = (Cliente)new ClassProperties().RetornarObjetoFiltro(new Cliente(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (clienteFiltro != null)
                    CarregarGrid(clienteFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Cliente clienteFiltro)
        {
            List<Cliente> lstClientes = new List<Cliente>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientes = bizCliente.PesquisarCliente(clienteFiltro).OrderBy(x => x.Nome).ToList();

                LimparGrid();

                foreach (Cliente itemCliente in lstClientes)
                {
                    gvClientes.Rows.Add(new object[] 
                    {
                        itemCliente.idCliente, 
                        itemCliente.Nome,
                        itemCliente.CPF_CNPJ,
                        itemCliente.Telefone, 
                        itemCliente.Status                        
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
            while (gvClientes.Rows.Count > 0)
                gvClientes.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            ClienteManutencao form = new ClienteManutencao(new Cliente());
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

            if (gvClientes.RowCount == 0)
                return;

            linhaGrid = gvClientes.SelectedCells[0].RowIndex;

            Cliente cliente = new Cliente()
            {
                idCliente = int.Parse(gvClientes[0, linhaGrid].Value.ToString())
            };

            ClienteManutencao form = new ClienteManutencao(cliente);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvClientes_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void ClienteConsulta_Load(object sender, EventArgs e)
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

