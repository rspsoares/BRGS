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
    public partial class FreteRelatorio : Form
    {
        private Helper helper = new Helper();

        public FreteRelatorio()
        {
            InitializeComponent();
        }

        private void CarregarComboFretistas()
        {
            List<Fornecedor> lstFretistas = new List<Fornecedor>();
            BIZFornecedor bizFornecedor = new BIZFornecedor();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFretistas.Add(new Fornecedor() { idFornecedor = 0, Nome = "--Selecione--" });
                lstFretistas.AddRange(bizFornecedor.PesquisarFornecedor(new Fornecedor()).OrderBy(x => x.Nome).ToList());

                cbFretistas.DataSource = lstFretistas;
                cbFretistas.DisplayMember = "Nome";
                cbFretistas.ValueMember = "idFornecedor";
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

        private void CarregarComboObras()
        {
            BIZObra bizObra = new BIZObra();
            List<ObraEtapa> lstObras = new List<ObraEtapa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstObras.Add(new ObraEtapa() { idObraEtapa = 0,  numeroLicitacao = "--Selecione--" });
                lstObras.AddRange(bizObra.PesquisarObraEtapaFreteCombo());

                cbObras.DataSource = lstObras;
                cbObras.DisplayMember = "numeroLicitacao";
                cbObras.ValueMember = "idObraEtapa";
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

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            BIZFrete bizFrete = new BIZFrete();
            //ReportClass relat = new ReportClass();
            DataTable dt = new DataTable();
            string filtro = string.Empty;
            string filtroRelatorio = string.Empty;
            string msgRetorno = string.Empty;
            string periodoVencimento = string.Empty;

            msgRetorno = this.ValidarFiltro();

            if (msgRetorno == string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;

                filtro = this.MontarFiltroSQL();
                filtroRelatorio = this.MontarFiltroRelatorio();

                dt = bizFrete.GerarRelatorio(filtro, filtroRelatorio);                

                var relat = new FretesGerados();
                relat.SetDataSource(dt);
                Relatorio relatorioFrete = new Relatorio(relat);
                relatorioFrete.Text = "Relatório de Fretes";

                this.Cursor = Cursors.Default;

                relatorioFrete.ShowDialog();
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            if (chkFretista.Checked)
                filtro += "Fretista: " + cbFretistas.Text + " / ";

            if (chkObras.Checked)            
                filtro += "Obra: " + cbObras.Text + " / ";

            return filtro;
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;

            if (chkFretista.Checked && cbFretistas.FindStringExact(cbFretistas.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Fretista válido";

            if (chkObras.Checked && cbObras.FindStringExact(cbObras.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Obra válida";
            
            return msgRetorno;
        }

        private string MontarFiltroSQL()
        {
            string filtroSQL = string.Empty;

            if (chkFretista.Checked && int.Parse(cbFretistas.SelectedValue.ToString()) > 0)
                filtroSQL += " AND Fr.idFornecedor = " + int.Parse(cbFretistas.SelectedValue.ToString());

            if (chkObras.Checked && int.Parse(cbObras.SelectedValue.ToString()) > 0)
                filtroSQL += " AND O.idObraEtapa = " + int.Parse(cbObras.SelectedValue.ToString());

            //filtroSQL += " AND Us.idUsuario = " + UsuarioLogado.idUsuario +
            //    " AND Uc.idUsuario = " + UsuarioLogado.idUsuario;

            return filtroSQL;
        }

        private void cbFretistas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkFretista_CheckedChanged(object sender, EventArgs e)
        {
            cbFretistas.Enabled = chkFretista.Checked;
        }

        private void FreteRelatorio_Load(object sender, EventArgs e)
        {
            this.CarregarComboFretistas();
            this.CarregarComboObras();
        }

        private void chkObras_CheckedChanged(object sender, EventArgs e)
        {
            cbObras.Enabled = chkObras.Checked;
        }

        private void cbObras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
