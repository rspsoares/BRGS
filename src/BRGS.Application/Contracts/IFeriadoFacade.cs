using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
