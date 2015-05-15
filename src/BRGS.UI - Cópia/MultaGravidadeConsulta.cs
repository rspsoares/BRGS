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
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class MultaGravidadeConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        
        public MultaGravidadeConsulta()
        {
            InitializeComponent();
        }
        
        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesNFS = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesNFS = new ClassProperties().RetornarPropriedadesClasse(new MultaGravidade());

            cbPesquisaCampo.DataSource = lstPropriedadesNFS;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                MultaGravidade gravidadeFiltro = new MultaGravidade();
                gravidadeFiltro = (MultaGravidade)new ClassProperties().RetornarObjetoFiltro(new MultaGravidade(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (gravidadeFiltro != null)
                    CarregarGrid(gravidadeFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(MultaGravidade gravidadeFiltro)
        {
            List<MultaGravidade> lstGravidades = new List<MultaGravidade>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstGravidades = bizVeiculo.PesquisarMultasGravidade(gravidadeFiltro).OrderBy(x => x.Valor).ToList();

                LimparGrid();

                gvGravidades.Columns[2].DefaultCellStyle.Format = "N2";

                foreach (MultaGravidade itemGravidade in lstGravidades)
                {
                    gvGravidades.Rows.Add(new object[] 
                    {
                        itemGravidade.idGravidade, 
                        itemGravidade.Descricao,
                        itemGravidade.Valor
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
            while (gvGravidades.Rows.Count > 0)
                gvGravidades.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            MultaGravidadeManutencao form = new MultaGravidadeManutencao(new MultaGravidade());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarGravidade();
        }

        private void VisualizarGravidade()
        {
            int linhaGrid = 0;

            if (gvGravidades.RowCount == 0)
                return;

            linhaGrid = gvGravidades.SelectedCells[0].RowIndex;

            MultaGravidade gravidade = new MultaGravidade()
            {
                idGravidade = int.Parse(gvGravidades[0, linhaGrid].Value.ToString()),
                Descricao = gvGravidades[1, linhaGrid].Value.ToString(),
                Valor = decimal.Parse(gvGravidades[2, linhaGrid].Value.ToString())
            };

            MultaGravidadeManutencao form = new MultaGravidadeManutencao(gravidade);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvGravidades_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarGravidade();
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

        private void MultaGravidadeConsulta_Load(object sender, EventArgs e)
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
