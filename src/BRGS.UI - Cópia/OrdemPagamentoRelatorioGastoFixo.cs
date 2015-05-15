using BRGS.BIZ;
using BRGS.Entity;
using BRGS.UI.Relatorios;
using BRGS.Util;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class OrdemPagamentoRelatorioGastoFixo : Form
    {
        private BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
        private BIZDespesa bizDespesa = new BIZDespesa();
        private List<Despesa> lstDespesasCadastradas = new List<Despesa>();
        private List<Despesa> lstDespesasSelecionadas = new List<Despesa>();
        private Helper helper = new Helper();        

        public OrdemPagamentoRelatorioGastoFixo()
        {
            InitializeComponent();
        }

        private void OrdemPagamentoRelatorioGastoFixo_Load(object sender, EventArgs e)
        {
            dtpDe.Value = DateTime.Parse("01/01/" + DateTime.Now.Year);
            dtpAte.Value = DateTime.Parse("31/12/" + DateTime.Now.Year);
                        
            this.CarregarComboEmpresas();
            this.CarregarComboUEN();
            this.CarregarDespesas();
        }

        private void CarregarComboEmpresas()
        {
            List<Empresa> lstEmpresas = new List<Empresa>();
            BIZEmpresa bizEmpresa = new BIZEmpresa();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstEmpresas.Add(new Empresa() { idEmpresa = 0, razaoSocial = "--Selecione--" });
                lstEmpresas.AddRange(bizEmpresa.PesquisarEmpresa(new Empresa()).OrderBy(x => x.razaoSocial).ToList());

                cbEmpresa.DataSource = lstEmpresas;
                cbEmpresa.DisplayMember = "razaoSocial";
                cbEmpresa.ValueMember = "idEmpresa";
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

        private void CarregarComboUEN()
        {
            BIZUEN bizUEN = new BIZUEN();
            List<UEN> lstUEN = new List<UEN>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });
                lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(x => x.Descricao));
                

                cbUEN.DataSource = null;
                cbUEN.BindingContext = new BindingContext();
                cbUEN.DataSource = lstUEN;
                cbUEN.DisplayMember = "Descricao";
                cbUEN.ValueMember = "idUEN";
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

        private void CarregarDespesas()
        {
            try
            {
                lstDespesasCadastradas = bizDespesa.PesquisarDespesa(new Despesa()).OrderBy(x => x.Descricao).ToList();
                CarregarGridDespesasCadastradas(lstDespesasCadastradas);
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

                dt = bizOP.GerarRelatorioOrdemPagamentoGastoFixo(filtro, filtroRelatorio);

                opDespesas = new GastosFixos();
                opDespesas.SetDataSource(dt);
                Relatorio gastosFixos = new Relatorio(opDespesas);
                gastosFixos.Text = "Relatório de OP's - Gastos Fixos";
                gastosFixos.ShowDialog();
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;
            
            if(chkEmpresa.Checked && cbEmpresa.FindStringExact(cbEmpresa.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma empresa válida";            
            
            if (chkDataPagamento.Checked)
            {
                if(dtpDe.Value.Date > dtpAte.Value.Date)
                    msgRetorno += Environment.NewLine + "A Data Inicial não pode ser maior do que a Final"; 

                if(dtpDe.Value.Year != dtpAte.Value.Year)
                    msgRetorno += Environment.NewLine + "O intervalo de datas deve ser no mesmo ano";                 
            }

            if (chkUEN.Checked && cbUEN.FindStringExact(cbUEN.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

            if (chkDespesa.Checked && gvDespesasSelecionadas.RowCount == 0)
                msgRetorno += Environment.NewLine + "Favor selecionar alguma Despesa";

            return msgRetorno;
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            if(chkEmpresa.Checked)
                filtro += "Empresa: " + cbEmpresa.Text + " / ";

            if (chkDataPagamento.Checked)
                filtro += "Data de Pagto.: De " + dtpDe.Value.ToShortDateString() + " Até " + dtpAte.Value.ToShortDateString() + " / ";
            else
                filtro += "Datas de Pagamentos do ano atual";

            if (chkUEN.Checked)
                filtro += "UEN: " + cbUEN.Text + " / ";

            if (chkDespesa.Checked)
                filtro += gvDespesasSelecionadas.RowCount > 1 ? "Despesas diversas" : "Despesa: " + gvDespesasSelecionadas[1, 0].Value;

            return filtro;
        }

        private string MontarFiltroSQL()
        {
            string filtroSQL = string.Empty;

            if (chkEmpresa.Checked)
                filtroSQL += " AND E.idEmpresa = " + int.Parse(cbEmpresa.SelectedValue.ToString());

            if (chkDataPagamento.Checked)
                filtroSQL += " AND I.DataPagamento BETWEEN CONVERT(DATETIME, '" + dtpDe.Value.Date + "', 103) AND CONVERT(DATETIME, '" + dtpAte.Value.Date + "', 103)";
            else
                filtroSQL += " AND I.DataPagamento BETWEEN CONVERT(DATETIME, '" + DateTime.Parse("01/01/" + DateTime.Now.Year) + "', 103) AND CONVERT(DATETIME, '" + DateTime.Parse("31/12/" + DateTime.Now.Year) + "', 103)";

            if (chkUEN.Checked)
                filtroSQL += " AND U.idUEN = " + int.Parse(cbUEN.SelectedValue.ToString());

            if (chkDespesa.Checked && lstDespesasSelecionadas.Count > 0)
            {
                filtroSQL += " AND (";
                foreach (Despesa itemDespesa in lstDespesasSelecionadas)
                    filtroSQL += " I.idDespesa = " + itemDespesa.idDespesa + " OR";

                filtroSQL = filtroSQL.Substring(0, filtroSQL.Length - 3);

                filtroSQL += ")";
            }

            return filtroSQL;
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

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            cbEmpresa.Enabled = chkEmpresa.Checked;
        }

        private void chkDataPagamento_CheckedChanged(object sender, EventArgs e)
        {
            dtpDe.Enabled = chkDataPagamento.Checked;
            dtpAte.Enabled = chkDataPagamento.Checked;
        }

        private void chkUEN_CheckedChanged(object sender, EventArgs e)
        {
            cbUEN.Enabled = chkUEN.Checked;
        }

        private void chkDespesa_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = chkDespesa.Checked;
            btAdd.Enabled = chkDespesa.Checked;
            btRem.Enabled = chkDespesa.Checked;
            groupBox4.Enabled = chkDespesa.Checked;
        }

        private void tbFiltroDespesa_TextChanged(object sender, EventArgs e)
        {
            var lstDespesaFiltrada = from lstDespesaFiltro in lstDespesasCadastradas
                                     where lstDespesaFiltro.Descricao.ToUpper().Contains(tbFiltroDespesa.Text.Trim().ToUpper())
                                     select lstDespesaFiltro;

            this.CarregarGridDespesasCadastradas(lstDespesaFiltrada.ToList());
        }
    }
}
