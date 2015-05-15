using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestCusto
    {
        private BIZCusto bizCusto = new BIZCusto();

        [TestMethod]
        public void CustoPesquisar()
        {
            List<Custo> lstCusto = new List<Custo>();

            lstCusto = bizCusto.PesquisarCusto(new Custo());

            Assert.AreEqual(true, lstCusto.Count > 0);
        }
    }
}
