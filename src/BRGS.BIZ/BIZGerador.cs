using BRGS.Entity;
using BRGS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BRGS.BIZ
{
    public  class BIZGerador
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosExecutar(Gerador gerador)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", gerador.ID.ToString() },
                { "@IdEmpresa", gerador.IdEmpresa.Equals(0) ? string.Empty : gerador.IdEmpresa.ToString() },
                { "@IdObra", gerador.IdObra.Equals(0) ? string.Empty : gerador.IdObra.ToString() },
                { "@NumeroSerie", gerador.NumeroSerie },
                { "@Combustivel", gerador.Combustivel },
                { "@Modelo", gerador.Modelo },
                { "@Marca", gerador.Marca },
                { "@Lotado", gerador.Lotado },
                { "@NotaFiscal", gerador.NotaFiscal },
                { "@DataCompra", gerador.DataCompra.ToString() },
                { "@Acessorios", gerador.Acessorios }
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarGeradores(Gerador gerador)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", gerador.ID.Equals(0) ? null : gerador.ID.ToString() },
                { "@IdEmpresa", gerador.IdEmpresa.Equals(0) ? null : gerador.IdEmpresa.ToString() },
                { "@IdObra", gerador.IdObra.Equals(0) ? null : gerador.IdObra.ToString() },
                { "@NumeroSerie", string.IsNullOrEmpty(gerador.NumeroSerie) ? null : gerador.NumeroSerie },
                { "@Combustivel", string.IsNullOrEmpty(gerador.Combustivel) ? null : gerador.Combustivel },
                { "@Modelo", string.IsNullOrEmpty(gerador.Modelo) ? null : gerador.Modelo },
                { "@Marca", string.IsNullOrEmpty(gerador.Marca) ? null : gerador.Marca },
                { "@Lotada", string.IsNullOrEmpty(gerador.Lotado) ? null : gerador.Lotado },
                { "@NotaFiscal", string.IsNullOrEmpty(gerador.NotaFiscal) ? null : gerador.NotaFiscal },
                { "@DataCompra", gerador.DataCompra.Equals(DateTime.MinValue) ? null : gerador.DataCompra.ToString() }
            };

            return lstParametros;
        }

        private string ValidarCamposObrigatorios(Gerador gerador)
        {
            string Msg = string.Empty;

            //if (string.IsNullOrEmpty(categoria.Descricao))
            //    Msg += Environment.NewLine + "Descrição da Categoria não preenchida";

            return Msg;
        }

        public string IncluirGerador(Gerador gerador, out int ID)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(gerador);
                ID = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(gerador);
                    using (DataSet ds = dao.Pesquisar("SP_GERADORES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        ID = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_GERADORES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public List<Gerador> PesquisarGeradores(Gerador gerador)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Gerador> lstGeradores = new List<Gerador>();
            dynamic lst = new List<Gerador>();
            try
            {
                lstParametros = MontarParametrosPesquisarGeradores(gerador);

                using (DataSet ds = dao.Pesquisar("SP_GERADORES_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Gerador>()
                          select f;
                }

                lstGeradores.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_GERADORES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstGeradores;
        }
    }
}
