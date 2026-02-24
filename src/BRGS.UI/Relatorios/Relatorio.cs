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
