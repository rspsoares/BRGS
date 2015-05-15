using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BRGS.Domain
{
    public class NFServico
    {
        public int idNota { get; set; }
        public int numeroNota { get; set; } 
        public decimal valorNota { get; set; }
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        
        [Description("Data de Emissão")]
        public DateTime dataEmissao { get; set; }        
        
        public int idCliente { get; set; }

        [Description("Nome Cliente")]
        public string Nome { get; set; }       

        [Description("CPF / CNPJ")]
        public string CNPJ { get; set; }        
        
        public string descricaoServico { get; set; }
        public string numeroProcesso { get; set; }
        
        [Description("Empenho")]
        public string Empenho { get; set; }
        
        public int pagamentoEfetuado { get; set; }
        public decimal valorPago { get; set; }        
        public DateTime dataPagamento { get; set; }
        public int possuiDataAtes { get; set; }
        public DateTime dataAtes { get; set; }
        public int possuiDataCAT { get; set; }
        public DateTime dataCAT { get; set; }
        public int Cancelado { get; set; }
        public string observacaoCancelado { get; set; }
        public decimal IRPJ { get; set; }
        public decimal CSLL { get; set; }
        public decimal INSS { get; set; }
        public decimal PIS { get; set; }
        public decimal COFINS { get; set; }
        public decimal ISSQN { get; set; }
        public List<NFServicoItem> lstItens { get; set; }
        public int UnitTest { get; set; }
    }
}
