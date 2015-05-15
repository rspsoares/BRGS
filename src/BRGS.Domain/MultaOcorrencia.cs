using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class MultaOcorrencia
    {
        public int idOcorrencia { get; set; }
        public int idMulta { get; set; }
        
        [Description("Código Multa")]
        public string codigoMulta { get; set; }
        public int desdobramentoMulta { get; set; }
        public string descricaoMulta { get; set; }
        public decimal valorMulta { get; set; }
        
        public int idMotorista { get; set; }
        
        [Description("Nome Motorista")]
        public string nomeMotorista { get; set; }
        public int idVeiculo { get; set; }

        [Description("Placa Veículo")]
        public string Placa { get; set; }

        public int idOP { get; set; }
        public string numeroOP { get; set; }
        public string statusOP { get; set; }
        
        [Description("Data Multa")]
        public DateTime dataMulta { get; set; }
        public int UnitTest { get; set; }
    }
}
