using BRGS.Domain;
using System.Collections.Generic;
using System.Data;

namespace BRGS.Application.Contracts
{
    public interface IFreteFacade
    {
        List<Frete> Pesquisar(Frete frete);

        string Incluir(Frete frete, out int idFrete);

        string Alterar(Frete frete);

        string ValidarExclusao(Frete frete);

        void Excluir(Frete frete);

        DataTable GerarRelatorio(string filtro);
    }
}
