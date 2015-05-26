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
    public partial class ObraManutencao : Form
    {
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private Obra obraSelecionada = new Obra();
        private BIZObra bizObra = new BIZObra();
        private BIZCliente bizCliente = new BIZCliente();
        private BIZEmpresa bizEmpresa = new BIZEmpresa();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public ObraManutencao(Obra _obraSelecionada)
        {
            InitializeComponent();
            obraSelecionada = _obraSelecionada;
        }

        private void ObraManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                CarregarCombos();
                
                if(obraSelecionada.idObra > 0)
                {
                    CarregarObra();
                   // CarregarGridPlanejamento();
                    CarregarGridEtapas();
                    CarregarTotais();
                }                    
                else
                {
                    //btPlanejamentoNovo.Enabled = false;                    
                    //btPlanejamentoVisualizar.Enabled = false;
                    btNovaEtapa.Enabled = false;
                    btVisualizarEtapa.Enabled = false;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogErro logErro = new LogErro()
                {
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(logErro);
            }			
        }

        private void CarregarCombos()
        {
            this.CarregarComboEmpresas();
            this.CarregarComboClientes();
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

        private void CarregarComboClientes()
        {
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

        private void CarregarObra()
        {            
            cbEmpresa.SelectedValue = obraSelecionada.idEmpresa;
            tbNumeroLicitacao.Text = obraSelecionada.numeroLicitacao;
            cbClientes.SelectedValue = obraSelecionada.idCliente;
            tbNomeEvento.Text = obraSelecionada.nomeEvento;
            tbValorBruto.Text = helper.FormatarValorMoeda(obraSelecionada.valorBruto.ToString());
        }

        private void CarregarGridEtapas()
        {
            List<ObraEtapa> lstEtapas = new List<ObraEtapa>();

            if (obraSelecionada.lstEtapas == null)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstEtapas = obraSelecionada.lstEtapas.OrderBy(obr => obr.dataInicio).ToList();

                LimparGrid();

                gvEtapas.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvEtapas.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvEtapas.Columns[4].DefaultCellStyle.Format = "N2";
                gvEtapas.Columns[5].DefaultCellStyle.Format = "N2";

                foreach (ObraEtapa itemObra in lstEtapas)
                {
                    gvEtapas.Rows.Add(new object[] 
                    {
                        itemObra.idObraEtapa, 
                        itemObra.Descricao,
                        itemObra.dataInicio.Date,
                        itemObra.dataTermino.Date,                         
                        decimal.Parse(helper.FormatarValorMoeda(itemObra.saldoEtapa.ToString())),
                        decimal.Parse(helper.FormatarValorMoeda(itemObra.valorContrato.ToString())),
                        itemObra.Finalizada == 0 ? "Aberta" : "Fechada"
                    });
                }
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

        private void LimparGrid()
        {
            while (gvEtapas.Rows.Count > 0)
                gvEtapas.Rows.RemoveAt(0);
        }

        private void CarregarTotais()
        {
            BIZNotaFiscal bizNF = new BIZNotaFiscal();
            this.Cursor = Cursors.WaitCursor;

            if (obraSelecionada.lstEtapas == null)
                return;

            try
            {
                //obraSelecionada.saldoObra = obraSelecionada.valorBruto - decimal.Parse(obraSelecionada.lstEtapas.Sum(x => x.saldoEtapa).ToString());
                obraSelecionada.saldoObra = obraSelecionada.valorBruto - obraSelecionada.lstEtapas.SelectMany(x => x.lstGastosRealizados).Where(y => y.statusOrdemPagamento == "PAGA").Sum(z => z.Valor);
                
                obraSelecionada.totalOPGerada = obraSelecionada.lstEtapas.SelectMany(x => x.lstGastosRealizados).Where(y => y.statusOrdemPagamento != "CANCELADA" && y.statusOrdemPagamento != string.Empty).Sum(z => z.Valor);
                obraSelecionada.totalOPAberto = obraSelecionada.lstEtapas.SelectMany(x => x.lstGastosRealizados).Where(y => y.statusOrdemPagamento == "GERADA").Sum(z => z.Valor);
                obraSelecionada.totalNotaFiscal = obraSelecionada.lstEtapas.Sum(x => x.totalNotaFiscalGerada); 

                lbSaldoObra.Text = "Saldo Obra: R$ " + helper.FormatarValorMoeda(obraSelecionada.saldoObra.ToString());
                lbTotalNotaFiscal.Text = "Total Notas Fiscais: R$ " + helper.FormatarValorMoeda(obraSelecionada.totalNotaFiscal.ToString());
                lbTotalOPGerada.Text = "Total OP's geradas: R$ " + helper.FormatarValorMoeda(obraSelecionada.totalOPGerada.ToString());
                lbTotalOPAberto.Text = "Total OP's em aberto: R$ " + helper.FormatarValorMoeda(obraSelecionada.totalOPAberto.ToString());
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

        //private void btPlanejamentoNovo_Click(object sender, EventArgs e)
        //{
        //    ObraEtapa etapa = new ObraEtapa();

        //    etapa.idObra = obraSelecionada.idObra;
        //    etapa.idEmpresa = obraSelecionada.idEmpresa;
        //    etapa.numeroLicitacao = obraSelecionada.numeroLicitacao;
        //    etapa.idCliente = obraSelecionada.idCliente;
        //    etapa.nomeEvento = obraSelecionada.nomeEvento;
        //    etapa.dataInicio = DateTime.Now;
        //    etapa.dataTermino = DateTime.Now;
        //    etapa.lstGastosPrevistos = new List<ObraEtapaGastoPrevisto>();
        //    etapa.lstGastosRealizados = new List<ObraEtapaGastoRealizado>();
        //    etapa.lstFases = new List<ObraEtapaFase>();
        //    etapa.lstFollowUps = new List<ObraEtapaFollowUp>();

        //    ObraPlanejamentoManutencao form = new ObraPlanejamentoManutencao(etapa);
        //    form.ShowDialog();

        //    obraSelecionada.lstEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObra = obraSelecionada.idObra });

        //    CarregarGridPlanejamento();
        //    CarregarGridEtapas();
        //    CarregarTotais();
        //}       
       
        private void cbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbNumeroLicitacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorBruto_KeyDown(object sender, KeyEventArgs e)
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

        private void tbNomeEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorBruto_Leave(object sender, EventArgs e)
        {
            tbValorBruto.Text = helper.FormatarValorMoeda(tbValorBruto.Text);
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idObra = 0;
            int idEmpresa = 0;
            int idCliente = 0;

            if (cbEmpresa.SelectedIndex > 0 && cbEmpresa.FindStringExact(cbEmpresa.Text) != -1)
                idEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());

            if (cbClientes.SelectedIndex > 0 && cbClientes.FindStringExact(cbClientes.Text) != -1)
                idCliente = int.Parse(cbClientes.SelectedValue.ToString());

            obraSelecionada.idEmpresa = idEmpresa;
            obraSelecionada.numeroLicitacao = tbNumeroLicitacao.Text;
            obraSelecionada.idCliente = idCliente;
            obraSelecionada.nomeEvento = tbNomeEvento.Text;
            obraSelecionada.valorBruto = decimal.Parse(tbValorBruto.Text);

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (obraSelecionada.idObra == 0)
                {
                    msgRetorno = bizObra.IncluirObra(obraSelecionada, out idObra);
                    acaoSelecionada = "Inclusão";
                    obraSelecionada.idObra = idObra;                    
                }
                else
                {
                    msgRetorno = bizObra.AlterarObra(obraSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    //btPlanejamentoNovo.Enabled = UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name && perm.nomeControle == "btPlanejamentoNovo").ToList()[0].Habilitado;
                    //btPlanejamentoVisualizar.Enabled = UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name && perm.nomeControle == "btPlanejamentoVisualizar").ToList()[0].Habilitado;
                    //btNovaEtapa.Enabled = UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name && perm.nomeControle == "btPlanejamentoEtapa").ToList()[0].Habilitado;
                    //btVisualizarEtapa.Enabled = UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name && perm.nomeControle == "btGastosEtapa").ToList()[0].Habilitado;
                    
                    //CarregarGridPlanejamento();
                    CarregarGridEtapas();
                    CarregarTotais();
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        //private void CarregarGridPlanejamento()
        //{
        //    List<ObraEtapa> lstEtapas = new List<ObraEtapa>();
        //    List<ObraEtapaPlanejamento> lstPlanejamento = new List<ObraEtapaPlanejamento>();
        //    List<ObraEtapaPlanejamento> lstPlanejamentoGrid = new List<ObraEtapaPlanejamento>();

        //    while (gvPlanejamento.Rows.Count > 0)
        //        gvPlanejamento.Rows.RemoveAt(0);

        //    lstEtapas = obraSelecionada.lstEtapas.OrderBy(obr => obr.dataInicio).ToList();

        //    lstPlanejamento = lstEtapas.SelectMany(x => x.lstPlanejamentos).ToList();

        //    if (lstPlanejamento == null)
        //        return;

        //    lstPlanejamentoGrid = lstPlanejamento
        //        .GroupBy(l => l.idObraEtapa)
        //        .Select(cl => new ObraEtapaPlanejamento
        //        {
        //            idObraEtapa = cl.First().idObraEtapa,
        //            descricaoEtapa = cl.First().descricaoEtapa,
        //            valorPrevisto = cl.Sum(c => c.valorPrevisto)
        //        }).ToList();
            
        //    gvPlanejamento.Columns[2].DefaultCellStyle.Format = "N2";

        //    foreach (ObraEtapaPlanejamento planejamento in lstPlanejamentoGrid)
        //    {
        //        gvPlanejamento.Rows.Add(new object[] 
        //        {
        //            planejamento.idObraEtapa,
        //            planejamento.descricaoEtapa,                    
        //            helper.FormatarValorMoeda(planejamento.valorPrevisto.ToString()),                    
        //        });
        //    }
        //}

        private void btNovaEtapa_Click(object sender, EventArgs e)
        {
            ObraEtapa etapa = new ObraEtapa();

            etapa.idObra = obraSelecionada.idObra;
            etapa.idEmpresa = obraSelecionada.idEmpresa;
            etapa.numeroLicitacao = obraSelecionada.numeroLicitacao;
            etapa.idCliente = obraSelecionada.idCliente;
            etapa.nomeEvento = obraSelecionada.nomeEvento;
            etapa.dataInicio = DateTime.Now;
            etapa.dataTermino = DateTime.Now;
            etapa.lstGastosPrevistos = new List<ObraEtapaGastoPrevisto>();
            etapa.lstGastosRealizados = new List<ObraEtapaGastoRealizado>();
            etapa.lstFases = new List<ObraEtapaFase>();
            etapa.lstFollowUps = new List<ObraEtapaFollowUp>();

            ObraEtapaManutencao form = new ObraEtapaManutencao(etapa, true);
            form.ShowDialog();

            obraSelecionada.lstEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObra = obraSelecionada.idObra });

            CarregarGridEtapas();
            CarregarTotais();

            //ObraEtapa etapa = new ObraEtapa();
            //int linhaGrid = 0;
            //int idEtapaSelecionada = 0;

            //if (gvEtapas.RowCount == 0)
            //    return;

            //linhaGrid = gvEtapas.SelectedCells[0].RowIndex;
            //idEtapaSelecionada = int.Parse(gvEtapas[0, linhaGrid].Value.ToString());

            //etapa = obraSelecionada.lstEtapas.Where(x => x.idObraEtapa == idEtapaSelecionada).First();

            //ObraEtapaManutencao form = new ObraEtapaManutencao(etapa, true);
            //form.ShowDialog();

            //obraSelecionada.lstEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObra = obraSelecionada.idObra });

            //CarregarGridEtapas();
            //CarregarTotais();
        }

        private void btVisualizarEtapa_Click(object sender, EventArgs e)
        {
            ObraEtapa etapa = new ObraEtapa();
            int linhaGrid = 0;
            int idEtapaSelecionada = 0;

            if (gvEtapas.RowCount == 0)
                return;

            linhaGrid = gvEtapas.SelectedCells[0].RowIndex;
            idEtapaSelecionada = int.Parse(gvEtapas[0, linhaGrid].Value.ToString());

            etapa = obraSelecionada.lstEtapas.Where(x => x.idObraEtapa == idEtapaSelecionada).First();

            ObraEtapaManutencao form = new ObraEtapaManutencao(etapa, false);
            form.ShowDialog();

            obraSelecionada.lstEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObra = obraSelecionada.idObra });

            CarregarGridEtapas();
            CarregarTotais();
        }

        //private void btPlanejamentoVisualizar_Click(object sender, EventArgs e)
        //{
        //    ObraEtapa etapa = new ObraEtapa();
        //    int linhaGrid = 0;
        //    int idEtapaSelecionada = 0;

        //    if (gvEtapas.RowCount == 0)
        //        return;

        //    linhaGrid = gvPlanejamento.SelectedCells[0].RowIndex;
        //    idEtapaSelecionada = int.Parse(gvPlanejamento[0, linhaGrid].Value.ToString());

        //    etapa = obraSelecionada.lstEtapas.Where(x => x.idObraEtapa == idEtapaSelecionada).First();

        //    ObraPlanejamentoManutencao form = new ObraPlanejamentoManutencao(etapa);
        //    form.ShowDialog();

        //    obraSelecionada.lstEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObra = obraSelecionada.idObra });

        //    CarregarGridPlanejamento();
        //    CarregarGridEtapas();
        //    CarregarTotais();

        //}      
    }
}
