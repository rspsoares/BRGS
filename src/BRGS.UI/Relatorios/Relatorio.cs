using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRGS.UI.Relatorios
{
    public partial class Relatorio : Form
    {
        public Relatorio(object crRelatorio)
        {
            InitializeComponent();

            crystalReportViewer1.ReportSource = crRelatorio;
            crystalReportViewer1.RefreshReport();
        }      
    }
}
