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
        private readonly BIZOrdemPagamento ordemPagamento = new BIZOrdemPagamento();        
        
        public OrdemPagamentoController()
        {
            Parametrizacao.servidor_Conexao = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        [HttpGet]
        public DataResultModel GetOpPDF(string idOP)
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
                    
                var pdfContent = ordemPagamento.PesquisarBinarioCrystalOrdemPagamento(idOP);
                var result = Convert.FromBase64String(pdfContent);                

                return new DataResultModel(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new DataResultModel(false, ex.Message + " " + ex.InnerException, Array.Empty<byte>());
            }
        }
    }
}