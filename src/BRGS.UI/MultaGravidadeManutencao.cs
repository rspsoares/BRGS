using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class MultaGravidadeManutencao : Form
    {
        private MultaGravidade gravidadeSelecionada = new MultaGravidade();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public MultaGravidadeManutencao(MultaGravidade _gravidadeSelecionada)
        {
            InitializeComponent();
            gravidadeSelecionada = _gravidadeSelecionada;
        }

        private void MultaGravidadeManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (gravidadeSelecionada.idGravidade > 0)
                    this.CarregarGravidade();
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

        private void CarregarGravidade()
        {
            tbDescricao.Text = gravidadeSelecionada.Descricao;
            tbValor.Text = helper.FormatarValorMoeda(gravidadeSelecionada.Valor.ToString());
        }

        private void cbGravidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void PopularEntidade()
        {
            gravidadeSelecionada.Descricao = tbDescricao.Text;
            gravidadeSelecionada.Valor = decimal.Parse(tbValor.Text);            
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idGravidade = 0;

            try
            {
                this.PopularEntidade();

                if (gravidadeSelecionada.idGravidade == 0)
                {
                    msgRetorno = bizVeiculo.IncluirMultaGravidade(gravidadeSelecionada, out idGravidade);
                    gravidadeSelecionada.idGravidade = idGravidade;
                    acaoSelecionada = "Inclusão";
                }
                else
                {
                    msgRetorno = bizVeiculo.AlterarMultaGravidade(gravidadeSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (gravidadeSelecionada.idGravidade == 0)
                    return;

                msgRetorno = bizVeiculo.ValidarExclusaoMultaGravidade(gravidadeSelecionada);

                if (msgRetorno == string.Empty)
                {
                    if (MessageBox.Show("Confirma exclusão da gravidade ?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizVeiculo.ExcluirMultaGravidade(gravidadeSelecionada);
                    MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
        }

        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDesdobramento_KeyDown(object sender, KeyEventArgs e)
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

        private void tbInfrator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }      

        private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            tbValor.Text = helper.FormatarValorMoeda(tbValor.Text);
        }             
    }
}
 