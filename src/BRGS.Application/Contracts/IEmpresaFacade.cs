using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    public interface IEmpresaFacade
    {
        List<Empresa> Pesquisar(Empresa empresa);

        string Incluir(Empresa empresa, out int idEmpresa);

        string Alterar(Empresa empresa);

        void Excluir(Empresa empresa);
    }
}
