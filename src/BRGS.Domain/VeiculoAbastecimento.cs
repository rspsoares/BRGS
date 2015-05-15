using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class VeiculoAbastecimento
    {
        public int idVeiculoAbastecimento { get; set; }
        public int idVeiculo { get; set; }
        public string placaVeiculo { get; set; }
        public int idMotorista { get; set; }
        public string nomeMotorista { get; set; }       
        public DateTime  Data { get; set; }
        public decimal Valor { get; set; }
        public int UnitTest { get; set; }
    }
}
