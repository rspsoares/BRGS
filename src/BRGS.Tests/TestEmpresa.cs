using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BRGS.BIZ;
using BRGS.Entity;
using System.Collections.Generic;

namespace BRGS.Tests
{
    [TestClass]
    public class TestEmpresa
    {
        private BIZEmpresa bizEmpresa = new BIZEmpresa();

        [TestMethod]
        public void EmpresaPesquisar()
        {
            List<Empresa> lstEmpresas = new List<Empresa>();

            lstEmpresas = bizEmpresa.PesquisarEmpresa(new Empresa());

            Assert.AreEqual(true, lstEmpresas.Count > 0);
        }

        [TestMethod]
        public void EmpresaIncluir_SemCamposObrigatorios()
        {
            int idEmpresa = 0;
            string Msg = string.Empty;

            Msg = bizEmpresa.IncluirEmpresa(new Empresa(), out idEmpresa);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void EmpresaIncluir()
        {
            Empresa empresa = new Empresa();
            int idEmpresa = 0;
            string Msg = string.Empty;

            empresa = PreencherCamposObrigatorios();

            Msg = bizEmpresa.IncluirEmpresa(empresa, out idEmpresa);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void EmpresaAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizEmpresa.AlterarEmpresa(new Empresa());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void EmpresaAlterar()
        {
            Empresa empresa = new Empresa();
            string Msg = string.Empty;

            empresa = bizEmpresa.PesquisarEmpresa(new Empresa() { UnitTest = 1 })[0];
            empresa.lstContasBancarias = bizEmpresa.PesquisarEmpresaContaBancaria(new EmpresaContaBancaria() { idEmpresa = empresa.idEmpresa });
            empresa.razaoSocial = "TESTE ALTERADO";

            Msg = bizEmpresa.AlterarEmpresa(empresa);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void EmpresaExcluir()
        {
            List<Empresa> lstEmpresas = new List<Empresa>();            

            bizEmpresa.ExcluirEmpresaTeste();

            lstEmpresas = bizEmpresa.PesquisarEmpresa(new Empresa() { UnitTest = 1 });

            Assert.AreEqual(true, lstEmpresas.Count == 0);
        }

        private Empresa PreencherCamposObrigatorios()
        {
            Empresa empresa = new Empresa();

            empresa.razaoSocial = "RAZÃO";
            empresa.nomeFantasia = "Nome Fantasia";
            empresa.Atividade = "Atividade";
            empresa.Endereco = "Endereço";
            empresa.Cidade = "Cidade";
            empresa.Estado = "XX";
            empresa.CNPJ = "59.587.264/0001-36";
            empresa.ICM = "skfhkjs";
            empresa.inscricaoEstadual = "IE HSGDH";

            empresa.lstContasBancarias = new List<EmpresaContaBancaria>();
            empresa.lstContasBancarias.Add(new EmpresaContaBancaria()
            {
                Banco = "BANCO",
                Agencia = "AGÊNCIA",
                TipoConta = "TIPO CONTA",
                Conta = "CONTA",
                UnitTest = 1
            });

            empresa.UnitTest = 1;

            return empresa;
        }
    }
}
