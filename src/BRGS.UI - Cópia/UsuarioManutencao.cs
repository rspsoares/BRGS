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
    public partial class UsuarioManutencao : Form
    {
        private Usuario usuarioSelecionado = new Usuario();
        private BIZUsuario bizUsuario = new BIZUsuario();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        private List<UsuarioPermissoes> lstPermissoes = new List<UsuarioPermissoes>();
        private List<UsuarioPermissoes> lstUsuarioPermissoes = new List<UsuarioPermissoes>();
        private BIZUEN bizUEN = new BIZUEN();        
        private List<UEN> lstUENCadastradas = new List<UEN>();
        private List<UEN> lstUENSelecionadas = new List<UEN>();
        private BIZCentroCusto bizCC = new BIZCentroCusto();
        private List<CentroCusto> lstCCCadastrados = new List<CentroCusto>();
        private List<CentroCusto> lstCCSelecionados = new List<CentroCusto>();
        private BIZDespesa bizDespesa = new BIZDespesa();
        private List<Despesa> lstDespesaCadastradas = new List<Despesa>();
        private List<Despesa> lstDespesaSelecionados = new List<Despesa>();

        public UsuarioManutencao(Usuario _usuarioSelecionado)
        {
            InitializeComponent();
            usuarioSelecionado = _usuarioSelecionado;          
        }

        private void CarregarAcessos()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstPermissoes = bizUsuario.PesquisarPermissoesUsuario(new UsuarioPermissoes() { idUsuario = usuarioSelecionado.idUsuario });

                if (lstPermissoes.Count == 0)
                    return;

                if (usuarioSelecionado.idUsuario == 0)
                    lstPermissoes = lstPermissoes.Where(x => x.idUsuario == lstPermissoes[0].idUsuario).ToList();
          
                foreach (UsuarioPermissoes itemPermissao in lstPermissoes)
                {
                    if (itemPermissao.idControlePai == 0)
                    {
                        TriStateTreeNode nodeModulo = new TriStateTreeNode(" " + itemPermissao.descricaoControle);
                        nodeModulo.IsContainer = true;                        
                        nodeModulo.Name = itemPermissao.idControle.ToString();
                        
                        this.AdicionarControles(nodeModulo, itemPermissao.idControle, lstPermissoes);

                        this.tvAcesso.SuspendLayout();
                        this.tvAcesso.Nodes.Add(nodeModulo);
                        this.tvAcesso.ResumeLayout();
                    }
                }

                foreach (UsuarioPermissoes permissao in lstPermissoes)
                {
                    TriStateTreeNode nodeSelecionado = (TriStateTreeNode)tvAcesso.Nodes.Find(permissao.idControle.ToString(), true)[0];
                    nodeSelecionado.Checked = permissao.Habilitado;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(helper.RetornarMensagemPadraoErroAcessoBD(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void AdicionarControles(TriStateTreeNode nodeModulo, int idPai, List<UsuarioPermissoes> lstPermissoes)
        {
            List<UsuarioPermissoes> lstPermissoesControles = new List<UsuarioPermissoes>();
            lstPermissoesControles = lstPermissoes.Where(perm => perm.idControlePai == idPai).ToList();

            if (lstPermissoesControles.Count > 0)
            {
                foreach (UsuarioPermissoes itemPermissao in lstPermissoesControles)
                {
                    TriStateTreeNode nodeControle = new TriStateTreeNode(" " + itemPermissao.descricaoControle);
                    nodeControle.Name = itemPermissao.idControle.ToString();
                    nodeControle.IsContainer = !itemPermissao.objetoTela;
                    nodeControle.Collapse();

                    this.AdicionarControles(nodeControle, itemPermissao.idControle, lstPermissoes);

                    nodeModulo.Nodes.Add(nodeControle);
                }
            }
        }

        private void linkRedefinirSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = this.PopularEntidade();

            UsuarioSenha formSenha = new UsuarioSenha(usuario);
            formSenha.ShowDialog();
        }

        private void ObterPermissoes(TreeNodeCollection lstNos)
        {
            if (lstNos != null)
            {
                foreach (TriStateTreeNode itemNo in lstNos)
                {
                    lstUsuarioPermissoes.Add(new UsuarioPermissoes()
                    {
                        idUsuario = usuarioSelecionado.idUsuario,
                        idControle = int.Parse(itemNo.Name.ToString()),
                        Habilitado = itemNo.Checked
                    });

                    ObterPermissoes(itemNo.Nodes);
                }
            }
        }

        private Usuario PopularEntidade()
        {
            usuarioSelecionado.idUsuario = usuarioSelecionado.idUsuario;
            usuarioSelecionado.Nome = tbNome.Text;
            usuarioSelecionado.Login = tbLogin.Text;
            usuarioSelecionado.Bloqueado = chkBloqueado.Checked ? 1 : 0;
            usuarioSelecionado.Ativo = "S";

            return usuarioSelecionado;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {            
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idUsuario = 0;
            
            usuarioSelecionado = this.PopularEntidade();
            lstUsuarioPermissoes = new List<UsuarioPermissoes>();            
            this.ObterPermissoes(tvAcesso.Nodes);            
            usuarioSelecionado.lstPermissoes = lstUsuarioPermissoes.Distinct().ToList();
        
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (usuarioSelecionado.idUsuario == 0)
                {
                    msgRetorno = bizUsuario.IncluirUsuario(usuarioSelecionado, out idUsuario);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idUsuario.ToString();
                    usuarioSelecionado.idUsuario = idUsuario; ;
                }
                else
                {
                    msgRetorno = bizUsuario.AlterarUsuario(usuarioSelecionado);
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

            TabControl1.TabIndex = 0;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
          
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (usuarioSelecionado.idUsuario != 0)
                {
                    if (MessageBox.Show("Confirma exclusão do Usuário?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        bizUsuario.ExcluirUsuario(usuarioSelecionado);
                        MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }                  
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

            TabControl1.TabIndex = 0;
        }

        private void tbNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void UsuarioManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                
                this.CarregarAcessos();
                this.CarregarUENCadastradas();
                this.CarregarCCCadastrados();
                this.CarregarDespesaCadastradas();
                
                if (usuarioSelecionado.idUsuario > 0)
                {
                    usuarioSelecionado = bizUsuario.PesquisarUsuario(new Usuario { idUsuario = usuarioSelecionado.idUsuario }).FirstOrDefault();

                    tbNome.Text = usuarioSelecionado.Nome;
                    tbLogin.Text = usuarioSelecionado.Login;
                    tbUltimoAcesso.Text = usuarioSelecionado.idUsuario > 0 && usuarioSelecionado.ultimoAcesso != DateTime.MinValue ? usuarioSelecionado.ultimoAcesso.ToString() : string.Empty;
                    chkBloqueado.Checked = usuarioSelecionado.Bloqueado == 1 ? true : false;
                    linkRedefinirSenha.Enabled = usuarioSelecionado.idUsuario > 0;

                    this.CarregarUENAssociadas();                    
                    this.CarregarCCAssociados();                    
                    this.CarregarDespesaAssociadas();
                }
                else
                {
                    usuarioSelecionado.lstPermissoes = new List<UsuarioPermissoes>();
                    usuarioSelecionado.lstUEN = new List<UsuarioUEN>();
                    usuarioSelecionado.lstCC = new List<UsuarioCentroCusto>();
                    usuarioSelecionado.lstDespesas = new List<UsuarioDespesa>();
                }

                TabControl1.TabIndex = 0;
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
       
        private void CarregarUENCadastradas()
        {
            lstUENCadastradas = bizUEN.PesquisarUEN(new UEN()).OrderBy(x => x.Descricao).ToList();

            while (gvUENCadastradas.Rows.Count > 0)
                gvUENCadastradas.Rows.RemoveAt(0);

            foreach (UEN itemUEN in lstUENCadastradas)
            {
                gvUENCadastradas.Rows.Add(new object[] 
                {
                    itemUEN.idUEN, 
                    itemUEN.Descricao                      
                });
            }
        }

        private void CarregarUENAssociadas()
        {
            while (gvUENAssociadas.Rows.Count > 0)
                gvUENAssociadas.Rows.RemoveAt(0);

            foreach (UsuarioUEN itemUEN in usuarioSelecionado.lstUEN.OrderBy(x => x.descricaoUEN).ToList())
            {
                gvUENAssociadas.Rows.Add(new object[] 
                {
                    itemUEN.idUEN, 
                    itemUEN.descricaoUEN
                });
            }
        }

        private void CarregarCCCadastrados()
        {
            lstCCCadastrados = bizCC.PesquisarCentroCusto(new CentroCusto()).OrderBy(x => x.Descricao).ToList();

            while (gvCCCadastrados.Rows.Count > 0)
                gvCCCadastrados.Rows.RemoveAt(0);

            foreach (CentroCusto itemCentroCusto in lstCCCadastrados)
            {
                gvCCCadastrados.Rows.Add(new object[] 
                {
                    itemCentroCusto.idCentroCusto, 
                    itemCentroCusto.Descricao                      
                });
            }
        }

        private void CarregarCCAssociados()
        {
            while (gvCCAssociados.Rows.Count > 0)
                gvCCAssociados.Rows.RemoveAt(0);

            foreach (UsuarioCentroCusto itemCC in usuarioSelecionado.lstCC.OrderBy(x => x.descricaoCentroCusto).ToList())
            {
                gvCCAssociados.Rows.Add(new object[] 
                {
                    itemCC.idCentroCusto, 
                    itemCC.descricaoCentroCusto
                });
            }
        }

        private void CarregarDespesaCadastradas()
        {
            lstDespesaCadastradas = bizDespesa.PesquisarDespesa(new Despesa()).OrderBy(x => x.Descricao).ToList();

            while (gvDespesasCadastradas.Rows.Count > 0)
                gvDespesasCadastradas.Rows.RemoveAt(0);

            foreach (Despesa itemDespesa in lstDespesaCadastradas)
            {
                gvDespesasCadastradas.Rows.Add(new object[] 
                {
                    itemDespesa.idDespesa, 
                    itemDespesa.Descricao                      
                });
            }
        }

        private void CarregarDespesaAssociadas()
        {
            while (gvDespesasAssociadas.Rows.Count > 0)
                gvDespesasAssociadas.Rows.RemoveAt(0);

            foreach (UsuarioDespesa itemDespesa in usuarioSelecionado.lstDespesas.OrderBy(x => x.descricaoDespesa).ToList())
            {
                gvDespesasAssociadas.Rows.Add(new object[] 
                {
                    itemDespesa.idDespesa, 
                    itemDespesa.descricaoDespesa
                });
            }
        }

        private void btUENAdicionar_Click(object sender, EventArgs e)
        {
            int idUENCadastrada = 0;
            string descricaoUENCadastrada = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvUENCadastradas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idUENCadastrada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                descricaoUENCadastrada = linhaSelecionada.Cells[1].Value.ToString();

                if (usuarioSelecionado.lstUEN.Exists(x => x.idUEN == idUENCadastrada))
                    MessageBox.Show("A UEN " + descricaoUENCadastrada + " já está associada a esse usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    usuarioSelecionado.lstUEN.Add(new UsuarioUEN()
                    {
                        idUEN = idUENCadastrada,
                        descricaoUEN = descricaoUENCadastrada
                    });
                }
            }

            this.CarregarUENAssociadas();
        }

        private void btUENRemover_Click(object sender, EventArgs e)
        {
            int idUENAssociada = 0;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvUENAssociadas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idUENAssociada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                usuarioSelecionado.lstUEN.RemoveAll(item => item.idUEN == idUENAssociada);
            }

            this.CarregarUENAssociadas();
        }

        private void btCCAdicionar_Click(object sender, EventArgs e)
        {
            int idCCCadastrado = 0;
            string descricaoCCCadastrado = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvCCCadastrados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idCCCadastrado = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                descricaoCCCadastrado = linhaSelecionada.Cells[1].Value.ToString();

                if (usuarioSelecionado.lstCC.Exists(x => x.idCentroCusto == idCCCadastrado))
                    MessageBox.Show("O Centro de Custo " + descricaoCCCadastrado + " já está associado a esse usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    usuarioSelecionado.lstCC.Add(new UsuarioCentroCusto()
                    {
                        idCentroCusto = idCCCadastrado,
                        descricaoCentroCusto = descricaoCCCadastrado
                    });
                }
            }

            this.CarregarCCAssociados();
        }

        private void btDespesaAdicionar_Click(object sender, EventArgs e)
        {
            int idDespesaCadastrada = 0;
            string descricaoDespesaCadastrada = string.Empty;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvDespesasCadastradas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idDespesaCadastrada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                descricaoDespesaCadastrada = linhaSelecionada.Cells[1].Value.ToString();

                if (usuarioSelecionado.lstDespesas.Exists(x => x.idDespesa == idDespesaCadastrada))
                    MessageBox.Show("A Despesa " + descricaoDespesaCadastrada + " já está associada a esse usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    usuarioSelecionado.lstDespesas.Add(new UsuarioDespesa()
                    {
                        idDespesa = idDespesaCadastrada,
                        descricaoDespesa = descricaoDespesaCadastrada
                    });
                }
            }

            this.CarregarDespesaAssociadas();
        }

        private void btCCRemover_Click(object sender, EventArgs e)
        {
            int idCCAssociado = 0;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvCCAssociados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idCCAssociado = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                usuarioSelecionado.lstCC.RemoveAll(item => item.idCentroCusto == idCCAssociado);
            }

            this.CarregarCCAssociados();
        }

        private void btDespesaRemover_Click(object sender, EventArgs e)
        {
            int idDespesaAssociada = 0;
            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvDespesasAssociadas.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idDespesaAssociada = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                usuarioSelecionado.lstDespesas.RemoveAll(item => item.idDespesa == idDespesaAssociada);
            }

            this.CarregarDespesaAssociadas();
        }
    }
}
