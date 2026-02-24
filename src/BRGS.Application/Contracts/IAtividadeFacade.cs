using BRGS.Domain;
using System.Collections.Generic;

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
