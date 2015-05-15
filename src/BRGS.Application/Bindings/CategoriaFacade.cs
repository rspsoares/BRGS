using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class CategoriaFacade: ICategoriaFacade
    {
        public virtual List<Categoria> Pesquisar(Categoria categoria)
        {
            return new List<Categoria>();
        }

        public virtual string Incluir(Categoria categoria, out int idCategoria)
        {
            idCategoria = 0;
            return "";
        }

        public virtual string Alterar(Categoria categoriaOriginal, Categoria categoriaAtualizada)
        {
            return "";
        }

        public virtual string ValidarExclusao(Categoria categoria)
        {
            return "";
        }

        public virtual string ExcluirCategoria(Categoria categoria)
        {
            return "";
        }
    }
}
