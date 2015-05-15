using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace BRGS.Util
{
    public partial class FiltroGrid: UserControl
    {
        public delegate void btPesquisarClickedHandler();
        
        [Category("Action")]
        public event btPesquisarClickedHandler btPesquisarClick;   

        private List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();
        public string valorPesquisa = string.Empty;
        
        public FiltroGrid()
        {
            InitializeComponent();
            tbData.Value = DateTime.Today;           
        }

        public void CarregarCamposPesquisa(object tipoEntidade)
        {
            lstPropriedades = new ClassProperties().RetornarPropriedadesClasse(tipoEntidade);

            cbPesquisaCampo.DataSource = lstPropriedades;
            cbPesquisaCampo.DisplayMember = "descricaoPropriedade";
            cbPesquisaCampo.ValueMember = "nomePropriedade";
        }

        private void cbPesquisaCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoPropriedade = string.Empty;
            ClassProperties.PropriedadeClasse atributoSelecionado;

            atributoSelecionado = (ClassProperties.PropriedadeClasse)cbPesquisaCampo.SelectedItem;

            tipoPropriedade = lstPropriedades.FindAll(x => x.nomePropriedade.Name == atributoSelecionado.nomePropriedade.Name)[0].tipoPropriedade.Name;

            if (tipoPropriedade != "DateTime")
            {
                this.tableLayoutPanel1.ColumnStyles[1].Width = 0; 
                this.tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.AutoSize;
            }
            else
            {
                this.tableLayoutPanel1.ColumnStyles[2].Width = 0;
                this.tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.AutoSize;
            }

            tbPesquisaValor.Visible = tipoPropriedade != "DateTime";
            tbData.Visible = tipoPropriedade == "DateTime";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            this.valorPesquisa = tbPesquisaValor.Visible == true ? tbPesquisaValor.Text : tbData.Value.ToShortDateString();            
            btPesquisarClick();
        }
    }
}
