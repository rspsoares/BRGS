using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;

namespace BRGS.UI.Relatorios
{
    public class CrystalReportsHelper
    {
        public CrystalReportsHelper()
        {
            Parametrizacao.servidor_Conexao = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void MobileOrdemPagamentoEmissao(string idOP)
        {
            var empresa = new BIZEmpresa();
            var ordemPagamento = new BIZOrdemPagamento();
            var helper = new Helper();
            DataTable dtOP, dtObras, dtTotaisObra = new DataTable();
            Image logotipo = null;
            var pdfContent = string.Empty;

            var opSelecionada = ordemPagamento.PesquisarOrdemPagamento(new OrdemPagamento() { idOrdemPagamento = int.Parse(idOP) })[0];            

            dtOP = ordemPagamento.GerarOrdemPagamento(opSelecionada, out dtObras, out dtTotaisObra);

            var empresaSelecionada = empresa.PesquisarEmpresa(new Empresa() { idEmpresa = opSelecionada.idEmpresa })[0];

            switch (empresaSelecionada.razaoSocial)
            {
                case "FRONT ESTRUTURAS LTDA - EPP":
                    logotipo = Properties.Resources.Logo_FRONT;
                    break;
                case "BRGS BRASIL LTDA - EPP":
                    logotipo = Properties.Resources.Logo_BRGS;
                    break;
                case "LOGOS DO BRASIL LTDA - EPP":
                    logotipo = Properties.Resources.Logo_LOGOS;
                    break;
                case "BRG SERVICOS LTDA - EPP":
                    logotipo = Properties.Resources.Logo_BRG;
                    break;
            }

            dtOP = helper.AdicionarLogotipoDataTable(dtOP, logotipo);

            var op = new OrdemPagamentoEmissao();
            op.Database.Tables["DataTable1"].SetDataSource(dtOP);
            op.Database.Tables["dtTotalObra"].SetDataSource(dtTotaisObra);
            op.Subreports[0].Database.Tables["dtOPsPagaObra"].SetDataSource(dtObras);

            var cryRpt = new ReportDocument();
            cryRpt.Load(op.FilePath);
            cryRpt.Database.Tables["DataTable1"].SetDataSource(dtOP);
            cryRpt.Database.Tables["dtTotalObra"].SetDataSource(dtTotaisObra);
            cryRpt.Subreports[0].Database.Tables["dtOPsPagaObra"].SetDataSource(dtObras);

            cryRpt.Refresh();

            var resultPDF = cryRpt.ExportToStream(ExportFormatType.PortableDocFormat);
 
            using (var ms = new MemoryStream())
            {
                resultPDF.CopyTo(ms);
                var bContent = ms.ToArray();
                pdfContent = Convert.ToBase64String(bContent);

                ms.Close();
            }

            ordemPagamento.AtualizarBinarioCrystalOrdemPagamento(idOP, pdfContent);           
        } 
    }
}
