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
        private ReportDocument _cryRpt = new ReportDocument();
        private readonly string _reportPath;
        public CrystalReportsHelper(string reportPath)
        {
            _reportPath = reportPath;
            _cryRpt = new ReportDocument();
        }

        public string ExportarOP2PDF(int idOP, int idObraEtapa)
        {
            var empresa = new BIZEmpresa();
            var ordemPagamento = new BIZOrdemPagamento();
            var helper = new Helper();
            DataTable dtOP, dtObras, dtTotaisObra = new DataTable();
            Image logotipo = null;
            var pdfContent = string.Empty;

            // = ordemPagamento.PesquisarOrdemPagamento(new OrdemPagamento() { idOrdemPagamento = idOP })[0];            
            var opSelecionada = new OrdemPagamento()
            {
                idOrdemPagamento = idOP,
                idObraEtapa = idObraEtapa
            };

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

            var dsOP = PrepararDataSet(dtOP, dtTotaisObra, logotipo);

            _cryRpt.Load(_reportPath);
            _cryRpt.SetDataSource(dsOP);
            _cryRpt.Subreports[0].Database.Tables["dtOPsPagaObra"].SetDataSource(dtObras);            

            _cryRpt.Refresh();

            var resultPDF = _cryRpt.ExportToStream(ExportFormatType.PortableDocFormat);
 
            using (var ms = new MemoryStream())
            {
                resultPDF.CopyTo(ms);
                var bContent = ms.ToArray();
                pdfContent = Convert.ToBase64String(bContent);
                ms.Close();
            }

            return pdfContent;
        }

        private dsOrdemPagamento PrepararDataSet(DataTable dtOP, DataTable dtTotaisObra, Image logotipo)
        {
            var dsOP = new dsOrdemPagamento();

            foreach (DataRow dr in dtOP.Rows)
            {
                ImageConverter _imageConverter = new ImageConverter();
                byte[] xByte = (byte[])_imageConverter.ConvertTo(logotipo, typeof(byte[]));

                dsOP.DataTable1.AddDataTable1Row
                (
                    dr["RazaoSocial"].ToString(),
                    dr["NomeEvento"].ToString(),
                    dr["NumeroLicitacao"].ToString(),
                    dr["NomeSolicitante"].ToString(),
                    dr["NomeFavorecido"].ToString(),
                    dr["Autorizado"].ToString(),
                    dr["DataSolicitacao"].ToString(),
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
                    int.Parse(dr["idObraEtapa"].ToString()),
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
