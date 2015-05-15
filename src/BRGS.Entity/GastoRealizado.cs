using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class GastoRealizado
    {
        public int idObra { get; set; }
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public int idCentroCusto { get; set; }
        public string descricaoCentroCusto { get; set; }
        public int idDespesa { get; set; }
        public string descricaoDespesa { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int idOrdemPagamento { get; set; }
        public string statusOrdemPagamento { get; set; }
        public string Observacao { get; set; }
        public int UnitTest { get; set; }
    }
}
