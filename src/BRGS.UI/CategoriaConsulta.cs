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
    public partial class CategoriaConsulta : Form
    {
        private BIZCategoria bizCategoria = new BIZCategoria();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public CategoriaConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Categoria());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Categoria categoriaFiltro = new Categoria();
                categoriaFiltro = (Categoria)new ClassProperties().RetornarObjetoFiltro(new Categoria(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (categoriaFiltro != null)
                    CarregarGrid(categoriaFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Categoria categoriaFiltro)
        {
            List<Categoria> lstCategorias = new List<Categoria>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCategorias = bizCategoria.PesquisarCategoria(categoriaFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                foreach (Categoria itemDespesa in lstCategorias)
                {
                    gvCategorias.Rows.Add(new object[] 
                    {
                        itemDespesa.idCategoria, 
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
            while (gvCategorias.Rows.Count > 0)
                gvCategorias.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            CategoriaManutencao form = new CategoriaManutencao(new Categoria());
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

            if (gvCategorias.RowCount == 0)
                return;

            linhaGrid = gvCategorias.SelectedCells[0].RowIndex;

            Categoria categoria = new Categoria()
            {
                idCategoria = int.Parse(gvCategorias[0, linhaGrid].Value.ToString()),
                Descricao = gvCategorias[1, linhaGrid].Value.ToString()
            };

            CategoriaManutencao form = new CategoriaManutencao(categoria);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvCategorias_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void CategoriaConsulta_Load(object sender, EventArgs e)
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
