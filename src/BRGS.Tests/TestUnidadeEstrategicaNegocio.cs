using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestUnidadeEstrategicaNegocio
    {
        private BIZUnidadeEstrategicaNegocio bizUEN = new BIZUnidadeEstrategicaNegocio();

        [TestMethod]
        public void UnidadeEstrategicaNegocioPesquisar()
        {
            List<UnidadeEstrategicaNegocio> lstUEN = new List<UnidadeEstrategicaNegocio>();

            lstUEN = bizUEN.PesquisarUnidadeEstrategicaNegocio(new UnidadeEstrategicaNegocio());

            Assert.AreEqual(true, lstUEN.Count > 0);
        }
    }
}
