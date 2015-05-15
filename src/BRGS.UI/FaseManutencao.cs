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
    public partial class FaseManutencao : Form
    {
        private Fase faseSelecionada = new Fase();
        private BIZFase bizFase = new BIZFase();
        private BIZCliente bizCliente = new BIZCliente();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public FaseManutencao(Fase _faseSelecionada)
        {
            InitializeComponent();
            faseSelecionada = _faseSelecionada;            
        }
        
        private void CarregarObras()
        {
            List<ObraEtapa> lstObras = new List<ObraEtapa>();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                lstObras = bizFase.PesquisarObrasAssociadas(new Fase() { idFase = faseSelecionada.idFase}).OrderBy(x => x.nomeCliente).ThenBy(x => x.nomeEvento).ToList();

                foreach (ObraEtapa itemObra in lstObras)
                {
                    gvObras.Rows.Add(new object[] 
                    {
                        itemObra.idObraEtapa, 
                        itemObra.nomeCliente,
                        itemObra.numeroLicitacao,
                        itemObra.nomeEvento                     
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
            int idFase = 0;

            faseSelecionada.Descricao = tbDescricao.Text;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (faseSelecionada.idFase == 0)
                {
                    msgRetorno = bizFase.IncluirFase(faseSelecionada, out idFase);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idFase.ToString();
                    faseSelecionada.idFase = idFase;
                }
                else
                {
                    msgRetorno = bizFase.AlterarFase(faseSelecionada);
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (faseSelecionada.idFase != 0)
                {
                    msgRetorno = bizFase.ValidarExclusao(faseSelecionada);

                    if (msgRetorno == string.Empty)
                    {
                        if (MessageBox.Show("Confirma exclusão da Fase?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            bizFase.ExcluirFase(faseSelecionada);
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

        private void FaseManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (faseSelecionada.idFase != 0)
                {
                    tbDescricao.Text = faseSelecionada.Descricao;
                    this.CarregarObras();
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
