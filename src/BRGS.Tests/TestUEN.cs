using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestUEN
    {
        private BIZUEN bizUEN = new BIZUEN();
        
        [TestMethod]
        public void UENPesquisar()
        {
            List<UEN> lstUEN = new List<UEN>();

            lstUEN = bizUEN.PesquisarUEN(new UEN() { UnitTest = 1 });

            Assert.AreEqual(true, lstUEN.Count > 0);
        }

        [TestMethod]
        public void UENIncluir_SemCamposObrigatorios()
        {
            int idUEN = 0;
            string Msg = string.Empty;

            Msg = bizUEN.IncluirUEN(1, new UEN(), out idUEN);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UENIncluir()
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            UEN uen = new UEN();
            int idUEN = 0;
            string Msg = string.Empty;
            
            uen = this.PreencherCamposObrigatorios();

            Msg = bizUEN.IncluirUEN(1, uen, out idUEN);
                        
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@idUEN", idUEN.ToString());
            lstParametros.Add("@UnitTest", "1");

            new DataAccess().Executar("SP_USUARIOSUEN_INCLUIR", lstParametros);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UENAlterar_SemCamposObrigatorios()
        {            
            string Msg = string.Empty;

            Msg = bizUEN.AlterarUEN(new UEN());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UENAlterar()
        {            
            string Msg = string.Empty;
            UEN uen = new UEN();

            uen = this.PreencherCamposObrigatorios();
            uen.Descricao = "Alterado";

            Msg = bizUEN.AlterarUEN(uen);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UENExcluir()
        {
            UEN uen = new UEN();
            List<UEN> lstUEN = new List<UEN>();
            string Msg = string.Empty;

            uen.idUEN = 0;
            uen.UnitTest = 1;

            Msg = bizUEN.ExcluirUEN(uen);

            lstUEN = bizUEN.PesquisarUEN(new UEN() { UnitTest = 1 });

            Assert.AreEqual(true, lstUEN.Count == 0);
        }

        private UEN PreencherCamposObrigatorios()
        {
            UEN uen = new UEN();
             
            uen.Descricao = "Teste UEN";
            uen.Administrativo = 9;
            uen.lstCentrosCustos = new List<UENCentroCusto>();
            uen.lstCentrosCustos.Add(new UENCentroCusto()
            {
                idUEN = 99,
                idCentroCusto = 99,               
                UnitTest = 1
            });
            uen.UnitTest = 1;

            return uen;
        }
    }
}