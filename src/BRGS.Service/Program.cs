using System.ServiceProcess;

namespace BRGS.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if (!DEBUG)
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new BRGSService()
            };
            ServiceBase.Run(ServicesToRun);
#else
            var serv = new BRGSService();
            serv.Debug();
#endif 
        }
    }
}
