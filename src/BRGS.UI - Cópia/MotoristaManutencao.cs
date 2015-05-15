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
    public partial class MotoristaManutencao : Form
    {       
        private BIZMotorista bizMotorista = new BIZMotorista();        
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        private Motorista motoristaSelecionado = new Motorista();         

        public MotoristaManutencao(Motorista _motorista)
        {
            InitializeComponent();
            motoristaSelecionado = _motorista;
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idMotorista = 0;

            motoristaSelecionado.Nome = tbNome.Text;
            motoristaSelecionado.RG = tbRG.Text;
            motoristaSelecionado.CPF = helper.FormatarCPF_CNPJ(tbCPF.Text);
            motoristaSelecionado.Telefone = tbTelefone.Text;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (motoristaSelecionado.idMotorista == 0)
                {
                    msgRetorno = bizMotorista.IncluirMotorista(motoristaSelecionado, out idMotorista);
                    acaoSelecionada = "Inclusão";                    
                    motoristaSelecionado.idMotorista = idMotorista;
                }
                else
                {
                    msgRetorno = bizMotorista.AlterarMotorista(motoristaSelecionado);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;            
            
            try
            {
                if (motoristaSelecionado.idMotorista != 0)
                {   
                    if (MessageBox.Show("Confirma exclusão do Motorista?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        bizMotorista.ExcluirMotorista(motoristaSelecionado);
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); 
                    }                    
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
        }

        private void MotoristaManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (motoristaSelecionado.idMotorista != 0)                
                {
                    motoristaSelecionado = bizMotorista.PesquisarMotorista(new Motorista() { idMotorista = motoristaSelecionado.idMotorista })[0];

                    tbNome.Text = motoristaSelecionado.Nome;
                    tbRG.Text = motoristaSelecionado.RG;
                    tbCPF.Text = motoristaSelecionado.CPF;
                    tbTelefone.Text = motoristaSelecionado.Telefone;
                }                
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

        private void tbRG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCPF_Leave(object sender, EventArgs e)
        {
            tbCPF.Text = helper.FormatarCPF_CNPJ(tbCPF.Text);
        }
    }
}