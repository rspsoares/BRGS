using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using BRGS.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestUsuario
    {
        Helper helper = new Helper();
        private BIZUsuario bizUsuario = new BIZUsuario();

        #region Usuários

        [TestMethod]
        public void UsuarioIncluir_SemCamposObrigatorios()
        {
            int novoID = 0;
            string Msg = bizUsuario.IncluirUsuario(new Usuario(), out novoID);
            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsuarioIncluir()
        {
            Usuario usuario = new Usuario();
            int novoID = 0;

            usuario = PreencherCamposObrigatorios();
            string Msg = bizUsuario.IncluirUsuario(usuario, out novoID);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsuarioPesquisar()
        {
            Usuario usuario = new Usuario();
            usuario.UnitTest = 1;
            usuario.Nome = "Nome ALTERADO";

            List<Usuario> lstUsuarios = bizUsuario.PesquisarUsuario(usuario);
            Assert.AreEqual(true, lstUsuarios.Count > 0);
        }

        [TestMethod]
        public void UsuarioAlterar_SemCamposObrigatorios()
        {
            string Msg = bizUsuario.AlterarUsuario(new Usuario());
            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsuarioAlterar()
        {
            Usuario usuario = new Usuario();           

            usuario = PreencherCamposObrigatorios();
            usuario.idUsuario = bizUsuario.PesquisarUsuario(new Usuario() { UnitTest = 1 })[0].idUsuario;
            usuario.UnitTest = 1;
            usuario.Nome = "Nome ALTERADO";

            string Msg = bizUsuario.AlterarUsuario(usuario);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsuarioAtualizarUltimoAcesso()
        {
            Usuario usuario = new Usuario();          

            usuario = PreencherCamposObrigatorios();
            usuario.idUsuario = bizUsuario.PesquisarUsuario(new Usuario() { UnitTest = 1 })[0].idUsuario;
            usuario.ultimoAcesso = DateTime.Now;

            bizUsuario.AtualizarUltimoAcesso(usuario, 1);

            usuario = bizUsuario.PesquisarUsuario(new Usuario() { idUsuario = usuario.idUsuario })[0];

            Assert.AreNotEqual(DateTime.MinValue, usuario.ultimoAcesso);
        }

        [TestMethod]
        public void UsuarioAlterarSenha()
        {
            Usuario usuario = new Usuario();            

            usuario.idUsuario = bizUsuario.PesquisarUsuario(new Usuario() { UnitTest = 1 })[0].idUsuario;
            usuario.Senha = helper.CriptografarSenha("zzzzzzz");

            string Msg = bizUsuario.AlterarUsuarioSenha(usuario, 1);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsuarioExcluir()
        {
            Usuario usuario = new Usuario();            

            usuario.idUsuario = 0;
            usuario.UnitTest = 1;

            string Msg = bizUsuario.ExcluirUsuarioTeste();
            Assert.AreEqual(string.Empty, Msg);
        }

        private Usuario PreencherCamposObrigatorios()
        {
            Usuario usuario = new Usuario();
            usuario.Nome = "Usuário TESTE";
            usuario.Login = "usuario";
            usuario.Senha = helper.CriptografarSenha("abcde");
            usuario.ultimoAcesso = DateTime.MinValue;
            usuario.Bloqueado = 9;
            usuario.Ativo = "S";
            usuario.UnitTest = 1;
            
            usuario.lstPermissoes = new List<UsuarioPermissoes>();
            usuario.lstPermissoes.Add(new UsuarioPermissoes()
            {
                idUsuario = 99,
                idControle = 1,
                Habilitado = true,
                UnitTest = 1
            });

            usuario.lstUEN = new List<UsuarioUEN>();
            usuario.lstUEN.Add(new UsuarioUEN()
            {
                idUEN = new BIZUEN().PesquisarUEN(new UEN())[0].idUEN,                
                UnitTest = 1
            });

            usuario.lstCC = new List<UsuarioCentroCusto>();
            usuario.lstCC.Add(new UsuarioCentroCusto()
            {
                idCentroCusto = new BIZCentroCusto().PesquisarCentroCusto(new CentroCusto())[0].idCentroCusto,
                UnitTest = 1
            });

            usuario.lstDespesas = new List<UsuarioDespesa>();
            usuario.lstDespesas.Add(new UsuarioDespesa()
            {
                idDespesa = new BIZDespesa().PesquisarDespesa(new Despesa())[0].idDespesa,
                UnitTest = 1
            });

            return usuario;
        }

        #endregion

        #region Permissão de Acesso

        [TestMethod]
        public void UsuarioPesquisarPermissoes()
        {
            List<UsuarioPermissoes> lstPermissoes = new List<UsuarioPermissoes>();
            Usuario usuario = new Usuario();

            usuario = bizUsuario.PesquisarUsuario(new Usuario() { UnitTest = 1 })[0];

            lstPermissoes = bizUsuario.PesquisarPermissoesUsuario(new UsuarioPermissoes() { idUsuario = usuario.idUsuario });

            Assert.AreEqual(true, lstPermissoes.Count > 0);
        }

        #endregion
    }
}