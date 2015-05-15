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
    public partial class UENManutencao : Form
    {
        private UEN uenSelecionada = new UEN();
        private Helper helper = new Helper();
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private BIZUEN bizUEN = new BIZUEN();
        private List<CentroCusto> lstCentrosCustosCadastrados = new List<CentroCusto>();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public UENManutencao(UEN _uenSelecionada)
        {
            InitializeComponent();

            uenSelecionada = _uenSelecionada;           
        }

        private void CarregarCentrosCustos()
        {
            this.Cursor = Cursors.WaitCursor;
            
            try            
            {
                lstCentrosCustosCadastrados = bizCentroCusto.PesquisarCentroCusto(new CentroCusto()).OrderBy(x => x.Descricao).ToList();
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
            tbDescricao.Text = string.Empty;
            chkAdministrativo.Checked = false;
            tbFiltroDespesa.Text = string.Empty;
            uenSelecionada = new UEN();
            uenSelecionada.lstCentrosCustos = new List<UENCentroCusto>();
 
            while (gvCentrosCustosCadastrados.Rows.Count > 0)
                gvCentrosCustosCadastrados.Rows.RemoveAt(0);

            this.CarregarCentrosCustosCadastrados(lstCentrosCustosCadastrados);

            while (gvCentrosCustosAssociados.Rows.Count > 0)
                gvCentrosCustosAssociados.Rows.RemoveAt(0);
        }

        private void CarregarCentrosCustosCadastrados(List<CentroCusto> lstCentrosCustos)
        {   
            while (gvCentrosCustosCadastrados.Rows.Count > 0)
                gvCentrosCustosCadastrados.Rows.RemoveAt(0);

            foreach (CentroCusto itemCentroCusto in lstCentrosCustos)
            {
                gvCentrosCustosCadastrados.Rows.Add(new object[] 
                {
                    itemCentroCusto.idCentroCusto, 
                    itemCentroCusto.Codigo, 
                    itemCentroCusto.Descricao                      
                });
            }
        }

        private void CarregarCentrosCustosAssociados()
        {
            while (gvCentrosCustosAssociados.Rows.Count > 0)
                gvCentrosCustosAssociados.Rows.RemoveAt(0);

            foreach (UENCentroCusto itemCentroCusto in uenSelecionada.lstCentrosCustos.OrderBy(x => x.descricaoCentroCusto).ToList())
            {
                gvCentrosCustosAssociados.Rows.Add(new object[] 
                {
                    itemCentroCusto.idCentroCusto, 
                    itemCentroCusto.codigoCentroCusto, 
                    itemCentroCusto.descricaoCentroCusto
                });
            }
        }

        private void CarregarUEN(UEN uenSelecionada)
        {
            try
            {
                lbCodigo.Text = uenSelecionada.idUEN.ToString();
                tbDescricao.Text = uenSelecionada.Descricao;
                chkAdministrativo.Checked = uenSelecionada.Administrativo == 1 ? true : false;

                this.CarregarCentrosCustosCadastrados(lstCentrosCustosCadastrados);
                this.CarregarCentrosCustosAssociados();
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
            int idCentroCustoCadastrado = 0;
            string codigoCentroCustoCadastrado = string.Empty;
            string descricaoCentroCustoCadastrado = string.Empty;

            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvCentrosCustosCadastrados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idCentroCustoCadastrado = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                codigoCentroCustoCadastrado = linhaSelecionada.Cells[1].Value.ToString();
                descricaoCentroCustoCadastrado = linhaSelecionada.Cells[2].Value.ToString();

                if (uenSelecionada.lstCentrosCustos.Exists(x => x.idCentroCusto == idCentroCustoCadastrado))
                    MessageBox.Show("O Centro de Custo " + descricaoCentroCustoCadastrado + " já está associado a essa UEN.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    uenSelecionada.lstCentrosCustos.Add(new UENCentroCusto()
                    {
                        idCentroCusto = idCentroCustoCadastrado,
                        codigoCentroCusto = codigoCentroCustoCadastrado,
                        descricaoCentroCusto = descricaoCentroCustoCadastrado                         
                    });
                }
            }

            this.CarregarCentrosCustosAssociados();
        }

        private void btRem_Click(object sender, EventArgs e)
        {
            int idCentroCustoAssociado = 0;

            DataGridViewSelectedRowCollection lstLinhasSelecionadas = gvCentrosCustosAssociados.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstLinhasSelecionadas)
            {
                idCentroCustoAssociado = int.Parse(linhaSelecionada.Cells[0].Value.ToString());
                uenSelecionada.lstCentrosCustos.RemoveAll(item => item.idCentroCusto == idCentroCustoAssociado);
            }

            CarregarCentrosCustosAssociados();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idUEN = 0;
                        
            uenSelecionada.Descricao = tbDescricao.Text;
            uenSelecionada.Administrativo = chkAdministrativo.Checked ? 1 : 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (uenSelecionada.idUEN == 0)
                {
                    msgRetorno = bizUEN.IncluirUEN(UsuarioLogado.idUsuario, uenSelecionada, out idUEN);
                    acaoSelecionada = "Inclusão";
                    lbCodigo.Text = idUEN.ToString();
                    uenSelecionada.idUEN = idUEN;
                }
                else
                {
                    msgRetorno = bizUEN.AlterarUEN(uenSelecionada);
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
            int idCentroCusto = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                idCentroCusto = int.Parse(lbCodigo.Text);

                if (idCentroCusto != 0)
                {
                    msgRetorno = bizUEN.ValidarExclusao(uenSelecionada);

                    if (msgRetorno == string.Empty)
                    {
                        if (MessageBox.Show("Confirma exclusão da UEN?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            bizUEN.ExcluirUEN(uenSelecionada);                             
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

        private void tbFiltroCentroCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbFiltroCentroCusto_TextChanged(object sender, EventArgs e)
        {
            var lstCentrosCustosFiltrado = from lstCCFiltro in lstCentrosCustosCadastrados
                   where lstCCFiltro.Descricao.ToUpper().Contains(tbFiltroDespesa.Text.Trim().ToUpper())
                   select lstCCFiltro ;
            
            this.CarregarCentrosCustosCadastrados(lstCentrosCustosFiltrado.ToList());            
        }

        private void UENManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                this.CarregarCentrosCustos();

                if (uenSelecionada.idUEN == 0)
                    LimparCampos();
                else
                    CarregarUEN(uenSelecionada);

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