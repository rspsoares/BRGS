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
    public partial class ObrasRelatorioConsolidado : Form
    {
        private Helper helper = new Helper();
        private BIZObra bizObra = new BIZObra();
        private List<Obra> lstObrasCadastradas = new List<Obra>();        
        private List<ObraEtapa> lstLicitacoesCliente = new List<ObraEtapa>();
        private List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();

        public ObrasRelatorioConsolidado()
        {
            InitializeComponent();
        }

        private void CarregarObras()
        {
            try
            {
                lstObrasCadastradas = bizObra.PesquisarObra(new Obra()).OrderBy(x => x.nomeEvento).ToList();                
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

        private void CarregarObrasEtapas()
        {
            lstObrasEtapas = new List<ObraEtapa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstObrasEtapas.AddRange(bizObra.PesquisarObraEtapa(new ObraEtapa()));                
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

        private void CarregarCombos()
        {            
            this.CarregarComboClientes();
        }

        private void CarregarComboClientes()
        {
            BIZCliente bizCliente = new BIZCliente();
            List<Cliente> lstClientes = new List<Cliente>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientes.Add(new Cliente() { idCliente = 0, Nome = "--Selecione--" });
                lstClientes.AddRange(bizCliente.PesquisarCliente(new Cliente()).OrderBy(u => u.Nome));

                cbClientes.DataSource = lstClientes;
                cbClientes.DisplayMember = "Nome";
                cbClientes.ValueMember = "idCliente";
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

        private void cbClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            cbClientes.Enabled = chkCliente.Checked;
            chkLicitacao.Enabled = chkCliente.Checked;

            if (chkCliente.Checked == false)
                chkLicitacao.Checked = false;
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            ReportClass obra = new ReportClass();
            DataTable dt = new DataTable();
            string filtro = string.Empty;
            string filtroRelatorio = string.Empty;
            string msgRetorno = string.Empty;

            msgRetorno = this.ValidarFiltro();
            
            if (msgRetorno == string.Empty)
            {
                filtro = this.MontarFiltroSQL();
                filtroRelatorio = this.MontarFiltroRelatorio();

                dt = bizObra.GerarRelatorioRealizadasConsolidado(filtro, filtroRelatorio);
                
                obra = new GastosObrasConsolidado();
                obra.SetDataSource(dt);
                Relatorio gastosObras = new Relatorio(obra);
                gastosObras.Text = "Relatório de Gastos Realizados - Consolidado";
                gastosObras.ShowDialog();               
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            if (chkCliente.Checked)
            {
                filtro += "Cliente: " + cbClientes.Text + " / ";

                if (chkLicitacao.Checked)
                    filtro += "Licitação: " + cbLicitacao.Text + " / ";
            }

            if (chkDataPagamento.Checked)            
                filtro += "Data de Pagto.: De " + dtpDe.Value.ToShortDateString() + " Até " + dtpAte.Value.ToShortDateString();                            

            filtro += optSim.Checked ? "Pagas" : "Em aberto";

            return filtro;
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;

            if (chkCliente.Checked && cbClientes.FindStringExact(cbClientes.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Cliente válido";

            if (chkLicitacao.Checked && cbLicitacao.FindStringExact(cbLicitacao.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Licitação válida";

            if (chkDataPagamento.Checked && dtpDe.Value > dtpAte.Value)
                msgRetorno += Environment.NewLine + "A data de Início não pode ser maior do que a Data de Término";

            if (dtpDe.Value.Year != dtpAte.Value.Year)
                msgRetorno += Environment.NewLine + "O período deve ser do mesmo ano";

            return msgRetorno;
        }

        private string MontarFiltroSQL()
        {
            string filtroSQL = string.Empty;

            if (chkCliente.Checked)
                filtroSQL += " AND C.idCliente = " + int.Parse(cbClientes.SelectedValue.ToString());

            if (chkLicitacao.Checked && int.Parse(cbLicitacao.SelectedValue.ToString()) > 0)
                filtroSQL += " AND OE.idObraEtapa = " + int.Parse(cbLicitacao.SelectedValue.ToString());

            if (chkDataPagamento.Checked)
                filtroSQL += " AND OPI.DataVencimento BETWEEN CONVERT(DATETIME, '" + dtpDe.Value + "', 103) AND CONVERT(DATETIME, '" + dtpAte.Value + "', 103)";

            if (optSim.Checked)
                filtroSQL += " AND OPI.DataPagamento <> '1753-01-01 00:00:00.000'";

            if (optNao.Checked)
                filtroSQL += " AND OPI.DataPagamento = '1753-01-01 00:00:00.000'";
            

            filtroSQL += " ORDER BY C.Nome, OE.NomeEvento";

            return filtroSQL;
        }

        private void ObrasRelatorioConsolidado_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.CarregarObras();
            this.CarregarObrasEtapas();
            
            this.CarregarCombos();

            this.Cursor = Cursors.Default;
        }

        private void chkLicitacao_CheckedChanged(object sender, EventArgs e)
        {
            cbLicitacao.Enabled = chkLicitacao.Checked;
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {             
            if(cbClientes.SelectedIndex == 0)
            {
                cbLicitacao.DataSource = null;
                cbLicitacao.BindingContext = new BindingContext();                    
                return;
            }                

            lstLicitacoesCliente = new List<ObraEtapa>();

            lstLicitacoesCliente.Add(new ObraEtapa() { idObraEtapa = 0, numeroLicitacao = "--Selecione--" });
            
            if(cbClientes.SelectedValue != null)
            {
                lstLicitacoesCliente.AddRange(lstObrasEtapas.Where(x => x.idCliente == int.Parse(cbClientes.SelectedValue.ToString())).OrderBy(y => y.numeroLicitacao).ThenBy(z => z.Descricao));

                foreach (ObraEtapa itemLicitacao in lstLicitacoesCliente)                
                    itemLicitacao.numeroLicitacao =  itemLicitacao.numeroLicitacao + " - " + itemLicitacao.Descricao;
            }

            cbLicitacao.DataSource = lstLicitacoesCliente;
            cbLicitacao.DisplayMember = "numeroLicitacao";
            cbLicitacao.ValueMember = "idObraEtapa";    
        }

        private void chkDataPagamento_CheckedChanged(object sender, EventArgs e)
        {
            dtpDe.Enabled = chkDataPagamento.Checked;
            dtpAte.Enabled = chkDataPagamento.Checked;
        }              
    }
}