using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BRGS.Entity;
using BRGS.BIZ;
using System.Collections.Generic;

namespace BRGS.Tests
{
    [TestClass]
    public class TestFuncionario
    {
        private BIZFuncionario bizFuncionario = new BIZFuncionario();

        [TestMethod]
        public void FuncionarioPesquisar()
        {
            List<Funcionario> lstFuncionarios = new List<Funcionario>();

            lstFuncionarios = bizFuncionario.PesquisarFuncionarios(new Funcionario());

            Assert.AreEqual(true, lstFuncionarios.Count > 0);
        }
    }
}
