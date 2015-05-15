using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestNotaFiscal
    {
        BIZNotaFiscal bizNotaFiscal = new BIZNotaFiscal();

        [TestMethod]
        public void NotaFiscalIncluir_SemCamposObrigatorios()
        {
            string Msg = string.Empty;
            int idNota = 0;

            Msg = bizNotaFiscal.IncluirNotaFiscal(new NotaFiscal(), out idNota );

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NotaFiscalIncluir()
        {
            string Msg = string.Empty;
            int idNota = 0;
            
            NotaFiscal notaFiscal = new NotaFiscal();

            notaFiscal = this.PreencherDadosObrigatoriosNotaFiscal();
            Msg = bizNotaFiscal.IncluirNotaFiscal(notaFiscal, out idNota);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NotaFiscalAlterar_SemCamposObrigatorios()
        {
            string Msg = string.Empty;

            Msg = bizNotaFiscal.AlterarNotaFiscal(new NotaFiscal());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NotaFiscalAlterar()
        {
            string Msg = string.Empty ;
            NotaFiscal notaFiscal = new NotaFiscal();

            notaFiscal = bizNotaFiscal.PesquisarNotaFiscal(new NotaFiscal() { UnitTest = 1 })[0];
            notaFiscal.descricaoServico = "Alteração";
            
            Msg = bizNotaFiscal.AlterarNotaFiscal(notaFiscal);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void NotaFiscalPesquisar()
        {
            List<NotaFiscal> lstNF = new List<NotaFiscal>();

            lstNF = bizNotaFiscal.PesquisarNotaFiscal(new NotaFiscal() { UnitTest = 1 });

            Assert.AreEqual(true, lstNF.Count > 0);
        }

        [TestMethod]
        public void NotaFiscalPrazoPagamentoPesquisar()
        {
            List<NotaFiscalPrazoPagamento> lstPrazos = new List<NotaFiscalPrazoPagamento>();

            lstPrazos = bizNotaFiscal.PesqisarPrazoPagamento();

            Assert.AreEqual(true, lstPrazos.Count > 0);
        }

        [TestMethod]
        public void NotaFiscalExcluir()
        {
            List<NotaFiscal> lstNF = new List<NotaFiscal>();

            bizNotaFiscal.ExcluirNotaFiscalTestes();

            lstNF = bizNotaFiscal.PesquisarNotaFiscal(new NotaFiscal() { UnitTest = 1 });

            Assert.AreEqual(false, lstNF.Count > 0);
        }

        private NotaFiscal PreencherDadosObrigatoriosNotaFiscal()
        {
            NotaFiscal notaFiscal = new NotaFiscal();
            BIZEmpresa bizEmpresa = new BIZEmpresa();

            notaFiscal.numeroNota = 999;
            notaFiscal.tipoNota = 9;
            notaFiscal.codigoVerificacao = "XXXXXXXXX";
            notaFiscal.tipoOperacao = 8;
            notaFiscal.Contrato = "ABC 123";
            notaFiscal.idEmpresa = bizEmpresa.PesquisarEmpresa(new Empresa())[0].idEmpresa;
            notaFiscal.idCliente = new BIZCliente().PesquisarCliente(new Cliente())[0].idCliente;
            notaFiscal.idPrazoPagamento = 1;
            notaFiscal.numeroProcesso = string.Empty;
            notaFiscal.Empenho = string.Empty;
            notaFiscal.dataEmissao = DateTime.Now;
            notaFiscal.dataPagamento = DateTime.Now;
            notaFiscal.possuiDataAtes = 0;
            notaFiscal.dataAtes = DateTime.Now;
            notaFiscal.possuiDataCAT = 0;
            notaFiscal.dataCAT = DateTime.Now;
            notaFiscal.descricaoServico = "Descrição teste";
            notaFiscal.CNPJ = "59.587.264/0001-36";
            notaFiscal.pagamentoEfetuado = 0;
            notaFiscal.valorPago = decimal.Zero;
            notaFiscal.Cancelado = 0;
            notaFiscal.lstItens = new List<NotaFiscalItem>();
            notaFiscal.observacaoCancelado = string.Empty;
            notaFiscal.IRPJ = 11;
            notaFiscal.CSLL = 22;
            notaFiscal.INSS = 33;
            notaFiscal.PIS = 44;
            notaFiscal.COFINS = 55;
            notaFiscal.ISSQN = 66;

            notaFiscal.lstItens.Add(new NotaFiscalItem()
            {
                idNota = 999,
                Descricao = "Teste Item",
                precoUnitario = decimal.Parse("99,99"),
                Unidade = "Un",
                Quantidade = 9,
                UnitTest = 1
            });
                        
            notaFiscal.UnitTest = 1;

            return notaFiscal;
        }
    }
}
