using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestNFServico
    {
        BIZNFServico bizNFServico = new BIZNFServico();

        [TestMethod]
        public void NFServicoIncluir_SemCamposObrigatorios()
        {
            string Msg = string.Empty;
            int idNota = 0;

            Msg = bizNFServico.IncluirNFServico(new NFServico(), out idNota );

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NFServicoIncluir()
        {
            string Msg = string.Empty;
            int idNota = 0;
            
            NFServico nfServico = new NFServico();

            nfServico = this.PreencherDadosObrigatoriosNFServico();
            Msg = bizNFServico.IncluirNFServico(nfServico, out idNota);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NFServicoAlterar_SemCamposObrigatorios()
        {
            string Msg = string.Empty;

            Msg = bizNFServico.AlterarNFServico(new NFServico());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NFServicoAlterar()
        {
            string Msg = string.Empty ;
            NFServico nfServico = new NFServico();

            nfServico = bizNFServico.PesquisarNFServico(new NFServico() { UnitTest = 1 })[0];
            nfServico.descricaoServico = "Alteração";
            
            Msg = bizNFServico.AlterarNFServico(nfServico);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NFServicoPesquisar()
        {
            List<NFServico> lstNFServico = new List<NFServico>();

            lstNFServico = bizNFServico.PesquisarNFServico(new NFServico() { UnitTest = 1 });

            Assert.AreEqual(true,lstNFServico.Count > 0);
        }

        [TestMethod]
        public void NFServicoExcluir()
        {
            List<NFServico> lstNFServico = new List<NFServico>();

            bizNFServico.ExcluirNFServicoTestes();

            lstNFServico = bizNFServico.PesquisarNFServico(new NFServico() {UnitTest = 1 });

            Assert.AreEqual(false, lstNFServico.Count > 0);
        }

        private NFServico PreencherDadosObrigatoriosNFServico()
        {
            NFServico nfServico = new NFServico();
            BIZEmpresa bizEmpresa = new BIZEmpresa();

            nfServico.numeroNota = 999;
            nfServico.idEmpresa = bizEmpresa.PesquisarEmpresa(new Empresa())[0].idEmpresa;
            nfServico.idCliente = new BIZCliente().PesquisarCliente(new Cliente())[0].idCliente;          
            nfServico.numeroProcesso = string.Empty;
            nfServico.Empenho = string.Empty;
            nfServico.dataEmissao = DateTime.Now;
            nfServico.dataPagamento = DateTime.Now;
            nfServico.possuiDataAtes = 0;
            nfServico.dataAtes = DateTime.Now;
            nfServico.possuiDataCAT = 0;
            nfServico.dataCAT = DateTime.Now;
            nfServico.descricaoServico = "Descrição teste";
            nfServico.CNPJ = "59.587.264/0001-36";
            nfServico.pagamentoEfetuado = 0;
            nfServico.valorPago = decimal.Zero;
            nfServico.Cancelado = 0;
            nfServico.lstItens = new List<NFServicoItem>();
            nfServico.observacaoCancelado = string.Empty;
            nfServico.IRPJ = 11;
            nfServico.CSLL = 22;
            nfServico.INSS = 33;
            nfServico.PIS = 44;
            nfServico.COFINS = 55;
            nfServico.ISSQN = 66;

            nfServico.lstItens.Add(new NFServicoItem()
            {
                idNota = 999,
                Descricao = "Teste Item",
                precoUnitario = decimal.Parse("99,99"),
                Unidade = "Un",
                Quantidade = 9,
                UnitTest = 1
            });
            
            
            nfServico.UnitTest = 1;

            return nfServico;
        }
    }
}
