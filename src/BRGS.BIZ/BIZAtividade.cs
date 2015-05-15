using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZAtividade
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZAuditoria bizAuditoria = new BIZAuditoria();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosPesquisar(Atividade atividade)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idAtividade", atividade.idAtividade.Equals(0) ? null : atividade.idAtividade.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(atividade.Descricao) ? null : atividade.Descricao);
            lstParametros.Add("@UnitTest", atividade.UnitTest.Equals(0) ? null : atividade.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Atividade atividade)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idAtividade", atividade.idAtividade.ToString());
            lstParametros.Add("@Descricao", atividade.Descricao.ToString());
            lstParametros.Add("@UnitTest", atividade.UnitTest.ToString());

            return lstParametros;
        }

        public List<Atividade> PesquisarAtividade(Atividade atividade)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Atividade> lstAtividades = new List<Atividade>();

            try
            {
                lstParametros = MontarParametrosPesquisar(atividade);

                using (DataSet ds = dao.Pesquisar("SP_ATIVIDADES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstAtividades.Add(new Atividade()
                        {
                            idAtividade = int.Parse(dr["idAtividade"].ToString()),
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
                    procedureSQL = "SP_ATIVIDADES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstAtividades;
        }

        private string ValidarCamposObrigatorios(Atividade atividade)
        {
            string Msg = string.Empty;
            
            if (string.IsNullOrEmpty(atividade.Descricao))
                Msg += Environment.NewLine + "Descrição da Atividade não preenchida";
            
            return Msg;
        }

        public string IncluirAtividade(Atividade atividade, out int idAtividade)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(atividade);
                idAtividade = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(atividade);
                    using (DataSet ds = dao.Pesquisar("SP_ATIVIDADES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idAtividade = int.Parse(dr[0].ToString());
                    }

                    atividade.idAtividade = idAtividade;
                    bizAuditoria.GerarAuditoriaAtividade(new Atividade(), atividade, "INCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ATIVIDADES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarAtividade(Atividade atividadeOriginal, Atividade atividadeAtualizada)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosAuditoria = new Dictionary<string, string>();
            Atividade atividadeAuditoria = new Atividade();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(atividadeAtualizada);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(atividadeAtualizada);
                    dao.Executar("SP_ATIVIDADES_ALTERAR", lstParametros);
                    bizAuditoria.GerarAuditoriaAtividade(atividadeOriginal, atividadeAtualizada, "ALTERAÇÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ATIVIDADES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(Atividade atividade)
        {
            BIZCliente bizCliente = new BIZCliente();
            List<Cliente> lstClientes = new List<Cliente>();
            string Msg = string.Empty;

            lstClientes = bizCliente.PesquisarCliente(new Cliente() { idAtividade = atividade.idAtividade });

            if (lstClientes.Count > 0)
                Msg += Environment.NewLine + "Esta Atividade está associada a algum Cliente";

            return Msg;
        }

        public string ExcluirAtividade(Atividade atividade)
        {
            DataAccess dao = new DataAccess();            
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusao(atividade);

                if (Msg == string.Empty || atividade.UnitTest == 1)
                {
                    lstParametros.Add("@idAtividade", atividade.idAtividade.ToString());
                    lstParametros.Add("@UnitTest", atividade.UnitTest.Equals(0) ? null : atividade.UnitTest.ToString());

                    dao.Executar("SP_ATIVIDADES_EXCLUIR", lstParametros);

                    bizAuditoria.GerarAuditoriaAtividade(atividade, atividade, "EXCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ATIVIDADES_EXCLUIR",
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
