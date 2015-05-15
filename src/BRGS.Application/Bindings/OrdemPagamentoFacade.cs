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
    public class OrdemPagamentoFacade : IOrdemPagamentoFacade
    {
        public virtual List<OrdemPagamento> Pesquisar(OrdemPagamento ordemPagamento)
        {
            return new List<OrdemPagamento>();
        }

        public virtual List<OrdemPagamentoItem> PesquisarItem(OrdemPagamentoItem ordemPagamentoItem)
        {
            return new List<OrdemPagamentoItem>();
        }

        public virtual List<OrdemPagamento> PesquisarOPAbastecimento()
        {
            return new List<OrdemPagamento>();
        }

        public virtual string Incluir(OrdemPagamento ordemPagamento, bool origemConsultaOP, out int idOrdemPagamento)
        {
            idOrdemPagamento = 0;
            return "";
        }

        public virtual string Alterar(OrdemPagamento ordemPagamento)
        {
            return "";
        }

        public virtual void Excluir(OrdemPagamento ordemPagamento)
        {

        }

        public virtual DataTable GerarRelatorioOrdemPagamentoEmitida(string filtro)
        {
            return new DataTable();
        }

        public virtual DataTable GerarRelatorioOrdemPagamentoGasto(string filtro)
        {
            return new DataTable();
        }

        public virtual DataTable GerarOrdemPagamento(OrdemPagamento opSelecionada, out DataTable dtObras)
        {
            dtObras = new DataTable();
            return new DataTable();
        }

        public virtual void AtualizarManutencaoOrdemPagamento(Manutencao manutencao)
        {

        }

        public virtual void AtualizarMultaOcorrenciaOrdemPagamento(MultaOcorrencia ocorrencia)
        {

        }
    }
}
