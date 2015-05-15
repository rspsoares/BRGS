using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface IUENFacade
    {
        List<UEN> Pesquisar(UEN uen);
        
        List<UENCentroCusto> PesquisarCentrosCustosAssociados(UENCentroCusto centrosCustos);
        
        string Incluir(UEN uen, out int idUEN);
        
        string Alterar(UEN uen);
        
        string ValidarExclusao(UEN uen);
        
        string Excluir(UEN uen);
    }
}
