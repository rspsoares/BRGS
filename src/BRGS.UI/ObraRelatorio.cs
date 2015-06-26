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
    public partial class ObraRelatorio : Form
    {
        private Helper helper = new Helper();
        private BIZObra bizObra = new BIZObra();
        private List<Obra> lstObrasCadastradas = new List<Obra>();
        private List<Obra> lstObrasSelecionadas = new List<Obra>();
        private List<ObraEtapa> lstLicitacoesCliente = new List<ObraEtapa>();
        private List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();
        private List<Cliente> lstClientes = new List<Cliente>();

        public ObraRelatorio()
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

        private void CarregarGridObrasCadastradas(List<Obra> lstFiltro)
        {
            while (gvEventosCadastrados.Rows.Count > 0)
                gvEventosCadastrados.Rows.RemoveAt(0);

            foreach (Obra itemObra in lstFiltro)
            {
                gvEventosCadastrados.Rows.Add(new object[] 
                {
                    itemObra.idObra, 
                    itemObra.nomeEvento
                });
            }
        }

        private void CarregarCombos()
        {
            this.CarregarComboUEN(0);
            this.CarregarComboClientes(0);
        }

        private void CarregarComboClientes(int idUEN)
        {
            List<Cliente> lstClientesCombo = new List<Cliente>();            

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientesCombo.Add(new Cliente() { idCliente = 0, Nome = "--Selecione--" });
                
                if(idUEN > 0)
                {
                    foreach (ObraEtapa etapa in lstObrasEtapas.OrderBy(x => x.nomeCliente).ToList())
                    {
                        if (etapa.lstGastosRealizados.Exists(x => x.idUEN == idUEN) && lstClientesCombo.Exists(x => x.idCliente == etapa.idCliente) == false)
                            lstClientesCombo.Add(new Cliente() { idCliente = etapa.idCliente, Nome = etapa.nomeCliente });
                    }
                }
                else
                    lstClientesCombo.AddRange(lstClientes);

                lbClientesFiltrados.Visible = idUEN > 0;

                cbClientes.DataSource = lstClientesCombo;
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

        private void CarregarComboUEN(int idCliente)
        {
            List<UEN> lstUEN = new List<UEN>();
            BIZUEN bizUEN = new BIZUEN();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });
                lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(x => x.Descricao).ToList());

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

        private void cbUEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkUEN_CheckedChanged(object sender, EventArgs e)
        {
            cbUEN.Enabled = chkUEN.Checked;

            if (chkUEN.Checked == false)
            {
                cbUEN.SelectedIndex = 0;
                CarregarComboClientes(0);
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

                dt = bizObra.GerarRelatorioRealizadas(filtro, filtroRelatorio);
                
                obra = new GastosObras();
                obra.SetDataSource(dt);
                Relatorio gastosObras = new Relatorio(obra);
                gastosObras.Text = "Relatório de Gastos Realizados";
                gastosObras.ShowDialog();               
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string MontarFiltroRelatorio()
        {
            string filtro = string.Empty;

            if (chkUEN.Checked)
                filtro += "UEN: " + cbUEN.Text + " / ";

            if (chkCliente.Checked)
            {
                filtro += "Cliente: " + cbClientes.Text + " / ";

                if (chkLicitacao.Checked)
                    filtro += "Licitação: " + cbLicitacao.Text + " / ";
            }

            if(gvEventosSelecionados.RowCount > 0)
                filtro += gvEventosSelecionados.RowCount > 1 ? "Eventos diversos / " : "Evento: " + gvEventosSelecionados[1, 0].Value + " / ";

            return filtro;
        }

        private string ValidarFiltro()
        {
            string msgRetorno = string.Empty;

            if (chkUEN.Checked && (cbUEN.FindStringExact(cbUEN.Text) == -1 || cbUEN.SelectedIndex == 0))
                msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

            if (chkCliente.Checked && (cbClientes.FindStringExact(cbClientes.Text) == -1 || cbClientes.SelectedIndex == 0))
                msgRetorno += Environment.NewLine + "Favor selecionar um Cliente válido";            

            return msgRetorno;
        }

        private string MontarFiltroSQL()
        {
            string filtroSQL = string.Empty;

            if (chkUEN.Checked)
                filtroSQL += " AND U.idUEN = " + int.Parse(cbUEN.SelectedValue.ToString());

            if (chkCliente.Checked)
                filtroSQL += " AND C.idCliente = " + int.Parse(cbClientes.SelectedValue.ToString());

            if (chkLicitacao.Checked && int.Parse(cbLicitacao.SelectedValue.ToString()) > 0)
                filtroSQL += " AND O.idObraEtapa = " + int.Parse(cbLicitacao.SelectedValue.ToString());

            if (lstObrasSelecionadas.Count > 0)
            {
                filtroSQL += " AND (";
                foreach (Obra itemObra in lstObrasSelecionadas)                
                    filtroSQL += " O.idObra = " + itemObra.idObra + " OR";

                filtroSQL = filtroSQL.Substring(0, filtroSQL.Length - 3);

                filtroSQL += ")";
            }

            filtroSQL += " AND Us.idUsuario = " + UsuarioLogado.idUsuario + 
                " AND Uc.idUsuario = " + UsuarioLogado.idUsuario + 
                " AND Ud.idUsuario =  " + UsuarioLogado.idUsuario;

            filtroSQL += " ORDER BY O.DataInicio";

            return filtroSQL;
        }

        private void tbFiltroEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbFiltroEvento_TextChanged(object sender, EventArgs e)
        {
            var lstObraFiltrado = from lstObrasFiltro in lstObrasCadastradas
                                  where lstObrasFiltro.nomeEvento.ToUpper().Contains(tbFiltroEvento.Text.Trim().ToUpper())
                                  select lstObrasFiltro;

            this.CarregarGridObrasCadastradas(lstObraFiltrado.ToList());    
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int idObraCadastrada = 0;
            string nomeEventoCadastrado = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvEventosCadastrados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idObraCadastrada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                nomeEventoCadastrado = linhaSelecionada.Cells[1].Value.ToString();

                if (lstObrasSelecionadas.Exists(x => x.idObra == idObraCadastrada))
                    MessageBox.Show("O Evento " + nomeEventoCadastrado + " já foi selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    lstObrasSelecionadas.Add(new Obra()
                    {
                        idObra = idObraCadastrada,
                        nomeEvento = nomeEventoCadastrado
                    });
                }
            }

            this.CarregarGridObrasSelecionadas();
        }

        private void CarregarGridObrasSelecionadas()
        {
            while (gvEventosSelecionados.Rows.Count > 0)
                gvEventosSelecionados.Rows.RemoveAt(0);

            foreach (Obra itemObra in lstObrasSelecionadas)
            {
                gvEventosSelecionados.Rows.Add(new object[] 
                {
                    itemObra.idObra, 
                    itemObra.nomeEvento
                });
            }
        }

        private void btRem_Click(object sender, EventArgs e)
        {
            int idObraSelecionada = 0;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvEventosSelecionados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idObraSelecionada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                lstObrasSelecionadas.RemoveAll(item => item.idObra == idObraSelecionada);
            }

            this.CarregarGridObrasSelecionadas();
        }

        private void LancamentoGastosRelatorio_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.CarregarClientes();
            this.CarregarObras();
            this.CarregarObrasEtapas();
            this.CarregarGridObrasCadastradas(lstObrasCadastradas);
            this.CarregarCombos();

            this.Cursor = Cursors.Default;
        }

        private void CarregarClientes()
        {
            BIZCliente bizCliente = new BIZCliente();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientes = bizCliente.PesquisarCliente(new Cliente()).OrderBy(u => u.Nome).ToList();
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

        private void cbUEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkUEN.Checked)            
                CarregarComboClientes(int.Parse(cbUEN.SelectedValue.ToString()));                
        }        
    }
}
