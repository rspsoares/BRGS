using BRGS.Entity;
using BRGS.Entity.DTO;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        private Dictionary<string, string> MontarParametrosPesquisarOrdemPagamentoMobile(OrdemPagamentoGridFiltroMobileDTO opFiltro)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>
            {
                { "@NumeroOP", string.IsNullOrEmpty(opFiltro.numeroOP) ? null : opFiltro.numeroOP },
                { "@NomeFavorecido", string.IsNullOrEmpty(opFiltro.nomeFavorecido) ? null : opFiltro.nomeFavorecido },                
                { "@DataPagamentoInicial", opFiltro.dataPagamentoParcelaInicial.Equals(DateTime.MinValue) ? null : opFiltro.dataPagamentoParcelaInicial.ToString("yyyy-MM-dd") },
                { "@DataPagamentoFinal", opFiltro.dataPagamentoParcelaFinal.Equals(DateTime.MinValue) ? null : opFiltro.dataPagamentoParcelaFinal.ToString("yyyy-MM-dd") },
                { "@Status", string.IsNullOrEmpty(opFiltro.Status) ? null : opFiltro.Status },
                { "@Sort", string.IsNullOrEmpty(opFiltro.Sort) ? null : opFiltro.Sort},
                { "@Offset", opFiltro.Offset.ToString() },
                { "@Limit", opFiltro.Limit.ToString() }
            };

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

        private string PrepararFiltroGrid(OrdemPagamento op)
        {
            var sbFiltro = new StringBuilder();
            sbFiltro.Append("1 = 1 AND");

            if (!string.IsNullOrEmpty(op.razaoSocial))
                sbFiltro.Append($" E.RazaoSocial LIKE '%{op.razaoSocial}%' AND");

            if (!string.IsNullOrEmpty(op.numeroOP))
                sbFiltro.Append($" OP.NumeroOP LIKE '%{op.numeroOP}%' AND");

            if (!string.IsNullOrEmpty(op.nomeFavorecido))
                sbFiltro.Append($" F.Nome LIKE '%{op.nomeFavorecido}%' AND");

            if (!op.dataPagamentoParcela.Equals(DateTime.MinValue))
                sbFiltro.Append($" OPI.DataPagamento = CONVERT(DATETIME, '{op.dataPagamentoParcela.Date.ToString()}', 103) AND");

            if (!op.dataVencimentoParcela.Equals(DateTime.MinValue))
                sbFiltro.Append($" OPI.DataVencimento = CONVERT(DATETIME, '{op.dataVencimentoParcela.Date.ToString()}', 103) AND");

            if (!string.IsNullOrEmpty(op.Status))
                sbFiltro.Append($" OP.Status LIKE '%{op.Status}%' AND");

            if (!string.IsNullOrEmpty(op.Observacao))
                sbFiltro.Append($" OP.Observacao LIKE '%{op.Observacao}%' AND");

            return sbFiltro
                .ToString()
                .Substring(0, sbFiltro.ToString().Length - 3)
                .Trim();
        }

        private string ScriptConsultaBase(string filtro)
        {
            var sql = new StringBuilder()
                .AppendLine("SELECT DISTINCT ")
                .AppendLine("OP.idOrdemPagamento ")
                .AppendLine(",OP.NumeroOP ")
                .AppendLine(",E.RazaoSocial ")
                .AppendLine(",C.Nome AS 'NomeCliente' ")
                .AppendLine(",O.NomeEvento ")
                .AppendLine(",F.Nome AS 'NomeFavorecido' ")
                .AppendLine(",(SELECT SUM(OPI.Valor) from OrdemPagamentoItens OPI where OPI.idOrdemPagamento = OP.idOrdemPagamento) as 'ValorTotal' ")
                .AppendLine(",OP.Status ")
                .AppendLine(",OP.Observacao ")
                .AppendLine(",(SELECT MAX(OPI.DataPagamento) from OrdemPagamentoItens OPI where OPI.idOrdemPagamento = OP.idOrdemPagamento) as 'DataPagamentoParcela' ")
                .AppendLine(",(SELECT isnull(MIN(OPI.DataVencimento),'1753-01-01 00:00:00.000') FROM OrdemPagamentoItens OPI where OPI.idOrdemPagamento = OP.idOrdemPagamento AND OPI.DataPagamento = '1753-01-01 00:00:00.000') AS 'dataVencimentoParcela' ")
                .AppendLine("FROM OrdemPagamento OP ")
                .AppendLine("INNER JOIN Fornecedores F on OP.idFavorecido = F.idFornecedor ")
                .AppendLine("LEFT JOIN ObrasEtapas O on OP.idObraEtapa = O.idObraEtapa ")
                .AppendLine("LEFT JOIN Clientes C on O.idCliente = C.idCliente ")
                .AppendLine("INNER JOIN Empresas E on OP.idEmpresa = E.idEmpresa ")
                .AppendLine("INNER JOIN OrdemPagamentoItens OPI ON OP.idOrdemPagamento = OPI.idOrdemPagamento ")
                .AppendLine($"WHERE {filtro} ");

            return sql.ToString();
        }

        private string PrepararSelectGridOP(string consultaBase, string sort, int take, int skip)
        {
            var sql = new StringBuilder()                 
                 .AppendLine($"{consultaBase} ")
                 .AppendLine($"ORDER BY {sort} ")
                 .AppendLine($"OFFSET {skip} ROWS ")
                 .AppendLine($"FETCH NEXT {take} ROWS ONLY");

            return sql.ToString();
        }

        private string PrepararSelectContador(string sqlConsultaBase)
        {
            var sql = new StringBuilder()
                .AppendLine("SELECT COUNT(1) as 'Qtd' FROM (")
                .AppendLine($"{sqlConsultaBase}")
                .AppendLine(") T");

            return sql.ToString();
        }

        public List<OrdemPagamento> GridOrdemPagamento(OrdemPagamento op, int take, int skip, string sort, out int totalLines, out int currentPage, out int totalPages)
        {
            var dao = new DataAccess();
            var lstOPs = new List<OrdemPagamento>();
            var parametros = new Dictionary<string, string>();
            dynamic lst = new List<OrdemPagamento>();

            totalLines = 0;
            totalPages = 0;

            try
            {
                var currPage = (decimal)skip / take;
                currentPage = currPage > 0
                    ? (int)Math.Ceiling(currPage) + 1
                    : 1;

                var filtro = PrepararFiltroGrid(op);

                var sqlConsultaBase = ScriptConsultaBase(filtro);

                var sqlContador = PrepararSelectContador(sqlConsultaBase);
                parametros = new Dictionary<string, string>
                {
                    { "@SQL", sqlContador }
                };

                using (DataSet ds = dao.Pesquisar("SP_BRGS_GRID", parametros))
                {
                    var dr = ds.Tables[0].Rows[0];
                    totalLines = int.Parse(dr["Qtd"].ToString());
                }

                totalPages = (int)Math.Ceiling(totalLines / (double)take);

                var sqlGrid = PrepararSelectGridOP(sqlConsultaBase, sort, take, skip);
                parametros = new Dictionary<string, string>
                {
                    { "@SQL", sqlGrid }
                };

                using (DataSet ds = dao.Pesquisar("SP_BRGS_GRID", parametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<OrdemPagamento>()
                          select f;
                }

                lstOPs.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(parametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_BRGS_GRID",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstOPs;
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

        public DataTable GerarRelatorioOrdemPagamentoEmitida(string filtroSQL, string filtroRelatorio, int idObraEtapa, out DataTable dtTotaisObra, out DataTable dtEquipamento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtOP = new DataTable();
            dtTotaisObra = new DataTable();
            dtEquipamento = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtroSQL);                
                DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_RELATORIO_EMITIDAS", lstParametros);
                dtOP = ds.Tables[0];
                dtOP = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtOP);

                if (idObraEtapa > 0)
                {
                    lstParametros = new Dictionary<string, string>();
                    lstParametros.Add("@idObraEtapa", idObraEtapa.ToString());
                    using (DataSet dsTotais = dao.Pesquisar("SP_ORDEMPAGAMENTO_EMISSAO_SUBRELATORIO_TOTAIS", lstParametros))
                    {
                        dtTotaisObra = dsTotais.Tables[0];
                    }

                    lstParametros = new Dictionary<string, string>();
                    DataSet dsEquip = dao.Pesquisar("SP_OBRAS_RELATORIO_EQUIPAMENTOS", lstParametros);
                    dtEquipamento = dsEquip.Tables[0];

                    var dr2 = dtEquipamento.Select($"IdObraEtapa = {idObraEtapa}");

                    DataColumn hasEquipamento = new DataColumn("HasEquipamento", typeof(bool))
                    {
                        DefaultValue = dr2.Length > 0
                    };
                    dtTotaisObra.Columns.Add(hasEquipamento);
                }
                else
                {
                    dtTotaisObra.Columns.Add("idObraEtapa", typeof(int));
                    dtTotaisObra.Columns.Add("ValorContrato", typeof(double));
                    dtTotaisObra.Columns.Add("TotalPago", typeof(double));
                    dtTotaisObra.Columns.Add("TotalAberto", typeof(double));
                    dtTotaisObra.Columns.Add("HasEquipamento", typeof(bool));
                    dtTotaisObra.Rows.Add(0, 0, 0, 0, false);
                }                    
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

        public DataTable GerarOrdemPagamento(OrdemPagamento opSelecionada, out DataTable dtObras, out DataTable dtTotaisObra)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtOP = new DataTable();         
            dtObras = new DataTable();
            dtTotaisObra = new DataTable();

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

                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idObraEtapa", opSelecionada.idObraEtapa.ToString());
                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_EMISSAO_SUBRELATORIO_TOTAIS", lstParametros))
                {
                    dtTotaisObra = ds.Tables[0];
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

        public List<int> PesquisarOrdemPagamentoSemBinarioCrystal()
        {
            try
            {
                DataAccess dao = new DataAccess();
                dynamic lst = new List<OrdemPagamentoGridMobileDTO>();
                var result = new List<OrdemPagamentoGridMobileDTO>();

                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_SEM_BINARIO_CRYSTAL", new Dictionary<string, string>()))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<OrdemPagamentoGridMobileDTO>()
                          select f;
                }

                result.AddRange(lst);

                return result
                    .Select(x => x.IdOrdemPagamento)
                    .ToList();
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_SEM_BINARIO_CRYSTAL",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void AtualizarBinarioCrystalOrdemPagamento(string idOP, string pdfContent)
        {
            DataAccess dao = new DataAccess();            
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idOrdemPagamento", idOP);
                lstParametros.Add("@pdfContent", pdfContent);

                dao.Executar("SP_ORDEMPAGAMENTO_ATUALIZARBINARIOCRYSTAL", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_ATUALIZARBINARIOCRYSTAL",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string PesquisarBinarioCrystalOrdemPagamento(string idOP)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            var pdfContent = string.Empty;

            try
            {
                lstParametros.Add("@idOrdemPagamento", idOP);

                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_PESQUISARBINARIOCRYSTAL", lstParametros))
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    pdfContent = dr[0].ToString();
                }               
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_PESQUISARBINARIOCRYSTAL",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return pdfContent;
        }

        public List<OrdemPagamentoGridMobileDTO> PesquisarOrdemPagamentoMobile(OrdemPagamentoGridFiltroMobileDTO opFiltro, out int totalRecords)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<OrdemPagamentoGridMobileDTO> lstOrdensPagamentos = new List<OrdemPagamentoGridMobileDTO>();
            dynamic lst = new List<OrdemPagamentoGridMobileDTO>();

            try
            {
                lstParametros = this.MontarParametrosPesquisarOrdemPagamentoMobile(opFiltro);
                using (DataSet ds = dao.Pesquisar("SP_ORDEMPAGAMENTO_GRID_MOBILE", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<OrdemPagamentoGridMobileDTO>()
                          select f;
                }

                lstOrdensPagamentos.AddRange(lst);
                totalRecords = lstOrdensPagamentos.FirstOrDefault()?.TotalRows ?? 0;
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ORDEMPAGAMENTO_GRID_MOBILE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstOrdensPagamentos;
        }
    }
}
