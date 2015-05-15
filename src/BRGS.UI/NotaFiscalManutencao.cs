using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.Util;
using BRGS.Entity;
using BRGS.BIZ;
using System.Data.SqlClient;
using BRGS.UI.Relatorios;
using CrystalDecisions.CrystalReports.Engine;

namespace BRGS.UI
{
    public partial class NotaFiscalManutencao : Form
    {
        private List<Empresa> lstEmpresas = new List<Empresa>();
        private BIZEmpresa bizEmpresa = new BIZEmpresa();
        private List<Cliente> lstClientes = new List<Cliente>();
        private BIZCliente bizCliente = new BIZCliente();
        private List<NotaFiscalItem> lstNFSItens = new List<NotaFiscalItem>();
        private BIZNotaFiscal bizNotaFiscal = new BIZNotaFiscal();
        private NotaFiscal notaFiscalSelecionada = new NotaFiscal();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        //private bool origemObra = false;
        private BIZObra bizObra = new BIZObra();

        public NotaFiscalManutencao(NotaFiscal _notaFiscalSelecionada) //, bool _origemObra)
        {
            InitializeComponent();
            notaFiscalSelecionada = _notaFiscalSelecionada;
            //origemObra = _origemObra;
        }

        private void CarregarComboTipoOperacao()
        {
            List<NotaFiscalOperacao> lstOperNF = new List<NotaFiscalOperacao>();

            lstOperNF.Add(new NotaFiscalOperacao() { idTipoOperacao = 0, Descricao = "--Selecione--" });
            lstOperNF.Add(new NotaFiscalOperacao() { idTipoOperacao = 1, Descricao = "Entrada" });
            lstOperNF.Add(new NotaFiscalOperacao() { idTipoOperacao = 2, Descricao = "Saída" });
            
            cbTipoOperacao.DataSource = lstOperNF;
            cbTipoOperacao.DisplayMember = "Descricao";
            cbTipoOperacao.ValueMember = "idTipoOperacao";
            cbTipoOperacao.SelectedIndex = 0;
        }

        private void CarregarComboTipoNota()
        {
            List<NotaFiscalTipo> lstTipoNF = new List<NotaFiscalTipo>();

            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 0, Descricao = "--Selecione--" });
            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 1, Descricao = "Locação" });
            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 2, Descricao = "Serviço" });
            lstTipoNF.Add(new NotaFiscalTipo() { idTipoNota = 3, Descricao = "Venda" });

            cbTipoNota.DataSource = lstTipoNF;
            cbTipoNota.DisplayMember = "Descricao";
            cbTipoNota.ValueMember = "idTipoNota";
            cbTipoNota.SelectedIndex = 0;
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

        private void LimparCampos()
        {
            lbCodigo.Text = "0";
            tbNumeroNota.Enabled = true;
            tbNumeroNota.Text = string.Empty;
            cbEmpresa_RazaoSocial.Enabled = true;
            cbEmpresa_RazaoSocial.SelectedIndex = 0;
            VerificarSelecaoComboEmpresa();
            dtpDataEmissao.Value = DateTime.Now;
            tbContrato.Text = string.Empty;
            cbPrazoPagamento.SelectedIndex = 0;
            cbCliente_Nome.SelectedIndex = 0;
            tbCliente_Endereco.Text = string.Empty;            
            tbCliente_Bairro.Text = string.Empty;
            tbCliente_Municipio.Text = string.Empty;
            cbCliente_UF.Text = string.Empty;
            tbCliente_CNPJ.Text = string.Empty;
            tbCliente_ICM.Text = string.Empty;
            tbCliente_InscricaoEstadual.Text = string.Empty;
            tbDescricaoServico.Text = string.Empty;
            tbProcesso.Text = string.Empty;
            tbEmpenho.Text = string.Empty;

            lstNFSItens = new List<NotaFiscalItem>();
            LimparCamposItens();
            LimparGridItens();

            cbPagamentoEfetuado.Checked = false;
            dtpDataPagamento.Value = DateTime.Now;
            tbValorPago.Text = "0,00";
            cbDataAtes.Checked = false;
            dtpDataAtes.Value = DateTime.Now;
            cbDataCAT.Checked = false;
            dtpDataCat.Value = DateTime.Now;
            cbCancelado.Checked = false;
            tbObservacaoCancelado.Text = string.Empty;

            tbIRPJ.Text = "0,00";
            tbCSLL.Text = "0,00";
            tbINSS.Text = "0,00";
            tbPIS.Text = "0,00";
            tbCOFINS.Text = "0,00";
            tbISSQN.Text = "0,00";            
        }

        private void CarregarNotaFiscal()
        {
            this.Cursor = Cursors.WaitCursor;

            try 
            {             
                notaFiscalSelecionada = bizNotaFiscal.PesquisarNotaFiscal(new NotaFiscal() { idNota = notaFiscalSelecionada.idNota })[0];
             
                lbCodigo.Text = notaFiscalSelecionada.idNota.ToString();
                tbNumeroNota.Enabled = notaFiscalSelecionada.numeroNota == 0 ? true : false;
                tbNumeroNota.Text = notaFiscalSelecionada.numeroNota.ToString();
                cbTipoNota.SelectedValue = notaFiscalSelecionada.tipoNota;
                tbCodigoVerificacao.Text = notaFiscalSelecionada.codigoVerificacao;
                tbContrato.Text = notaFiscalSelecionada.Contrato;
                tbValorTotal.Text = helper.FormatarValorMoeda(notaFiscalSelecionada.valorNota.ToString());
                cbTipoOperacao.SelectedValue = notaFiscalSelecionada.tipoOperacao;
                cbPrazoPagamento.SelectedValue = notaFiscalSelecionada.idPrazoPagamento;
                cbEmpresa_RazaoSocial.Enabled = false;
                cbEmpresa_RazaoSocial.Text = notaFiscalSelecionada.nomeEmpresa;
                cbObra.SelectedValue = notaFiscalSelecionada.idObraEtapa;
                VerificarSelecaoComboEmpresa();
                dtpDataEmissao.Value = notaFiscalSelecionada.dataEmissao;
                cbCliente_Nome.SelectedValue = notaFiscalSelecionada.idCliente;                
                tbDescricaoServico.Text = notaFiscalSelecionada.descricaoServico;
                tbProcesso.Text = notaFiscalSelecionada.numeroProcesso;
                tbEmpenho.Text = notaFiscalSelecionada.Empenho;

                lstNFSItens = notaFiscalSelecionada.lstItens;
                CarregarGridItens();

                cbPagamentoEfetuado.Checked = notaFiscalSelecionada.pagamentoEfetuado == 1 ? true : false;
                dtpDataPagamento.Value = notaFiscalSelecionada.dataPagamento.ToShortDateString() == "1/1/1753" ? DateTimePicker.MinimumDateTime : notaFiscalSelecionada.dataPagamento;
                tbValorPago.Text = notaFiscalSelecionada.valorPago.ToString();
                cbDataAtes.Checked = notaFiscalSelecionada.possuiDataAtes == 1 ? true : false;
                dtpDataAtes.Value = notaFiscalSelecionada.dataAtes;
                cbDataCAT.Checked = notaFiscalSelecionada.possuiDataCAT == 1 ? true : false;
                dtpDataCat.Value = notaFiscalSelecionada.dataCAT;
                cbCancelado.Checked = notaFiscalSelecionada.Cancelado == 1 ? true : false;
                tbObservacaoCancelado.Text = notaFiscalSelecionada.observacaoCancelado;

                tbIRPJ.Text = notaFiscalSelecionada.IRPJ.ToString();
                tbCSLL.Text = notaFiscalSelecionada.CSLL.ToString();
                tbINSS.Text = notaFiscalSelecionada.INSS.ToString();
                tbPIS.Text = notaFiscalSelecionada.PIS.ToString();
                tbCOFINS.Text = notaFiscalSelecionada.COFINS.ToString();
                tbISSQN.Text = notaFiscalSelecionada.ISSQN.ToString();
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

        private void CarregarEstados()
        {
            List<string> lstEstados = new List<string>();
            lstEstados.Add("");
            lstEstados.AddRange(helper.RetornarUF());

            cbCliente_UF.DataSource = lstEstados;
            cbCliente_UF.ValueMember = lstEstados[0];
        }

        private void CarregarComboEmpresas()
        {
            lstEmpresas = new List<Empresa>();
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                lstEmpresas.Add(new Empresa() { idEmpresa = 0, razaoSocial = "--Selecione--" });
                lstEmpresas.AddRange(bizEmpresa.PesquisarEmpresa(new Empresa()).OrderBy(x => x.razaoSocial).ToList());

                cbEmpresa_RazaoSocial.DataSource = lstEmpresas;
                cbEmpresa_RazaoSocial.DisplayMember = "razaoSocial";
                cbEmpresa_RazaoSocial.ValueMember = "idEmpresa";
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
            lstClientes = new List<Cliente>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientes.Add(new Cliente() { idCliente = 0, Nome = "--Selecione--", Status = "Ativo" });
                lstClientes.AddRange(bizCliente.PesquisarCliente(new Cliente()).OrderBy(x => x.Nome).ToList());

                cbCliente_Nome.DataSource = lstClientes.Where(x => x.Status.ToUpper() == "ATIVO").ToList();
                cbCliente_Nome.DisplayMember = "Nome";
                cbCliente_Nome.ValueMember = "idCliente";
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

        private void cbEmpresa_RazaoSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCliente_RazaoSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCliente_Endereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }     

        private void tbCliente_Bairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCliente_Municipio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbCliente_UF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCliente_CNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCliente_ICM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCliente_InscricaoEstadual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbProcesso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
                     

        private void tbItem_Qtd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbItem_Unidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbItem_Descricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbItem_PrecoUnitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbItem_Qtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbItem_Qtd_Leave(object sender, EventArgs e)
        {
            tbItem_Qtd.Text = helper.FormatarValorMoeda(tbItem_Qtd.Text).Replace(",00", string.Empty).Replace(".",string.Empty);
        }

        private void tbItem_PrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbItem_PrecoUnitario_Leave(object sender, EventArgs e)
        {
            tbItem_PrecoUnitario.Text = helper.FormatarValorMoeda(tbItem_PrecoUnitario.Text);
        }

        private void cbEmpresa_RazaoSocial_SelectedValueChanged(object sender, EventArgs e)
        {
            VerificarSelecaoComboEmpresa();  
        }

        private void VerificarSelecaoComboEmpresa()
        {
            List<EmpresaContaBancaria> lstContas = new List<EmpresaContaBancaria>();
            Empresa empresa = new Empresa();
            int idEmp = 0;

            if (cbEmpresa_RazaoSocial.SelectedIndex > 0)
            {
                idEmp = int.Parse(cbEmpresa_RazaoSocial.SelectedValue.ToString());                
                
                empresa = lstEmpresas.Where(emp => emp.idEmpresa == idEmp).ToList()[0];
                tbEmpresa_NomeFantasia.Text = empresa.nomeFantasia;
                tbEmpresa_CNPJ.Text = empresa.CNPJ;
                tbEmpresa_ICM.Text = empresa.ICM;
                tmEmpresa_InscricaoEstadual.Text = empresa.inscricaoEstadual;
                CarregarContasBancariasEmpresa(empresa.idEmpresa);
                cbContaBancaria.SelectedValue = notaFiscalSelecionada.idContaBancariaEmpresa;
            }
            else
            {
                tbEmpresa_NomeFantasia.Text = string.Empty;                
                tbEmpresa_CNPJ.Text = string.Empty;
                tbEmpresa_ICM.Text = string.Empty;
                tmEmpresa_InscricaoEstadual.Text = string.Empty;
                cbContaBancaria.Text = string.Empty;
            }
        }
        
        private void cbEmpresa_RazaoSocial_Leave(object sender, EventArgs e)
        {
            VerificarSelecaoComboEmpresa();
        }

        private void CarregarContasBancariasEmpresa(int idEmp)
        {
            List<EmpresaContaBancaria> lstContas = new List<EmpresaContaBancaria>();

            cbContaBancaria.BindingContext = new BindingContext();
            cbContaBancaria.DataSource = null;
            cbContaBancaria.Text = string.Empty;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstContas.Add(new EmpresaContaBancaria() { idContaBancaria = 0, Banco = "--Selecione--" });
                lstContas.AddRange(bizEmpresa.PesquisarEmpresaContaBancariaCombo(new EmpresaContaBancaria() { idEmpresa = idEmp }));

                cbContaBancaria.DataSource = lstContas;
                cbContaBancaria.DisplayMember = "Banco";
                cbContaBancaria.ValueMember = "idContaBancaria";
                cbContaBancaria.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void VerificarSelecaoComboCliente()
        {
            Cliente cliente = new Cliente();
            int idCliente = 0;

            if (cbCliente_Nome.SelectedIndex > 0)
            {
                idCliente = int.Parse(cbCliente_Nome.SelectedValue.ToString());

                cliente = lstClientes.Where(cli => cli.idCliente == idCliente).ToList()[0];

                tbCliente_Endereco.Text = cliente.Endereco;                
                tbCliente_Bairro.Text = cliente.Bairro;
                tbCliente_Municipio.Text = cliente.Cidade; 
                cbCliente_UF.Text = cliente.Estado;
                tbCliente_CNPJ.Text = cliente.CPF_CNPJ;
                tbCliente_InscricaoEstadual.Text = cliente.IE;
                tbCliente_ICM.Text = cliente.ICM;
            }
            else
            {                
                tbCliente_Endereco.Text = string.Empty;
                tbCliente_Bairro.Text = string.Empty;
                tbCliente_Municipio.Text = string.Empty;
                cbCliente_UF.Text = string.Empty;
                tbCliente_CNPJ.Text = string.Empty;
                tbCliente_InscricaoEstadual.Text = string.Empty;
                tbCliente_ICM.Text = string.Empty;
            }
        }    

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            string Msg = string.Empty;

            Msg = VerificarCamposItens();

            if (Msg == string.Empty)
            {
                NotaFiscalItem nfsItem = new NotaFiscalItem()
                {
                    Quantidade = int.Parse(tbItem_Qtd.Text),
                    Unidade = tbItem_Unidade.Text,
                    Descricao = tbItem_Descricao.Text,
                    precoUnitario = decimal.Parse(tbItem_PrecoUnitario.Text)                     
                };

                lstNFSItens.Add(nfsItem);
                                
                CarregarGridItens();
                LimparCamposItens();
            }
            else
                MessageBox.Show(Msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void LimparCamposItens()
        {
            tbItem_Qtd.Text = string.Empty;
            tbItem_Unidade.Text = string.Empty;
            tbItem_Descricao.Text = string.Empty;
            tbItem_PrecoUnitario.Text = string.Empty;
        }

        private void CarregarGridItens()
        {
            decimal valorTotal = decimal.Zero;
            decimal totalNF = decimal.Zero;

            LimparGridItens();

            foreach (NotaFiscalItem nfsItem in lstNFSItens)
            {
                valorTotal = nfsItem.Quantidade * nfsItem.precoUnitario;
                totalNF += valorTotal;

                gvItens.Rows.Add(new object[] 
                {
                    nfsItem.Quantidade,
                    nfsItem.Unidade,
                    nfsItem.Descricao,
                    helper.FormatarValorMoeda(nfsItem.precoUnitario.ToString()),
                    helper.FormatarValorMoeda(valorTotal.ToString())
                });
            }

            lbItens_Total.Text = "Total NF: R$ " + helper.FormatarValorMoeda(totalNF.ToString());
        }

        private void LimparGridItens()
        {
            while (gvItens.Rows.Count > 0)
                gvItens.Rows.RemoveAt(0);
        }

        private string VerificarCamposItens()
        {
            string Msg = string.Empty;

            if (tbItem_Qtd.Text == string.Empty || tbItem_Qtd.Text == "0")            
                Msg += Environment.NewLine + "Favor informar a Quantidade";

            if (tbItem_Unidade.Text == string.Empty)            
                Msg += Environment.NewLine + "Favor informar a Unidade";            

            if (tbItem_Descricao.Text == string.Empty)            
                Msg += Environment.NewLine + "Favor informar a Descrição da Operação";            
            
            if (tbItem_PrecoUnitario.Text == string.Empty || tbItem_PrecoUnitario.Text == "0,00")            
                Msg += Environment.NewLine + "Favor informar o Preço Unitário";

            if (lstNFSItens.Exists(item => item.Descricao == tbItem_Descricao.Text))
                Msg += Environment.NewLine + "Esse item já foi adicionado";

            return Msg;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;
           
            if (gvItens.RowCount == 0)
                return;

            linhaGrid = gvItens.SelectedCells[0].RowIndex;

            NotaFiscalItem itemSelecionado = new NotaFiscalItem()
            {
                Quantidade = int.Parse(gvItens[0, linhaGrid].Value.ToString()),
                Unidade = gvItens[1, linhaGrid].Value.ToString(),
                Descricao = gvItens[2, linhaGrid].Value.ToString(),
                precoUnitario = decimal.Parse(gvItens[3, linhaGrid].Value.ToString())
            };

            lstNFSItens.RemoveAll(item =>
                item.Quantidade == itemSelecionado.Quantidade &&
                item.Unidade == itemSelecionado.Unidade &&
                item.Descricao == itemSelecionado.Descricao &&
                item.precoUnitario == itemSelecionado.precoUnitario); 
    
                CarregarGridItens();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idNota = 0;

            this.Cursor = Cursors.WaitCursor;
            
            try
            {
                NotaFiscal nfServico = PopularEntidadeNF();

                if (nfServico.idNota == 0)
                {
                    msgRetorno = bizNotaFiscal.IncluirNotaFiscal(nfServico, out idNota);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idNota.ToString();                    
                }
                else
                {
                    msgRetorno = bizNotaFiscal.AlterarNotaFiscal(nfServico);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    CarregarGridItens();
                    tbNumeroNota.Enabled = false;
                    if (nfServico.tipoNota == 1)
                    {
                        if (MessageBox.Show(acaoSelecionada + " efetuada com sucesso. Deseja emitir esta Nota Fiscal de Serviço agora?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                            EmitirNFS();
                    }
                    else
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

            tabControl1.SelectTab(0);

            this.Cursor = Cursors.Default;
        }

        private void EmitirNFS()
        {
            ReportClass nfs = new ReportClass();
            DataTable dtNFS = new DataTable();
            string tituloAba = string.Empty;
            Image logotipo = null;
                        
            dtNFS = bizNotaFiscal.GerarNotaFiscal(int.Parse(lbCodigo.Text));

            switch (cbEmpresa_RazaoSocial.Text)
            {
                case "FRONT ESTRUTURAS LTDA - EPP":
                    tituloAba = "Nota Fiscal de Serviço - FRONTT";
                    logotipo = Properties.Resources.Logo_FRONT;
                    break;
                case "BRGS BRASIL LTDA - EPP":
                    tituloAba = "Nota Fiscal de Serviço - BRGS";
                    logotipo = Properties.Resources.Logo_BRGS;
                    break;
                case "LOGOS DO BRASIL LTDA - EPP":
                    tituloAba = "Nota Fiscal de Serviço - LOGOS";
                    logotipo = Properties.Resources.Logo_LOGOS;
                    break;
                case "BRG SERVICOS LTDA - EPP":
                    tituloAba = "Nota Fiscal de Serviço - BRG";
                    logotipo = Properties.Resources.Logo_BRG;
                    break;
                default:
                    MessageBox.Show("Favor selecionar uma empresa válida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }

            dtNFS = helper.AdicionarLogotipoDataTable(dtNFS, logotipo);
            nfs = new NotaFiscalEmissao();
            nfs.SetDataSource(dtNFS);
            Relatorio relat = new Relatorio(nfs);
            relat.Text = tituloAba;
            relat.ShowDialog();          
        }

        private NotaFiscal PopularEntidadeNF()
        {
            int numeroNota = 0;

            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.idNota = int.Parse(lbCodigo.Text);
            notaFiscal.numeroNota = int.TryParse(tbNumeroNota.Text, out numeroNota) ? numeroNota : 0;
            notaFiscal.tipoNota = int.Parse(cbTipoNota.SelectedValue.ToString());
            notaFiscal.codigoVerificacao = tbCodigoVerificacao.Text;
            notaFiscal.Contrato = tbContrato.Text;
            
            if(notaFiscal.tipoNota == 1)
                notaFiscal.valorNota = decimal.Parse(lbItens_Total.Text.Replace("Total NF: R$ ", string.Empty).Trim());
            else
                notaFiscal.valorNota = decimal.Parse(tbValorTotal.Text);
           
            notaFiscal.tipoOperacao = int.Parse(cbTipoOperacao.SelectedValue.ToString());
            notaFiscal.idEmpresa = cbEmpresa_RazaoSocial.FindStringExact(cbEmpresa_RazaoSocial.Text) != -1 ? int.Parse(cbEmpresa_RazaoSocial.SelectedValue.ToString()) : -1;
            notaFiscal.idContaBancariaEmpresa = cbContaBancaria.FindStringExact(cbContaBancaria.Text) != -1 ? int.Parse(cbContaBancaria.SelectedValue.ToString()) : 0;
            notaFiscal.idPrazoPagamento = cbPrazoPagamento.FindStringExact(cbPrazoPagamento.Text) != -1 ? int.Parse(cbPrazoPagamento.SelectedValue.ToString()) : 0;
            notaFiscal.dataEmissao = dtpDataEmissao.Value.Date;
            notaFiscal.idObraEtapa = cbObra.FindStringExact(cbObra.Text) != -1 ? int.Parse(cbObra.SelectedValue.ToString()) : -1;
            notaFiscal.idCliente = cbCliente_Nome.FindStringExact(cbCliente_Nome.Text) != -1 ? int.Parse(cbCliente_Nome.SelectedValue.ToString()) : 0;            
            notaFiscal.descricaoServico = tbDescricaoServico.Text;
            notaFiscal.numeroProcesso = tbProcesso.Text;
            notaFiscal.Empenho = tbEmpenho.Text;

            if (cbCancelado.Checked)
                notaFiscal.pagamentoEfetuado = 0;
            else
                notaFiscal.pagamentoEfetuado = cbPagamentoEfetuado.Checked ? 1 : 0;

            notaFiscal.dataPagamento = cbPagamentoEfetuado.Checked ? dtpDataPagamento.Value.Date : DateTimePicker.MinimumDateTime;
            notaFiscal.valorPago = cbCancelado.Checked ? decimal.Zero : decimal.Parse(tbValorPago.Text);
            notaFiscal.possuiDataAtes = cbDataAtes.Checked ? 1 : 0;
            notaFiscal.dataAtes = cbDataAtes.Checked ? dtpDataAtes.Value.Date : DateTimePicker.MinimumDateTime;
            notaFiscal.possuiDataCAT = cbDataCAT.Checked ? 1 : 0;
            notaFiscal.dataCAT = cbDataCAT.Checked ? dtpDataCat.Value.Date : DateTimePicker.MinimumDateTime;
            notaFiscal.Cancelado = cbCancelado.Checked ? 1 : 0;
            notaFiscal.observacaoCancelado = tbObservacaoCancelado.Text;

            notaFiscal.IRPJ = decimal.Parse(tbIRPJ.Text);
            notaFiscal.CSLL = decimal.Parse(tbCSLL.Text);
            notaFiscal.INSS = decimal.Parse(tbINSS.Text);
            notaFiscal.PIS = decimal.Parse(tbPIS.Text);
            notaFiscal.COFINS = decimal.Parse(tbCOFINS.Text);
            notaFiscal.ISSQN = decimal.Parse(tbISSQN.Text);

            if (notaFiscal.tipoNota > 1)
            {
                notaFiscal.lstItens = new List<NotaFiscalItem>();
                lstNFSItens = new List<NotaFiscalItem>();
            }
            else
                notaFiscal.lstItens = lstNFSItens;            

            return notaFiscal;
        }

        private void tbValorPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorPago_Leave(object sender, EventArgs e)
        {
            tbValorPago.Text = helper.FormatarValorMoeda(tbValorPago.Text);
        }

        private void cbPagamentoEfetuado_CheckedChanged(object sender, EventArgs e)
        {            
            if (cbPagamentoEfetuado.Checked)
            {
                dtpDataPagamento.Enabled = true;
                dtpDataPagamento.Value = DateTime.Now; 
                tbValorPago.Enabled = true;
            }
            else
            {
                dtpDataPagamento.Enabled = false;
                dtpDataPagamento.Value = DateTime.Parse("1/1/1753");
                tbValorPago.Enabled = false;
            }
        }

        private void cbDataAtes_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDataAtes.Checked)
            {
                dtpDataAtes.Enabled = true;
                dtpDataAtes.Value = DateTime.Now;
            }
            else
            {
                dtpDataAtes.Enabled = false;
                dtpDataAtes.Value = DateTime.Parse("1/1/1753");
            }
        }

        private void cbDataCAT_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDataCAT.Checked)
            {
                dtpDataCat.Enabled = true;
                dtpDataCat.Value = DateTime.Now;
            }
            else
            {
                dtpDataCat.Enabled = false;
                dtpDataCat.Value = DateTime.Parse("1/1/1753");
            }
        }

        private void cbCancelado_CheckedChanged(object sender, EventArgs e)
        {
            tbObservacaoCancelado.Enabled = cbCancelado.Checked;
        }

        private void tbNumeroNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbNumeroNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbNumeroNota_Leave(object sender, EventArgs e)
        {
            tbNumeroNota.Text = helper.FormatarValorMoeda(tbNumeroNota.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void cbCliente_Nome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbCliente_Nome_Leave(object sender, EventArgs e)
        {
            VerificarSelecaoComboCliente();
        }

        private void cbCliente_Nome_SelectedValueChanged(object sender, EventArgs e)
        {
            VerificarSelecaoComboCliente();
        }

        private void tbEmpenho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDescricaoEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbIRPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCSLL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbINSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCOFINS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbISSQN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbIRPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbCSLL_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbINSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbPIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbCOFINS_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbISSQN_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbIRPJ_Leave(object sender, EventArgs e)
        {
            tbIRPJ.Text = helper.FormatarValorMoeda(tbIRPJ.Text);
        }

        private void tbCSLL_Leave(object sender, EventArgs e)
        {
            tbCSLL.Text = helper.FormatarValorMoeda(tbCSLL.Text);
        }

        private void tbINSS_Leave(object sender, EventArgs e)
        {
            tbINSS.Text = helper.FormatarValorMoeda(tbINSS.Text);
        }

        private void tbPIS_Leave(object sender, EventArgs e)
        {
            tbPIS.Text = helper.FormatarValorMoeda(tbPIS.Text);
        }

        private void tbCOFINS_Leave(object sender, EventArgs e)
        {
            tbCOFINS.Text = helper.FormatarValorMoeda(tbCOFINS.Text);
        }

        private void tbISSQN_Leave(object sender, EventArgs e)
        {
            tbISSQN.Text = helper.FormatarValorMoeda(tbISSQN.Text);
        }

        private void NotaFiscalServicoManutencao_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                CarregarComboEmpresas();
                CarregarComboClientes();
                CarregarEstados();
                CarregarComboTipoNota();
                CarregarComboTipoOperacao();
                CarregarComboObras();
                CarregarComboPrazoPagamento();

                if (notaFiscalSelecionada.idNota == 0)
                    LimparCampos();
                else
                    CarregarNotaFiscal();
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

            this.Cursor = Cursors.Default;
        }

        private void CarregarComboPrazoPagamento()
        {
            List<NotaFiscalPrazoPagamento> lstPrazos = new List<NotaFiscalPrazoPagamento>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstPrazos.Add(new NotaFiscalPrazoPagamento() { idPrazoPagamento = 0, Descricao= "--Selecione--" });
                lstPrazos.AddRange(bizNotaFiscal.PesqisarPrazoPagamento().OrderBy(x => x.Descricao).ToList());

                cbPrazoPagamento.DataSource = lstPrazos;
                cbPrazoPagamento.DisplayMember = "Descricao";
                cbPrazoPagamento.ValueMember = "idPrazoPagamento";
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

        private void tbCodigoVerificacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
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
        }

        private void cbTipoNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbTipoNota_SelectedValueChanged(object sender, EventArgs e)
        {
            Control abaItens = tabControl1.TabPages[1];

            switch (cbTipoNota.SelectedValue.ToString())
            {     
                case "2": // Serviço
                    tbCodigoVerificacao.Enabled = true;
                    tbContrato.Enabled = true;
                    tbValorTotal.Enabled = true;
                    cbTipoOperacao.Enabled = false;                    
                    abaItens.Enabled = false;
                    break;
                case "3": // Venda
                    tbCodigoVerificacao.Enabled = false;
                    tbContrato.Enabled = false;
                    tbValorTotal.Enabled = true;
                    cbTipoOperacao.Enabled = true;                    
                    abaItens.Enabled = false;
                    break;
                default:
                    tbCodigoVerificacao.Enabled = false;
                    tbContrato.Enabled = true;
                    tbValorTotal.Enabled = false;
                    cbTipoOperacao.Enabled = false;                
                    abaItens.Enabled = true;                    
                    break;
            }
        }

        private void cbTipoOperacao_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
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
            ObraEtapa obra = new ObraEtapa();

            if (cbObra.SelectedIndex != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    obra = bizObra.PesquisarObraEtapa(new ObraEtapa() { idObraEtapa = int.Parse(cbObra.SelectedValue.ToString()) })[0];
                    tbLicitacao.Text = obra.numeroLicitacao;
                    tbDescricaoServico.Text = obra.nomeEvento;
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
                tbLicitacao.Text = string.Empty;
                tbDescricaoServico.Text = string.Empty;
            }
        }

        private void tbContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbPrazoPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
