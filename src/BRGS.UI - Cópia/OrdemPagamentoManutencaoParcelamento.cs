using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class OrdemPagamentoManutencaoParcelamento : Form
    {
        private Helper helper = new Helper();
        public List<OrdemPagamentoItemParcela> lstParcelas = new List<OrdemPagamentoItemParcela>();
        public List<OrdemPagamentoItemParcela> lstParcelasTemp = new List<OrdemPagamentoItemParcela>();
        private BIZFeriado bizFeriado = new BIZFeriado();
 
        public OrdemPagamentoManutencaoParcelamento(OrdemPagamentoItemParcela parcelado)
        {
            InitializeComponent();
            tbValorTotal.Text = helper.FormatarValorMoeda(parcelado.valorParcela.ToString());
            tbDataPrimeiroVencimento.Value = parcelado.dataVencimento;
        }

        private void tbValorTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorTotal_Leave(object sender, EventArgs e)
        {
            tbValorTotal.Text = helper.FormatarValorMoeda(tbValorTotal.Text);
        }

        private void tbValorParcela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorParcela_Leave(object sender, EventArgs e)
        {
            tbValorParcela.Text = helper.FormatarValorMoeda(tbValorParcela.Text);
        }

        private void tbNumeroParcelas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbNumeroParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            msgRetorno = this.ValidarParcelamento();

            if (msgRetorno == string.Empty)
                this.GerarParcelamento();
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string ValidarParcelamento()
        {
            string msgRetorno = string.Empty;

            if (tbValorTotal.Text == string.Empty || tbValorTotal.Text == "0,00")
                msgRetorno += Environment.NewLine + "Favor informar o Valor";

            if (tbNumeroParcelas.Text == string.Empty || tbNumeroParcelas.Text == "0")
                msgRetorno += Environment.NewLine + "Favor informar o Número de Parcelas";

            return msgRetorno;
        }

        private void GerarParcelamento()
        {
            decimal valorTotal = 0;
            decimal valorParcelaAtual = 0;
            decimal valorAcumulado = 0;
            int qtdParcelas = 0;
            List<Feriado> lstFeriados = new List<Feriado>();

            lstFeriados = bizFeriado.PesquisarFeriados(new Feriado());

            lstParcelasTemp = new List<OrdemPagamentoItemParcela>();

            valorTotal = decimal.Parse(tbValorTotal.Text);
            qtdParcelas = int.Parse(tbNumeroParcelas.Text);

            valorParcelaAtual = valorTotal / qtdParcelas;
            valorParcelaAtual = decimal.Parse(helper.FormatarValorMoeda(valorParcelaAtual.ToString()));

            for (int i = 1; i < qtdParcelas; i++) // Adicionar até a penúltima parcela
            {
                lstParcelasTemp.Add(new OrdemPagamentoItemParcela()
                {                     
                     valorParcela = decimal.Parse(helper.FormatarValorMoeda(valorParcelaAtual.ToString())),
                     dataVencimento = helper.CalcularDataVencimento(tbDataPrimeiroVencimento.Value, i - 1, lstFeriados),  // tbDataPrimeiroVencimento.Value.AddMonths(i - 1),
                     numeroParcela = i,
                     totalParcelas = qtdParcelas
                });

                valorAcumulado += decimal.Parse(helper.FormatarValorMoeda(valorParcelaAtual.ToString()));
            }

            // Adicionar a última parcela com o valor restante
            lstParcelasTemp.Add(new OrdemPagamentoItemParcela()
            {
                numeroParcela = qtdParcelas,
                valorParcela = valorTotal - valorAcumulado,
                dataVencimento = helper.CalcularDataVencimento(tbDataPrimeiroVencimento.Value, qtdParcelas - 1, lstFeriados), // tbDataPrimeiroVencimento.Value.AddMonths(qtdParcelas - 1),
                totalParcelas = qtdParcelas 
            });

            this.AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            decimal valorTotalParcelas = decimal.Zero;

            while (gvParcelas.Rows.Count > 0)
                gvParcelas.Rows.RemoveAt(0);

            if (lstParcelasTemp.Count == 0)
                return;

            gvParcelas.Columns[0].DefaultCellStyle.Format = "N0";
            gvParcelas.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvParcelas.Columns[2].DefaultCellStyle.Format = "N2";

            foreach (OrdemPagamentoItemParcela parcela in lstParcelasTemp)
            {
                gvParcelas.Rows.Add(new object[] 
                {
                    parcela.numeroParcela,
                    parcela.dataVencimento.Date,
                    parcela.valorParcela
                });
            }

            valorTotalParcelas = lstParcelasTemp.Sum(x => x.valorParcela);

            lbTotal.Text = "Total: R$ " + helper.FormatarValorMoeda(valorTotalParcelas.ToString());
            lbTotal.ForeColor = valorTotalParcelas != decimal.Parse(tbValorTotal.Text) ? Color.Red : Color.Black;
        }
        
        private string ValidarParcela()
        {
            string msgRetorno = string.Empty;

            if (tbValorTotal.Text == string.Empty || tbValorTotal.Text == "0,00")
                msgRetorno += Environment.NewLine + "Favor informar o novo Valor da Parcela";

            return msgRetorno;
        }

        private void gvParcelas_SelectionChanged(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            
            if (gvParcelas.SelectedCells.Count == 0)
                return;

            linhaGrid = gvParcelas.SelectedCells[0].RowIndex;
            
            lbID.Text = gvParcelas[0, linhaGrid].Value.ToString();
            tbDataVencimentoParcela.Value = DateTime.Parse(gvParcelas[1, linhaGrid].Value.ToString());
            tbValorParcela.Text = helper.FormatarValorMoeda(gvParcelas[2, linhaGrid].Value.ToString());
        }

        private void btAtualizarParcela_Click(object sender, EventArgs e)
        {
            OrdemPagamentoItemParcela parcelaAtualizada = new OrdemPagamentoItemParcela();            
            string msgRetorno = string.Empty;

            try
            {
                msgRetorno = this.ValidarParcela();
                if (msgRetorno == string.Empty)
                {
                    lstParcelasTemp.Where(x => x.numeroParcela == int.Parse(lbID.Text)).First().valorParcela = decimal.Parse(tbValorParcela.Text);
                    lstParcelasTemp.Where(x => x.numeroParcela == int.Parse(lbID.Text)).First().dataVencimento = tbDataVencimentoParcela.Value;

                    this.AtualizarGrid();
                }             
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            if (lstParcelasTemp.Sum(x => x.valorParcela) > decimal.Parse(tbValorTotal.Text))
            {
                MessageBox.Show("A soma do Valor das Parcelas ultrapassa o Valor Total", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                this.Close();
                lstParcelas = lstParcelasTemp;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            lstParcelas = new List<OrdemPagamentoItemParcela>();
            this.Close();
        }
    }
}
