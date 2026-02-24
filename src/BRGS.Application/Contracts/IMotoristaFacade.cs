using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    interface IMotoristaFacade
    {
        List<Motorista> Pesquisar(Motorista motorista);
        
        string Incluir(Motorista motorista, out int idMotorista);

        string Alterar(Motorista motorista);

        string Excluir(Motorista motorista);
    }
}
