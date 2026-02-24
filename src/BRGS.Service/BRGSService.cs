using BRGS.BIZ;
using BRGS.Entity;
using BRGS.UI.Relatorios;
using BRGS.Util;
using NLog;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace BRGS.Service
{
    public partial class BRGSService : ServiceBase
    {
        private static readonly Logger log = LogManager.GetLogger("ServiceLogger");

        public BRGSService()
        {
            InitializeComponent();
            Parametrizacao.servidor_Conexao = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        protected override void OnStart(string[] args)
        {
            var helper = new Helper();
            timer = new Timer(new TimerCallback(ProcessCallback), null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(helper.ConfigurationGet<int>("JobInterval")).TotalMilliseconds);
        }

        private void ProcessCallback(object state)
        {
            if (jobLock)
                return;

            jobLock = true;

            try
            {
                GerarPdfOp();
            }
            catch (Exception ex)
            {
                log.Error($"[ProcessCallback] Erro: {ex.Message} - {ex.InnerException}");
            }
            finally
            {
                jobLock = false;
            }
        }

        private void GerarPdfOp()
        {
            try
            {
                var ordemPagamento = new BIZOrdemPagamento();

                ordemPagamento
                    .PesquisarOrdemPagamentoSemBinarioCrystal()
                    .ForEach(idOP =>
                    {
                        try
                        {
                            log.Info($"[GerarPdfOp] Processando OP Id: {idOP}");
                            var startInfo = new ProcessStartInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BRGS.exe"))
                            {
                                Arguments = $"MobileOrdemPagamentoEmissao {idOP}",
                                UseShellExecute = false
                            };

                            using (var proc = Process.Start(startInfo))
                            {
                                proc.WaitForExit();
                                proc.Close();
                            }
                            log.Info($"[GerarPdfOp] OP Id: {idOP} processado com sucesso.");
                        }
                        catch (Exception exOP)
                        {
                            log.Error($"[GerarPdfOp] OP Id: {idOP} Erro: {exOP.Message} - {exOP.InnerException}");
                        }                       
                    });
            }
            catch (Exception ex)
            {
                log.Error($"[GerarPdfOp] Erro: {ex.Message} - {ex.InnerException}");
            }
        }

        protected override void OnStop()
        {
            timer.Dispose();
        }

        public void Debug()
        {
            GerarPdfOp();
        }
    }
}
