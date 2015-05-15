using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class LogErro
    {
        public DateTime Data { get; set; }
        public string procedureSQL { get; set; }
        public string parametrosSQL { get; set; }
        public string mensagemErro { get; set; }
        public string nomeComputador { get; set; }
        public int Enviado { get; set; }
    }
}
