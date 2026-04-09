using System;

namespace BRGS.Entity
{
    public class EmpilhadeiraManutencao
    {
        public int ID { get; set; }
        public int IdEmpilhadeira { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}