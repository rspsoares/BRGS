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
using System.Data.SqlTypes;

namespace BRGS.UI
{
    public partial class OrdemPagamentoManutencao : Form
    {
        private Helper helper = new Helper();
        private BIZFornecedor bizFornecedor = new BIZFornecedor();
        private List<Fornecedor> lstFornecedores = new List<Fornecedor>();
        private List<UENCentroCusto> lstCentroCustos = new List<UENCentroCusto>();
        private List<CentroCustoDespesa> lstDespesas = new List<CentroCustoDespesa>();
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private BIZUEN bizUEN = new BIZUEN();
        private List<UEN> lstUEN = new List<UEN>();
        private OrdemPagamento opSelecionada = new OrdemPagamento();
        private bool origemConsultaOP = true;
        private BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
        private List<ObraEtapa> lstObras = new List<ObraEtapa>();
        private BIZObra bizObra = new BIZObra();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public OrdemPagamentoManutencao(OrdemPagamento _opSelecionada, bool _origemConsultaOP)
        {
            InitializeComponent();

            opSelecionada = _opSelecionada;
            origemConsultaOP = _origemConsultaOP;          
        }

        private void CarregarOrdemPagamento(OrdemPagamento opSelecionada)
        {         
            tbNumeroOP.Text = opSelecionada.numeroOP;
            tbDataCriacao.Value = opSelecionada.dataCriacao.Date == DateTime.MinValue ? DateTime.Today : opSelecionada.dataCriacao.Date;

            cbObra.SelectedValue = opSelecionada.idObraEtapa;
            //cbObra.Enabled = opSelecionada.idObraEtapa == 0;
            
            cbEmpresa.SelectedValue = opSelecionada.idEmpresa;
            cbEmpresa.Enabled = opSelecionada.idObraEtapa == 0;

            this.CarregarComboUEN();

            cbFavorecido.SelectedValue = opSelecionada.idFavorecido;
            CarregarContasBancarias(opSelecionada.idFavorecido);
            cbDadosBancarios.SelectedValue = opSelecionada.idContaBancaria;
            
            tbSolicitante.Text = opSelecionada.nomeSolicitante;            
            dtpDataSolicitacao.Value = opSelecionada.dataSolicitacao;
            cbAutorizado.SelectedValue = opSelecionada.idAutorizado;            
            tbObservacao.Text = opSelecionada.Observacao;
            
            opSelecionada.Status = this.RetornarStatusOP();
            lbStatus.Text = opSelecionada.Status != null ? opSelecionada.Status : "GERADA";
 
            chkCancelada.Checked = opSelecionada.Cancelada == 1 ? true : false;            
            tbObservacaoCancelada.Enabled = chkCancelada.Enabled && chkCancelada.Checked;
            tbObservacaoCancelada.Text = opSelecionada.observacaoCancelada;
                      
            this.CarregarItens();
            
            if (btPagamento.Enabled == false)
            {
                // Se houver algum item de UEN, Centro de Custo ou Despesa que o usuário logado não tem permissão, desabilitar os botões Gravar e Excluir
                foreach (OrdemPagamentoItem itemOP in opSelecionada.lstItens)
                {
                    if (UsuarioLogado.lstUEN.Exists(x => x.idUEN == itemOP.idUEN) == false)
                    {
                        btExcluir.Enabled = false;
                        btGravar.Enabled = false;
                        break;
                    }

                    if (UsuarioLogado.lstCC.Exists(x => x.idCentroCusto == itemOP.idCentroCusto) == false)
                    {
                        btExcluir.Enabled = false;
                        btGravar.Enabled = false;
                        break;
                    }

                    if (UsuarioLogado.lstDespesas.Exists(x => x.idDespesa == itemOP.idDespesa) == false)
                    {
                        btExcluir.Enabled = false;
                        btGravar.Enabled = false;
                        break;
                    }
                }
            }
        }

        private void LimparCampos()
        {            
            tbNumeroOP.Text = string.Empty;
            tbDataCriacao.Value = DateTime.Today;
            cbEmpresa.SelectedIndex = 0;
            cbObra.SelectedIndex = 0;
          //  cbObra.Enabled = true;
            cbFavorecido.SelectedIndex = 0;
            cbDadosBancarios.Text = string.Empty;            
            opSelecionada.idSolicitante = UsuarioLogado.idUsuario;
            tbSolicitante.Text = UsuarioLogado.Nome;
            dtpDataSolicitacao.Value = DateTime.Now;
            cbAutorizado.SelectedIndex = 0;
            tbObservacao.Text = string.Empty;
            tbObservacaoCancelada.Text = string.Empty;
            lbStatus.Text = "GERADA";
            cbUEN.SelectedIndex = 0;
            tbValor.Text = "0,00";     
            
            while (gvItens.Rows.Count > 0)
                gvItens.Rows.RemoveAt(0);

            opSelecionada.lstItens = new List<OrdemPagamentoItem>();
        }

        private void CarregarCombos()
        {
            this.CarregarComboEmpresas();
            this.CarregarComboObras();
            this.CarregarComboAutorizador();
            this.CarregarComboFornecedores();
            this.CarregarListaUEN();
            this.CarregarComboUEN();
            this.CarregarListaCentroCusto();
            this.CarregarListaDespesas();
        }

        private void CarregarComboAutorizador()
        {
            List<Funcionario> lstFuncionarios = new List<Funcionario>();
            BIZFuncionario bizFuncionario = new BIZFuncionario();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFuncionarios.Add(new Funcionario() { idFuncionario = 0, Nome = "--Selecione--" });
                lstFuncionarios.AddRange(bizFuncionario.PesquisarFuncionarios(new Funcionario()).OrderBy(x => x.Nome).ToList());

                cbAutorizado.DataSource = lstFuncionarios;
                cbAutorizado.DisplayMember = "Nome";
                cbAutorizado.ValueMember = "idFuncionario";
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

        private void CarregarComboObras()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstObras.Add(new ObraEtapa() { idObraEtapa = 0, numeroLicitacao = "--Selecione--" });
                lstObras.AddRange(bizObra.PesquisarObraEtapaCombo());               

                cbObra.DataSource = lstObras;
                cbObra.DisplayMember = "numeroLicitacao";
                cbObra.ValueMember = "idObraEtapa";
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

        private void CarregarComboFornecedores()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFornecedores.Add(new Fornecedor() { idFornecedor = 0, Nome = "--Selecione--" });
                lstFornecedores.AddRange(bizFornecedor.PesquisarFornecedorCombo(new Fornecedor()).OrderBy(u => u.Nome));                
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

        private void CarregarComboUEN()
        {            
            List<UEN> lstUENFiltro = new List<UEN>();        

            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                lstUENFiltro.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });

                if (cbObra.SelectedIndex > 0)                
                    lstUENFiltro.AddRange(bizObra.RetornarUENGastosRealizados(new ObraEtapaGastoRealizado() { idObraEtapa = int.Parse(cbObra.SelectedValue.ToString()) }));                
                else                                    
                    lstUENFiltro.AddRange(lstUEN.OrderBy(u => u.Descricao));                

                cbUEN.DataSource = null;
                cbUEN.BindingContext = new BindingContext();
                cbUEN.DataSource = lstUENFiltro;
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

        private void CarregarCentrosCustos()
        {
            List<UENCentroCusto> lstCCFiltrado = new List<UENCentroCusto>();
            List<ObraEtapaGastoRealizado> lstGastosObra = new List<ObraEtapaGastoRealizado>();
            int idUENCombo = 0;
            
            if (cbUEN.SelectedValue == null || int.TryParse(cbUEN.SelectedValue.ToString(), out idUENCombo) == false)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCCFiltrado.Add(new UENCentroCusto() { idCentroCusto = 0, descricaoCentroCusto = "--Selecione--" });

                if (cbObra.SelectedIndex > 0)
                {
                    lstGastosObra = bizObra.PesquisarGastosRealizados(new ObraEtapaGastoRealizado() { idObraEtapa = int.Parse(cbObra.SelectedValue.ToString()) });
                    if (lstGastosObra.Count > 0)
                    {
                        foreach (ObraEtapaGastoRealizado centroCustoObra in lstGastosObra)
                        {
                            if(lstCCFiltrado.Exists(x => x.idCentroCusto == centroCustoObra.idCentroCusto) == false)
                                lstCCFiltrado.AddRange(lstCentroCustos.Where(x => x.idCentroCusto == centroCustoObra.idCentroCusto && x.idUEN == int.Parse(cbUEN.SelectedValue.ToString())));
                        }
                        
                        lstCCFiltrado.OrderBy(x => x.descricaoCentroCusto);
                    }
                }
                else 
                    lstCCFiltrado.AddRange(lstCentroCustos.Where(x => x.idUEN == int.Parse(cbUEN.SelectedValue.ToString())).OrderBy(x => x.descricaoCentroCusto).ToList());

                cbCentroCusto.DataSource = null;
                cbCentroCusto.BindingContext = new BindingContext();
                cbCentroCusto.DataSource = lstCCFiltrado;
                cbCentroCusto.DisplayMember = "descricaoCentroCusto";
                cbCentroCusto.ValueMember = "idCentroCusto";
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void CarregarListaDespesas()
        {
            BIZDespesa bizDespesa = new BIZDespesa();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstDespesas = bizCentroCusto.PesquisarDespesasAssociadas(new CentroCustoDespesa());
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

        private void CarregarListaUEN()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN = bizUEN.PesquisarUEN(new UEN());
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

        private void CarregarListaCentroCusto()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCentroCustos = bizUEN.PesquisarCentrosCustosAssociados(new UENCentroCusto());
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
      
        private void cbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbFavorecido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDataProgramada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDataSolicitacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbAutorizado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbUEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbCentroCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValor_KeyDown(object sender, KeyEventArgs e)
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

        private void tbValor_Leave(object sender, EventArgs e)
        {
            tbValor.Text = helper.FormatarValorMoeda(tbValor.Text);        
        }

        private void cbUEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarregarCentrosCustos();
        }

        private void CarregarItens()
        {
            decimal totalItens = decimal.Zero;            

            while (gvItens.Rows.Count > 0)
                gvItens.Rows.RemoveAt(0);

            if (opSelecionada.lstItens == null)
                return;

            gvItens.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvItens.Columns[8].DefaultCellStyle.Format = "N2";
            gvItens.Columns[9].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvItens.Columns[10].DefaultCellStyle.Format = "N2";

            foreach (OrdemPagamentoItem itemOP in opSelecionada.lstItens)
            {
                gvItens.Rows.Add(new object[] 
                {
                    itemOP.idUEN,
                    itemOP.idCentroCusto,
                    itemOP.idDespesa, 
                    itemOP.descricaoUEN,
                    itemOP.descricaoCentroCusto,                    
                    itemOP.descricaoDespesa,
                    itemOP.idObraGastoRealizado.ToString(), 
                    itemOP.dataVencimento.Date,                    
                    helper.FormatarValorMoeda(itemOP.Valor.ToString()),
                    itemOP.dataPagamento == DateTime.MinValue || itemOP.dataPagamento == SqlDateTime.MinValue ? (DateTime?)null : itemOP.dataPagamento,
                    helper.FormatarValorMoeda(itemOP.valorPago.ToString()),
                    itemOP.idOrdemPagamentoItem,
                    itemOP.idUsuarioPagamento, 
                    itemOP.dataPagamento == DateTime.MinValue || itemOP.dataPagamento == SqlDateTime.MinValue ? string.Empty : itemOP.nomeUsuarioPagamento,
                    itemOP.Multa,
                    itemOP.Desconto
                });
            }

            totalItens = opSelecionada.lstItens.Sum(x => x.Valor);
            lbTotal.Text = "Total: R$ " + helper.FormatarValorMoeda(totalItens.ToString());          
        }

        private void cbCentroCusto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarregarDespesas();
        }

        private void CarregarDespesas()
        {
            int idCentroCustoCombo = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                cbDespesa.DataSource = null;
                cbDespesa.Text = string.Empty;

                if (cbCentroCusto.SelectedValue != null && int.TryParse(cbCentroCusto.SelectedValue.ToString(), out idCentroCustoCombo))
                {
                    cbDespesa.BindingContext = new BindingContext();
                    cbDespesa.DataSource = lstDespesas.Where(x => x.idCentroCusto == idCentroCustoCombo).OrderBy(x => x.descricaoDespesa).ToList();
                    cbDespesa.DisplayMember = "descricaoDespesa";
                    cbDespesa.ValueMember = "idDespesa";
                    cbDespesa.Text = "--Selecione--";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            List<OrdemPagamentoItemParcela> lstParcelas = new List<OrdemPagamentoItemParcela>();

            msgRetorno = VerificarNovoItem();

            if (msgRetorno == string.Empty)
            {
                if (chkGerarParcelamento.Checked)
                {
                    OrdemPagamentoManutencaoParcelamento form = new 
                        OrdemPagamentoManutencaoParcelamento(new OrdemPagamentoItemParcela() 
                        { 
                            valorParcela = decimal.Parse(tbValor.Text), 
                            dataVencimento = tbDataVencimento.Value
                        });
                        
                    form.ShowDialog();
                    lstParcelas = form.lstParcelas;

                    foreach (OrdemPagamentoItemParcela parcela in lstParcelas)
                    {
                        OrdemPagamentoItem itemOP = new OrdemPagamentoItem()
                        {
                            idObraGastoRealizado = 0,
                            idUEN = int.Parse(cbUEN.SelectedValue.ToString()),
                            descricaoUEN = cbUEN.Text,
                            idCentroCusto = int.Parse(cbCentroCusto.SelectedValue.ToString()),
                            descricaoCentroCusto = cbCentroCusto.Text,
                            idDespesa = int.Parse(cbDespesa.SelectedValue.ToString()),
                            descricaoDespesa = cbDespesa.Text,
                            Valor = parcela.valorParcela,
                            dataVencimento = parcela.dataVencimento,                            
                            numeroParcela = parcela.numeroParcela,
                            totalParcelas = parcela.totalParcelas
                        };

                        opSelecionada.lstItens.Add(itemOP);                
                    }
                }
                else
                {
                    OrdemPagamentoItem itemOP = new OrdemPagamentoItem()
                    {
                        idObraGastoRealizado = 0,
                        idUEN = int.Parse(cbUEN.SelectedValue.ToString()),
                        descricaoUEN = cbUEN.Text,
                        idCentroCusto = int.Parse(cbCentroCusto.SelectedValue.ToString()),
                        descricaoCentroCusto = cbCentroCusto.Text,
                        idDespesa = int.Parse(cbDespesa.SelectedValue.ToString()),
                        descricaoDespesa = cbDespesa.Text,
                        Valor = decimal.Parse(tbValor.Text),
                        dataVencimento = tbDataVencimento.Value,                       
                        numeroParcela = 1,
                        totalParcelas = 1
                    };
                    
                    opSelecionada.lstItens.Add(itemOP);
                }
                
                CarregarItens(); 
                tbValor.Text = "0,00";
                chkGerarParcelamento.Checked = false;
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string VerificarNovoItem()
        {
            string msgRetorno = string.Empty;

            if (cbUEN.SelectedIndex == 0 || cbUEN.FindStringExact(cbUEN.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

            if (cbCentroCusto.FindStringExact(cbCentroCusto.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Centro de Custo válido";

            if (cbDespesa.FindStringExact(cbDespesa.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Despesa válida";

            if (tbValor.Text == string.Empty || tbValor.Text == "0,00")
                msgRetorno += Environment.NewLine + "Favor informar o Valor";

            return msgRetorno;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            decimal valorPago = decimal.Zero;

            if (gvItens.RowCount == 0)
                return;

            linhaGrid = gvItens.SelectedCells[0].RowIndex;

            valorPago = decimal.Parse(gvItens[10, linhaGrid].Value.ToString());
            
            if (valorPago != decimal.Zero)
            {
                MessageBox.Show("Não é possível remover um item que já foi pago", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OrdemPagamentoItem itemSelecionado = new OrdemPagamentoItem()
            {
                idOrdemPagamentoItem = int.Parse(gvItens[11, linhaGrid].Value.ToString()),
                idDespesa = int.Parse(gvItens[2, linhaGrid].Value.ToString()),
                Valor = decimal.Parse(gvItens[8, linhaGrid].Value.ToString()),
                dataVencimento = DateTime.Parse(gvItens[7, linhaGrid].Value.ToString())
            };

            opSelecionada.lstItens.RemoveAll(item =>
                item.idOrdemPagamentoItem == itemSelecionado.idOrdemPagamentoItem &&
                item.idDespesa == itemSelecionado.idDespesa &&
                item.Valor == itemSelecionado.Valor &&
                item.dataVencimento.Date == itemSelecionado.dataVencimento.Date);

            CarregarItens();
        }

        private void cbFavorecido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFavorecido.SelectedIndex != 0 && cbFavorecido.FindStringExact(cbFavorecido.Text) != -1)            
                CarregarContasBancarias(int.Parse(cbFavorecido.SelectedValue.ToString()));
        }

        private void CarregarContasBancarias(int idFornec)
        {
            List<FornecedorContaBancaria> lstContas = new List<FornecedorContaBancaria>();
                        
            cbDadosBancarios.BindingContext = new BindingContext();
            cbDadosBancarios.DataSource = null;
            cbDadosBancarios.Text = string.Empty;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstContas.Add(new FornecedorContaBancaria() { idContaBancaria = 0, Banco = "--Selecione--" });
                lstContas.AddRange(bizFornecedor.PesquisarFornecedorContaBancariaCombo(new FornecedorContaBancaria() { idFornecedor = idFornec }));

                cbDadosBancarios.DataSource = lstContas;
                cbDadosBancarios.DisplayMember = "Banco";
                cbDadosBancarios.ValueMember = "idContaBancaria";
                cbDadosBancarios.SelectedIndex = 0;                
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idOP = 0;  
            
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.PopularEntidade();

                if (opSelecionada.idOrdemPagamento == 0)
                {
                    msgRetorno = bizOP.IncluirOrdemPagamento(opSelecionada, origemConsultaOP, out idOP);
                    acaoSelecionada = "Inclusão";
                    opSelecionada.idOrdemPagamento = idOP;
                }
                else
                {
                    msgRetorno = bizOP.AlterarOrdemPagamento(opSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    if (MessageBox.Show(acaoSelecionada + " efetuada com sucesso. Deseja emitir esta Ordem de Pagamento agora?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        this.EmitirOP();

                    opSelecionada = bizOP.PesquisarOrdemPagamento(new OrdemPagamento() { idOrdemPagamento = opSelecionada.idOrdemPagamento })[0];
                    opSelecionada.lstItens = new List<OrdemPagamentoItem>();
                    opSelecionada.lstItens = bizOP.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idOrdemPagamento = opSelecionada.idOrdemPagamento });

                    tbNumeroOP.Text = opSelecionada.numeroOP;
                    this.CarregarItens();
                    lbStatus.Text = opSelecionada.Status;
                    this.tabControl1.SelectedIndex = 0;
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

        private void EmitirOP()
        {
            ReportClass op = new ReportClass();
            DataTable dtOP = new DataTable();
            DataTable dtObras = new DataTable();
            string tituloAba = string.Empty;
            Image logotipo = null;

            try
            {
                dtOP = bizOP.GerarOrdemPagamento(opSelecionada, out dtObras);

                switch (cbEmpresa.Text)
                {
                    case "FRONT ESTRUTURAS LTDA - EPP":                       
                        tituloAba = "Emissão de Ordem de Pagamento - FRONT";
                        logotipo = Properties.Resources.Logo_FRONT;
                        break;
                    case "BRGS BRASIL LTDA - EPP":                        
                        tituloAba = "Emissão de Ordem de Pagamento - BRGS";
                        logotipo = Properties.Resources.Logo_BRGS;
                        break;
                    case "LOGOS DO BRASIL LTDA - EPP":                       
                        tituloAba = "Emissão de Ordem de Pagamento - LOGOS";
                        logotipo = Properties.Resources.Logo_LOGOS;
                        break;    
                    case "BRG SERVICOS LTDA - EPP":
                        tituloAba = "Emissão de Ordem de Pagamento - BRG";
                        logotipo = Properties.Resources.Logo_BRG;
                        break;    
                }

                dtOP = helper.AdicionarLogotipoDataTable(dtOP, logotipo);
                op = new OrdemPagamentoEmissao();
                op.SetDataSource(dtOP);
                op.Subreports[0].Database.Tables["dtOPsPagaObra"].SetDataSource(dtObras);

                Relatorio relat = new Relatorio(op);
                relat.Text = tituloAba;
                relat.ShowDialog();
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

        private void PopularEntidade()
        {            
            opSelecionada.idEmpresa = cbEmpresa.FindStringExact(cbEmpresa.Text) != -1 ? int.Parse(cbEmpresa.SelectedValue.ToString()) : 0;
            opSelecionada.idObraEtapa = cbObra.FindStringExact(cbObra.Text) != -1 ? int.Parse(cbObra.SelectedValue.ToString()) : 0;
            opSelecionada.idFavorecido = cbFavorecido.FindStringExact(cbFavorecido.Text) != -1 ? int.Parse(cbFavorecido.SelectedValue.ToString()) : 0;
            opSelecionada.favorecidoInativo = cbFavorecido.Text.Contains("(INATIVO)");
            opSelecionada.idContaBancaria = cbDadosBancarios.FindStringExact(cbDadosBancarios.Text) != -1 ? int.Parse(cbDadosBancarios.SelectedValue.ToString()) : 0;            
            opSelecionada.dataSolicitacao = dtpDataSolicitacao.Value;

            if (chkCancelada.Checked)
            {
                opSelecionada.Cancelada = 1;
                opSelecionada.observacaoCancelada = tbObservacaoCancelada.Text;            
            }
            else
            {
                opSelecionada.Cancelada = 0;
                opSelecionada.observacaoCancelada = string.Empty;
            }

            opSelecionada.idAutorizado = cbAutorizado.FindStringExact(cbAutorizado.Text) != -1 ? int.Parse(cbAutorizado.SelectedValue.ToString()) : 0;
            opSelecionada.Observacao = tbObservacao.Text;
            opSelecionada.observacaoCancelada = tbObservacaoCancelada.Text;
            opSelecionada.Status = this.RetornarStatusOP();
        }
        
        private string RetornarStatusOP()
        {
            decimal valorTotal = decimal.Zero;
            decimal valorPago = decimal.Zero;

            valorTotal = opSelecionada.lstItens.Sum(x => x.Valor);
            valorPago = opSelecionada.lstItens.Sum(x => x.valorPago);

            if (opSelecionada.Cancelada == 1)
                return "CANCELADA";

            if (opSelecionada.idOrdemPagamento == 0 || opSelecionada.lstItens.Count == 0 || valorPago == 0)
                return "GERADA";

            if (opSelecionada.lstItens.Count > 0 && opSelecionada.lstItens.Where(x => x.valorPago != 0).ToList().Count != opSelecionada.lstItens.Count)            
                return "PAGA PARCIALMENTE";               
            else
                return "PAGA";
        }

        private void OrdemPagamentoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                this.CarregarCombos();

                if (opSelecionada.idOrdemPagamento == 0 && origemConsultaOP)
                    LimparCampos();
                else                
                    CarregarOrdemPagamento(opSelecionada);                  
                
                if (opSelecionada.Cancelada == 1)
                    btGravar.Enabled = false;

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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
        
            if (opSelecionada.idOrdemPagamento == 0)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {                
                if (MessageBox.Show("Confirma exclusão da Ordem de Pagamento?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    bizOP.ExcluirOrdemPagamento(opSelecionada);
                    MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

        private void chkCancelada_Click(object sender, EventArgs e)
        {
            tbObservacaoCancelada.Enabled = chkCancelada.Checked;

            if (chkCancelada.Checked == false)
                tbObservacaoCancelada.Text = string.Empty;
        }

        private void tbParcelaValorPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbParcelaValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }


        private void cbObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            BIZObra bizObra = new BIZObra();
            ObraEtapa obra = new ObraEtapa();
            List<ObraEtapaGastoRealizado> lstGastosSemOP = new List<ObraEtapaGastoRealizado>();
            
            if (cbObra.SelectedIndex != 0 && origemConsultaOP)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    cbEmpresa.Enabled = false;

                    if (opSelecionada.idOrdemPagamento != 0 || origemConsultaOP == false)
                        return;

                    obra = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObraEtapa = int.Parse(cbObra.SelectedValue.ToString()) })[0];
                    cbEmpresa.SelectedValue = obra.idEmpresa;
                    cbEmpresa.Enabled = false;
                    lstGastosSemOP = obra.lstGastosRealizados.Where(x => x.idOrdemPagamento == 0).ToList();

                    opSelecionada.lstItens = new List<OrdemPagamentoItem>();

                    foreach (ObraEtapaGastoRealizado itemGasto in lstGastosSemOP)
                    {
                        opSelecionada.lstItens.Add(new OrdemPagamentoItem()
                        {
                            idObraGastoRealizado = itemGasto.idObraEtapaGastoRealizado,
                            idUEN = itemGasto.idUEN,
                            idCentroCusto = itemGasto.idCentroCusto,
                            idDespesa = itemGasto.idDespesa,
                            descricaoUEN = itemGasto.descricaoUEN,
                            descricaoCentroCusto = itemGasto.descricaoCentroCusto,
                            descricaoDespesa = itemGasto.descricaoDespesa,
                            Valor = itemGasto.Valor,
                            dataVencimento = itemGasto.Data,
                            numeroParcela = 1,
                            totalParcelas = 1
                        });
                    }

                    this.CarregarItens();
                    this.CarregarComboUEN();
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
            else
            {
                cbEmpresa.Enabled = true;
                this.CarregarComboUEN();
            }
        }

        private void btPagamento_Click(object sender, EventArgs e)
        {         
            int linhaGrid = 0;
            int idOPItem = 0;
            
            OrdemPagamentoItem opItemAtualizado = new OrdemPagamentoItem();

            try
            {
                if (gvItens.RowCount == 0)
                    return;

                linhaGrid = gvItens.SelectedCells[0].RowIndex;
                
                idOPItem = int.Parse(gvItens[11, linhaGrid].Value.ToString());

                if (idOPItem == 0)
                {
                    MessageBox.Show("Favor gravar os itens antes de realizar o seu pagamento.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }                        
                
                OrdemPagamentoItem opItem = new OrdemPagamentoItem()
                {
                    idOrdemPagamentoItem = idOPItem,
                    descricaoDespesa = gvItens[5, linhaGrid].Value.ToString(),
                    dataVencimento = DateTime.Parse(gvItens[7, linhaGrid].Value.ToString()),
                    Valor = decimal.Parse(gvItens[8, linhaGrid].Value.ToString()),
                    dataPagamento = gvItens[9, linhaGrid].Value == null ? DateTime.MinValue : DateTime.Parse(gvItens[9, linhaGrid].Value.ToString()),
                    Multa = decimal.Parse(gvItens[14, linhaGrid].Value.ToString()),
                    Desconto = decimal.Parse(gvItens[15, linhaGrid].Value.ToString()),
                    valorPago = decimal.Parse(gvItens[10, linhaGrid].Value.ToString()),
                    idUsuarioPagamento = int.Parse(gvItens[12, linhaGrid].Value.ToString()),
                    nomeUsuarioPagamento = gvItens[13, linhaGrid].Value.ToString()
                };

                OrdemPagamentoManutencaoPagamento formPagto = new OrdemPagamentoManutencaoPagamento(opItem);
                formPagto.ShowDialog();

                opItemAtualizado = formPagto.opItem;

                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().Valor = opItemAtualizado.Valor;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().dataVencimento = opItemAtualizado.dataVencimento;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().valorPago = opItemAtualizado.valorPago;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().dataPagamento = opItemAtualizado.dataPagamento;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().Multa = opItemAtualizado.Multa;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().Desconto = opItemAtualizado.Desconto;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().idUsuarioPagamento = opItemAtualizado.idUsuarioPagamento;
                opSelecionada.lstItens.Where(x => x.idOrdemPagamentoItem == idOPItem).First().nomeUsuarioPagamento = opItemAtualizado.nomeUsuarioPagamento; 

                this.CarregarItens();
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDadosBancarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbAutorizado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
