using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface IAtividadeFacade
    {
        List<Atividade> Pesquisar(Atividade atividade);
        
        string Incluir(Atividade atividade, out int idAtividade);
        
        string Alterar(Atividade atividadeOriginal, Atividade atividadeAtualizada);
        
        string ValidarExclusao(Atividade atividade);
        
        string Excluir(Atividade atividade);
    }
}
