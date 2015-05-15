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
    public partial class MultaOcorrenciaGeracaoOP : Form
    {
        private MultaOcorrencia ocorrenciaSelecionada = new MultaOcorrencia();
        private BIZUEN bizUEN = new BIZUEN();
        private List<UEN> lstUEN = new List<UEN>();
        private List<UENCentroCusto> lstCentrosCustos = new List<UENCentroCusto>();
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private List<CentroCustoDespesa> lstDespesas = new List<CentroCustoDespesa>();
        private Helper helper = new Helper();

        public MultaOcorrenciaGeracaoOP(MultaOcorrencia _ocorrenciaSelecionada)
        {
            InitializeComponent();
            ocorrenciaSelecionada = _ocorrenciaSelecionada;
        }

        private void MultaOcorrenciaGeracaoOP_Load(object sender, EventArgs e)
        {
            tbValor.Text =  helper.FormatarValorMoeda(ocorrenciaSelecionada.valorMulta.ToString());
            CarregarCombos();
        }

        private void CarregarCombos()
        {
            this.CarregarListaUEN();
            this.CarregarListaCentroCusto();
            this.CarregarListaDespesas();
            this.CarregarComboUEN();
        }

        private void CarregarListaUEN()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--" });
                lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(x => x.Descricao).ToList());
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

        private void CarregarComboUEN()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
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

        private string ValidarCombos()
        {
            string msgRetorno = string.Empty;

            if (cbUEN.SelectedIndex == 0 || cbUEN.FindStringExact(cbUEN.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma UEN válida";

            if (cbCentroCusto.SelectedIndex == 0 || cbCentroCusto.FindStringExact(cbCentroCusto.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar um Centro de Custo válido";

            if (cbDespesa.SelectedIndex == 0 || cbDespesa.FindStringExact(cbDespesa.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Despesa válida";

            return msgRetorno;
        }

        private void cbUEN_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CarregarComboCentroCusto();
        }

        private void CarregarComboCentroCusto()
        {
            List<UENCentroCusto> lstCCFiltrado = new List<UENCentroCusto>();
            int idUENCombo = 0;

            if (cbUEN.SelectedValue == null || int.TryParse(cbUEN.SelectedValue.ToString(), out idUENCombo) == false)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCCFiltrado.Add(new UENCentroCusto() { idCentroCusto = 0, descricaoCentroCusto = "--Selecione--" });
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
            List<CentroCustoDespesa> lstDespesaFiltrada = new List<CentroCustoDespesa>();
            int idCentroCustoCombo = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                cbDespesa.DataSource = null;
                cbDespesa.Text = string.Empty;

                if (cbCentroCusto.SelectedValue != null && int.TryParse(cbCentroCusto.SelectedValue.ToString(), out idCentroCustoCombo))
                {
                    lstDespesaFiltrada.Add(new CentroCustoDespesa() { idDespesa = 0, descricaoDespesa = "--Selecione--" });
                    lstDespesaFiltrada.AddRange(lstDespesas.Where(x => x.idCentroCusto == idCentroCustoCombo).OrderBy(x => x.descricaoDespesa).ToList());

                    cbDespesa.BindingContext = new BindingContext();
                    cbDespesa.DataSource = lstDespesaFiltrada;
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

        private void btGerarOP_Click(object sender, EventArgs e)
        {
            OrdemPagamento ordemPagamento = new OrdemPagamento();
            string msgRetorno = string.Empty;

            msgRetorno = ValidarCombos();

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
                    idOcorrenciaMulta = ocorrenciaSelecionada.idOcorrencia,
                    idManutencao = 0,
                    idFrete = 0,
                    idObraGastoRealizado = 0,
                    idAbastecimento = 0,
                    idUEN = int.Parse(cbUEN.SelectedValue.ToString()),
                    idCentroCusto = int.Parse(cbCentroCusto.SelectedValue.ToString()),
                    idDespesa = int.Parse(cbDespesa.SelectedValue.ToString()),
                    descricaoUEN = cbUEN.Text,
                    descricaoCentroCusto = cbCentroCusto.Text,
                    descricaoDespesa = cbDespesa.Text,
                    Valor = ocorrenciaSelecionada.valorMulta,
                    dataVencimento = tbData.Value,
                    numeroParcela = 1,
                    totalParcelas = 1
                });

                OrdemPagamentoManutencao form = new OrdemPagamentoManutencao(ordemPagamento, false);
                form.ShowDialog();

                this.Close();
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
