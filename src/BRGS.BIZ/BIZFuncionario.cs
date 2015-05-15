using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BRGS.BIZ
{
    public class BIZFuncionario
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();      

        public List<Funcionario> PesquisarFuncionarios(Funcionario funcionario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Funcionario> lstFuncionarios = new List<Funcionario>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_FUNCIONARIOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstFuncionarios.Add(new Funcionario()
                        {
                            idFuncionario = int.Parse(dr["idFuncionario"].ToString()),
                            Nome = dr["Nome"].ToString(),
                            UnitTest = 0
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
                    procedureSQL = "SP_FUNCIONARIOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstFuncionarios;
        }
    }
}
