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
    public partial class CentroCustoConsulta : Form
    {
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public CentroCustoConsulta()
        {
            InitializeComponent();            
        }
        
        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new CentroCusto());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                CentroCusto centroCustoFiltro = new CentroCusto();
                centroCustoFiltro = (CentroCusto)new ClassProperties().RetornarObjetoFiltro(new CentroCusto(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (centroCustoFiltro != null)
                    CarregarGrid(centroCustoFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(CentroCusto centroCustoFiltro)
        {
            List<CentroCusto> lstCentroCusto = new List<CentroCusto>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstCentroCusto = bizCentroCusto.PesquisarCentroCusto(centroCustoFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                foreach (CentroCusto itemCentroCusto in lstCentroCusto)
                {
                    gvCentroCusto.Rows.Add(new object[] 
                    {
                        itemCentroCusto.idCentroCusto, 
                        itemCentroCusto.Codigo, 
                        itemCentroCusto.Descricao
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
            while (gvCentroCusto.Rows.Count > 0)
                gvCentroCusto.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            CentroCustoManutencao form = new CentroCustoManutencao(new CentroCusto(), false);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarCentroCusto();
        }

        private void VisualizarCentroCusto()
        {
            CentroCusto centroCusto = new CentroCusto();
            int idCentroCustoSelecionado = 0;
            int linhaGrid = 0;

            if (gvCentroCusto.RowCount == 0)
                return;

            linhaGrid = gvCentroCusto.SelectedCells[0].RowIndex;
            idCentroCustoSelecionado = int.Parse(gvCentroCusto[0, linhaGrid].Value.ToString());
            
            centroCusto = bizCentroCusto.PesquisarCentroCusto(new CentroCusto() { idCentroCusto = idCentroCustoSelecionado })[0];
            
            CentroCustoManutencao form = new CentroCustoManutencao(centroCusto,false);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvCentroCusto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarCentroCusto();
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

        private void CentroCustoConsulta_Load(object sender, EventArgs e)
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
