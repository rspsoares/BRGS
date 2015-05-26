using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZObra
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();

        #region Obras

        private Dictionary<string, string> MontarParametrosExecutarObra(Obra obra)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObra", obra.idObra.ToString());
            lstParametros.Add("@idEmpresa", obra.idEmpresa.ToString());
            lstParametros.Add("@idCliente", obra.idCliente.ToString());
            lstParametros.Add("@NumeroLicitacao", obra.numeroLicitacao);
            lstParametros.Add("@NomeEvento", obra.nomeEvento);
            lstParametros.Add("@ValorBruto", obra.valorBruto.ToString());
            // lstParametros.Add("@Finalizada", obra.Finalizada.ToString());    
            lstParametros.Add("@UnitTest", obra.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarObra(Obra obra)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObra", obra.idObra.Equals(0) ? null : obra.idObra.ToString());
            lstParametros.Add("@idEmpresa", obra.idEmpresa.Equals(0) ? null : obra.idEmpresa.ToString());
            lstParametros.Add("@idCliente", obra.idCliente.Equals(0) ? null : obra.idCliente.ToString());
            lstParametros.Add("@NumeroLicitacao", string.IsNullOrEmpty(obra.numeroLicitacao) ? null : obra.numeroLicitacao);
            lstParametros.Add("@NomeCliente", string.IsNullOrEmpty(obra.nomeCliente) ? null : obra.nomeCliente);
            lstParametros.Add("@NomeEvento", string.IsNullOrEmpty(obra.nomeEvento) ? null : obra.nomeEvento);
            lstParametros.Add("@UnitTest", obra.UnitTest.Equals(0) ? null : obra.UnitTest.ToString());

            return lstParametros;
        }

        public List<Obra> PesquisarObra(Obra obra)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosGastos = new Dictionary<string, string>();
            List<Obra> lstObras = new List<Obra>();
            List<ObraEtapa> lstEtapas = new List<ObraEtapa>();

            try
            {
                lstParametros = MontarParametrosPesquisarObra(obra);

                using (DataSet ds = dao.Pesquisar("SP_OBRAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Obra obraItem = new Obra();
                        obraItem.idObra = int.Parse(dr["idObra"].ToString());
                        obraItem.idEmpresa = int.Parse(dr["idEmpresa"].ToString());
                        obraItem.nomeEmpresa = dr["RazaoSocial"].ToString();
                        obraItem.idCliente = int.Parse(dr["idCliente"].ToString());
                        obraItem.numeroLicitacao = dr["NumeroLicitacao"].ToString();
                        obraItem.nomeCliente = dr["Nome"].ToString();
                        obraItem.nomeEvento = dr["NomeEvento"].ToString();
                        obraItem.valorBruto = decimal.Parse(dr["ValorBruto"].ToString());
                        //obraItem.Finalizada = int.Parse(dr["Finalizada"].ToString());
                        obraItem.lstEtapas = this.PesquisarObraEtapa(new ObraEtapa() { idObra = obraItem.idObra, UnitTest = obra.UnitTest });
                        
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
                    procedureSQL = "SP_OBRAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObras;
        }

        private string ValidarCamposObrigatoriosObra(Obra obra)
        {
            string Msg = string.Empty;

            if (obra.idEmpresa == 0)
                Msg += Environment.NewLine + "Favor selecionar a Empresa";

            if (obra.numeroLicitacao == string.Empty)
                Msg += Environment.NewLine + "Favor informar o Número da Licitação";

            if (obra.valorBruto == decimal.Zero)
                Msg += Environment.NewLine + "Favor informar o Valor Bruto";

            if (obra.idCliente == 0)
                Msg += Environment.NewLine + "Favor selecionar o Cliente";

            if (obra.nomeEvento == string.Empty)
                Msg += Environment.NewLine + "Favor informar o Nome do Evento";

            return Msg;
        }

        public string IncluirObra(Obra obra, out int idObra)
        {
            DataAccess dao = new DataAccess();            
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();            
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosObra(obra);
                idObra = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarObra(obra);

                    using (DataSet ds = dao.Pesquisar("SP_OBRAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idObra = int.Parse(dr[0].ToString());
                    }                   
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarObra(Obra obra)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosObra(obra);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarObra(obra);
                    dao.Executar("SP_OBRAS_ALTERAR", lstParametros);                    
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirObraTestes()
        {
            DataAccess dao = new DataAccess();

            try
            {
                dao.Executar("SP_OBRAS_EXCLUIR", new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        #endregion

        #region Obras Etapas

        private Dictionary<string, string> MontarParametrosExecutarObraEtapa(ObraEtapa obraEtapa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", obraEtapa.idObraEtapa.ToString());
            lstParametros.Add("@idObra", obraEtapa.idObra.ToString());
            lstParametros.Add("@idEmpresa", obraEtapa.idEmpresa.ToString());
            lstParametros.Add("@idCliente", obraEtapa.idCliente.ToString());
            lstParametros.Add("@Descricao", obraEtapa.Descricao);
            lstParametros.Add("@NumeroLicitacao", obraEtapa.numeroLicitacao);            
            lstParametros.Add("@NomeEvento", obraEtapa.nomeEvento);
            lstParametros.Add("@ValorContrato", obraEtapa.valorContrato.ToString());
            lstParametros.Add("@DataInicio", obraEtapa.dataInicio.Date.ToString());
            lstParametros.Add("@DataTermino", obraEtapa.dataTermino.Date.ToString());
            lstParametros.Add("@Finalizada", obraEtapa.Finalizada.ToString());    
            lstParametros.Add("@UnitTest", obraEtapa.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarObraEtapa(ObraEtapa obraEtapa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", obraEtapa.idObraEtapa.Equals(0) ? null : obraEtapa.idObraEtapa.ToString());
            lstParametros.Add("@idObra", obraEtapa.idObra.Equals(0) ? null : obraEtapa.idObra.ToString());
            lstParametros.Add("@idEmpresa", obraEtapa.idEmpresa.Equals(0) ? null : obraEtapa.idEmpresa.ToString());
            lstParametros.Add("@idCliente", obraEtapa.idCliente.Equals(0) ? null : obraEtapa.idCliente.ToString());
            lstParametros.Add("@NumeroLicitacao", string.IsNullOrEmpty(obraEtapa.numeroLicitacao) ? null : obraEtapa.numeroLicitacao);
            lstParametros.Add("@NomeCliente", string.IsNullOrEmpty(obraEtapa.nomeCliente) ? null : obraEtapa.nomeCliente);
            lstParametros.Add("@NomeEvento", string.IsNullOrEmpty(obraEtapa.nomeEvento) ? null : obraEtapa.nomeEvento);            
            lstParametros.Add("@UnitTest", obraEtapa.UnitTest.Equals(0) ? null : obraEtapa.UnitTest.ToString());

            return lstParametros;
        }

        public List<ObraEtapa> PesquisarObraEtapa(ObraEtapa obraEtapa)
        {
            BIZNotaFiscal bizNF = new BIZNotaFiscal();
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosGastos = new Dictionary<string, string>();
            List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();
            List<ObraEtapaGastoPrevisto> lstPrevistos = new List<ObraEtapaGastoPrevisto>();
            List<ObraEtapaGastoRealizado> lstRealizados = new List<ObraEtapaGastoRealizado>();

            try
            {
                lstParametros = MontarParametrosPesquisarObraEtapa(obraEtapa);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapa obraEtapaItem = new ObraEtapa();
                        obraEtapaItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        obraEtapaItem.idObra = int.Parse(dr["idObra"].ToString());
                        obraEtapaItem.idEmpresa = int.Parse(dr["idEmpresa"].ToString());
                        obraEtapaItem.nomeEmpresa = dr["RazaoSocial"].ToString();
                        obraEtapaItem.idCliente = int.Parse(dr["idCliente"].ToString());
                        obraEtapaItem.Descricao = dr["Descricao"].ToString();
                        obraEtapaItem.numeroLicitacao = dr["NumeroLicitacao"].ToString();
                        obraEtapaItem.nomeCliente = dr["Nome"].ToString();
                        obraEtapaItem.nomeEvento = dr["NomeEvento"].ToString();
                        obraEtapaItem.valorContrato = decimal.Parse(dr["ValorContrato"].ToString());
                        obraEtapaItem.dataInicio = DateTime.Parse(dr["DataInicio"].ToString());
                        obraEtapaItem.dataTermino = DateTime.Parse(dr["DataTermino"].ToString());
                        obraEtapaItem.Finalizada = int.Parse(dr["Finalizada"].ToString());
                        obraEtapaItem.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        //obraEtapaItem.lstPlanejamentos = this.PesquisarPlanejamento(new ObraEtapaPlanejamento() { idObraEtapa = obraEtapaItem.idObraEtapa, UnitTest = obraEtapa.UnitTest });
                        obraEtapaItem.lstGastosPrevistos = this.PesquisarGastosPrevistos(new ObraEtapaGastoPrevisto() { idObraEtapa = obraEtapaItem.idObraEtapa, UnitTest = obraEtapa.UnitTest });
                        obraEtapaItem.lstGastosRealizados = this.PesquisarGastosRealizados(new ObraEtapaGastoRealizado() { idObraEtapa = obraEtapaItem.idObraEtapa, UnitTest = obraEtapa.UnitTest });
                        obraEtapaItem.lstFases = this.PesquisarObraEtapaFases(new ObraEtapaFase() { idObraEtapa = obraEtapaItem.idObraEtapa, UnitTest = obraEtapa.UnitTest });
                        obraEtapaItem.lstFollowUps = this.PesquisarObraEtapaFollowUp(new ObraEtapaFollowUp() { idObraEtapa = obraEtapaItem.idObraEtapa, UnitTest = obraEtapa.UnitTest });

                        obraEtapaItem.saldoEtapa = obraEtapaItem.valorContrato - decimal.Parse(obraEtapaItem.lstGastosRealizados.Where(x => x.statusOrdemPagamento == "PAGA").Sum(y => y.Valor).ToString());
                        obraEtapaItem.totalNotaFiscalGerada = decimal.Parse(bizNF.PesquisarNotaFiscal(new NotaFiscal() { idObraEtapa = obraEtapaItem.idObraEtapa }).Where(y => y.Cancelado == 0).Sum(x => x.valorNota).ToString());

                        lstObrasEtapas.Add(obraEtapaItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObrasEtapas;
        }

        public List<ObraEtapa> PesquisarObraEtapaDespesa(int idDespesa)
        {
            List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idDespesa", idDespesa.ToString());

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_DESPESAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapa obraEtapaItem = new ObraEtapa();
                        obraEtapaItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        obraEtapaItem.numeroLicitacao = dr["NumeroLicitacao"].ToString();
                        obraEtapaItem.nomeCliente = dr["Nome"].ToString();
                        obraEtapaItem.nomeEvento = dr["NomeEvento"].ToString();

                        lstObrasEtapas.Add(obraEtapaItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_DESPESAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObrasEtapas;
        }

        public List<ObraEtapa> PesquisarObraEtapaCombo()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapa> lstObras = new List<ObraEtapa>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapa obraItem = new ObraEtapa();
                        obraItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        obraItem.numeroLicitacao = dr["Nome"].ToString() + " - " + dr["NumeroLicitacao"].ToString() + " - " + dr["Descricao"].ToString();
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
                    procedureSQL = "SP_OBRASETAPAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObras.OrderBy(x => x.numeroLicitacao).ToList();
        }

        public List<ObraEtapa> PesquisarObraEtapaFreteCombo()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapa> lstObrasEtapas = new List<ObraEtapa>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_FRETES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapa obraItem = new ObraEtapa();
                        obraItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        obraItem.numeroLicitacao = dr["Nome"].ToString() + " - " + dr["NumeroLicitacao"].ToString() + " - " + dr["Descricao"].ToString();
                        lstObrasEtapas.Add(obraItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_FRETES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObrasEtapas.OrderBy(x => x.numeroLicitacao).ToList();
        }

        private string ValidarCamposObrigatoriosEtapa(ObraEtapa obraEtapa)
        {
            string Msg = string.Empty;

            if (obraEtapa.idEmpresa == 0)
                Msg += Environment.NewLine + "Favor selecionar a Empresa";

            if (obraEtapa.numeroLicitacao == string.Empty)
                Msg += Environment.NewLine + "Favor informar o Número da Licitação";

            if (obraEtapa.idCliente == 0)
                Msg += Environment.NewLine + "Favor selecionar o Cliente";

            if (obraEtapa.Descricao == string.Empty)
                Msg += Environment.NewLine + "Favor informar a Descrição";

            if (obraEtapa.nomeEvento == string.Empty)
                Msg += Environment.NewLine + "Favor informar o Nome do Evento";

            if(obraEtapa.dataInicio > obraEtapa.dataTermino)
                Msg += Environment.NewLine + "A Data de Início da Obra não pode ser maior do que a Data de Término";

            return Msg;
        }

        public string IncluirObraEtapa(ObraEtapa obraEtapa, out int idObraEtapa)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosEtapa(obraEtapa);
                idObraEtapa = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarObraEtapa(obraEtapa);

                    using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idObraEtapa = int.Parse(dr[0].ToString());
                    }

                  //  lstComandos.AddRange(this.IncluirPlanejamento(idObraEtapa, obraEtapa.lstPlanejamentos));
                    lstComandos.AddRange(this.IncluirGastosPrevistos(idObraEtapa, obraEtapa.lstGastosPrevistos));
                    lstComandos.AddRange(this.IncluirGastosRealizados(idObraEtapa, obraEtapa.lstGastosRealizados));
                    lstComandos.AddRange(this.IncluirFases(idObraEtapa, obraEtapa.lstFases));
                    lstComandos.AddRange(this.IncluirFollowUp(idObraEtapa, obraEtapa.lstFollowUps));
                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        //public string AlterarObraEtapaPlanejamento(ObraEtapa obraEtapa)
        //{
        //    DataAccess dao = new DataAccess();
        //    List<_Transacao> lstComandos = new List<_Transacao>();
        //    Dictionary<string, string> lstParametros = new Dictionary<string, string>();
        //    Dictionary<string, string> lstExclusao = new Dictionary<string, string>();

        //    string Msg = string.Empty;

        //    try
        //    {
        //        Msg = ValidarCamposObrigatoriosEtapa(obraEtapa);

        //        if (Msg == string.Empty)
        //        {
        //            lstComandos.Add(new _Transacao()
        //            {
        //                nomeProcedure = "SP_OBRASETAPAS_ALTERAR",
        //                lstParametros = MontarParametrosExecutarObraEtapa(obraEtapa)
        //            });

        //            lstExclusao.Add("@idObraEtapa", obraEtapa.idObraEtapa.ToString());

        //            lstComandos.Add(new _Transacao()
        //            {
        //                nomeProcedure = "SP_OBRASETAPAS_PLANEJAMENTO_EXCLUIR",
        //                lstParametros = lstExclusao
        //            });

        //            lstComandos.AddRange(this.IncluirPlanejamento(obraEtapa.idObraEtapa, obraEtapa.lstPlanejamentos));                   

        //            dao.ExecutarTransacao(lstComandos);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string parametrosSQL = string.Empty;
        //        parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

        //        LogErro log = new LogErro()
        //        {
        //            procedureSQL = "SP_OBRASETAPAS_ALTERAR",
        //            parametrosSQL = parametrosSQL,
        //            mensagemErro = ex.ToString()
        //        };

        //        bizLogErro.IncluirLogErro(log);

        //        throw ex;
        //    }

        //    return Msg;
        //}        
        
        public string AlterarObraEtapa(ObraEtapa obraEtapa)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstExclusao = new Dictionary<string, string>();            

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosEtapa(obraEtapa);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_OBRASETAPAS_ALTERAR",
                        lstParametros = MontarParametrosExecutarObraEtapa(obraEtapa)
                    });

                    lstExclusao.Add("@idObraEtapa", obraEtapa.idObraEtapa.ToString());

                    //lstComandos.Add(new _Transacao()
                    //{
                    //    nomeProcedure = "SP_OBRASETAPAS_PLANEJAMENTO_EXCLUIR",
                    //    lstParametros = lstExclusao
                    //});

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_OBRASETAPAS_GASTOSPREVISTOS_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_OBRASETAPAS_GASTOSPREVISTOS_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_OBRASETAPAS_GASTOSREALIZADOS_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_OBRASETAPAS_FASES_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_OBRASETAPAS_FOLLOWUP_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                   // lstComandos.AddRange(this.IncluirPlanejamento(obraEtapa.idObraEtapa, obraEtapa.lstPlanejamentos));
                    lstComandos.AddRange(this.IncluirGastosPrevistos(obraEtapa.idObraEtapa, obraEtapa.lstGastosPrevistos));
                    lstComandos.AddRange(this.IncluirGastosRealizados(obraEtapa.idObraEtapa, obraEtapa.lstGastosRealizados));
                    lstComandos.AddRange(this.IncluirFases(obraEtapa.idObraEtapa, obraEtapa.lstFases));
                    lstComandos.AddRange(this.IncluirFollowUp(obraEtapa.idObraEtapa, obraEtapa.lstFollowUps));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirObraEtapa()
        {
            DataAccess dao = new DataAccess();

            try
            {
                dao.Executar("SP_OBRASETAPAS_EXCLUIR", new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void ExcluirObraEtapaTestes()
        {
            DataAccess dao = new DataAccess();

            try
            {
                dao.Executar("SP_OBRASETAPAS_EXCLUIRTESTE", new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        private decimal ObterSaldoComparativoPrevistoRealizado(List<ObraEtapaGastoPrevisto> lstPrevisto, List<ObraEtapaGastoRealizado> lstRealizado)
        {
            decimal saldo = decimal.Zero;
            decimal totalPrevisto = decimal.Zero;
            decimal totalRealizado = decimal.Zero;

            totalPrevisto = lstPrevisto.Sum(prev => prev.Valor);
            totalRealizado = lstRealizado.Sum(real => real.Valor);

            saldo = totalPrevisto - totalRealizado;

            return saldo;
        }

        public DataTable GerarRelatorioRealizadas(string filtro, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtObra = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_OBRAS_RELATORIO_REALIZADAS", lstParametros);
                dtObra = ds.Tables[0];

                dtObra = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtObra);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRAS_RELATORIO_REALIZADAS",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtObra;
        }

        public DataTable GerarRelatorioRealizadasConsolidado(string filtro, string filtroRelatorio)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtObra = new DataTable();

            try
            {
                lstParametros.Add("@filtro", filtro);
                DataSet ds = dao.Pesquisar("SP_OBRAS_RELATORIO_REALIZADAS_CONSOLIDADO", lstParametros);
                dtObra = ds.Tables[0];

                dtObra = helper.AdicionarColunaFiltroRelatorio(filtroRelatorio, dtObra);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRAS_RELATORIO_REALIZADAS_CONSOLIDADO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtObra;
        }

        public List<_Transacao> AtualizarGastosRealizadosOrdemPagamento(int idOP, List<ObraEtapaGastoRealizado> lstRealizados)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (ObraEtapaGastoRealizado gastoRealizado in lstRealizados)
            {
                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idObraEtapaGastoRealizado", gastoRealizado.idObraEtapaGastoRealizado.ToString());
                lstParametros.Add("@idOrdemPagamento", idOP.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_OBRASETAPAS_GASTOSREALIZADOS_ATUALIZAROP",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        #endregion

        #region Gastos Previstos
        
        private Dictionary<string, string> MontarParametrosExecutarGastoPrevisto(ObraEtapaGastoPrevisto gastoPrevisto)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", gastoPrevisto.idObraEtapa.ToString());
            lstParametros.Add("@idUEN", gastoPrevisto.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", gastoPrevisto.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", gastoPrevisto.idDespesa.ToString());
            lstParametros.Add("@Valor", gastoPrevisto.Valor.ToString());
            lstParametros.Add("@Observacao", gastoPrevisto.Observacao.ToString());
            lstParametros.Add("@UnitTest", gastoPrevisto.UnitTest.ToString());

            return lstParametros;
        }
        
        private Dictionary<string, string> MontarParametrosPesquisarGastoPrevisto(ObraEtapaGastoPrevisto gastoPrevisto)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", gastoPrevisto.idObraEtapa.Equals(0) ? null : gastoPrevisto.idObraEtapa.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", gastoPrevisto.UnitTest.Equals(0) ? null : gastoPrevisto.UnitTest.ToString());

            return lstParametros;
        } 
        
        private List<ObraEtapaGastoPrevisto> PesquisarGastosPrevistos(ObraEtapaGastoPrevisto gastoPrevisto)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapaGastoPrevisto> lstGastosPrevistos = new List<ObraEtapaGastoPrevisto>();
            
            try
            {
                lstParametros = MontarParametrosPesquisarGastoPrevisto(gastoPrevisto);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_GASTOSPREVISTOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapaGastoPrevisto previstoItem = new ObraEtapaGastoPrevisto();
                        previstoItem.idObraEtapa =  int.Parse(dr["idObraEtapa"].ToString());
                        previstoItem.idUEN = int.Parse(dr["idUEN"].ToString());
                        previstoItem.descricaoUEN = dr["DescricaoUEN"].ToString();
                        previstoItem.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        previstoItem.descricaoCentroCusto = dr["DescricaoCentroCusto"].ToString();
                        previstoItem.idDespesa = int.Parse(dr["idDespesa"].ToString());
                        previstoItem.descricaoDespesa = dr["DescricaoDespesa"].ToString();
                        previstoItem.Valor = decimal.Parse(dr["Valor"].ToString());
                        previstoItem.Observacao = dr["Observacao"].ToString();
                        previstoItem.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        
                        lstGastosPrevistos.Add(previstoItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_GASTOSPREVISTOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstGastosPrevistos;
        }
        
        private List<_Transacao> IncluirGastosPrevistos(int idObraEtapa, List<ObraEtapaGastoPrevisto> lstPrevisto)
        {   
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (ObraEtapaGastoPrevisto gastoPrevisto in lstPrevisto)
            {
                gastoPrevisto.idObraEtapa = idObraEtapa;
                lstParametros = MontarParametrosExecutarGastoPrevisto(gastoPrevisto);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_OBRASETAPAS_GASTOSPREVISTOS_INCLUIR",
                    lstParametros = lstParametros
                });                        
            }

            return lstComandos;
        }

        #endregion

        #region Gastos Realizados
        
        private Dictionary<string, string> MontarParametrosExecutarGastoRealizado(ObraEtapaGastoRealizado gastoRealizado)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", gastoRealizado.idObraEtapa.ToString());
            lstParametros.Add("@idUEN", gastoRealizado.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", gastoRealizado.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", gastoRealizado.idDespesa.ToString());
            lstParametros.Add("@idOrdemPagamento", gastoRealizado.idOrdemPagamento.ToString());
            lstParametros.Add("@Data", gastoRealizado.Data.Date.ToString());
            lstParametros.Add("@Valor", gastoRealizado.Valor.ToString());
            lstParametros.Add("@Observacao", gastoRealizado.Observacao.ToString());
            lstParametros.Add("@UnitTest", gastoRealizado.UnitTest.ToString());

            return lstParametros;
        }
        
        private Dictionary<string, string> MontarParametrosPesquisarGastoRealizado(ObraEtapaGastoRealizado gastoRealizado)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapaGastoRealizado", gastoRealizado.idObraEtapaGastoRealizado.Equals(0) ? null : gastoRealizado.idObraEtapaGastoRealizado.ToString());
            lstParametros.Add("@idObraEtapa", gastoRealizado.idObraEtapa.Equals(0) ? null : gastoRealizado.idObraEtapa.ToString());
            lstParametros.Add("@idUEN", gastoRealizado.idUEN.Equals(0) ? null : gastoRealizado.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", gastoRealizado.idCentroCusto.Equals(0) ? null : gastoRealizado.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", gastoRealizado.idDespesa.Equals(0) ? null : gastoRealizado.idDespesa.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", gastoRealizado.UnitTest.Equals(0) ? null : gastoRealizado.UnitTest.ToString());

            return lstParametros;
        }
        
        public List<ObraEtapaGastoRealizado> PesquisarGastosRealizados(ObraEtapaGastoRealizado gastoRealizado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapaGastoRealizado> lstGastosRealizados = new List<ObraEtapaGastoRealizado>();

            try
            {
                lstParametros = MontarParametrosPesquisarGastoRealizado(gastoRealizado);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_GASTOSREALIZADOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapaGastoRealizado realizadoItem = new ObraEtapaGastoRealizado();
                        realizadoItem.idObraEtapaGastoRealizado = int.Parse(dr["idObraEtapaGastoRealizado"].ToString());
                        realizadoItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        realizadoItem.idUEN = int.Parse(dr["idUEN"].ToString());
                        realizadoItem.descricaoUEN = dr["DescricaoUEN"].ToString();
                        realizadoItem.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        realizadoItem.descricaoCentroCusto = dr["DescricaoCentroCusto"].ToString();
                        realizadoItem.idDespesa = int.Parse(dr["idDespesa"].ToString());
                        realizadoItem.descricaoDespesa = dr["DescricaoDespesa"].ToString();
                        realizadoItem.Data = DateTime.Parse(dr["Data"].ToString());
                        realizadoItem.Valor = decimal.Parse(dr["Valor"].ToString());
                        realizadoItem.idOrdemPagamento = int.Parse(dr["idOrdemPagamento"].ToString());
                        realizadoItem.statusOrdemPagamento = dr["StatusOP"].ToString();
                        realizadoItem.Observacao = dr["Observacao"].ToString();
                        realizadoItem.UnitTest = int.Parse(dr["UnitTest"].ToString());

                        lstGastosRealizados.Add(realizadoItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_GASTOSREALIZADOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstGastosRealizados;
        }

        public List<UEN> RetornarUENGastosRealizados(ObraEtapaGastoRealizado gastoRealizado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UEN> lstUEN = new List<UEN>();
            List<UEN> lstAgrupada = new List<UEN>();
            
            try
            {
                lstParametros = MontarParametrosPesquisarGastoRealizado(gastoRealizado);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_GASTOSREALIZADOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (!lstUEN.Exists(x => x.idUEN == int.Parse(dr["idUEN"].ToString())))
                        {
                            lstUEN.Add(new UEN()
                            {
                                idUEN = int.Parse(dr["idUEN"].ToString()),
                                Descricao = dr["DescricaoUEN"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_GASTOSREALIZADOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstUEN;       
        }

        private List<_Transacao> IncluirGastosRealizados(int idObraEtapa, List<ObraEtapaGastoRealizado> lstRealizado)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (ObraEtapaGastoRealizado gastoRealizado in lstRealizado)
            {
                gastoRealizado.idObraEtapa = idObraEtapa;
                lstParametros = MontarParametrosExecutarGastoRealizado(gastoRealizado);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_OBRASETAPAS_GASTOSREALIZADOS_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public void IncluirGastoRealizado(ObraEtapaGastoRealizado gastoRealizado, out int idGastoRealizado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            idGastoRealizado = 0;

            try
            {
                lstParametros = MontarParametrosExecutarGastoRealizado(gastoRealizado);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_GASTOSREALIZADOS_INCLUIR", lstParametros))
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    idGastoRealizado = int.Parse(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_GASTOSREALIZADOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        #endregion
        
        #region Fases
        
        private Dictionary<string, string> MontarParametrosExecutarFase(ObraEtapaFase obraFase)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", obraFase.idObraEtapa.ToString());
            lstParametros.Add("@idFase", obraFase.idFase.ToString());
            lstParametros.Add("@DataInicio", obraFase.dataInicio.Date.ToString());
            lstParametros.Add("@DataPrevTermino", obraFase.dataPrevTermino.Date.ToString());
            lstParametros.Add("@DataTermino", obraFase.dataTermino.Date.Equals(DateTime.MinValue) ? "1/1/1753" : obraFase.dataTermino.Date.ToString());            
            lstParametros.Add("@UnitTest", obraFase.UnitTest.ToString());

            return lstParametros;
        }
        
        private Dictionary<string, string> MontarParametrosPesquisarFase(ObraEtapaFase obraFase)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", obraFase.idObraEtapa.Equals(0) ? null : obraFase.idObraEtapa.ToString());
            lstParametros.Add("@idFase", obraFase.idFase.Equals(0) ? null : obraFase.idFase.ToString());
            lstParametros.Add("@UnitTest", obraFase.UnitTest.Equals(0) ? null : obraFase.UnitTest.ToString());

            return lstParametros;
        }

        public List<ObraEtapaFase> PesquisarObraEtapaFases(ObraEtapaFase obraFase)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapaFase> lstObraEtapaFases = new List<ObraEtapaFase>();

            try
            {
                lstParametros = MontarParametrosPesquisarFase(obraFase);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_FASES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapaFase itemFase = new ObraEtapaFase();
                        itemFase.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        itemFase.idFase = int.Parse(dr["idFase"].ToString());
                        itemFase.Descricao = dr["Descricao"].ToString();
                        itemFase.dataInicio = DateTime.Parse(dr["DataInicio"].ToString());
                        itemFase.dataPrevTermino = DateTime.Parse(dr["DataPrevTermino"].ToString());
                        itemFase.dataTermino = dr["DataTermino"].ToString() == "01/01/1753 00:00:00" ? DateTime.MinValue : DateTime.Parse(dr["DataTermino"].ToString());
                        itemFase.UnitTest = int.Parse(dr["UnitTest"].ToString());

                        lstObraEtapaFases.Add(itemFase);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_FASES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObraEtapaFases;
        }
        
        private List<_Transacao> IncluirFases(int idObraEtapa, List<ObraEtapaFase> lstFases)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (ObraEtapaFase itemFase in lstFases)
            {
                itemFase.idObraEtapa = idObraEtapa;
                lstParametros = MontarParametrosExecutarFase(itemFase);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_OBRASETAPAS_FASES_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }
        
        #endregion

        #region FollowUp

        private Dictionary<string, string> MontarParametrosExecutarFollowUP(ObraEtapaFollowUp obraFU)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", obraFU.idObraEtapa.ToString());
            lstParametros.Add("@idFollowup", obraFU.idFollowUp.ToString());
            lstParametros.Add("@idUsuario", obraFU.idUsuario.ToString());
            lstParametros.Add("@Data", obraFU.Data.ToString());
            lstParametros.Add("@Descricao", obraFU.Descricao);
            lstParametros.Add("@UnitTest", obraFU.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarFollowUp(ObraEtapaFollowUp obraFU)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idObraEtapa", obraFU.idObraEtapa.Equals(0) ? null : obraFU.idObraEtapa.ToString());
            lstParametros.Add("@idUsuario", obraFU.idUsuario.Equals(0) ? null : obraFU.idUsuario.ToString());
            lstParametros.Add("@UnitTest", obraFU.UnitTest.Equals(0) ? null : obraFU.UnitTest.ToString());

            return lstParametros;
        }

        public List<ObraEtapaFollowUp> PesquisarObraEtapaFollowUp(ObraEtapaFollowUp obraFU)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapaFollowUp> lstObraFU = new List<ObraEtapaFollowUp>();

            try
            {
                lstParametros = MontarParametrosPesquisarFollowUp(obraFU);

                using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_FOLLOWUP_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ObraEtapaFollowUp itemFU = new ObraEtapaFollowUp();
                        itemFU.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
                        itemFU.idFollowUp = int.Parse(dr["idFollowUp"].ToString());
                        itemFU.idUsuario = int.Parse(dr["idUsuario"].ToString());
                        itemFU.nomeUsuario = dr["Nome"].ToString();
                        itemFU.Descricao = dr["Descricao"].ToString();
                        itemFU.Data = DateTime.Parse(dr["Data"].ToString());
                        itemFU.UnitTest = int.Parse(dr["UnitTest"].ToString());

                        lstObraFU.Add(itemFU);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRASETAPAS_FOLLOWUP_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObraFU;
        }

        private List<_Transacao> IncluirFollowUp(int idObraEtapa, List<ObraEtapaFollowUp> lstFU)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (ObraEtapaFollowUp itemFU in lstFU)
            {
                itemFU.idObraEtapa = idObraEtapa;
                lstParametros = MontarParametrosExecutarFollowUP(itemFU);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_OBRASETAPAS_FOLLOWUP_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        #endregion
        
        //#region Planejamento

        //private Dictionary<string, string> MontarParametrosExecutarPlanejamento(ObraEtapaPlanejamento planejamento)
        //{
        //    Dictionary<string, string> lstParametros = new Dictionary<string, string>();
        //    lstParametros.Add("@idPlanejamento", planejamento.idPlanejamento.ToString());
        //    lstParametros.Add("@idObraEtapa", planejamento.idObraEtapa.ToString());
        //    lstParametros.Add("@idUEN", planejamento.idUEN.ToString());
        //    lstParametros.Add("@ValorPrevisto", planejamento.valorPrevisto.ToString());
        //    lstParametros.Add("@UnitTest", planejamento.UnitTest.ToString());

        //    return lstParametros;
        //}

        //private Dictionary<string, string> MontarParametrosPesquisarPlanejamento(ObraEtapaPlanejamento planejamento)
        //{
        //    Dictionary<string, string> lstParametros = new Dictionary<string, string>();
        //    lstParametros.Add("@idObraEtapa", planejamento.idObraEtapa.Equals(0) ? null : planejamento.idObraEtapa.ToString());
        //    lstParametros.Add("@UnitTest", planejamento.UnitTest.Equals(0) ? null : planejamento.UnitTest.ToString());

        //    return lstParametros;
        //}

        //public List<ObraEtapaPlanejamento> PesquisarPlanejamento(ObraEtapaPlanejamento planejamento)
        //{
        //    DataAccess dao = new DataAccess();
        //    Dictionary<string, string> lstParametros = new Dictionary<string, string>();
        //    List<ObraEtapaPlanejamento> lstPlanejamentos = new List<ObraEtapaPlanejamento>();

        //    try
        //    {
        //        lstParametros = MontarParametrosPesquisarPlanejamento(planejamento);

        //        using (DataSet ds = dao.Pesquisar("SP_OBRASETAPAS_PLANEJAMENTO_CONSULTAR", lstParametros))
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                ObraEtapaPlanejamento planejamentoItem = new ObraEtapaPlanejamento();
        //                planejamentoItem.idObraEtapa = int.Parse(dr["idObraEtapa"].ToString());
        //                planejamentoItem.descricaoEtapa = dr["DescricaoEtapa"].ToString();
        //                planejamentoItem.idUEN = int.Parse(dr["idUEN"].ToString());
        //                planejamentoItem.descricaoUEN = dr["DescricaoUEN"].ToString();
        //                planejamentoItem.valorPrevisto = decimal.Parse(dr["ValorPrevisto"].ToString());                        
        //                planejamentoItem.UnitTest = int.Parse(dr["UnitTest"].ToString());

        //                lstPlanejamentos.Add(planejamentoItem);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string parametrosSQL = string.Empty;
        //        parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

        //        LogErro log = new LogErro()
        //        {
        //            procedureSQL = "SP_OBRASETAPAS_PLANEJAMENTO_CONSULTAR",
        //            parametrosSQL = parametrosSQL,
        //            mensagemErro = ex.ToString()
        //        };

        //        bizLogErro.IncluirLogErro(log);

        //        throw ex;
        //    }

        //    return lstPlanejamentos;
        //}

        ////public List<_Transacao> IncluirPlanejamento(int idObraEtapa, List<ObraEtapaPlanejamento> lstPlanejamento)
        ////{
        ////    DataAccess dao = new DataAccess();
        ////    List<_Transacao> lstComandos = new List<_Transacao>();
        ////    Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
        ////    foreach (ObraEtapaPlanejamento planejamento in lstPlanejamento)
        ////    {
        ////        planejamento.idObraEtapa = idObraEtapa;
        ////        lstParametros = MontarParametrosExecutarPlanejamento(planejamento);

        ////        lstComandos.Add(new _Transacao()
        ////        {
        ////            nomeProcedure = "SP_OBRASETAPAS_PLANEJAMENTO_INCLUIR",
        ////            lstParametros = lstParametros
        ////        });
        ////    }

        ////    return lstComandos;            
        ////}

        //public void ExcluirPlanejamentoTeste()
        //{
        //    DataAccess dao = new DataAccess();

        //    try
        //    {
        //        dao.Executar("SP_OBRASETAPAS_PLANEJAMENTO_EXCLUIRTESTE", new Dictionary<string, string>());
        //    }
        //    catch (Exception ex)
        //    {
        //        string parametrosSQL = string.Empty;
        //        parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

        //        LogErro log = new LogErro()
        //        {
        //            procedureSQL = "SP_OBRASETAPAS_PLANEJAMENTO_EXCLUIRTESTE",
        //            parametrosSQL = parametrosSQL,
        //            mensagemErro = ex.ToString()
        //        };

        //        bizLogErro.IncluirLogErro(log);

        //        throw ex;
        //    }
        //}

        //#endregion
    }
}
