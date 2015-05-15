using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class FornecedorFacade: IFornecedorFacade
    {
        public virtual List<Fornecedor> Pesquisar(Fornecedor fornecedor)
        {
            return new List<Fornecedor>();
        }

        public virtual List<Fornecedor> PesquisarCombo(Fornecedor fornecedor)
        {
            return new List<Fornecedor>();
        }

        public virtual string Incluir(Fornecedor fornecedor, out int idFornecedor)
        {
            idFornecedor = 0;
            return "";
        }

        public virtual string Alterar(Fornecedor fornecedorOriginal, Fornecedor fornecedorSelecionado)
        {
            return "";
        }

        public virtual string ValidarExclusao(Fornecedor fornecedor)
        {
            return "";
        }

        public virtual void Excluir(Fornecedor fornecedor)
        {

        }
    }
}
