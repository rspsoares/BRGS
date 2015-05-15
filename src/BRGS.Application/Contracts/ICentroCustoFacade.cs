using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface ICentroCustoFacade
    {
        List<CentroCusto> Pesquisar(CentroCusto custo);
        
        List<CentroCustoDespesa> PesquisarDespesasAssociadas(CentroCustoDespesa despesa);
        
        string Incluir(CentroCusto centroCusto, out int idCentroCusto);
        
        string Alterar(CentroCusto centroCusto);
        
        string ValidarExclusao(CentroCusto centroCusto);
        
        string Excluir(CentroCusto centroCusto);
    }
}
