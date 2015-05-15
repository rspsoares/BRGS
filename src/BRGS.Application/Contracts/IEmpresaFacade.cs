using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
