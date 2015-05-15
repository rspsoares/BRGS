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
    public partial class FeriadoConsulta : Form
    {
        private BIZFeriado bizFeriado = new BIZFeriado();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public FeriadoConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Feriado());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Feriado feriadoFiltro = new Feriado();
                feriadoFiltro = (Feriado)new ClassProperties().RetornarObjetoFiltro(new Feriado(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (feriadoFiltro != null)
                    CarregarGrid(feriadoFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Feriado feriadoFiltro)
        {
            List<Feriado> lstFeriado = new List<Feriado>();
            DateTime dataFeriado = new DateTime();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFeriado = bizFeriado.PesquisarFeriados(feriadoFiltro).OrderBy(x => x.Descricao).ToList();

                LimparGrid();

                gvFeriados.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

                foreach (Feriado itemFeriado in lstFeriado)
                {
                    dataFeriado = new DateTime(DateTime.Today.Year, itemFeriado.Mes, itemFeriado.Dia);

                    gvFeriados.Rows.Add(new object[] 
                    {
                        itemFeriado.idFeriado, 
                        dataFeriado,
                        itemFeriado.Descricao
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
            while (gvFeriados.Rows.Count > 0)
                gvFeriados.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            FeriadoManutencao form = new FeriadoManutencao(new Feriado());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarFase();
        }

        private void VisualizarFase()
        {
            int linhaGrid = 0;

            if (gvFeriados.RowCount == 0)
                return;

            linhaGrid = gvFeriados.SelectedCells[0].RowIndex;

            Feriado feriado = new Feriado()
            {
                idFeriado = int.Parse(gvFeriados[0, linhaGrid].Value.ToString()),
                Dia = DateTime.Parse(gvFeriados[1, linhaGrid].Value.ToString()).Day,
                Mes = DateTime.Parse(gvFeriados[1, linhaGrid].Value.ToString()).Month,
                Descricao = gvFeriados[2, linhaGrid].Value.ToString()
            };

            FeriadoManutencao form = new FeriadoManutencao(feriado);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvFeriados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarFase();
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

        private void FeriadoConsulta_Load(object sender, EventArgs e)
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