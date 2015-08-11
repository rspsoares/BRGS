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
    public partial class FornecedorManutencao : Form
    {
        private BIZFornecedor bizFornecedor = new BIZFornecedor();
        private Fornecedor fornecedorOriginal = new Fornecedor();
        private Fornecedor fornecedorSelecionado = new Fornecedor();
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public FornecedorManutencao(Fornecedor _fornecedorSelecionado)
        {
            InitializeComponent();
            fornecedorOriginal = _fornecedorSelecionado;
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
            tbCidade.Text = string.Empty;
            cbEstado.SelectedIndex = 0;
            tbCEP.Text = string.Empty;
            tbPais.Text = string.Empty;
            tbTelefone.Text = string.Empty;
            tbFax.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbSite.Text = string.Empty;
            tbObservacao.Text = string.Empty;
            cbStatus.SelectedIndex = 0;
            fornecedorSelecionado.lstContatos = new List<FornecedorContato>();
            fornecedorSelecionado.lstContasBancarias = new List<FornecedorContaBancaria>();
        }

        private void CarregarFornecedor(int idFornecedorSelecionado)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                fornecedorOriginal  = bizFornecedor.PesquisarFornecedor(new Fornecedor() { idFornecedor = idFornecedorSelecionado })[0];
                fornecedorOriginal.lstContatos = bizFornecedor.PesquisarFornecedorContato(new FornecedorContato() { idFornecedor = idFornecedorSelecionado });
                fornecedorOriginal.lstContasBancarias = bizFornecedor.PesquisarFornecedorContaBancaria(new FornecedorContaBancaria() { idFornecedor = idFornecedorSelecionado });

                fornecedorSelecionado = (Fornecedor)fornecedorOriginal.Clone();        

                lbCodigo.Text = fornecedorSelecionado.idFornecedor.ToString();
                tbCodigo.Text = fornecedorSelecionado.Codigo;
                tbNome.Text = fornecedorSelecionado.Nome;
                tbCPFCNPJ.Text = fornecedorSelecionado.CPF_CNPJ;
                tbIE.Text = fornecedorSelecionado.IE;
                tbICM.Text = fornecedorSelecionado.ICM;
                cbCategoria.SelectedValue = fornecedorSelecionado.idCategoria;
                cbAtividade.SelectedValue = fornecedorSelecionado.idAtividade;
                tbEndereco.Text = fornecedorSelecionado.Endereco;
                tbComplemento.Text = fornecedorSelecionado.Complemento;
                tbBairro.Text = fornecedorSelecionado.Bairro;
                tbCidade.Text = fornecedorSelecionado.Cidade;
                cbEstado.Text = fornecedorSelecionado.Estado;
                tbCEP.Text = fornecedorSelecionado.CEP;
                tbPais.Text = fornecedorSelecionado.Pais;
                tbTelefone.Text = fornecedorSelecionado.Telefone;
                tbFax.Text = fornecedorSelecionado.Fax;
                tbEmail.Text = fornecedorSelecionado.Email;
                tbSite.Text = fornecedorSelecionado.Site;                
                tbObservacao.Text = fornecedorSelecionado.Observacao;
                cbStatus.Text = fornecedorSelecionado.Status;
                this.CarregarContatos();
                this.CarregarContasBancarias();
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

            cbEstado.DataSource = lstEstados;
            cbEstado.ValueMember = lstEstados[0];
        }

        private void CarregarStatus()
        {
            List<string> lstStatus = new List<string>();
            lstStatus.Add("Ativo");
            lstStatus.Add("Inativo");

            cbStatus.DataSource = lstStatus;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idFornecedor = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.PopularEntidadeFornecedor();

                if (lbCodigo.Text == "0")
                {
                    msgRetorno = bizFornecedor.IncluirFornecedor(fornecedorSelecionado, out idFornecedor);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idFornecedor.ToString();
                }
                else
                {
                    msgRetorno = bizFornecedor.AlterarFornecedor(fornecedorOriginal, fornecedorSelecionado);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                    this.tabControl1.SelectedIndex = 0;
                    fornecedorOriginal = (Fornecedor)fornecedorSelecionado.Clone();
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

        private void PopularEntidadeFornecedor()
        {
            fornecedorSelecionado.idFornecedor = int.Parse(lbCodigo.Text);
            fornecedorSelecionado.idAtividade = int.Parse(cbAtividade.SelectedValue.ToString());
            fornecedorSelecionado.idCategoria = int.Parse(cbCategoria.SelectedValue.ToString());
            fornecedorSelecionado.TipoPessoa = "Z";
            fornecedorSelecionado.Codigo = tbCodigo.Text;
            fornecedorSelecionado.Nome = tbNome.Text;            
            fornecedorSelecionado.CPF_CNPJ = helper.FormatarCPF_CNPJ(tbCPFCNPJ.Text);
            fornecedorSelecionado.IE = tbIE.Text;
            fornecedorSelecionado.ICM = tbICM.Text;
            fornecedorSelecionado.Endereco = tbEndereco.Text;
            fornecedorSelecionado.Complemento = tbComplemento.Text;
            fornecedorSelecionado.Bairro = tbBairro.Text;
            fornecedorSelecionado.Cidade = tbCidade.Text;
            fornecedorSelecionado.Estado = cbEstado.FindStringExact(cbEstado.Text) != -1 ? cbEstado.Text : string.Empty;
            fornecedorSelecionado.CEP = tbCEP.Text;
            fornecedorSelecionado.Pais = tbPais.Text;
            fornecedorSelecionado.Telefone = tbTelefone.Text;
            fornecedorSelecionado.Fax = tbFax.Text;
            fornecedorSelecionado.Email = tbEmail.Text;
            fornecedorSelecionado.Site = tbSite.Text;            
            fornecedorSelecionado.Observacao = tbObservacao.Text;
            fornecedorSelecionado.Status = cbStatus.FindStringExact(cbStatus.Text) != -1 ? cbStatus.Text : string.Empty;
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

        private void FornecedorManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                CarregarEstados();
                CarregarStatus();                
                CarregarComboAtividades();
                CarregarComboCategorias();

                cbTipoConta.Items.Add("C.CORRENTE");
                cbTipoConta.Items.Add("C.POUPANÇA");

                if (fornecedorOriginal.idFornecedor == 0)
                    LimparCampos();
                else
                    CarregarFornecedor(fornecedorOriginal.idFornecedor);
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
                fornecedorSelecionado.lstContatos.Add(new FornecedorContato()
                {
                    idFornecedor = fornecedorSelecionado.idFornecedor,
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

            if (tbContatoNome.Text == string.Empty)
                msgRetorno += Environment.NewLine + "Favor informar o Nome do contato";

            if (tbContatoEmail.Text.Trim() != string.Empty && helper.ValidarEmail(tbContatoEmail.Text) == false)
                msgRetorno += Environment.NewLine + "E-mail do contato inválido";

            if (fornecedorSelecionado.lstContatos == null)
                fornecedorSelecionado.lstContatos = new List<FornecedorContato>();

            return msgRetorno;
        }

        private void btContatoRemover_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;

            if (gvContatos.RowCount == 0)
                return;

            linhaGrid = gvContatos.SelectedCells[0].RowIndex;

            FornecedorContato itemSelecionado = new FornecedorContato()
            {
                Nome = gvContatos[0, linhaGrid].Value.ToString()
            };

            fornecedorSelecionado.lstContatos.RemoveAll(item => item.Nome == itemSelecionado.Nome);

            this.CarregarContatos();
        }

        private void CarregarContatos()
        {
            while (gvContatos.Rows.Count > 0)
                gvContatos.Rows.RemoveAt(0);

            if (fornecedorSelecionado.lstContatos == null)
                return;

            foreach (FornecedorContato itemContato in fornecedorSelecionado.lstContatos.OrderBy(x => x.Nome).ToList())
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

            if(fornecedorSelecionado.idFornecedor == 0)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Msg = bizFornecedor.ValidarExclusaoFornecedor(fornecedorSelecionado);

                if (Msg == string.Empty)
                {
                    if (MessageBox.Show("Confirma exclusão do fornecedor?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizFornecedor.ExcluirFornecedor(fornecedorSelecionado);
                    MessageBox.Show("Fornecedor excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btContaAdd_Click(object sender, EventArgs e)
        {
            FornecedorContaBancaria contaBancaria = new FornecedorContaBancaria();

            try
            {
                if (tbBanco.Text.Trim() != string.Empty)
                {
                    if (MessageBox.Show("Confirma inclusão desta Conta Bancária?", "Exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        LimparCamposContaBancaria();
                        return;
                    }

                    contaBancaria = new FornecedorContaBancaria()
                    {
                        idContaBancaria = 0,
                        idFornecedor = fornecedorSelecionado.idFornecedor,
                        Banco = tbBanco.Text,
                        Agencia = tbAgencia.Text,
                        TipoConta = cbTipoConta.Text,
                        Conta = tbConta.Text
                    };

                    bizFornecedor.IncluirContaBancaria(contaBancaria);

                    LimparCamposContaBancaria();

                    this.CarregarContasBancarias();
                }
                else
                    MessageBox.Show("Favor informar o Nome do Banco", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void CarregarContasBancarias()
        {
            try
            {
                while (gvContasBancarias.Rows.Count > 0)
                    gvContasBancarias.Rows.RemoveAt(0);

                fornecedorSelecionado.lstContasBancarias = bizFornecedor.PesquisarFornecedorContaBancaria(new FornecedorContaBancaria() { idFornecedor = fornecedorSelecionado.idFornecedor });

                foreach (FornecedorContaBancaria itemConta in fornecedorSelecionado.lstContasBancarias.OrderBy(x => x.Banco).ToList())
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
                    gvContasBancarias.Rows[0].Selected = true;
                else
                    LimparCamposContaBancaria();
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

        private void LimparCamposContaBancaria()
        {
            tbBanco.Text = string.Empty;
            tbAgencia.Text = string.Empty;
            cbTipoConta.Text = string.Empty;
            tbConta.Text = string.Empty;
        }

        private void btContaRemover_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            int idConta = 0;

            if (gvContasBancarias.RowCount == 0)
                return;

            if (MessageBox.Show("Confirma exclusão desta Conta Bancária?", "Exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                return;

            linhaGrid = gvContasBancarias.SelectedCells[0].RowIndex;
            idConta = int.Parse(gvContasBancarias[0, linhaGrid].Value.ToString());

            bizFornecedor.ExcluirContaBancaria(idConta);

            LimparCamposContaBancaria();

            this.CarregarContasBancarias();
        }

        private void cbTipoConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

     

          
    }
}
