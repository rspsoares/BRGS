using BRGS.Application.Contracts;
using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Bindings
{
    public class UENFacade: IUENFacade
    {
        public virtual List<UEN> Pesquisar(UEN uen)
        {
            return new List<UEN>();
        }

        public virtual List<UENCentroCusto> PesquisarCentrosCustosAssociados(UENCentroCusto centrosCustos)
        {
            return new List<UENCentroCusto>();
        }

        public virtual string Incluir(UEN uen, out int idUEN)
        {
            idUEN = 0;
            return "";
        }

        public virtual string Alterar(UEN uen)
        {
            return "";
        }

        public virtual string ValidarExclusao(UEN uen)
        {
            return "";
        }

        public virtual string Excluir(UEN uen)
        {
            return "";
        }
    }
}
