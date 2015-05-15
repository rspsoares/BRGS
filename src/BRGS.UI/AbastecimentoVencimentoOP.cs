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
    public partial class AbastecimentoVencimentoOP : Form
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        public AbastecimentoVencimentoOP()
        {
            InitializeComponent();          
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            if (cbOPAbastecimento.FindStringExact(cbOPAbastecimento.Text) == -1)
            {
                MessageBox.Show("Favor selecionar uma OP válida.", "Ateção", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AbastecimentoVencimentoOP_Load(object sender, EventArgs e)
        {
            try
            {
                helper.VerificaPermissaoAcessoObjetos(this, UsuarioLogado.lstPermissoes.Where(perm => perm.nomeFormulario == this.Name).ToList());
                CarregarComboOP();
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

        private void CarregarComboOP()
        {
            List<OrdemPagamento> lstOP = new List<OrdemPagamento>();
            BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
            this.Cursor = Cursors.WaitCursor;

            try
            {
                lstOP.Add(new OrdemPagamento() { idOrdemPagamento  = 0, numeroOP = "--Selecione--" });
                lstOP.AddRange(bizOP.PesquisarOPAbastecimento().OrderBy(x => x.idOrdemPagamento));

                cbOPAbastecimento.DataSource = lstOP;
                cbOPAbastecimento.DisplayMember = "numeroOP";
                cbOPAbastecimento.ValueMember = "idOrdemPagamento";
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

        private void cbOPAbastecimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void chkAdicionarOP_CheckedChanged(object sender, EventArgs e)
        {
            cbOPAbastecimento.Enabled = chkAdicionarOP.Checked;
        }
    }
}
