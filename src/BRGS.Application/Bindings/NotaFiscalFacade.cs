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
    public class NotaFiscalFacade : INotaFiscalFacade
    {
        public virtual List<NotaFiscal> Pesquisar(NotaFiscal notaFiscal)
        {
            return new List<NotaFiscal>();
        }

        public virtual string Incluir(NotaFiscal notaFiscal, out int idNota)
        {
            idNota = 0;
            return "";
        }

        public virtual string Alterar(NotaFiscal notaFiscal)
        {
            return "";
        }

        public virtual void Excluir(NotaFiscal notaFiscal)
        {

        }

        public virtual DataTable GerarRelatorioNotasFiscaisEmitidas(string filtro)
        {
            return new DataTable();
        }

        public virtual DataTable GerarNotaFiscal(int numeroNota)
        {
            return new DataTable();
        }
    }
}
