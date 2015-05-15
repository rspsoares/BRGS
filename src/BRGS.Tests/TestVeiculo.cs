using System;
using System.Collections.Generic;
using BRGS.BIZ;
using BRGS.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BRGS.Tests
{
    [TestClass]
    public class TestVeiculo
    {
        private BIZVeiculo bizVeiculo = new BIZVeiculo();
        private BIZMotorista bizMotorista = new BIZMotorista();

        #region Veículos
        
        [TestMethod]
        public void VeiculoPesquisar()
        {
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            lstVeiculos = bizVeiculo.PesquisarVeiculos(new Veiculo());

            Assert.AreEqual(true, lstVeiculos.Count > 0);
        }

        [TestMethod]
        public void VeiculoIncluir_SemCamposObrigatorios()
        {
            int idVeiculo = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirVeiculo(new Veiculo(), out idVeiculo);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void VeiculoIncluir()
        {
            Veiculo veiculo = new Veiculo();
            int idVeiculo = 0;
            string Msg = string.Empty;

            veiculo = PreencherCamposObrigatoriosVeiculos();

            Msg = bizVeiculo.IncluirVeiculo(veiculo, out idVeiculo);

            Assert.AreEqual(string.Empty, Msg);
        }
        
        [TestMethod]
        public void VeiculoAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarVeiculo(new Veiculo());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void VeiculoAlterar()
        {
            Veiculo veiculo = new Veiculo();
            string Msg = string.Empty;

            veiculo = bizVeiculo.PesquisarVeiculos(new Veiculo() { UnitTest = 1 })[0];
            veiculo.Descricao = "Teste ALTERADO";

            Msg = bizVeiculo.AlterarVeiculo(veiculo);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void VeiculoExcluir()
        {
            List<Veiculo> lstVeiculos = new List<Veiculo>();
            string Msg = string.Empty;

            bizVeiculo.ExcluirVeiculoTeste();

            lstVeiculos = bizVeiculo.PesquisarVeiculos(new Veiculo() { UnitTest = 1 });

            Assert.AreEqual(true, lstVeiculos.Count == 0);
        }

        private Veiculo PreencherCamposObrigatoriosVeiculos()
        {
            Veiculo veiculo = new Veiculo();

            veiculo.idVeiculo = 0;
            veiculo.Descricao = "Fusca";
            veiculo.Placa = "0909";
            veiculo.Ano = 2020;
            veiculo.Modelo = 2021;
            veiculo.Chassi = "chassi";
            veiculo.Cor = "AZUL";
            veiculo.Rastreador = "Rastr";
            veiculo.semParar = 9;
            veiculo.Seguradora ="Segu";
            veiculo.dataVencimentoSeguro = DateTime.Today;
            veiculo.Renavam = "Renav";
            veiculo.dataVencimentoIPVA = DateTime.Today;
            veiculo.dataVencimentoDPVAT = DateTime.Today; 
            veiculo.lstAbastecimentos = new List<Abastecimento>();            
            veiculo.UnitTest = 1;

            return veiculo;
        }

        #endregion
        
        #region Abastecimentos

        [TestMethod]
        public void AbastecimentoPesquisar()
        {
            List<Abastecimento> lstAbastecimentos = new List<Abastecimento>();

            lstAbastecimentos = bizVeiculo.PesquisarAbastecimentos(new Abastecimento() { UnitTest = 1});

            Assert.AreEqual(true, lstAbastecimentos.Count > 0);
        }

        [TestMethod]
        public void AbastecimentoIncluir_SemCamposObrigatorios()
        {
            int idAbastecimento = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirAbastecimentos(new Abastecimento(), out idAbastecimento);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AbastecimentoIncluir()
        {
            Abastecimento abastecimento = new Abastecimento();            
            string Msg = string.Empty;
            int idAbastecimento = 0;

            abastecimento = PreencherCamposObrigatoriosAbastecimento();

            Msg = bizVeiculo.IncluirAbastecimentos(abastecimento, out idAbastecimento);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AbastecimentoAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarAbastecimento(new Abastecimento());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AbastecimentoAlterar()
        {
            Abastecimento abastecimento = new Abastecimento();            
            string Msg = string.Empty;

            abastecimento = bizVeiculo.PesquisarAbastecimentos(new Abastecimento() { UnitTest = 1 })[0];
            abastecimento.Valor = decimal.Parse("1234");
            Msg = bizVeiculo.AlterarAbastecimento(abastecimento);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void AbastecimentoExcluir()
        {
            List<Abastecimento> lstAbastecimentos = new List<Abastecimento>();
            string Msg = string.Empty;

            bizVeiculo.ExcluirAbastecimentoTeste();

            lstAbastecimentos = bizVeiculo.PesquisarAbastecimentos(new Abastecimento() { UnitTest = 1 });

            Assert.AreEqual(true, lstAbastecimentos.Count == 0);
        }

        private Abastecimento PreencherCamposObrigatoriosAbastecimento()
        {
            BIZMotorista bizMotorista = new BIZMotorista();
            BIZFornecedor bizFornecedor = new BIZFornecedor();
            BIZObra bizObra = new BIZObra();
            BIZUEN bizUEN = new BIZUEN();
            BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
            BIZDespesa bizDespesa = new BIZDespesa();
            
            Abastecimento abastecimento = new Abastecimento();

            abastecimento.idAbastecimento = 99;
            abastecimento.numeroAbastecimento = "0/2019";
            abastecimento.idFornecedor = bizFornecedor.PesquisarFornecedor(new Fornecedor())[0].idFornecedor; 
            abastecimento.idVeiculo = bizVeiculo.PesquisarVeiculos(new Veiculo())[0].idVeiculo;;
            abastecimento.idMotorista = bizMotorista.PesquisarMotorista(new Motorista())[0].idMotorista;;            
            abastecimento.idObraEtapa = bizObra.PesquisarObraEtapa(new ObraEtapa())[0].idObraEtapa;
            abastecimento.idObraEtapaGastoRealizado = bizObra.PesquisarGastosRealizados(new ObraEtapaGastoRealizado())[0].idObraEtapaGastoRealizado;
            abastecimento.idUEN = bizUEN.PesquisarUEN(new UEN())[0].idUEN;
            abastecimento.idCentroCusto = bizCentroCusto.PesquisarCentroCusto(new CentroCusto())[0].idCentroCusto;
            abastecimento.idDespesa = bizDespesa.PesquisarDespesa(new Despesa())[0].idDespesa;
            abastecimento.Data = DateTime.Now;
            abastecimento.Valor = decimal.Parse("99.99");
            abastecimento.Desconto = decimal.Parse("77.77");
            abastecimento.idEmissor = 1;
            abastecimento.Kilometragem = 999999;
            abastecimento.Litros = 90;
            abastecimento.UnitTest = 1;
         
            return abastecimento;
        }

        #endregion

        #region Manutenções

        [TestMethod]
        public void ManutencaoPesquisar()
        {
            List<Manutencao> lstManutencoes = new List<Manutencao>();

            lstManutencoes = bizVeiculo.PesquisarManutencoes(new Manutencao() { UnitTest = 1 });

            Assert.AreEqual(true, lstManutencoes.Count > 0);
        }

        [TestMethod]
        public void ManutencaoIncluir_SemCamposObrigatorios()
        {
            int idManutencao = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirManutencao(new Manutencao(), out idManutencao);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ManutencaoIncluir()
        {
            Manutencao manutencao = new Manutencao();
            string Msg = string.Empty;
            int idManutencao = 0;

            manutencao = PreencherCamposObrigatoriosManutencao();
            
            Msg = bizVeiculo.IncluirManutencao(manutencao, out idManutencao);
            manutencao.idManutencao = idManutencao;

            bizVeiculo.AtualizarManutencaoOrdemPagamento(manutencao);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ManutencaoAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarManutencao(new Manutencao());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ManutencaoAlterar()
        {
            Manutencao manutencao = new Manutencao();
            string Msg = string.Empty;

            manutencao = bizVeiculo.PesquisarManutencoes(new Manutencao() { UnitTest = 1 })[0];
            manutencao.Descricao = "Descrição alterada";

            Msg = bizVeiculo.AlterarManutencao(manutencao);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void ManutencaoExcluir()
        {
            List<Manutencao> lstManutencoes = new List<Manutencao>();
            string Msg = string.Empty;

            bizVeiculo.ExcluirManutencaoTeste();

            lstManutencoes = bizVeiculo.PesquisarManutencoes(new Manutencao() { UnitTest = 1 });

            Assert.AreEqual(true, lstManutencoes.Count == 0);
        }

        private Manutencao PreencherCamposObrigatoriosManutencao()
        {
            Manutencao manutencao = new Manutencao();

            manutencao.idManutencao = 99;
            manutencao.numeroManutencao  = "0/2019";
            manutencao.idVeiculo = bizVeiculo.PesquisarVeiculos(new Veiculo())[0].idVeiculo; ;
            manutencao.idOP = new BIZOrdemPagamento().PesquisarOrdemPagamento(new OrdemPagamento())[0].idOrdemPagamento;
            manutencao.Descricao = "Descrição teste";
            manutencao.dataManutencao = DateTime.Now;
            manutencao.Valor = decimal.Parse("99.99");
            manutencao.UnitTest = 1;

            return manutencao;
        }

        #endregion

        #region Multas

        [TestMethod]
        public void MultasPesquisar()
        {
            List<Multa> lstMultas = new List<Multa>();

            lstMultas = bizVeiculo.PesquisarMultas(new Multa() { UnitTest = 1 });

            Assert.AreEqual(true, lstMultas.Count > 0);
        }

        [TestMethod]
        public void MultaIncluir_SemCamposObrigatorios()
        {
            int idMulta = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirMulta(new Multa(), out idMulta);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaIncluir()
        {
            Multa multa = new Multa();
            string Msg = string.Empty;
            int idMulta = 0;

            multa = PreencherCamposObrigatoriosMulta();

            Msg = bizVeiculo.IncluirMulta(multa, out idMulta);
            
            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarMulta(new Multa());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaAlterar()
        {
            Multa multa = new Multa();
            string Msg = string.Empty;

            multa = bizVeiculo.PesquisarMultas(new Multa() { UnitTest = 1 })[0];
            multa.Descricao = "Descrição alterada";

            Msg = bizVeiculo.AlterarMulta(multa);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaExcluir()
        {
            List<Multa> lstMulta = new List<Multa>();
            string Msg = string.Empty;

            bizVeiculo.ExcluirMultaTeste();

            lstMulta = bizVeiculo.PesquisarMultas(new Multa() { UnitTest = 1 });

            Assert.AreEqual(true, lstMulta.Count == 0);
        }

        private Multa PreencherCamposObrigatoriosMulta()
        {
            Multa multa = new Multa();
            
            multa.idMulta = 99;
            multa.idGravidade = bizVeiculo.PesquisarMultasGravidade(new MultaGravidade() { UnitTest = 1 })[0].idGravidade;
            multa.Codigo = "123-45";
            multa.Desdobramento = 9;
            multa.Descricao = "Descrição Multa";
            multa.Infrator = "Infrator";
            multa.Pontos = 99;
            multa.orgaoCompetente = "Orgão";
            multa.UnitTest = 1;

            return multa;
        }

        #endregion

        #region Gravidade da Multa

        [TestMethod]
        public void MultasGravidadePesquisar()
        {
            List<MultaGravidade> lstMultaGravidade = new List<MultaGravidade>();

            lstMultaGravidade = bizVeiculo.PesquisarMultasGravidade(new MultaGravidade() { UnitTest = 1 });

            Assert.AreEqual(true, lstMultaGravidade.Count > 0);
        }

        [TestMethod]
        public void MultaGravidadeIncluir_SemCamposObrigatorios()
        {
            int idGravidade = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirMultaGravidade(new MultaGravidade(), out idGravidade);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaGravidadeIncluir()
        {
            MultaGravidade gravidade = new MultaGravidade();
            string Msg = string.Empty;
            int idGravidade = 0;

            gravidade = PreencherCamposObrigatoriosGravidade();

            Msg = bizVeiculo.IncluirMultaGravidade(gravidade, out idGravidade);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaGravidadeAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarMultaGravidade(new MultaGravidade());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaGravidadeAlterar()
        {
            MultaGravidade gravidade = new MultaGravidade();
            string Msg = string.Empty;

            gravidade = bizVeiculo.PesquisarMultasGravidade(new MultaGravidade() { UnitTest = 1 })[0];
            gravidade.Descricao = "Descrição alterada";

            Msg = bizVeiculo.AlterarMultaGravidade(gravidade);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultaGravidadeExcluir()
        {
            List<MultaGravidade> lstGravidades = new List<MultaGravidade>();
            string Msg = string.Empty;

            bizVeiculo.ExcluirMultaGravidadeTeste();

            lstGravidades = bizVeiculo.PesquisarMultasGravidade(new MultaGravidade() { UnitTest = 1 });

            Assert.AreEqual(true, lstGravidades.Count == 0);
        }

        private MultaGravidade PreencherCamposObrigatoriosGravidade()
        {
            MultaGravidade gravidade = new MultaGravidade();

            gravidade.idGravidade = 99;
            gravidade.Descricao = "Descrição Gravidade";
            gravidade.Valor = decimal.Parse("99.88");
            gravidade.UnitTest = 1;

            return gravidade;
        }   

        #endregion

        #region Uso dos Veículos
        
        [TestMethod]
        public void UsoVeiculosPesquisar()
        {
            List<UsoVeiculo> lstUsos = new List<UsoVeiculo>();

            lstUsos = bizVeiculo.PesquisarUsoVeiculos(new UsoVeiculo() { UnitTest = 1 });

            Assert.AreEqual(true, lstUsos.Count > 0);
        }

        [TestMethod]
        public void UsoVeiculosIncluir_SemCamposObrigatorios()
        {
            int idUso = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirUsoVeiculo(new UsoVeiculo(), out idUso);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsoVeiculosIncluir()
        {
            UsoVeiculo uso = new UsoVeiculo();
            string Msg = string.Empty;
            int idUso = 0;

            uso = PreencherCamposObrigatoriosUsoVeiculos();

            Msg = bizVeiculo.IncluirUsoVeiculo(uso, out idUso);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsoVeiculosAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarUsoVeiculo(new UsoVeiculo());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsoVeiculosAlterar()
        {
            UsoVeiculo uso = new UsoVeiculo();
            string Msg = string.Empty;

            uso = bizVeiculo.PesquisarUsoVeiculos(new UsoVeiculo() { UnitTest = 1 })[0];
            uso.Observacoes = "Observação alterada";

            Msg = bizVeiculo.AlterarUsoVeiculo(uso);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void UsoVeiculosExcluir()
        {
            List<UsoVeiculo> lstUso = new List<UsoVeiculo>();
            string Msg = string.Empty;

            bizVeiculo.ExcluiUsoVeiculoTeste();

            lstUso = bizVeiculo.PesquisarUsoVeiculos(new UsoVeiculo() { UnitTest = 1 });

            Assert.AreEqual(true, lstUso.Count == 0);
        }

        private UsoVeiculo PreencherCamposObrigatoriosUsoVeiculos()
        {
            UsoVeiculo uso = new UsoVeiculo();
            
            uso.idUso = 8;
            uso.idVeiculo = bizVeiculo.PesquisarVeiculos(new Veiculo())[0].idVeiculo;
            uso.idMotorista = bizMotorista.PesquisarMotorista(new Motorista())[0].idMotorista;
            uso.dataSaida = DateTime.Now;
            uso.dataChegada = DateTime.Now;
            uso.Observacoes  = "Teste";
            uso.UnitTest = 1;
            
            return uso;            
        }

        #endregion

        #region Multas Ocorrências

        [TestMethod]
        public void MultasOcorrenciasPesquisar()
        {
            List<MultaOcorrencia> lstOcorrencias = new List<MultaOcorrencia>();

            lstOcorrencias = bizVeiculo.PesquisarMultaOcorrencia(new MultaOcorrencia() { UnitTest = 1 });

            Assert.AreEqual(true, lstOcorrencias.Count > 0);
        }

        [TestMethod]
        public void MultasOcorrenciasIncluir_SemCamposObrigatorios()
        {
            int idOcorrencia = 0;
            string Msg = string.Empty;

            Msg = bizVeiculo.IncluirMultaOcorrencia(new MultaOcorrencia(), out idOcorrencia);

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultasOcorrenciasIncluir()
        {
            MultaOcorrencia ocorrencia = new MultaOcorrencia();
            string Msg = string.Empty;
            int idOcorrencia = 0;

            ocorrencia = PreencherCamposObrigatoriosMultasOcorrencias();

            Msg = bizVeiculo.IncluirMultaOcorrencia(ocorrencia, out idOcorrencia);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultasOcorrenciasAlterar_SemCamposObrigatorio()
        {
            string Msg = string.Empty;

            Msg = bizVeiculo.AlterarMultaOcorrencia(new MultaOcorrencia());

            Assert.AreNotEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultasOcorrenciasAlterar()
        {
            MultaOcorrencia ocorrencia = new MultaOcorrencia();
            string Msg = string.Empty;

            ocorrencia = bizVeiculo.PesquisarMultaOcorrencia(new MultaOcorrencia() { UnitTest = 1 })[0];
            ocorrencia.dataMulta = DateTime.Now.AddDays(100);

            Msg = bizVeiculo.AlterarMultaOcorrencia(ocorrencia);

            Assert.AreEqual(string.Empty, Msg);
        }

        [TestMethod]
        public void MultasOcorrenciasExcluir()
        {
            List<MultaOcorrencia> lstUso = new List<MultaOcorrencia>();
            string Msg = string.Empty;

            bizVeiculo.ExcluiMultaOcorrenciaTeste();

            lstUso = bizVeiculo.PesquisarMultaOcorrencia(new MultaOcorrencia() { UnitTest = 1 });

            Assert.AreEqual(true, lstUso.Count == 0);
        }

        private MultaOcorrencia PreencherCamposObrigatoriosMultasOcorrencias()
        {
            MultaOcorrencia ocorrencia = new MultaOcorrencia();

            ocorrencia.idOcorrencia = 99;
            ocorrencia.idMulta = bizVeiculo.PesquisarMultas(new Multa())[0].idMulta;
            ocorrencia.idMotorista = bizMotorista.PesquisarMotorista(new Motorista())[0].idMotorista;
            ocorrencia.idVeiculo = bizVeiculo.PesquisarVeiculos(new Veiculo())[0].idVeiculo;            
            ocorrencia.dataMulta = DateTime.Now;
            ocorrencia.UnitTest = 1;

            return ocorrencia;
        }

        #endregion
    }
}
