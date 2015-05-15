using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZFeriado
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        private BIZAuditoria bizAuditoria = new BIZAuditoria();

        private Dictionary<string, string> MontarParametrosPesquisar(Feriado feriado)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idFeriado", feriado.idFeriado.Equals(0) ? null : feriado.idFeriado.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(feriado.Descricao) ? null : feriado.Descricao);
            lstParametros.Add("@UnitTest", feriado.UnitTest.Equals(0) ? null : feriado.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Feriado feriado)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFeriado", feriado.idFeriado.ToString());
            lstParametros.Add("@Dia", feriado.Dia.ToString());
            lstParametros.Add("@Mes", feriado.Mes.ToString());
            lstParametros.Add("@Descricao", feriado.Descricao.ToString());
            lstParametros.Add("@UnitTest", feriado.UnitTest.ToString());

            return lstParametros;
        }

        public List<Feriado> PesquisarFeriados(Feriado feriado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Feriado> lstFeriados = new List<Feriado>();

            try
            {
                lstParametros = MontarParametrosPesquisar(feriado);

                using (DataSet ds = dao.Pesquisar("SP_FERIADOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstFeriados.Add(new Feriado()
                        {
                            idFeriado = int.Parse(dr["idFeriado"].ToString()),
                            Dia = int.Parse(dr["Dia"].ToString()),
                            Mes = int.Parse(dr["Mes"].ToString()),
                            Descricao = dr["Descricao"].ToString(),
                            UnitTest = int.Parse(dr["UnitTest"].ToString()),
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
                    procedureSQL = "SP_FERIADOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstFeriados;
        }

        private string ValidarCamposObrigatorios(Feriado feriado)
        {
            string Msg = string.Empty;
            
            if (feriado.Dia == 0)
                Msg += Environment.NewLine + "Favor informar o Dia do Feriado";
            
            if (feriado.Mes == 0)
                Msg += Environment.NewLine + "Favor informar o Mês do Feriado";

            if(feriado.Dia > 28 && feriado.Mes == 2)
                Msg += Environment.NewLine + "Data de Feriado inválida";

            if (string.IsNullOrEmpty(feriado.Descricao))
                Msg += Environment.NewLine + "Favor informar a Descrição do Feriado";

            return Msg;
        }

        public string IncluirFeriado(Feriado feriado, out int idFeriado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(feriado);
                idFeriado = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(feriado);
                    using (DataSet ds = dao.Pesquisar("SP_FERIADOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idFeriado = int.Parse(dr[0].ToString());
                    }
                    
                    feriado.idFeriado = idFeriado;

                    bizAuditoria.GerarAuditoriaFeriado(new Feriado(), feriado, "INCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FERIADOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarFeriado(Feriado feriadoOriginal, Feriado feriadoAtualizado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(feriadoAtualizado);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(feriadoAtualizado);
                    dao.Executar("SP_FERIADOS_ALTERAR", lstParametros);
                    bizAuditoria.GerarAuditoriaFeriado(feriadoOriginal, feriadoAtualizado, "ALTERAÇÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FERIADOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }
        
        public string ExcluirFeriado(Feriado feriado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {                
                lstParametros.Add("@idFeriado", feriado.idFeriado.ToString());
                lstParametros.Add("@UnitTest", feriado.UnitTest.Equals(0) ? null : feriado.UnitTest.ToString());

                dao.Executar("SP_FERIADOS_EXCLUIR", lstParametros);
                bizAuditoria.GerarAuditoriaFeriado(feriado, feriado, "EXCLUSAO");
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FERIADOS_EXCLUIR",
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
