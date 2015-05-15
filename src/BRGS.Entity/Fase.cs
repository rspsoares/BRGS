using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Fase
    {
        public int idFase { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public int UnitTest { get; set; }
    }
}
