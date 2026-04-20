using System;

namespace BRGS.Entity
{
    public class GeradorUso
    {
        public int ID { get; set; }
        public int IdGerador { get; set; }
        public int IdCliente { get; set; }
        public int IdObraEtapa { get; set; }
        public string NomeCliente { get; set; }
        public string NumeroLicitacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
