using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using BRGS.UI.Relatorios;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace BRGS.UI
{
    public partial class NotaFiscalRelatorio : Form
    {   
        private BIZNotaFiscal bizNotaFiscal = new BIZNotaFiscal();
        private Helper helper = new Helper();

        public NotaFiscalRelatorio()
        {
            InitializeComponent();                      
        }

        private void CarregarCombos()
        {
            this.CarregarComboEmpresas();
            this.CarregarComboClientes();
            this.CarregarComboTipoNota();
        }

        private void CarregarComboTipoNota()
        {
            List<NotaFiscalTipo> lstTipoNF = new List<NotaFiscalTipo>();

            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 1, Descricao = "Locação" });
            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 2, Descricao = "Serviço" });
            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 3, Descricao = "Venda" });

            cbTipoNota.DataSource = lstTipoNF;
            cbTipoNota.DisplayMember = "Descricao";
            cbTipoNota.ValueMember = "idTipoNota";
            cbTipoNota.SelectedIndex = 0;
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

        private void CarregarComboEmpresas()
        {
            List<Empresa> lstEmpresas = new List<Empresa>();
            BIZEmpresa bizEmpresa = new BIZEmpresa();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstEmpresas.Add(new Empresa() { idEmpresa = 0, razaoSocial = "--Selecione--" });
                lstEmpresas.AddRange(bizEmpresa.PesquisarEmpresa(new Empresa()).OrderBy(x => x.razaoSocial).ToList());

                cbEmpresas.DataSource = lstEmpresas;
                cbEmpresas.DisplayMember = "razaoSocial";
                cbEmpresas.ValueMember = "idEmpresa";
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

        private void tbDe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbAte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private string MontarFiltroSQL()
        {                       
            string filtroSQL = string.Empty;

            if (chkEmpresa.Checked)
                filtroSQL += " AND E.idEmpresa = " + int.Parse(cbEmpresas.SelectedValue.ToString());

            if(chkCliente.Checked)
                filtroSQL += " AND C.idCliente = " + int.Parse(cbClientes.SelectedValue.ToString());

            if (chkDataEmissao.Checked)
                filtroSQL += " AND NF.DataEmissao BETWEEN CONVERT(DATETIME, '" + dtpDe.Value + "', 103) AND CONVERT(DATETIME, '" + dtpAte.Value + "', 103)";

            if (chkPaga.Checked)
            {
                if (optSim.Checked)
                    filtroSQL += " AND NF.ValorPago > 0";
                else                
                    filtroSQL += " AND NF.ValorPago = 0";
            }               

            if(chkTipo.Checked)
                filtroSQL += " AND NF.TipoNota = " + int.Parse(cbTipoNota.SelectedValue.ToString());

            if (chkStatus.Checked)
            {
                if(optAtivo.Checked)
                    filtroSQL += " AND NF.Cancelado = 0";
                else
                    filtroSQL += " AND NF.Cancelado = 1";               
            }                

            return filtroSQL;
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;           

            if (chkEmpresa.Checked && cbEmpresas.FindStringExact(cbEmpresas.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Empresa válida";

            if (chkCliente.Checked && cbClientes.FindStringExact(cbClientes.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Cliente válido";

            if (chkDataEmissao.Checked && dtpDe.Value > dtpAte.Value) 
                msgRetorno += Environment.NewLine + "A Data Inicial não pode ser maior do que a Data Final";
            
            return msgRetorno;
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            ReportClass nf = new ReportClass();
            DataTable dt = new DataTable();
            string filtro = string.Empty;
            string filtroRelatorio = string.Empty;
            string msgRetorno = string.Empty;
            
            msgRetorno = this.ValidarFiltro();
            
            if (msgRetorno == string.Empty)
            {
                filtro = this.MontarFiltroSQL();
                filtroRelatorio = this.MontarFiltroRelatorio();

                dt = bizNotaFiscal.GerarRelatorioNotasFiscaisEmitidas(filtro, filtroRelatorio);
                dt.DefaultView.Sort = this.VerificarOrdenacao();
                dt = dt.DefaultView.ToTable();

                if (rbResumido.Checked)
                {
                    nf = new NotasFiscaisEmitidas_Resumido();
                    nf.SetDataSource(dt);
                    Relatorio nfResumido = new Relatorio(nf);
                    nfResumido.Text = "Notas Fiscais Emitidas - Resumido";
                    nfResumido.ShowDialog();
                }
                else
                {
                    nf = new NotasFiscaisEmitidas_Completo();
                    nf.SetDataSource(dt);
                    Relatorio nfResumido = new Relatorio(nf);
                    nfResumido.Text = "Notas Fiscais Emitidas - Completo";
                    nfResumido.ShowDialog();
                }
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            // Filtro
            if (chkEmpresa.Checked)
                filtro += "Empresa: " + cbEmpresas.Text + " / ";

            if (chkCliente.Checked)            
                filtro += "Cliente: " + cbClientes.Text + " / ";

            if (chkDataEmissao.Checked)
                filtro += "Data de Emissão: De " + dtpDe.Value.ToShortDateString() + " Até " + dtpAte.Value.ToShortDateString() + " / ";

            if (chkPaga.Checked)
                filtro += optSim.Checked ? "Pagas / " : "Em aberto / ";
                        
            if (chkTipo.Checked)
                filtro += "Tipo Nota: " + cbTipoNota.Text + " / ";
            
            if(chkStatus.Checked)
                filtro += optAtivo.Checked ? "Ativas / " : "Canceladas / ";
            
            // Ordenação
            if (rbNumeroNF.Checked)
                filtro += "Ordenado por Número Nota Fiscal / ";

            if(rbDataEmissao.Checked)
                filtro += "Ordenado por Data de Emissão / ";

            if(rbCliente.Checked)
                filtro += "Ordenado por Cliente / ";

            if(rbEvento.Checked)
                filtro += "Ordenado por Evento / ";

            if(rbDataPagamento.Checked)
                filtro += "Ordenado por Data de Pagto. / ";

            // Direção
            filtro += rbAsc.Checked ? "Ascendente / " : "Descendente / ";

            return filtro;
        }

        private string VerificarOrdenacao()
        {
            string ordemRelatorio = string.Empty;
            string direcaoRelatorio = string.Empty;

            direcaoRelatorio = rbAsc.Checked ? " ASC " : " DESC ";
            
            if (rbNumeroNF.Checked)
                ordemRelatorio = "NumeroNota" + direcaoRelatorio;

            if(rbDataEmissao.Checked)
                ordemRelatorio = "DataEmissao" + direcaoRelatorio;

            if(rbCliente.Checked)
                ordemRelatorio = "Nome" + direcaoRelatorio;

            if(rbEvento.Checked)
                ordemRelatorio = "DescricaoServico" + direcaoRelatorio;

            if(rbDataPagamento.Checked)
                ordemRelatorio = "DataPagamento" + direcaoRelatorio;

            return ordemRelatorio;
        }

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            cbEmpresas.Enabled = chkEmpresa.Checked;
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            cbClientes.Enabled = chkCliente.Checked;
        }

        private void chkDataEmissao_CheckedChanged(object sender, EventArgs e)
        {
            dtpDe.Enabled = chkDataEmissao.Checked;
            dtpAte.Enabled = chkDataEmissao.Checked;            
        }

        private void chkPaga_CheckedChanged(object sender, EventArgs e)
        {
            optSim.Enabled = chkPaga.Checked;
            optNao.Enabled = chkPaga.Checked;
        }

        private void cbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cboTipoNota_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            cbTipoNota.Enabled = chkTipo.Checked;
        }

        private void cbTipoNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void NotaFiscalRelatorio_Load(object sender, EventArgs e)
        {
            this.CarregarCombos();
            dtpDe.Value = DateTime.Now;
            dtpAte.Value = DateTime.Now;
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            optAtivo.Enabled = chkStatus.Checked;
            optCancelado.Enabled = chkStatus.Checked;
        }
    }
}
