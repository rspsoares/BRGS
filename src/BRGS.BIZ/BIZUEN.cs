using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZUEN
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosPesquisarUEN(UEN uen)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idUEN", uen.idUEN.Equals(0) ? null : uen.idUEN.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(uen.Descricao) ? null : uen.Descricao);
            lstParametros.Add("@Administrativo", uen.Administrativo == null ? null : uen.Administrativo.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", uen.UnitTest.Equals(0) ? null : uen.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarUEN(UEN uen)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idUEN", uen.idUEN.ToString());
            lstParametros.Add("@Descricao", uen.Descricao);
            lstParametros.Add("@Administrativo", uen.Administrativo.ToString());
            lstParametros.Add("@UnitTest", uen.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarCentroCusto(UENCentroCusto centrosCustos)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idUEN", centrosCustos.idUEN.Equals(0) ? null : centrosCustos.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", centrosCustos.idCentroCusto.Equals(0) ? null : centrosCustos.idCentroCusto.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", centrosCustos.UnitTest.Equals(0) ? null : centrosCustos.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutaCentroCusto(UENCentroCusto centrosCustos)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idUEN", centrosCustos.idUEN.ToString());
            lstParametros.Add("@idCentroCusto", centrosCustos.idCentroCusto.ToString());
            lstParametros.Add("@UnitTest", centrosCustos.UnitTest.ToString());

            return lstParametros;
        }

        public List<UEN> PesquisarUEN(UEN uen)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UEN> lstUEN = new List<UEN>();

            try
            {
                lstParametros = MontarParametrosPesquisarUEN(uen);

                using (DataSet ds = dao.Pesquisar("SP_UEN_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UEN uenItem = new UEN();
                        uenItem.idUEN =  int.Parse(dr["idUEN"].ToString());
                        uenItem.Descricao =  dr["Descricao"].ToString();
                        uenItem.Administrativo = int.Parse(dr["Administrativo"].ToString());
                        uenItem.lstCentrosCustos = this.PesquisarCentrosCustosAssociados(new UENCentroCusto() { idUEN = uenItem.idUEN });

                        lstUEN.Add(uenItem);
                    }
                }
            }   
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);
                 
                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_UEN_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstUEN;
        }

        public List<UENCentroCusto> PesquisarCentrosCustosAssociados(UENCentroCusto centrosCustos)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UENCentroCusto> lstCentrosCustos = new List<UENCentroCusto>();

            try
            {
                lstParametros = MontarParametrosPesquisarCentroCusto(centrosCustos);

                using (DataSet ds = dao.Pesquisar("SP_UEN_CENTROSCUSTOS_PESQUISAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UENCentroCusto centroCustoItem = new UENCentroCusto();

                        centroCustoItem.idUEN = int.Parse(dr["idUEN"].ToString());
                        centroCustoItem.descricaoUEN = dr["DescricaoUEN"].ToString();
                        centroCustoItem.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        centroCustoItem.codigoCentroCusto = dr["CodigoCentroCusto"].ToString();
                        centroCustoItem.descricaoCentroCusto = dr["DescricaoCentroCusto"].ToString();
                        centroCustoItem.Administrativo = int.Parse(dr["Administrativo"].ToString());
                        lstCentrosCustos.Add(centroCustoItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_UEN_CENTROSCUSTOS_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstCentrosCustos;
        }

        private string ValidarCamposObrigatorios(UEN uen)
        {
            string Msg = string.Empty;
                        
            if (string.IsNullOrEmpty(uen.Descricao))
                Msg += Environment.NewLine + "Favor informar a Descrição";

            return Msg;
        }

        public string IncluirUEN(int idUsuario, UEN uen, out int idUEN)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosCentroCusto = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarCamposObrigatorios(uen);
                idUEN = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarUEN(uen);

                    using (DataSet ds = dao.Pesquisar("SP_UEN_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idUEN = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(this.IncluirCentrosCustos(idUEN, uen.lstCentrosCustos));

                    dao.ExecutarTransacao(lstComandos);

                    lstParametros = new Dictionary<string, string>();
                    lstParametros.Add("@idUsuario", idUsuario.ToString());
                    lstParametros.Add("@idUEN", idUEN.ToString());
                    lstParametros.Add("@UnitTest", uen.UnitTest.ToString());

                    dao.Executar("SP_USUARIOSUEN_INCLUIR", lstParametros);         
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_UEN_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        private List<_Transacao> IncluirCentrosCustos(int idUEN, List<UENCentroCusto> lstCentroCusto)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (UENCentroCusto itemCentroCusto in lstCentroCusto)
            {
                itemCentroCusto.idUEN = idUEN;
                lstParametros = MontarParametrosExecutaCentroCusto(itemCentroCusto);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_UEN_CENTROSCUSTOS_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public string AlterarUEN(UEN uen)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstExclusaoCentroCusto = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosCentroCusto = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(uen);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_UEN_ALTERAR",
                        lstParametros = MontarParametrosExecutarUEN(uen)
                    });

                    lstExclusaoCentroCusto.Add("@idUEN", uen.idUEN.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_UEN_CENTROSCUSTOS_EXCLUIR",
                        lstParametros = lstExclusaoCentroCusto
                    });

                    lstComandos.AddRange(this.IncluirCentrosCustos(uen.idUEN, uen.lstCentrosCustos));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_UEN_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(UEN uen)
        {
            BIZObra bizObra = new BIZObra();
            List<ObraEtapaGastoRealizado> lstObras = new List<ObraEtapaGastoRealizado>();
            BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
            List<OrdemPagamentoItem> lstOPItens = new List<OrdemPagamentoItem>();

            string Msg = string.Empty;

            lstObras = bizObra.PesquisarGastosRealizados(new ObraEtapaGastoRealizado() { idUEN = uen.idUEN });

            if (lstObras.Count > 0)
                Msg += Environment.NewLine + "Esta UEN está associada a alguma Obra";

            lstOPItens = bizOP.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idUEN  = uen.idUEN });

            if (lstOPItens.Count > 0)
                Msg += Environment.NewLine + "Esta UEN está associada a alguma Ordem de Pagamento";            
            
            return Msg;
        }

        public string ExcluirUEN(UEN uen)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusao(uen);

                if (Msg == string.Empty || uen.UnitTest == 1)
                {
                    lstParametros.Add("@idUEN", uen.idUEN.ToString());
                    lstParametros.Add("@UnitTest", uen.UnitTest.Equals(0) ? null : uen.UnitTest.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_UEN_CENTROSCUSTOS_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_UEN_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_UEN_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }
    }
}
