using BRGS.Application.Contracts;
using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Bindings
{
    public class EmpresaFacade: IEmpresaFacade
    {
        public virtual List<Empresa> Pesquisar(Empresa empresa)
        {
            return new List<Empresa>();
        }

        public virtual string Incluir(Empresa empresa, out int idEmpresa)
        {
            idEmpresa = 0;
            return "";
        }

        public virtual string Alterar(Empresa empresa)
        {
            return "";
        }

        public virtual void Excluir(Empresa empresa)
        {

        }
    }
}
