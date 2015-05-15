using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class FaseFacade: IFaseFacade
    {
        public virtual List<Fase> Pesquisar(Fase fase)
        {
            return new List<Fase>();
        }

        public virtual List<Obra> PesquisarObrasAssociadas(Fase fase)
        {
            return new List<Obra>();
        }

        public virtual string Incluir(Fase fase, out int idFase)
        {
            idFase = 0;
            return "";
        }

        public virtual string Alterar(Fase fase)
        {
            return "";
        }

        public virtual string ValidarExclusao(Fase fase)
        {
            return "";
        }

        public virtual string Excluir(Fase fase)
        {
            return "";
        }
    }
}
