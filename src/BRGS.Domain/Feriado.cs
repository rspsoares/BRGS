using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class Feriado : _Auditoria, ICloneable
    {
        public int idFeriado { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public int UnitTest { get; set; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Feriado Clone()
        {
            return (Feriado)this.MemberwiseClone();
        }
    }
}
