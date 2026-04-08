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
    public partial class EmpilhadeiraManutencao : Form
    {
        private Empilhadeira empilhadeiraSelecionada = new Empilhadeira();
        private BIZObra bizObra = new BIZObra();        
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZEmpilhadeira bizEmpilhadeira = new BIZEmpilhadeira();
        private List<ObraEtapa> lstLicitacoesCliente = new List<ObraEtapa>();
        private List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();

        private Helper helper = new Helper();
        
        public EmpilhadeiraManutencao(Empilhadeira _empilhadeiraSelecionada)
        {
            InitializeComponent();
            empilhadeiraSelecionada = _empilhadeiraSelecionada;
        }

        private void tbNumeroSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCombustivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbLicitacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbLotada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void cbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbNotaFiscal_KeyDown(object sender, KeyEventArgs e)
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

        private void tbTorre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbTorre_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbTorre_Leave(object sender, EventArgs e)
        {
            tbTorre.Text = helper.FormatarValorMoeda(tbTorre.Text);
        }

        private void tbCapacidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbCapacidade_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            tbValor.Text = helper.FormatarValorMoeda(tbValor.Text);
        }

        private void EmpilhadeiraManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                CarregarCombos();

                if (empilhadeiraSelecionada.ID != 0)
                    CarregarEmpilhadeira();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(helper.RetornarMensagemPadraoErroGenerico(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogErro logErro = new LogErro()
                {
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(logErro);
            }
            finally 
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarEmpilhadeira()
        {
            empilhadeiraSelecionada = bizEmpilhadeira.PesquisarEmpilhadeiras(new Empilhadeira() { ID = empilhadeiraSelecionada.ID })[0];
            //empresaSelecionada.lstContasBancarias = bizEmpresa.PesquisarEmpresaContaBancaria(new EmpresaContaBancaria() { idEmpresa = empresaSelecionada.idEmpresa });

            tbNumeroSerie.Text = empilhadeiraSelecionada.NumeroSerie;
            tbMarca.Text = empilhadeiraSelecionada.Marca;
            tbModelo.Text = empilhadeiraSelecionada.Modelo;
            tbCombustivel.Text = empilhadeiraSelecionada.Combustivel;
            tbTorre.Text = empilhadeiraSelecionada.Torre.ToString();
            tbCapacidade.Text = empilhadeiraSelecionada.CapacidadeCarga.ToString();
            cbClientes.SelectedValue = empilhadeiraSelecionada.IdCliente;
            cbLicitacao.SelectedValue = empilhadeiraSelecionada.IdObraEtapa;
            tbLotada.Text = empilhadeiraSelecionada.Lotada;
            cbEmpresa.SelectedValue = empilhadeiraSelecionada.IdEmpresa;
            tbNotaFiscal.Text = empilhadeiraSelecionada.NotaFiscal;
            dtpDataCompra.Value = empilhadeiraSelecionada.DataCompra;
            tbAcessorios.Text = empilhadeiraSelecionada.Acessorios;
        }

        private void CarregarCombos()
        {
            CarregarObrasEtapas();
            CarregarComboClientes();
            CarregarComboEmpresas();
        }

        private void CarregarComboClientes()
        {
            BIZCliente bizCliente = new BIZCliente();
            List<Cliente> lstClientes = new List<Cliente>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstClientes.Add(new Cliente() { idCliente = 0, Nome = "--Selecione--" });
                lstClientes.AddRange(bizCliente.PesquisarCliente(new Cliente()).OrderBy(u => u.Nome));

                cbClientes.DataSource = lstClientes;
                cbClientes.DisplayMember = "Nome";
                cbClientes.ValueMember = "idCliente";
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

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientes.SelectedIndex == 0)
            {
                cbLicitacao.DataSource = null;
                cbLicitacao.BindingContext = new BindingContext();
                return;
            }

            lstLicitacoesCliente = new List<ObraEtapa>
            {
                new ObraEtapa() { idObraEtapa = 0, numeroLicitacao = "--Selecione--" }
            };

            if (cbClientes.SelectedValue != null)
            {
                lstLicitacoesCliente.AddRange(lstObrasEtapas.Where(x => x.idCliente == int.Parse(cbClientes.SelectedValue.ToString())).OrderBy(y => y.numeroLicitacao).ThenBy(z => z.Descricao));

                foreach (ObraEtapa itemLicitacao in lstLicitacoesCliente)
                    itemLicitacao.numeroLicitacao = itemLicitacao.numeroLicitacao + " - " + itemLicitacao.Descricao;
            }

            cbLicitacao.DataSource = lstLicitacoesCliente;
            cbLicitacao.DisplayMember = "numeroLicitacao";
            cbLicitacao.ValueMember = "idObraEtapa";
        }

        private void CarregarObrasEtapas()
        {
            lstObrasEtapas = new List<ObraEtapa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstObrasEtapas.AddRange(bizObra.PesquisarObraEtapa(new ObraEtapa()));
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

        private void CarregarComboEmpresas()
        {
            List<Empresa> lstEmpresas = new List<Empresa>();
            BIZEmpresa bizEmpresa = new BIZEmpresa();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstEmpresas.Add(new Empresa() { idEmpresa = 0, razaoSocial = "--Selecione--" });
                lstEmpresas.AddRange(bizEmpresa.PesquisarEmpresa(new Empresa()).OrderBy(x => x.razaoSocial).ToList());

                cbEmpresa.DataSource = lstEmpresas;
                cbEmpresa.DisplayMember = "razaoSocial";
                cbEmpresa.ValueMember = "idEmpresa";
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

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idEmpilhadeira = 0;
            int idEmpresa = 0;
            int idCliente = 0;
            int idObraEtapa = 0;

            if (cbEmpresa.SelectedIndex > 0 && cbEmpresa.FindStringExact(cbEmpresa.Text) != -1)
                idEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());

            if (cbClientes.SelectedIndex > 0 && cbClientes.FindStringExact(cbClientes.Text) != -1)
                idCliente = int.Parse(cbClientes.SelectedValue.ToString());

            if (cbLicitacao.SelectedIndex > 0 && cbLicitacao.FindStringExact(cbLicitacao.Text) != -1)
                idObraEtapa = int.Parse(cbLicitacao.SelectedValue.ToString());

            empilhadeiraSelecionada.NumeroSerie = tbNumeroSerie.Text;
            empilhadeiraSelecionada.Marca = tbMarca.Text;
            empilhadeiraSelecionada.Modelo = tbModelo.Text;
            empilhadeiraSelecionada.Combustivel = tbCombustivel.Text;
            empilhadeiraSelecionada.Torre = decimal.Parse(tbTorre.Text);
            empilhadeiraSelecionada.CapacidadeCarga = int.Parse(tbCapacidade.Text);
            empilhadeiraSelecionada.IdCliente = idCliente;
            empilhadeiraSelecionada.IdObraEtapa = idObraEtapa;
            empilhadeiraSelecionada.Lotada = tbLotada.Text;
            empilhadeiraSelecionada.IdEmpresa = idEmpresa;
            empilhadeiraSelecionada.NotaFiscal = tbNotaFiscal.Text;
            empilhadeiraSelecionada.DataCompra = dtpDataCompra.Value;
            empilhadeiraSelecionada.Acessorios = tbAcessorios.Text;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (empilhadeiraSelecionada.ID == 0)
                {
                    msgRetorno = bizEmpilhadeira.IncluirEmpilhadeira(empilhadeiraSelecionada, out idEmpilhadeira);
                    acaoSelecionada = "Inclusão";
                    empilhadeiraSelecionada.ID = idEmpilhadeira;
                }
                else
                {
                    msgRetorno = bizEmpilhadeira.AlterarEmpilhadeira(empilhadeiraSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)
                {
                    //TODO: Carregar grid histórico
                    //CarregarGridHistorico();                    
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            this.Cursor = Cursors.Default;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            try
            {
                if (empilhadeiraSelecionada.ID != 0)
                {
                    if (MessageBox.Show("Confirma exclusão da Empilhadeira?", "Confirmação de exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        bizEmpilhadeira.ExcluirEmpilhadeira(empilhadeiraSelecionada);
                        this.Cursor = Cursors.Default;
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
        }
    }
}
