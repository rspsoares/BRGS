using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestCategoria
    {
        private BIZCategoria bizCategoria = new BIZCategoria();

        [TestMethod]
        public void CategoriaPesquisar()
        {
            List<Categoria> lstCategorias = new List<Categoria>();

            lstCategorias = bizCategoria.PesquisarCategoria(new Categoria());

            Assert.AreEqual(true, lstCategorias.Count > 0);
        }

        [TestMethod]
        public void CategoriaIncluir_SemCamposObrigatorios()
        {
            int idCategoria = 0;
            string Msg = string.Empty;

            Msg = bizCategoria.IncluirCategoria(new Categoria(), out idCategoria);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CategoriaIncluir()
        {
            Categoria categoria = new Categoria();
            int idCategoria = 0;
            string Msg = string.Empty;

            categoria = PreencherCamposObrigatorios();

            Msg = bizCategoria.IncluirCategoria(categoria, out idCategoria);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CategoriaAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizCategoria.AlterarCategoria(new Categoria(), new Categoria());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CategoriaAlterar()
        {
            Categoria categoria = new Categoria();
            string Msg = string.Empty;

            categoria = bizCategoria.PesquisarCategoria(new Categoria() { UnitTest = 1 })[0];
            categoria.Descricao = "Teste ALTERADO";

            Msg = bizCategoria.AlterarCategoria(categoria,categoria);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void CategoriaExcluir()
        {
            List<Categoria> lstCategorias = new List<Categoria>();
            string Msg = string.Empty;

            Msg = bizCategoria.ExcluirCategoria(new Categoria() { UnitTest = 1 });

            lstCategorias = bizCategoria.PesquisarCategoria(new Categoria() { UnitTest = 1 });

            Assert.AreEqual(true, lstCategorias.Count == 0);
        }

        private Categoria PreencherCamposObrigatorios()
        {
            Categoria categoria = new Categoria();

            categoria.idCategoria = 0;
            categoria.Descricao = "Teste";
            categoria.UnitTest = 1;

            return categoria;
        }
    }
}
