using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class DespesaFacade : IDespesaFacade
    {
        public virtual List<Despesa> Pesquisar(Despesa despesa)
        {
            return new List<Despesa>();
        }

        public virtual string Incluir(Despesa despesa, out int idDespesa)
        {
            idDespesa = 0;
            return "";
        }

        public virtual string Alterar(Despesa despesa)
        {
            return "";
        }

        public virtual string ValidarExclusao(Despesa despesa)
        {
            return "";
        }

        public virtual string Excluir(Despesa despesa)
        {
            return "";
        }
    }
}
