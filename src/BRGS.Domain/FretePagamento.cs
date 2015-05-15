using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class FretePagamento
    {
        public int idFrete { get; set; }
        public int idOP { get; set; }
        public string numeroOP { get; set; }
        public string statusOP { get; set; }
        public decimal valorOP { get; set; }
        public int UnitTest { get; set; }
    }
}
