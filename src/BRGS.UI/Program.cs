using BRGS.UI.Relatorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BRGS.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mdiBRGS());
            }
            else
            {
                var reportType = args[0];
                var id = args[1];

                var crHelper = new CrystalReportsHelper();

                switch (reportType)
                {
                    case "MobileOrdemPagamentoEmissao":
                        crHelper.MobileOrdemPagamentoEmissao(id);
                        break;
                    default:
                        break;
                }
            }            
        }
    }
}
