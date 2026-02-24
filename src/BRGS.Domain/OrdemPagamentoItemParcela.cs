using System;

namespace BRGS.Domain
{
    public class OrdemPagamentoItemParcela
    {        
        public DateTime dataVencimento { get; set; }
        public decimal valorParcela { get; set; }
        public int numeroParcela { get; set; }
        public int totalParcelas { get; set; }
    }
}
