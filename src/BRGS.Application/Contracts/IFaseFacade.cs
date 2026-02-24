using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    public interface IFaseFacade
    {
        List<Fase> Pesquisar(Fase fase);

        List<Obra> PesquisarObrasAssociadas(Fase fase);

        string Incluir(Fase fase, out int idFase);

        string Alterar(Fase fase);

        string ValidarExclusao(Fase fase);

        string Excluir(Fase fase);
    }
}
