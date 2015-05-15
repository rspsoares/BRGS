using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface ICategoriaFacade
    {
        List<Categoria> Pesquisar(Categoria categoria);

        string Incluir(Categoria categoria, out int idCategoria);
        
        string Alterar(Categoria categoriaOriginal, Categoria categoriaAtualizada);

        string ValidarExclusao(Categoria categoria);

        string ExcluirCategoria(Categoria categoria);
    }
}
