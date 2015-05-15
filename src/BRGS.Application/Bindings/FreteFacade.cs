using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class FreteFacade: IFreteFacade
    {
        public virtual List<Frete> Pesquisar(Frete frete)
        {

            return new List<Frete>();
        }

        public virtual string Incluir(Frete frete, out int idFrete)
        {
            idFrete = 0;
            return "";
        }

        public virtual string Alterar(Frete frete)
        {

            return "";
        }

        public virtual string ValidarExclusao(Frete frete)
        {
            return "";
        }

        public virtual void Excluir(Frete frete)
        {
                        
        }

        public virtual DataTable GerarRelatorio(string filtro)
        {

            return new DataTable();
        }
    }
}
