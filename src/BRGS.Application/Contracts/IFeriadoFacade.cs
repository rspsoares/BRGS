using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    public interface IFeriadoFacade
    {
        List<Feriado> PesquisarFeriados(Feriado feriado);

        string IncluirFeriado(Feriado feriado, out int idFeriado);

        string AlterarFeriado(Feriado feriadoOriginal, Feriado feriadoAtualizado);

        string ExcluirFeriado(Feriado feriado);
    }
}
