using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class _FiltroRelatorio
    {
        public string nomeCampo { get; set; }
        public string tipoComparacao { get; set; }
        public string valorInicio { get; set; }
        public string valorFim { get; set; }
        public string filtroSQL { get; set; }
    }
}
