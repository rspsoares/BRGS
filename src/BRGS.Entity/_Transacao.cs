using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class _Transacao
    {
        public string nomeProcedure { get; set; }
        public Dictionary<string, string> lstParametros { get; set; }
    }
}
