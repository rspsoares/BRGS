using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestMotorista
    {
        private BIZMotorista bizMotorista = new BIZMotorista();

        [TestMethod]
        public void MotoristaPesquisar()
        {
            List<Motorista> lstMotorista = new List<Motorista>();

            lstMotorista = bizMotorista.PesquisarMotorista(new Motorista());

            Assert.AreEqual(true, lstMotorista.Count > 0);
        }

        [TestMethod]
        public void MotoristaIncluir_SemCamposObrigatorios()
        {
            int idMotorista = 0;
            string Msg = string.Empty;

            Msg = bizMotorista.IncluirMotorista(new Motorista(), out idMotorista);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MotoristaIncluir()
        {
            Motorista motorista = new Motorista();
            int idMotorista = 0;
            string Msg = string.Empty;

            motorista = PreencherCamposObrigatorios();

            Msg = bizMotorista.IncluirMotorista(motorista, out idMotorista);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MotoristaAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizMotorista.AlterarMotorista(new Motorista());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MotoristaAlterar()
        {
            Motorista motorista = new Motorista();
            string Msg = string.Empty;

            motorista = bizMotorista.PesquisarMotorista(new Motorista() { UnitTest = 1 })[0];
            motorista.Nome = "Teste ALTERADO";

            Msg = bizMotorista.AlterarMotorista(motorista);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MotoristaExcluir()
        {
            List<Motorista> lstMotorista = new List<Motorista>();            

            bizMotorista.ExcluirMotoristaTeste();

            lstMotorista = bizMotorista.PesquisarMotorista(new Motorista() { UnitTest = 1 });

            Assert.AreEqual(true, lstMotorista.Count == 0);
        }

        private Motorista PreencherCamposObrigatorios()
        {
            Motorista motorista = new Motorista();

            motorista.idMotorista= 0;
            motorista.Nome = "Teste";
            motorista.RG = "1234";
            motorista.CPF = "306.215.131-56";
            motorista.Telefone = "89789789";
            motorista.UnitTest = 1;

            return motorista;
        }
    }
}
