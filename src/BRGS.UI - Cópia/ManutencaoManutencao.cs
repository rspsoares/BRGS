using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class ManutencaoManutencao : Form
    {
        private Manutencao manutencaoSelecionada = new Manutencao();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public ManutencaoManutencao(Manutencao _manutencaoSelecionada)
        {
            InitializeComponent();
            manutencaoSelecionada = _manutencaoSelecionada;
        }

        private void ManutencaoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                this.CarregarComboVeiculos();

                if (manutencaoSelecionada.idManutencao > 0)
                    this.CarregarManutencao();
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

        private void CarregarManutencao()
        {
            manutencaoSelecionada = bizVeiculo.PesquisarManutencoes(new Manutencao() { idManutencao = manutencaoSelecionada.idManutencao })[0];

            tbNumero.Text = manutencaoSelecionada.numeroManutencao;
            cbPlaca.SelectedValue = manutencaoSelecionada.idVeiculo;
            tbDescricao.Text = manutencaoSelecionada.Descricao;
            tbData.Value = manutencaoSelecionada.dataManutencao;
            tbValor.Text = helper.FormatarValorMoeda(manutencaoSelecionada.Valor.ToString());
            tbNumeroOP.Text = manutencaoSelecionada.numeroOP;
            tbStatusOP.Text = manutencaoSelecionada.statusOP;
            tbValor.Enabled = false;
        }

        private void CarregarComboVeiculos()
        {
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstVeiculos.Add(new Veiculo() { idVeiculo = 0, Placa = "--Selecione--" });
                lstVeiculos.AddRange(bizVeiculo.PesquisarVeiculoCombo());

                cbPlaca.DataSource = lstVeiculos;
                cbPlaca.DisplayMember = "Placa";
                cbPlaca.ValueMember = "idVeiculo";
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

        private void cbPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            tbValor.Text = helper.FormatarValorMoeda(tbValor.Text);
        }

        private void PopularEntidade()
        {
            manutencaoSelecionada.idVeiculo = int.Parse(cbPlaca.SelectedValue.ToString());
            manutencaoSelecionada.Descricao = tbDescricao.Text;
            manutencaoSelecionada.dataManutencao = tbData.Value;
            manutencaoSelecionada.Valor = decimal.Parse(tbValor.Text);
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idManutencao = 0;
            
            try
            {
                this.PopularEntidade();

                if (manutencaoSelecionada.idManutencao == 0)
                {
                    msgRetorno = bizVeiculo.IncluirManutencao(manutencaoSelecionada, out idManutencao);
                    manutencaoSelecionada.idManutencao = idManutencao;
                    acaoSelecionada = "Inclusão";
                }
                else
                {
                    msgRetorno = bizVeiculo.AlterarManutencao(manutencaoSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (manutencaoSelecionada.idOP == 0)
                {
                    ManutencaoGeracaoOP form = new ManutencaoGeracaoOP(manutencaoSelecionada);
                    form.ShowDialog();
                    this.Close();
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
                if (manutencaoSelecionada.idManutencao == 0)
                    return;

                msgRetorno = ValidarExclusaoManutencao();

                if (msgRetorno == string.Empty)
                {
                    if (MessageBox.Show("Confirma exclusão da manutenção ?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizVeiculo.ExcluirManutencao(manutencaoSelecionada);
                    MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private string ValidarExclusaoManutencao()
        {
            string msgRetorno = string.Empty;

            if (manutencaoSelecionada.idOP > 0)
                msgRetorno += Environment.NewLine + "Já foi gerada uma OP para essa manutenção";

            return msgRetorno;
        }
    }
}
