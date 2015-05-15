using System;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestLogErro
    {
        private BIZLogErro bizLogErro = new BIZLogErro();

        [TestMethod]
        public void LogErroIncluir()
        {   
            string msgRetorno = string.Empty;

            LogErro logErro = new LogErro()
            {
                Data = DateTime.Now,
                Enviado = 0,
                mensagemErro = "Teste Mensagem",
                parametrosSQL = "Teste parâmetros",
                procedureSQL = "Teste procedure"
            };

            msgRetorno = bizLogErro.IncluirLogErro(logErro);

            Assert.AreEqual(string.Empty, msgRetorno);
        }
    }
}
