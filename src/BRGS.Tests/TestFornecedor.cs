using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestFornecedor
    {
        private BIZFornecedor bizFornecedor = new BIZFornecedor();

        [TestMethod]
        public void FornecedorPesquisar()
        {
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();

            lstFornecedores = bizFornecedor.PesquisarFornecedor(new Fornecedor());

            Assert.AreEqual(true, lstFornecedores.Count > 0);
        }

        [TestMethod]
        public void FornecedorIncluir_SemCamposObrigatorios()
        {
            int idFornecedor = 0;
            string Msg = string.Empty;

            Msg = bizFornecedor.IncluirFornecedor(new Fornecedor(), out idFornecedor);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FornecedorIncluir()
        {
            int idFornecedor = 0;
            string Msg = string.Empty;
            Fornecedor fornecedor = new Fornecedor();

            fornecedor = this.PreencherCamposObrigatorios();

            Msg = bizFornecedor.IncluirFornecedor(fornecedor, out idFornecedor);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FornecedorAlterar_SemCamposObrigatorios()
        {            
            string Msg = string.Empty;

            Msg = bizFornecedor.AlterarFornecedor(new Fornecedor(), new Fornecedor());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FornecedorAlterar()
        {            
            string Msg = string.Empty;
            Fornecedor fornecedor = new Fornecedor();

            fornecedor = this.PreencherCamposObrigatorios();
            fornecedor.Nome = "Alterado";

            Msg = bizFornecedor.AlterarFornecedor(fornecedor,fornecedor);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FornecedorContaBancariaIncluir()
        {
            string Msg = string.Empty;
            FornecedorContaBancaria contaBancaria = new FornecedorContaBancaria();
            List<FornecedorContaBancaria> lstContasTeste = new List<FornecedorContaBancaria>();
            Fornecedor fornecedor = new Fornecedor();

            fornecedor = bizFornecedor.PesquisarFornecedor(new Fornecedor())[0];

            contaBancaria.idFornecedor = fornecedor.idFornecedor;
            contaBancaria.Banco = "11";
            contaBancaria.Agencia = "22";
            contaBancaria.TipoConta = "aa";
            contaBancaria.Conta = "33";
            contaBancaria.UnitTest = 1;

            bizFornecedor.IncluirContaBancaria(contaBancaria);

            lstContasTeste = bizFornecedor.PesquisarFornecedorContaBancaria(new FornecedorContaBancaria() { UnitTest = 1 });

            Assert.AreEqual(true, lstContasTeste.Count > 0);
        }

        [TestMethod]
        public void FornecedorContaBancariaExcluir()
        {
            List<FornecedorContaBancaria> lstContasTeste = new List<FornecedorContaBancaria>();
            FornecedorContaBancaria contaBancaria = new FornecedorContaBancaria();

            contaBancaria = bizFornecedor.PesquisarFornecedorContaBancaria(new FornecedorContaBancaria() { UnitTest = 1 })[0];

            bizFornecedor.ExcluirContaBancaria(contaBancaria.idContaBancaria);

            lstContasTeste = bizFornecedor.PesquisarFornecedorContaBancaria(new FornecedorContaBancaria() { UnitTest = 1 });

            Assert.AreEqual(true, lstContasTeste.Count == 0);
        }

        [TestMethod]
        public void FornecedorExcluir()
        {
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
            
            bizFornecedor.ExcluirFornecedorTeste();
            lstFornecedores = bizFornecedor.PesquisarFornecedor(new Fornecedor() { UnitTest = 1 });

            Assert.AreEqual(true, lstFornecedores.Count == 0);
        }

        private Fornecedor PreencherCamposObrigatorios()
        {
            Fornecedor fornecedor = new Fornecedor();

            fornecedor.Codigo = "codigo";
            fornecedor.Nome = "Teste";
            fornecedor.CPF_CNPJ = "59.587.264/0001-36";
            fornecedor.IE = "111";
            fornecedor.ICM = "2999";
            fornecedor.Endereco = "222";
            fornecedor.Complemento = "333";
            fornecedor.Bairro = "999";
            fornecedor.Cidade = "767";
            fornecedor.Estado = "SS";
            fornecedor.CEP = "87587";
            fornecedor.Pais = "yy";
            fornecedor.Telefone = "fd";
            fornecedor.Fax = "gdt";
            fornecedor.Email = "teste@cliente.com";
            fornecedor.TipoPessoa = "X";
            fornecedor.Site = "7798";
            fornecedor.Observacao= "7689698";            
            fornecedor.Status = "Nana";

            fornecedor.lstContatos = new List<FornecedorContato>();
            fornecedor.lstContatos.Add(new FornecedorContato()
            {
                Nome = "Contato",
                Telefone = "9999",
                Email = "rtrtrtrtrt",
                UnitTest = 1
            });

            fornecedor.lstContasBancarias = new List<FornecedorContaBancaria>();
            fornecedor.lstContasBancarias.Add(new FornecedorContaBancaria()
            {
                Banco = "BANCO",
                Agencia = "AGÊNCIA",
                TipoConta = "TIPO CONTA",
                Conta = "CONTA",
                UnitTest = 1
            });

            fornecedor.UnitTest = 1;

            return fornecedor;
        }
    }
}