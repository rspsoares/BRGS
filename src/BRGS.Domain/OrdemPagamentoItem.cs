using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class OrdemPagamentoItem
    {
        public int idOrdemPagamentoItem { get; set; }
        public int idOrdemPagamento { get; set; }
        public int idObraGastoRealizado { get; set; }
        public int idAbastecimento { get; set; }
        public int idManutencao { get; set; }
        public int idFrete { get; set; }
        public int idOcorrenciaMulta { get; set; }
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public int idCentroCusto { get; set; }
        public string descricaoCentroCusto { get; set; }
        public int idDespesa { get; set; }
        public string descricaoDespesa { get; set; }
        public int idUsuarioPagamento { get; set; }
        public string nomeUsuarioPagamento { get; set; }
        public decimal Valor { get; set; }
        public decimal valorPago { get; set; }
        public decimal Desconto { get; set; }
        public decimal Multa { get; set; }
        public DateTime dataVencimento { get; set; }
        public DateTime dataPagamento { get; set; }
        public int numeroParcela { get; set; }
        public int totalParcelas { get; set; }
        public int UnitTest { get; set; }
    }
}