using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZCategoria
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        private BIZAuditoria bizAuditoria = new BIZAuditoria();

        private Dictionary<string, string> MontarParametrosPesquisar(Categoria categoria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idCategoria", categoria.idCategoria.Equals(0) ? null : categoria.idCategoria.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(categoria.Descricao) ? null : categoria.Descricao);
            lstParametros.Add("@UnitTest", categoria.UnitTest.Equals(0) ? null : categoria.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Categoria categoria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCategoria", categoria.idCategoria.ToString());
            lstParametros.Add("@Descricao", categoria.Descricao.ToString());
            lstParametros.Add("@UnitTest", categoria.UnitTest.ToString());

            return lstParametros;
        }

        public List<Categoria> PesquisarCategoria(Categoria categoria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Categoria> lstAtividades = new List<Categoria>();

            try
            {
                lstParametros = MontarParametrosPesquisar(categoria);

                using (DataSet ds = dao.Pesquisar("SP_CATEGORIAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstAtividades.Add(new Categoria()
                        {
                            idCategoria = int.Parse(dr["idCategoria"].ToString()),
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
                    procedureSQL = "SP_CATEGORIAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstAtividades;
        }

        private string ValidarCamposObrigatorios(Categoria categoria)
        {
            string Msg = string.Empty;            

            if (string.IsNullOrEmpty(categoria.Descricao))
                Msg += Environment.NewLine + "Descrição da Categoria não preenchida";

            return Msg;
        }

        public string IncluirCategoria(Categoria categoria, out int idCategoria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(categoria);
                idCategoria = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(categoria);
                    using (DataSet ds = dao.Pesquisar("SP_CATEGORIAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idCategoria = int.Parse(dr[0].ToString());
                    }

                    categoria.idCategoria = idCategoria;
                    bizAuditoria.GerarAuditoriaCategoria(new Categoria(), categoria, "INCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CATEGORIAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarCategoria(Categoria categoriaOriginal, Categoria categoriaAtualizada)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(categoriaAtualizada);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(categoriaAtualizada);
                    dao.Executar("SP_CATEGORIAS_ALTERAR", lstParametros);
                    bizAuditoria.GerarAuditoriaCategoria(categoriaOriginal, categoriaAtualizada, "ALTERAÇÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CATEGORIAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(Categoria categoria)
        {
            BIZCliente bizCliente = new BIZCliente();
            List<Cliente> lstClientes = new List<Cliente>();
            string Msg = string.Empty;

            lstClientes = bizCliente.PesquisarCliente(new Cliente() { idCategoria = categoria.idCategoria });

            if (lstClientes.Count > 0)
                Msg += Environment.NewLine + "Esta Categoria está associada a algum Cliente";

            return Msg;
        }

        public string ExcluirCategoria(Categoria categoria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusao(categoria);

                if (Msg == string.Empty || categoria.UnitTest == 1)
                {
                    lstParametros.Add("@idCategoria", categoria.idCategoria.ToString());
                    lstParametros.Add("@UnitTest", categoria.UnitTest.Equals(0) ? null : categoria.UnitTest.ToString());

                    dao.Executar("SP_CATEGORIAS_EXCLUIR", lstParametros);

                    bizAuditoria.GerarAuditoriaCategoria(categoria, categoria, "EXCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CATEGORIAS_EXCLUIR",
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
