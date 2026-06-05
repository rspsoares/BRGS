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
        private CrystalReportsHelper _crystalReportsHelper;
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
            _crystalReportsHelper = new CrystalReportsHelper(_reportPath);
            timerRequisicao = new Timer(new TimerCallback(ProcessRequisicaoCallback), null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(_helper.ConfigurationGet<int>("JobRequisicaoInterval")).TotalMilliseconds);
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

        private void ProcessRequisicaoCallback(object state)
        {
            if (jobRequisicaoLock)
                return;

            jobRequisicaoLock = true;

            try
            {
                GerarPDFRequisicao();
            }
            catch (Exception ex)
            {
                log.Error($"[ProcessCallback] Erro: {ex.Message} - {ex.InnerException}");
            }
            finally
            {
                jobRequisicaoLock = false;
            }
        }

        private void GerarPDFRequisicao()
        {
            try
            {
                _crystalReportsHelper = new CrystalReportsHelper(_reportPath);
                var ordemPagamento = new BIZOrdemPagamento();

                ordemPagamento
                    .PesquisarOrdemPagamentoPDFRequisicao()
                    .ForEach(idOP =>
                    {
                        try
                        {
                            log.Info($"[GerarPDFRequisicao] Processando OP Id: {idOP}");
                            
                            var pdfContent = _crystalReportsHelper.ExportarOP2PDF(idOP);
                            
                            ordemPagamento.InserirOrdemPagamentoPDF(idOP, pdfContent);

                            log.Info($"[GerarPDFRequisicao] OP Id: {idOP} processado com sucesso.");
                        }
                        catch (Exception exOP)
                        {
                            log.Error($"[GerarPDFRequisicao] OP Id: {idOP} Erro: {exOP.Message} - {exOP.InnerException}");
                        }
                    });
            }
            catch (Exception ex)
            {
                log.Error($"[GerarPDFRequisicao] Erro: {ex.Message} - {ex.InnerException}");
            }
        }

        private void GerarPDFTabelaOP()
        {
            try
            {
                _crystalReportsHelper = new CrystalReportsHelper(_reportPath);
                var ordemPagamento = new BIZOrdemPagamento();

                ordemPagamento
                    .PesquisarOrdemPagamentoSemPDF()
                    .ForEach(idOP =>
                    {
                        try
                        { 
                            log.Info($"[GerarPDFTabelaOP] Processando OP Id: {idOP}");
                            
                            var pdfContent = _crystalReportsHelper.ExportarOP2PDF(idOP);
                            
                            ordemPagamento.InserirOrdemPagamentoPDF(idOP, pdfContent);
                            
                            log.Info($"[GerarPDFTabelaOP] OP Id: {idOP} processado com sucesso.");
                        }
                        catch (Exception exOP)
                        {
                            log.Error($"[GerarPDFTabelaOP] OP Id: {idOP} Erro: {exOP.Message} - {exOP.InnerException}");
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
            timerRequisicao.Dispose();
            timerTabelaOP.Dispose();
        }

        public void Debug()
        {
            _crystalReportsHelper = new CrystalReportsHelper(_reportPath);
            GerarPDFTabelaOP();
            //GerarPDFRequisicao();
        }
    }
}
