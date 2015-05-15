using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestCentroCusto
    {
        private BIZCentroCusto bizCentroCusto = new BIZCentroCusto();

        [TestMethod]
        public void CentroCustoPesquisar()
        {
            List<CentroCusto> lstCentrosCustos = new List<CentroCusto>();

            lstCentrosCustos = bizCentroCusto.PesquisarCentroCusto(new CentroCusto() { UnitTest = 1 });

            Assert.AreEqual(true, lstCentrosCustos.Count > 0);
        }

        [TestMethod]
        public void CentroCustoIncluir_SemCamposObrigatorios()
        {
            int idCentroCusto = 0;
            string Msg = string.Empty;

            Msg = bizCentroCusto.IncluirCentroCusto(1, new CentroCusto(), out idCentroCusto);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CentroCustoIncluir()
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            int idCentroCusto = 0;
            string Msg = string.Empty;
            CentroCusto centroCusto = new CentroCusto();

            centroCusto = this.PreencherCamposObrigatorios();

            Msg = bizCentroCusto.IncluirCentroCusto(1, centroCusto, out idCentroCusto);

            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@idCentroCusto", idCentroCusto.ToString());
            lstParametros.Add("@UnitTest", "1");

            new DataAccess().Executar("SP_USUARIOSCENTROCUSTO_INCLUIR", lstParametros);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CentroCustoAlterar_SemCamposObrigatorios()
        {            
            string Msg = string.Empty;

            Msg = bizCentroCusto.AlterarCentroCustos(new CentroCusto());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CentroCustoAlterar()
        {            
            string Msg = string.Empty;
            CentroCusto centroCusto = new CentroCusto();

            centroCusto = this.PreencherCamposObrigatorios();          
            centroCusto.Descricao = "Alterado";           

            Msg = bizCentroCusto.AlterarCentroCustos(centroCusto);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CentroCustoExcluir()
        {
            CentroCusto centroCusto = new CentroCusto();
            List<CentroCusto> lstCentrosCustos = new List<CentroCusto>();
            string Msg = string.Empty;

            centroCusto.UnitTest = 1;

            Msg = bizCentroCusto.ExcluirCentroCusto(centroCusto);

            lstCentrosCustos = bizCentroCusto.PesquisarCentroCusto(new CentroCusto() { UnitTest = 1 });

            Assert.AreEqual(true, lstCentrosCustos.Count == 0);
        }

        private CentroCusto PreencherCamposObrigatorios()
        {
            CentroCusto centroCusto = new CentroCusto();

            centroCusto.Codigo = "ABCD";
            centroCusto.Descricao = "Teste Centro Custo";
            centroCusto.Administrativo = 9;
            centroCusto.lstDespesas = new List<CentroCustoDespesa>();
            centroCusto.lstDespesas.Add(new CentroCustoDespesa()
            {
                idCentroCusto = 99,
                idDespesa = 99,
                UnitTest = 1
            });

            centroCusto.lstUsuarios = new List<UsuarioCentroCusto>();
            centroCusto.lstUsuarios.Add(new UsuarioCentroCusto()
            {
                idCentroCusto = 99,
                idUsuario = 99,
                UnitTest = 1
            });

            centroCusto.UnitTest = 1;

            return centroCusto;
        }
    }
}
