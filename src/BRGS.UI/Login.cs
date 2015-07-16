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
using System.Data.SqlClient;
using BRGS.Util;
using System.Security.Cryptography;
using System.Xml;
using System.Reflection;

namespace BRGS.UI
{
    public partial class Login : Form
    {
        private Helper helper = new Helper();
        private BIZUsuario bizUsuario = new BIZUsuario();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZParametrizacao bizParametrizacao = new BIZParametrizacao();

        public Login()
        {
            InitializeComponent();          
        }

        private void tbSenha_KeyDown(object sender, KeyEventArgs e)
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

        private void btLogin_Click(object sender, EventArgs e)
        {            
            string Msg = string.Empty;
            
            this.Cursor = Cursors.WaitCursor;

            try
            {
                Usuario usuarioLogin = new Usuario()
                {
                    Login = tbUsuario.Text,
                    Senha = helper.CriptografarSenha(tbSenha.Text),
                    Ativo = "S"
                };

                usuarioLogin = bizUsuario.AutenticarUsuario(new Usuario() { Login = tbUsuario.Text, Senha = helper.CriptografarSenha(tbSenha.Text), Ativo = "S" });

                Msg = this.AutenticarUsuario(usuarioLogin);

                if (Msg == string.Empty)
                {
                    this.Cursor = Cursors.Default;                   

                    if (usuarioLogin.Senha == string.Empty)
                    {
                        MessageBox.Show("Favor definir a senha de acesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        UsuarioSenha frmSenha = new UsuarioSenha(usuarioLogin);
                        frmSenha.ShowDialog();
                        return;
                    }                    

                    UsuarioLogado.idUsuario = usuarioLogin.idUsuario;
                    UsuarioLogado.Nome = usuarioLogin.Nome;
                    UsuarioLogado.lstPermissoes = usuarioLogin.lstPermissoes;
                    UsuarioLogado.lstUEN = usuarioLogin.lstUEN;
                    UsuarioLogado.lstCC = usuarioLogin.lstCC;
                    UsuarioLogado.lstDespesas = usuarioLogin.lstDespesas;

                    bizUsuario.AtualizarUltimoAcesso(new Usuario() { idUsuario = UsuarioLogado.idUsuario, ultimoAcesso = DateTime.Now }, UsuarioLogado.idUsuario);
                    
                    // Log Version
                    XmlDocument xmlDoc = new XmlDocument();
                    Assembly asmCurrent = System.Reflection.Assembly.GetExecutingAssembly();
                    string executePath = new Uri(asmCurrent.GetName().CodeBase).LocalPath;

                    xmlDoc.Load(executePath + ".manifest");

                    if (xmlDoc.HasChildNodes)
                        UsuarioLogado.Versao = xmlDoc.ChildNodes[1].ChildNodes[0].Attributes.GetNamedItem("version").Value.ToString();

                    if (UsuarioLogado.Versao != string.Empty)
                        UsuarioLogado.dataPublicacao = bizUsuario.AtualizarHistoricoVersao(UsuarioLogado.Versao);
                    else
                        UsuarioLogado.dataPublicacao = DateTime.MinValue;
                    
                    // *************
                    
                    bizParametrizacao.ObterParametrizacao();

                    this.Close();
                }
                else
                    MessageBox.Show(Msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private string AutenticarUsuario(Usuario usuarioLogin)
        {
            string Msg = string.Empty;

            if (usuarioLogin.idUsuario == 0)
                Msg = "Usuário e/ou senha inválidos.";

            if (usuarioLogin.Bloqueado == 1)
                Msg = "Usuário bloqueado.";

            return Msg;
        }

        private void tbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
