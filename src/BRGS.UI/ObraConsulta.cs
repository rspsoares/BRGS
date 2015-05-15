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
    public partial class ObraConsulta : Form
    {
        private BIZObra bizObra = new BIZObra();
        private Helper helper = new Helper();
        private HelperUI helperUI = new HelperUI();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public ObraConsulta()
        {
            InitializeComponent();            
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedadesObra = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedadesObra = new ClassProperties().RetornarPropriedadesClasse(new Obra());

            cbPesquisaCampo.DataSource = lstPropriedadesObra;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Obra obraFiltro = new Obra();
                obraFiltro = (Obra)new ClassProperties().RetornarObjetoFiltro(new Obra(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (obraFiltro != null)
                    CarregarGrid(obraFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Obra obraFiltro)
        {
            List<Obra> lstObra = new List<Obra>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstObra = bizObra.PesquisarObra(obraFiltro).OrderBy(obr => obr.nomeCliente).ToList();

                LimparGrid();

                gvObras.Columns[4].DefaultCellStyle.Format = "N2";

                foreach (Obra itemObra in lstObra)
                {
                    gvObras.Rows.Add(new object[] 
                    {
                        itemObra.idObra, 
                        itemObra.nomeCliente,
                        itemObra.numeroLicitacao,                         
                        itemObra.nomeEvento,
                        decimal.Parse(helper.FormatarValorMoeda(itemObra.valorBruto.ToString()))                        
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
            while (gvObras.Rows.Count > 0)
                gvObras.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            Obra novaObra = new Obra();
            novaObra.lstEtapas = new List<ObraEtapa>();

            helperUI.AbrirNovaAba(new TabPage("Gerenciamento de Obras"), new ObraManutencao(novaObra));
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarObra();
        }

        private void VisualizarObra()
        {
            Obra obraSelecionada = new Obra();
            int linhaGrid = 0;
            int idObraSelecionada = 0;
            
            try
            {
                if (gvObras.RowCount == 0)
                    return;  
                
                linhaGrid = gvObras.SelectedCells[0].RowIndex;
                idObraSelecionada = int.Parse(gvObras[0, linhaGrid].Value.ToString());
                obraSelecionada = bizObra.PesquisarObra(new Obra() { idObra = idObraSelecionada })[0];

                helperUI.AbrirNovaAba(new TabPage("Gerenciamento de Obras: " + obraSelecionada.nomeCliente + " - " + obraSelecionada.nomeEvento), new ObraManutencao(obraSelecionada));                     
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

        private void gvObras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarObra();
        }

        private void ObraConsulta_Load(object sender, EventArgs e)
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
