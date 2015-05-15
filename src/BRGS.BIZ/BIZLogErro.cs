using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZLogErro
    {
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosExecutar(LogErro logErro)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@Data", logErro.Data.Date.ToString());
            lstParametros.Add("@ProcedureSQL", string.IsNullOrEmpty(logErro.procedureSQL) ? string.Empty : logErro.procedureSQL);
            lstParametros.Add("@ParametrosSQL", string.IsNullOrEmpty(logErro.parametrosSQL) ? string.Empty : logErro.parametrosSQL);
            lstParametros.Add("@NomeComputador", Environment.MachineName);
            lstParametros.Add("@Mensagem", logErro.mensagemErro);

            return lstParametros;
        }

        public string IncluirLogErro(LogErro logErro)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;
            
            try
            {
                lstParametros = MontarParametrosExecutar(logErro);
                dao.Executar("SP_LOGERROS_INCLUIR", lstParametros);
            }            
            catch (Exception ex)
            {
                throw ex;
            }

            return Msg;
        }
    }
}
