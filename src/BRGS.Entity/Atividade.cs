using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Atividade : _Auditoria, ICloneable
    {
        public int idAtividade { get; set; }
        
        [Description("Descrição")]
        public string Descricao { get; set; }
        public int UnitTest { get; set; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
        
        public Atividade Clone()
        {
            return (Atividade)this.MemberwiseClone();
        }
    }
}
