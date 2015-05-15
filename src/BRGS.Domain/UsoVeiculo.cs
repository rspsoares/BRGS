using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class UsoVeiculo
    {
        public int idUso { get; set; }
        public int idVeiculo { get; set; }
        
        [Description("Placa")]
        public string Placa { get; set; }
        
        public int idMotorista { get; set; }
        
        [Description("Motorista")]
        public string nomeMotorista { get; set; }
        
        public DateTime dataSaida { get; set; }
        public DateTime  dataChegada { get; set; }
        public string Observacoes { get; set; }
        public int UnitTest { get; set; }
    }
}
