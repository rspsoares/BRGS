using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class FeriadoFacade: IFeriadoFacade
    {
        public virtual List<Feriado> PesquisarFeriados(Feriado feriado)
        {
            return new List<Feriado>();
        }

        public virtual string IncluirFeriado(Feriado feriado, out int idFeriado)
        {
            idFeriado = 0;
            return "";
        }

        public virtual string AlterarFeriado(Feriado feriadoOriginal, Feriado feriadoAtualizado)
        {
            return "";
        }

        public virtual string ExcluirFeriado(Feriado feriado)
        {
            return "";
        }
    }
}
