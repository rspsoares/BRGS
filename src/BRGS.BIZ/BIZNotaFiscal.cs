using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BRGS.Entity;
using System.Data;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZNotaFiscal
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();        

        private Dictionary<string, string> MontarParametrosExecutarNotaFiscal(NotaFiscal notaFiscal)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idNota", notaFiscal.idNota.ToString());
            lstParametros.Add("@TipoNota", notaFiscal.tipoNota.ToString());                        
            lstParametros.Add("@NumeroNota", notaFiscal.numeroNota.ToString());
            lstParametros.Add("@CodigoVerificacao", notaFiscal.codigoVerificacao);
            lstParametros.Add("@TipoOperacao", notaFiscal.tipoOperacao.ToString());
            lstParametros.Add("@Contrato", notaFiscal.Contrato.ToString());   
            lstParametros.Add("@idEmpresa", notaFiscal.idEmpresa.ToString());
            lstParametros.Add("@idContaBancariaEmpresa", notaFiscal.idContaBancariaEmpresa.ToString());
            lstParametros.Add("@idPrazoPagamento", notaFiscal.idPrazoPagamento.ToString());    
            lstParametros.Add("@DataEmissao", notaFiscal.dataEmissao.Date.ToString());
            lstParametros.Add("@ValorNota", notaFiscal.valorNota.ToString());
            lstParametros.Add("@idObraEtapa", notaFiscal.idObraEtapa.ToString());      
            lstParametros.Add("@idCliente", notaFiscal.idCliente.ToString());            
            lstParametros.Add("@DescricaoServico", notaFiscal.descricaoServico);            
            lstParametros.Add("@NumeroProcesso", notaFiscal.numeroProcesso);
            lstParametros.Add("@Empenho", notaFiscal.Empenho);
            lstParametros.Add("@PagamentoEfetuado", notaFiscal.pagamentoEfetuado.ToString());
            lstParametros.Add("@DataPagamento", notaFiscal.dataPagamento.Date.Equals(DateTime.MinValue) ? "1/1/1753" : notaFiscal.dataPagamento.Date.ToString());            
            lstParametros.Add("@ValorPago", notaFiscal.valorPago.ToString());
            lstParametros.Add("@PossuiDataAtes", notaFiscal.possuiDataAtes.ToString());
            lstParametros.Add("@DataAtes", notaFiscal.dataAtes.Date.Equals(DateTime.MinValue) ? "1/1/1753" : notaFiscal.dataAtes.Date.ToString());            
            lstParametros.Add("@PossuiDataCAT", notaFiscal.possuiDataCAT.ToString());
            lstParametros.Add("@DataCAT", notaFiscal.dataCAT.Date.Equals(DateTime.MinValue) ? "1/1/1753" : notaFiscal.dataCAT.Date.ToString());
            lstParametros.Add("@Cancelado", notaFiscal.Cancelado.ToString());
            lstParametros.Add("@ObservacaoCancelado", notaFiscal.observacaoCancelado.ToString());
            lstParametros.Add("@IRPJ", notaFiscal.IRPJ.ToString());
            lstParametros.Add("@CSLL", notaFiscal.CSLL.ToString());
            lstParametros.Add("@INSS", notaFiscal.INSS.ToString());
            lstParametros.Add("@PIS", notaFiscal.PIS.ToString());
            lstParametros.Add("@COFINS", notaFiscal.COFINS.ToString());
            lstParametros.Add("@ISSQN", notaFiscal.ISSQN.ToString());
            lstParametros.Add("@UnitTest",notaFiscal.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarNotaFiscalItens(NotaFiscalItem nfItens)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idNota", nfItens.idNota.ToString());
            lstParametros.Add("@Quantidade", nfItens.Quantidade.ToString());
            lstParametros.Add("@Unidade", nfItens.Unidade.ToString());
            lstParametros.Add("@Descricao", nfItens.Descricao.ToString());
            lstParametros.Add("@PrecoUnitario", nfItens.precoUnitario.ToString());
            lstParametros.Add("@UnitTest", nfItens.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarNotaFiscal(NotaFiscal notaFiscal)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idNota", notaFiscal.idNota.Equals(0) ? null : notaFiscal.idNota.ToString());
            lstParametros.Add("@NumeroNota", notaFiscal.numeroNota.Equals(0) ? null : notaFiscal.numeroNota.ToString());
            lstParametros.Add("@idEmpresa", notaFiscal.idEmpresa.Equals(0) ? null : notaFiscal.idEmpresa.ToString());
            lstParametros.Add("@idObraEtapa", notaFiscal.idObraEtapa.Equals(0) ? null : notaFiscal.idObraEtapa.ToString());            
            lstParametros.Add("@CNPJ", string.IsNullOrEmpty(notaFiscal.CNPJ) ? null : notaFiscal.CNPJ);
            lstParametros.Add("@DataEmissao", notaFiscal.dataEmissao.Equals(DateTime.MinValue) ? null : notaFiscal.dataEmissao.Date.ToString());
            lstParametros.Add("@idCliente", notaFiscal.idCliente.Equals(0) ? null : notaFiscal.idCliente.ToString());            
            lstParametros.Add("@NomeCliente", string.IsNullOrEmpty(notaFiscal.Nome) ? null : notaFiscal.Nome);
            lstParametros.Add("@Empenho", string.IsNullOrEmpty(notaFiscal.Empenho) ? null : notaFiscal.Empenho);
            lstParametros.Add("@UnitTest", notaFiscal.UnitTest.Equals(0) ? null : notaFiscal.UnitTest.ToString());

            return lstParametros;
        }

        private string ValidarCamposObrigatorios(NotaFiscal notaFiscal, bool inclusao)
        {
            string Msg = string.Empty;

            if (notaFiscal.numeroNota == 0) // Nota Fiscal Provisória
            {
                if (notaFiscal.idEmpresa < 1)
                    Msg += Environment.NewLine + "Empresa emissora da Nota Fiscal não selecionada";
            }
            else
            {
                if (notaFiscal.tipoNota == 2) // Nota de Serviço
                {
                    if (notaFiscal.codigoVerificacao == string.Empty)
                        Msg += Environment.NewLine + "Falor informar o Código de Verificação";

                    if (notaFiscal.valorNota == decimal.Zero)
                        Msg += Environment.NewLine + "Falor informar o Valor da Nota Fiscal";
                }
                else if (notaFiscal.tipoNota == 3) // Nota de Venda 
                {
                    if (notaFiscal.valorNota == decimal.Zero)
                        Msg += Environment.NewLine + "Falor informar o Valor da Nota Fiscal";

                    if (notaFiscal.tipoOperacao == 0)
                        Msg += Environment.NewLine + "Falor informar o Tipo de Operação";
                }
                else if (notaFiscal.tipoNota == 0)
                    Msg += Environment.NewLine + "Falor selecionar o Tipo de Nota Fiscal";

                if (notaFiscal.numeroNota == 0)
                    Msg += Environment.NewLine + "Favor informar o Número da Nota Fiscal";

                if (notaFiscal.idEmpresa < 1)
                    Msg += Environment.NewLine + "Empresa emissora da Nota Fiscal não selecionada";

                if (notaFiscal.idCliente == 0)
                    Msg += Environment.NewLine + "Favor selecionar o Cliente";

                if (notaFiscal.descricaoServico == string.Empty)
                    Msg += Environment.NewLine + "Descrição do Evento / Serviço não preenchido";

                if (notaFiscal.CNPJ != null && notaFiscal.CNPJ != string.Empty && !helper.ValidarCPF(notaFiscal.CNPJ) && !helper.ValidarCNPJ(notaFiscal.CNPJ))
                    Msg += Environment.NewLine + "CPF / CNPJ do Cliente inválido";

                if (notaFiscal.tipoNota == 1 && notaFiscal.lstItens != null && notaFiscal.lstItens.Count == 0)
                    Msg += Environment.NewLine + "Nenhum item foi adicionado na Nota Fiscal";

                if (notaFiscal.pagamentoEfetuado == 1 && notaFiscal.valorPago == decimal.Zero)
                    Msg += Environment.NewLine + "Valor Pago não informado";

                if (notaFiscal.Cancelado == 1 && notaFiscal.observacaoCancelado == string.Empty)
                    Msg += Environment.NewLine + "Favor informar o motivo do cancelamento desta Nota Fiscal";

                if (inclusao && notaFiscal.UnitTest == 0 && this.VerificarNumeroNFDuplicado(notaFiscal))
                    Msg += Environment.NewLine + "O número desta Nota Fiscal " + notaFiscal.numeroNota + " já foi utilizado para essa empresa";
            }

            if (notaFiscal.idPrazoPagamento == 0)
                Msg += Environment.NewLine + "Favor selecionar o Prazo de Pagamento";

            return Msg;
        }

        private bool VerificarNumeroNFDuplicado(NotaFiscal notaFiscal)
        {            
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();  
            bool existeNF = true;
         
            try
            {
                lstParametros.Add("@NumeroNota", notaFiscal.numeroNota.ToString());
                lstParametros.Add("@IdEmpresa", notaFiscal.idEmpresa.ToString());
                lstParametros.Add("@TipoNota", notaFiscal.tipoNota.ToString());
                
                using (DataSet ds = dao.Pesquisar("SP_NOTASFISCAIS_VERIFICARDUPLICIDADE", lstParametros))
                {
                    existeNF = ds.Tables[0].Rows.Count > 0;                
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

            return existeNF;
        }

        public List<NotaFiscal> PesquisarNotaFiscal(NotaFiscal notaFiscal)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();
            List<NotaFiscal> lstNF = new List<NotaFiscal>();
            List<NotaFiscalItem> lstNFItens = new List<NotaFiscalItem>(); 

            try
            {
                lstParametros = MontarParametrosPesquisarNotaFiscal(notaFiscal);

                using (DataSet ds = dao.Pesquisar("SP_NOTASFISCAIS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        NotaFiscal nf = new NotaFiscal();
                        nf.idNota = int.Parse(dr["idNota"].ToString());
                        nf.tipoNota = int.Parse(dr["TipoNota"].ToString());
                        nf.descTipoNota = dr["DescricaoTipoNota"].ToString();
                        nf.numeroNota = int.Parse(dr["NumeroNota"].ToString());
                        nf.codigoVerificacao = dr["CodigoVerificacao"].ToString();
                        nf.tipoOperacao = int.Parse(dr["TipoOperacao"].ToString());
                        nf.Contrato = dr["Contrato"].ToString();
                        nf.idEmpresa = int.Parse(dr["idEmpresa"].ToString());
                        nf.idContaBancariaEmpresa = int.Parse(dr["idContaBancariaEmpresa"].ToString());
                        nf.nomeEmpresa = dr["RazaoSocial"].ToString();                        
                        nf.dataEmissao = DateTime.Parse(dr["DataEmissao"].ToString());
                        nf.valorNota = decimal.Parse(dr["ValorNota"].ToString());
                        nf.idPrazoPagamento = int.Parse(dr["idPrazoPagamento"].ToString());
                        nf.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        nf.nomeEvento = dr["NomeEvento"].ToString();
                        nf.numeroLicitacao = dr["NumeroLicitacao"].ToString();
                        nf.idCliente = int.Parse(dr["idCliente"].ToString());                        
                        nf.Nome = dr["NomeCliente"].ToString();                       
                        nf.descricaoServico = dr["DescricaoServico"].ToString();
                        nf.numeroProcesso = dr["NumeroProcesso"].ToString();
                        nf.Empenho = dr["Empenho"].ToString();
                        nf.pagamentoEfetuado = int.Parse(dr["PagamentoEfetuado"].ToString());
                        nf.dataPagamento = DateTime.Parse(dr["DataPagamento"].ToString());
                        nf.valorPago = decimal.Parse(dr["ValorPago"].ToString());
                        nf.possuiDataAtes = int.Parse(dr["PossuiDataAtes"].ToString());
                        nf.dataAtes = DateTime.Parse(dr["DataAtes"].ToString());
                        nf.possuiDataCAT = int.Parse(dr["PossuiDataCAT"].ToString());
                        nf.dataCAT = DateTime.Parse(dr["DataCAT"].ToString());
                        nf.Cancelado = int.Parse(dr["Cancelado"].ToString());
                        nf.observacaoCancelado = dr["ObservacaoCancelado"].ToString();
                        nf.IRPJ = decimal.Parse(dr["IRPJ"].ToString());
                        nf.CSLL = decimal.Parse(dr["CSLL"].ToString());
                        nf.INSS = decimal.Parse(dr["INSS"].ToString());
                        nf.PIS = decimal.Parse(dr["PIS"].ToString());
                        nf.COFINS = decimal.Parse(dr["COFINS"].ToString());
                        nf.ISSQN = decimal.Parse(dr["ISSQN"].ToString()); 

                        lstParametrosItens = new Dictionary<string, string>();
                        lstParametrosItens.Add("@idNota",nf.idNota.ToString());                         

                        using (DataSet dsItens = dao.Pesquisar("SP_NOTASFISCAISITENS_CONSULTAR", lstParametrosItens))
                        {
                            lstNFItens = new List<NotaFiscalItem>();
                            foreach (DataRow drItens in dsItens.Tables[0].Rows)
                            {
                                NotaFiscalItem nfsItem = new NotaFiscalItem();
                                nfsItem.idNota = int.Parse(drItens["idNota"].ToString());
                                nfsItem.Unidade = drItens["Unidade"].ToString();
                                nfsItem.Quantidade = int.Parse(drItens["Quantidade"].ToString()); 
                                nfsItem.Descricao = drItens["Descricao"].ToString();
                                nfsItem.precoUnitario = decimal.Parse(drItens["PrecoUnitario"].ToString());
                                nfsItem.UnitTest = int.Parse(drItens["UnitTest"].ToString()); 

                                lstNFItens.Add(nfsItem);
                            }
                        }

                        nf.lstItens = lstNFItens;
                        lstNF.Add(nf);
                    }
                }
            }           
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAIS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstNF;
        }

        public List<NotaFiscalPrazoPagamento> PesqisarPrazoPagamento()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<NotaFiscalPrazoPagamento> lstPrazos = new List<NotaFiscalPrazoPagamento>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_NOTASFISCAISPRAZOPAGAMENTO_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        NotaFiscalPrazoPagamento nfPrazo = new NotaFiscalPrazoPagamento();
                        nfPrazo.idPrazoPagamento = int.Parse(dr["idNotaFiscalPrazo"].ToString());
                        nfPrazo.Descricao = dr["Descricao"].ToString();

                        lstPrazos.Add(nfPrazo);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAISPRAZOPAGAMENTO_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstPrazos;
        }

        public string IncluirNotaFiscal(NotaFiscal notaFiscal, out int idNota)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            string Msg = string.Empty;
            
            try
            {
                Msg = ValidarCamposObrigatorios(notaFiscal,true);
                idNota = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarNotaFiscal(notaFiscal);
                    using (DataSet ds = dao.Pesquisar("SP_NOTASFISCAIS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idNota = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(IncluirItensNotaFiscal(idNota, notaFiscal.lstItens));                   

                    dao.ExecutarTransacao(lstComandos);
                }                
            }            
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAIS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        private List<_Transacao> IncluirItensNotaFiscal(int idNota, List<NotaFiscalItem> lstItens)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();

            foreach (NotaFiscalItem nfServicoItens in lstItens)
            {
                nfServicoItens.idNota = idNota;
                lstParametrosItens = MontarParametrosExecutarNotaFiscalItens(nfServicoItens);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_NOTASFISCAISITENS_INCLUIR",
                    lstParametros = lstParametrosItens
                });
            }

            return lstComandos;
        }

        public string AlterarNotaFiscal(NotaFiscal notaFiscal)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(notaFiscal,false);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_NOTASFISCAIS_ALTERAR",
                        lstParametros =  MontarParametrosExecutarNotaFiscal(notaFiscal)
                    });    

                    lstParametrosItens.Add("@idNota", notaFiscal.idNota.ToString());
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_NOTASFISCAISITENS_EXCLUIR",
                        lstParametros = lstParametrosItens
                    });

                    lstComandos.AddRange(IncluirItensNotaFiscal(notaFiscal.idNota, notaFiscal.lstItens));

                    dao.ExecutarTransacao(lstComandos);
                }
            }           
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NFSERVICOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirNotaFiscalTestes()
        {
            DataAccess dao = new DataAccess();

            try
            {
                dao.Executar("SP_NOTASFISCAIS_EXCLUIR", new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAIS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }            
        }

        public DataTable GerarRelatorioNotasFiscaisEmitidas(string filtro, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtNotaFiscal = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_NOTASFISCAIS_RELATORIO_EMITIDAS", lstParametros);
                dtNotaFiscal = ds.Tables[0];

                dtNotaFiscal = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtNotaFiscal);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAIS_RELATORIO_EMITIDAS",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtNotaFiscal;
        }

        public DataTable GerarNotaFiscal(int numeroNota)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();          
            DataTable dtNotaFiscal = new DataTable();
            
            try
            {
                lstParametros.Add("@idNota",numeroNota.ToString());
                DataSet ds = dao.Pesquisar("SP_NOTASFISCAIS_GERAR", lstParametros);
                dtNotaFiscal = ds.Tables[0];
            }           
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NOTASFISCAIS_GERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtNotaFiscal;
        }
    }
}
