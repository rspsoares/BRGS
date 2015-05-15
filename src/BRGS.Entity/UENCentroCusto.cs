using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class UENCentroCusto
    {
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public int idCentroCusto { get; set; }
        public string codigoCentroCusto { get; set; }
        public string descricaoCentroCusto { get; set; }
        public int Administrativo { get; set; }
        public int UnitTest { get; set; }
    }
}
