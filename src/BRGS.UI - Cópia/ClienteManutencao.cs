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
    public partial class ClienteManutencao : Form
    {
        private BIZCliente bizCliente = new BIZCliente();
        private BIZObra bizObra = new BIZObra();
        private Cliente clienteSelecionado = new Cliente();
        private Cliente clienteOriginal = new Cliente();
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private BIZLogErro bizLogErro = new BIZLogErro();
        
        public ClienteManutencao(Cliente _clienteSelecionado )
        {
            InitializeComponent();
            clienteOriginal = _clienteSelecionado;          
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

        private void CarregarComboAtividades()
        {
            BIZAtividade bizAtividade = new BIZAtividade();
            List<Atividade> lstAtividades = new List<Atividade>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstAtividades.Add(new Atividade() { idAtividade = 0, Descricao = "--Selecione--" });
                lstAtividades.AddRange(bizAtividade.PesquisarAtividade(new Atividade()).OrderBy(x => x.Descricao).ToList());

                cbAtividade.DataSource = lstAtividades;
                cbAtividade.DisplayMember = "Descricao";
                cbAtividade.ValueMember = "idAtividade";
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

        private void CarregarComboCategorias()
        {
            BIZCategoria bizCategoria = new BIZCategoria();
            List<Categoria> lstCategorias = new List<Categoria>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCategorias.Add(new Categoria() { idCategoria = 0, Descricao = "--Selecione--" });
                lstCategorias.AddRange(bizCategoria.PesquisarCategoria(new Categoria()).OrderBy(x => x.Descricao).ToList());

                cbCategoria.DataSource = lstCategorias;
                cbCategoria.DisplayMember = "Descricao";
                cbCategoria.ValueMember = "idCategoria";
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
            tbNome.Text = string.Empty;
            tbCPFCNPJ.Text = string.Empty;
            tbIE.Text = string.Empty;
            tbICM.Text = string.Empty;
            tbEndereco.Text = string.Empty;
            tbComplemento.Text = string.Empty;
            tbBairro.Text = string.Empty;
            tbCidade.Text   = string.Empty;
            cbEstado.SelectedIndex = 0;
            tbCEP.Text = string.Empty;
            tbPais.Text = string.Empty;
            tbTelefone.Text = string.Empty;
            tbFax.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbSite.Text = string.Empty;
            tbObservacao.Text = string.Empty;
            cbStatus.SelectedIndex = 0;
            clienteSelecionado.lstContatos = new List<ClienteContato>();
            clienteSelecionado.lstContasBancarias = new List<ClienteContaBancaria>();
        }

        private void CarregarCliente(int idClienteSelecionado)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                clienteOriginal = bizCliente.PesquisarCliente(new Cliente() { idCliente = idClienteSelecionado })[0];
                clienteOriginal.lstContatos = bizCliente.PesquisarClienteContato(new ClienteContato() { idCliente = idClienteSelecionado });
                clienteOriginal.lstContasBancarias = bizCliente.PesquisarClienteContaBancaria(new ClienteContaBancaria() { idCliente = idClienteSelecionado });
                clienteSelecionado = (Cliente)clienteOriginal.Clone();                

                lbCodigo.Text = clienteSelecionado.idCliente.ToString();
                tbCodigo.Text = clienteSelecionado.Codigo;
                tbNome.Text = clienteSelecionado.Nome;
                tbCPFCNPJ.Text = clienteSelecionado.CPF_CNPJ;
                tbIE.Text = clienteSelecionado.IE;
                tbICM.Text = clienteSelecionado.ICM;
                cbCategoria.SelectedValue = clienteSelecionado.idCategoria;
                cbAtividade.SelectedValue = clienteSelecionado.idAtividade;
                tbEndereco.Text = clienteSelecionado.Endereco;
                tbComplemento.Text = clienteSelecionado.Complemento;
                tbBairro.Text = clienteSelecionado.Bairro;
                tbCidade.Text = clienteSelecionado.Cidade;
                cbEstado.Text = clienteSelecionado.Estado;
                tbCEP.Text = clienteSelecionado.CEP;
                tbPais.Text = clienteSelecionado.Pais;
                tbTelefone.Text = clienteSelecionado.Telefone;
                tbFax.Text = clienteSelecionado.Fax;
                tbEmail.Text = clienteSelecionado.Email;
                tbSite.Text = clienteSelecionado.Site;                
                tbObservacao.Text = clienteSelecionado.Observacao;
                cbStatus.Text = clienteSelecionado.Status;
                this.CarregarContatos();
                this.CarregarContasBancarias();
                this.CarregarObras();                               
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
            List<ObraEtapa> lstObras = new List<ObraEtapa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstObras = bizObra.PesquisarObraEtapa(new ObraEtapa() { idCliente = int.Parse(lbCodigo.Text)}).OrderBy(obr => obr.nomeEvento).ToList();

                LimparGrid();

                foreach (ObraEtapa itemObra in lstObras)
                {
                    gvObras.Rows.Add(new object[] 
                    {
                        itemObra.idObraEtapa, 
                        itemObra.nomeEmpresa,
                        itemObra.numeroLicitacao,                         
                        itemObra.nomeEvento,
                        helper.FormatarValorMoeda(itemObra.valorContrato.ToString()) 
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
            while (gvObras.Rows.Count > 0)
                gvObras.Rows.RemoveAt(0);
        }

        private void CarregarEstados()
        {
            List<string> lstEstados = new List<string>();
            lstEstados.Add("");
            lstEstados.AddRange(helper.RetornarUF());

            cbEstado.DataSource = lstEstados;
            cbEstado.ValueMember = lstEstados[0];
        }

        private void CarregarStatus()
        {
            List<string> lstStatus = new List<string>();            
            lstStatus.Add("ATIVO");
            lstStatus.Add("INATIVO");
            
            cbStatus.DataSource = lstStatus;            
        }        

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idCliente = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
               this.PopularEntidadeCliente();

                if (lbCodigo.Text == "0")
                {
                    msgRetorno = bizCliente.IncluirCliente(clienteSelecionado, out idCliente);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idCliente.ToString();
                }
                else
                {
                    msgRetorno = bizCliente.AlterarCliente(clienteOriginal, clienteSelecionado);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    btCriarObra.Enabled = true;
                    this.tabControl1.SelectedIndex = 0;
                    clienteOriginal = (Cliente)clienteSelecionado.Clone();
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

        private void PopularEntidadeCliente()
        {
            clienteSelecionado.idCliente = int.Parse(lbCodigo.Text);
            clienteSelecionado.idAtividade = int.Parse(cbAtividade.SelectedValue.ToString());
            clienteSelecionado.idCategoria = int.Parse(cbCategoria.SelectedValue.ToString());
            clienteSelecionado.TipoPessoa = "Z";
            clienteSelecionado.Codigo = tbCodigo.Text;
            clienteSelecionado.Nome = tbNome.Text;                        
            clienteSelecionado.CPF_CNPJ = helper.FormatarCPF_CNPJ(tbCPFCNPJ.Text);
            clienteSelecionado.IE = tbIE.Text;
            clienteSelecionado.ICM = tbICM.Text;
            clienteSelecionado.Endereco = tbEndereco.Text;
            clienteSelecionado.Complemento = tbComplemento.Text;
            clienteSelecionado.Bairro = tbBairro.Text;
            clienteSelecionado.Cidade = tbCidade.Text;
            clienteSelecionado.Estado = cbEstado.FindStringExact(cbEstado.Text) != -1 ? cbEstado.Text : string.Empty;
            clienteSelecionado.CEP = tbCEP.Text;
            clienteSelecionado.Pais = tbPais.Text;
            clienteSelecionado.Telefone = tbTelefone.Text;
            clienteSelecionado.Fax = tbFax.Text;
            clienteSelecionado.Email = tbEmail.Text;
            clienteSelecionado.Site = tbSite.Text;            
            clienteSelecionado.Observacao = tbObservacao.Text;
            clienteSelecionado.Status = cbStatus.FindStringExact(cbStatus.Text) != -1 ? cbStatus.Text : string.Empty;
        }
    
        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCPFCNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbIE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbAtividade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbEndereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbComplemento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbBairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbSite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbICM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }       

        private void tbBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbAgencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbTipoConta_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {               
                SendKeys.Send("{tab}");
            }
        }

        private void tbConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
       
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

        private void tbValorContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorContrato_Leave(object sender, EventArgs e)
        {
            tbValorContrato.Text = helper.FormatarValorMoeda(tbValorContrato.Text);    
        }

        private void btCriarObra_Click(object sender, EventArgs e)
        {
            //string msgRetorno = string.Empty;

            //msgRetorno = ValidarCriarObra();

            //if (msgRetorno == string.Empty)
            //{
            //    ObraEtapa obraCliente = new ObraEtapa();
            //    obraCliente.idCliente = clienteSelecionado.idCliente;
            //    obraCliente.idEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());
            //    obraCliente.numeroLicitacao = tbNumeroLicitacao.Text;
            //    obraCliente.nomeEvento = tbNomeEvento.Text;
            //    obraCliente.valorContrato = decimal.Parse(tbValorContrato.Text);                
            //    obraCliente.lstGastosPrevistos = new List<ObraEtapaGastoPrevisto>();
            //    obraCliente.lstGastosRealizados = new List<ObraEtapaGastoRealizado>();

            //    ObraManutencao formObra = new ObraManutencao(obraCliente);
            //    formObra.ShowDialog();

            //    this.LimparCamposNovaObra();
            //    this.CarregarObras();
            //}
            //else
            //    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void LimparCamposNovaObra()
        {            
            cbEmpresa.SelectedIndex = 0;
            tbNumeroLicitacao.Text = string.Empty;
            tbValorContrato.Text = "0,00";
            tbNomeEvento.Text = string.Empty;
        }

        private string ValidarCriarObra()
        {
            string msgRetorno = string.Empty;

            if (cbEmpresa.SelectedIndex == 0 || cbEmpresa.FindStringExact(cbEmpresa.Text) == -1)
                msgRetorno += Environment.NewLine + "Favor selecionar uma Empresa válida";

            if (tbNumeroLicitacao.Text == string.Empty)
                msgRetorno += Environment.NewLine + "Favor informar o Número da Licitação";
        
            if (tbValorContrato.Text == string.Empty || tbValorContrato.Text == "0,00")
                msgRetorno += Environment.NewLine + "Favor informar o Valor do Contrato";

            if (tbNomeEvento.Text == string.Empty)
                msgRetorno += Environment.NewLine + "Favor informar o Nome do Evento";
            
            return msgRetorno; 
        }

        private void tbNomeEvento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void ClienteManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (clienteOriginal.idCliente == 0)
                    btCriarObra.Enabled = false;

                CarregarEstados();
                CarregarStatus();
                CarregarComboEmpresas();
                CarregarComboAtividades();
                CarregarComboCategorias();

                cbTipoConta.Items.Add("C.CORRENTE");
                cbTipoConta.Items.Add("C.POUPANÇA");

                if (clienteOriginal.idCliente == 0)
                    LimparCampos();
                else
                    CarregarCliente(clienteOriginal.idCliente);

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

        private void tbContatoNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbContatoTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbContatoEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btContatoAdd_Click(object sender, EventArgs e)
        {
            string Msg = string.Empty;

            Msg = this.ValidarAdicionarContato();

            if (Msg == string.Empty)
            {
                clienteSelecionado.lstContatos.Add(new ClienteContato()
                {
                    idCliente = clienteSelecionado.idCliente,
                    Nome = tbContatoNome.Text,
                    Telefone = tbContatoTelefone.Text,
                    Email = tbContatoEmail.Text
                });

                this.CarregarContatos();

                tbContatoNome.Text = string.Empty;
                tbContatoTelefone.Text = string.Empty;
                tbContatoEmail.Text = string.Empty;
            }
            else
                MessageBox.Show("Atenção:" + Msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);     
        }

        private string ValidarAdicionarContato()
        {
            string msgRetorno = string.Empty;

            if(tbContatoNome.Text == string.Empty)
                msgRetorno += Environment.NewLine + "Favor informar o Nome do contato";

            if(tbContatoEmail.Text.Trim() != string.Empty && helper.ValidarEmail(tbContatoEmail.Text) == false)
                msgRetorno += Environment.NewLine + "E-mail do contato inválido";

            if (clienteSelecionado.lstContatos == null)
                clienteSelecionado.lstContatos = new List<ClienteContato>();

            if(clienteSelecionado.lstContatos.Exists(x => x.Nome.ToUpper() == tbContatoNome.Text.ToUpper()))
                 msgRetorno += Environment.NewLine + "Já existe um Contato com esse nome";

            return msgRetorno;
        }

        private void btContatoRemover_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;

            if (gvContatos.RowCount == 0)
                return;

            linhaGrid = gvContatos.SelectedCells[0].RowIndex;

            ClienteContato itemSelecionado = new ClienteContato()
            {
                Nome = gvContatos[0, linhaGrid].Value.ToString()
            };

            clienteSelecionado.lstContatos.RemoveAll(item => item.Nome == itemSelecionado.Nome);

            this.CarregarContatos();
        }

        private void CarregarContatos()
        {
            while (gvContatos.Rows.Count > 0)
                gvContatos.Rows.RemoveAt(0);

            if (clienteSelecionado.lstContatos == null)
                return;

            foreach (ClienteContato itemContato in clienteSelecionado.lstContatos.OrderBy(x => x.Nome).ToList())
            {
                gvContatos.Rows.Add(new object[] 
                {
                    itemContato.Nome,
                    itemContato.Telefone,
                    itemContato.Email
                });
            }
        }

        private void tbCPFCNPJ_Leave(object sender, EventArgs e)
        {
            tbCPFCNPJ.Text = helper.FormatarCPF_CNPJ(tbCPFCNPJ.Text);            
        }        

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string Msg = string.Empty;

            if (clienteSelecionado.idCliente == 0)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Msg = bizCliente.ValidarExclusaoCliente(clienteSelecionado);

                if (Msg == string.Empty)
                {
                    if (MessageBox.Show("Confirma exclusão do cliente?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizCliente.ExcluirCliente(clienteSelecionado);
                    MessageBox.Show("Cliente excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Atenção:" + Msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void cbTipoConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btContaAdd_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            if (tbBanco.Text.Trim() != string.Empty)
            {
                if (clienteSelecionado.lstContasBancarias.Count == 0 || lbIdContaBancaria.Text == string.Empty)
                {
                    clienteSelecionado.lstContasBancarias.Add(new ClienteContaBancaria()
                    {
                        idContaBancaria = 0,
                        idCliente = clienteSelecionado.idCliente,
                        Banco = tbBanco.Text,
                        Agencia = tbAgencia.Text,
                        TipoConta = cbTipoConta.Text,
                        Conta = tbConta.Text
                    });
                }
                else
                {
                    linhaGrid = int.Parse(lbIdContaBancaria.Text);

                    ClienteContaBancaria itemSelecionado = new ClienteContaBancaria()
                    {
                        Banco = gvContasBancarias[1, linhaGrid].Value.ToString(),
                        Agencia = gvContasBancarias[2, linhaGrid].Value.ToString(),
                        TipoConta = gvContasBancarias[3, linhaGrid].Value.ToString(),
                        Conta = gvContasBancarias[4, linhaGrid].Value.ToString(),
                    };

                    ClienteContaBancaria contaAtualizada = clienteSelecionado.lstContasBancarias.Where
                        (item =>
                            item.Banco == itemSelecionado.Banco &&
                            item.Agencia == itemSelecionado.Agencia &&
                            item.TipoConta == itemSelecionado.TipoConta &&
                            item.Conta == itemSelecionado.Conta).First();

                    contaAtualizada.Banco = tbBanco.Text;
                    contaAtualizada.Agencia = tbAgencia.Text;
                    contaAtualizada.TipoConta = cbTipoConta.Text;
                    contaAtualizada.Conta = tbConta.Text;
                }

                this.CarregarContasBancarias();               
            }
            else
                MessageBox.Show("Favor informar o Nome do Banco", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void gvContasBancarias_MouseClick(object sender, MouseEventArgs e)
        {
            int linhaGrid = 0;

            if (gvContasBancarias.Rows.Count == 0)
                return;

            linhaGrid = gvContasBancarias.SelectedCells[0].RowIndex;

            lbIdContaBancaria.Text = linhaGrid.ToString();
            tbBanco.Text = gvContasBancarias[1, linhaGrid].Value.ToString();
            tbAgencia.Text = gvContasBancarias[2, linhaGrid].Value.ToString();
            cbTipoConta.Text = gvContasBancarias[3, linhaGrid].Value.ToString();
            tbConta.Text = gvContasBancarias[4, linhaGrid].Value.ToString();

            btContaAdd.Text = "Atualizar";
        }

        private void btContaNova_Click(object sender, EventArgs e)
        {
            lbIdContaBancaria.Text = string.Empty;
            tbBanco.Text = string.Empty;
            tbAgencia.Text = string.Empty;
            cbTipoConta.Text = string.Empty;
            tbConta.Text = string.Empty;

            btContaAdd.Text = "Adicionar";
        }

        private void btContaRemover_Click(object sender, EventArgs e)
        {            
            int linhaGrid = 0;
            
            if (gvContasBancarias.RowCount == 0)
                return;

            lbIdContaBancaria.Text = string.Empty;

            linhaGrid = gvContasBancarias.SelectedCells[0].RowIndex;

            ClienteContaBancaria itemSelecionado = new ClienteContaBancaria()
            {
                Banco = gvContasBancarias[1, linhaGrid].Value.ToString(),
                Agencia = gvContasBancarias[2, linhaGrid].Value.ToString(),
                TipoConta = gvContasBancarias[3, linhaGrid].Value.ToString(),
                Conta = gvContasBancarias[4, linhaGrid].Value.ToString(),
            };

            clienteSelecionado.lstContasBancarias.Where
                (item =>
                    item.Banco == itemSelecionado.Banco &&
                    item.Agencia == itemSelecionado.Agencia &&
                    item.TipoConta == itemSelecionado.TipoConta &&
                    item.Conta == itemSelecionado.Conta).ToList()[0].Excluir = true;

            tbBanco.Text = string.Empty;
            tbAgencia.Text = string.Empty;
            cbTipoConta.Text = string.Empty;
            tbConta.Text = string.Empty;

            this.CarregarContasBancarias();
        }

        private void CarregarContasBancarias()
        {
            while (gvContasBancarias.Rows.Count > 0)
                gvContasBancarias.Rows.RemoveAt(0);

            foreach (ClienteContaBancaria itemConta in clienteSelecionado.lstContasBancarias.Where(x => x.Excluir == false).OrderBy(x => x.Banco).ToList())
            {
                gvContasBancarias.Rows.Add(new object[] 
                {
                    itemConta.idContaBancaria,
                    itemConta.Banco,
                    itemConta.Agencia,
                    itemConta.TipoConta,
                    itemConta.Conta
                });
            }

            if (gvContasBancarias.Rows.Count > 0)
            {
                gvContasBancarias.Rows[0].Selected = true;
                gvContasBancarias_MouseClick(gvContasBancarias, null);
            }
            else
            {
                tbBanco.Text = string.Empty;
                tbAgencia.Text = string.Empty;
                cbTipoConta.Text = string.Empty;
                tbConta.Text = string.Empty;
            }
        }
    }
}
