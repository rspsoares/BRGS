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
    public partial class AtividadeManutencao : Form
    {
        private Atividade atividadeSelecionada = new Atividade();
        private Atividade atividadeOriginal = new Atividade();
        private BIZAtividade bizAtividade = new BIZAtividade();
        private BIZCliente bizCliente = new BIZCliente();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public AtividadeManutencao(Atividade _atividadeSelecionada)
        {
            InitializeComponent();
            atividadeOriginal = _atividadeSelecionada;
            atividadeSelecionada = (Atividade)atividadeOriginal.Clone();
        }

        private void CarregarClientes()
        {
            List<Cliente> lstClientes = new List<Cliente>();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                lstClientes = bizCliente.PesquisarCliente(new Cliente() { idAtividade = atividadeSelecionada.idAtividade }).OrderBy(x => x.Nome).ToList();

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
            int idAtividade = 0;

            atividadeSelecionada.Descricao = tbDescricao.Text;            

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (atividadeSelecionada.idAtividade == 0)
                {
                    msgRetorno = bizAtividade.IncluirAtividade(atividadeSelecionada, out idAtividade);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idAtividade.ToString();
                    atividadeSelecionada.idAtividade = idAtividade;
                }
                else
                {
                    msgRetorno = bizAtividade.AlterarAtividade(atividadeOriginal, atividadeSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atividadeOriginal = (Atividade)atividadeSelecionada.Clone();
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
                if (atividadeSelecionada.idAtividade != 0)
                {
                    msgRetorno = bizAtividade.ValidarExclusao(atividadeSelecionada);

                    if (msgRetorno == string.Empty)
                    {
                        if (MessageBox.Show("Confirma exclusão da Atividade?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            bizAtividade.ExcluirAtividade(atividadeSelecionada);
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

        private void AtividadeManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (atividadeSelecionada.idAtividade != 0)
                {
                    tbDescricao.Text = atividadeSelecionada.Descricao;
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
