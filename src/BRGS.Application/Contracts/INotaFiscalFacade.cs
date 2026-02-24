using BRGS.Domain;
using System.Collections.Generic;
using System.Data;

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
