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
    public partial class FreteConsulta : Form
    {
        private BIZFrete bizFrete = new BIZFrete();
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public FreteConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Frete());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Frete freteFiltro = new Frete();
                freteFiltro = (Frete)new ClassProperties().RetornarObjetoFiltro(new Frete(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (freteFiltro != null)
                    CarregarGrid(freteFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Frete freteFiltro)
        {
            List<Frete> lstFretes = new List<Frete>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstFretes = bizFrete.PesquisarFrete(freteFiltro).OrderBy(x => x.numeroFrete).ToList();

                LimparGrid();
                
                foreach (Frete itemFrete in lstFretes)
                {
                    gvFretes.Rows.Add(new object[] 
                    {
                        itemFrete.idFrete,
                        itemFrete.numeroFrete, 
                        itemFrete.nomeFornecedor,
                        itemFrete.Trajeto,
                        itemFrete.valorTotal,
                        this.CarcularSaldoFrete(itemFrete)                       
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

        private decimal CarcularSaldoFrete(Frete frete)
        {
            decimal saldo = decimal.Zero;

            saldo = frete.valorTotal - frete.lstPagamentos.Where(x => x.statusOP == "PAGA").Sum(y => y.valorOP);

            return saldo;
        }

        private void LimparGrid()
        {
            while (gvFretes.Rows.Count > 0)
                gvFretes.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            FreteManutencao form = new FreteManutencao(new Frete());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarFrete();
        }

        private void VisualizarFrete()
        {
            int linhaGrid = 0;            

            if (gvFretes.RowCount == 0)
                return;

            linhaGrid = gvFretes.SelectedCells[0].RowIndex;

            Frete frete = new Frete()
            {
                idFrete  = int.Parse(gvFretes[0, linhaGrid].Value.ToString())
            };

            FreteManutencao form = new FreteManutencao(frete);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvFretes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarFrete();
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

        private void FreteConsulta_Load(object sender, EventArgs e)
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