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
    public partial class MultaManutencao : Form
    {
        private Multa multaSelecionada = new Multa();
        private List<MultaGravidade> lstGravidades = new List<MultaGravidade>();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public MultaManutencao(Multa _multaSelecionada)
        {
            InitializeComponent();
            multaSelecionada = _multaSelecionada;
        }

        private void MultaManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                this.CarregarComboGravidades();

                if (multaSelecionada.idMulta > 0)
                    this.CarregarMulta();
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

        private void CarregarMulta()
        {
            multaSelecionada = bizVeiculo.PesquisarMultas(new Multa() { idMulta = multaSelecionada.idMulta })[0];

            tbCodigo.Text = multaSelecionada.Codigo;
            tbDesdobramento.Text = multaSelecionada.Desdobramento.ToString();
            tbDescricao.Text = multaSelecionada.Descricao;
            tbInfrator.Text = multaSelecionada.Infrator;
            tbPontos.Text = multaSelecionada.Pontos.ToString();
            cbGravidade.SelectedValue = multaSelecionada.idGravidade;
            tbValor.Text = helper.FormatarValorMoeda(multaSelecionada.Valor.ToString());
            tbOrgaoCompetente.Text = multaSelecionada.orgaoCompetente;
        }

        private void CarregarComboGravidades()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstGravidades.Add(new MultaGravidade() { idGravidade = 0, Descricao = "--Selecione--" });
                lstGravidades.AddRange(bizVeiculo.PesquisarMultasGravidade(new MultaGravidade()));

                cbGravidade.DataSource = lstGravidades;
                cbGravidade.DisplayMember = "Descricao";
                cbGravidade.ValueMember = "idGravidade";
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

        private void cbGravidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void PopularEntidade()
        {
            multaSelecionada.Codigo = tbCodigo.Text;
            multaSelecionada.Desdobramento = int.Parse(tbDesdobramento.Text);
            multaSelecionada.Descricao = tbDescricao.Text;
            multaSelecionada.Infrator = tbInfrator.Text;
            multaSelecionada.Pontos = int.Parse(tbPontos.Text);
            multaSelecionada.idGravidade = int.Parse(cbGravidade.SelectedValue.ToString());            
            multaSelecionada.orgaoCompetente = tbOrgaoCompetente.Text;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idMulta = 0;

            try
            {
                this.PopularEntidade();

                if (multaSelecionada.idMulta == 0)
                {
                    msgRetorno = bizVeiculo.IncluirMulta(multaSelecionada, out idMulta);
                    multaSelecionada.idMulta = idMulta;
                    acaoSelecionada = "Inclusão";
                }
                else
                {
                    msgRetorno = bizVeiculo.AlterarMulta(multaSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (multaSelecionada.idMulta == 0)
                    return;
               
                if (MessageBox.Show("Confirma exclusão da multa?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                bizVeiculo.ExcluirMulta(multaSelecionada);
                MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();               
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

        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbDesdobramento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
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

        private void tbInfrator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPontos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbOrgaoCompetente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPontos_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbPontos_Leave(object sender, EventArgs e)
        {
            tbPontos.Text = helper.FormatarValorMoeda(tbPontos.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void cbGravidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultaGravidade gravidade = new MultaGravidade();

            if (cbGravidade.FindStringExact(cbGravidade.Text) == -1 || cbGravidade.SelectedIndex == 0)
                tbValor.Text = "0,00";
            else
            {
                gravidade = lstGravidades.FirstOrDefault(x => x.idGravidade == int.Parse(cbGravidade.SelectedValue.ToString()));
                tbValor.Text = helper.FormatarValorMoeda(gravidade.Valor.ToString());
            }
        }

        private void tbDesdobramento_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbDesdobramento_Leave(object sender, EventArgs e)
        {
            tbDesdobramento.Text = helper.FormatarValorMoeda(tbDesdobramento.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }
    }
}
