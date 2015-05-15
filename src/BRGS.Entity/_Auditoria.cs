using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class _Auditoria
    {
        public int idLog { get; set; }
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }        
        public DateTime dataAlteracao { get; set; }        
        public string Acao { get; set; }      
    }
}
