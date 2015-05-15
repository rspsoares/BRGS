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
    public partial class CentroCustoManutencao : Form
    {
        private CentroCusto centroCustoSelecionado = new CentroCusto();
        private Helper helper = new Helper();        
        private BIZDespesa bizDespesa = new BIZDespesa();
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private List<Despesa> lstDespesasCadastradas = new List<Despesa>();
        private BIZUsuario bizUsuario = new BIZUsuario();
        private List<Usuario> lstUsuarioCadastrados = new List<Usuario>();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private bool origemCliente = false;

        public CentroCustoManutencao(CentroCusto _centroCustoSelecionado, bool _origemCliente)
        {
            InitializeComponent();

            centroCustoSelecionado = _centroCustoSelecionado;
            origemCliente = _origemCliente;
        }

        private void CarregarDespesas()
        {
            try
            {
                lstDespesasCadastradas = bizDespesa.PesquisarDespesa(new Despesa()).OrderBy(x => x.Descricao).ToList();
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

        private void CarregarUsuarios()
        {
            try
            {
                lstUsuarioCadastrados = bizUsuario.PesquisarUsuario(new Usuario() { Ativo = "S", Bloqueado = 0}).OrderBy(x => x.Nome).ToList();
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
            tbCodigo.Text = string.Empty;
            tbDescricao.Text = string.Empty;
            chkAdministrativo.Checked = false;
            centroCustoSelecionado = new CentroCusto();
            centroCustoSelecionado.lstDespesas = new List<CentroCustoDespesa>();
            centroCustoSelecionado.lstUsuarios = new List<UsuarioCentroCusto>();

            while (gvDespesasCadastradas.Rows.Count > 0)
                gvDespesasCadastradas.Rows.RemoveAt(0);

            while (gvDespesasAssociadas.Rows.Count > 0)
                gvDespesasAssociadas.Rows.RemoveAt(0);

            while (gvUsuariosCadastrados.Rows.Count > 0)
                gvUsuariosCadastrados.Rows.RemoveAt(0);

            while (gvUsuariosAssociados.Rows.Count > 0)
                gvUsuariosAssociados.Rows.RemoveAt(0);

            this.CarregarDespesasCadastradas(lstDespesasCadastradas);
            this.CarregarUsuariosCadastrados(lstUsuarioCadastrados);            
        }

        private void CarregarDespesasCadastradas(List<Despesa> lstDespesas)            
        {    
            while (gvDespesasCadastradas.Rows.Count > 0)
                gvDespesasCadastradas.Rows.RemoveAt(0);

            foreach (Despesa itemDespesa in lstDespesas)
            {
                gvDespesasCadastradas.Rows.Add(new object[] 
                {
                    itemDespesa.idDespesa, 
                    itemDespesa.Descricao                      
                });
            }
        }

        private void CarregarUsuariosCadastrados(List<Usuario> lstUsuarios)
        {
            while (gvUsuariosCadastrados.Rows.Count > 0)
                gvUsuariosCadastrados.Rows.RemoveAt(0);

            foreach (Usuario itemUsuario in lstUsuarios)
            {
                gvUsuariosCadastrados.Rows.Add(new object[] 
                {
                    itemUsuario.idUsuario, 
                    itemUsuario.Nome                      
                });
            }
        }

        private void CarregarDespesasAssociadas()
        {
            while (gvDespesasAssociadas.Rows.Count > 0)
                gvDespesasAssociadas.Rows.RemoveAt(0);

            foreach (CentroCustoDespesa itemDespesa in centroCustoSelecionado.lstDespesas.OrderBy(x => x.descricaoDespesa).ToList())
            {
                gvDespesasAssociadas.Rows.Add(new object[] 
                {
                    itemDespesa.idDespesa, 
                    itemDespesa.descricaoDespesa
                });
            }
        }

        private void CarregarUsuariosAssociados()
        {
            while (gvUsuariosAssociados.Rows.Count > 0)
                gvUsuariosAssociados.Rows.RemoveAt(0);

            foreach (UsuarioCentroCusto itemUsuario in centroCustoSelecionado.lstUsuarios.OrderBy(x => x.nomeUsuario).ToList())
            {
                gvUsuariosAssociados.Rows.Add(new object[] 
                {
                    itemUsuario.idUsuario, 
                    itemUsuario.nomeUsuario
                });
            }
        }

        private void CarregarCentroCusto(CentroCusto centroCustoSelecionado)
        {
            try
            {                
                tbCodigo.Text = centroCustoSelecionado.Codigo;
                tbDescricao.Text = centroCustoSelecionado.Descricao;
                chkAdministrativo.Checked = centroCustoSelecionado.Administrativo == 1 ? true : false;

                this.CarregarDespesasCadastradas(lstDespesasCadastradas);
                this.CarregarDespesasAssociadas();

                this.CarregarUsuariosCadastrados(lstUsuarioCadastrados);
                this.CarregarUsuariosAssociados();
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

        private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int idDespesaCadastrada = 0;
            string descricaoDespesaCadastrada = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvDespesasCadastradas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idDespesaCadastrada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                descricaoDespesaCadastrada = linhaSelecionada.Cells[1].Value.ToString();
                
                if (centroCustoSelecionado.lstDespesas.Exists(x => x.idDespesa == idDespesaCadastrada))            
                    MessageBox.Show("A despesa " + descricaoDespesaCadastrada + " já está associada a esse Centro de Custo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                           
                else
                {
                    centroCustoSelecionado.lstDespesas.Add(new CentroCustoDespesa()
                    {
                        idDespesa = idDespesaCadastrada,
                        descricaoDespesa = descricaoDespesaCadastrada
                    });                   
                }            
            }

            this.CarregarDespesasAssociadas();
        }

        private void btRem_Click(object sender, EventArgs e)
        {
            int idDespesaAssociada = 0;          
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvDespesasAssociadas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idDespesaAssociada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());                
                centroCustoSelecionado.lstDespesas.RemoveAll(item => item.idDespesa == idDespesaAssociada);
            }
          
            CarregarDespesasAssociadas();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idCentroCusto = 0;

            centroCustoSelecionado.Codigo = tbCodigo.Text;
            centroCustoSelecionado.Descricao = tbDescricao.Text;
            centroCustoSelecionado.Administrativo = chkAdministrativo.Checked ? 1 : 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (centroCustoSelecionado.idCentroCusto == 0)
                {
                    msgRetorno = bizCentroCusto.IncluirCentroCusto(UsuarioLogado.idUsuario, centroCustoSelecionado, out idCentroCusto);
                    acaoSelecionada = "Inclusão";                    
                    centroCustoSelecionado.idCentroCusto = idCentroCusto;                    
                }
                else
                {
                    msgRetorno = bizCentroCusto.AlterarCentroCustos(centroCustoSelecionado);
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

            this.Cursor = Cursors.WaitCursor;

            try
            {               
                if (centroCustoSelecionado.idCentroCusto != 0)
                {
                    msgRetorno = bizCentroCusto.ValidarExclusao(centroCustoSelecionado);

                    if (msgRetorno == string.Empty)
                    {
                        if (MessageBox.Show("Confirma exclusão do Centro de Custo?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            bizCentroCusto.ExcluirCentroCusto(centroCustoSelecionado);
                            MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparCampos();
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

            this.Cursor = Cursors.Default;
        }

        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }       

        private void tbFiltroDespesa_TextChanged(object sender, EventArgs e)
        {
            var lstDespesasFiltrado = from lstDespesasFiltro in lstDespesasCadastradas
                                      where lstDespesasFiltro.Descricao.ToUpper().Contains(tbFiltroDespesa.Text.Trim().ToUpper())
                                      select lstDespesasFiltro;

            this.CarregarDespesasCadastradas(lstDespesasFiltrado.ToList());    
        }

        private void tbFiltroDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void CentroCustoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                
                this.CarregarDespesas();
                this.CarregarUsuarios();

                if (centroCustoSelecionado.idCentroCusto == 0)
                    LimparCampos();
                else
                    CarregarCentroCusto(centroCustoSelecionado);

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

        private void btAddUsuario_Click(object sender, EventArgs e)
        {
            int idUsuarioCadastrado = 0;
            string nomeUsuarioCadastrado = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvUsuariosCadastrados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idUsuarioCadastrado = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                nomeUsuarioCadastrado = linhaSelecionada.Cells[1].Value.ToString();

                if (centroCustoSelecionado.lstUsuarios.Exists(x => x.idUsuario == idUsuarioCadastrado))
                    MessageBox.Show("O usuário " + nomeUsuarioCadastrado + " já está associado a esse Centro de Custo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    centroCustoSelecionado.lstUsuarios.Add(new UsuarioCentroCusto()
                    {
                        idUsuario = idUsuarioCadastrado,
                        nomeUsuario = nomeUsuarioCadastrado
                    });
                }
            }

            this.CarregarUsuariosAssociados();
        }

        private void btRemUsuario_Click(object sender, EventArgs e)
        {
            int idUsuarioAssociado = 0;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvUsuariosAssociados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idUsuarioAssociado = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                centroCustoSelecionado.lstUsuarios.RemoveAll(item => item.idUsuario == idUsuarioAssociado);
            }

            CarregarUsuariosAssociados();
        }       
    }
}
