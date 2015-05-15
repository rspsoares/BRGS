using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestCliente
    {
        private BIZCliente bizCliente = new BIZCliente();
 
        [TestMethod]
        public void ClientePesquisar()
        {            
            List<Cliente> lstClientes = new List<Cliente>();

            lstClientes = bizCliente.PesquisarCliente(new Cliente());

            Assert.AreEqual(true, lstClientes.Count > 0);
        }

        [TestMethod]
        public void ClienteIncluir_SemCamposObrigatorios()
        {
            int idCliente = 0;
            string Msg = string.Empty;

            Msg = bizCliente.IncluirCliente(new Cliente(), out idCliente);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ClienteIncluir()
        {
            int idCliente = 0;
            string Msg = string.Empty;
            Cliente cliente = new Cliente();            

            cliente = this.PreencherCamposObrigatorios();

            Msg = bizCliente.IncluirCliente(cliente, out idCliente);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ClienteAlterar_SemCamposObrigatorios()
        {            
            string Msg = string.Empty;

            Msg = bizCliente.AlterarCliente(new Cliente(), new Cliente());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ClienteAlterar()
        {            
            string Msg = string.Empty;
            Cliente cliente = new Cliente();

            cliente = this.PreencherCamposObrigatorios();
            cliente.Nome = "Alterado";

            Msg = bizCliente.AlterarCliente(cliente,cliente);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ClienteExcluir()
        {
            List<Cliente> lstClientes = new List<Cliente>();
            
            bizCliente.ExcluirClienteTeste();
            lstClientes = bizCliente.PesquisarCliente(new Cliente() { UnitTest = 1 });

            Assert.AreEqual(true, lstClientes.Count == 0);
        }

        private Cliente PreencherCamposObrigatorios()
        {
            Cliente cliente = new Cliente();

            cliente.Codigo = "codigo";
            cliente.Nome = "Teste";
            cliente.CPF_CNPJ = "59.587.264/0001-36";
            cliente.IE = "111";
            cliente.ICM = "2999";
            cliente.Endereco = "222";
            cliente.Complemento = "333";
            cliente.Bairro = "999";
            cliente.Cidade = "767";
            cliente.Estado = "SS";
            cliente.CEP = "87587";
            cliente.Pais = "yy";
            cliente.Telefone = "fd";
            cliente.Fax = "gdt";
            cliente.Email = "teste@cliente.com";
            cliente.TipoPessoa = "X";
            cliente.Site = "7798";
            cliente.Observacao= "7689698";            
            cliente.Status = "Nana";

            cliente.lstContatos = new List<ClienteContato>();
            cliente.lstContatos.Add(new ClienteContato()
            {
                Nome = "Contato",
                Telefone = "9999",
                Email = "rtrtrtrtrt",
                UnitTest = 1
            });

            cliente.lstContasBancarias = new List<ClienteContaBancaria>();
            cliente.lstContasBancarias.Add(new ClienteContaBancaria()
            {
                Banco = "banco teste",
                Agencia = "8989",
                TipoConta = "jjhj",
                Conta = "888",
                UnitTest = 1
            });

            cliente.UnitTest = 1;

            return cliente;
        }
    }
}

