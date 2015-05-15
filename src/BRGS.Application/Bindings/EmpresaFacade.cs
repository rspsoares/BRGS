using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
