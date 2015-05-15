using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface IAuditoriaFacade
    {
        #region Atividade
        
        void GerarAuditoriaAtividade(Atividade atividadeOriginal, Atividade atividadeAtualizada, string acao);
        
        List<Atividade> PesquisarAuditoriaAtividade(out List<Atividade> lstMaster);

        #endregion

        #region Categoria

        List<Categoria> PesquisarAuditoriaCategoria(out List<Categoria> lstMaster);

        void GerarAuditoriaCategoria(Categoria categoriaOriginal, Categoria categoriaAtualizada, string acao);

        #endregion

        #region Cliente

        void GerarAuditoriaCliente(Cliente clienteOriginal, Cliente clienteAtualizado, string acao);

        #endregion

        #region Feriado

        void GerarAuditoriaFeriado(Feriado feriadoOriginal, Feriado feriadoAtualizada, string acao);

        #endregion

        #region Fornecedor

        void GerarAuditoriaFornecedor(Fornecedor fornecedorOriginal, Fornecedor fornecedorAtualizado, string acao);

        #endregion
    }
}
