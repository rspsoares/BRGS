using System;

namespace BRGS.Entity.DTO
{
    public class OrdemPagamentoGridFiltroMobileDTO
    {
        public string numeroOP { get; set; }
        public string nomeFavorecido { get; set; }        
        public DateTime dataPagamentoParcelaInicial { get; set; }
        public DateTime dataPagamentoParcelaFinal { get; set; }
        public string Status { get; set; }
        public string Sort { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
