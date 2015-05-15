using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class Manutencao
    {
        public int idManutencao { get; set; }

        [Description("Número Manutenção")]
        public string numeroManutencao { get; set; }
        
        public int idVeiculo { get; set; }

        [Description("Placa")]
        public string placaVeiculo { get; set; }
        public string descricaoVeiculo { get; set; }

        public int idOP { get; set; }
        public string numeroOP { get; set; }
        public string statusOP { get; set; }
        public string Descricao { get; set; }
        public DateTime dataManutencao { get; set; }
        public decimal Valor { get; set; }
        public int UnitTest { get; set; }
    }
}
