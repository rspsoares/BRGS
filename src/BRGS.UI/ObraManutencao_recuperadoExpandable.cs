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

namespace BRGS.UI
{
    public partial class ObraManutencao_recuperadoExpandable : Form
    {
        //private Helper helper = new Helper();
        //private HelperUI helperUI = new HelperUI();
        //private Obra obraSelecionada = new Obra();
        //private ObraEtapa obraEtapaSelecionada = new ObraEtapa();
        //private Obra obraOriginal = new Obra();        
        //private BIZObra bizObra = new BIZObra();
        //private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        //private BIZUEN bizUEN = new BIZUEN();
        //private BIZCliente bizCliente = new BIZCliente();
        //private List<UENCentroCusto> lstCentroCustoAssociados = new List<UENCentroCusto>();
        //private List<CentroCustoDespesa> lstDespesasAssociadas = new List<CentroCustoDespesa>();
        //private List<UEN> lstUEN = new List<UEN>();
        //private List<CentroCusto> lstCC = new List<CentroCusto>();
        //private BIZFase bizFases = new BIZFase();        
        //private BIZLogErro bizLogErro = new BIZLogErro();
        //private bool listaGastosAlterada = false;        
        //private Random rnd = new Random();
        //private bool? previsaoEtapa = null;

        //public ObraManutencao_recuperadoExpandable(Obra _obraSelecionada, bool? _previsaoEtapa = null)
        //{
        //    InitializeComponent();

        //    obraSelecionada = _obraSelecionada;
        //    obraOriginal = _obraSelecionada;           
        //    previsaoEtapa = _previsaoEtapa;
        //}             

        //private void CarregarCombos()
        //{
        //    this.CarregarComboEmpresas();
        //    this.CarregarComboClientes();
        //    this.CarregarComboUENPrevisto();
        //    this.CarregarComboUENRealizado();
        //    this.CarregarListaCentroCusto();
        //    this.CarregarListaDespesas();
        //    this.CarregarComboFases();
        //}

        //private void CarregarComboFases()
        //{
        //    List<Fase> lstFases = new List<Fase>();

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {                
        //        lstFases.Add(new Fase() { idFase = 0, Descricao = "-- Selecione --" });
        //        lstFases.Add(new Fase() { idFase = -2, Descricao = "-- Criar nova... --" });
        //        lstFases.AddRange(bizFases.PesquisarFases(new Fase()).OrderBy(u => u.Descricao));

        //        cbFases.DataSource = lstFases;
        //        cbFases.DisplayMember = "Descricao";
        //        cbFases.ValueMember = "idFase";
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarComboClientes()
        //{
        //    List<Cliente> lstClientes = new List<Cliente>();

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        lstClientes.Add(new Cliente() { idCliente = 0, Nome = "--Selecione--" });
        //        lstClientes.AddRange(bizCliente.PesquisarCliente(new Cliente()).OrderBy(u => u.Nome));

        //        cbClientes.DataSource = lstClientes;
        //        cbClientes.DisplayMember = "Nome";
        //        cbClientes.ValueMember = "idCliente";              
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarListaDespesas()
        //{
        //    BIZDespesa bizDespesa = new BIZDespesa();

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        lstDespesasAssociadas = bizCentroCusto.PesquisarDespesasAssociadas(new CentroCustoDespesa());
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarListaCentroCusto()
        //{                      
        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        lstCentroCustoAssociados = bizUEN.PesquisarCentrosCustosAssociados(new UENCentroCusto());
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}
        
        //private void CarregarComboUENPrevisto()
        //{
        //    List<UEN> lstUENTemp = new List<UEN>();

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--", Administrativo = 0 });
        //        lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(u => u.Descricao).ToList());
                              
        //        cbPrevistoUEN.DataSource = lstUEN.Where(x => x.Administrativo == 0).ToList();
        //        cbPrevistoUEN.DisplayMember = "Descricao";
        //        cbPrevistoUEN.ValueMember = "idUEN";                
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarComboUENRealizado()
        //{
        //    cbRealizadoUEN.DataSource = null;
        //    cbRealizadoUEN.BindingContext = new BindingContext();
        //    cbRealizadoUEN.DataSource = lstUEN;
        //    cbRealizadoUEN.DisplayMember = "Descricao";
        //    cbRealizadoUEN.ValueMember = "idUEN";
        //}     

        //private void CarregarComboEmpresas()
        //{
        //    List<Empresa> lstEmpresas = new List<Empresa>();
        //    BIZEmpresa bizEmpresa = new BIZEmpresa();

        //    this.Cursor = Cursors.WaitCursor;
           
        //    try
        //    {
        //        lstEmpresas.Add(new Empresa() { idEmpresa = 0, razaoSocial = "--Selecione--" });
        //        lstEmpresas.AddRange(bizEmpresa.PesquisarEmpresa(new Empresa()).OrderBy(x => x.razaoSocial).ToList());

        //        cbEmpresa.DataSource = lstEmpresas;
        //        cbEmpresa.DisplayMember = "razaoSocial";
        //        cbEmpresa.ValueMember = "idEmpresa";
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarComparativoObra(ObraEtapa etapaObra)
        //{
        //    grpRealizados.Enabled = etapaObra.lstGastosPrevistos.Count > 0;

        //    this.CarregarGastosPrevistos(etapaObra.lstGastosPrevistos);
        //    this.CarregarGastosRealizados(etapaObra.lstGastosRealizados);
        //    this.CarregarFases(etapaObra.lstFases);
        //    this.CarregarFollowUps(etapaObra.lstFollowUps);

        //    //btGerarOP.Enabled = true;            
        //}     

        //private void tbNumeroLicitacao_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbNomeCliente_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbNomeEvento_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbPrevistoDespesa_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbPrevistoValor_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbRealizadoDespesa_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbRealizadoData_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbRealizadoValor_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbPrevistoValor_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    int asc = (int)e.KeyChar;

        //    if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
        //        e.Handled = true;
        //}

        //private void tbPrevistoValor_Leave(object sender, EventArgs e)
        //{
        //    tbPrevistoValor.Text = helper.FormatarValorMoeda(tbPrevistoValor.Text);
        //}

        //private void tbRealizadoValor_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    int asc = (int)e.KeyChar;

        //    if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
        //        e.Handled = true;
        //}

        //private void tbRealizadoValor_Leave(object sender, EventArgs e)
        //{
        //    tbRealizadoValor.Text = helper.FormatarValorMoeda(tbRealizadoValor.Text);            
        //}       

        //private void btPrevistoAdicionar_Click(object sender, EventArgs e)
        //{
        //    string msgRetorno = string.Empty;

        //    msgRetorno = VerificarNovoGastoPrevisto();

        //    if (msgRetorno == string.Empty)
        //    {
        //        ObraEtapaGastoPrevisto gastoPrevisto = new ObraEtapaGastoPrevisto()
        //        {
        //            idUEN = int.Parse(cbPrevistoUEN.SelectedValue.ToString()),
        //            descricaoUEN = cbPrevistoUEN.Text,
        //            idCentroCusto = int.Parse(cbPrevistoCentroCusto.SelectedValue.ToString()),
        //            descricaoCentroCusto = cbPrevistoCentroCusto.Text,
        //            idDespesa =  int.Parse(cbPrevistoDespesa.SelectedValue.ToString()),
        //            descricaoDespesa = cbPrevistoDespesa.Text,
        //            Valor = decimal.Parse(tbPrevistoValor.Text),
        //            Observacao = tbPrevistoObservacao.Text                    
        //        };

        //        obraEtapaSelecionada.lstGastosPrevistos.Add(gastoPrevisto);

        //        CarregarGastosPrevistos(obraEtapaSelecionada.lstGastosPrevistos.Where(x => x.descricaoUEN == cbPrevistoUEN.Text).ToList());    
                               
        //        tbPrevistoValor.Text = "0,00";

        //        listaGastosAlterada = true;                
        //    }
        //    else
        //        MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //}

        //private string VerificarNovoGastoPrevisto()
        //{
        //    string msgRetorno = string.Empty;

        //    if (cbPrevistoUEN.SelectedIndex == 0 || cbPrevistoUEN.FindStringExact(cbPrevistoUEN.Text) == -1)
        //        msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

        //    if (cbPrevistoCentroCusto.FindStringExact(cbPrevistoCentroCusto.Text) == -1)
        //        msgRetorno += Environment.NewLine + "Favor selecionar um Centro de Custo válido";

        //    if (cbPrevistoDespesa.FindStringExact(cbPrevistoDespesa.Text) == -1)
        //        msgRetorno += Environment.NewLine + "Favor selecionar uma Despesa válida";

        //    if (tbPrevistoValor.Text == string.Empty || tbPrevistoValor.Text == "0,00")
        //        msgRetorno += Environment.NewLine + "Favor informar o Valor";

        //    return msgRetorno;           
        //}

        //private void CarregarGastosPrevistos(List<ObraEtapaGastoPrevisto> lstGastosPrevistos)
        //{
        //    decimal totalPrevisto = decimal.Zero;
        //    decimal totalUEN = decimal.Zero;            
            
        //    while (gvGastosPrevistos.Rows.Count > 0)
        //        gvGastosPrevistos.Rows.RemoveAt(0);

        //    if (lstGastosPrevistos == null)
        //        return;

        //    foreach (ObraEtapaGastoPrevisto gastoPrevisto in lstGastosPrevistos)
        //    {
        //        gvGastosPrevistos.Rows.Add(new object[] 
        //        {
        //            gastoPrevisto.idUEN,
        //            gastoPrevisto.idCentroCusto,
        //            gastoPrevisto.idDespesa, 
        //            gastoPrevisto.descricaoUEN,
        //            gastoPrevisto.descricaoCentroCusto,                    
        //            gastoPrevisto.descricaoDespesa,
        //            helper.FormatarValorMoeda(gastoPrevisto.Valor.ToString()),
        //            gastoPrevisto.Observacao  
        //        });
        //    }

        //    if (cbPrevistoUEN.SelectedIndex != 0)            
        //        totalUEN = lstGastosPrevistos.Sum(x => x.Valor);

        //    lbPrevistoUEN.Text = "Total UEN: R$ " + helper.FormatarValorMoeda(totalUEN.ToString()); ;

        //    totalPrevisto = obraEtapaSelecionada.lstGastosPrevistos.Sum(x => x.Valor);
        //    lbPrevistoTotal.Text = "Total Previsto: R$ " + helper.FormatarValorMoeda(totalPrevisto.ToString());

        //    this.CarregarCentrosCustosPrevisto();
        //    this.FiltrarComboUENRealizado();          
        //}

        //private void FiltrarComboUENRealizado()
        //{
        //    List<UEN> lstUENFiltrada = new List<UEN>();
        //    List<UEN> lstUENTemp = new List<UEN>();


        //    if (obraEtapaSelecionada.lstGastosPrevistos.Count == 0)
        //    {
        //        this.CarregarComboUENRealizado();
        //        return;
        //    }

        //    try
        //    {
        //        // Filtrar o Combo de UEN's realizadas para só mostrar as Unidades previstas
        //        var uenFiltrada =
        //            (from lstUENPrev in obraEtapaSelecionada.lstGastosPrevistos
        //            from lstUENReal in lstUEN
        //            where lstUENPrev.idUEN == lstUENReal.idUEN
        //            orderby lstUENReal.Descricao
        //            select lstUENReal).Distinct();
                               
        //        // E dentro dessas UEN's previstas, só mostrar as que ele tiver permissão
        //        lstUENTemp = uenFiltrada.ToList();
        //        foreach (UsuarioUEN itemUsuarioUEN in UsuarioLogado.lstUEN)
        //        {
        //            if (lstUENTemp.Exists(x => x.idUEN == itemUsuarioUEN.idUEN) == false)
        //                lstUENTemp.RemoveAll(x => x.idUEN == itemUsuarioUEN.idUEN);                    
        //        }               

        //        lstUENFiltrada.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });
        //        //lstUENFiltrada.AddRange((List<UEN>)uenFiltrada.ToList());
        //        lstUENFiltrada.AddRange(lstUENTemp);

        //        cbRealizadoUEN.DataSource = null;
        //        cbRealizadoUEN.BindingContext = new BindingContext();
        //        cbRealizadoUEN.DataSource = lstUENFiltrada;
        //        cbRealizadoUEN.DisplayMember = "Descricao";
        //        cbRealizadoUEN.ValueMember = "idUEN";
        //        cbRealizadoUEN.SelectedIndex = 0;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void CarregarFases(List<ObraEtapaFase> lstFases)
        //{
        //    DateTime? dataTermino = new DateTime();
            
        //    while (gvFases.Rows.Count > 0)
        //        gvFases.Rows.RemoveAt(0);

        //    if (lstFases == null)
        //        return;

        //    gvFases.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    gvFases.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    gvFases.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";

        //    foreach (ObraEtapaFase itemFase in lstFases.OrderBy(x => x.dataInicio).ThenBy(x => x.dataPrevTermino).ToList()) 
        //    {
        //        dataTermino = itemFase.dataTermino == DateTime.MinValue ? (DateTime?)null : itemFase.dataTermino;
        //        itemFase.id = itemFase.id == 0 ? rnd.Next(1,100) : itemFase.id;

        //        gvFases.Rows.Add(new object[] 
        //        {
        //            itemFase.id,
        //            itemFase.idFase,
        //            itemFase.Descricao,
        //            itemFase.dataInicio.Date,
        //            itemFase.dataPrevTermino.Date,
        //            dataTermino
        //        });
        //    }
        //}

        //private void CarregarFollowUps(List<ObraEtapaFollowUp> lstFU)
        //{
        //    while (gvFollowUp.Rows.Count > 0)
        //        gvFollowUp.Rows.RemoveAt(0);

        //    if (lstFU == null)
        //        return;

        //    gvFollowUp.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

        //    foreach (ObraEtapaFollowUp itemFU in lstFU.OrderByDescending(x => x.Data).ThenByDescending(x => x.idFollowUp).ToList())
        //    {
        //        gvFollowUp.Rows.Add(new object[] 
        //        {
        //            itemFU.Data,
        //            itemFU.Descricao,
        //            itemFU.nomeUsuario                    
        //        });
        //    }
        //}

        //private void CarregarGastosRealizados(List<ObraEtapaGastoRealizado> lstGastosRealizados)
        //{
        //    decimal totalRealizado = decimal.Zero;
        //    decimal totalUEN = decimal.Zero;

        //    while (gvGastosRealizados.Rows.Count > 0)
        //        gvGastosRealizados.Rows.RemoveAt(0);

        //    if (lstGastosRealizados == null)
        //        return;

        //    gvGastosRealizados.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";

        //    lstGastosRealizados = lstGastosRealizados.
        //        OrderBy(real => real.descricaoUEN).
        //        ThenBy(real => real.descricaoCentroCusto).
        //        ThenBy(real => real.descricaoDespesa).ToList();

        //    foreach (ObraEtapaGastoRealizado gastoRealizado in lstGastosRealizados)
        //    {
        //        gvGastosRealizados.Rows.Add(new object[] 
        //        {
        //            gastoRealizado.idUEN,
        //            gastoRealizado.idCentroCusto,
        //            gastoRealizado.idDespesa, 
        //            gastoRealizado.descricaoUEN,
        //            gastoRealizado.descricaoCentroCusto,          
        //            gastoRealizado.descricaoDespesa,
        //            gastoRealizado.Data.Date,
        //            helper.FormatarValorMoeda(gastoRealizado.Valor.ToString()),                  
        //            gastoRealizado.Observacao,
        //            this.CalcularSaldoDespesa(gastoRealizado),
        //            gastoRealizado.statusOrdemPagamento,
        //            gastoRealizado.idObraEtapaGastoRealizado 
        //        });
        //    }

        //    if (cbRealizadoUEN.SelectedIndex != 0)
        //        totalUEN = lstGastosRealizados.Sum(x => x.Valor);

        //    lbRealizadoUEN.Text = "Total UEN: R$ " + helper.FormatarValorMoeda(totalUEN.ToString()); ;

        //    totalRealizado = obraEtapaSelecionada.lstGastosRealizados.Sum(x => x.Valor);
        //    lbRealizadoTotal.Text = "Total Realizado: R$ " + helper.FormatarValorMoeda(totalRealizado.ToString());          
        //}

        //private string CalcularSaldoDespesa(ObraEtapaGastoRealizado gastoRealizado)
        //{
        //    decimal saldoDespesa = decimal.Zero;
        //    decimal valorPrevisto = decimal.Zero;
        //    decimal totalRealizado = decimal.Zero;

        //    valorPrevisto = obraEtapaSelecionada.lstGastosPrevistos.Where(
        //        prev => prev.idUEN == gastoRealizado.idUEN && 
        //        prev.idCentroCusto == gastoRealizado.idCentroCusto && 
        //        prev.idDespesa == gastoRealizado.idDespesa).Sum(total => total.Valor);

        //    totalRealizado = obraEtapaSelecionada.lstGastosRealizados.Where(
        //       real => real.idUEN == gastoRealizado.idUEN &&
        //       real.idCentroCusto == gastoRealizado.idCentroCusto &&
        //       real.idDespesa == gastoRealizado.idDespesa).Sum(total => total.Valor);

        //    saldoDespesa = valorPrevisto - totalRealizado;

        //    return helper.FormatarValorMoeda(saldoDespesa.ToString());
        //}

        //private void btPrevistoRemover_Click(object sender, EventArgs e)
        //{
        //    int linhaGrid = 0;

        //    if (gvGastosPrevistos.RowCount == 0)
        //        return;

        //    linhaGrid = gvGastosPrevistos.SelectedCells[0].RowIndex;

        //    ObraEtapaGastoPrevisto itemSelecionado = new ObraEtapaGastoPrevisto()
        //    {
        //        idUEN = int.Parse(gvGastosPrevistos[0, linhaGrid].Value.ToString()),
        //        idCentroCusto = int.Parse(gvGastosPrevistos[1, linhaGrid].Value.ToString()),
        //        idDespesa = int.Parse(gvGastosPrevistos[2, linhaGrid].Value.ToString()),   
        //        Valor = decimal.Parse(gvGastosPrevistos[6, linhaGrid].Value.ToString())   
        //    };

        //    obraEtapaSelecionada.lstGastosPrevistos.RemoveAll(item =>
        //        item.idUEN == itemSelecionado.idUEN &&
        //        item.idCentroCusto == itemSelecionado.idCentroCusto &&
        //        item.idDespesa == itemSelecionado.idDespesa &&
        //        item.Valor == itemSelecionado.Valor);

        //    if (cbPrevistoUEN.SelectedIndex == 0)
        //        CarregarGastosPrevistos(obraEtapaSelecionada.lstGastosPrevistos);
        //    else
        //        CarregarGastosPrevistos(obraEtapaSelecionada.lstGastosPrevistos.Where(x => x.descricaoUEN == cbPrevistoUEN.Text).ToList());

        //    listaGastosAlterada = true;
        //}

        //private void btRealizadoAdicionar_Click(object sender, EventArgs e)
        //{
        //    string msgRetorno = string.Empty;

        //    msgRetorno = VerificarNovoGastoRealizado();

        //    if (msgRetorno == string.Empty)
        //    {
        //        ObraEtapaGastoRealizado gastoRealizado = new ObraEtapaGastoRealizado()
        //        {
        //            idObraEtapaGastoRealizado = 0,
        //            idUEN = int.Parse(cbRealizadoUEN.SelectedValue.ToString()),
        //            descricaoUEN = cbRealizadoUEN.Text,
        //            idCentroCusto = int.Parse(cbRealizadoCentroCusto.SelectedValue.ToString()),
        //            descricaoCentroCusto = cbRealizadoCentroCusto.Text,
        //            idDespesa  = int.Parse(cbRealizadoDespesa.SelectedValue.ToString()),
        //            descricaoDespesa = cbRealizadoDespesa.Text,
        //            Data = tbRealizadoData.Value,
        //            Valor = decimal.Parse(tbRealizadoValor.Text),
        //            Observacao = tbRealizadoObservacao.Text,
        //            statusOrdemPagamento = "*"                 
        //        };

        //        obraEtapaSelecionada.lstGastosRealizados.Add(gastoRealizado);

        //        CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados.Where(x => x.descricaoUEN == cbRealizadoUEN.Text).ToList());

        //        this.CarregarCentrosCustosRealizado();

        //        tbRealizadoData.Value = DateTime.Now;
        //        tbRealizadoValor.Text = "0,00";
        //        listaGastosAlterada = true;                
        //    }
        //    else
        //        MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //}

        //private string VerificarNovoGastoRealizado()
        //{
        //    string msgRetorno = string.Empty;            

        //    if (cbRealizadoUEN.SelectedIndex == 0 || cbRealizadoUEN.FindStringExact(cbRealizadoUEN.Text) == -1)
        //        msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

        //    if (cbRealizadoCentroCusto.FindStringExact(cbRealizadoCentroCusto.Text) == -1)
        //        msgRetorno += Environment.NewLine + "Favor selecionar um Centro de Custo válido";

        //    if (cbRealizadoDespesa.FindStringExact(cbRealizadoDespesa.Text) == -1)
        //        msgRetorno += Environment.NewLine + "Favor selecionar uma Despesa válida";

        //    if (tbRealizadoValor.Text == string.Empty || tbRealizadoValor.Text == "0,00")
        //        msgRetorno += Environment.NewLine + "Favor informar o Valor";

        //    return msgRetorno;
        //}

        //private void btRealizadoRemover_Click(object sender, EventArgs e)
        //{
        //    int linhaGrid = 0;

        //    if (gvGastosRealizados.RowCount == 0)
        //        return;

        //    linhaGrid = gvGastosRealizados.SelectedCells[0].RowIndex;
            
        //    if (gvGastosRealizados[8, linhaGrid].Value.ToString().ToUpper() == "* LANÇAMENTO AUTOMÁTICO ABASTECIMENTO *")
        //    {
        //        MessageBox.Show("Essa despesa foi lançada automaticamente. Para removê-la, é necessário excluir a autorização desse abastecimento, no módulo de Transportes", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }
        //    else if (gvGastosRealizados[8, linhaGrid].Value.ToString().ToUpper() == "* LANÇAMENTO AUTOMÁTICO FRETE *")
        //    {
        //        MessageBox.Show("Essa despesa foi lançada automaticamente. Para removê-la, é necessário excluir no Controle de Fretes, no módulo de Transportes", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    ObraEtapaGastoRealizado itemSelecionado = new ObraEtapaGastoRealizado()
        //    {
        //        idObraEtapaGastoRealizado = int.Parse(gvGastosRealizados[11, linhaGrid].Value.ToString())                
        //    };

        //    obraEtapaSelecionada.lstGastosRealizados.RemoveAll(item => item.idObraEtapaGastoRealizado == itemSelecionado.idObraEtapaGastoRealizado);

        //    if (cbRealizadoUEN.SelectedIndex == 0)
        //        CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados);
        //    else
        //        CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados.Where(x => x.descricaoUEN == cbRealizadoUEN.Text).ToList());

        //    this.CarregarCentrosCustosRealizado();

        //    listaGastosAlterada = true;
        //}

        //private void btGravarGastos_Click(object sender, EventArgs e)
        //{
        //    string msgRetorno = string.Empty;
        //    string acaoSelecionada = string.Empty;
            
        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        //if (obraEtapaSelecionada.idObraEtapa == 0)
        //        //{
        //        //    msgRetorno = bizObra.IncluirObraEtapa(obraEtapaSelecionada, out idObraEtapa);
        //        //    acaoSelecionada = "Inclusão";
        //        //    obraEtapaSelecionada.idObraEtapa = idObraEtapa;
        //        //}
        //        //else
        //        //{

        //        msgRetorno = bizObra.AlterarObraEtapa(obraEtapaSelecionada);
        //        acaoSelecionada = "Alteração";

        //        //}

        //        if (msgRetorno == string.Empty)
        //        {
        //            grpRealizados.Enabled = obraEtapaSelecionada.lstGastosPrevistos.Count > 0;

        //            obraEtapaSelecionada = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObraEtapa = obraEtapaSelecionada.idObraEtapa }).FirstOrDefault();

        //            //foreach (ObraEtapaGastoRealizado itemGastoRealizado in obraEtapaSelecionada.lstGastosRealizados)
        //            //{
        //            //    if (itemGastoRealizado.statusOrdemPagamento == "*")
        //            //        itemGastoRealizado.statusOrdemPagamento = string.Empty;
        //            //}                    

        //            CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados);
        //            //btGerarOP.Enabled = true;
        //           // expTotaisObra.Enabled = true;

        //            MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //            MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private Color AtualizarCorSaldoBruto(decimal valorTotal, decimal valorAtual)
        //{
        //    Color cor = Color.Black;
        //    decimal margemLucro = decimal.Zero;

        //    if (valorTotal == decimal.Zero)
        //        return Color.Black;

        //    margemLucro = (valorAtual * 100) / valorTotal;

        //    if (margemLucro >= 20)
        //        cor = Color.Green;
        //    else if (margemLucro > 0 && margemLucro < 20)
        //        cor = Color.Orange;
        //    else
        //        cor = Color.Red;

        //    return cor;
        //}

        //private Color AtualizarCorSaldoUEN(decimal valorPrevisto, decimal valorRealizado)
        //{
        //    Color cor = Color.Black;
            
        //    if(valorPrevisto == valorRealizado && valorPrevisto != decimal.Zero)            
        //        cor = Color.Orange;                        
        //    else if (valorPrevisto > valorRealizado)            
        //        cor = Color.Green;            
        //    else if (valorPrevisto < valorRealizado)            
        //        cor = Color.Red;            

        //    return cor;
        //}
        
        //private void tbValorBruto_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbValorBruto_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    int asc = (int)e.KeyChar;

        //    if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
        //        e.Handled = true;
        //}

        //private void tbValorBruto_Leave(object sender, EventArgs e)
        //{
        //    tbValorBruto.Text = helper.FormatarValorMoeda(tbValorBruto.Text);
        //}

        //private void cbEmpresa_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbPrevistoUEN_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbPrevistoCentroCusto_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbRealizadoUEN_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbRealizadoCentroCusto_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void cbPrevistoUEN_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbPrevistoUEN.SelectedIndex == 0)
        //        CarregarGastosPrevistos(obraEtapaSelecionada.lstGastosPrevistos);
        //    else
        //        CarregarGastosPrevistos(obraEtapaSelecionada.lstGastosPrevistos.Where(x => x.descricaoUEN == cbPrevistoUEN.Text).ToList());

        //    this.CarregarCentrosCustosPrevisto();
        //}

        //private void cbRealizadoUEN_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbRealizadoUEN.SelectedIndex == 0)
        //        CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados);
        //    else
        //        CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados.Where(x => x.descricaoUEN == cbRealizadoUEN.Text).ToList());
            
        //    this.CarregarCentrosCustosRealizado();
        //}

        //private void CarregarCentrosCustosPrevisto()
        //{
        //    int idUENCombo = 0;
        //    int idCCPrevisto = 0;
        //    List<ObraEtapaGastoPrevisto> lstCCPrevisto = new List<ObraEtapaGastoPrevisto>();
        //    List<UENCentroCusto> lstCCPrev = new List<UENCentroCusto>();

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {                 
        //        cbPrevistoCentroCusto.DataSource = null;
        //        cbPrevistoCentroCusto.Text = string.Empty;

        //        if (cbPrevistoUEN.SelectedValue != null && int.TryParse(cbPrevistoUEN.SelectedValue.ToString(), out idUENCombo))
        //        {
        //            lstCCPrevisto = obraEtapaSelecionada.lstGastosPrevistos.Where(x => x.idUEN == idUENCombo).ToList();

        //            if (obraEtapaSelecionada.lstGastosPrevistos.Count > 0 && idUENCombo != 0 && lstCCPrevisto.Count > 0)
        //            {
        //                idCCPrevisto = obraEtapaSelecionada.lstGastosPrevistos.Where(x => x.idUEN == idUENCombo).ToList()[0].idCentroCusto;
        //                lstCCPrev = lstCentroCustoAssociados.Where(x => x.idUEN == idUENCombo && x.Administrativo == 0 && (x.idCentroCusto == idCCPrevisto && idCCPrevisto != 0)).OrderBy(x => x.descricaoCentroCusto).ToList();                        
        //            }
        //            else                    
        //                lstCCPrev = lstCentroCustoAssociados.Where(x => x.idUEN == idUENCombo && x.Administrativo == 0).OrderBy(x => x.descricaoCentroCusto).ToList();
                    
        //            cbPrevistoCentroCusto.BindingContext = new BindingContext();
        //            cbPrevistoCentroCusto.DataSource = lstCCPrev;                        
        //            cbPrevistoCentroCusto.DisplayMember = "descricaoCentroCusto";
        //            cbPrevistoCentroCusto.ValueMember = "idCentroCusto";
        //            cbPrevistoCentroCusto.Text = "--Selecione--";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarCentrosCustosRealizado()
        //{
        //    int idUENCombo = 0;
        //    int idCCPrevisto = 0;
        //    int idCCRealizado = 0;
        //    List<UENCentroCusto> lstCCReal = new List<UENCentroCusto>();
        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        cbRealizadoCentroCusto.DataSource = null;
        //        cbRealizadoCentroCusto.Text = string.Empty;

        //        if (cbRealizadoUEN.SelectedValue != null && int.TryParse(cbRealizadoUEN.SelectedValue.ToString(), out idUENCombo))
        //        {
        //            if (obraEtapaSelecionada.lstGastosPrevistos.Count > 0 && idUENCombo != 0) // Foi previsto CC
        //            {
        //                idCCPrevisto = obraEtapaSelecionada.lstGastosPrevistos.Where(x => x.idUEN == idUENCombo).ToList()[0].idCentroCusto;
        //                lstCCReal = lstCentroCustoAssociados.Where(x => x.idUEN == idUENCombo && (x.idCentroCusto == idCCPrevisto && idCCPrevisto != 0)).OrderBy(x => x.descricaoCentroCusto).ToList();
        //            }
        //            else // Não foi previsto CC
        //            {
        //                if (obraEtapaSelecionada.lstGastosRealizados.Count > 0 && idUENCombo != 0) // Já foi adicionado um lançamento realizado. Filtrar pelo Centro de Custo adicionado
        //                {
        //                    if (obraEtapaSelecionada.lstGastosRealizados.Where(x => x.idUEN == idUENCombo).Count() > 0)
        //                    {
        //                        idCCRealizado = obraEtapaSelecionada.lstGastosRealizados.Where(x => x.idUEN == idUENCombo).ToList()[0].idCentroCusto;
        //                        lstCCReal = lstCentroCustoAssociados.Where(x => x.idUEN == idUENCombo && (x.idCentroCusto == idCCRealizado && idCCRealizado != 0)).OrderBy(x => x.descricaoCentroCusto).ToList();
        //                    }
        //                }
        //                else
        //                    lstCCReal = lstCentroCustoAssociados.Where(x => x.idUEN == idUENCombo).OrderBy(x => x.descricaoCentroCusto).ToList();
        //            }

        //            cbRealizadoCentroCusto.BindingContext = new BindingContext();
        //            cbRealizadoCentroCusto.DataSource = lstCCReal;
        //            cbRealizadoCentroCusto.DisplayMember = "descricaoCentroCusto";
        //            cbRealizadoCentroCusto.ValueMember = "idCentroCusto";
        //            cbRealizadoCentroCusto.Text = "--Selecione--";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarDespesasPrevisto()
        //{
        //    int idCentroCustoCombo = 0;

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        cbPrevistoDespesa.DataSource = null;
        //        cbPrevistoDespesa.Text = string.Empty;

        //        if (cbPrevistoCentroCusto.SelectedValue != null && int.TryParse(cbPrevistoCentroCusto.SelectedValue.ToString(), out idCentroCustoCombo))
        //        {
        //            cbPrevistoDespesa.BindingContext = new BindingContext();
        //            cbPrevistoDespesa.DataSource = lstDespesasAssociadas.Where(x => x.idCentroCusto == idCentroCustoCombo).OrderBy(x => x.descricaoDespesa).ToList();
        //            cbPrevistoDespesa.DisplayMember = "descricaoDespesa";
        //            cbPrevistoDespesa.ValueMember = "idDespesa";
        //            cbPrevistoDespesa.Text = "--Selecione--";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void CarregarDespesasRealizado()
        //{
        //    int idCentroCustoCombo = 0;

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {             
        //        cbRealizadoDespesa.DataSource = null;
        //        cbRealizadoDespesa.Text = string.Empty;

        //        if (cbRealizadoCentroCusto.SelectedValue != null && int.TryParse(cbRealizadoCentroCusto.SelectedValue.ToString(), out idCentroCustoCombo))
        //        {
        //            cbRealizadoDespesa.BindingContext = new BindingContext();
        //            cbRealizadoDespesa.DataSource = lstDespesasAssociadas.Where(x => x.idCentroCusto == idCentroCustoCombo).OrderBy(x => x.descricaoDespesa).ToList(); ;
        //            cbRealizadoDespesa.DisplayMember = "descricaoDespesa";
        //            cbRealizadoDespesa.ValueMember = "idDespesa";
        //            cbRealizadoDespesa.Text = "--Selecione--";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}

        //private void cbPrevistoCentroCusto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.CarregarDespesasPrevisto();
        //}

        //private void cbRealizadoCentroCusto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.CarregarDespesasRealizado();
        //}

        //private void ObraManutencao_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //if (this.VerificarAlteracoesNaoSalvas())
        //    //{
        //    //    if (MessageBox.Show("Existem alterações não gravadas. Deseja sair mesmo assim?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
        //    //        e.Cancel = true;
        //    //}
        //}

        ////private bool VerificarAlteracoesNaoSalvas()
        ////{            
        ////    int idEmpresa = 0;
        ////    int idCliente = 0;

        ////    obraOriginal.numeroLicitacao = obraOriginal.numeroLicitacao == null ? string.Empty : obraOriginal.numeroLicitacao;
        ////    obraOriginal.nomeCliente = obraOriginal.nomeCliente == null ? string.Empty : obraOriginal.nomeCliente;
        ////    obraOriginal.nomeEvento = obraOriginal.nomeEvento == null ? string.Empty : obraOriginal.nomeEvento;

        ////    if (cbEmpresa.SelectedIndex > 0 && cbEmpresa.FindStringExact(cbEmpresa.Text) != -1)
        ////        idEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());

        ////    if (cbClientes.SelectedIndex > 0 && cbClientes.FindStringExact(cbClientes.Text) != -1)
        ////        idCliente = int.Parse(cbClientes.SelectedValue.ToString());

        ////    // Verificando dados do cabeçalho
        ////    if (obraOriginal.idEmpresa != idEmpresa)
        ////        return true;

        ////    if (obraOriginal.numeroLicitacao != tbNumeroLicitacao.Text)
        ////        return true;

        ////    if (obraOriginal.idCliente != idCliente)
        ////        return true;

        ////    if (obraOriginal.nomeEvento != tbNomeEvento.Text)
        ////        return true;

        ////    //if (obraOriginal.valorContrato != decimal.Parse(tbValorContrato.Text))
        ////    //    return true;
            
        ////    // Verificando Lançamentos
        ////    if (listaGastosAlterada)
        ////        return true;

        ////    return false;
        ////}

        //private void cbClientes_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}        

        //private void tbRealizadoObservacao_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void tbPrevistoObservacao_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

        //private void gvGastosRealizados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (decimal.Parse(gvGastosRealizados.Rows[e.RowIndex].Cells[9].Value.ToString()) < decimal.Zero)
        //        gvGastosRealizados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;            
        //}

        //private void btGerarOP_Click(object sender, EventArgs e)
        //{
        //    OrdemPagamento ordemPagamento = new OrdemPagamento();
        //    string msgRetorno = string.Empty;
        //    bool novoLancamento = false;
        //    int linhaGrid = 0;

        //    try
        //    {
        //        msgRetorno = this.ValidarGeracaoOP();

        //        if (msgRetorno == string.Empty)                
        //        {

        //            linhaGrid = gvGastosRealizados.SelectedCells[0].RowIndex;

        //            if (gvGastosRealizados[8, linhaGrid].Value.ToString().ToUpper() == "* LANÇAMENTO AUTOMÁTICO ABASTECIMENTO *")
        //            {
        //                MessageBox.Show("A OP dessa despesa será gerada pelo módulo de Transportes", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                return;
        //            }
                    
        //            DataGridViewRowCollection lstItens = gvGastosRealizados.Rows;
        //            foreach (DataGridViewRow linhaSelecionada in lstItens)
        //            {
        //                if (linhaSelecionada.Cells[10].Value.ToString() == "*")
        //                {
        //                    novoLancamento = true;
        //                    break;
        //                }
        //            }
                    
        //            if (novoLancamento)
        //                if (MessageBox.Show("Existem lançamentos não gravados. Se confirmar a geração da Ordem de Pagamento eles serão perdidos. Deseja continuar?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
        //                    return;
                    
        //            ordemPagamento.idOrdemPagamento = 0;
        //            ordemPagamento.idEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());
        //            ordemPagamento.idObraEtapa = obraEtapaSelecionada.idObraEtapa;                    
        //            ordemPagamento.idSolicitante = UsuarioLogado.idUsuario;
        //            ordemPagamento.nomeSolicitante = UsuarioLogado.Nome;
        //            ordemPagamento.dataSolicitacao = DateTime.Now;
        //            ordemPagamento.Autorizado = string.Empty;
        //            ordemPagamento.Observacao = string.Empty;
        //            ordemPagamento.lstItens = new List<OrdemPagamentoItem>();

        //            DataGridViewSelectedRowCollection lstItensSelecionados = gvGastosRealizados.SelectedRows;
        //            foreach (DataGridViewRow linhaSelecionada in lstItensSelecionados)
        //            {
        //                ordemPagamento.lstItens.Add(new OrdemPagamentoItem()
        //                {
        //                    idObraGastoRealizado = int.Parse(linhaSelecionada.Cells[11].Value.ToString()),
        //                    idUEN = int.Parse(linhaSelecionada.Cells[0].Value.ToString()),
        //                    idCentroCusto = int.Parse(linhaSelecionada.Cells[1].Value.ToString()),
        //                    idDespesa = int.Parse(linhaSelecionada.Cells[2].Value.ToString()),
        //                    descricaoUEN = linhaSelecionada.Cells[3].Value.ToString(),
        //                    descricaoCentroCusto = linhaSelecionada.Cells[4].Value.ToString(),
        //                    descricaoDespesa = linhaSelecionada.Cells[5].Value.ToString(),
        //                    Valor = decimal.Parse(linhaSelecionada.Cells[7].Value.ToString()),
        //                    dataVencimento = DateTime.Parse(linhaSelecionada.Cells[6].Value.ToString()),
        //                    numeroParcela = 1,
        //                    totalParcelas = 1
        //                });
        //            }

        //            OrdemPagamentoManutencao form = new OrdemPagamentoManutencao(ordemPagamento, false);
        //            form.ShowDialog();

        //            obraEtapaSelecionada.lstGastosRealizados = new List<ObraEtapaGastoRealizado>();
        //            obraEtapaSelecionada.lstGastosRealizados = bizObra.PesquisarGastosRealizados(new ObraEtapaGastoRealizado() { idObraEtapa = obraEtapaSelecionada.idObraEtapa });
        //            CarregarGastosRealizados(obraEtapaSelecionada.lstGastosRealizados);
        //        }
        //        else
        //            MessageBox.Show("Atenção" + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private string ValidarGeracaoOP()
        //{
        //    string msgRetorno = string.Empty;
        //    bool lancamentoSemOP = true;

        //    if(cbEmpresa.FindStringExact(cbEmpresa.Text) == -1)
        //         msgRetorno += Environment.NewLine + "Empresa inválida";
    
        //    if(gvGastosRealizados.SelectedRows.Count == 0)
        //        msgRetorno += Environment.NewLine + "Favor selecionar pelo menos um Lançamento Realizado";

        //    DataGridViewSelectedRowCollection lstItensSelecionados = gvGastosRealizados.SelectedRows;
            
        //    foreach (DataGridViewRow linhaSelecionada in lstItensSelecionados)
        //    {
        //       if (linhaSelecionada.Cells[10].Value.ToString() != string.Empty)
        //       {
        //            lancamentoSemOP = false;
        //            break;
        //        }                
        //    }

        //    if (lancamentoSemOP == false)            
        //        msgRetorno += Environment.NewLine + "Favor selecionar somente Lançamentos Realizados gravados e sem Ordem de Pagamento gerada";            

        //    return msgRetorno;
        //}       

        //private void ObraManutencao_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

        //        CarregarCombos();
                
        //        tbFaseDataInicio.Value = DateTime.Today;
        //        tbFaseDataPrevTermino.Value = DateTime.Today;
        //        tbFaseDataTermino.Value = DateTime.Today;
        //        tbValorBruto.Text = "0";
        //        chkFinalizada.Checked = obraSelecionada.Finalizada == 1;

        //        tbFUData.Value = DateTime.Today;
        //        tbFUUsuario.Text = UsuarioLogado.Nome;

        //        if (obraSelecionada.idObra == 0)                                    
        //        {
        //            //expPlanejamentoObra.Enabled = false;
        //            //expLancamentoGastosEtapa.Enabled = false;
        //            //expLancamentoGastosEtapa.IsExpanded = false;
        //            //expTotaisObra.Enabled = false;
        //            //expTotaisObra.IsExpanded = false;
        //        }
        //        else
        //        {
        //            cbEmpresa.SelectedValue = obraSelecionada.idEmpresa;
        //            tbNumeroLicitacao.Text = obraSelecionada.numeroLicitacao;
        //            cbClientes.SelectedValue = obraSelecionada.idCliente;
        //            tbNomeEvento.Text = obraSelecionada.nomeEvento;
        //            tbValorBruto.Text = helper.FormatarValorMoeda(obraSelecionada.valorBruto.ToString());
                    
        //            if(obraSelecionada.lstEtapas.Count > 0)
        //            {
        //                CarregarGridEtapas();

        //                obraEtapaSelecionada = obraSelecionada.lstEtapas.First();
                        
        //                CarregarComparativoObra(obraEtapaSelecionada);
        //                HabilitarCamposCabecalho();
        //                VerificarObraFinalizada();                       
        //            }
        //        }

        //        this.Cursor = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        LogErro logErro = new LogErro()
        //        {
        //            mensagemErro = ex.ToString()
        //        };

        //        bizLogErro.IncluirLogErro(logErro);
        //    }			
        //}

        //private void CarregarGridEtapas()
        //{            
        //    while (gvPlanejamento.Rows.Count > 0)
        //        gvPlanejamento.Rows.RemoveAt(0);

        //    if (obraSelecionada.lstEtapas.Count > 0)
        //    {
        //        gvPlanejamento.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
        //        gvPlanejamento.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        //        gvPlanejamento.Columns[4].DefaultCellStyle.Format = "N2";

        //        foreach (ObraEtapa obraEtapa in obraSelecionada.lstEtapas)
        //        {
        //            gvPlanejamento.Rows.Add(new object[] 
        //            {
        //                obraEtapa.idObraEtapa, 
        //                obraEtapa.Descricao,
        //                obraEtapa.dataInicio.Date,
        //                obraEtapa.dataTermino.Date,                         
        //                decimal.Parse(helper.FormatarValorMoeda(obraEtapa.valorContrato.ToString()))
        //            });
        //        }

        //        //expLancamentoGastosEtapa.Enabled = true;
        //       // expTotaisObra.Enabled = true;
        //    }
        //}

        //private void HabilitarCamposCabecalho()
        //{            
        //    UsuarioPermissoes permissaoAlterarCabecalho = new UsuarioPermissoes();

        //    permissaoAlterarCabecalho = UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name && perm.nomeControle == "AlterarCabecalhoObra").FirstOrDefault(); // .ToList()[0];

        //    //if (permissaoAlterarCabecalho != null)
        //        //expDadosObra.Enabled = permissaoAlterarCabecalho.Habilitado;

        //    //{


        //    //    tbDescricao.Enabled = permissaoAlterarCabecalho.Habilitado;
        //    //    tbValorBruto.Enabled = permissaoAlterarCabecalho.Habilitado;
        //    //    tbDataInicio.Enabled = permissaoAlterarCabecalho.Habilitado;
        //    //    tbDataTermino.Enabled = permissaoAlterarCabecalho.Habilitado;
        //    //}
        //}

        //private void VerificarObraFinalizada()
        //{
        //    if (previsaoEtapa != null)
        //    {
        //        grpPrevistos.Enabled = previsaoEtapa.Value && obraSelecionada.Finalizada == 0;
        //        grpRealizados.Enabled = !previsaoEtapa.Value && obraSelecionada.Finalizada == 0;
        //    }
        //    else
        //    {
        //        grpPrevistos.Enabled = obraSelecionada.Finalizada == 0;
        //        grpRealizados.Enabled = obraSelecionada.Finalizada == 0;
        //    }

        //    grpFases.Enabled = obraSelecionada.Finalizada == 0;
        //    grpFollowUp.Enabled = obraSelecionada.Finalizada == 0;            
        //}

        //private void cbFases_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbFases.SelectedIndex > 0 && int.Parse(cbFases.SelectedValue.ToString()) == -2)
        //    {
        //        FaseManutencao form = new FaseManutencao(new Fase());
        //        form.ShowDialog();
        //        this.CarregarComboFases();
        //    }
        //}

        //private void chkFaseConcluida_CheckedChanged(object sender, EventArgs e)
        //{
        //    tbFaseDataTermino.Enabled = chkFaseConcluida.Checked; 
        //}

        //private void btFaseAdd_Click(object sender, EventArgs e)
        //{
        //    string Msg = string.Empty;

        //    Msg = this.ValidarAdicionarFase();

        //    if (Msg == string.Empty)
        //    {
        //        if (lbLinhaGrid.Text != string.Empty)
        //            obraEtapaSelecionada.lstFases.RemoveAll(x => x.id == int.Parse(lbLinhaGrid.Text));

        //        obraEtapaSelecionada.lstFases.Add(new ObraEtapaFase()
        //        {
        //            id = rnd.Next(1,100),
        //            idObraEtapa = obraEtapaSelecionada.idObraEtapa,
        //            idFase = int.Parse(cbFases.SelectedValue.ToString()),
        //            Descricao = cbFases.Text,
        //            dataInicio = tbFaseDataInicio.Value.Date,
        //            dataPrevTermino = tbFaseDataPrevTermino.Value.Date,
        //            dataTermino = chkFaseConcluida.Checked ? tbFaseDataTermino.Value.Date : DateTime.MinValue
        //        });

        //        this.CarregarFases(obraEtapaSelecionada.lstFases);

        //        cbFases.SelectedIndex = 0;                
        //        btFaseAdd.Text = "Adicionar";
        //        lbLinhaGrid.Text = string.Empty;
        //    }
        //    else
        //        MessageBox.Show(Msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);           
        //}

        //private string ValidarAdicionarFase()
        //{
        //    string Msg = string.Empty;

        //    if (cbFases.SelectedIndex == 0 || cbFases.FindStringExact(cbFases.Text) == -1)
        //        Msg += Environment.NewLine + "Favor selecionar uma das Fases cadastradas";

        //    if(tbFaseDataInicio.Value > tbFaseDataPrevTermino.Value)
        //        Msg += Environment.NewLine + "A Data de Início não pode ser maior do que a Data de Previsão de Término.";

        //    if (tbFaseDataInicio.Value > tbFaseDataTermino.Value && chkFaseConcluida.Checked)
        //        Msg += Environment.NewLine + "A Data de Início não pode ser maior do que a Data de Término.";

        //    if (tbFaseDataInicio.Value < obraEtapaSelecionada.dataInicio)
        //        Msg += Environment.NewLine + "A Data de Início da Fase não pode ser anterior ao Início da Obra.";

        //    if (tbFaseDataPrevTermino.Value > obraEtapaSelecionada.dataTermino)
        //        Msg += Environment.NewLine + "A Data de Término da Fase não pode ser posterior ao Término da Obra.";

        //    return Msg;
        //}

        //private void gvFases_Click(object sender, EventArgs e)
        //{
        //    int linhaGrid = 0;

        //    btFaseAdd.Text = "ATUALIZAR";

        //    linhaGrid = gvFases.SelectedCells[0].RowIndex;
            
        //    ObraEtapaFase itemSelecionado = new ObraEtapaFase()
        //    {
        //        id = int.Parse(gvFases[0, linhaGrid].Value.ToString()),
        //        idFase = int.Parse(gvFases[1, linhaGrid].Value.ToString()),
        //        Descricao = gvFases[2, linhaGrid].Value.ToString(),
        //        dataInicio = DateTime.Parse(gvFases[3, linhaGrid].Value.ToString()),
        //        dataPrevTermino = DateTime.Parse(gvFases[4, linhaGrid].Value.ToString()),
        //        dataTermino = gvFases[5, linhaGrid].Value == null ? DateTime.MinValue : DateTime.Parse(gvFases[5, linhaGrid].Value.ToString()),
        //    };

        //    lbLinhaGrid.Text = itemSelecionado.id.ToString();
        //    cbFases.Text = itemSelecionado.Descricao;
        //    tbFaseDataInicio.Value = itemSelecionado.dataInicio.Date;
        //    tbFaseDataPrevTermino.Value = itemSelecionado.dataPrevTermino.Date;
        //    chkFaseConcluida.Checked = itemSelecionado.dataTermino != DateTime.MinValue;
        //    tbFaseDataTermino.Value = itemSelecionado.dataTermino == DateTime.MinValue ? DateTime.Today : itemSelecionado.dataTermino.Date;
        //}

        //private void btFaseRemover_Click(object sender, EventArgs e)
        //{
        //    int linhaGrid = 0;

        //    if (gvFases.RowCount == 0)
        //        return;

        //    linhaGrid = gvFases.SelectedCells[0].RowIndex;

        //    ObraEtapaFase itemSelecionado = new ObraEtapaFase()
        //    {
        //        idFase = int.Parse(gvFases[1, linhaGrid].Value.ToString()),
        //        Descricao = gvFases[2, linhaGrid].Value.ToString(),
        //        dataInicio = DateTime.Parse(gvFases[3, linhaGrid].Value.ToString())
        //    };

        //    obraEtapaSelecionada.lstFases.RemoveAll(item =>
        //        item.idFase == itemSelecionado.idFase &&
        //        item.Descricao == itemSelecionado.Descricao &&
        //        item.dataInicio == itemSelecionado.dataInicio);

        //    this.CarregarFases(obraEtapaSelecionada.lstFases);

        //    btFaseAdd.Text = "Adicionar";
        //    lbLinhaGrid.Text = string.Empty;
        //}

        //private void gvFases_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    // Data Prevista de Término e Fase não concluída
        //    if (DateTime.Parse(gvFases.Rows[e.RowIndex].Cells[4].Value.ToString()) < DateTime.Today && gvFases.Rows[e.RowIndex].Cells[5].Value == null)
        //    {
        //        gvFases.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
        //        gvFases.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
        //    }
        //}

        //private void btFUAdd_Click(object sender, EventArgs e)
        //{
        //    if (btFUAdd.Text == "Adicionar")
        //    {
        //        if (tbFUDescricao.Text.Trim() != string.Empty)
        //        {
        //            obraEtapaSelecionada.lstFollowUps.Add(new ObraEtapaFollowUp()
        //            {
        //                idObraEtapa = obraEtapaSelecionada.idObraEtapa,
        //                idUsuario = UsuarioLogado.idUsuario,
        //                nomeUsuario = UsuarioLogado.Nome,
        //                Descricao = tbFUDescricao.Text,
        //                Data = new DateTime(tbFUData.Value.Date.Year,tbFUData.Value.Date.Month,tbFUData.Value.Date.Day ,tbFUHora.Value.Hour,tbFUHora.Value.Minute,tbFUHora.Value.Second) 
        //            });

        //            this.CarregarFollowUps(obraEtapaSelecionada.lstFollowUps);
        //        }
        //        else
        //            MessageBox.Show("Favor informar a Descrição", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    else
        //    {
        //        tbFUData.Enabled = true;
        //        tbFUHora.Enabled = true;
        //        tbFUDescricao.Enabled = true;
        //        btFUAdd.Text = "Adicionar";
        //    }
            
        //    tbFUData.Value = DateTime.Today;
        //    tbFUHora.Value = DateTime.Now;
        //    tbFUDescricao.Text = string.Empty;
        //    tbFUUsuario.Text = UsuarioLogado.Nome;
        //}

        //private void gvFollowUp_Click(object sender, EventArgs e)
        //{
        //    DateTime dataFU = new DateTime();
        //    int linhaGrid = 0;

        //    btFUAdd.Text = "Novo";

        //    linhaGrid = gvFollowUp.SelectedCells[0].RowIndex;

        //    dataFU = DateTime.Parse(gvFollowUp[0, linhaGrid].Value.ToString());

        //    tbFUData.Value = dataFU.Date;
        //    tbFUData.Enabled = false;

        //    tbFUHora.Value = dataFU;
        //    tbFUHora.Enabled = false;
            
        //    tbFUDescricao.Text = gvFollowUp[1, linhaGrid].Value.ToString();
        //    tbFUDescricao.Enabled = false;
        //    tbFUUsuario.Text = gvFollowUp[2, linhaGrid].Value.ToString();
        //}

        //private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        SendKeys.Send("{tab}");
        //    }
        //}

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
        //    CarregarGridEtapas();                                   
        //}

        //private void btPlanejamentoVisualizar_Click(object sender, EventArgs e)
        //{
        //    ObraEtapa etapa = new ObraEtapa();
        //    int linhaGrid = 0;
        //    int idEtapaSelecionada = 0;

        //    if (gvPlanejamento.RowCount == 0)
        //        return;

        //    linhaGrid = gvPlanejamento.SelectedCells[0].RowIndex;
        //    idEtapaSelecionada = int.Parse(gvPlanejamento[0, linhaGrid].Value.ToString());

        //    etapa = obraSelecionada.lstEtapas.Where(x => x.idObraEtapa == idEtapaSelecionada).First();

        //    ObraPlanejamentoManutencao form = new ObraPlanejamentoManutencao(etapa);
        //    form.ShowDialog();

        //    obraSelecionada.lstEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObra = obraSelecionada.idObra });

        //    CarregarGridEtapas();    
        //}

        //private void gvPlanejamento_SelectionChanged(object sender, EventArgs e)
        //{
        //    int idEtapa = 0;

        //    if (gvPlanejamento.SelectedRows == null || gvPlanejamento.SelectedRows.Count == 0)
        //        return;

        //    idEtapa = (int)gvPlanejamento.SelectedRows[0].Cells[0].Value;

        //    obraEtapaSelecionada = obraSelecionada.lstEtapas.Where(x => x.idObraEtapa == idEtapa).FirstOrDefault();

        //    CarregarComparativoObra(obraEtapaSelecionada);
        //}

        //private void btGravarObra_Click(object sender, EventArgs e)
        //{
        //    string msgRetorno = string.Empty;
        //    string acaoSelecionada = string.Empty;
        //    int idObra = 0;
        //    int idEmpresa = 0;
        //    int idCliente = 0;

        //    if (cbEmpresa.SelectedIndex > 0 && cbEmpresa.FindStringExact(cbEmpresa.Text) != -1)
        //        idEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());

        //    if (cbClientes.SelectedIndex > 0 && cbClientes.FindStringExact(cbClientes.Text) != -1)
        //        idCliente = int.Parse(cbClientes.SelectedValue.ToString());

        //    obraSelecionada.idEmpresa = idEmpresa;
        //    obraSelecionada.numeroLicitacao = tbNumeroLicitacao.Text;
        //    obraSelecionada.idCliente = idCliente;            
        //    obraSelecionada.nomeEvento = tbNomeEvento.Text;
        //    obraSelecionada.valorBruto = decimal.Parse(tbValorBruto.Text);
            
        //    obraSelecionada.Finalizada = chkFinalizada.Checked ? 1 : 0;

        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        if (obraSelecionada.idObra == 0)
        //        {
        //            msgRetorno = bizObra.IncluirObra(obraSelecionada, out idObra);
        //            acaoSelecionada = "Inclusão";
        //            obraSelecionada.idObra = idObra;
        //        }
        //        else
        //        {
        //            msgRetorno = bizObra.AlterarObra(obraSelecionada);
        //            acaoSelecionada = "Alteração";
        //        }

        //        if (msgRetorno == string.Empty)
        //        {
        //            listaGastosAlterada = false;
        //            obraOriginal = obraSelecionada;
        //            helperUI.AlterarTituloAbaAtual("Gerenciamento de Obras:: " + cbClientes.Text + " - " + obraSelecionada.nomeEvento);

        //            //expPlanejamentoObra.Enabled = true;
                 
        //            MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //            MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    this.Cursor = Cursors.Default;
        //}
    }
}
