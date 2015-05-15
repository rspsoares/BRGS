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
    public partial class OrdemPagamentoRelatorio : Form
    {
        private BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
        private BIZObra bizObra = new BIZObra();
        private BIZCliente bizCliente = new BIZCliente();
        private BIZFornecedor bizFornecedor = new BIZFornecedor();
        private Helper helper = new Helper();        
        private List<ObraEtapa> lstObras = new List<ObraEtapa>();
        private List<ObraEtapa> lstLicitacoesCliente = new List<ObraEtapa>();

        public OrdemPagamentoRelatorio()
        {
            InitializeComponent();
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

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            ReportClass op = new ReportClass();
            DataTable dt = new DataTable();
            string filtroSQL = string.Empty;
            string ordenacao = string.Empty;
            string msgRetorno = string.Empty;
            string filtroRelatorio = string.Empty;

            msgRetorno = this.ValidarFiltro();

            if (msgRetorno == string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;

                filtroSQL = this.MontarFiltroSQL();
                filtroRelatorio = this.MontarFiltroRelatorio();

                dt = bizOP.GerarRelatorioOrdemPagamentoEmitida(filtroSQL, filtroRelatorio);

                dt = VerificarOrdenacao(dt, rbAgrupado.Checked);

                if (rbAgrupado.Checked)
                {   
                    op = new OrdemPagamentoEmitidas();
                    op.SetDataSource(dt);
                    Relatorio opEmitidas = new Relatorio(op);
                    opEmitidas.Text = "Relatório de Ordens de Pagamentos Emitidas";                  
                    opEmitidas.ShowDialog();                   
                }
                else
                {                    
                    op = new OrdemPagamentoEmitidas_Resumido();                    
                    op.SetDataSource(dt);
                    Relatorio opEmitidas = new Relatorio(op);
                    opEmitidas.Text = "Relatório de Ordens de Pagamentos Emitidas - Resumido";                   
                    opEmitidas.ShowDialog();
                }
                
                this.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            if (chkEmpresa.Checked)
                filtro += "Empresa: " + cbEmpresa.Text + " / ";

            if(chkCliente.Checked)
            {
                filtro += "Cliente: " + cbCliente.Text + " / "; 
 
                if(chkLicitacao.Checked)
                    filtro += "Licitação: " + cbLicitacao.Text + " / "; 
            }

            if(chkFavorecido.Checked)
                filtro += "Favorecido: " + cbFavorecido.Text + " / "; 

            if(chkNomeEvento.Checked)
                filtro += "Evento: " + cbNomeEvento.Text + " / "; 

            if(chkDataVencimento.Checked)
            {
                filtro += "Data de Venc.: De " + dtpDe.Value.ToShortDateString() + " Até " + dtpAte.Value.ToShortDateString();
                filtro += optAscendente.Checked ? " Ascendente / " : " Descendente / ";
            }

            if (chkPaga.Checked)
                filtro += optSim.Checked ? "Pagas" : "Em aberto";

            return filtro;
        }

        private DataTable VerificarOrdenacao(DataTable dt, bool relatorioAgrupado)
        {
            DataView dtView = new DataView(dt);
            string ordenacao;
         
            if(relatorioAgrupado)
            {
                if (chkDataVencimento.Checked)                
                    ordenacao = optAscendente.Checked ? " DataVencimento ASC" : " DataVencimento DESC" + ", NomeFavorecido ASC";                
                else
                    ordenacao = " NomeFavorecido ASC, DataVencimento ASC";
            }
            else
            {
                if (chkDataVencimento.Checked)
                    ordenacao = optAscendente.Checked ? " DataVencimento ASC" : " DataVencimento DESC" + ", NomeFavorecido ASC, Valor ASC";
                else
                    ordenacao = " DataVencimento ASC, NomeFavorecido ASC, Valor ASC";
            }            
            
            dtView.Sort = ordenacao;
            return dtView.ToTable();
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;

            if (chkEmpresa.Checked && cbEmpresa.FindStringExact(cbEmpresa.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Empresa válida";

            if (chkCliente.Checked && cbCliente.FindStringExact(cbCliente.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Cliente válido";

            if (chkLicitacao.Checked && cbLicitacao.FindStringExact(cbLicitacao.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Número de Licitação válido";

            if (chkFavorecido.Checked && cbFavorecido.FindStringExact(cbFavorecido.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Favorecido válido";

            if (chkNomeEvento.Checked && cbNomeEvento.FindStringExact(cbNomeEvento.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Evento válido";
            
            if (chkDataVencimento.Checked && dtpDe.Value > dtpAte.Value)
                msgRetorno += Environment.NewLine + "A data de Início não pode ser maior do que a Data de Término";

            return msgRetorno;
        }

        private string MontarFiltroSQL()
        {
            string filtroSQL = string.Empty;

            if (chkEmpresa.Checked && int.Parse(cbEmpresa.SelectedValue.ToString()) > 0)
                filtroSQL += " AND O.idEmpresa = " + int.Parse(cbEmpresa.SelectedValue.ToString());
            
            if (chkFavorecido.Checked && int.Parse(cbFavorecido.SelectedValue.ToString()) > 0)
                filtroSQL += " AND O.idFavorecido = " + int.Parse(cbFavorecido.SelectedValue.ToString());

            if (chkCliente.Checked && int.Parse(cbCliente.SelectedValue.ToString()) > 0)
                filtroSQL += " AND OB.idCliente = " + int.Parse(cbCliente.SelectedValue.ToString());

            if (chkLicitacao.Checked && int.Parse(cbLicitacao.SelectedValue.ToString()) > 0)
                filtroSQL += " AND OB.idObraEtapa = " + int.Parse(cbLicitacao.SelectedValue.ToString());
                       
            if (chkNomeEvento.Checked && int.Parse(cbNomeEvento.SelectedValue.ToString()) > 0)
                filtroSQL += " AND OB.NomeEvento = '" + cbNomeEvento.Text + "'";

            if (chkDataVencimento.Checked)            
                filtroSQL += " AND I.DataVencimento BETWEEN CONVERT(DATETIME, '" + dtpDe.Value + "', 103) AND CONVERT(DATETIME, '" + dtpAte.Value + "', 103)";
               
            if (chkPaga.Checked)
            {
                if (optSim.Checked)                        
                    filtroSQL += " AND I.DataPagamento <> '1753-01-01 00:00:00.000'";

                if (optNao.Checked)                        
                    filtroSQL += " AND I.DataPagamento = '1753-01-01 00:00:00.000'";
            }

            filtroSQL += " AND USU.idUsuario = " + UsuarioLogado.idUsuario + 
                " AND Uc.idUsuario = " + UsuarioLogado.idUsuario + 
                " AND Ud.idUsuario =  " + UsuarioLogado.idUsuario;
    
            return filtroSQL;
        }

        private void cbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            cbEmpresa.Enabled = chkEmpresa.Checked;
        }

        private void chkDataVencimento_CheckedChanged(object sender, EventArgs e)
        {
            dtpDe.Enabled = chkDataVencimento.Checked;
            dtpAte.Enabled = chkDataVencimento.Checked;
            optAscendente.Enabled = chkDataVencimento.Checked;
            optDescendente.Enabled = chkDataVencimento.Checked;
        }

        private void chkPaga_CheckedChanged(object sender, EventArgs e)
        {
            optSim.Enabled = chkPaga.Checked;
            optNao.Enabled = chkPaga.Checked;
        }

        private void OrdemPagamentoRelatorio_Load(object sender, EventArgs e)
        {
            dtpDe.Value = DateTime.Today;
            dtpAte.Value = DateTime.Today;
            
            this.CarregarObras();
            this.CarregarComboEmpresas();                        
            this.CarregarClientes();
            this.CarregarFornecedores();                     
            this.CarregarComboNomeEvento();      
        }

        private void CarregarClientes()
        {
            List<ObraEtapa> lstClientesObras = new List<ObraEtapa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientesObras = new List<ObraEtapa>();

                lstClientesObras.Add(new ObraEtapa() { idCliente = 0, nomeCliente = "--Selecione--" });

                lstClientesObras.AddRange(lstObras.GroupBy(obra => obra.nomeCliente).Select(grp => grp.First()).OrderBy(x => x.nomeCliente));

                cbCliente.DataSource = null;
                cbCliente.BindingContext = new BindingContext();                
                cbCliente.DataSource = lstClientesObras;
                cbCliente.DisplayMember = "nomeCliente";
                cbCliente.ValueMember = "idCliente";    
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

        private void CarregarFornecedores()
        {
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFornecedores.Add(new Fornecedor() { idFornecedor = 0, Nome = "--Selecione--" });
                lstFornecedores.AddRange(bizFornecedor.PesquisarFornecedor(new Fornecedor()).OrderBy(u => u.Nome));
                helper.CarregarComboBox(cbFavorecido, new BindingSource(), lstFornecedores.Cast<object>().ToList(), "Nome", "idFornecedor");
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

        private void CarregarObras()
        {
            lstObras = new List<ObraEtapa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {                
                lstObras.AddRange(bizObra.PesquisarObraEtapa(new ObraEtapa()));
                lstLicitacoesCliente = lstObras;
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

        private void CarregarComboNomeEvento()
        {
            List<ObraEtapa> lstNomesEventos = new List<ObraEtapa>();

            lstNomesEventos.Add(new ObraEtapa() { idObraEtapa = 0, nomeEvento = "--Selecione--" });
            lstNomesEventos.AddRange(lstObras.OrderBy(x => x.nomeEvento).ToList());
            helper.CarregarComboBox(cbNomeEvento, new BindingSource(), lstNomesEventos.Cast<object>().ToList(), "nomeEvento", "idObraEtapa");         
        }
                
        private void chkFavorecido_CheckedChanged(object sender, EventArgs e)
        {
            cbFavorecido.Enabled = chkFavorecido.Checked;
        }

        private void chkNomeEvento_CheckedChanged(object sender, EventArgs e)
        {
            cbNomeEvento.Enabled = chkNomeEvento.Checked;
        }
        
        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            cbCliente.Enabled = chkCliente.Checked;
            chkLicitacao.Enabled = chkCliente.Checked;

            if (chkCliente.Checked == false)
                chkLicitacao.Checked = false;
        }

        private void chkLicitacao_CheckedChanged(object sender, EventArgs e)
        {
            cbLicitacao.Enabled = chkLicitacao.Checked;
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstObras.Count == 0 || cbCliente.SelectedIndex == 0)
            {
                cbLicitacao.DataSource = null;
                cbLicitacao.BindingContext = new BindingContext();                    
                return;
            }                

            lstLicitacoesCliente = new List<ObraEtapa>();

            lstLicitacoesCliente.Add(new ObraEtapa() { idObraEtapa = 0, numeroLicitacao = "--Selecione--" });
            
            if(cbCliente.SelectedValue != null)
            {
                lstLicitacoesCliente.AddRange(lstObras.Where(x => x.idCliente == int.Parse(cbCliente.SelectedValue.ToString())).OrderBy(y => y.numeroLicitacao).ThenBy(z => z.Descricao));

                foreach (ObraEtapa itemLicitacao in lstLicitacoesCliente)                
                    itemLicitacao.numeroLicitacao =  itemLicitacao.numeroLicitacao + " - " + itemLicitacao.Descricao;
            }

            cbLicitacao.DataSource = lstLicitacoesCliente;
            cbLicitacao.DisplayMember = "numeroLicitacao";
            cbLicitacao.ValueMember = "idObraEtapa";    
        }
    }
}
