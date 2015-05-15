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
    public partial class DespesaConsulta : Form
    {
        private BIZDespesa bizDespesa = new BIZDespesa();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public DespesaConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesNFS = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesNFS = new ClassProperties().RetornarPropriedadesClasse(new Despesa());

            cbPesquisaCampo.DataSource = lstPropriedadesNFS;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Despesa despesaFiltro = new Despesa();
                despesaFiltro = (Despesa)new ClassProperties().RetornarObjetoFiltro(new Despesa(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (despesaFiltro != null)
                    CarregarGrid(despesaFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Despesa despesaFiltro)
        {
            List<Despesa> lstDespesa = new List<Despesa>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstDespesa = bizDespesa.PesquisarDespesa(despesaFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                foreach (Despesa itemDespesa in lstDespesa)
                {
                    gvDespesas.Rows.Add(new object[] 
                    {
                        itemDespesa.idDespesa, 
                        itemDespesa.Descricao,
                        itemDespesa.gastoFixo == 1 ? "Sim" : "Não"
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
            while (gvDespesas.Rows.Count > 0)
                gvDespesas.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            DespesaManutencao form = new DespesaManutencao(new Despesa());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarDespesa();
        }

        private void VisualizarDespesa()
        {
            int linhaGrid = 0;            

            if (gvDespesas.RowCount == 0)
                return;

            linhaGrid = gvDespesas.SelectedCells[0].RowIndex;

            Despesa despesa = new Despesa()
            {
                idDespesa = int.Parse(gvDespesas[0, linhaGrid].Value.ToString()),
                Descricao = gvDespesas[1, linhaGrid].Value.ToString(),
                gastoFixo = gvDespesas[2, linhaGrid].Value.ToString() == "Sim" ? 1 : 0
            };

            DespesaManutencao form = new DespesaManutencao(despesa);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvDespesas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarDespesa();
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

        private void DespesaConsulta_Load(object sender, EventArgs e)
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
