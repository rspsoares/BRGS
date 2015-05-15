using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestOrdemPagamento
    {
        private BIZOrdemPagamento bizOrdemPagamento = new BIZOrdemPagamento();

        [TestMethod]
        public void OrdemPagamentoIncluir_SemCamposObrigatorios()
        {
            OrdemPagamento opTeste = new OrdemPagamento();
            string Msg = string.Empty;
            int idOP = 0;

            opTeste.lstItens = new List<OrdemPagamentoItem>();
            Msg = bizOrdemPagamento.IncluirOrdemPagamento(opTeste, true, out idOP);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void OrdemPagamentoIncluir()
        {
            string Msg = string.Empty;
            int idOP = 0;

            OrdemPagamento ordemPagamento = new OrdemPagamento();

            ordemPagamento = this.PreencherCamposOrigatorios();
            Msg = bizOrdemPagamento.IncluirOrdemPagamento(ordemPagamento,true, out idOP);

            Assert.AreEqual(string.Empty, Msg);
        }
      
        [TestMethod]
        public void OrdemPagamentoAlterar_SemCamposObrigatorios()
        {
            OrdemPagamento opTeste = new OrdemPagamento();
            string Msg = string.Empty;

            opTeste.lstItens = new List<OrdemPagamentoItem>();
            Msg = bizOrdemPagamento.AlterarOrdemPagamento(opTeste);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void OrdemPagamentoAlterar()
        {
            string Msg = string.Empty;

            OrdemPagamento ordemPagamento = new OrdemPagamento();

            ordemPagamento = bizOrdemPagamento.PesquisarOrdemPagamento(new OrdemPagamento() { UnitTest = 1 })[0];
            ordemPagamento.lstItens = bizOrdemPagamento.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idOrdemPagamento = ordemPagamento.idOrdemPagamento });
            ordemPagamento.nomeSolicitante = "Solicitante Alterado";
            ordemPagamento.Status = "Teste Status";
            ordemPagamento.UnitTest = 1;

            Msg = bizOrdemPagamento.AlterarOrdemPagamento(ordemPagamento);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void OrdemPagamentoPesquisar()
        {
            string Msg = string.Empty;
            List<OrdemPagamento> lstOP = new List<OrdemPagamento>();

            lstOP = bizOrdemPagamento.PesquisarOrdemPagamento(new OrdemPagamento() { UnitTest = 1 });

            Assert.AreEqual(true, lstOP.Count > 0);
        }

        [TestMethod]
        public void OrdemPagamentoExcluir()
        {
            string Msg = string.Empty;
            List<OrdemPagamento> lstOP = new List<OrdemPagamento>();

            bizOrdemPagamento.ExcluirOrdemPagamentoTestes();
            
            lstOP = bizOrdemPagamento.PesquisarOrdemPagamento(new OrdemPagamento() { UnitTest = 1 });

            Assert.AreEqual(true, lstOP.Count == 0);
        }

        private OrdemPagamento PreencherCamposOrigatorios()
        {
            UEN UEN = new UEN();
            CentroCusto centroCusto = new CentroCusto();
            Despesa despesa = new Despesa();
            ObraEtapa obra = new ObraEtapa();
            OrdemPagamento ordemPagamento = new OrdemPagamento();

            ordemPagamento.idEmpresa = new BIZEmpresa().PesquisarEmpresa(new Empresa())[0].idEmpresa;
            ordemPagamento.idObraEtapa = new BIZObra().PesquisarObraEtapa(new ObraEtapa() { UnitTest = 1 })[0].idObraEtapa;
            ordemPagamento.idFavorecido = new BIZFornecedor().PesquisarFornecedor(new Fornecedor() { UnitTest = 1 })[0].idFornecedor;      
            ordemPagamento.idContaBancaria = new BIZFornecedor().PesquisarFornecedorContaBancaria(new FornecedorContaBancaria() { idFornecedor = ordemPagamento.idFavorecido})[0].idContaBancaria;
            ordemPagamento.idSolicitante = 1;
            ordemPagamento.idAutorizado = 9;            
            ordemPagamento.dataSolicitacao = DateTime.Now;            
            ordemPagamento.Status = string.Empty;

            UEN = new BIZUEN().PesquisarUEN(new UEN())[0];
            centroCusto = new BIZCentroCusto().PesquisarCentroCusto(new CentroCusto())[0];
            despesa = new BIZDespesa().PesquisarDespesa(new Despesa())[0];

            ordemPagamento.lstItens = new List<OrdemPagamentoItem>();
            ordemPagamento.lstItens.Add(new OrdemPagamentoItem()
            {
                idUEN = UEN.idUEN,
                idCentroCusto = centroCusto.idCentroCusto,
                idDespesa = despesa.idDespesa,
                idUsuarioPagamento = new BIZUsuario().PesquisarUsuario(new Usuario())[0].idUsuario,
                idAbastecimento = 9,
                Valor = Decimal.Parse("999.99"),
                valorPago = Decimal.Parse("999.99"),       
                dataVencimento = DateTime.Now,
                dataPagamento = DateTime.Now, 
                numeroParcela = 9,
                totalParcelas = 999,
                Desconto = 111,
                Multa = 222,
                UnitTest = 1
            });
            
            ordemPagamento.Observacao = "Observacão";
            ordemPagamento.Cancelada = 9;
            ordemPagamento.observacaoCancelada = "teste cancelamento";
            ordemPagamento.UnitTest = 1;

            return ordemPagamento;
        }
    }
}
