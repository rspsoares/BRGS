using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class ObraFollowUp
    {
        public int idFollowUp { get; set; }
        public int idObra { get; set; }
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int UnitTest { get; set; }
    }
}
