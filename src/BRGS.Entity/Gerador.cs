using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BRGS.Entity
{
    public class Gerador
    {
        public Gerador()
        {
            lstManutencoes = new List<GeradorManutencao>();
        }

        public int ID { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCliente { get; set; }
        public int IdObraEtapa { get; set; }
        public DateTime DataAlocacao { get; set; }

        [Description("Número Série")]
        public string NumeroSerie { get; set; }

        public string Combustivel { get; set; }

        [Description("Marca")]
        public string Marca { get; set; }

        [Description("Modelo")]
        public string Modelo { get; set; }

        [Description("Lotado")]
        public string Lotado { get; set; }

        public string NotaFiscal { get; set; }
        public DateTime DataCompra { get; set; }
        public string Acessorios { get; set; }

        [Description("Cliente")]
        public string Cliente { get; set; }

        public List<GeradorManutencao> lstManutencoes { get; set; }
    }
}
