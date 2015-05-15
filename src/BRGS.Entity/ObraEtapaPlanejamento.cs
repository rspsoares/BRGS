using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class ObraEtapaPlanejamento
    {
        public int idPlanejamento { get; set; }
        public int idObraEtapa { get; set; }
        public string descricaoEtapa { get; set; }
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public decimal valorPrevisto { get; set; }        
        public int UnitTest { get; set; }
    }
}
