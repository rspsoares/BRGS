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
    public partial class VeiculoManutencao : Form
    {
        private Veiculo veiculoSelecionado = new Veiculo();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public VeiculoManutencao(Veiculo _veiculoSelecionado)
        {
            InitializeComponent();
            veiculoSelecionado = _veiculoSelecionado;
        }

        private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbAno_Leave(object sender, EventArgs e)
        {
            tbAno.Text = helper.FormatarValorMoeda(tbAno.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void tbModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127)
                e.Handled = true;
        }

        private void tbModelo_Leave(object sender, EventArgs e)
        {
            tbModelo.Text = helper.FormatarValorMoeda(tbModelo.Text).Replace(",00", string.Empty).Replace(".", string.Empty);
        }

        private void tbRenavam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbChassi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbRastreador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbSeguradora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkPossuiSeguro_CheckedChanged(object sender, EventArgs e)
        {
            tbSeguradora.Enabled = chkPossuiSeguro.Checked;
            tbDataVencimentoSeguro.Enabled = chkPossuiSeguro.Checked;
        }

        private void VeiculoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                if (veiculoSelecionado.idVeiculo != 0)
                    this.CarregarVeiculo();
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

        private void CarregarVeiculo()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                veiculoSelecionado = bizVeiculo.PesquisarVeiculos(new Veiculo() { idVeiculo = veiculoSelecionado.idVeiculo })[0];
                tbDescricao.Text = veiculoSelecionado.Descricao;
                tbPlaca.Text = veiculoSelecionado.Placa;
                tbCor.Text = veiculoSelecionado.Cor;
                tbAno.Text = veiculoSelecionado.Ano.ToString();
                tbModelo.Text = veiculoSelecionado.Modelo.ToString();
                tbRenavam.Text = veiculoSelecionado.Renavam;
                tbChassi.Text = veiculoSelecionado.Chassi;
                tbRastreador.Text = veiculoSelecionado.Rastreador;
                chkSemParar.Checked = veiculoSelecionado.semParar == 1 ? true : false;

                if (veiculoSelecionado.Seguradora != string.Empty)
                {
                    chkPossuiSeguro.Checked = true;
                    tbSeguradora.Text = veiculoSelecionado.Seguradora;
                    tbDataVencimentoSeguro.Value = veiculoSelecionado.dataVencimentoSeguro;
                }

                tbdataVencimentoIPVA.Value = veiculoSelecionado.dataVencimentoIPVA.Date;
                tbDataVencimentoDPVAT.Value = veiculoSelecionado.dataVencimentoDPVAT.Date;

                this.CarregarAbastecimentos();
                this.CarregarManutencoes();
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

        private void CarregarAbastecimentos()
        {
            while (gvAbastecimentos.Rows.Count > 0)
                gvAbastecimentos.Rows.RemoveAt(0);

            if (veiculoSelecionado.lstAbastecimentos == null)
                return;

            gvAbastecimentos.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvAbastecimentos.Columns[2].DefaultCellStyle.Format = "N2";

            foreach (Abastecimento itemAbastecimento in veiculoSelecionado.lstAbastecimentos)
            {
                gvAbastecimentos.Rows.Add(new object[] 
                {                 
                    itemAbastecimento.Data,                    
                    itemAbastecimento.nomeMotorista,
                    decimal.Parse(helper.FormatarValorMoeda(itemAbastecimento.Valor.ToString()))
                });
            }
        }

        private void CarregarManutencoes()
        {
            while (gvManutencoes.Rows.Count > 0)
                gvManutencoes.Rows.RemoveAt(0);

            if (veiculoSelecionado.lstManutencoes == null)
                return;

            gvManutencoes.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            gvManutencoes.Columns[2].DefaultCellStyle.Format = "N2";

            foreach (Manutencao itemManutencao in veiculoSelecionado.lstManutencoes)
            {
                gvManutencoes.Rows.Add(new object[] 
                {                 
                    itemManutencao.dataManutencao,                    
                    itemManutencao.Descricao,
                    decimal.Parse(helper.FormatarValorMoeda(itemManutencao.Valor.ToString()))
                });
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idVeiculo = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.PopularEntidade();

                if (veiculoSelecionado.idVeiculo == 0)
                {
                    msgRetorno = bizVeiculo.IncluirVeiculo(veiculoSelecionado, out idVeiculo);
                    acaoSelecionada = "Inclusão";
                    veiculoSelecionado.idVeiculo = idVeiculo;
                }
                else
                {
                    msgRetorno = bizVeiculo.AlterarVeiculo(veiculoSelecionado);
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
            veiculoSelecionado.Descricao = tbDescricao.Text;
            veiculoSelecionado.Placa = tbPlaca.Text;
            veiculoSelecionado.Cor = tbCor.Text;
            veiculoSelecionado.Ano = int.Parse(tbAno.Text);
            veiculoSelecionado.Modelo = int.Parse(tbModelo.Text);
            veiculoSelecionado.Renavam = tbRenavam.Text;
            veiculoSelecionado.Chassi = tbChassi.Text;
            veiculoSelecionado.Rastreador = tbRastreador.Text;
            veiculoSelecionado.semParar = chkSemParar.Checked ? 1 : 0;
            veiculoSelecionado.Seguradora = chkPossuiSeguro.Checked ? tbSeguradora.Text : string.Empty;
            veiculoSelecionado.dataVencimentoSeguro = chkPossuiSeguro.Checked ? tbDataVencimentoSeguro.Value : DateTime.MinValue;
            veiculoSelecionado.dataVencimentoIPVA = tbdataVencimentoIPVA.Value;
            veiculoSelecionado.dataVencimentoDPVAT = tbDataVencimentoDPVAT.Value;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string Msg = string.Empty;

            if (veiculoSelecionado.idVeiculo == 0)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Msg = bizVeiculo.ValidarExclusaoVeiculo(veiculoSelecionado);

                if (Msg == string.Empty)
                {
                    if (MessageBox.Show("Confirma exclusão do veículo?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizVeiculo.ExcluirVeiculo(veiculoSelecionado);
                    MessageBox.Show("Veículo excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
