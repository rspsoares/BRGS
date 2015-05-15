using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Contracts
{
    public interface IVeiculoFacade
    {
        List<Veiculo> Pesquisar(Veiculo veiculo);
        
        List<Veiculo> PesquisarCombo();
        
        string Incluir(Veiculo veiculo, out int idVeiculo);
        
        string Alterar(Veiculo veiculo);
        
        string ValidarExclusao(Veiculo veiculo);
        
        string Excluir(Veiculo veiculo);

        #region Abastecimento
        
        List<Abastecimento> PesquisarAbastecimentos(Abastecimento abastecimento);

        DataTable GerarAutorizacaoAbastecimento(Abastecimento abastecimento);

        string IncluirAbastecimentos(Abastecimento abastecimento, out int idAbastecimento);

        string AlterarAbastecimento(Abastecimento abastecimento);

        string ValidarExclusaoAbastecimento(Abastecimento abastecimento);

        string ExcluirAbastecimento(Abastecimento abastecimento);

	    #endregion
        
        #region Manutenção

        List<Manutencao> PesquisarManutencoes(Manutencao manutencao);

        string IncluirManutencao(Manutencao manutencao, out int idManutencao);

        string AlterarManutencao(Manutencao manutencao);
        
        string ValidarExclusaoManutencao(Manutencao manutencao);

        string ExcluirManutencao(Manutencao manutencao);
        
        #endregion
        
        #region Multas

        List<Multa> PesquisarMultas(Multa multa);

        string IncluirMulta(Multa multa, out int idMulta);

        string AlterarMulta(Multa multa);

        string ExcluirMulta(Multa multa);

        #endregion
        
        #region Multas Gravidade

        List<MultaGravidade> PesquisarMultasGravidade(MultaGravidade gravidade);

        string IncluirMultaGravidade(MultaGravidade gravidade, out int idGravidade);

        string AlterarMultaGravidade(MultaGravidade gravidade);

        string ValidarExclusaoMultaGravidade(MultaGravidade gravidade);

        string ExcluirMultaGravidade(MultaGravidade gravidade);
                
        #endregion

        #region Uso de Veículos

        List<UsoVeiculo> PesquisarUsoVeiculos(UsoVeiculo uso);

        string IncluirUsoVeiculo(UsoVeiculo uso, out int idUso);

        string AlterarUsoVeiculo(UsoVeiculo uso);

        string ValidarExclusaoUsoVeiculo(UsoVeiculo uso);

        string ExcluirUsoVeiculo(UsoVeiculo uso);
        
        #endregion

        #region Ocorrência de Multas

        List<MultaOcorrencia> PesquisarMultaOcorrencia(MultaOcorrencia ocorrencia);

        string IncluirMultaOcorrencia(MultaOcorrencia ocorrencia, out int idOcorrencia);

        string AlterarMultaOcorrencia(MultaOcorrencia ocorrencia);

        string ValidarExclusaoMultaOcorrencia(MultaOcorrencia ocorrencia);

        string ExcluirMultaOcorrencia(MultaOcorrencia ocorrencia);

        #endregion
    }
}
