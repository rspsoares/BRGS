using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BRGS.Entity;
using System.Data;
using BRGS.Util;
using BRGS.Entities;

namespace BRGS.BIZ
{
    public class BIZNFServico
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();        

        private Dictionary<string, string> MontarParametrosExecutarNFS(NFServico nfServico)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idNota", nfServico.idNota.ToString());             
            lstParametros.Add("@NumeroNota", nfServico.numeroNota.ToString());             
            lstParametros.Add("@idEmpresa", nfServico.idEmpresa.ToString());             
            lstParametros.Add("@DataEmissao", nfServico.dataEmissao.Date.ToString());
            lstParametros.Add("@ValorNota", nfServico.valorNota.ToString());            
            lstParametros.Add("@idCliente", nfServico.idCliente.ToString());            
            lstParametros.Add("@DescricaoServico", nfServico.descricaoServico);            
            lstParametros.Add("@NumeroProcesso", nfServico.numeroProcesso);
            lstParametros.Add("@Empenho", nfServico.Empenho);
            lstParametros.Add("@PagamentoEfetuado", nfServico.pagamentoEfetuado.ToString());
            lstParametros.Add("@DataPagamento", nfServico.dataPagamento.Date.Equals(DateTime.MinValue) ? "1/1/1753" : nfServico.dataPagamento.Date.ToString());            
            lstParametros.Add("@ValorPago", nfServico.valorPago.ToString());
            lstParametros.Add("@PossuiDataAtes", nfServico.possuiDataAtes.ToString());
            lstParametros.Add("@DataAtes", nfServico.dataAtes.Date.Equals(DateTime.MinValue) ? "1/1/1753" : nfServico.dataAtes.Date.ToString());            
            lstParametros.Add("@PossuiDataCAT", nfServico.possuiDataCAT.ToString());
            lstParametros.Add("@DataCAT", nfServico.dataCAT.Date.Equals(DateTime.MinValue) ? "1/1/1753" : nfServico.dataCAT.Date.ToString());
            lstParametros.Add("@Cancelado", nfServico.Cancelado.ToString());
            lstParametros.Add("@ObservacaoCancelado", nfServico.observacaoCancelado.ToString());
            lstParametros.Add("@IRPJ", nfServico.IRPJ.ToString());
            lstParametros.Add("@CSLL", nfServico.CSLL.ToString());
            lstParametros.Add("@INSS", nfServico.INSS.ToString());
            lstParametros.Add("@PIS", nfServico.PIS.ToString());
            lstParametros.Add("@COFINS", nfServico.COFINS.ToString());
            lstParametros.Add("@ISSQN", nfServico.ISSQN.ToString());
            lstParametros.Add("@UnitTest",nfServico.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarNFSItens(NFServicoItem nfServicoItens)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idNota", nfServicoItens.idNota.ToString());
            lstParametros.Add("@Quantidade", nfServicoItens.Quantidade.ToString());
            lstParametros.Add("@Unidade", nfServicoItens.Unidade.ToString());
            lstParametros.Add("@Descricao", nfServicoItens.Descricao.ToString());
            lstParametros.Add("@PrecoUnitario", nfServicoItens.precoUnitario.ToString());
            lstParametros.Add("@UnitTest", nfServicoItens.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarNFServico(NFServico nfServico)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idNota", nfServico.idNota.Equals(0) ? null : nfServico.idNota.ToString());
            lstParametros.Add("@NumeroNota", nfServico.numeroNota.Equals(0) ? null : nfServico.numeroNota.ToString());
            lstParametros.Add("@idEmpresa", nfServico.idEmpresa.Equals(0) ? null : nfServico.idEmpresa.ToString());            
            lstParametros.Add("@CNPJ", string.IsNullOrEmpty(nfServico.CNPJ) ? null : nfServico.CNPJ);
            lstParametros.Add("@DataEmissao", nfServico.dataEmissao.Equals(DateTime.MinValue) ? null : nfServico.dataEmissao.Date.ToString());
            lstParametros.Add("@NomeCliente", string.IsNullOrEmpty(nfServico.Nome) ? null : nfServico.Nome);
            lstParametros.Add("@Empenho", string.IsNullOrEmpty(nfServico.Empenho) ? null : nfServico.Empenho);
            lstParametros.Add("@UnitTest", nfServico.UnitTest.Equals(0) ? null : nfServico.UnitTest.ToString());

            return lstParametros;
        }

        private string ValidarCamposObrigatorios(NFServico nfServico, bool inclusao)
        {
            string Msg = string.Empty;

            if (nfServico.numeroNota == 0)
                Msg += Environment.NewLine + "Favor informar o Número da Nota Fiscal";

            if (nfServico.idEmpresa < 1)            
                Msg += Environment.NewLine + "Empresa emissora da Nota Fiscal não selecionada";
            
            if (nfServico.idCliente == 0)
                Msg += Environment.NewLine + "Favor selecionar o Cliente";
            
            if (nfServico.descricaoServico == string.Empty)
                Msg += Environment.NewLine + "Descrição do Evento / Serviço não preenchido";

            if (nfServico.CNPJ != null && nfServico.CNPJ != string.Empty && !helper.ValidarCPF(nfServico.CNPJ) && !helper.ValidarCNPJ(nfServico.CNPJ))
                Msg += Environment.NewLine + "CPF / CNPJ do Cliente inválido";

            if (nfServico.lstItens != null && nfServico.lstItens.Count == 0)
                Msg += Environment.NewLine + "Nenhum item foi adicionado na Nota Fiscal";

            if (nfServico.pagamentoEfetuado == 1 && nfServico.valorPago == decimal.Zero)
                Msg += Environment.NewLine + "Valor Pago não informado";

            if(nfServico.Cancelado == 1 && nfServico.observacaoCancelado == string.Empty)
                Msg += Environment.NewLine + "Favor informar o motivo do cancelamento desta Nota Fiscal";

            if(inclusao && nfServico.UnitTest == 0 && this.VerificarNumeroNFDuplicado(nfServico))
                Msg += Environment.NewLine + "O número de Nota Fiscal de Serviço " + nfServico.numeroNota + " já foi utilizado para essa empresa";

            return Msg;
        }

        private bool VerificarNumeroNFDuplicado(NFServico nfServico)
        {            
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();  
            bool existeNF = true;
         
            try
            {
                lstParametros.Add("@NumeroNota", nfServico.numeroNota.ToString());
                lstParametros.Add("@IdEmpresa", nfServico.idEmpresa.ToString());
                
                using (DataSet ds = dao.Pesquisar("SP_NFSERVICOS_VERIFICARDUPLICIDADE", lstParametros))
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
                    procedureSQL = "SP_NFSERVICOS_VERIFICARDUPLICIDADE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return existeNF;
        }

        public List<NFServico> PesquisarNFServico(NFServico nfServico)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();
            List<NFServico> lstNFS = new List<NFServico>();
            List<NFServicoItem> lstNFSItens = new List<NFServicoItem>(); 

            try
            {
                lstParametros = MontarParametrosPesquisarNFServico(nfServico);

                using (DataSet ds = dao.Pesquisar("SP_NFSERVICOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        NFServico nfs = new NFServico();
                        nfs.idNota = int.Parse(dr["idNota"].ToString());
                        nfs.numeroNota = int.Parse(dr["NumeroNota"].ToString());
                        nfs.idEmpresa = int.Parse(dr["idEmpresa"].ToString());
                        nfs.nomeEmpresa = dr["RazaoSocial"].ToString();
                        nfs.dataEmissao = DateTime.Parse(dr["DataEmissao"].ToString());
                        nfs.valorNota = decimal.Parse(dr["ValorNota"].ToString());
                        nfs.idCliente = int.Parse(dr["idCliente"].ToString());
                        nfs.Nome = dr["NomeCliente"].ToString();                       
                        nfs.descricaoServico = dr["DescricaoServico"].ToString();
                        nfs.numeroProcesso = dr["NumeroProcesso"].ToString();
                        nfs.Empenho = dr["Empenho"].ToString();
                        nfs.pagamentoEfetuado = int.Parse(dr["PagamentoEfetuado"].ToString());
                        nfs.dataPagamento = DateTime.Parse(dr["DataPagamento"].ToString());
                        nfs.valorPago = decimal.Parse(dr["ValorPago"].ToString());
                        nfs.possuiDataAtes = int.Parse(dr["PossuiDataAtes"].ToString());
                        nfs.dataAtes = DateTime.Parse(dr["DataAtes"].ToString());
                        nfs.possuiDataCAT = int.Parse(dr["PossuiDataCAT"].ToString());
                        nfs.dataCAT = DateTime.Parse(dr["DataCAT"].ToString());
                        nfs.Cancelado = int.Parse(dr["Cancelado"].ToString());
                        nfs.observacaoCancelado = dr["ObservacaoCancelado"].ToString();
                        nfs.IRPJ = decimal.Parse(dr["IRPJ"].ToString());
                        nfs.CSLL = decimal.Parse(dr["CSLL"].ToString());
                        nfs.INSS = decimal.Parse(dr["INSS"].ToString());
                        nfs.PIS = decimal.Parse(dr["PIS"].ToString());
                        nfs.COFINS = decimal.Parse(dr["COFINS"].ToString());
                        nfs.ISSQN = decimal.Parse(dr["ISSQN"].ToString()); 

                        lstParametrosItens = new Dictionary<string, string>();
                        lstParametrosItens.Add("@idNota",nfs.idNota.ToString());                         

                        using (DataSet dsItens = dao.Pesquisar("SP_NFSERVICOSITENS_CONSULTAR", lstParametrosItens))
                        {
                            lstNFSItens = new List<NFServicoItem>();
                            foreach (DataRow drItens in dsItens.Tables[0].Rows)
                            {
                                NFServicoItem nfsItem = new NFServicoItem();
                                nfsItem.idNota = int.Parse(drItens["idNota"].ToString());
                                nfsItem.Unidade = drItens["Unidade"].ToString();
                                nfsItem.Quantidade = int.Parse(drItens["Quantidade"].ToString()); 
                                nfsItem.Descricao = drItens["Descricao"].ToString();
                                nfsItem.precoUnitario = decimal.Parse(drItens["PrecoUnitario"].ToString());
                                nfsItem.UnitTest = int.Parse(drItens["UnitTest"].ToString()); 

                                lstNFSItens.Add(nfsItem);
                            }
                        }

                        nfs.lstItens = lstNFSItens;
                        lstNFS.Add(nfs);
                    }
                }
            }           
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NFSERVICOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstNFS;
        }

        public string IncluirNFServico(NFServico nfServico, out int idNota)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            string Msg = string.Empty;
            
            try
            {
                Msg = ValidarCamposObrigatorios(nfServico,true);
                idNota = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarNFS(nfServico);
                    using (DataSet ds = dao.Pesquisar("SP_NFSERVICOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idNota = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(IncluirItensNFServico(idNota, nfServico.lstItens));                   

                    dao.ExecutarTransacao(lstComandos);
                }                
            }            
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NFSERVICOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        private List<_Transacao> IncluirItensNFServico(int idNota, List<NFServicoItem> lstItens)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();

            foreach (NFServicoItem nfServicoItens in lstItens)
            {
                nfServicoItens.idNota = idNota;
                lstParametrosItens = MontarParametrosExecutarNFSItens(nfServicoItens);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_NFSERVICOSITENS_INCLUIR",
                    lstParametros = lstParametrosItens
                });
            }

            return lstComandos;
        }

        public string AlterarNFServico(NFServico nfServico)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosItens = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(nfServico,false);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_NFSERVICOS_ALTERAR",
                        lstParametros =  MontarParametrosExecutarNFS(nfServico)
                    });    

                    lstParametrosItens.Add("@idNota", nfServico.idNota.ToString());
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_NFSERVICOSITENS_EXCLUIR",
                        lstParametros = lstParametrosItens
                    });

                    lstComandos.AddRange(IncluirItensNFServico(nfServico.idNota, nfServico.lstItens));

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

        public void ExcluirNFServicoTestes()
        {
            DataAccess dao = new DataAccess();

            try
            {
                dao.Executar("SP_NFSERVICOS_EXCLUIR", new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NFSERVICOS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }            
        }

        public DataTable GerarRelatorioNFSEmitidas(string filtro)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtNFS = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_NFSERVICOS_RELATORIO_EMITIDAS", lstParametros);
                dtNFS = ds.Tables[0];
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NFSERVICOS_RELATORIO_EMITIDAS",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtNFS;
        }

        public DataTable GerarNFS(int numeroNota)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();          
            DataTable dtNFS = new DataTable();
            
            try
            {
                lstParametros.Add("@idNota",numeroNota.ToString());
                DataSet ds = dao.Pesquisar("SP_NFSERVICOS_GERAR", lstParametros);
                dtNFS = ds.Tables[0];
            }           
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_NFSERVICOS_GERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtNFS;
        }
    }
}
