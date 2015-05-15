using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class AbastecimentoConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        
        public AbastecimentoConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Abastecimento());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Abastecimento abastecimentoFiltro = new Abastecimento();
                abastecimentoFiltro = (Abastecimento)new ClassProperties().RetornarObjetoFiltro(new Abastecimento(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (abastecimentoFiltro != null)
                    CarregarGrid(abastecimentoFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Abastecimento abastecimentoFiltro)
        {
            List<Abastecimento> lstAbastecimentos = new List<Abastecimento>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstAbastecimentos = bizVeiculo.PesquisarAbastecimentos(abastecimentoFiltro).OrderBy(x => x.numeroAbastecimento).ToList();

                LimparGrid();

                gvAbastecimentos.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
                
                foreach (Abastecimento itemAbastecimento in lstAbastecimentos)
                {
                    gvAbastecimentos.Rows.Add(new object[] 
                    {
                        itemAbastecimento.idAbastecimento, 
                        itemAbastecimento.numeroAbastecimento,
                        itemAbastecimento.nomeFornecedor,
                        itemAbastecimento.placaVeiculo + " - " + itemAbastecimento.descricaoVeiculo,
                        itemAbastecimento.nomeMotorista, 
                        itemAbastecimento.nomeObra,
                        itemAbastecimento.descricaoCentroCusto,
                        itemAbastecimento.Data.Date,
                        itemAbastecimento.valorTotal,
                        itemAbastecimento.idOP, 
                        string.IsNullOrEmpty(itemAbastecimento.numeroOP) ? string.Empty : itemAbastecimento.numeroOP,
                        itemAbastecimento.statusOP,
                        itemAbastecimento.idFornecedor
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

            this.Cursor = Cursors.Default;
        }

        private void LimparGrid()
        {
            while (gvAbastecimentos.Rows.Count > 0)
                gvAbastecimentos.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            AbastecimentoManutencao form = new AbastecimentoManutencao(new Abastecimento());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarAbastecimento();
        }

        private void VisualizarAbastecimento()
        {
            int linhaGrid = 0;

            if (gvAbastecimentos.RowCount == 0)
                return;

            linhaGrid = gvAbastecimentos.SelectedCells[0].RowIndex;

            Abastecimento abastecimento = new Abastecimento()
            {
               idAbastecimento = int.Parse(gvAbastecimentos[0, linhaGrid].Value.ToString())              
            };

            AbastecimentoManutencao form = new AbastecimentoManutencao(abastecimento);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvAbastecimentos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarAbastecimento();
        }

        private void cbPesquisaCampo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbPesquisaValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void AbastecimentoConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                CarregarCamposPesquisa();
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

        private void btGerarOP_Click(object sender, EventArgs e)
        {
            BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
            OrdemPagamento ordemPagamento = new OrdemPagamento();
            string msgRetorno = string.Empty;
            DateTime dataVecimentoOP = new DateTime();
            int idOPSelecionada = 0;
            int idFornecedor = 0;
       
            try
            {
                msgRetorno = this.ValidarGeracaoOP(out idFornecedor);

                if (msgRetorno == string.Empty)
                {
                    using (AbastecimentoVencimentoOP formVencimentoOP = new AbastecimentoVencimentoOP())
                    {
                        DialogResult dr = formVencimentoOP.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            dataVecimentoOP = formVencimentoOP.tbData.Value;
                            if (formVencimentoOP.chkAdicionarOP.Checked)
                                idOPSelecionada = int.Parse(formVencimentoOP.cbOPAbastecimento.SelectedValue.ToString());
                        }
                        else
                            return;
                    }

                    if (idOPSelecionada == 0)
                    {
                        ordemPagamento.idOrdemPagamento = 0;
                        ordemPagamento.idEmpresa = 0;
                        ordemPagamento.idFavorecido = idFornecedor;
                        ordemPagamento.idObraEtapa = 0;
                        ordemPagamento.idSolicitante = UsuarioLogado.idUsuario;
                        ordemPagamento.nomeSolicitante = UsuarioLogado.Nome;
                        ordemPagamento.dataSolicitacao = DateTime.Now;
                        ordemPagamento.Autorizado = string.Empty;
                        ordemPagamento.Observacao = string.Empty;
                        ordemPagamento.lstItens = new List<OrdemPagamentoItem>();
                        ordemPagamento.lstItens.AddRange(GerarListadeItens(dataVecimentoOP));
                    }
                    else
                    {
                        ordemPagamento = bizOP.PesquisarOrdemPagamento(new OrdemPagamento() { idOrdemPagamento = idOPSelecionada })[0];
                        ordemPagamento.lstItens = bizOP.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idOrdemPagamento = idOPSelecionada });
                        ordemPagamento.lstItens.AddRange(GerarListadeItens(dataVecimentoOP));
                    }

                    OrdemPagamentoManutencao form = new OrdemPagamentoManutencao(ordemPagamento, false);
                    form.ShowDialog();

                    this.CarregarGrid(new Abastecimento());
                }
                else
                    MessageBox.Show("Atenção" + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private List<OrdemPagamentoItem> GerarListadeItens(DateTime dataVencimentoOP)
        {
            List<OrdemPagamentoItem> lstItens = new List<OrdemPagamentoItem>();
            Abastecimento itemAbastecimento = new Abastecimento();
            DataGridViewSelectedRowCollection lstItensSelecionados = gvAbastecimentos.SelectedRows;

            foreach (DataGridViewRow linhaSelecionada in lstItensSelecionados)
            {
                itemAbastecimento = bizVeiculo.PesquisarAbastecimentos(new Abastecimento() { idAbastecimento = int.Parse(linhaSelecionada.Cells[0].Value.ToString()) })[0];

                lstItens.Add(new OrdemPagamentoItem()
                {
                    idAbastecimento = itemAbastecimento.idAbastecimento,
                    idObraGastoRealizado = 0,
                    idUEN = itemAbastecimento.idUEN,
                    idCentroCusto = itemAbastecimento.idCentroCusto,
                    idDespesa = itemAbastecimento.idDespesa,
                    descricaoUEN = itemAbastecimento.descricaoUEN,
                    descricaoCentroCusto = itemAbastecimento.descricaoCentroCusto,
                    descricaoDespesa = itemAbastecimento.descricaoDespesa,
                    Valor = itemAbastecimento.valorTotal,
                    dataVencimento = dataVencimentoOP,
                    numeroParcela = 1,
                    totalParcelas = 1
                });
            }

            return lstItens;
        }

        private string ValidarGeracaoOP(out int idFornecedor)
        {
            string msgRetorno = string.Empty;
            
            DataGridViewSelectedRowCollection lstItens = gvAbastecimentos.SelectedRows;

            if (lstItens.Count == 0)            
                msgRetorno += Environment.NewLine + "Favor selecionar alguma autorização de abastecimento";

            idFornecedor = int.Parse(lstItens[0].Cells[12].Value.ToString());
            
            foreach (DataGridViewRow linhaSelecionada in lstItens)
            {
                if (int.Parse(linhaSelecionada.Cells[12].Value.ToString()) != idFornecedor)
                {
                    msgRetorno += Environment.NewLine + "Não é permitido gerar uma OP com abastecimentos em postos diferentes";
                    break;
                }

                if (linhaSelecionada.Cells[10].Value.ToString() != string.Empty)
                {
                    msgRetorno += Environment.NewLine + "Já foi gerada OP para a autorização Nº " + linhaSelecionada.Cells[1].Value.ToString();
                    break;
                }

                if (decimal.Parse(linhaSelecionada.Cells[8].Value.ToString()) == decimal.Zero)
                {
                    msgRetorno += Environment.NewLine + "Favor informar os valores dos abastecimentos selecionados";
                    break;
                }
            }

            return msgRetorno;
        }
    }
}