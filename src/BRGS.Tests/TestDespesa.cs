using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestDespesa
    {
        private BIZDespesa bizDespesa = new BIZDespesa();

        [TestMethod]
        public void DespesaPesquisar()
        {
            List<Despesa> lstDespesas = new List<Despesa>();

            lstDespesas = bizDespesa.PesquisarDespesa(new Despesa());

            Assert.AreEqual(true, lstDespesas.Count > 0);
        }

        [TestMethod]
        public void DespesaPesquisarObra()
        {
            int idDespesa = 0;
            string Msg = string.Empty;
            BIZObra bizObra = new BIZObra();
            List<ObraEtapa> lstObras = new List<ObraEtapa>();
            List<ObraEtapa> lstObrasDespesa = new List<ObraEtapa>();

            lstObras = bizObra.PesquisarObraEtapa(new ObraEtapa() { UnitTest = 1 });

            idDespesa = lstObras[0].lstGastosRealizados[0].idDespesa;

            lstObrasDespesa = bizObra.PesquisarObraEtapaDespesa(idDespesa);

            Assert.AreEqual(true, lstObrasDespesa.Count > 0);
        }

        [TestMethod]
        public void DespesaIncluir_SemCamposObrigatorios()
        {
            int idDespesa = 0;
            string Msg = string.Empty;

            Msg = bizDespesa.IncluirDespesa(1, new Despesa(), out idDespesa);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void DespesaIncluir()
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Despesa despesa = new Despesa();
            int idDespesa = 0;
            string Msg = string.Empty;

            despesa = PreencherCamposObrigatorios();

            Msg = bizDespesa.IncluirDespesa(1, despesa, out idDespesa);

            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@idDespesa", idDespesa.ToString());
            lstParametros.Add("@UnitTest", "1");

            new DataAccess().Executar("SP_USUARIOSDESPESA_INCLUIR", lstParametros);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void DespesaAlterar_SemCamposObrigatorio()
        {            
            string Msg = string.Empty;

            Msg = bizDespesa.AlterarDespesa(new Despesa());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void DespesaAlterar()
        {
            Despesa despesa = new Despesa();            
            string Msg = string.Empty;
            
            despesa = bizDespesa.PesquisarDespesa(new Despesa() { UnitTest = 1 })[0];
            despesa.Descricao = "Teste ALTERADO";

            Msg = bizDespesa.AlterarDespesa(despesa);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void DespesaExcluir()
        {
            List<Despesa> lstDespesas = new List<Despesa>();
            string Msg = string.Empty;

            Msg = bizDespesa.ExcluirDespesa(new Despesa() { UnitTest = 1 });

            lstDespesas = bizDespesa.PesquisarDespesa(new Despesa() { UnitTest = 1 });

            Assert.AreEqual(true, lstDespesas.Count == 0);
        }

        private Despesa PreencherCamposObrigatorios()
        {
            Despesa despesa = new Despesa();
            
            despesa.idDespesa = 0;
            despesa.Descricao = "Teste";
            despesa.gastoFixo = 99;
            despesa.UnitTest = 1;

            return despesa;
        }
    }
}
