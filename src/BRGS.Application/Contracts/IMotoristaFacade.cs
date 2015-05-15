using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
