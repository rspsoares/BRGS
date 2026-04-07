using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BRGS.BIZ
{
    public class BIZEmpilhadeira
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosExecutar(Empilhadeira empilhadeira)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", empilhadeira.ID.ToString() },
                { "@IdEmpresa", empilhadeira.IdEmpresa.Equals(0) ? string.Empty : empilhadeira.IdEmpresa.ToString() },
                { "@IdObra", empilhadeira.IdObra.Equals(0) ? string.Empty : empilhadeira.IdObra.ToString() },
                { "@NumeroSerie", empilhadeira.NumeroSerie },
                { "@Combustivel", empilhadeira.Combustivel },
                { "@Modelo", empilhadeira.Modelo },
                { "@Marca", empilhadeira.Marca },
                { "@Torre", empilhadeira.Torre.ToString() },
                { "@CapacidadeCarga", empilhadeira.CapacidadeCarga.ToString() },
                { "@Lotada", empilhadeira.Lotada },
                { "@NotaFiscal", empilhadeira.NotaFiscal },
                { "@DataCompra", empilhadeira.DataCompra.ToString() },
                { "@Acessorios", empilhadeira.Acessorios }
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarEmpilhadeiras(Empilhadeira empilhadeira)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", empilhadeira.ID.Equals(0) ? null : empilhadeira.ID.ToString() },
                { "@IdEmpresa", empilhadeira.IdEmpresa.Equals(0) ? null : empilhadeira.IdEmpresa.ToString() },
                { "@IdObra", empilhadeira.IdObra.Equals(0) ? null : empilhadeira.IdObra.ToString() },
                { "@NumeroSerie", string.IsNullOrEmpty(empilhadeira.NumeroSerie) ? null : empilhadeira.NumeroSerie },
                { "@Combustivel", string.IsNullOrEmpty(empilhadeira.Combustivel) ? null : empilhadeira.Combustivel },
                { "@Modelo", string.IsNullOrEmpty(empilhadeira.Modelo) ? null : empilhadeira.Modelo },
                { "@Marca", string.IsNullOrEmpty(empilhadeira.Marca) ? null : empilhadeira.Marca },
                { "@Torre", empilhadeira.Torre.Equals(0) ? null : empilhadeira.Torre.ToString() },
                { "@CapacidadeCarga", empilhadeira.CapacidadeCarga.Equals(0) ? null : empilhadeira.CapacidadeCarga.ToString() },
                { "@Lotada", string.IsNullOrEmpty(empilhadeira.Lotada) ? null : empilhadeira.Lotada },
                { "@NotaFiscal", string.IsNullOrEmpty(empilhadeira.NotaFiscal) ? null : empilhadeira.NotaFiscal },
                { "@DataCompra", empilhadeira.DataCompra.Equals(DateTime.MinValue) ? null : empilhadeira.DataCompra.ToString() }
            };

            return lstParametros;
        }

        private string ValidarCamposObrigatorios(Empilhadeira empilhadeira)
        {
            string Msg = string.Empty;

            //if (string.IsNullOrEmpty(categoria.Descricao))
            //    Msg += Environment.NewLine + "Descrição da Categoria não preenchida";

            return Msg;
        }

        public string IncluirEmpilhadeira(Empilhadeira empilhadeira, out int ID)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(empilhadeira);
                ID = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(empilhadeira);
                    using (DataSet ds = dao.Pesquisar("SP_EMPILHADEIRAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        ID = int.Parse(dr[0].ToString());
                    }

                    //categoria.idCategoria = ID;
                    //bizAuditoria.GerarAuditoriaCategoria(new Categoria(), categoria, "INCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public List<Empilhadeira> PesquisarEmpilhadeiras(Empilhadeira empilhadeira)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Empilhadeira> lstEmpilhadeiras = new List<Empilhadeira>();
            dynamic lst = new List<Empilhadeira>();
            try
            {
                lstParametros = MontarParametrosPesquisarEmpilhadeiras(empilhadeira);

                using (DataSet ds = dao.Pesquisar("SP_EMPILHADEIRAS_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Empilhadeira>()
                          select f;
                }

                lstEmpilhadeiras.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstEmpilhadeiras;
        }
    }
}
