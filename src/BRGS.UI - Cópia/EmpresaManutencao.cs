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
    public partial class EmpresaManutencao : Form
    {
        private Empresa empresaSelecionada = new Empresa();
        private BIZEmpresa bizEmpresa = new BIZEmpresa();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public EmpresaManutencao(Empresa _empresaSelecionada)
        {
            InitializeComponent();
            empresaSelecionada = _empresaSelecionada;            
        }

        private void tbRazaoSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbNomeFantasia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbAtividade_KeyDown(object sender, KeyEventArgs e)
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

        private void tbCNPJ_KeyDown(object sender, KeyEventArgs e)
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

        private void tbInscricaoEstadual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCNPJ_Leave(object sender, EventArgs e)
        {
            tbCNPJ.Text = helper.FormatarCPF_CNPJ(tbCNPJ.Text);
        }

        private void EmpresaManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                CarregarEstados();

                cbTipoConta.Items.Add("C.CORRENTE");
                cbTipoConta.Items.Add("C.POUPANÇA");

                if (empresaSelecionada.idEmpresa != 0)
                    this.CarregarEmpresa();
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

        private void CarregarEstados()
        {
            List<string> lstEstados = new List<string>();
            lstEstados.Add("");
            lstEstados.AddRange(helper.RetornarUF());

            cbEstado.DataSource = lstEstados;
            cbEstado.ValueMember = lstEstados[0];
        }

        private void CarregarEmpresa()
        {
            empresaSelecionada = bizEmpresa.PesquisarEmpresa(new Empresa() { idEmpresa = empresaSelecionada.idEmpresa })[0];
            empresaSelecionada.lstContasBancarias = bizEmpresa.PesquisarEmpresaContaBancaria(new EmpresaContaBancaria() { idEmpresa = empresaSelecionada.idEmpresa });

            tbRazaoSocial.Text = empresaSelecionada.razaoSocial;
            tbNomeFantasia.Text = empresaSelecionada.nomeFantasia;
            tbAtividade.Text = empresaSelecionada.Atividade;
            tbEndereco.Text = empresaSelecionada.Endereco;
            tbCidade.Text = empresaSelecionada.Cidade;
            cbEstado.Text = empresaSelecionada.Estado;
            tbCNPJ.Text = empresaSelecionada.CNPJ;
            tbICM.Text = empresaSelecionada.ICM;
            tbInscricaoEstadual.Text = empresaSelecionada.inscricaoEstadual;

            CarregarContasBancarias();
        }

        private void CarregarContasBancarias()
        {
            while (gvContasBancarias.Rows.Count > 0)
                gvContasBancarias.Rows.RemoveAt(0);

            lbIdContaBancaria.Text = string.Empty;

            foreach (EmpresaContaBancaria itemConta in empresaSelecionada.lstContasBancarias.Where(x => x.Excluir == false).OrderBy(x => x.Banco).ToList())
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

        private void btContaAdd_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;
            if (tbBanco.Text.Trim() != string.Empty)
            {
                if (lbIdContaBancaria.Text == string.Empty)
                {
                    empresaSelecionada.lstContasBancarias.Add(new EmpresaContaBancaria()
                    {
                        idContaBancaria = 0,
                        idEmpresa = empresaSelecionada.idEmpresa,
                        Banco = tbBanco.Text,
                        Agencia = tbAgencia.Text,
                        TipoConta = cbTipoConta.Text,
                        Conta = tbConta.Text
                    });
                }
                else
                {
                    linhaGrid = int.Parse(lbIdContaBancaria.Text);

                    EmpresaContaBancaria itemSelecionado = new EmpresaContaBancaria()
                    {
                        Banco = gvContasBancarias[1, linhaGrid].Value.ToString(),
                        Agencia = gvContasBancarias[2, linhaGrid].Value.ToString(),
                        TipoConta = gvContasBancarias[3, linhaGrid].Value.ToString(),
                        Conta = gvContasBancarias[4, linhaGrid].Value.ToString(),
                    };

                    EmpresaContaBancaria contaAtualizada = empresaSelecionada.lstContasBancarias.Where
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

                lbIdContaBancaria.Text = string.Empty;
                tbBanco.Text = string.Empty;
                tbAgencia.Text = string.Empty;
                cbTipoConta.Text = string.Empty;
                tbConta.Text = string.Empty;
            }
            else
                MessageBox.Show("Favor informar o Nome do Banco", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btContaRemover_Click(object sender, EventArgs e)
        {            
            int linhaGrid = 0;
            
            if (gvContasBancarias.RowCount == 0)
                return;

            lbIdContaBancaria.Text = string.Empty;

            linhaGrid = gvContasBancarias.SelectedCells[0].RowIndex;

            EmpresaContaBancaria itemSelecionado = new EmpresaContaBancaria()
            {
                Banco = gvContasBancarias[1, linhaGrid].Value.ToString(),
                Agencia = gvContasBancarias[2, linhaGrid].Value.ToString(),
                TipoConta = gvContasBancarias[3, linhaGrid].Value.ToString(),
                Conta = gvContasBancarias[4, linhaGrid].Value.ToString(),
            };

            empresaSelecionada.lstContasBancarias.Where
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

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idEmpresa = 0;

            PopularEntidade();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (empresaSelecionada.idEmpresa == 0)
                {
                    msgRetorno = bizEmpresa.IncluirEmpresa(empresaSelecionada, out idEmpresa);
                    acaoSelecionada = "Inclusão";
                    empresaSelecionada.idEmpresa = idEmpresa;
                }
                else
                {
                    msgRetorno = bizEmpresa.AlterarEmpresa(empresaSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)                
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            empresaSelecionada.razaoSocial = tbRazaoSocial.Text;
            empresaSelecionada.nomeFantasia = tbNomeFantasia.Text;            
            empresaSelecionada.Atividade = tbAtividade.Text;
            empresaSelecionada.Endereco = tbEndereco.Text;
            empresaSelecionada.Cidade = tbCidade.Text;
            empresaSelecionada.Estado = cbEstado.Text;
            empresaSelecionada.CNPJ = tbCNPJ.Text;
            empresaSelecionada.ICM = tbICM.Text;
            empresaSelecionada.inscricaoEstadual = tbInscricaoEstadual.Text;
        }
    }
}
