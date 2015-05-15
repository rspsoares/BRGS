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
    public partial class CategoriaManutencao : Form
    {
        private Categoria categoriaSelecionada = new Categoria();
        private Categoria categoriaOriginal = new Categoria();
        private BIZCategoria bizCategoria = new BIZCategoria();
        private BIZCliente bizCliente = new BIZCliente();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public CategoriaManutencao(Categoria _categoriaSelecionada)
        {
            InitializeComponent();

            categoriaOriginal = _categoriaSelecionada;
            categoriaSelecionada = (Categoria)categoriaOriginal.Clone();
        }

        private void CarregarClientes()
        {
            List<Cliente> lstClientes = new List<Cliente>();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                lstClientes = bizCliente.PesquisarCliente(new Cliente() { idCategoria = categoriaSelecionada.idCategoria }).OrderBy(x => x.Nome).ToList();

                foreach (Cliente itemCliente in lstClientes)
                {
                    gvClientes.Rows.Add(new object[] 
                    {
                        itemCliente.idCliente, 
                        itemCliente.Nome
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

        private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idCategoria = 0;

            categoriaSelecionada.Descricao = tbDescricao.Text;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (categoriaSelecionada.idCategoria == 0)
                {
                    msgRetorno = bizCategoria.IncluirCategoria(categoriaSelecionada, out idCategoria);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idCategoria.ToString();
                    categoriaSelecionada.idCategoria = idCategoria;
                }
                else
                {
                    msgRetorno = bizCategoria.AlterarCategoria(categoriaOriginal, categoriaSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    categoriaOriginal = (Categoria)categoriaSelecionada.Clone();
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (categoriaSelecionada.idCategoria != 0)
                {
                    msgRetorno = bizCategoria.ValidarExclusao(categoriaSelecionada);

                    if (msgRetorno == string.Empty)
                    {
                        if (MessageBox.Show("Confirma exclusão da Categoria?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            bizCategoria.ExcluirCategoria(categoriaSelecionada);
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Atenção " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        }

        private void CategoriaManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                
                if (categoriaSelecionada.idCategoria != 0)
                {
                    tbDescricao.Text = categoriaSelecionada.Descricao;
                    this.CarregarClientes();
                }
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
    }
}
