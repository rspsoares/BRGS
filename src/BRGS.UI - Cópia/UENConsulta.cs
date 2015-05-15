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
    public partial class UENConsulta : Form
    {
        private BIZUEN bizUEN = new BIZUEN();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public UENConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new UEN());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                UEN uenFiltro = new UEN();
                uenFiltro = (UEN)new ClassProperties().RetornarObjetoFiltro(new UEN(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (uenFiltro != null)
                    CarregarGrid(uenFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(UEN uenFiltro)
        {
            List<UEN> lstUEN = new List<UEN>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN = bizUEN.PesquisarUEN(uenFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                foreach (UEN itemCentroCusto in lstUEN)
                {
                    gvUEN.Rows.Add(new object[] 
                    {
                        itemCentroCusto.idUEN,                         
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
            while (gvUEN.Rows.Count > 0)
                gvUEN.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            UENManutencao form = new UENManutencao(new UEN());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarUEN();
        }

        private void VisualizarUEN()
        {
            UEN uen = new UEN();
            int idUENSelecionada = 0;
            int linhaGrid = 0;

            if (gvUEN.RowCount == 0)
                return;

            linhaGrid = gvUEN.SelectedCells[0].RowIndex;
            idUENSelecionada = int.Parse(gvUEN[0, linhaGrid].Value.ToString());
            
            uen = bizUEN.PesquisarUEN(new UEN() { idUEN = idUENSelecionada })[0];
            
            UENManutencao form = new UENManutencao(uen);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvCentroCusto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarUEN();
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

        private void UENConsulta_Load(object sender, EventArgs e)
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
