using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entities;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZUnidadeEstrategicaNegocio
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosPesquisar(UnidadeEstrategicaNegocio uen)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idUEN", uen.idUEN.Equals(0) ? null : uen.idUEN.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(uen.Descricao) ? null : uen.Descricao);
            lstParametros.Add("@UnitTest", uen.UnitTest.Equals(0) ? null : uen.UnitTest.ToString());
            return lstParametros;
        }

        public List<UnidadeEstrategicaNegocio> PesquisarUnidadeEstrategicaNegocio(UnidadeEstrategicaNegocio uen)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UnidadeEstrategicaNegocio> lstUEN = new List<UnidadeEstrategicaNegocio>();

            try
            {
                lstParametros = MontarParametrosPesquisar(uen);

                using (DataSet ds = dao.Pesquisar("SP_UEN_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstUEN.Add(new UnidadeEstrategicaNegocio()
                        {
                            idUEN = int.Parse(dr["idUEN"].ToString()),                          
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
                    procedureSQL = "SP_UEN_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstUEN;
        }
    }
}
