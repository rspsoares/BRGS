using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
