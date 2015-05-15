using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Obra
    {
        public int idObra { get; set; }
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public int idCliente { get; set; }

        [Description("Nome do Cliente")]
        public string nomeCliente { get; set; }

        [Description("Número da Licitação")]
        public string numeroLicitacao { get; set; }

        public decimal valorBruto { get; set; }
        
        [Description("Nome do Evento")]
        public string nomeEvento { get; set; }

        public decimal saldoObra { get; set; }
        public decimal totalNotaFiscal { get; set; }
        public decimal totalOPGerada { get; set; }
        public decimal totalOPAberto { get; set; }
        public int Finalizada { get; set; }

        public List<ObraEtapa> lstEtapas { get; set; }
        public int UnitTest { get; set; }
    }
}
