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
    public partial class MultaOcorrenciaManutencao : Form
    {
        private MultaOcorrencia ocorrenciaSelecionada = new MultaOcorrencia();
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public MultaOcorrenciaManutencao(MultaOcorrencia _ocorrenciaSelecionada)
        {
            InitializeComponent();
            ocorrenciaSelecionada = _ocorrenciaSelecionada;
        }

        private void MultaOcorrenciaManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                this.CarregarCombos();

                if (ocorrenciaSelecionada.idOcorrencia > 0)
                    this.CarregarOcorrencia();
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

        private void CarregarCombos()
        {
            CarregarComboMultas();
            CarregarComboVeiculos();
            CarregarComboMotoristas();
        }

        private void CarregarComboMultas()
        {
            List<Multa> lstMultas = new List<Multa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstMultas.Add(new Multa() { idMulta = 0, Descricao = "--Selecione--" });
                lstMultas.AddRange(bizVeiculo.PesquisarMultas(new Multa()).OrderBy(x => x.Descricao));

                cbMultas.DataSource = lstMultas;
                cbMultas.DisplayMember = "Descricao";
                cbMultas.ValueMember = "idMulta";
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

        private void CarregarComboVeiculos()
        {
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstVeiculos.Add(new Veiculo() { idVeiculo = 0, Placa = "--Selecione--" });
                lstVeiculos.AddRange(bizVeiculo.PesquisarVeiculoCombo());

                cbVeiculos.DataSource = lstVeiculos;
                cbVeiculos.DisplayMember = "Placa";
                cbVeiculos.ValueMember = "idVeiculo";
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

                cbMotoristas.DataSource = lstMotoristas;
                cbMotoristas.DisplayMember = "Nome";
                cbMotoristas.ValueMember = "idMotorista";
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

        private void CarregarOcorrencia()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                ocorrenciaSelecionada = bizVeiculo.PesquisarMultaOcorrencia(new MultaOcorrencia() { idOcorrencia = ocorrenciaSelecionada.idOcorrencia })[0];
                
                cbMultas.SelectedValue = ocorrenciaSelecionada.idMulta;
                tbData.Value = ocorrenciaSelecionada.dataMulta;
                cbVeiculos.SelectedValue = ocorrenciaSelecionada.idVeiculo;
                cbMotoristas.SelectedValue = ocorrenciaSelecionada.idMotorista;
                tbNumeroOP.Text = ocorrenciaSelecionada.numeroOP;
                tbStatusOP.Text = ocorrenciaSelecionada.statusOP;
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

        private void cbMultas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbVeiculos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbMotoristas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbMultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Multa multa = new Multa();
            int idMulta = 0;

            if (cbMultas.SelectedIndex == 0)
            {
                tbCodigo.Text = string.Empty;
                tbInfrator.Text = string.Empty;
                tbPontos.Text = string.Empty;
                tbGravidade.Text = string.Empty;
                tbValor.Text = string.Empty;
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            idMulta = int.Parse(cbMultas.SelectedValue.ToString());

            try
            {
                multa = bizVeiculo.PesquisarMultas(new Multa() { idMulta = int.Parse(cbMultas.SelectedValue.ToString()) })[0];
                tbCodigo.Text = multa.Codigo;
                tbInfrator.Text = multa.Infrator;
                tbPontos.Text = multa.Pontos.ToString();
                tbGravidade.Text = multa.descricaoGravidade;
                tbValor.Text = helper.FormatarValorMoeda(multa.Valor.ToString());                
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

        private void FiltrarGridUsoVeiculo()
        {
            List<UsoVeiculo> lstUsos = new List<UsoVeiculo>();
            UsoVeiculo usoFiltro = new UsoVeiculo();
            
            usoFiltro.dataSaida = tbData.Value;
            usoFiltro.idVeiculo = cbVeiculos.SelectedIndex > 0 ? int.Parse(cbVeiculos.SelectedValue.ToString()) : 0;
            usoFiltro.idMotorista = cbMotoristas.SelectedIndex > 0 ? int.Parse(cbMotoristas.SelectedValue.ToString()) : 0;

            lstUsos = bizVeiculo.PesquisarUsoVeiculos(usoFiltro).OrderBy(x => x.dataSaida).ToList();
            
            LimparGrid();
            
            gvUsos.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            gvUsos.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            foreach (UsoVeiculo itemUso in lstUsos)
            {
                gvUsos.Rows.Add(new object[] 
                {
                    itemUso.idUso,
                    itemUso.Placa,
                    itemUso.nomeMotorista,
                    itemUso.dataSaida,
                    itemUso.dataChegada == DateTime.MinValue || itemUso.dataChegada == SqlDateTime.MinValue ? (DateTime?)null : itemUso.dataChegada,                        
                    itemUso.Observacoes
                });
            }
        }

        private void LimparGrid()
        {
            while (gvUsos.Rows.Count > 0)
                gvUsos.Rows.RemoveAt(0);
        }

        private void tbData_ValueChanged(object sender, EventArgs e)
        {
            FiltrarGridUsoVeiculo();
        }

        private void cbVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGridUsoVeiculo();
        }

        private void cbMotoristas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGridUsoVeiculo();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idOcorrencia = 0;

            try
            {
                PopularEntidade();

                if (ocorrenciaSelecionada.idOcorrencia == 0)
                {
                    msgRetorno = bizVeiculo.IncluirMultaOcorrencia(ocorrenciaSelecionada, out idOcorrencia);
                    ocorrenciaSelecionada.idOcorrencia = idOcorrencia;
                    acaoSelecionada = "Inclusão";
                }
                else
                {
                    msgRetorno = bizVeiculo.AlterarMultaOcorrencia(ocorrenciaSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else                
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (ocorrenciaSelecionada.idOP == 0)
                {
                    MultaOcorrenciaGeracaoOP form = new MultaOcorrenciaGeracaoOP(ocorrenciaSelecionada);
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

        private void PopularEntidade()
        {
            ocorrenciaSelecionada.idMulta = int.Parse(cbMultas.SelectedValue.ToString());
            ocorrenciaSelecionada.valorMulta = decimal.Parse(tbValor.Text);
            ocorrenciaSelecionada.dataMulta = tbData.Value;
            ocorrenciaSelecionada.idVeiculo = int.Parse(cbVeiculos.SelectedValue.ToString());
            ocorrenciaSelecionada.idMotorista = int.Parse(cbMotoristas.SelectedValue.ToString());
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (ocorrenciaSelecionada.idOcorrencia == 0)
                    return;

                msgRetorno = bizVeiculo.ValidarExclusaoMultaOcorrencia(ocorrenciaSelecionada);

                if (msgRetorno == string.Empty)
                {
                    if (MessageBox.Show("Confirma exclusão da Ocorrência ?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    bizVeiculo.ExcluirMultaOcorrencia(ocorrenciaSelecionada);
                    MessageBox.Show("Exclusão efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
        }
    }
}
