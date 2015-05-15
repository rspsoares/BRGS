using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BRGS.BIZ
{
    public class BIZParametrizacao
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZAuditoria bizAuditoria = new BIZAuditoria();

        private Dictionary<string, string> MontarParametrosExecutar()
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@diasVencimentoOPAlerta", Parametrizacao.diasVencimentoOPAlerta.ToString());
            lstParametros.Add("@diasVencimentoOPCritico", Parametrizacao.diasVencimentoOPCritico.ToString());
            lstParametros.Add("@diasVencimentoDocumentacaoVeiculoAlerta", Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta.ToString());
            lstParametros.Add("@diasVencimentoDocumentacaoVeiculoCritico", Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico.ToString());

            return lstParametros;
        }

        public void ObterParametrizacao()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            try
            {
                using (DataSet ds = dao.Pesquisar("SP_PARAMETRIZACOES_CONSULTAR", lstParametros))
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    Parametrizacao.diasVencimentoOPAlerta = string.IsNullOrEmpty(dr["diasVencimentoOPAlerta"].ToString()) ? 0 : int.Parse(dr["diasVencimentoOPAlerta"].ToString());
                    Parametrizacao.diasVencimentoOPCritico = string.IsNullOrEmpty(dr["diasVencimentoOPCritico"].ToString()) ? 0 : int.Parse(dr["diasVencimentoOPCritico"].ToString());
                    Parametrizacao.diasVencimentoDocumentacaoVeiculoAlerta = string.IsNullOrEmpty(dr["diasVencimentoDocumentacaoVeiculoAlerta"].ToString()) ? 0 : int.Parse(dr["diasVencimentoDocumentacaoVeiculoAlerta"].ToString());
                    Parametrizacao.diasVencimentoDocumentacaoVeiculoCritico = string.IsNullOrEmpty(dr["diasVencimentoDocumentacaoVeiculoCritico"].ToString()) ? 0 : int.Parse(dr["diasVencimentoDocumentacaoVeiculoCritico"].ToString());
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_PARAMETRIZACOES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }        

        public void AtualizarParametrizacao()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            try
            {
                lstParametros = MontarParametrosExecutar();
                dao.Executar("SP_PARAMETRIZACOES_ALTERAR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_PARAMETRIZACOES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }
    }
}
