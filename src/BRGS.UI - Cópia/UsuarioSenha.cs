using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class UsuarioSenha : Form
    {
        private Usuario usuarioSelecionado = new Usuario();
        private BIZUsuario bizUsuario = new BIZUsuario();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public UsuarioSenha(Usuario _usuarioSelecionado)
        {
            InitializeComponent();

            usuarioSelecionado = _usuarioSelecionado;

            lbCodigo.Text = usuarioSelecionado.idUsuario.ToString();
            tbNome.Text = usuarioSelecionado.Nome;
            tbLogin.Text = usuarioSelecionado.Login;          
        }
         private void tbSenha1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbSenha2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

           
            this.Cursor = Cursors.WaitCursor;

            try
            {
                msgRetorno = this.ValidarSenha();

                if (msgRetorno == string.Empty)
                {
                    Usuario usuario = new Usuario()
                    {
                        idUsuario = usuarioSelecionado.idUsuario,
                        Senha = helper.CriptografarSenha(tbSenha1.Text)
                    };

                    msgRetorno = bizUsuario.AlterarUsuarioSenha(usuario, UsuarioLogado.idUsuario);

                    if (msgRetorno == string.Empty)
                    {
                        MessageBox.Show("Alteração da senha efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            this.Cursor = Cursors.Default;
        }

        private string ValidarSenha()
        {
            string Msg = string.Empty;
            
            if (tbSenha1.Text.Trim() == string.Empty)
                Msg += "Favor informar a senha";
            
            if (tbSenha1.Text != tbSenha2.Text)
                Msg += "As senhas não conferem";

            return Msg;
        }
    }
}