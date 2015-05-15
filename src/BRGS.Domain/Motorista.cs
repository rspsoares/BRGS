using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class Motorista
    {
        public int idMotorista { get; set; }
        
        [Description("Nome")]
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public int Ativo { get; set; }
        public int UnitTest { get; set; }
    }
}
