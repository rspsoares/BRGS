using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class UsoVeiculosManutencao : Form
    {
        private UsoVeiculo usoSelecionado = new UsoVeiculo();
        private Manutencao manutencaoSelecionada = new Manutencao();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public UsoVeiculosManutencao(UsoVeiculo _usoSelecionado)
        {
            InitializeComponent();
            usoSelecionado = _usoSelecionado;
        }

        private void UsoVeiculosManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                CarregarComboVeiculos();
                CarregarComboMotoristas();

                if (usoSelecionado.idUso > 0)
                    CarregarUso();
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

        private void CarregarUso()
        {
            usoSelecionado = bizVeiculo.PesquisarUsoVeiculos(new UsoVeiculo() { idUso = usoSelecionado.idUso })[0];
                        
            cbPlaca.SelectedValue = usoSelecionado.idVeiculo;
            cbMotorista.SelectedValue = usoSelecionado.idMotorista;
            tbSaidaData.Value = usoSelecionado.dataSaida.Date;
            tbSaidaHora.Value =  usoSelecionado.dataSaida;

            if (usoSelecionado.dataChegada == SqlDateTime.MinValue)
            {
                tbChegadaData.Value = DateTime.Today;
                tbChegadaHora.Value = DateTime.Now;
                chkRetorno.Checked = false;
            }
            else
            {
                tbChegadaData.Value = usoSelecionado.dataChegada.Date;
                tbChegadaHora.Value = usoSelecionado.dataChegada;
                chkRetorno.Checked = true;
            }            
            
            tbObservacao.Text = usoSelecionado.Observacoes;
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

        private void CarregarComboMotoristas()
        {
            List<Motorista> lstMotoristas = new List<Motorista>();
            BIZMotorista bizMotorista = new BIZMotorista();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstMotoristas.Add(new Motorista() { idMotorista = 0, Nome = "--Selecione--" });
                lstMotoristas.AddRange(bizMotorista.PesquisarMotorista(new Motorista()).OrderBy(x => x.Nome));

                cbMotorista.DataSource = lstMotoristas;
                cbMotorista.DisplayMember = "Nome";
                cbMotorista.ValueMember = "idMotorista";
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
       
        private void PopularEntidade()
        {
            usoSelecionado.idVeiculo = int.Parse(cbPlaca.SelectedValue.ToString());
            usoSelecionado.idMotorista = int.Parse(cbMotorista.SelectedValue.ToString());

            usoSelecionado.dataSaida = new DateTime(
                tbSaidaData.Value.Year, tbSaidaData.Value.Month, tbSaidaData.Value.Day, tbSaidaHora.Value.Hour, tbSaidaHora.Value.Minute, tbSaidaHora.Value.Second);
            
            usoSelecionado.dataChegada = chkRetorno.Checked ?
                new DateTime(tbChegadaData.Value.Year, tbChegadaData.Value.Month, tbChegadaData.Value.Day, tbChegadaHora.Value.Hour, tbChegadaHora.Value.Minute, tbChegadaHora.Value.Second) : 
                DateTime.MinValue;
            
            usoSelecionado.Observacoes = tbObservacao.Text;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idUso = 0;

            try
            {
                PopularEntidade();

                if (usoSelecionado.idUso == 0)
                {
                    msgRetorno = bizVeiculo.IncluirUsoVeiculo(usoSelecionado, out idUso);
                    usoSelecionado.idUso = idUso;
                    acaoSelecionada = "Inclusão";
                }
                else
                {
                    msgRetorno = bizVeiculo.AlterarUsoVeiculo(usoSelecionado);
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
                if (usoSelecionado.idUso == 0)
                    return;

                if (MessageBox.Show("Confirma exclusão do Uso ?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                bizVeiculo.ExcluirUsoVeiculo(usoSelecionado);
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

        private void cbMotorista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkRetorno_CheckedChanged(object sender, EventArgs e)
        {
            tbChegadaData.Enabled = chkRetorno.Checked;
            tbChegadaHora.Enabled = chkRetorno.Checked;
        }
    }
}
