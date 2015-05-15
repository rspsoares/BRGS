using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class ClienteContato : _Auditoria, ICloneable
    {
        public int idCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int UnitTest { get; set; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public ClienteContato Clone()
        {
            return (ClienteContato)this.MemberwiseClone();
        }
    }
}
