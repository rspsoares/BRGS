using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class OrdemPagamento
    {
        public int idOrdemPagamento { get; set; }
        public int idEmpresa { get; set; }

        [Description("Nome Empresa")]
        public string razaoSocial { get; set; }

        public int idObraEtapa { get; set; }
                
        [Description("Número OP")]
        public string numeroOP { get; set; }

        public int idFavorecido { get; set; }
        
        [Description("Favorecido")]
        public string nomeFavorecido { get; set; }
        public bool favorecidoInativo { get; set; }

        public int idContaBancaria { get; set; }

        public string nomeCliente { get; set; }
        public string nomeEvento { get; set; }
        
        public int idSolicitante { get; set; }
        public string nomeSolicitante { get; set; }

        public int idAutorizado { get; set; }
        public string Autorizado { get; set; }

        public DateTime dataCriacao { get; set; }
        public DateTime dataSolicitacao { get; set; }

        [Description("Data Pagamento")]
        public DateTime dataPagamentoParcela { get; set; }

        public decimal valorTotal { get; set; }

        [Description("Data Vencimento")]
        public DateTime dataVencimentoParcela { get; set; }
        
        [Description("Status")]
        public string Status { get; set; }

        [Description("Observação")]
        public string Observacao { get; set; }

        public int Cancelada { get; set; }
        public string observacaoCancelada { get; set; }
        public List<OrdemPagamentoItem> lstItens { get; set; }
        public int UnitTest { get; set; }
    }
}
