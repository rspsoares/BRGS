using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class ObraFase
    {
        public int id { get; set; }
        public int idObra { get; set; }
        public int idFase { get; set; }
        public string Descricao { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataPrevTermino { get; set; }
        public DateTime dataTermino { get; set; }
        public int UnitTest { get; set; }
    }
}
