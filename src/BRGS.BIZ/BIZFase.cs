using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZFase
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosPesquisar(Fase fase)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFase", fase.idFase.Equals(0) ? null : fase.idFase.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(fase.Descricao) ? null : fase.Descricao);
            lstParametros.Add("@UnitTest", fase.UnitTest.Equals(0) ? null : fase.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Fase fase)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFase", fase.idFase.ToString());
            lstParametros.Add("@Descricao", fase.Descricao.ToString());
            lstParametros.Add("@UnitTest", fase.UnitTest.ToString());

            return lstParametros;
        }

        public List<Fase> PesquisarFases(Fase fase)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Fase> lstFases = new List<Fase>();

            try
            {
                lstParametros = MontarParametrosPesquisar(fase);

                using (DataSet ds = dao.Pesquisar("SP_FASES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstFases.Add(new Fase()
                        {
                            idFase = int.Parse(dr["idFase"].ToString()),
                            Descricao = dr["Descricao"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FASES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstFases;
        }

        public List<ObraEtapa> PesquisarObrasAssociadas(Fase fase)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ObraEtapa> lstObras = new List<ObraEtapa>();

            try
            {
                lstParametros.Add("@idFase", fase.idFase.ToString());

                using (DataSet ds = dao.Pesquisar("SP_FASES_OBRASASSOCIADAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstObras.Add(new ObraEtapa()
                        {
                            idObraEtapa  = int.Parse(dr["idObra"].ToString()),
                            nomeCliente = dr["NomeCliente"].ToString(),
                            numeroLicitacao = dr["NumeroLicitacao"].ToString(),
                            nomeEvento = dr["NomeEvento"].ToString()                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FASES_OBRASASSOCIADAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstObras;
        }

        private string ValidarCamposObrigatorios(Fase fase)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(fase.Descricao))
                Msg += Environment.NewLine + "Descrição da Fase não preenchida";

            return Msg;
        }

        public string IncluirFase(Fase fase, out int idFase)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(fase);
                idFase = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(fase);
                    using (DataSet ds = dao.Pesquisar("SP_FASES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idFase = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FASES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarFase(Fase fase)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(fase);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(fase);
                    dao.Executar("SP_FASES_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FASES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(Fase fase)
        {
            BIZObra bizObra = new BIZObra();
            List<ObraEtapaFase> lstFasesObra = new List<ObraEtapaFase>();
            string Msg = string.Empty;

            lstFasesObra = bizObra.PesquisarObraEtapaFases(new ObraEtapaFase() { idFase = fase.idFase });

            if (lstFasesObra.Count > 0)
                Msg += Environment.NewLine + "Esta Fase está associada a alguma Obra";

            return Msg;
        }

        public string ExcluirFase(Fase fase)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusao(fase);

                if (Msg == string.Empty || fase.UnitTest == 1)
                {
                    lstParametros.Add("@idFase", fase.idFase.ToString());
                    lstParametros.Add("@UnitTest", fase.UnitTest.Equals(0) ? null : fase.UnitTest.ToString());

                    dao.Executar("SP_FASES_EXCLUIR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FASES_EXCLUIR",
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
