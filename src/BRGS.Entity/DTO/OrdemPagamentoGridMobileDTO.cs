using System;

namespace BRGS.Entity.DTO
{
    public class OrdemPagamentoGridMobileDTO
    {
        public int IdOrdemPagamento { get; set; }
        public string NumeroOP { get; set; }
        public string NomeFavorecido { get; set; }
        public string NomeCliente { get; set; }        
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public DateTime DataPagamentoParcela { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
