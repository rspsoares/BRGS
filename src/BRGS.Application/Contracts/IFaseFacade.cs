using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
