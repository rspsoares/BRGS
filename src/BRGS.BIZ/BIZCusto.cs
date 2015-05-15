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
    public class BIZCusto
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();      

        private Dictionary<string, string> MontarParametrosPesquisar(Custo custo)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idCusto", custo.idCusto.Equals(0) ? null : custo.idCusto.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(custo.Descricao) ? null : custo.Descricao);
            lstParametros.Add("@UnitTest", custo.UnitTest.Equals(0) ? null : custo.UnitTest.ToString());
            return lstParametros;
        }

        public List<Custo> PesquisarCusto(Custo custo)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Custo> lstCustos = new List<Custo>();

            try
            {
                lstParametros = MontarParametrosPesquisar(custo);

                using (DataSet ds = dao.Pesquisar("SP_CUSTOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstCustos.Add(new Custo()
                        {
                            idCusto =  int.Parse(dr["idCusto"].ToString()),
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
                    procedureSQL = "SP_CUSTOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstCustos;
        }
    }
}
