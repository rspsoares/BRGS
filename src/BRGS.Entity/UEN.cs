using System.Collections.Generic;
using System.ComponentModel;

namespace BRGS.Entity
{
    public class UEN
    {
        public int idUEN { get; set; }
        
        [Description("Descrição")]
        public string Descricao { get; set; }
        public int? Administrativo { get; set; }
        public List<UENCentroCusto> lstCentrosCustos { get; set; }
        public int UnitTest { get; set; }
    }
}
