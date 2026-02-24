using BRGS.Domain;
using System.Collections.Generic;

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
