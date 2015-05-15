using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class MotoristaFacade : IMotoristaFacade
    {
        public virtual List<Motorista> Pesquisar(Motorista motorista)
        {

            return new List<Motorista>();
        }

        public virtual string Incluir(Motorista motorista, out int idMotorista)
        {
            idMotorista = 0;
            return "";
        }

        public virtual string Alterar(Motorista motorista)
        {
            return "";
        }

        public virtual string Excluir(Motorista motorista)
        {
            return "";
        }
    }
}
