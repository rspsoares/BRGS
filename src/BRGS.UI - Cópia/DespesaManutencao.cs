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
    public partial class DespesaManutencao : Form
    {
        private Despesa despesaSelecionada = new Despesa();
        private Helper helper = new Helper();        
        private BIZObra bizObra = new BIZObra();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZDespesa bizDespesa = new BIZDespesa();

        public DespesaManutencao(Despesa _despesaSelecionada)
        {
            InitializeComponent();

            despesaSelecionada = _despesaSelecionada;          
        }

        private void CarregarDespesa(Despesa despesaSelecionada)
        {
            List<ObraEtapa> lstObras = new List<ObraEtapa>();

            try
            {
                lbCodigo.Text = despesaSelecionada.idDespesa.ToString();
                tbDescricao.Text = despesaSelecionada.Descricao;
                chkGastoFixo.Checked = despesaSelecionada.gastoFixo == 1 ? true : false; 

                lstObras = bizObra.PesquisarObraEtapaDespesa(despesaSelecionada.idDespesa).OrderBy(obr => obr.nomeCliente).ToList();

                foreach (ObraEtapa itemObra in lstObras)
                {
                    gvObras.Rows.Add(new object[] 
                    {
                        itemObra.idObraEtapa, 
                        itemObra.numeroLicitacao, 
                        itemObra.nomeCliente,
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
        }

        private void LimparCampos()
        {
            despesaSelecionada = new Despesa();
            lbCodigo.Text = "0";
            tbDescricao.Text = string.Empty;
            chkGastoFixo.Checked = false;

            while (gvObras.Rows.Count > 0)
                gvObras.Rows.RemoveAt(0);
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
            int idDespesa = 0;            
                        
            despesaSelecionada.Descricao = tbDescricao.Text;
            despesaSelecionada.gastoFixo = chkGastoFixo.Checked ? 1 : 0;
            
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (despesaSelecionada.idDespesa == 0)
                {
                    msgRetorno = bizDespesa.IncluirDespesa(UsuarioLogado.idUsuario, despesaSelecionada, out idDespesa);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idDespesa.ToString();
                    despesaSelecionada.idDespesa = idDespesa;
                }
                else
                {
                    msgRetorno = bizDespesa.AlterarDespesa(despesaSelecionada);
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
            int idDespesa = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                idDespesa = int.Parse(lbCodigo.Text);

                if (idDespesa != 0)
                {
                    msgRetorno = bizDespesa.ValidarExclusao(despesaSelecionada);
                    
                    if(msgRetorno == string.Empty)                    
                    {
                        if(MessageBox.Show("Confirma exclusão da Despesa?","Confirmação de exclusão",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)                        
                        {
                            bizDespesa.ExcluirDespesa(despesaSelecionada);
                            MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparCampos();
                        }
                    }
                    else
                        MessageBox.Show("Atenção" + msgRetorno,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
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

        private void DespesaManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (despesaSelecionada.idDespesa == 0)
                    LimparCampos();
                else
                    CarregarDespesa(despesaSelecionada);

                this.Cursor = Cursors.Default;
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
