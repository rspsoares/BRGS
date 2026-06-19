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
            timerTabelaOP = new Timer(new TimerCallback(ProcessTabelaOPCallback), null, (int)TimeSpan.FromSeconds(2).TotalMilliseconds, (int)TimeSpan.FromSeconds(_helper.ConfigurationGet<int>("JobTabelaOPInterval")).TotalMilliseconds);
        }

        private void ProcessTabelaOPCallback(object state)
        {
            if (jobTabelaOPLock)
                return;

            jobTabelaOPLock = true;

            try
            {
                GerarPDFTabelaOP();
            }
            catch (Exception ex)
            {
                log.Error($"[ProcessTabelaOPCallback] Erro: {ex.Message} - {ex.InnerException}");
            }
            finally
            {
                jobTabelaOPLock = false;
            }
        }

        private void GerarPDFTabelaOP()
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
                            log.Info($"[GerarPDFTabelaOP] Processando OP Id: {op.IdOrdemPagamento}");

                            ordemPagamento.AtualizarDataPagamentoSQLNullDate(op.IdOrdemPagamento);

                            var pdfContent = crystalReportsHelper.ExportarOP2PDF(op.IdOrdemPagamento, op.IdObraEtapa);

                            if (!string.IsNullOrEmpty(pdfContent))
                                ordemPagamento.InserirOrdemPagamentoPDF(op.IdOrdemPagamento, pdfContent);
                            else                            
                                ordemPagamento.AtualizarOPNaoGerarPDF(op.IdOrdemPagamento);
    
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
            timerTabelaOP.Dispose();
        }

        public void Debug()
        {         
            GerarPDFTabelaOP();            
        }
    }
}
