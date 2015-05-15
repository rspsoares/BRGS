using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class FornecedorContato : _Auditoria, ICloneable
    {
        public int idFornecedor { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int UnitTest { get; set; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public FornecedorContato Clone()
        {
            return (FornecedorContato)this.MemberwiseClone();
        }
    }
}
