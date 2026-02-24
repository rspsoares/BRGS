using System.ComponentModel;

namespace BRGS.Entity
{
    public class Despesa
    {
        public int idDespesa { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public int? gastoFixo { get; set; }
        public int UnitTest { get; set; }
    }
}
