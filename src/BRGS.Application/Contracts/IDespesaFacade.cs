using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    public interface IDespesaFacade
    {
        List<Despesa> Pesquisar(Despesa despesa);

        string Incluir(Despesa despesa, out int idDespesa);

        string Alterar(Despesa despesa);

        string ValidarExclusao(Despesa despesa);

        string Excluir(Despesa despesa);
    }
}
