using System;

namespace BRGS.Entity
{
    public class GeradorManutencao
    {
        public int ID { get; set; }
        public int IdGerador { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
