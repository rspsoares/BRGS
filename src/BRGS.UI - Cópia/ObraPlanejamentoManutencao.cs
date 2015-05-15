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
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI
{
    public partial class ObraPlanejamentoManutencao : Form
    {
        private Helper helper = new Helper();        
        private ObraEtapa etapaSelecionada = new ObraEtapa();
        private List<ObraEtapaPlanejamento> lstPlanejamento = new List<ObraEtapaPlanejamento>();
        private BIZObra bizObra = new BIZObra();
        private BIZUEN bizUEN = new BIZUEN();
        private BIZLogErro bizLogErro = new BIZLogErro();

        public ObraPlanejamentoManutencao(ObraEtapa _etapaSelecionada)
        {
            InitializeComponent();
            etapaSelecionada = _etapaSelecionada;
        }

        private void ObraPlanejamentoManutencao_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());

                CarregarComboUEN();

                tbDataInicio.Value = DateTime.Today;
                tbDataTermino.Value = DateTime.Today;
                
                if (etapaSelecionada.idObraEtapa != 0)
                    CarregarPlanejamento();
                
                this.Cursor = Cursors.Default;
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

        private void CarregarComboUEN()
        {
            List<UEN> lstUEN = new List<UEN>();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstUEN.Add(new UEN() { idUEN = 0, Descricao = "--Selecione--", Administrativo = 0 });
                lstUEN.AddRange(bizUEN.PesquisarUEN(new UEN()).OrderBy(u => u.Descricao).ToList());

                cbUEN.DataSource = lstUEN.Where(x => x.Administrativo == 0).ToList();
                cbUEN.DisplayMember = "Descricao";
                cbUEN.ValueMember = "idUEN";
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

        private void CarregarPlanejamento()
        {
            tbDescricao.Text = etapaSelecionada.Descricao;
            tbDataInicio.Value = etapaSelecionada.dataInicio;
            tbDataTermino.Value = etapaSelecionada.dataTermino;
            tbValorContrato.Text = helper.FormatarValorMoeda(etapaSelecionada.valorContrato.ToString());
            lstPlanejamento = etapaSelecionada.lstPlanejamentos.Where(x => x.idUEN != 0).ToList();
            CarregarGrid();
        }

        private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorContrato_Leave(object sender, EventArgs e)
        {
            tbValorContrato.Text = helper.FormatarValorMoeda(tbValorContrato.Text);
        }

        private void tbValorPrevisto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void tbValorPrevisto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int asc = (int)e.KeyChar;

            if (!char.IsDigit(e.KeyChar) && asc != 08 && asc != 127 && asc != 44)
                e.Handled = true;
        }

        private void tbValorPrevisto_Leave(object sender, EventArgs e)
        {
            tbValorPrevisto.Text = helper.FormatarValorMoeda(tbValorPrevisto.Text);
        }

        private string ValidarPrevisao()
        {
            string msgRetorno = string.Empty;
            
            if(cbUEN.FindStringExact(cbUEN.Text) == -1 || cbUEN.SelectedIndex == 0)
                msgRetorno += Environment.NewLine + "UEN inválida";
            
            if (lstPlanejamento.Count(x => x.idUEN == int.Parse(cbUEN.SelectedValue.ToString())) > 0)
                msgRetorno += Environment.NewLine + "Esta UEN já foi adicionada";

            if(decimal.Parse(tbValorPrevisto.Text) <= decimal.Zero)
                msgRetorno += Environment.NewLine + "Valor inválido";

            return msgRetorno;
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;

            msgRetorno = ValidarPrevisao();

            if (msgRetorno == string.Empty)
            {
                ObraEtapaPlanejamento planejamento = new ObraEtapaPlanejamento()
                {
                    idObraEtapa = etapaSelecionada.idObraEtapa,
                    idUEN = int.Parse(cbUEN.SelectedValue.ToString()),
                    descricaoUEN = cbUEN.Text,
                    valorPrevisto = decimal.Parse(tbValorPrevisto.Text)
                };

                lstPlanejamento.Add(planejamento);

                cbUEN.SelectedIndex = 0;
                tbValorPrevisto.Text = "0,00";

                CarregarGrid();
            }
            else
                MessageBox.Show("Atenção: " + msgRetorno, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CarregarGrid()
        {
            decimal totalPrevisto = decimal.Zero;            

            while (gvPrevisao.Rows.Count > 0)
                gvPrevisao.Rows.RemoveAt(0);

            if (lstPlanejamento == null)
                return;

            foreach (ObraEtapaPlanejamento planejamento in lstPlanejamento)
            {
                gvPrevisao.Rows.Add(new object[] 
                {
                    planejamento.idUEN,                    
                    planejamento.descricaoUEN,                    
                    helper.FormatarValorMoeda(planejamento.valorPrevisto.ToString()),                    
                });
            }

            totalPrevisto = lstPlanejamento.Sum(x => x.valorPrevisto);
            lbPrevistoTotal.Text = "Total Previsto para a Etapa: R$ " + helper.FormatarValorMoeda(totalPrevisto.ToString());
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            int linhaGrid = 0;

            if (gvPrevisao.RowCount == 0)
                return;

            linhaGrid = gvPrevisao.SelectedCells[0].RowIndex;

            ObraEtapaPlanejamento itemSelecionado = new ObraEtapaPlanejamento()
            {
                idUEN = int.Parse(gvPrevisao[0, linhaGrid].Value.ToString())
            };

            lstPlanejamento.RemoveAll(item => item.idUEN == itemSelecionado.idUEN);

            CarregarGrid();
        }

        private void cbUEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgRetorno = string.Empty;
            string acaoSelecionada = string.Empty;
            int idObraEtapa = 0;

            PopularEntidade();            

            try
            {
                if (etapaSelecionada.idObraEtapa == 0)
                {
                    msgRetorno = bizObra.IncluirObraEtapa(etapaSelecionada, out idObraEtapa);
                    etapaSelecionada.idObraEtapa = idObraEtapa;
                    acaoSelecionada = "Inclusão";
                }
                else
                {
                    msgRetorno = bizObra.AlterarObraEtapaPlanejamento(etapaSelecionada);
                    acaoSelecionada = "Alteração";
                }

                if (msgRetorno == string.Empty)                
                    MessageBox.Show(acaoSelecionada + " efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                else
                    MessageBox.Show("Atenção: " + msgRetorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
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

        private void PopularEntidade()
        {
            etapaSelecionada.Descricao = tbDescricao.Text;
            etapaSelecionada.dataInicio = tbDataInicio.Value;
            etapaSelecionada.dataTermino = tbDataTermino.Value;
            etapaSelecionada.valorContrato = decimal.Parse(tbValorContrato.Text);            
            etapaSelecionada.lstPlanejamentos = lstPlanejamento;
        }
    }
}
