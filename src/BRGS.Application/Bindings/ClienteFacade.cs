using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class ClienteFacade: IClienteFacade
    {
        public virtual List<Cliente> Pesquisar(Cliente cliente)
        {
            return new List<Cliente>();
        }

        public virtual string Incluir(Cliente cliente, out int idCliente)
        {
            idCliente = 0;
            return "";
        }

        public virtual string Alterar(Cliente clienteOriginal, Cliente clienteAtualizado)
        {
            return "";
        }

        public virtual string ValidarExclusao(Cliente cliente)
        {
            return "";
        }

        public virtual void Excluir(Cliente cliente)
        {

        }
    }
}
