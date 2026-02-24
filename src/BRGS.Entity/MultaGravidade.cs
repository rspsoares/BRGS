using System.ComponentModel;

namespace BRGS.Entity
{
    public class MultaGravidade
    {
        public int idGravidade { get; set; }
        
        [Description("Descrição")]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int UnitTest { get; set; }
    }
}
