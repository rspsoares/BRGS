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
    public partial class ParametrizacaoManutencao : Form
    {
        private BIZParametrizacao bizParametrizacao = new BIZParametrizacao();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public ParametrizacaoManutencao()
        {
            InitializeComponent();
        }

        private void ParametrizacaoManutencao_Load(object sender, EventArgs e)
        {
            tbOPDiasVencAlerta.Text = Parametrizacao.diasVencimentoOPAlerta.ToString();
            tbOPDiasVencCritico.Text = Parametrizacao.diasVencimentoOPCritico.ToString();
            tbVeiculoDiasVencAlerta.Text = Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta.ToString();
            tbVeiculoDiasVencCritico.Text = Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico.ToString();
        }

        private void tbOPDiasVencAlerta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbOPDiasVencAlerta_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbOPDiasVencAlerta_Leave(object sender, EventArgs e)
        {
            tbOPDiasVencAlerta.Text = helper.FormatarValorMoeda(tbOPDiasVencAlerta.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void tbOPDiasVencCritico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbOPDiasVencCritico_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbOPDiasVencCritico_Leave(object sender, EventArgs e)
        {
            tbOPDiasVencCritico.Text = helper.FormatarValorMoeda(tbOPDiasVencCritico.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void tbVeiculoDiasVencAlerta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbVeiculoDiasVencAlerta_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbVeiculoDiasVencAlerta_Leave(object sender, EventArgs e)
        {
            tbVeiculoDiasVencAlerta.Text = helper.FormatarValorMoeda(tbVeiculoDiasVencAlerta.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void tbVeiculoDiasVencCritico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbVeiculoDiasVencCritico_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbVeiculoDiasVencCritico_Leave(object sender, EventArgs e)
        {
            tbVeiculoDiasVencCritico.Text = helper.FormatarValorMoeda(tbVeiculoDiasVencCritico.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private string ValidarCampos()
        {
            string msgRetorno = string.Empty;

            if (int.Parse(tbOPDiasVencAlerta.Text) < int.Parse(tbOPDiasVencCritico.Text))
                msgRetorno += Environment.NewLine + "A quantidade de dias de vencimento da OP para Alerta não pode ser menor do que o Crítico";

            if (int.Parse(tbVeiculoDiasVencAlerta.Text) < int.Parse(tbVeiculoDiasVencCritico.Text))
                msgRetorno += Environment.NewLine + "A quantidade de dias de vencimento da Documentação do Veículo para Alerta não pode ser menor do que o Crítico";
            
            return msgRetorno;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            msgRetorno = ValidarCampos();

            if(msgRetorno != string.Empty)
            {
                MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            
            try
            {


                Parametrizacao.diasVencimentoOPAlerta = int.Parse(tbOPDiasVencAlerta.Text);
                Parametrizacao.diasVencimentoOPCritico = int.Parse(tbOPDiasVencCritico.Text);
                Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta = int.Parse(tbVeiculoDiasVencAlerta.Text);
                Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico = int.Parse(tbVeiculoDiasVencCritico.Text);

                bizParametrizacao.AtualizarParametrizacao();

                MessageBox.Show("Alteração efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tabControl1.SelectTab(0);

            this.Cursor = Cursors.Default;
        }
    }
}
