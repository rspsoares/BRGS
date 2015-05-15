using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class OrdemPagamentoManutencaoPagamento : Form
    {
        public OrdemPagamentoItem opItem = new OrdemPagamentoItem();
        private Helper helper = new Helper();

        public OrdemPagamentoManutencaoPagamento(OrdemPagamentoItem _opItem)
        {
            InitializeComponent();
            opItem = _opItem;
        }

        private void tbValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbMulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorPago_KeyDown(object sender, KeyEventArgs e)
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

        private void tbMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            tbValor.Text = helper.FormatarValorMoeda(tbValor.Text);
            this.CalcularValorPago();
        }

        private void tbMulta_Leave(object sender, EventArgs e)
        {
            tbMulta.Text = helper.FormatarValorMoeda(tbMulta.Text);
            this.CalcularValorPago();
        }

        private void tbDesconto_Leave(object sender, EventArgs e)
        {
            tbDesconto.Text = helper.FormatarValorMoeda(tbDesconto.Text);
            this.CalcularValorPago();
        }

        private void tbValorPago_Leave(object sender, EventArgs e)
        {
            tbValorPago.Text = helper.FormatarValorMoeda(tbValorPago.Text);
        }

        private void OrdemPagamentoManutencaoPagamento_Load(object sender, EventArgs e)
        {
            lbIdItem.Text = opItem.idOrdemPagamentoItem.ToString();
            tbItem.Text = opItem.descricaoDespesa;
            tbValor.Text = helper.FormatarValorMoeda(opItem.Valor.ToString());
            tbDataVencimento.Value = opItem.dataVencimento;

            chkPago.Checked = opItem.valorPago == decimal.Zero ? false : true;
                     
            tbDataPagamento.Value = opItem.valorPago == decimal.Zero ? DateTime.Now.Date : DateTime.Parse(opItem.dataPagamento.ToString());
            
            tbMulta.Text = opItem.valorPago == decimal.Zero ? "0,00" : helper.FormatarValorMoeda(opItem.Multa.ToString());
            tbDesconto.Text = opItem.valorPago == decimal.Zero ? "0,00" : helper.FormatarValorMoeda(opItem.Desconto.ToString());
            tbValorPago.Text = helper.FormatarValorMoeda(opItem.Valor.ToString());
            this.CalcularValorPago();
        }

        private void chkPago_CheckedChanged(object sender, EventArgs e)
        {
            tbMulta.Enabled = chkPago.Checked;
            tbDesconto.Enabled = chkPago.Checked;
            tbDataPagamento.Enabled = chkPago.Checked;           
        }

        private void CalcularValorPago()
        {
            decimal valorItem = decimal.Zero;
            decimal valorMulta = decimal.Zero;
            decimal valorDesconto = decimal.Zero;
            decimal valorPago = decimal.Zero;

            valorItem = decimal.Parse(tbValor.Text);
            valorMulta = decimal.Parse(tbMulta.Text);
            valorDesconto = decimal.Parse(tbDesconto.Text);
 
            valorPago = valorItem + valorMulta - valorDesconto;

            tbValorPago.Text = helper.FormatarValorMoeda(valorPago.ToString());
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            try
            {
                opItem.Valor = decimal.Parse(tbValor.Text);
                opItem.dataVencimento = tbDataVencimento.Value;
                opItem.Multa = chkPago.Checked ? decimal.Parse(tbMulta.Text) : decimal.Zero;
                opItem.Desconto = chkPago.Checked ? decimal.Parse(tbDesconto.Text) : decimal.Zero;
                opItem.dataPagamento = chkPago.Checked ? tbDataPagamento.Value : DateTime.MinValue;
                opItem.valorPago = chkPago.Checked ? decimal.Parse(tbValorPago.Text) : decimal.Zero;
                opItem.idUsuarioPagamento = chkPago.Checked ? UsuarioLogado.idUsuario : 0;
                opItem.nomeUsuarioPagamento = chkPago.Checked ? UsuarioLogado.Nome : string.Empty;

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
