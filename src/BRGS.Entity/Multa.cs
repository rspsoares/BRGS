using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Multa
    {
        public int idMulta { get; set; }
        public int idGravidade { get; set; }

        [Description("Código")]
        public string Codigo { get; set; }
        
        public int Desdobramento { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        
        public string Infrator { get; set; }
        public int Pontos { get; set; }
        public string orgaoCompetente { get; set; }
        public string descricaoGravidade { get; set; }        
        public decimal Valor { get; set; }
        public int UnitTest { get; set; }
    }
}
