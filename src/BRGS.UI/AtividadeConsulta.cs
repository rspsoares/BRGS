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
    public partial class AtividadeConsulta : Form
    {
        private BIZAtividade bizAtividade = new BIZAtividade();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public AtividadeConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Atividade());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Atividade atividadeFiltro = new Atividade();
                atividadeFiltro = (Atividade)new ClassProperties().RetornarObjetoFiltro(new Atividade(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (atividadeFiltro != null)
                    CarregarGrid(atividadeFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Atividade atividadeFiltro)
        {
            List<Atividade> lstAtividades = new List<Atividade>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstAtividades = bizAtividade.PesquisarAtividade(atividadeFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                foreach (Atividade itemDespesa in lstAtividades)
                {
                    gvAtividades.Rows.Add(new object[] 
                    {
                        itemDespesa.idAtividade, 
                        itemDespesa.Descricao
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
            while (gvAtividades.Rows.Count > 0)
                gvAtividades.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            AtividadeManutencao form = new AtividadeManutencao(new Atividade());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarAtividade();
        }

        private void VisualizarAtividade()
        {
            int linhaGrid = 0;

            if (gvAtividades.RowCount == 0)
                return;

            linhaGrid = gvAtividades.SelectedCells[0].RowIndex;

            Atividade atividade = new Atividade()
            {
                idAtividade = int.Parse(gvAtividades[0, linhaGrid].Value.ToString()),
                Descricao = gvAtividades[1, linhaGrid].Value.ToString()
            };

            AtividadeManutencao form = new AtividadeManutencao(atividade);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvAtividades_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarAtividade();
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

        private void AtividadeConsulta_Load(object sender, EventArgs e)
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
