using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Drawing;
using System.IO;

namespace BRGS.UI.Relatorios
{
    public class CrystalReportsHelper
    {        
        private readonly string _reportPath;
     
        public CrystalReportsHelper(string reportPath)
        {
            _reportPath = reportPath;        
        }

        public string ExportarOP2PDF(int idOP, int idObraEtapa)
        {   
            var ordemPagamento = new BIZOrdemPagamento();
            var helper = new Helper();
            DataTable dtOP, dtObras, dtTotaisObra = new DataTable();
            Image logotipo = null;
            var pdfContent = string.Empty;

            var opSelecionada = new OrdemPagamento()
            {
                idOrdemPagamento = idOP,
                idObraEtapa = idObraEtapa
            };

            dtOP = ordemPagamento.GerarOrdemPagamento(opSelecionada, out dtObras, out dtTotaisObra);

            if (dtOP.Rows.Count == 0)
                return string.Empty;

            var empresaSelecionada = dtOP.Rows[0]["RazaoSocial"].ToString();            

            switch (empresaSelecionada)
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

            var dsOP = PrepararDataSet(dtOP, dtTotaisObra, logotipo);

            using (var cryRpt = new ReportDocument())
            {
                cryRpt.Load(_reportPath);
                cryRpt.SetDataSource(dsOP);
                cryRpt.Subreports[0].Database.Tables["dtOPsPagaObra"].SetDataSource(dtObras);

                cryRpt.Refresh();

                using (var resultPDF = cryRpt.ExportToStream(ExportFormatType.PortableDocFormat))
                using (var ms = new MemoryStream())
                {
                    resultPDF.CopyTo(ms);
                    pdfContent = Convert.ToBase64String(ms.ToArray());
                }

                cryRpt.Close();
                cryRpt.Dispose();
            }

            dtOP?.Dispose();
            dtObras?.Dispose();
            dtTotaisObra?.Dispose();

            dsOP?.Dispose();

            logotipo?.Dispose();

            return pdfContent;
        }

        private dsOrdemPagamento PrepararDataSet(DataTable dtOP, DataTable dtTotaisObra, Image logotipo)
        {
            var dsOP = new dsOrdemPagamento();
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(logotipo, typeof(byte[]));

            foreach (DataRow dr in dtOP.Rows)
            {
                dsOP.DataTable1.AddDataTable1Row
                (
                    dr["RazaoSocial"].ToString(),
                    dr["NomeEvento"].ToString(),
                    dr["NumeroLicitacao"].ToString(),
                    dr["NomeSolicitante"].ToString(),
                    dr["NomeFavorecido"].ToString(),
                    dr["Autorizado"].ToString(),
                    DateTime.Parse(dr["DataSolicitacao"].ToString()),
                    dr["DescricaoUEN"].ToString(),
                    dr["DescricaoCentroCusto"].ToString(),
                    dr["DescricaoDespesa"].ToString(),
                    decimal.Parse(dr["Valor"].ToString()),
                    dr["Observacao1"].ToString(),
                    dr["Banco"].ToString(),
                    dr["Agencia"].ToString(),
                    dr["TipoConta"].ToString(),
                    dr["Conta"].ToString(),
                    xByte,
                    dr["Status"].ToString(),
                    dr["CPF_CNPJ"].ToString(),
                    dr["Cliente"].ToString(),
                    DateTime.Parse(dr["DataVencimento"].ToString()),
                    DateTime.Parse(dr["DataPagamento"].ToString()),
                    string.IsNullOrEmpty(dr["idObraEtapa"].ToString()) ? 0 : int.Parse(dr["idObraEtapa"].ToString()),
                    dr["NumeroOP"].ToString(),
                    dr["Parcela"].ToString()); 
            }

            foreach (DataRow dr in dtTotaisObra.Rows)
            {
                dsOP.dtTotalObra.AdddtTotalObraRow
                (
                    int.Parse(dr["idObraEtapa"].ToString()),
                    decimal.Parse(dr["ValorContrato"].ToString()),
                    decimal.Parse(dr["TotalPago"].ToString()),
                    decimal.Parse(dr["TotalAberto"].ToString())
                );
            }

            return dsOP;
        }
    }
}
