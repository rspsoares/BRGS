using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestFeriado
    {
        private BIZFeriado bizFeriado = new BIZFeriado();

        [TestMethod]
        public void FeriadoPesquisar()
        {
            List<Feriado> lstFases = new List<Feriado>();

            lstFases = bizFeriado.PesquisarFeriados(new Feriado());

            Assert.AreEqual(true, lstFases.Count > 0);
        }

        [TestMethod]
        public void FeriadoIncluir_SemCamposObrigatorios()
        {
            int idFeriado = 0;
            string Msg = string.Empty;

            Msg = bizFeriado.IncluirFeriado(new Feriado(), out idFeriado);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FeriadoIncluir()
        {
            Feriado feriado = new Feriado();
            int idFeriado = 0;
            string Msg = string.Empty;

            feriado = PreencherCamposObrigatorios();

            Msg = bizFeriado.IncluirFeriado(feriado, out idFeriado);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FeriadoAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizFeriado.AlterarFeriado(new Feriado(),new Feriado());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FeriadoAlterar()
        {
            Feriado feriado = new Feriado();
            string Msg = string.Empty;

            feriado = bizFeriado.PesquisarFeriados(new Feriado() { UnitTest = 1 })[0];
            feriado.Descricao = "Teste ALTERADO";

            Msg = bizFeriado.AlterarFeriado(feriado, feriado);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void FeriadoExcluir()
        {
            List<Feriado> lstFeriados = new List<Feriado>();
            string Msg = string.Empty;

            Msg = bizFeriado.ExcluirFeriado(new Feriado() { UnitTest = 1 });

            lstFeriados = bizFeriado.PesquisarFeriados(new Feriado() { UnitTest = 1 });

            Assert.AreEqual(true, lstFeriados.Count == 0);
        }

        private Feriado PreencherCamposObrigatorios()
        {
            Feriado feriado = new Feriado();

            feriado.idFeriado = 0;
            feriado.Dia = 99;
            feriado.Mes = 99;
            feriado.Descricao = "Teste";
            feriado.UnitTest = 1;

            return feriado;
        }
    }
}
