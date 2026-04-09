using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRGS.Entity
{
    public class Empilhadeira
    {
        public Empilhadeira()
        {
            lstManutencoes = new List<EmpilhadeiraManutencao>();
        }

        public int ID { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCliente { get; set; }
        public int IdObraEtapa { get; set; }

        [Description("Número Série")]
        public string NumeroSerie { get; set; }
        
        public string Combustivel { get; set; }

        [Description("Marca")]
        public string Marca { get; set; }

        [Description("Modelo")]
        public string Modelo { get; set; }

        [Description("Lotada")]
        public string Lotada { get; set; }

        public decimal Torre { get; set; }
        public int CapacidadeCarga { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime DataCompra { get; set; }
        public string Acessorios { get; set; }

        [Description("Cliente")]
        public string Cliente { get; set; }

        public List<EmpilhadeiraManutencao> lstManutencoes { get; set; }
    }
}
