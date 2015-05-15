using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FiltroGridPesquisa
{
    public partial class FiltroGrid: UserControl
    {
        public List<ClassProperties.PropriedadeClasse> lstPropriedades = new List<ClassProperties.PropriedadeClasse>();
        public FiltroGrid()
        {
            InitializeComponent();
        }

        private void cbPesquisaCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
