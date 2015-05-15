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
    public partial class FeriadoManutencao : Form
    {
        private Feriado feriadoOriginal = new Feriado();
        private Feriado feriadoSelecionado = new Feriado();
        private BIZFeriado bizFeriado = new BIZFeriado();        
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public FeriadoManutencao(Feriado _feriado)
        {
            InitializeComponent();

            feriadoOriginal = _feriado;
            feriadoSelecionado = (Feriado)feriadoOriginal.Clone();         
        }

        private void tbDia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbDia_Leave(object sender, EventArgs e)
        {
            if (tbDia.Text == string.Empty || int.Parse(tbDia.Text) > 31)
                tbDia.Text = "0";          
        }

        private void tbMes_Leave(object sender, EventArgs e)
        {
            if (tbMes.Text == string.Empty || int.Parse(tbMes.Text) > 12)
                tbMes.Text = "0";          
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (feriadoSelecionado.idFeriado != 0)
                {   
                    if (MessageBox.Show("Confirma exclusão do Feriado?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        bizFeriado.ExcluirFeriado(feriadoSelecionado);
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

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idFeriado = 0;

            feriadoSelecionado.Dia = int.Parse(tbDia.Text);
            feriadoSelecionado.Mes = int.Parse(tbMes.Text);
            feriadoSelecionado.Descricao = tbDescricao.Text;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (feriadoSelecionado.idFeriado == 0)
                {
                    msgRetorno = bizFeriado.IncluirFeriado(feriadoSelecionado, out idFeriado);
                    acaoSelecionada = "Inclusão";                    
                    feriadoSelecionado.idFeriado = idFeriado;
                }
                else
                {
                    msgRetorno = bizFeriado.AlterarFeriado(feriadoOriginal,feriadoSelecionado);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    feriadoOriginal = (Feriado)feriadoSelecionado.Clone();
                }
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

        private void FeriadoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (feriadoSelecionado.idFeriado != 0)
                {
                    tbDia.Text = feriadoSelecionado.Dia.ToString();
                    tbMes.Text = feriadoSelecionado.Mes.ToString();
                    tbDescricao.Text = feriadoSelecionado.Descricao;                    
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
    }
}
