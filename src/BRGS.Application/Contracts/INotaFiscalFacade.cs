using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface INotaFiscalFacade
    {
        List<NotaFiscal> Pesquisar(NotaFiscal notaFiscal);

        string Incluir(NotaFiscal notaFiscal, out int idNota);

        string Alterar(NotaFiscal notaFiscal);

        void Excluir(NotaFiscal notaFiscal);

        DataTable GerarRelatorioNotasFiscaisEmitidas(string filtro);

        DataTable GerarNotaFiscal(int numeroNota);
    }
}
