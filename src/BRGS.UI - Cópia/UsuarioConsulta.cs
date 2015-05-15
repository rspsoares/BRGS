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
    public partial class UsuarioConsulta : Form
    {
        private BIZUsuario bizUsuario = new BIZUsuario();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public UsuarioConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesClientes = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesClientes = new ClassProperties().RetornarPropriedadesClasse(new Usuario());

            cbPesquisaCampo.DataSource = lstPropriedadesClientes;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Usuario usuarioFiltro = new Usuario();
                usuarioFiltro = (Usuario)new ClassProperties().RetornarObjetoFiltro(new Usuario(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (usuarioFiltro != null)
                    CarregarGrid(usuarioFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Usuario usuarioFiltro)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();

            this.Cursor = Cursors.WaitCursor;

            try
            {                
                usuarioFiltro.Ativo = "S";
                lstUsuarios = bizUsuario.PesquisarUsuario(usuarioFiltro).OrderBy(x => x.Nome).ToList();

                LimparGrid();

                foreach (Usuario usuario in lstUsuarios)
                {                 
                    gvUsuarios.Rows.Add(new object[] {
                        usuario.idUsuario,
                        usuario.Nome,
                        usuario.Login,
                        usuario.ultimoAcesso == DateTime.MinValue ? string.Empty : usuario.ultimoAcesso.ToString(), 
                        usuario.Bloqueado == 1 ? "Sim" : "Não"});
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
            while (gvUsuarios.Rows.Count > 0)
                gvUsuarios.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            UsuarioManutencao form = new UsuarioManutencao(new Usuario());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarUsuario();
        }

        private void VisualizarUsuario()
        {
            int linhaGrid = 0;

            if (gvUsuarios.RowCount == 0)
                return;

            linhaGrid = gvUsuarios.SelectedCells[0].RowIndex;

            Usuario usuario = new Usuario()
            {
                idUsuario = int.Parse(gvUsuarios[0, linhaGrid].Value.ToString())
                //Nome = gvUsuarios[1, linhaGrid].Value.ToString(),
                //Login = gvUsuarios[2, linhaGrid].Value.ToString(),
                //ultimoAcesso = gvUsuarios[3, linhaGrid].Value.ToString() == string.Empty ? DateTime.MinValue : DateTime.Parse(gvUsuarios[3, linhaGrid].Value.ToString()),
                //Bloqueado = gvUsuarios[4, linhaGrid].Value.ToString() == "Sim" ? 1 : 0
            };

            UsuarioManutencao form = new UsuarioManutencao(usuario);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarUsuario();
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

        private void UsuarioConsulta_Load(object sender, EventArgs e)
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
  