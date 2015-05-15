using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Despesa
    {
        public int idDespesa { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public int? gastoFixo { get; set; }
        public int UnitTest { get; set; }
    }
}
