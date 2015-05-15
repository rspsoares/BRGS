using System;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BRGS.BIZ;

namespace BRGS.Tests
{
    
    [TestClass]
    public class TestParametrizacao
    {
        private BIZParametrizacao bizParametrizacao = new BIZParametrizacao();

        [TestMethod]
        public void ParametrizacaoPesquisar()
        {            
            bizParametrizacao.ObterParametrizacao();
            UsuarioLogado.idUsuario = 1;
        }

        [TestMethod]
        public void ParametrizacaoAtualizar()
        {
            string strConn = string.Empty;

            strConn = "Server=localhost;Network Library=DBMSSOCN;Initial Catalog=BRGS;User Id=sa;Password=brgs2013;";            
            Parametrizacao.servidor_Conexao = strConn;
            Parametrizacao.servidor_Endereco = strConn.Substring(7, strConn.IndexOf(";", 0) - 7);

            Parametrizacao.diasVencimentoOPAlerta = 10;
            Parametrizacao.diasVencimentoOPCritico = 5;
            Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta = 10;
            Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico = 5;

            bizParametrizacao.AtualizarParametrizacao();
        }
    }
}
