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
using BRGS.Util;

namespace BRGS.UI
{
    public partial class FreteManutencao : Form
    {
        private BIZFrete bizFrete = new BIZFrete();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Frete freteSelecionado = new Frete();
        private List<UENCentroCusto> lstCentroCustos = new List<UENCentroCusto>();
        private List<CentroCustoDespesa> lstDespesas = new List<CentroCustoDespesa>();
        private BIZUEN bizUEN = new BIZUEN();
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private BIZObra bizObra = new BIZObra();

        public FreteManutencao(Frete _freteSelecionado)
        {
            InitializeComponent();
            freteSelecionado = _freteSelecionado;
        }

        private void FreteManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                this.CarregarCombos();

                if (freteSelecionado.idFrete > 0)
                    CarregarFrete();
                else
                {
                    btGerarOP.Enabled = false;
                    freteSelecionado.lstPagamentos = new List<FretePagamento>();
                    freteSelecionado.lstObras = new List<FreteObra>();
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

        private void CarregarFrete()
        {            
            freteSelecionado = bizFrete.PesquisarFrete(new Frete() { idFrete = freteSelecionado.idFrete })[0];

            tbNumero.Text = freteSelecionado.numeroFrete;
            cbFornecedores.SelectedValue = freteSelecionado.idFornecedor;
            tbTrajeto.Text = freteSelecionado.Trajeto;            
            tbPrevisaoPagto.Value = freteSelecionado.previsaoPagamento.Date;
            tbValorTotal.Text = helper.FormatarValorMoeda(freteSelecionado.valorTotal.ToString());
            btGerarOP.Enabled = true;

            this.CarregarGridObras();
            this.CarregarGridPagamentos();
        }

        private void CarregarGridObras()
        { 
            while (gvObras.Rows.Count > 0)
                gvObras.Rows.RemoveAt(0);

            gvObras.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvObras.Columns[5].DefaultCellStyle.Format = "N2";

            foreach (FreteObra obraItem in freteSelecionado.lstObras.Where(x => x.Ativo == true).OrderBy(x => x.descricaoObra).ToList())
            {
                gvObras.Rows.Add(new object[] 
                {
                    obraItem.idObraEtapa,
                    obraItem.descricaoObra,
                    obraItem.idObraEtapaGastoRealizado, 
                    obraItem.descricaoDespesa,
                    obraItem.Data,
                    helper.FormatarValorMoeda(obraItem.Valor.ToString()) 
                });
            }

            lbTotalObras.Text = "Total Rateio: R$ " + helper.FormatarValorMoeda(freteSelecionado.lstObras.Where(x => x.Ativo == true).Sum(obra => obra.Valor).ToString());
        }

        private void CarregarCombos()
        {
            this.CarregarComboFornecedores();
            this.CarregarComboObras();
            this.CarregarComboUEN();
            this.CarregarComboUENPagto();
            this.CarregarListaCentroCusto();
            this.CarregarListaDespesas();                 
        }

        private void CarregarComboUENPagto()
        {
            List<UEN> lstUEN = new List<UEN>();            

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });
                lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(u => u.Descricao));

                cbUENPagto.DataSource = null;
                cbUENPagto.BindingContext = new BindingContext();
                cbUENPagto.DataSource = lstUEN;
                cbUENPagto.DisplayMember = "Descricao";
                cbUENPagto.ValueMember = "idUEN";
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

        private void CarregarListaDespesas()
        {
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

        private void CarregarComboObras()
        {
            List<ObraEtapa> lstObras = new List<ObraEtapa>();            

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

 	    private void CarregarComboUEN()
        {            
            List<UEN> lstUEN = new List<UEN>();
            int idObraEtapa = 0;

            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                if (cbObra.SelectedValue == null || int.TryParse(cbObra.SelectedValue.ToString(), out idObraEtapa) == false)
                    return;

                lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });

                if (cbObra.SelectedIndex > 0)
                    lstUEN.AddRange(bizObra.RetornarUENGastosRealizados(new ObraEtapaGastoRealizado() { idObraEtapa = int.Parse(cbObra.SelectedValue.ToString()) }));
                else
                    lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(u => u.Descricao));     
                
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
        
        private void CarregarComboFornecedores()
        {
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
            BIZFornecedor bizFornecedor = new BIZFornecedor();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFornecedores.Add(new Fornecedor() { idFornecedor = 0, Nome = "--Selecione--" });
                lstFornecedores.AddRange(bizFornecedor.PesquisarFornecedor(new Fornecedor()).OrderBy(u => u.Nome));

                cbFornecedores.DataSource = lstFornecedores;
                cbFornecedores.DisplayMember = "Nome";
                cbFornecedores.ValueMember = "idFornecedor";
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

        private void cbFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbTrajeto_KeyDown(object sender, KeyEventArgs e)
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

        private void tbValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorPago_KeyDown(object sender, KeyEventArgs e)
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

        private void cbUEN_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CarregarCentrosCustos();
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
                            if (lstCCFiltrado.Exists(x => x.idCentroCusto == centroCustoObra.idCentroCusto) == false)
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

        private void cbUEN_Leave(object sender, EventArgs e)
        {
            int idUENCombo = 0;

            if (cbUEN.SelectedValue == null || int.TryParse(cbUEN.SelectedValue.ToString(), out idUENCombo) == false)
            {
                cbCentroCusto.DataSource = null;
                cbCentroCusto.Text = string.Empty;
            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            OrdemPagamento ordemPagamento = new OrdemPagamento();
            string msgRetorno = string.Empty;

            msgRetorno = this.ValidarGeracaoOP();

            if (msgRetorno == string.Empty)
            {
                ordemPagamento.idOrdemPagamento = 0;
                ordemPagamento.idEmpresa = 0;
                ordemPagamento.idObraEtapa = 0;
                ordemPagamento.idSolicitante = UsuarioLogado.idUsuario;
                ordemPagamento.nomeSolicitante = UsuarioLogado.Nome;
                ordemPagamento.dataSolicitacao = DateTime.Now;
                ordemPagamento.Autorizado = string.Empty;
                ordemPagamento.Observacao = string.Empty;
                ordemPagamento.lstItens = new List<OrdemPagamentoItem>();
                ordemPagamento.lstItens.Add(new OrdemPagamentoItem()
                {
                    idFrete = freteSelecionado.idFrete,
                    idAbastecimento = 0,
                    idObraGastoRealizado = 0,
                    idUEN = int.Parse(cbUENPagto.SelectedValue.ToString()),
                    idCentroCusto = int.Parse(cbCentroCustoPagto.SelectedValue.ToString()),
                    idDespesa = int.Parse(cbDespesaPagto.SelectedValue.ToString()),
                    descricaoUEN = cbUENPagto.Text,
                    descricaoCentroCusto = cbCentroCustoPagto.Text,
                    descricaoDespesa = cbDespesaPagto.Text,
                    Valor = decimal.Parse(tbValorPagto.Text),
                    dataVencimento = tbDataVenc.Value.Date,
                    numeroParcela = 1,
                    totalParcelas = 1
                });

                OrdemPagamentoManutencao form = new OrdemPagamentoManutencao(ordemPagamento, false);
                form.ShowDialog();

                CarregarFrete();              
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string ValidarGeracaoOP()
        {
            string msgRetorno = string.Empty;

            if (cbUENPagto.SelectedIndex == 0 || cbUENPagto.FindStringExact(cbUENPagto.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

            if (cbCentroCustoPagto.FindStringExact(cbCentroCustoPagto.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Centro de Custo válido";

            if (cbDespesaPagto.FindStringExact(cbDespesaPagto.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Despesa válida";

            if (tbValorPagto.Text == string.Empty || tbValorPagto.Text == "0,00")
                msgRetorno += Environment.NewLine + "Favor informar o Valor";

            return msgRetorno;
        }

        private void CarregarGridPagamentos()
        {
            decimal valorSaldo = decimal.Zero;            
            decimal totalPago = decimal.Zero;
            decimal totalFrete = decimal.Zero;

            while (gvPagamentos.Rows.Count > 0)
                gvPagamentos.Rows.RemoveAt(0);
          
            foreach (FretePagamento pagoItem in freteSelecionado.lstPagamentos)
            {                
                gvPagamentos.Columns[2].DefaultCellStyle.Format = "N2";

                gvPagamentos.Rows.Add(new object[] 
                {
                    pagoItem.numeroOP,
                    pagoItem.statusOP,                    
                    helper.FormatarValorMoeda(pagoItem.valorOP.ToString())
                });
            }

            totalFrete = freteSelecionado.valorTotal;
            totalPago = freteSelecionado.lstPagamentos.Where(x => x.statusOP == "PAGA").Sum(x => x.valorOP);            
            valorSaldo = totalFrete - totalPago;

            lbSaldo.Text = "Saldo: R$ " + helper.FormatarValorMoeda(valorSaldo.ToString());
            lbSaldo.ForeColor = valorSaldo < 0 ? Color.Red : Color.Black;
        }     

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idFrete = 0;            
            string msgConfirmacao = string.Empty;
            ObraEtapaGastoRealizado gastoRealizado = new ObraEtapaGastoRealizado();

            this.PopularEntidade();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (freteSelecionado.lstObras.Where(x => x.Ativo == true).ToList().Count > 0)
                {
                    if (freteSelecionado.lstObras.Where(x => x.Ativo == true).ToList().Count == 1)
                        msgConfirmacao = "Confirma a gravação dos dados e a inclusão desse frete nos Gastos Realizados na obra " + freteSelecionado.lstObras.Where(x => x.Ativo == true).ToList()[0].descricaoObra + " ?";
                    else
                        msgConfirmacao = "Confirma a gravação dos dados e a inclusão desse frete nos Gastos Realizados nas obras selecionadas ?";

                    if (MessageBox.Show(msgConfirmacao, "Gasto realizado na Obra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }

                if (freteSelecionado.idFrete == 0)
                {
                    msgRetorno = bizFrete.IncluirFrete(freteSelecionado, out idFrete);
                    acaoSelecionada = "Inclusão";
                    freteSelecionado.idFrete = idFrete;
                }
                else
                {
                    msgRetorno = bizFrete.AlterarFrete(freteSelecionado);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CarregarFrete();
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

        private void PopularEntidade()
        {           
            freteSelecionado.idFornecedor = cbFornecedores.FindStringExact(cbFornecedores.Text) != -1 ? int.Parse(cbFornecedores.SelectedValue.ToString()) : 0;
            freteSelecionado.Trajeto = tbTrajeto.Text;           
            freteSelecionado.previsaoPagamento = tbPrevisaoPagto.Value.Date;
            freteSelecionado.valorTotal = decimal.Parse(tbValorTotal.Text); 
        }

        private void cbObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarComboUEN();
        }

        private void cbCentroCusto_SelectedValueChanged(object sender, EventArgs e)
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

        private void cbDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btAdicionarObra_Click(object sender, EventArgs e)
        {
            FreteObra freteObra = new FreteObra();
            string msgRetorno = string.Empty;

            freteObra.idFrete = freteSelecionado.idFrete;
            freteObra.idObraEtapa = cbObra.FindStringExact(cbObra.Text) != -1 ? int.Parse(cbObra.SelectedValue.ToString()) : 0;
            freteObra.descricaoObra = cbObra.Text;
            freteObra.idUEN = cbUEN.FindStringExact(cbUEN.Text) != -1 ? int.Parse(cbUEN.SelectedValue.ToString()) : 0;
            freteObra.descricaoUEN = cbUEN.Text;
            freteObra.idCentroCusto = cbCentroCusto.FindStringExact(cbCentroCusto.Text) != -1 ? int.Parse(cbCentroCusto.SelectedValue.ToString()) : 0;
            freteObra.descricaoCentroCusto = cbCentroCusto.Text;
            freteObra.idDespesa = cbDespesa.FindStringExact(cbDespesa.Text) != -1 ? int.Parse(cbDespesa.SelectedValue.ToString()) : 0;
            freteObra.descricaoDespesa = cbDespesa.Text;
            freteObra.Valor = decimal.Parse(tbValor.Text);
            freteObra.Data = tbData.Value.Date;
            freteObra.Ativo = true;

            msgRetorno = bizFrete.ValidarAdicionarObra(freteObra, freteSelecionado);

            if (msgRetorno == string.Empty)
            {
                freteSelecionado.lstObras.Add(freteObra);
                this.CarregarGridObras();
                cbObra.SelectedIndex = 0;
                tbValor.Text = "0,00";
                tbData.Value = DateTime.Today;
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btRemoverObra_Click(object sender, EventArgs e)
        {           
            string msgRetorno = string.Empty;
            int linhaGrid = 0;          
            
            if (gvObras.RowCount == 0)
                return;

            linhaGrid = gvObras.SelectedCells[0].RowIndex;

            FreteObra obraSelecionada = new FreteObra()
            {
                idObraEtapa = int.Parse(gvObras[0, linhaGrid].Value.ToString()),
                idObraEtapaGastoRealizado = int.Parse(gvObras[2, linhaGrid].Value.ToString())
            };

            msgRetorno = bizFrete.ValidarExcluirObra(obraSelecionada);

            if (msgRetorno == string.Empty)
            {
                freteSelecionado.lstObras.RemoveAll(x => x.idObraEtapaGastoRealizado == obraSelecionada.idObraEtapaGastoRealizado);
                CarregarGridObras();                
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            freteSelecionado.valorTotal = decimal.Parse(tbValorTotal.Text);
        }

        private void tbValorPagto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorPagto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorPagto_Leave(object sender, EventArgs e)
        {
            tbValorPagto.Text = helper.FormatarValorMoeda(tbValorPagto.Text);
        }

        private void cbUENPagto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbCentroCustoPagto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbDespesaPagto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbUENPagto_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CarregarCentrosCustosPagamento();
        }

        private void CarregarCentrosCustosPagamento()
        {
              List<UENCentroCusto> lstCCFiltrado = new List<UENCentroCusto>();
            List<ObraEtapaGastoRealizado> lstGastosObra = new List<ObraEtapaGastoRealizado>();
            int idUENCombo = 0;

            if (cbUENPagto.SelectedValue == null || int.TryParse(cbUENPagto.SelectedValue.ToString(), out idUENCombo) == false)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCCFiltrado.Add(new UENCentroCusto() { idCentroCusto = 0, descricaoCentroCusto = "--Selecione--" });
                lstCCFiltrado.AddRange(lstCentroCustos.Where(x => x.idUEN == int.Parse(cbUENPagto.SelectedValue.ToString())).OrderBy(x => x.descricaoCentroCusto).ToList());

                cbCentroCustoPagto.DataSource = null;
                cbCentroCustoPagto.BindingContext = new BindingContext();
                cbCentroCustoPagto.DataSource = lstCCFiltrado;
                cbCentroCustoPagto.DisplayMember = "descricaoCentroCusto";
                cbCentroCustoPagto.ValueMember = "idCentroCusto";
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void cbCentroCustoPagto_SelectedValueChanged(object sender, EventArgs e)
        {
            int idCentroCustoCombo = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                cbDespesaPagto.DataSource = null;
                cbDespesaPagto.Text = string.Empty;

                if (cbCentroCustoPagto.SelectedValue != null && int.TryParse(cbCentroCustoPagto.SelectedValue.ToString(), out idCentroCustoCombo))
                {
                    cbDespesaPagto.BindingContext = new BindingContext();
                    cbDespesaPagto.DataSource = lstDespesas.Where(x => x.idCentroCusto == idCentroCustoCombo).OrderBy(x => x.descricaoDespesa).ToList();
                    cbDespesaPagto.DisplayMember = "descricaoDespesa";
                    cbDespesaPagto.ValueMember = "idDespesa";
                    cbDespesaPagto.Text = "--Selecione--";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string validacaoObra = string.Empty;

            try
            {
                if (freteSelecionado.idFrete == 0)
                    return;

                msgRetorno = ValidarExclusaoFrete();

                if (msgRetorno == string.Empty)
                {                    
                    if (MessageBox.Show("Confirma exclusão desse frete ?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizFrete.ExcluirFrete(freteSelecionado);
                    MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private string ValidarExclusaoFrete()
        {
            string msgRetorno = string.Empty;

            if (freteSelecionado.lstObras.Count > 0)
                msgRetorno += Environment.NewLine + "Esse frete está associado a uma ou mais obras";

            if (freteSelecionado.lstPagamentos.Count > 0)
                msgRetorno += Environment.NewLine + "Já foi gerada uma OP para esse frete";

            return msgRetorno;
        }
    }
}
