using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BRGS.Application.Contracts;
using BRGS.Application.Bindings;

namespace BRGS.Tests
{
    [TestClass]
    public class TestAtividade
    {
        private BIZAtividade bizAtividade = new BIZAtividade();        

        [TestMethod]
        public void AtividadePesquisar()
        {          
            List<Atividade> lstAtividades = new List<Atividade>();

            lstAtividades = bizAtividade.PesquisarAtividade(new Atividade());

            Assert.AreEqual(true, lstAtividades.Count > 0);
        }

        [TestMethod]
        public void AtividadeIncluir_SemCamposObrigatorios()
        {
            int idAtividade = 0;
            string Msg = string.Empty;

            Msg = bizAtividade.IncluirAtividade(new Atividade(), out idAtividade);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AtividadeIncluir()
        {
            Atividade atividade = new Atividade();
            int idAtividade = 0;
            string Msg = string.Empty;

            atividade = PreencherCamposObrigatorios();

            Msg = bizAtividade.IncluirAtividade(atividade, out idAtividade);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AtividadeAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizAtividade.AlterarAtividade(new Atividade(), new Atividade());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AtividadeAlterar()
        {
            Atividade atividade = new Atividade();
            string Msg = string.Empty;

            atividade = bizAtividade.PesquisarAtividade(new Atividade() { UnitTest = 1 })[0];
            atividade.Descricao = "Teste ALTERADO";

            Msg = bizAtividade.AlterarAtividade(atividade,atividade);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AtividadeExcluir()
        {
            List<Atividade> lstAtividades = new List<Atividade>();
            string Msg = string.Empty;

            Msg = bizAtividade.ExcluirAtividade(new Atividade() { UnitTest = 1 });

            lstAtividades = bizAtividade.PesquisarAtividade(new Atividade() { UnitTest = 1 });

            Assert.AreEqual(true, lstAtividades.Count == 0);
        }

        private Atividade PreencherCamposObrigatorios()
        {
            Atividade atividade = new Atividade();

            atividade.idAtividade = 0;
            atividade.Descricao = "Teste";
            atividade.UnitTest = 1;

            return atividade;
        }
    }
}
