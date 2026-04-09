using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace BRGS.Tests
{
    [TestClass]
    public class TestEmpilhadeira
    {
        private BIZEmpilhadeira bizEmpilhadeira = new BIZEmpilhadeira();
        private BIZEmpresa bizEmpresa = new BIZEmpresa();

        public TestEmpilhadeira()
        {             
            var strConn = "Server=45.148.165.119,21433;Database=BRGS1;Network Library=DBMSSOCN;Initial Catalog=BRGS1;User Id=OS_User;Password=SenhaForte@BRGSApp;";
            Parametrizacao.servidor_Conexao = strConn;
            Parametrizacao.servidor_Endereco = strConn.Substring(7, strConn.IndexOf(";", 0) - 7);
        }

        [TestMethod]
        public void TestCarregarPlanilha()
        {  
            File
                .ReadAllLines(@"C:\_Rodrigo\BRGS\Empilhadeiras.csv")
                .Skip(1)
                .ToList()
                .ForEach(line => 
                {
                    var lineSplit = line.Split(new char[] { ';' });

                    //var numeroSerie = lineSplit[0].Trim();
                    //var fantasia = lineSplit[10].Trim();

                    //var empresa = bizEmpresa.PesquisarEmpresa(new Empresa() {nomeFantasia = fantasia }).FirstOrDefault();
                    //if(empresa == null)
                    //{
                    //    var x = "borocoxô!";

                    //}
                    //else
                    //{                       
                    //    var empilhadeira = bizEmpilhadeira.PesquisarEmpilhadeiras(new Empilhadeira() { NumeroSerie = numeroSerie }).FirstOrDefault();
                    //    if(empilhadeira != null)
                    //    {
                    //        empilhadeira.IdEmpresa = empresa.idEmpresa;
                    //        bizEmpilhadeira.AlterarEmpilhadeira(empilhadeira);
                    //    }

                    //}

                    var empilhadeira = new Empilhadeira
                    {
                        NumeroSerie = lineSplit[0].Trim(),
                        Combustivel = lineSplit[1].Trim(),
                        Modelo = lineSplit[2].Trim(),
                        Marca = lineSplit[3].Trim(),
                        Torre = decimal.Parse(lineSplit[4]),
                        CapacidadeCarga = int.Parse(lineSplit[5]),
                        Lotada = lineSplit[6].Trim(),
                        NotaFiscal = lineSplit[9].Trim(),
                        DataCompra = DateTime.Parse(lineSplit[11]),
                        Acessorios = $"{lineSplit[12].Trim()} - {lineSplit[13].Trim()} - {lineSplit[14].Trim()} - {lineSplit[15].Trim()}"
                    };

                    bizEmpilhadeira.IncluirEmpilhadeira(empilhadeira, out int ID);
                });
        }

        [TestMethod]
        public void TestInsert()
        {
            var e = new Empilhadeira
            {
                
                NumeroSerie = "SERIE",
                Marca = "Marca",
                Modelo = "MODELO",
                Combustivel = "Combustivel",
                Torre = 123.5M,
                CapacidadeCarga = 321,
                IdCliente = 0,
                IdObraEtapa = 0,
                Lotada = "Lotada",
                IdEmpresa = 1,
                NotaFiscal = "NotaFiscal",
                DataCompra = DateTime.Today,
                Acessorios = "Acessorios"
            };

            e.lstManutencoes.Add(new EmpilhadeiraManutencao()
            {
                Data = DateTime.Today,
                Valor = 123,
                Descricao = "sssss"
            });

            e.lstManutencoes.Add(new EmpilhadeiraManutencao()
            {
                Data = DateTime.Today.AddDays(9),
                Valor = 321,
                Descricao = "ttt"
            });

            bizEmpilhadeira.IncluirEmpilhadeira(e, out int ID);

            Assert.IsTrue(ID > 0);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var e = new Empilhadeira
            {
                ID = 41,
                NumeroSerie = "**SERIE",
                Marca = "**Marca",
                Modelo = "**MODELO",
                Combustivel = "**Combustivel",
                Torre = 99.5M,
                CapacidadeCarga = 999,
                IdCliente = 0,
                IdObraEtapa = 0,
                Lotada = "**Lotada",
                IdEmpresa = 0,
                NotaFiscal = "**NotaFiscal",
                DataCompra = DateTime.Today.AddDays(15),
                Acessorios = "**Acessorios"
            };

            string msgRetorno = bizEmpilhadeira.AlterarEmpilhadeira(e);

            Assert.IsTrue(string.IsNullOrEmpty(msgRetorno));
        }
    }
}
