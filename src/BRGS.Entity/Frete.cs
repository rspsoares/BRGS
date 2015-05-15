using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Frete
    {
        public int idFrete { get; set; }

        [Description("Número")]
        public string numeroFrete { get; set; }
        public int idFornecedor { get; set; }

        [Description("Fornecedor")]
        public string nomeFornecedor { get; set; }

        [Description("Trajeto")]
        public string Trajeto { get; set; }        
        public DateTime previsaoPagamento { get; set; }
        public decimal valorTotal { get; set; }
        public int UnitTest { get; set; }
        public List<FretePagamento> lstPagamentos = new List<FretePagamento>();
        public List<FreteObra> lstObras { get; set; }
    }
}
