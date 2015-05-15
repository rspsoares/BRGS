using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZOrdemPagamento
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        private Dictionary<string, string> MontarParametrosExecutarOrdemPagamento(OrdemPagamento ordemPagamento)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idOrdemPagamento", ordemPagamento.idOrdemPagamento.ToString());
            lstParametros.Add("@idEmpresa", ordemPagamento.idEmpresa.ToString());
            lstParametros.Add("@idObraEtapa", ordemPagamento.idObraEtapa.ToString());
            lstParametros.Add("@idFavorecido", ordemPagamento.idFavorecido.ToString());
            lstParametros.Add("@idContaBancaria", ordemPagamento.idContaBancaria.ToString());
            lstParametros.Add("@idSolicitante", ordemPagamento.idSolicitante.ToString());
            lstParametros.Add("@NumeroOP", ordemPagamento.numeroOP.ToString());      
            lstParametros.Add("@idAutorizado", ordemPagamento.idAutorizado.ToString());
            lstParametros.Add("@DataSolicitacao", ordemPagamento.dataSolicitacao.ToString());            
            lstParametros.Add("@Observacao", ordemPagamento.Observacao.ToString());
            lstParametros.Add("@Status", ordemPagamento.Status.ToString());
            lstParametros.Add("@Cancelada", ordemPagamento.Cancelada.ToString());
            lstParametros.Add("@ObservacaoCancelada", ordemPagamento.observacaoCancelada.ToString());
            lstParametros.Add("@UnitTest", ordemPagamento.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarOrdemPagamentoItem(OrdemPagamentoItem ordemPagamentoItem)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idOrdemPagamento", ordemPagamentoItem.idOrdemPagamento.ToString());
            lstParametros.Add("@idUEN", ordemPagamentoItem.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", ordemPagamentoItem.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", ordemPagamentoItem.idDespesa.ToString());
            lstParametros.Add("@idUsuarioPagamento", ordemPagamentoItem.idUsuarioPagamento.ToString());
            lstParametros.Add("@idAbastecimento", ordemPagamentoItem.idAbastecimento.ToString());
            lstParametros.Add("@idManutencao", ordemPagamentoItem.idManutencao.ToString());
            lstParametros.Add("@Valor", ordemPagamentoItem.Valor.ToString());
            lstParametros.Add("@ValorPago", ordemPagamentoItem.valorPago.ToString());
            lstParametros.Add("@DataVencimento", ordemPagamentoItem.dataVencimento.Date.ToString());
            lstParametros.Add("@DataPagamento", ordemPagamentoItem.dataPagamento == DateTime.MinValue ? "01/01/1753 00:00:00.000" : ordemPagamentoItem.dataPagamento.Date.ToString());
            lstParametros.Add("@NumeroParcela", ordemPagamentoItem.numeroParcela.ToString());
            lstParametros.Add("@TotalParcelas", ordemPagamentoItem.totalParcelas.ToString());
            lstParametros.Add("@Desconto", ordemPagamentoItem.Desconto.ToString());
            lstParametros.Add("@Multa", ordemPagamentoItem.Multa.ToString());
            lstParametros.Add("@UnitTest", ordemPagamentoItem.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarOrdemPagamento(OrdemPagamento ordemPagamento)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idOrdemPagamento", ordemPagamento.idOrdemPagamento.Equals(0) ? null : ordemPagamento.idOrdemPagamento.ToString());
            lstParametros.Add("@idEmpresa", ordemPagamento.idEmpresa.Equals(0) ? null : ordemPagamento.idEmpresa.ToString());
            lstParametros.Add("@NomeEmpresa", string.IsNullOrEmpty(ordemPagamento.razaoSocial) ? null : ordemPagamento.razaoSocial);
            lstParametros.Add("@NumeroOP", string.IsNullOrEmpty(ordemPagamento.numeroOP) ? null : ordemPagamento.numeroOP);
            lstParametros.Add("@idObraEtapa", ordemPagamento.idObraEtapa.Equals(0) ? null : ordemPagamento.idObraEtapa.ToString());
            lstParametros.Add("@idFavorecido", ordemPagamento.idFavorecido.Equals(0) ? null : ordemPagamento.idFavorecido.ToString());
            lstParametros.Add("@idContaBancaria", ordemPagamento.idContaBancaria.Equals(0) ? null : ordemPagamento.idContaBancaria.ToString());
            lstParametros.Add("@NomeFavorecido", string.IsNullOrEmpty(ordemPagamento.nomeFavorecido) ? null : ordemPagamento.nomeFavorecido);            
            lstParametros.Add("@NomeSolicitante", string.IsNullOrEmpty(ordemPagamento.nomeSolicitante) ? null : ordemPagamento.nomeSolicitante);
            lstParametros.Add("@DataVencimento", ordemPagamento.dataVencimentoParcela.Equals(DateTime.MinValue) ? null : ordemPagamento.dataVencimentoParcela.Date.ToString());
            lstParametros.Add("@DataPagamento", ordemPagamento.dataPagamentoParcela.Equals(DateTime.MinValue) ? null : ordemPagamento.dataPagamentoParcela.ToString());            
            lstParametros.Add("@Status", string.IsNullOrEmpty(ordemPagamento.Status) ? null : ordemPagamento.Status);
            lstParametros.Add("@Observacao", string.IsNullOrEmpty(ordemPagamento.Observacao) ? null : ordemPagamento.Observacao);                        
            lstParametros.Add("@UnitTest", ordemPagamento.UnitTest.Equals(0) ? null : ordemPagamento.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarOrdemPagamentoItem(OrdemPagamentoItem ordemPagamentoItem)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idOrdemPagamento", ordemPagamentoItem.idOrdemPagamento.Equals(0) ? null : ordemPagamentoItem.idOrdemPagamento.ToString());
            lstParametros.Add("@idUEN", ordemPagamentoItem.idUEN.Equals(0) ? null : ordemPagamentoItem.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", ordemPagamentoItem.idCentroCusto.Equals(0) ? null : ordemPagamentoItem.idCentroCusto.ToString());            
            lstParametros.Add("@idDespesa", ordemPagamentoItem.idDespesa.Equals(0) ? null : ordemPagamentoItem.idDespesa.ToString());            
            return lstParametros;
        }

        public List<OrdemPagamento> PesquisarOrdemPagamento(OrdemPagamento ordemPagamento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();            
            List<OrdemPagamento> lstOrdensPagamentos = new List<OrdemPagamento>();
            dynamic lst = new List<OrdemPagamento>();

            try
            {
                lstParametros = this.MontarParametrosPesquisarOrdemPagamento(ordemPagamento);

                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<OrdemPagamento>()
                          select f;               
                }

                lstOrdensPagamentos.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstOrdensPagamentos;
        }

        public List<OrdemPagamentoItem> PesquisarOrdemPagamentoItem(OrdemPagamentoItem ordemPagamentoItem)
        {
            List<OrdemPagamentoItem> lstItens = new List<OrdemPagamentoItem>();
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            dynamic lst = new List<OrdemPagamentoItem>();

            try
            {
                lstParametros = this.MontarParametrosPesquisarOrdemPagamentoItem(ordemPagamentoItem);

                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTOITENS_CONSULTAR", lstParametros))
                {

                    lst = from f in ds.Tables[0].AsEnumerable<OrdemPagamentoItem>()
                          select f;         
                }

                lstItens.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTOITENS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstItens;
        }

        public List<OrdemPagamento> PesquisarOPAbastecimento()
        {
            DataAccess dao = new DataAccess();
            List<OrdemPagamento> lstOPAbastecimento = new List<OrdemPagamento>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            dynamic lst = new List<OrdemPagamento>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_CONSULTAR_ABASTECIMENTO", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<OrdemPagamento>()
                          select f;
                }

                lstOPAbastecimento.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_CONSULTAR_ABASTECIMENTO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstOPAbastecimento;
        }

        public DataTable GerarRelatorioOrdemPagamentoEmitida(string filtroSQL, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtOP = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtroSQL);                
                DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_RELATORIO_EMITIDAS", lstParametros);
                dtOP = ds.Tables[0];

                dtOP = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtOP);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_RELATORIO_EMITIDAS",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtOP;
        }

        public DataTable GerarRelatorioOrdemPagamentoGastoObra(string filtro, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtOP = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_RELATORIO_GASTO", lstParametros);
                dtOP = ds.Tables[0];

                dtOP = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtOP);              
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_RELATORIO_GASTO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtOP;
        }

        public DataTable GerarRelatorioOrdemPagamentoGastoFixo(string filtro, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtOP = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_RELATORIO_GASTOFIXO", lstParametros);
                dtOP = ds.Tables[0];

                dtOP = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtOP);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_RELATORIO_GASTOFIXO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtOP;
        }      

        private string ValidarCamposObrigatorios(OrdemPagamento ordemPagamento)
        {
            string Msg = string.Empty;
            string statusForecido = string.Empty;

            if (ordemPagamento.idEmpresa == 0)
                Msg += Environment.NewLine + "Favor selecionar a Empresa";
            
            if (ordemPagamento.idFavorecido == 0)
                Msg += Environment.NewLine + "Favor selecionar o Favorecido";
            
            if (ordemPagamento.idContaBancaria == 0)
                Msg += Environment.NewLine + "Favor selecionar a Conta Bancária";

            if (ordemPagamento.idOrdemPagamento == 0 && ordemPagamento.favorecidoInativo == true)
                Msg += Environment.NewLine + "Favor selecionar um Favorecido ATIVO";

            if (ordemPagamento.idAutorizado == 0)
                Msg += Environment.NewLine + "Favor selecionar o Nome de quem autorizou";

            if(ordemPagamento.Cancelada == 1 && ordemPagamento.observacaoCancelada == string.Empty)
                Msg += Environment.NewLine + "Favor justificar o cancelamento dessa Ordem de Pagamento";

            if (ordemPagamento.lstItens == null || ordemPagamento.lstItens.Count == 0)
                Msg += Environment.NewLine + "Favor adicionar pelo menos um item";

            if (ordemPagamento.lstItens != null && ordemPagamento.lstItens.Exists(x => x.idAbastecimento == 0)) // As regras abaixo não se aplicarão para OP's de Abastecimento
            {
                if (ordemPagamento.lstItens != null && ordemPagamento.lstItens.GroupBy(x => x.idUEN).Count() > 1)
                    Msg += Environment.NewLine + "Só podem haver despesas de uma única UEN";

                if (ordemPagamento.lstItens != null && ordemPagamento.lstItens.GroupBy(x => x.idCentroCusto).Count() > 1)
                    Msg += Environment.NewLine + "Só podem haver despesas de um único Centro de Custo";
            }

            return Msg;
        }

        private bool VerificarDuplicidadeOP(OrdemPagamento ordemPagamento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            bool existeOP = false;

            try
            {
                foreach (OrdemPagamentoItem itemOP in ordemPagamento.lstItens )
                {
                    lstParametros = new Dictionary<string, string>();
                    lstParametros.Add("@idFavorecido", ordemPagamento.idFavorecido.ToString());                    
                    lstParametros.Add("@idDespesa", itemOP.idDespesa.ToString());
                    lstParametros.Add("@DataVencimento", itemOP.dataVencimento.Date.ToShortDateString());

                    using (DataSet ds = dao.Pesquisar("dbo.SP_ORDEMPAGAMENTO_VERIFICARDUPLICIDADE", lstParametros))
                    {
                        existeOP = ds.Tables[0].Rows.Count > 0;
                    }

                    if (existeOP)
                        break;
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAIS_VERIFICARDUPLICIDADE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return existeOP;
        }
       
        public string IncluirOrdemPagamento(OrdemPagamento ordemPagamento, bool origemConsultaOP, out int idOrdemPagamento)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            BIZVeiculo bizVeiculo = new BIZVeiculo();
            BIZFrete bizFrete = new BIZFrete();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(ordemPagamento);
                idOrdemPagamento = 0;
                
                if (Msg == string.Empty)
                {
                    using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_NOVONUMEROOP", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        ordemPagamento.numeroOP = dr[0].ToString();
                    }

                    lstParametros = MontarParametrosExecutarOrdemPagamento(ordemPagamento);

                    using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idOrdemPagamento = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(this.IncluirOrdemPagamentoItens(idOrdemPagamento, ordemPagamento.idObraEtapa, ordemPagamento.lstItens));

                    dao.ExecutarTransacao(lstComandos);

                    if (ordemPagamento.lstItens.Exists(x => x.idFrete != 0))
                    {
                        FretePagamento fretePagamento = new FretePagamento()
                        {
                            idFrete = ordemPagamento.lstItens.Where(x => x.idFrete != 0).FirstOrDefault().idFrete,
                            idOP = idOrdemPagamento
                        };

                        bizFrete.IncluirPagamento(fretePagamento);
                    }

                    if (ordemPagamento.lstItens.Exists(x => x.idManutencao  != 0))
                    {
                        Manutencao manutencao = new Manutencao()
                        {
                            idManutencao = ordemPagamento.lstItens.Where(x => x.idManutencao != 0).FirstOrDefault().idManutencao,
                            idOP = idOrdemPagamento,
                        };

                        bizVeiculo.AtualizarManutencaoOrdemPagamento(manutencao);
                    }

                    if (ordemPagamento.lstItens.Exists(x => x.idOcorrenciaMulta != 0))
                    {
                        MultaOcorrencia ocorrencia = new MultaOcorrencia()
                        {
                            idOcorrencia = ordemPagamento.lstItens.Where(x => x.idOcorrenciaMulta != 0).FirstOrDefault().idOcorrenciaMulta,                            
                            idOP = idOrdemPagamento
                        };

                        bizVeiculo.AtualizarMultaOcorrenciaOrdemPagamento(ocorrencia);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        private List<_Transacao> IncluirOrdemPagamentoItens(int idOrdemPagamento, int idObra, List<OrdemPagamentoItem> lstItens)
        {
            BIZObra bizObra = new BIZObra();
            List<ObraEtapaGastoRealizado> lstRealizados = new List<ObraEtapaGastoRealizado>();
            BIZVeiculo bizVeiculo = new BIZVeiculo();
            List<Abastecimento> lstAbastecimentos = new List<Abastecimento>();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (OrdemPagamentoItem itemOrdem in lstItens)
            {
                itemOrdem.idOrdemPagamento = idOrdemPagamento;
                lstParametros = this.MontarParametrosExecutarOrdemPagamentoItem(itemOrdem);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_ORDEMPAGAMENTOITENS_INCLUIR",
                    lstParametros = lstParametros
                });

                if (itemOrdem.idObraGastoRealizado != 0)
                {
                    lstRealizados.Add(new ObraEtapaGastoRealizado()
                    {
                        idObraEtapaGastoRealizado = itemOrdem.idObraGastoRealizado,
                        idObraEtapa = idObra,
                        idUEN = itemOrdem.idUEN,
                        idCentroCusto = itemOrdem.idCentroCusto,
                        idDespesa = itemOrdem.idDespesa,
                        Valor = itemOrdem.Valor,
                        Observacao = string.Empty,
                        UnitTest = itemOrdem.UnitTest
                    });

                    lstComandos.AddRange(bizObra.AtualizarGastosRealizadosOrdemPagamento(idOrdemPagamento, lstRealizados));
                }
                
                if (itemOrdem.idAbastecimento != 0)
                {
                    lstAbastecimentos.Add(new Abastecimento()
                    {
                        idAbastecimento = itemOrdem.idAbastecimento
                    });

                    lstComandos.AddRange(bizVeiculo.AtualizarAbastecimentosOrdemPagamento(idOrdemPagamento, lstAbastecimentos));
                }
            }

            return lstComandos;
        }

        public string AlterarOrdemPagamento(OrdemPagamento ordemPagamento)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();            
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(ordemPagamento);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_ORDEMPAGAMENTO_ALTERAR",
                        lstParametros = MontarParametrosExecutarOrdemPagamento(ordemPagamento)
                    });

                    lstParametrosItens.Add("@idOrdemPagamento", ordemPagamento.idOrdemPagamento.ToString());
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_ORDEMPAGAMENTOITENS_EXCLUIR",
                        lstParametros = lstParametrosItens
                    });

                    lstComandos.AddRange(this.IncluirOrdemPagamentoItens(ordemPagamento.idOrdemPagamento, ordemPagamento.idObraEtapa, ordemPagamento.lstItens));

                    dao.ExecutarTransacao(lstComandos);                  
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirOrdemPagamento(OrdemPagamento ordemPagamento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idOrdemPagamento", ordemPagamento.idOrdemPagamento.ToString());

            try
            {
                dao.Executar("SP_ORDEMPAGAMENTO_EXCLUIR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }
        
        public void ExcluirOrdemPagamentoTestes()
        {
            DataAccess dao = new DataAccess();

            try
            {
                dao.Executar("SP_ORDEMPAGAMENTO_EXCLUIRTESTE", new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public DataTable GerarOrdemPagamento(OrdemPagamento opSelecionada, out DataTable dtObras)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtOP = new DataTable();         
            dtObras = new DataTable();

            try
            {
                lstParametros.Add("@idOrdemPagamento", opSelecionada.idOrdemPagamento.ToString());
                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_EMISSAO", lstParametros))
                {
                    dtOP = ds.Tables[0];                    
                }
               
                lstParametros.Add("@idObraEtapa", opSelecionada.idObraEtapa.ToString());
                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_EMISSAO_SUBRELATORIO_OBRAS", lstParametros))
                {
                    dtObras = ds.Tables[0];
                }                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_EMISSAO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtOP;
        }
    }
}
