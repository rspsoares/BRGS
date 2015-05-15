using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class UsoVeiculosConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public UsoVeiculosConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new UsoVeiculo());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                UsoVeiculo usoFiltro = new UsoVeiculo();
                usoFiltro = (UsoVeiculo)new ClassProperties().RetornarObjetoFiltro(new UsoVeiculo(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (usoFiltro != null)
                    CarregarGrid(usoFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(UsoVeiculo usoFiltro)
        {
            List<UsoVeiculo> lstUsos = new List<UsoVeiculo>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUsos = bizVeiculo.PesquisarUsoVeiculos(usoFiltro).OrderBy(x => x.Placa).ThenBy(x => x.nomeMotorista).ToList();

                LimparGrid();

                gvUsos.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                gvUsos.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                foreach (UsoVeiculo itemUso in lstUsos)
                {
                    gvUsos.Rows.Add(new object[] 
                    {
                        itemUso.idUso,
                        itemUso.Placa,
                        itemUso.nomeMotorista,
                        itemUso.dataSaida,
                        itemUso.dataChegada == DateTime.MinValue || itemUso.dataChegada == SqlDateTime.MinValue ? (DateTime?)null : itemUso.dataChegada,                        
                        itemUso.Observacoes
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
            while (gvUsos.Rows.Count > 0)
                gvUsos.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            UsoVeiculosManutencao form = new UsoVeiculosManutencao(new UsoVeiculo());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarUso();
        }

        private void VisualizarUso()
        {
            int linhaGrid = 0;

            if (gvUsos.RowCount == 0)
                return;

            linhaGrid = gvUsos.SelectedCells[0].RowIndex;

            UsoVeiculo uso = new UsoVeiculo()
            {
                idUso = int.Parse(gvUsos[0, linhaGrid].Value.ToString())
            };

            UsoVeiculosManutencao form = new UsoVeiculosManutencao(uso);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvUsos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarUso();
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

        private void UsoVeiculosConsulta_Load(object sender, EventArgs e)
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
