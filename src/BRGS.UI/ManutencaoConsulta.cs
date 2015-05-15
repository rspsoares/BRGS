using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class ManutencaoConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        
        public ManutencaoConsulta()
        {
            InitializeComponent();
        }

         private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Manutencao());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Manutencao manutencaoFiltro = new Manutencao();
                manutencaoFiltro = (Manutencao)new ClassProperties().RetornarObjetoFiltro(new Manutencao(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (manutencaoFiltro != null)
                    CarregarGrid(manutencaoFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Manutencao ManutencaoFiltro)
        {
            List<Manutencao> lstManutencaos = new List<Manutencao>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstManutencaos = bizVeiculo.PesquisarManutencoes(ManutencaoFiltro).OrderBy(x => x.numeroManutencao).ToList();

                LimparGrid();

                gvManutencoes.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                gvManutencoes.Columns[5].DefaultCellStyle.Format = "N2";

                foreach (Manutencao itemManutencao in lstManutencaos)
                {
                    gvManutencoes.Rows.Add(new object[] 
                    {
                        itemManutencao.idManutencao, 
                        itemManutencao.numeroManutencao,
                        itemManutencao.placaVeiculo + " - " + itemManutencao.descricaoVeiculo,
                        itemManutencao.Descricao,
                        itemManutencao.dataManutencao.Date,
                        itemManutencao.Valor,
                        itemManutencao.idOP,
                        string.IsNullOrEmpty(itemManutencao.numeroOP) ? string.Empty : itemManutencao.numeroOP,
                        itemManutencao.statusOP 
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
            while (gvManutencoes.Rows.Count > 0)
                gvManutencoes.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            ManutencaoManutencao form = new ManutencaoManutencao(new Manutencao());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarManutencao();
        }

        private void VisualizarManutencao()
        {
            int linhaGrid = 0;

            if (gvManutencoes.RowCount == 0)
                return;

            linhaGrid = gvManutencoes.SelectedCells[0].RowIndex;

            Manutencao Manutencao = new Manutencao()
            {
               idManutencao = int.Parse(gvManutencoes[0, linhaGrid].Value.ToString())              
            };

            ManutencaoManutencao form = new ManutencaoManutencao(Manutencao);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvManutencoes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarManutencao();
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

        private void ManutencaoConsulta_Load(object sender, EventArgs e)
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