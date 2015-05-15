using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestFase
    {
        private BIZFase bizFase = new BIZFase();

        [TestMethod]
        public void FasePesquisar()
        {
            List<Fase> lstFases = new List<Fase>();

            lstFases = bizFase.PesquisarFases(new Fase());

            Assert.AreEqual(true, lstFases.Count > 0);
        }

        [TestMethod]
        public void FaseIncluir_SemCamposObrigatorios()
        {
            int idFase = 0;
            string Msg = string.Empty;

            Msg = bizFase.IncluirFase(new Fase(), out idFase);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FaseIncluir()
        {
            Fase fase = new Fase();
            int idFase = 0;
            string Msg = string.Empty;

            fase = PreencherCamposObrigatorios();

            Msg = bizFase.IncluirFase(fase, out idFase);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FaseAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizFase.AlterarFase(new Fase());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FaseAlterar()
        {
            Fase fase = new Fase();
            string Msg = string.Empty;

            fase = bizFase.PesquisarFases(new Fase() { UnitTest = 1 })[0];
            fase.Descricao = "Teste ALTERADO";

            Msg = bizFase.AlterarFase(fase);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FaseExcluir()
        {
            List<Fase> lstFases = new List<Fase>();
            string Msg = string.Empty;

            Msg = bizFase.ExcluirFase(new Fase() { UnitTest = 1 });

            lstFases = bizFase.PesquisarFases(new Fase() { UnitTest = 1 });

            Assert.AreEqual(true, lstFases.Count == 0);
        }

        private Fase PreencherCamposObrigatorios()
        {
            Fase fase = new Fase();

            fase.idFase = 0;
            fase.Descricao = "Teste";
            fase.UnitTest = 1;

            return fase;
        }
    }
}
