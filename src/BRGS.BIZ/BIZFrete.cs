using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZFrete
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZObra bizObra = new BIZObra();

        #region Fretes
        
        private Dictionary<string, string> MontarParametrosPesquisarFrete(Frete frete)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFrete", frete.idFrete.Equals(0) ? null : frete.idFrete.ToString());
            lstParametros.Add("@NomeFornecedor", string.IsNullOrEmpty(frete.nomeFornecedor) ? null : frete.nomeFornecedor);  
            lstParametros.Add("@Trajeto", string.IsNullOrEmpty(frete.Trajeto) ? null : frete.Trajeto);            
            lstParametros.Add("@UnitTest", frete.UnitTest.Equals(0) ? null : frete.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarFrete(Frete frete)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFrete", frete.idFrete.ToString());
            lstParametros.Add("@NumeroFrete", frete.numeroFrete);
            lstParametros.Add("@idFornecedor", frete.idFornecedor.ToString());
            lstParametros.Add("@Trajeto", frete.Trajeto);
            lstParametros.Add("@PrevisaoPagamento", frete.previsaoPagamento.Date.ToString());
            lstParametros.Add("@ValorTotal", frete.valorTotal.ToString());
            lstParametros.Add("@UnitTest", frete.UnitTest.ToString());

            return lstParametros;
        }

        public List<Frete> PesquisarFrete(Frete frete)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Frete> lstFretes = new List<Frete>();

            try
            {
                lstParametros = MontarParametrosPesquisarFrete(frete);

                using (DataSet ds = dao.Pesquisar("SP_FRETES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Frete itemFrete = new Frete();
                        itemFrete.idFrete = int.Parse(dr["idFrete"].ToString());
                        itemFrete.numeroFrete = dr["NumeroFrete"].ToString();
                        itemFrete.idFornecedor = int.Parse(dr["idFornecedor"].ToString());
                        itemFrete.nomeFornecedor = dr["NomeFornecedor"].ToString();
                        itemFrete.Trajeto = dr["Trajeto"].ToString();                     
                        itemFrete.previsaoPagamento = DateTime.Parse(dr["PrevisaoPagamento"].ToString());
                        itemFrete.valorTotal = decimal.Parse(dr["ValorTotal"].ToString());
                        itemFrete.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        itemFrete.lstPagamentos = this.PesquisarPagamentos(new FretePagamento() { idFrete = itemFrete.idFrete });
                        itemFrete.lstObras = this.PesquisarObras(new FreteObra() { idFrete = itemFrete.idFrete });
                        lstFretes.Add(itemFrete);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstFretes;
        }

        private string ValidarCamposObrigatorios(Frete frete)
        {
            string Msg = string.Empty;

            if (frete.idFornecedor == 0)
                Msg += Environment.NewLine + "Favor selecionar o Fornecedor";

            if (string.IsNullOrEmpty(frete.Trajeto))
                Msg += Environment.NewLine + "Favor informar o Trajeto";

            if (frete.valorTotal == decimal.Zero)
                Msg += Environment.NewLine + "Favor informar o Valor Total";

            if (frete.lstObras != null && frete.lstObras.Count > 0 && frete.valorTotal != frete.lstObras.Sum(x => x.Valor))
                Msg += Environment.NewLine + "O Valor Total do Frete deve ser igual a soma dos valores rateados";

            return Msg;
        }

        public string IncluirFrete(Frete frete, out int idFrete)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosPagamentos = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarCamposObrigatorios(frete);
                idFrete = 0;

                if (Msg == string.Empty)
                {
                    using (DataSet ds = dao.Pesquisar("SP_FRETES_NOVONUMEROFRETE", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        frete.numeroFrete = dr[0].ToString();
                    }

                    lstParametros = MontarParametrosExecutarFrete(frete);

                    using (DataSet ds = dao.Pesquisar("SP_FRETES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idFrete = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(this.IncluirObras(idFrete, frete.lstObras));                    

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarFrete(Frete frete)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> parametroExclusao = new Dictionary<string, string>();            
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(frete);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_FRETES_ALTERAR",
                        lstParametros = MontarParametrosExecutarFrete(frete)
                    });

                    parametroExclusao.Add("@idFrete", frete.idFrete.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_FRETES_OBRAS_EXCLUIR",
                        lstParametros = parametroExclusao
                    });

                    foreach (FreteObra itemObra in frete.lstObras.Where(x => x.Ativo == false).ToList())
                    {
                        if (itemObra.idOP == 0)
                        {
                            parametroExclusao = new Dictionary<string, string>();
                            parametroExclusao.Add("@idObraEtapaGastoRealizado", itemObra.idObraEtapaGastoRealizado.ToString());

                            lstComandos.Add(new _Transacao()
                            {
                                nomeProcedure = "SP_OBRASETAPAS_GASTOSREALIZADOS_EXCLUIR",
                                lstParametros = parametroExclusao
                            });
                        }
                    }

                    lstComandos.AddRange(this.IncluirObras(frete.idFrete, frete.lstObras.Where(x => x.Ativo == true).ToList()));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(Frete frete)
        {
            string Msg = string.Empty;

            if (frete.lstPagamentos.Count > 0)
                Msg += Environment.NewLine + "Existem pagamentos efetuados para esse frete";

            return Msg;
        }

        public void ExcluirFrete(Frete frete)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idFrete", frete.idFrete.ToString());
                dao.Executar("SP_FRETES_EXCLUIR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void ExcluirFreteTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                dao.Executar("SP_FRETES_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public DataTable GerarRelatorio(string filtro, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtFrete = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_FRETES_RELATORIO", lstParametros);
                dtFrete = ds.Tables[0];

                dtFrete = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtFrete);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_RELATORIO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtFrete;
        }

        #endregion

        #region Pagamentos
        
        private Dictionary<string, string> MontarParametrosPesquisarPagamentos(FretePagamento fretePagamento)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFrete", fretePagamento.idFrete.Equals(0) ? null : fretePagamento.idFrete.ToString());
            lstParametros.Add("@UnitTest", fretePagamento.UnitTest.Equals(0) ? null : fretePagamento.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarPagamento(FretePagamento fretePagamento)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFrete", fretePagamento.idFrete.ToString());
            lstParametros.Add("@idOP", fretePagamento.idOP.ToString());            
            lstParametros.Add("@UnitTest", fretePagamento.UnitTest.ToString());

            return lstParametros;
        }

        public List<FretePagamento> PesquisarPagamentos(FretePagamento fretePagamento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<FretePagamento> lstPagamentos = new List<FretePagamento>();

            try
            {
                lstParametros = MontarParametrosPesquisarPagamentos(fretePagamento);

                using (DataSet ds = dao.Pesquisar("SP_FRETES_PAGAMENTOS_PESQUISAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FretePagamento pagamentoItem = new FretePagamento();
                        pagamentoItem.idFrete = int.Parse(dr["idFrete"].ToString());
                        pagamentoItem.idOP = int.Parse(dr["idOrdemPagamento"].ToString());
                        pagamentoItem.numeroOP = dr["NumeroOP"].ToString();
                        pagamentoItem.statusOP = dr["Status"].ToString();
                        pagamentoItem.valorOP = decimal.Parse(dr["ValorOP"].ToString());
                        lstPagamentos.Add(pagamentoItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_PAGAMENTOS_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstPagamentos;
        }

        public void IncluirPagamento(FretePagamento fretePagamento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros = MontarParametrosExecutarPagamento(fretePagamento);
                dao.Executar("SP_FRETES_PAGAMENTOS_INCLUIR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_PAGAMENTOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }        
        }

        #endregion
        
        #region Obras

        private Dictionary<string, string> MontarParametrosPesquisarObras(FreteObra freteObra)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFrete", freteObra.idFrete.Equals(0) ? null : freteObra.idFrete.ToString());          

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarObra(FreteObra freteObra)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();            
            lstParametros.Add("@idFrete", freteObra.idFrete.ToString());            
            lstParametros.Add("@idObraEtapa", freteObra.idObraEtapa.ToString());
            lstParametros.Add("@idObraEtapaGastoRealizado", freteObra.idObraEtapaGastoRealizado.ToString());
            lstParametros.Add("@Data", freteObra.Data.Date.ToString());            
            lstParametros.Add("@idUEN", freteObra.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", freteObra.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", freteObra.idDespesa.ToString());
            lstParametros.Add("@Valor", freteObra.Valor.ToString());         

            return lstParametros;
        }

        public List<FreteObra> PesquisarObras(FreteObra freteObra)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<FreteObra> lstObras = new List<FreteObra>();

            try
            {
                lstParametros = MontarParametrosPesquisarObras(freteObra);

                using (DataSet ds = dao.Pesquisar("SP_FRETES_OBRAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FreteObra obraItem = new FreteObra();
                        obraItem.idFreteObra = int.Parse(dr["idFreteObra"].ToString());                     
                        obraItem.idFrete = int.Parse(dr["idFrete"].ToString());                     
                        obraItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        obraItem.descricaoObra = dr["DescricaoObra"].ToString();
                        obraItem.idObraEtapaGastoRealizado = int.Parse(dr["idObraEtapaGastoRealizado"].ToString());
                        obraItem.idOP = string.IsNullOrEmpty(dr["idOrdemPagamento"].ToString()) ? 0 : int.Parse(dr["idOrdemPagamento"].ToString());
                        obraItem.Data = DateTime.Parse(dr["Data"].ToString());
                        obraItem.idUEN = int.Parse(dr["idUEN"].ToString());
                        obraItem.descricaoUEN = dr["DescricaoUEN"].ToString();
                        obraItem.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        obraItem.descricaoCentroCusto = dr["DescricaoCentroCusto"].ToString();
                        obraItem.idDespesa = int.Parse(dr["idDespesa"].ToString());
                        obraItem.descricaoDespesa = dr["DescricaoDespesa"].ToString();
                        obraItem.Valor = decimal.Parse(dr["Valor"].ToString());
                        obraItem.Ativo = true;
                        lstObras.Add(obraItem);                      
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FRETES_PAGAMENTOS_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObras;
        }

        public string ValidarAdicionarObra(FreteObra freteObra, Frete freteSelecionado)
        {
            string Msg = string.Empty;

            if (freteObra.idObraEtapa == 0)
                Msg += Environment.NewLine + "Favor selecionar a Obra";

            if (freteSelecionado.lstObras.Exists(x => x.idObraEtapa == freteObra.idObraEtapa))
                Msg += Environment.NewLine + "Esta Obra já foi adicionada";

            if (freteObra.idUEN == 0)
                Msg += Environment.NewLine + "Favor selecionar a UEN";

            if (freteObra.idCentroCusto == 0)
                Msg += Environment.NewLine + "Favor selecionar o Centro de Custo";

            if (freteObra.idDespesa == 0)
                Msg += Environment.NewLine + "Favor selecionar a Despesa";

            if (freteObra.Valor == decimal.Zero)
                Msg += Environment.NewLine + "Favor informar o Valor do Frete";

            if((freteSelecionado.lstObras.Where(x => x.Ativo == true).Sum(y => y.Valor) + freteObra.Valor > freteSelecionado.valorTotal))
                Msg += Environment.NewLine + "A soma dos rateios ultrapassa o Valor Total do Frete";

            return Msg;
        }

        public string ValidarExcluirObra(FreteObra freteObra)
        {
            BIZObra bizObra = new BIZObra();
            ObraEtapaGastoRealizado gastoRealizado = new ObraEtapaGastoRealizado();
            string Msg = string.Empty;            
           
            if(freteObra.idObraEtapaGastoRealizado > 0)
            {
                gastoRealizado = bizObra.PesquisarGastosRealizados(new ObraEtapaGastoRealizado() { idObraEtapaGastoRealizado = freteObra.idObraEtapaGastoRealizado }).FirstOrDefault();

                if (gastoRealizado != null)
                {
                    if (gastoRealizado.idOrdemPagamento > 0)
                        Msg = "Não é possível remover essa Obra, pois já foi gerada uma OP para essa despesa";
                }
            }
           
            return Msg;
        }

        private List<_Transacao> IncluirObras(int idFrete, List<FreteObra> lstObras)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            ObraEtapaGastoRealizado gastoRealizado = new ObraEtapaGastoRealizado();
            int idGastoRealizado = 0;

            foreach (FreteObra itemObra in lstObras)
            {
                if (itemObra.idOP == 0)
                {
                    gastoRealizado = new ObraEtapaGastoRealizado()
                    {
                        idObraEtapa = itemObra.idObraEtapa,
                        idUEN = itemObra.idUEN,
                        idCentroCusto = itemObra.idCentroCusto,
                        idDespesa = itemObra.idDespesa,
                        Data = itemObra.Data,
                        Valor = itemObra.Valor,
                        Observacao = "* Lançamento automático frete *"
                    };

                    bizObra.IncluirGastoRealizado(gastoRealizado, out idGastoRealizado);
                    itemObra.idObraEtapaGastoRealizado = idGastoRealizado;
                }

                itemObra.idFrete = idFrete;

                lstParametros = MontarParametrosExecutarObra(itemObra);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_FRETES_OBRAS_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }        

        #endregion
    }
}