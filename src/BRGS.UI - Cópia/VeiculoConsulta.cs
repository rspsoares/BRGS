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
using System.Data.SqlTypes;

namespace BRGS.UI
{
    public partial class VeiculoConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public VeiculoConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Veiculo());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Veiculo faseFiltro = new Veiculo();
                faseFiltro = (Veiculo)new ClassProperties().RetornarObjetoFiltro(new Veiculo(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (faseFiltro != null)
                    CarregarGrid(faseFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Veiculo veiculoFiltro)
        {           
            List<Veiculo> lstVeiculo = new List<Veiculo>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstVeiculo = bizVeiculo.PesquisarVeiculos(veiculoFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                gvVeiculos.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvVeiculos.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvVeiculos.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";

                foreach (Veiculo itemVeiculo in lstVeiculo)
                {
                    gvVeiculos.Rows.Add(new object[] 
                    {
                        itemVeiculo.idVeiculo, 
                        itemVeiculo.Descricao,
                        itemVeiculo.Placa,
                        itemVeiculo.Rastreador,
                        itemVeiculo.semParar == 1 ? "SIM" : "NÃO",
                        itemVeiculo.dataVencimentoSeguro == DateTime.MinValue || itemVeiculo.dataVencimentoSeguro == SqlDateTime.MinValue ? (DateTime?)null : itemVeiculo.dataVencimentoSeguro.Date,
                        itemVeiculo.dataVencimentoIPVA == DateTime.MinValue || itemVeiculo.dataVencimentoIPVA == SqlDateTime.MinValue ? (DateTime?)null : itemVeiculo.dataVencimentoIPVA.Date,
                        itemVeiculo.dataVencimentoDPVAT == DateTime.MinValue || itemVeiculo.dataVencimentoDPVAT == SqlDateTime.MinValue ? (DateTime?)null : itemVeiculo.dataVencimentoDPVAT.Date,
                    });
                }

                helper.VerificarCorLinhaGrid(gvVeiculos);
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
            while (gvVeiculos.Rows.Count > 0)
                gvVeiculos.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            VeiculoManutencao form = new VeiculoManutencao(new Veiculo());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarVeiculo();
        }

        private void VisualizarVeiculo()
        {
            int linhaGrid = 0;

            if (gvVeiculos.RowCount == 0)
                return;

            linhaGrid = gvVeiculos.SelectedCells[0].RowIndex;

            Veiculo veiculo = new Veiculo()
            {
                idVeiculo = int.Parse(gvVeiculos[0, linhaGrid].Value.ToString())                
            };

            VeiculoManutencao form = new VeiculoManutencao(veiculo);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvVeiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarVeiculo();
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

        private void VeiculoConsulta_Load(object sender, EventArgs e)
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
    }
}

