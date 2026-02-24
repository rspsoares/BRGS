using BRGS.Application.Contracts;
using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Bindings
{
    public class AuditoriaFacade : IAuditoriaFacade
    {
        #region Atividade

        public virtual void GerarAuditoriaAtividade(Atividade atividadeOriginal, Atividade atividadeAtualizada, string acao)
        {

        }

        public virtual List<Atividade> PesquisarAuditoriaAtividade(out List<Atividade> lstMaster)
        {
            lstMaster = new List<Atividade>();
            return new List<Atividade>();
        }

        #endregion

        #region Categoria

        public virtual List<Categoria> PesquisarAuditoriaCategoria(out List<Categoria> lstMaster)
        {
            lstMaster = new List<Categoria>();
            return new List<Categoria>();
        }

        public virtual void GerarAuditoriaCategoria(Categoria categoriaOriginal, Categoria categoriaAtualizada, string acao)
        {

        }

        #endregion

        #region Cliente

        public virtual void GerarAuditoriaCliente(Cliente clienteOriginal, Cliente clienteAtualizado, string acao)
        {

        }

        #endregion

        #region Feriado

        public virtual void GerarAuditoriaFeriado(Feriado feriadoOriginal, Feriado feriadoAtualizada, string acao)
        {

        }

        #endregion

        #region Fornecedor

        public virtual void GerarAuditoriaFornecedor(Fornecedor fornecedorOriginal, Fornecedor fornecedorAtualizado, string acao)
        {

        }

        #endregion
    }
}
