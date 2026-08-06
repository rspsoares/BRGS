using BRGS.BIZ;
using BRGS.Entity;
using BRGS.UI.Relatorios;
using BRGS.Util;
using NLog;
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;

namespace BRGS.Service
{
    public partial class BRGSService : ServiceBase
    {
        private static readonly Logger log = LogManager.GetLogger("ServiceLogger");        
        private Helper _helper = new Helper();
        private readonly string _reportPath;

        public BRGSService()
        {
            InitializeComponent();
            Parametrizacao.servidor_Conexao = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            _reportPath = _helper.ConfigurationGet<string>("ReportPath");            
        }

        protected override void OnStart(string[] args)
        {   
            timerGerarPDFOP = new Timer(new TimerCallback(ProcessGerarPDFOPCallback), null, (int)TimeSpan.FromSeconds(2).TotalMilliseconds, (int)TimeSpan.FromSeconds(_helper.ConfigurationGet<int>("JobGerarPDFOPInterval")).TotalMilliseconds);
            timerRetryGerarPDFOP = new Timer(new TimerCallback(ProcessRetryGerarPDFOPCallback), null, (int)TimeSpan.FromSeconds(3).TotalMilliseconds, (int)TimeSpan.FromSeconds(_helper.ConfigurationGet<int>("JobRetryGerarPDFOPInterval")).TotalMilliseconds);
        }

        private void ProcessRetryGerarPDFOPCallback(object state)
        {
            if (jobRetryGerarPDFOPLock)
                return;

            jobRetryGerarPDFOPLock = true;

            try
            {
                var ordemPagamento = new BIZOrdemPagamento();
                ordemPagamento.RetryGerarPDF();
            }
            catch (Exception ex)
            {
                log.Error($"[ProcessRetryGerarPDFOPCallback] Erro: {ex.Message} - {ex.InnerException}");
            }
            finally
            {
                jobRetryGerarPDFOPLock = false;
            }
        }

        private void ProcessGerarPDFOPCallback(object state)
        {
            if (jobGerarPDFOPLock)
                return;

            jobGerarPDFOPLock = true;

            try
            {                
                GerarPDFOP();
            }
            catch (Exception ex)
            {
                log.Error($"[ProcessGerarPDFOPCallback] Erro: {ex.Message} - {ex.InnerException}");
            }
            finally
            {
                jobGerarPDFOPLock = false;
            }
        }

        private void GerarPDFOP()
        {
            try
            {
                var crystalReportsHelper = new CrystalReportsHelper(_reportPath);
                var ordemPagamento = new BIZOrdemPagamento();

                ordemPagamento
                    .PesquisarOrdemPagamentoSemPDF()
                    .ForEach(op =>
                    {
                        try
                        {
                            var pdfContent = string.Empty;

                            log.Info($"[GerarPDFTabelaOP] Processando OP Id: {op.IdOrdemPagamento}");

                            ordemPagamento.AtualizarDataPagamentoSQLNullDate(op.IdOrdemPagamento);

                            pdfContent = crystalReportsHelper.ExportarOP2PDF(op.IdOrdemPagamento, op.IdObraEtapa);                            

                            if (!string.IsNullOrEmpty(pdfContent))
                                ordemPagamento.InserirOrdemPagamentoPDF(op.IdOrdemPagamento, pdfContent);
                            else
                            {
                                log.Warn($"Não foi possível gerar o PDF da OP ID: {op.IdOrdemPagamento}");
                                ordemPagamento.AtualizarOPNaoGerarPDF(op.IdOrdemPagamento);
                            }                                
    
                            log.Info($"[GerarPDFTabelaOP] OP Id: {op.IdOrdemPagamento} processado com sucesso.");
                        }
                        catch (Exception exOP)
                        {
                            log.Error($"[GerarPDFTabelaOP] OP Id: {op.IdOrdemPagamento} Erro: {exOP.Message} - {exOP.InnerException}");
                        }
                    });
            }
            catch (Exception ex)
            {
                log.Error($"[GerarPDFTabelaOP] Erro: {ex.Message} - {ex.InnerException}");
            }
        }

        protected override void OnStop()
        {
            timerGerarPDFOP.Dispose();
            timerRetryGerarPDFOP.Dispose();
        }

        //private void RetryOnException(int times, TimeSpan delay, Action operation)
        //{
        //    var attempts = 0;
        //    do
        //    {
        //        try
        //        {
        //            attempts++;
        //            operation();
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error($"[GerarPDFTabelaOP] Retry - Erro: {ex.Message} - {ex.InnerException}");

        //            if (attempts == times)
        //                throw;

        //            Task.Delay(delay).Wait();
        //        }
        //    } while (true);
        //}

        public void Debug()
        {
            ProcessGerarPDFOPCallback(null);
            //ProcessRetryGerarPDFOPCallback(null);

            //Retry:
            //UPDATE  OrdemPagamento SET GerarOPPdf = 1 WHERE << DataCriação >= 2026 and GerarOPPdf = 0
        }
    }
}
