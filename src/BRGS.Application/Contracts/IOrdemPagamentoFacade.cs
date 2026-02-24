using BRGS.Domain;
using System.Collections.Generic;
using System.Data;

namespace BRGS.Application.Contracts
{
    public interface IOrdemPagamentoFacade
    {
        List<OrdemPagamento> Pesquisar(OrdemPagamento ordemPagamento);

        List<OrdemPagamentoItem> PesquisarItem(OrdemPagamentoItem ordemPagamentoItem);

        List<OrdemPagamento> PesquisarOPAbastecimento();
        
        string Incluir(OrdemPagamento ordemPagamento, bool origemConsultaOP, out int idOrdemPagamento);

        string Alterar(OrdemPagamento ordemPagamento);

        void Excluir(OrdemPagamento ordemPagamento);

        DataTable GerarRelatorioOrdemPagamentoEmitida(string filtro);

        DataTable GerarRelatorioOrdemPagamentoGasto(string filtro);

        DataTable GerarOrdemPagamento(OrdemPagamento opSelecionada, out DataTable dtObras);

        void AtualizarManutencaoOrdemPagamento(Manutencao manutencao);

        void AtualizarMultaOcorrenciaOrdemPagamento(MultaOcorrencia ocorrencia);
    }
}
