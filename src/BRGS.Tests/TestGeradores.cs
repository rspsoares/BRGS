using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Data.SqlTypes;

namespace BRGS.Tests
{
    [TestClass]
    public class TestGeradores
    {
        private BIZGerador bizGerador = new BIZGerador();

        public TestGeradores()
        {
            //var strConn = "Server=45.148.165.119,21433;Database=BRGS1;Network Library=DBMSSOCN;Initial Catalog=BRGS1;User Id=OS_User;Password=SenhaForte@BRGSApp;";
            var strConn = "Server=localhost;Database=brgs1;Trusted_Connection=True;TrustServerCertificate=True;";
            Parametrizacao.servidor_Conexao = strConn;
            Parametrizacao.servidor_Endereco = strConn.Substring(7, strConn.IndexOf(";", 0) - 7);
        }

        [TestMethod]
        public void TestCarregarPlanilha()
        {
            //var strConn = "Server=45.148.165.119,21433;Database=BRGS1;Network Library=DBMSSOCN;Initial Catalog=BRGS1;User Id=OS_User;Password=SenhaForte@BRGSApp;";
            var strConn = "Server=localhost;Database=brgs1;Trusted_Connection=True;TrustServerCertificate=True;";
            Parametrizacao.servidor_Conexao = strConn;
            Parametrizacao.servidor_Endereco = strConn.Substring(7, strConn.IndexOf(";", 0) - 7);

            File
                .ReadAllLines(@"C:\_Rodrigo\BRGS\Geradores.csv")
                .Skip(1)
                .ToList()
                .ForEach(line =>
                {
                    try
                    {
                        var lineSplit = line.Split(new char[] { ';' });

                        var gerador = new Gerador
                        {
                            NumeroSerie = lineSplit[0].Trim(),
                            Combustivel = lineSplit[1].Trim(),
                            Modelo = lineSplit[2].Trim(),
                            Marca = lineSplit[3].Trim(),
                            Lotado = lineSplit[4].Trim(),
                            NotaFiscal = lineSplit[7].Trim(),
                            DataCompra = string.IsNullOrEmpty(lineSplit[9].Trim()) ? SqlDateTime.MinValue.Value : DateTime.Parse(lineSplit[9]),
                            Acessorios = $"{lineSplit[10].Trim()} - {lineSplit[11].Trim()}"
                        };

                        bizGerador.IncluirGerador(gerador, out int ID);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                   
                });
        }

        [TestMethod]
        public void TestAlocar()
        {
            var e = new Gerador
            {
                ID = 36,
                IdCliente = 1124,
                IdObraEtapa = 1226,
                DataAlocacao = DateTime.Today
            };

            bizGerador.Alocar(e);
        }

        [TestMethod]
        public void TestLiberar()
        {
            var e = new Gerador
            {
                ID = 36,
                IdCliente = 1124,
                IdObraEtapa = 1226
            };

            bizGerador.Liberar(e);
        }
    }
}
