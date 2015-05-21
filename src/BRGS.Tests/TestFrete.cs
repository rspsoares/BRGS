using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestFrete
    {
        private BIZFrete bizFrete = new BIZFrete();

        [TestMethod]
        public void FreteIncluir_SemCamposObrigatorios()
        {
            string Msg = string.Empty;
            int idFrete = 0;

            Msg = bizFrete.IncluirFrete(new Frete(), out idFrete);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FreteIncluir()
        {
            string Msg = string.Empty;
            int idFrete = 0;

            Frete frete = new Frete();

            frete = this.PreencherCamposOrigatoriosFrete();
            Msg = bizFrete.IncluirFrete(frete, out idFrete);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FreteAlterar_SemCamposObrigatorios()
        {
            string Msg = string.Empty;

            Msg = bizFrete.AlterarFrete(new Frete());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FreteAlterar()
        {
            string Msg = string.Empty;

            Frete frete = new Frete();

            frete = bizFrete.PesquisarFrete(new Frete() { UnitTest = 1 })[0];
            frete.Trajeto = "Trajeto Alterado";
            frete.UnitTest = 1;

            Msg = bizFrete.AlterarFrete(frete);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FretePesquisar()
        {
            string Msg = string.Empty;
            List<Frete> lstFretes = new List<Frete>();

            lstFretes = bizFrete.PesquisarFrete(new Frete() { UnitTest = 1 });

            Assert.AreEqual(true, lstFretes.Count > 0);
        }

        [TestMethod]
        public void FreteExcluir()
        {
            string Msg = string.Empty;
            List<Frete> lstFretes = new List<Frete>();

            bizFrete.ExcluirFreteTeste();
            lstFretes = bizFrete.PesquisarFrete(new Frete() { UnitTest = 1 });

            Assert.AreEqual(true, lstFretes.Count == 0);
        }

        private Frete PreencherCamposOrigatoriosFrete()
        {  
            Frete frete = new Frete();
            
            frete.idFrete = 0;
            frete.idFornecedor = 99;
            frete.nomeFornecedor = "aaa";          
            frete.Trajeto = "bbb";           
            frete.previsaoPagamento = DateTime.Today;
            frete.valorTotal = 10;
            frete.UnitTest = 1;
            frete.lstPagamentos = new List<FretePagamento>();
            frete.lstPagamentos.Add(new FretePagamento()
            {
                idFrete = 7,
                idOP = 10,
                UnitTest = 1
            });
            frete.lstObras = new List<FreteObra>();
            frete.lstObras.Add(new FreteObra()
            {
                idObraEtapa = 14,
                idObraEtapaGastoRealizado = 9,
                Data = DateTime.Today,
                idUEN = 9,
                descricaoUEN = "cccc",
                idCentroCusto = 8,
                descricaoCentroCusto = "dddd",
                idDespesa = 15,
                Valor = 10,
            });

            return frete;
        }
    }
}
