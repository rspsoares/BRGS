using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestObra
    {
        private BIZObra bizObra = new BIZObra();
        
        [TestMethod]
        public void ObraIncluir_SemCamposObrigatorios()
        {
            string Msg = string.Empty;
            int idObra = 0;

            Msg = bizObra.IncluirObra(new Obra(), out idObra);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraIncluir()
        {
            string Msg = string.Empty;
            int idObra = 0;

            Obra obra = new Obra();

            obra = this.PreencherCamposOrigatoriosObra();
            Msg = bizObra.IncluirObra(obra, out idObra);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraAlterar_SemCamposObrigatorios()
        {
            string Msg = string.Empty;

            Msg = bizObra.AlterarObra(new Obra());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraAlterar()
        {
            string Msg = string.Empty;

            Obra obra = new Obra();

            obra = bizObra.PesquisarObra(new Obra() { UnitTest = 1 })[0];
            obra.nomeEvento = "Evento Alterado";
            obra.UnitTest = 1;

            Msg = bizObra.AlterarObra(obra);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraPesquisar()
        {
            string Msg = string.Empty;
            List<Obra> lstObras = new List<Obra>();

            lstObras = bizObra.PesquisarObra(new Obra() { UnitTest = 1 });

            Assert.AreEqual(true, lstObras.Count > 0);
        }

        [TestMethod]
        public void ObraExcluir()
        {
            string Msg = string.Empty;
            List<Obra> lstObras = new List<Obra>();

            bizObra.ExcluirObraTestes();
            lstObras = bizObra.PesquisarObra(new Obra() { UnitTest = 1 });

            Assert.AreEqual(true, lstObras.Count == 0);
        }

        [TestMethod]
        public void ObraEtapaIncluir_SemCamposObrigatorios()
        {
            string Msg = string.Empty;
            int idObra = 0;

            Msg = bizObra.IncluirObraEtapa(new ObraEtapa(), out idObra);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraEtapaIncluir()
        {
            string Msg = string.Empty;            
            ObraEtapa obra = new ObraEtapa();
            int idObraEtapa = 0;

            obra = this.PreencherCamposOrigatoriosObraEtapa();
            Msg = bizObra.IncluirObraEtapa(obra, out idObraEtapa);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraEtapaAlterar_SemCamposObrigatorios()
        {
            string Msg = string.Empty;         

            Msg = bizObra.AlterarObraEtapa(new ObraEtapa());

            Assert.AreNotEqual(string.Empty, Msg);
        }
        
        [TestMethod]
        public void ObraEtapaAlterar()
        {
            string Msg = string.Empty;         
            ObraEtapa obraEtapa = new ObraEtapa();

            obraEtapa = this.PreencherCamposOrigatoriosObraEtapa();
            obraEtapa.idObraEtapa = bizObra.PesquisarObraEtapa(new ObraEtapa() { UnitTest = 1})[0].idObraEtapa;
            obraEtapa.nomeEvento = "Evento Alterado";
            obraEtapa.UnitTest = 1;

            Msg = bizObra.AlterarObraEtapa(obraEtapa);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ObraEtapaPesquisar()
        {
            string Msg = string.Empty;          
            List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();
           
            lstObrasEtapas = bizObra.PesquisarObraEtapa(new ObraEtapa() { UnitTest = 1});

            Assert.AreEqual(true, lstObrasEtapas.Count > 0);
        }

        [TestMethod]
        public void ObraEtapaPesquisarCombo()
        {
            string Msg = string.Empty;
            List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();

            lstObrasEtapas = bizObra.PesquisarObraEtapaCombo();

            Assert.AreEqual(true, lstObrasEtapas.Count > 0);
        }

        [TestMethod]
        public void ObraEtapaExcluir()
        { 
            string Msg = string.Empty;
            List<ObraEtapa> lstObras = new List<ObraEtapa>();
            
            bizObra.ExcluirObraEtapaTestes();
            lstObras = bizObra.PesquisarObraEtapa(new ObraEtapa() { UnitTest = 1 });

            Assert.AreEqual(true, lstObras.Count == 0);         
        }
        
        //[TestMethod]
        //public void ObraEtapaPlanejamentoPesquisar()
        //{
        //    string Msg = string.Empty;
        //    List<ObraEtapaPlanejamento> lstPlanejamentos = new List<ObraEtapaPlanejamento>();

        //    lstPlanejamentos = bizObra.PesquisarPlanejamento(new ObraEtapaPlanejamento() { UnitTest = 1 });

        //    Assert.AreEqual(true, lstPlanejamentos.Count > 0);
        //}

        //[TestMethod]
        //public void ObraEtapaPlanejamentoExcluir()
        //{
        //    List<ObraEtapaPlanejamento> lstPlanejamentos = new List<ObraEtapaPlanejamento>();
            
        //    bizObra.ExcluirPlanejamentoTeste();

        //    lstPlanejamentos = bizObra.PesquisarPlanejamento(new ObraEtapaPlanejamento() { UnitTest = 1 });

        //    Assert.AreEqual(true, lstPlanejamentos.Count == 0);
        //}

        private Obra PreencherCamposOrigatoriosObra()
        {         
            Obra obra = new Obra();           

            obra.idEmpresa = new BIZEmpresa().PesquisarEmpresa(new Empresa())[0].idEmpresa;
            obra.numeroLicitacao = "999999999";
            obra.idCliente = new BIZCliente().PesquisarCliente(new Cliente())[0].idCliente;
            obra.nomeCliente = "Cliente Teste";
            obra.nomeEvento = "Evento Teste";
            obra.valorBruto = Decimal.Parse("999.99");
            obra.Finalizada = 9;
            obra.UnitTest = 1;

            return obra;
        }

        private ObraEtapa PreencherCamposOrigatoriosObraEtapa()
        {
            UEN UEN = new UEN();                
            CentroCusto centroCusto = new CentroCusto();
            Despesa despesa = new Despesa();
            Fase fase = new Fase();
            ObraEtapa obraEtapa = new ObraEtapa();
            int idUsuarioTeste = 0;

            obraEtapa.idEmpresa = new BIZEmpresa().PesquisarEmpresa(new Empresa())[0].idEmpresa; 
            obraEtapa.numeroLicitacao = "999999999";
            obraEtapa.idCliente = new BIZCliente().PesquisarCliente(new Cliente())[0].idCliente;
            obraEtapa.nomeCliente = "Cliente Teste";
            obraEtapa.Descricao = "Etapa Teste";
            obraEtapa.nomeEvento = "Evento Teste";
            obraEtapa.valorContrato = Decimal.Parse("999.99");
            obraEtapa.dataInicio = DateTime.Now;
            obraEtapa.dataTermino = DateTime.Now;            

            UEN = new BIZUEN().PesquisarUEN(new UEN())[0];
            centroCusto = new BIZCentroCusto().PesquisarCentroCusto(new CentroCusto())[0];
            despesa = new BIZDespesa().PesquisarDespesa(new Despesa())[0];

            fase = new BIZFase().PesquisarFases(new Fase())[0];

            idUsuarioTeste = new BIZUsuario().PesquisarUsuario(new Usuario())[0].idUsuario;

            obraEtapa.lstGastosPrevistos = new List<ObraEtapaGastoPrevisto>();
            obraEtapa.lstGastosPrevistos.Add(new ObraEtapaGastoPrevisto()
            {
                idUEN = UEN.idUEN,
                idCentroCusto = centroCusto.idCentroCusto, 
                idDespesa = despesa.idDespesa,
                Valor = Decimal.Parse("999.99"),
                Observacao = "Teste de lançamento previsto", 
                UnitTest = 1
            });

            obraEtapa.lstGastosRealizados = new List<ObraEtapaGastoRealizado>();
            obraEtapa.lstGastosRealizados.Add(new ObraEtapaGastoRealizado()
            {
                idUEN = UEN.idUEN,
                idCentroCusto = centroCusto.idCentroCusto,
                idDespesa = despesa.idDespesa,
                Data = DateTime.Now,
                Valor = Decimal.Parse("999.99"),
                Observacao = "Teste de lançamento realizado", 
                UnitTest = 1
            });

            obraEtapa.lstFases = new List<ObraEtapaFase>();
            obraEtapa.lstFases.Add(new ObraEtapaFase()
            {
                idFase = fase.idFase,
                dataInicio = DateTime.Today,
                dataPrevTermino = DateTime.Today,
                dataTermino = DateTime.Today,
                UnitTest = 1
            });

            obraEtapa.lstFollowUps = new List<ObraEtapaFollowUp>();
            obraEtapa.lstFollowUps.Add(new ObraEtapaFollowUp()
            {
                idUsuario = idUsuarioTeste,
                Descricao = "TesteFU",
                Data = DateTime.Today,
                UnitTest = 1
            });

            //obraEtapa.lstPlanejamentos = new List<ObraEtapaPlanejamento>();
            //obraEtapa.lstPlanejamentos.Add(new ObraEtapaPlanejamento()
            //{
            //    idObraEtapa = obraEtapa.idObraEtapa,
            //    idUEN = UEN.idUEN,
            //    valorPrevisto = 99,                
            //    UnitTest = 1
            //});

            //obraEtapa.lstPlanejamentos.Add(new ObraEtapaPlanejamento()
            //{
            //    idObraEtapa = obraEtapa.idObraEtapa,
            //    idUEN = UEN.idUEN,
            //    valorPrevisto = 88,
            //    UnitTest = 1
            //});

            obraEtapa.UnitTest = 1;
            
            return obraEtapa;
        }
    }
}
