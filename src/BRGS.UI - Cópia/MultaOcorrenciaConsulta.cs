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
    public partial class MultaOcorrenciaConsulta : Form
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        public MultaOcorrenciaConsulta()
        {
            InitializeComponent();
        }

        private void CarregarCamposPesquisa()
        {
            List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();

            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(new MultaOcorrencia());

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (cbPesquisaCampo.FindStringExact(cbPesquisaCampo.Text) != -1)
            {
                MultaOcorrencia ocorrenciaFiltro = new MultaOcorrencia();
                ocorrenciaFiltro = (MultaOcorrencia)new ClassProperties().RetornarObjetoFiltro(new MultaOcorrencia(), (PropertyInfo)cbPesquisaCampo.SelectedValue, tbPesquisaValor.Text);

                if (ocorrenciaFiltro != null)
                    CarregarGrid(ocorrenciaFiltro);
                else
                    MessageBox.Show("Informação inválida para " + cbPesquisaCampo.Text + ". Favor verificar.", "Valor incorreto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Campo para o filtro de pesquisa inválido. Favor verificar.", "Opção inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid(MultaOcorrencia ocorrenciaFiltro)
        {
            List<MultaOcorrencia> lstOcorrencias = new List<MultaOcorrencia>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstOcorrencias = bizVeiculo.PesquisarMultaOcorrencia(ocorrenciaFiltro).OrderBy(x => x.dataMulta).ToList();

                LimparGrid();

                gvOcorrencias.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

                foreach (MultaOcorrencia itemOcorrencia in lstOcorrencias)
                {
                    gvOcorrencias.Rows.Add(new object[] 
                    {
                        itemOcorrencia.idOcorrencia, 
                        itemOcorrencia.dataMulta,
                        itemOcorrencia.descricaoMulta,
                        itemOcorrencia.nomeMotorista,
                        itemOcorrencia.Placa,
                        itemOcorrencia.numeroOP,
                        itemOcorrencia.statusOP
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
            while (gvOcorrencias.Rows.Count > 0)
                gvOcorrencias.Rows.RemoveAt(0);
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            MultaOcorrenciaManutencao form = new MultaOcorrenciaManutencao(new MultaOcorrencia());
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarOcorrencia();
        }

        private void VisualizarOcorrencia()
        {
            int linhaGrid = 0;

            if (gvOcorrencias.RowCount == 0)
                return;

            linhaGrid = gvOcorrencias.SelectedCells[0].RowIndex;

            MultaOcorrencia ocorrencia = new MultaOcorrencia()
            {
                idOcorrencia = int.Parse(gvOcorrencias[0, linhaGrid].Value.ToString())
            };

            MultaOcorrenciaManutencao form = new MultaOcorrenciaManutencao(ocorrencia);
            form.ShowDialog();

            btPesquisar_Click(null, null);
        }

        private void gvOcorrencias_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarOcorrencia();
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

        private void MultaOcorrenciaConsulta_Load(object sender, EventArgs e)
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