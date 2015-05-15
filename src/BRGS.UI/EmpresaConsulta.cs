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
    public partial class EmpresaConsulta : Form
    {
        private BIZEmpresa bizEmpresa = new BIZEmpresa();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public EmpresaConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new Empresa());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                Empresa empresaFiltro = new Empresa();
                empresaFiltro = (Empresa)new ClassProperties().RetornarObjetoFiltro(new Empresa(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (empresaFiltro != null)
                    CarregarGrid(empresaFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(Empresa empresaFiltro)
        {
            List<Empresa> lstEmpresa = new List<Empresa>();
            
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstEmpresa = bizEmpresa.PesquisarEmpresa(empresaFiltro).OrderBy(x => x.razaoSocial).ToList();

                LimparGrid();

                foreach (Empresa itemEmpresa in lstEmpresa)
                {
                    gvEmpresas.Rows.Add(new object[] 
                    {
                        itemEmpresa.idEmpresa, 
                        itemEmpresa.razaoSocial,                        
                        itemEmpresa.nomeFantasia
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
            while (gvEmpresas.Rows.Count > 0)
                gvEmpresas.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            EmpresaManutencao form = new EmpresaManutencao(new Empresa());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarEmpresa();
        }

        private void VisualizarEmpresa()
        {
            int linhaGrid = 0;

            if (gvEmpresas.RowCount == 0)
                return;

            linhaGrid = gvEmpresas.SelectedCells[0].RowIndex;

            Empresa empresa = new Empresa()
            {
                idEmpresa = int.Parse(gvEmpresas[0, linhaGrid].Value.ToString())               
            };

            EmpresaManutencao form = new EmpresaManutencao(empresa);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvEmpresas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarEmpresa();
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

        private void EmpresaConsulta_Load(object sender, EventArgs e)
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