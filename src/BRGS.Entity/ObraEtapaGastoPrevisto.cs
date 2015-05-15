using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class ObraEtapaGastoPrevisto
    {
        public int idObraEtapa { get; set; }
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public int idCentroCusto { get; set; }
        public string descricaoCentroCusto { get; set; }
        public int idDespesa { get; set; }
        public string descricaoDespesa { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public int UnitTest { get; set; }
    }
}
