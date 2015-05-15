using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class CentroCusto
    {
        public int idCentroCusto { get; set; }

        [Description("Código")]
        public string Codigo { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public int? Administrativo { get; set; }
        public int UnitTest { get; set; }
        public List<CentroCustoDespesa> lstDespesas { get; set; }
    }   
}
