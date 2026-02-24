using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    public interface IFornecedorFacade
    {   
        List<Fornecedor> Pesquisar(Fornecedor fornecedor);

        List<Fornecedor> PesquisarCombo(Fornecedor fornecedor);

        string Incluir(Fornecedor fornecedor, out int idFornecedor);

        string Alterar(Fornecedor fornecedorOriginal, Fornecedor fornecedorSelecionado);

        string ValidarExclusao(Fornecedor fornecedor);

        void Excluir(Fornecedor fornecedor);
    }
}
