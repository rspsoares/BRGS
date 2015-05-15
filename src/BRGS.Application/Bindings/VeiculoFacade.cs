using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class VeiculoFacade: IVeiculoFacade
    {
        public virtual List<Veiculo> Pesquisar(Veiculo veiculo)
        {
            return new List<Veiculo>();
        }

        public virtual List<Veiculo> PesquisarCombo()
        {
            return new List<Veiculo>();
        }

        public virtual string Incluir(Veiculo veiculo, out int idVeiculo)
        {
            idVeiculo = 0;
            return "";
        }

        public virtual string Alterar(Veiculo veiculo)
        {
            return "";
        }

        public virtual string ValidarExclusao(Veiculo veiculo)
        {
            return "";
        }

        public virtual string Excluir(Veiculo veiculo)
        {
            return "";
        }

        #region Abastecimento

        public virtual List<Abastecimento> PesquisarAbastecimentos(Abastecimento abastecimento)
        {
            return new List<Abastecimento>();
        }

        public virtual DataTable GerarAutorizacaoAbastecimento(Abastecimento abastecimento)
        {
            return new DataTable();
        }

        public virtual string IncluirAbastecimentos(Abastecimento abastecimento, out int idAbastecimento)
        {
            idAbastecimento = 0;
            return "";
        }

        public virtual string AlterarAbastecimento(Abastecimento abastecimento)
        {
            return "";
        }

        public virtual string ValidarExclusaoAbastecimento(Abastecimento abastecimento)
        {
            return "";
        }

        public virtual string ExcluirAbastecimento(Abastecimento abastecimento)
        {
            return "";
        }

        #endregion

        #region Manutenção

        public virtual List<Manutencao> PesquisarManutencoes(Manutencao manutencao)
        {
            return new List<Manutencao>();
        }

        public virtual string IncluirManutencao(Manutencao manutencao, out int idManutencao)
        {
            idManutencao = 0;
            return "";
        }

        public virtual string AlterarManutencao(Manutencao manutencao)
        {
            return "";
        }

        public virtual string ValidarExclusaoManutencao(Manutencao manutencao)
        {
            return "";
        }

        public virtual string ExcluirManutencao(Manutencao manutencao)
        {
            return "";
        }

        #endregion

        #region Multas

        public virtual List<Multa> PesquisarMultas(Multa multa)
        {
            return new List<Multa>();
        }

        public virtual string IncluirMulta(Multa multa, out int idMulta)
        {
            idMulta = 0;
            return "";
        }

        public virtual string AlterarMulta(Multa multa)
        {
            return "";
        }

        public virtual string ExcluirMulta(Multa multa)
        {
            return "";
        }

        #endregion

        #region Multas Gravidade

        public virtual List<MultaGravidade> PesquisarMultasGravidade(MultaGravidade gravidade)
        {
            return new List<MultaGravidade>();
        }

        public virtual string IncluirMultaGravidade(MultaGravidade gravidade, out int idGravidade)
        {
            idGravidade = 0;
            return "";
        }

        public virtual string AlterarMultaGravidade(MultaGravidade gravidade)
        {
            return "";
        }

        public virtual string ValidarExclusaoMultaGravidade(MultaGravidade gravidade)
        {
            return "";
        }

        public virtual string ExcluirMultaGravidade(MultaGravidade gravidade)
        {
            return "";
        }

        #endregion

        #region Uso de Veículos

        public virtual List<UsoVeiculo> PesquisarUsoVeiculos(UsoVeiculo uso)
        {
            return new List<UsoVeiculo>();
        }

        public virtual string IncluirUsoVeiculo(UsoVeiculo uso, out int idUso)
        {
            idUso = 0;
            return "";
        }

        public virtual string AlterarUsoVeiculo(UsoVeiculo uso)
        {
            return "";
        }

        public virtual string ValidarExclusaoUsoVeiculo(UsoVeiculo uso)
        {
            return "";
        }

        public virtual string ExcluirUsoVeiculo(UsoVeiculo uso)
        {
            return "";
        }

        #endregion

        #region Ocorrência de Multas

        public virtual List<MultaOcorrencia> PesquisarMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            return new List<MultaOcorrencia>();
        }

        public virtual string IncluirMultaOcorrencia(MultaOcorrencia ocorrencia, out int idOcorrencia)
        {
            idOcorrencia = 0;
            return "";
        }

        public virtual string AlterarMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            return "";
        }

        public virtual string ValidarExclusaoMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            return "";
        }

        public virtual string ExcluirMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            return "";
        }

        #endregion
    }
}
