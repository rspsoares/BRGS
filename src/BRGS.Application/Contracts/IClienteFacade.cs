using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    public interface IClienteFacade
    {
        List<Cliente> Pesquisar(Cliente cliente);

        string Incluir(Cliente cliente, out int idCliente);

        string Alterar(Cliente clienteOriginal, Cliente clienteAtualizado);

        string ValidarExclusao(Cliente cliente);

        void Excluir(Cliente cliente);
    }
}
