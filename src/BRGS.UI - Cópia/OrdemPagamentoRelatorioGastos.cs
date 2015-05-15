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
using BRGS.UI.Relatorios;
using BRGS.Util;
using CrystalDecisions.CrystalReports.Engine;

namespace BRGS.UI
{
    public partial class OrdemPagamentoRelatorioGastos : Form
    {
        private Helper helper = new Helper();
        private BIZDespesa bizDespesa = new BIZDespesa();
        private List<Despesa> lstDespesasCadastradas = new List<Despesa>();
        private List<Despesa> lstDespesasSelecionadas = new List<Despesa>();
        private BIZOrdemPagamento bizOP = new BIZOrdemPagamento();

        public OrdemPagamentoRelatorioGastos()
        {
            InitializeComponent();
        }

        private void OrdemPagamentoRelatorioGastos_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.CarregarDespesas();
            this.CarregarGridDespesasCadastradas(lstDespesasCadastradas);            
            this.Cursor = Cursors.Default;
        }

        private void CarregarDespesas()
        {
            try
            {
                lstDespesasCadastradas = bizDespesa.PesquisarDespesa(new Despesa()).OrderBy(x => x.Descricao).ToList() ;
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

        private void CarregarGridDespesasCadastradas(List<Despesa> lstFiltro)
        {
            while (gvDespesasCadastradas.Rows.Count > 0)
                gvDespesasCadastradas.Rows.RemoveAt(0);

            foreach (Despesa itemDespesa in lstFiltro)
            {
                gvDespesasCadastradas.Rows.Add(new object[] 
                {
                    itemDespesa.idDespesa, 
                    itemDespesa.Descricao 
                });
            }
        }
        
        private void CarregarGridDespesasSelecionadas()
        {
            while (gvDespesasSelecionadas.Rows.Count > 0)
                gvDespesasSelecionadas.Rows.RemoveAt(0);

            foreach (Despesa itemDespesa in lstDespesasSelecionadas)
            {
                gvDespesasSelecionadas.Rows.Add(new object[] 
                {
                    itemDespesa.idDespesa, 
                    itemDespesa.Descricao 
                });
            }
        }

        private void tbFiltroEvento_TextChanged(object sender, EventArgs e)
        {
            var lstDespesaFiltrada = from lstDespesaFiltro in lstDespesasCadastradas
                                     where lstDespesaFiltro.Descricao.ToUpper().Contains(tbFiltroDespesa.Text.Trim().ToUpper())
                                     select lstDespesaFiltro;

            this.CarregarGridDespesasCadastradas(lstDespesaFiltrada.ToList());    
        }
        
        private void chkDataVencimento_CheckedChanged(object sender, EventArgs e)
        {
            tbVencimentoDe.Enabled = chkDataVencimento.Checked;
            tbVencimentoAte.Enabled = chkDataVencimento.Checked;
        }

        private void chkPaga_CheckedChanged(object sender, EventArgs e)
        {
            optSim.Enabled = chkPaga.Checked;
            optNao.Enabled = chkPaga.Checked;
        }

        private void chkDespesa_CheckedChanged(object sender, EventArgs e)
        {
            chkCustoFixo.Enabled = chkDespesa.Checked;
            tbFiltroDespesa.Enabled = chkDespesa.Checked;
            gvDespesasCadastradas.Enabled = chkDespesa.Checked;
            btAdd.Enabled = chkDespesa.Checked;
            btRem.Enabled = chkDespesa.Checked;
            gvDespesasSelecionadas.Enabled = chkDespesa.Checked; 
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int idDespesaCadastrada = 0;
            string nomeDespesaCadastrada = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvDespesasCadastradas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idDespesaCadastrada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                nomeDespesaCadastrada = linhaSelecionada.Cells[1].Value.ToString();

                if (lstDespesasSelecionadas.Exists(x => x.idDespesa == idDespesaCadastrada))
                    MessageBox.Show("A Despesa " + nomeDespesaCadastrada + " já foi selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    lstDespesasSelecionadas.Add(new Despesa()
                    {
                        idDespesa = idDespesaCadastrada,
                        Descricao = nomeDespesaCadastrada
                    });
                }
            }

            this.CarregarGridDespesasSelecionadas();
        }

        private void btRem_Click(object sender, EventArgs e)
        {
            int idDespesaSelecionada = 0;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvDespesasSelecionadas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idDespesaSelecionada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                lstDespesasSelecionadas.RemoveAll(item => item.idDespesa == idDespesaSelecionada);
            }

            this.CarregarGridDespesasSelecionadas();
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;

            if (chkDataVencimento.Checked && tbVencimentoDe.Value.Date > tbVencimentoAte.Value.Date)
                msgRetorno += Environment.NewLine + "A Data de Vencimento Inicial não pode ser maior do que a Final";

            if (chkDataPagamento.Checked && tbPagamentoDe.Value.Date > tbPagamentoAte.Value.Date)
                msgRetorno += Environment.NewLine + "A Data de Pagamento Inicial não pode ser maior do que a Final";
  
            if(chkDespesa.Checked && gvDespesasSelecionadas.RowCount == 0)
                msgRetorno += Environment.NewLine + "Favor selecionar alguma Despesa";
            
            return msgRetorno;
        }

        private string MontarFiltroSQL()
        {
            string filtroSQL = string.Empty;

            if (chkDataVencimento.Checked)
                filtroSQL += " AND I.DataVencimento BETWEEN CONVERT(DATETIME, '" + tbVencimentoDe.Value.Date + "', 103) AND CONVERT(DATETIME, '" + tbVencimentoAte.Value.Date + "', 103)";

            if (chkDataPagamento.Checked)
                filtroSQL += " AND I.DataPagamento BETWEEN CONVERT(DATETIME, '" + tbPagamentoDe.Value.Date + "', 103) AND CONVERT(DATETIME, '" + tbPagamentoAte.Value.Date + "', 103)";

            if (chkPaga.Checked)            
                filtroSQL += optSim.Checked ? " AND I.DataPagamento <> '1753-01-01 00:00:00.000'" : " AND I.DataPagamento = '1753-01-01 00:00:00.000'";

            if (chkDespesa.Checked && lstDespesasSelecionadas.Count > 0)
            {
                filtroSQL += " AND (";
                foreach (Despesa itemDespesa in lstDespesasSelecionadas)
                    filtroSQL += " I.idDespesa = " + itemDespesa.idDespesa + " OR";

                filtroSQL = filtroSQL.Substring(0, filtroSQL.Length - 3);

                filtroSQL += ")";
            }

            filtroSQL += " AND Us.idUsuario = " + UsuarioLogado.idUsuario + 
                " AND Uc.idUsuario = " + UsuarioLogado.idUsuario + 
                " AND Ud.idUsuario =  " + UsuarioLogado.idUsuario;

            return filtroSQL;
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            ReportClass opDespesas = new ReportClass();
            DataTable dt = new DataTable();
            string filtro = string.Empty;
            string filtroRelatorio = string.Empty;
            string msgRetorno = string.Empty;

            msgRetorno = this.ValidarFiltro();

            if (msgRetorno == string.Empty)
            {
                filtro = this.MontarFiltroSQL();
                filtroRelatorio = this.MontarFiltroRelatorio();

                dt = bizOP.GerarRelatorioOrdemPagamentoGastoObra(filtro,filtroRelatorio);

                opDespesas = new OrdemPagamentoGastos();
                opDespesas.SetDataSource(dt);
                Relatorio gastosObras = new Relatorio(opDespesas);
                gastosObras.Text = "Relatório de OP's - Gastos";
                gastosObras.ShowDialog();
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            if (chkDataVencimento.Checked)
                filtro += "Data de Pagto.: De " + tbVencimentoDe.Value.ToShortDateString() + " Até " + tbVencimentoAte.Value.ToShortDateString() + " / ";

            if (chkDataVencimento.Checked)            
                filtro += "Data de Venc.: De " + tbPagamentoDe.Value.ToShortDateString() + " Até " + tbVencimentoAte.Value.ToShortDateString() + " / ";
                
            if (chkPaga.Checked)
                filtro += optSim.Checked ? "Pagas / " : "Em aberto / ";
            
            if (chkDespesa.Checked)            
                filtro += gvDespesasSelecionadas.RowCount > 1 ? "Despesas diversas" : "Despesa: " + gvDespesasSelecionadas[1,0].Value;
           
            return filtro;
        }

        private void chkDataPagamento_CheckedChanged(object sender, EventArgs e)
        {
            tbPagamentoDe.Enabled = chkDataPagamento.Checked;
            tbPagamentoAte.Enabled = chkDataPagamento.Checked;
        }

        private void chkCustoFixo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustoFixo.Checked)
            {
                lstDespesasSelecionadas = lstDespesasCadastradas.Where(x => x.gastoFixo == 1).ToList();
                this.CarregarGridDespesasSelecionadas();
            }
        }
    }
}
