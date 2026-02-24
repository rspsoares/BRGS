using BRGS.Application.Contracts;
using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Bindings
{
    public class CentroCustoFacade: ICentroCustoFacade
    {
        public virtual List<CentroCusto> Pesquisar(CentroCusto custo)
        {
            return new List<CentroCusto>();
        }

        public virtual List<CentroCustoDespesa> PesquisarDespesasAssociadas(CentroCustoDespesa despesa)
        {
            return new List<CentroCustoDespesa>();
        }

        public virtual string Incluir(CentroCusto centroCusto, out int idCentroCusto)
        {
            idCentroCusto = 0;
            return "";
        }

        public virtual string Alterar(CentroCusto centroCusto)
        {
            return "";
        }

        public virtual string ValidarExclusao(CentroCusto centroCusto)
        {
            return "";
        }

        public virtual string Excluir(CentroCusto centroCusto)
        {
            return "";
        }
    }
}
