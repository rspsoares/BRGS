using System.Threading;

namespace BRGS.Service
{
    partial class BRGSService
    {
        Timer timerGerarPDFOP;
        bool jobGerarPDFOPLock = false;

        Timer timerRetryGerarPDFOP;
        bool jobRetryGerarPDFOPLock = false;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "BRGSService";
        }

        #endregion
    }
}
