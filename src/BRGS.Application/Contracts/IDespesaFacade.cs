using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface IDespesaFacade
    {
        List<Despesa> Pesquisar(Despesa despesa);

        string Incluir(Despesa despesa, out int idDespesa);

        string Alterar(Despesa despesa);

        string ValidarExclusao(Despesa despesa);

        string Excluir(Despesa despesa);
    }
}
