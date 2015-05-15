using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.UI
{
    public partial class ServidorConexao : Form
    {
        private DataAccess dao = new DataAccess();
        private Helper helper = new Helper();

        public ServidorConexao()
        {
            InitializeComponent();
        }

        private void tbConexao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btTestar_Click(object sender, EventArgs e)
        {
            string msgErro = string.Empty;

            this.Cursor = Cursors.WaitCursor;

            helper.TestarConexao(tbConexao.Text, out msgErro);

            if (msgErro == string.Empty)
                MessageBox.Show("Conexão ao banco de dados realizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msgErro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Cursor = Cursors.Default;
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string msgErro = string.Empty;
            string strConnTest = string.Empty;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                strConnTest = helper.TestarConexao(tbConexao.Text, out msgErro);

                if (msgErro == string.Empty)
                {
                    helper.CriarArquivoConexao(strConnTest);
                    Parametrizacao.servidor_Endereco = tbConexao.Text;
                    Parametrizacao.servidor_Conexao = strConnTest;

                    this.Close();
                }
                else
                    MessageBox.Show(msgErro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Cursor = Cursors.Default;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
