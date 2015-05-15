using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class Categoria : _Auditoria, ICloneable
    {
        public int idCategoria { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public int UnitTest { get; set; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Categoria Clone()
        {
            return (Categoria)this.MemberwiseClone();
        }

    }
}
