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
    public partial class AbastecimentoManutencao : Form
    {
        private Abastecimento abastecimentoSelecionado = new Abastecimento();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZUEN bizUEN = new BIZUEN();
        private List<UEN> lstUEN = new List<UEN>();
        private List<UENCentroCusto> lstCentrosCustos = new List<UENCentroCusto>();
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private List<CentroCustoDespesa> lstDespesas = new List<CentroCustoDespesa>();
        private BIZObra bizObra = new BIZObra();
        private BIZFornecedor bizFornecedor = new BIZFornecedor();
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public AbastecimentoManutencao(Abastecimento _abastecimentoSelecionado)
        {
            InitializeComponent();
            abastecimentoSelecionado = _abastecimentoSelecionado;
        }

        private void AbastecimentoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                CarregarCombos();

                if (abastecimentoSelecionado.idAbastecimento > 0)
                    this.CarregarAbastecimento();
                else
                    cbPosto.Enabled = true;
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

        private void CarregarAbastecimento()
        {
            abastecimentoSelecionado = bizVeiculo.PesquisarAbastecimentos(new Abastecimento() { idAbastecimento = abastecimentoSelecionado.idAbastecimento })[0];

            tbNumero.Text = abastecimentoSelecionado.numeroAbastecimento;
            cbPlaca.SelectedValue = abastecimentoSelecionado.idVeiculo;
            cbPosto.SelectedValue = abastecimentoSelecionado.idFornecedor;
            cbMotorista.SelectedValue = abastecimentoSelecionado.idMotorista;            
            cbObra.SelectedValue = abastecimentoSelecionado.idObraEtapa;
            cbUEN.SelectedValue = abastecimentoSelecionado.idUEN;
            cbCentroCusto.SelectedValue = abastecimentoSelecionado.idCentroCusto;
            cbDespesa.SelectedValue = abastecimentoSelecionado.idDespesa;
            tbData.Value = abastecimentoSelecionado.Data.Date;
            tbKilometragem.Text = abastecimentoSelecionado.Kilometragem.ToString();
            tbLitros.Text = abastecimentoSelecionado.Litros.ToString();
            tbValor.Text = helper.FormatarValorMoeda(abastecimentoSelecionado.Valor.ToString());
            tbDesconto.Text = helper.FormatarValorMoeda(abastecimentoSelecionado.Desconto.ToString());
            AtualizarTotal();

            if(abastecimentoSelecionado.idOP > 0)
                cbPosto.Enabled = false;

            cbPlaca.Enabled = false;
            cbMotorista.Enabled = false;
            cbObra.Enabled = false;
            cbUEN.Enabled = false;
            cbCentroCusto.Enabled = false;
            cbDespesa.Enabled = false;
            tbData.Enabled = false;
            tbLitros.Enabled = true;
            tbKilometragem.Enabled = true;
            tbValor.Enabled = abastecimentoSelecionado.Valor == decimal.Zero;
            tbDesconto.Enabled = abastecimentoSelecionado.Valor == decimal.Zero; 
        }

        private void CarregarCombos()
        {
            this.CarregarPostoCombustivel();
            this.CarregarListaUEN();
            this.CarregarListaCentroCusto();
            this.CarregarListaDespesas();            
            this.CarregarComboObras(); 
            this.CarregarComboUEN();
            this.CarregarComboVeiculos();
            this.CarregarComboMotoristas();
        }

        private void CarregarPostoCombustivel()
        {
            BIZAtividade bizAtividade = new BIZAtividade();
            Atividade atividade = new Atividade();
            List<Fornecedor> lstPostos = new List<Fornecedor>();
            
            this.Cursor = Cursors.WaitCursor;

            try
            {
                atividade = bizAtividade.PesquisarAtividade(new Atividade() { Descricao = "POSTO DE COMBUSTÍVEL" }).FirstOrDefault();
                
                lstPostos.Add(new Fornecedor() { idFornecedor = 0, Nome = "--Selecione--" });
                lstPostos.AddRange(bizFornecedor.PesquisarFornecedor(new Fornecedor() { idAtividade = atividade.idAtividade }).OrderBy(x => x.Nome).ToList());

                cbPosto.DataSource = lstPostos;
                cbPosto.DisplayMember = "Nome";
                cbPosto.ValueMember = "idFornecedor";
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

        private void CarregarListaCentroCusto()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCentrosCustos = bizUEN.PesquisarCentrosCustosAssociados(new UENCentroCusto());
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

        private void CarregarComboVeiculos()
        {
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstVeiculos.Add(new Veiculo() { idVeiculo = 0, Placa = "--Selecione--"});
                lstVeiculos.AddRange(bizVeiculo.PesquisarVeiculoCombo());

                cbPlaca.DataSource = lstVeiculos;
                cbPlaca.DisplayMember = "Placa";
                cbPlaca.ValueMember = "idVeiculo";
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

        private void CarregarComboMotoristas()
        {
            List<Motorista> lstMotoristas = new List<Motorista>();
            BIZMotorista bizMotorista = new BIZMotorista();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstMotoristas.Add(new Motorista () { idMotorista = 0, Nome = "--Selecione--" });
                lstMotoristas.AddRange(bizMotorista.PesquisarMotorista(new Motorista()).OrderBy(x => x.Nome));

                cbMotorista.DataSource = lstMotoristas;
                cbMotorista.DisplayMember = "Nome";
                cbMotorista.ValueMember = "idMotorista";
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

        private void cbPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbMotorista_KeyDown(object sender, KeyEventArgs e)
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

        private void tbValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            tbValor.Text = helper.FormatarValorMoeda(tbValor.Text);
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            decimal valorTotal = decimal.Zero;

            valorTotal = decimal.Parse(tbValor.Text) - decimal.Parse(tbDesconto.Text);
            tbTotal.Text = helper.FormatarValorMoeda(valorTotal.ToString());
        }

        private void cbUEN_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CarregarComboCentroCusto();
        }

        private void CarregarComboCentroCusto()
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
                                lstCCFiltrado.AddRange(lstCentrosCustos.Where(x => x.idCentroCusto == centroCustoObra.idCentroCusto && x.idUEN == int.Parse(cbUEN.SelectedValue.ToString())));
                        }

                        lstCCFiltrado.OrderBy(x => x.descricaoCentroCusto);
                    }
                }
                else
                    lstCCFiltrado.AddRange(lstCentrosCustos.Where(x => x.idUEN == int.Parse(cbUEN.SelectedValue.ToString())).OrderBy(x => x.descricaoCentroCusto).ToList());

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

        private void PopularEntidade()
        {
            abastecimentoSelecionado.idVeiculo = int.Parse(cbPlaca.SelectedValue.ToString());
            abastecimentoSelecionado.idFornecedor = int.Parse(cbPosto.SelectedValue.ToString());
            abastecimentoSelecionado.idMotorista = int.Parse(cbMotorista.SelectedValue.ToString());            
            abastecimentoSelecionado.idObraEtapa = int.Parse(cbObra.SelectedValue.ToString());
            abastecimentoSelecionado.idUEN = int.Parse(cbUEN.SelectedValue.ToString());
            abastecimentoSelecionado.idCentroCusto = int.Parse(cbCentroCusto.SelectedValue.ToString());
            abastecimentoSelecionado.idDespesa = int.Parse(cbDespesa.SelectedValue.ToString());
            abastecimentoSelecionado.idEmissor = UsuarioLogado.idUsuario;
            abastecimentoSelecionado.Data = tbData.Value;
            abastecimentoSelecionado.Kilometragem = int.Parse(tbKilometragem.Text);
            abastecimentoSelecionado.Litros = decimal.Parse(tbLitros.Text);
            abastecimentoSelecionado.Valor = decimal.Parse(tbValor.Text);
            abastecimentoSelecionado.Desconto = decimal.Parse(tbDesconto.Text);
            abastecimentoSelecionado.valorTotal = decimal.Parse(tbValor.Text);
        }

        private void btGravar_Click(object sender, EventArgs e)
        {            
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idAbastecimento = 0;
            ObraEtapaGastoRealizado gastoRealizado = new ObraEtapaGastoRealizado();
            int idGastoRealizado = 0;            

            try
            {
                msgRetorno = ValidarAbastecimento();

                if (msgRetorno == string.Empty)
                {
                    this.PopularEntidade();

                    if (abastecimentoSelecionado.idObraEtapa > 0 && abastecimentoSelecionado.idObraEtapaGastoRealizado == 0)
                    {
                        if (MessageBox.Show("Confirma a gravação dos dados e a inclusão desse abastecimento nos Gastos Realizados da obra " + cbObra.Text + " ?", "Gasto realizado na Obra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                            return;

                        this.Cursor = Cursors.WaitCursor;

                        gastoRealizado = new ObraEtapaGastoRealizado()
                        {
                            idObraEtapa = abastecimentoSelecionado.idObraEtapa,
                            idUEN = abastecimentoSelecionado.idUEN,
                            idCentroCusto = abastecimentoSelecionado.idCentroCusto,
                            idDespesa = abastecimentoSelecionado.idDespesa,
                            Data = abastecimentoSelecionado.Data,
                            Valor = abastecimentoSelecionado.Valor,
                            Observacao = "* Lançamento automático abastecimento *"
                        };

                        bizObra.IncluirGastoRealizado(gastoRealizado, out idGastoRealizado);

                        abastecimentoSelecionado.idObraEtapaGastoRealizado = idGastoRealizado;
                    }

                    if (abastecimentoSelecionado.idAbastecimento == 0)
                    {                        
                        msgRetorno = bizVeiculo.IncluirAbastecimentos(abastecimentoSelecionado, out idAbastecimento);
                        abastecimentoSelecionado.idAbastecimento = idAbastecimento;
                        acaoSelecionada = "Inclusão";
                    }
                    else
                    {
                        msgRetorno = bizVeiculo.AlterarAbastecimento(abastecimentoSelecionado);
                        acaoSelecionada = "Alteração";
                    }

                    if (msgRetorno == string.Empty)
                    {
                        MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (abastecimentoSelecionado.idOP == 0)                            
                            this.EmitirAutorizacao();
                    }
                    else
                        MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
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

            this.Cursor = Cursors.Default;
        }

        private string ValidarAbastecimento()
        {
            string msgRetorno = string.Empty;
            
            if (cbPlaca.SelectedIndex == 0 || cbPlaca.FindStringExact(cbPlaca.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Placa válida";

            if (cbMotorista.SelectedIndex == 0 || cbMotorista.FindStringExact(cbMotorista.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Motorista válido";
            
            if (cbObra.FindStringExact(cbObra.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Obra válida";

            if (cbUEN.SelectedIndex == 0 || cbUEN.FindStringExact(cbUEN.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

            if (cbCentroCusto.SelectedIndex == 0 || cbCentroCusto.FindStringExact(cbCentroCusto.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Centro de Custo válido";

            if (cbDespesa.SelectedIndex == 0 || cbDespesa.FindStringExact(cbDespesa.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Despesa válida";

            if(decimal.Parse(tbTotal.Text) < decimal.Zero)
                msgRetorno += Environment.NewLine + "O Desconto é maior do que o Valor do abastecimento";

            return msgRetorno;
        }
        
        private void EmitirAutorizacao()
        {
            ReportClass relat = new ReportClass();
            DataTable dt = new DataTable();
           
            dt = bizVeiculo.GerarAutorizacao(abastecimentoSelecionado);

            relat = new AutorizacaoAbastecimentoEmissao();
            relat.SetDataSource(dt);
            Relatorio autorizacaoAbast = new Relatorio(relat);
            autorizacaoAbast.Text = "Autorização de Abastecimento";
            autorizacaoAbast.ShowDialog();           
        }

        private void cbPosto_KeyDown(object sender, KeyEventArgs e)
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

        private void cbObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarregarComboUEN();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string validacaoObra = string.Empty;

            try
            {
                if (abastecimentoSelecionado.idAbastecimento == 0)
                    return;

                msgRetorno = ValidarExclusaoAbastecimento();

                if (msgRetorno == string.Empty)
                {
                    if(abastecimentoSelecionado.idObraEtapaGastoRealizado > 0)
                        validacaoObra = " e do lançamento na Obra " + cbObra.Text;

                    if (MessageBox.Show("Confirma exclusão da autorização de abastecimento" + validacaoObra + " ?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizVeiculo.ExcluirAbastecimento(abastecimentoSelecionado);
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

        private string ValidarExclusaoAbastecimento()
        {
            string msgRetorno = string.Empty;

            if (abastecimentoSelecionado.idOP > 0)
                msgRetorno += Environment.NewLine + "Já foi gerada uma OP para esse abastecimento";

            return msgRetorno;
        }

        private void tbKilometragem_Leave(object sender, EventArgs e)
        {
            tbKilometragem.Text = helper.FormatarValorMoeda(tbKilometragem.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void tbKilometragem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbKilometragem_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbLitros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbLitros_Leave(object sender, EventArgs e)
        {
            tbLitros.Text = double.Parse(tbLitros.Text).ToString("f3");               
        }

        private void tbDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbDesconto_Leave(object sender, EventArgs e)
        {
            tbDesconto.Text = double.Parse(tbDesconto.Text).ToString("f3");
            this.AtualizarTotal();
        }
    }
}
