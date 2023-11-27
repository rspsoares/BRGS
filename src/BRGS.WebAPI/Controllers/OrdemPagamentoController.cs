using BRGS.BIZ;
using BRGS.Entity;
using System;
using System.Configuration;
using System.Web.Http;
using BRGS.WebAPI.Models;
using System.IO;
using System.Diagnostics;

namespace BRGS.WebAPI.Controllers
{
    public class OrdemPagamentoController : ApiController
    {
        private BIZOrdemPagamento ordemPagamento;        
        
        public OrdemPagamentoController()
        {
            Parametrizacao.servidor_Conexao = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        [HttpGet]
        public OrdemPagamentoPDFModel GetOpPDF(string idOP)
        {
            try
            {
                var startInfo = new ProcessStartInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\BRGS.exe"))
                {
                    Arguments = $"MobileOrdemPagamentoEmissao {idOP}",
                    UseShellExecute = false
                };

                using (var proc = Process.Start(startInfo))
                {
                    proc.WaitForExit();
                    proc.Close();
                }
                ordemPagamento = new BIZOrdemPagamento();

                var pdfContent = ordemPagamento.PesquisarBinarioCrystalOrdemPagamento(idOP);
                var result = Convert.FromBase64String(pdfContent);

                return new OrdemPagamentoPDFModel()
                {
                    PDFContent = result,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //TODO: Logar a exception
                return new OrdemPagamentoPDFModel()
                {
                    PDFContent = null,
                    Success = false,
                    Message = "Ocorreu um erro ao obter a ordem de Pagamento."
                };                
            }
        }

        [HttpGet]
        public OrdemPagamentoGridModel GetOpGridMobile(string filtroGrid, string pageNumber, string rowsOfPage)
        {
            try
            {
                ordemPagamento = new BIZOrdemPagamento();
                var opFiltro = new OrdemPagamento();

                if (filtroGrid != null && filtroGrid != "|")
                {
                    var filtroGridSplit = filtroGrid.Split('|');
                    if (filtroGridSplit.Length != 2)
                    {
                        return new OrdemPagamentoGridModel()
                        {   
                            Success = false,
                            Message = $"Formato de filtro inválido: {filtroGrid}"
                        };
                    }                       

                    var propertyInfo = opFiltro.GetType().GetProperty(filtroGridSplit[0]);
                    propertyInfo.SetValue(opFiltro, Convert.ChangeType(filtroGridSplit[1], propertyInfo.PropertyType), null);
                }

                var gridOP = ordemPagamento.PesquisarOrdemPagamentoMobile(opFiltro, pageNumber, rowsOfPage, out int totalRows);
                               
                return new OrdemPagamentoGridModel()
                {
                    OPResults = gridOP,
                    Total = totalRows,
                    Success = true
                };                
            }
            catch (Exception ex)
            {
                //TODO: Logar a exception


                return new OrdemPagamentoGridModel()
                {
                    OPResults = null,
                    Total = 0,
                    Success = false,
                    Message = "Ocorreu um erro ao obter os dados."
                };
            }
        }
    }
}