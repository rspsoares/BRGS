using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZMotorista
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosPesquisar(Motorista motorista)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idMotorista", motorista.idMotorista.Equals(0) ? null : motorista.idMotorista.ToString());
            lstParametros.Add("@Nome", string.IsNullOrEmpty(motorista.Nome) ? null : motorista.Nome);
            lstParametros.Add("@UnitTest", motorista.UnitTest.Equals(0) ? null : motorista.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Motorista motorista)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idMotorista", motorista.idMotorista.ToString());
            lstParametros.Add("@Nome", motorista.Nome);
            lstParametros.Add("@RG", motorista.RG);
            lstParametros.Add("@CPF", motorista.CPF);
            lstParametros.Add("@Telefone", motorista.Telefone);
            lstParametros.Add("@UnitTest", motorista.UnitTest.ToString());

            return lstParametros;
        }

        public List<Motorista> PesquisarMotorista(Motorista motorista)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Motorista> lstMotoristas = new List<Motorista>();

            try
            {
                lstParametros = MontarParametrosPesquisar(motorista);

                using (DataSet ds = dao.Pesquisar("SP_MOTORISTAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstMotoristas.Add(new Motorista()
                        {
                            idMotorista = int.Parse(dr["idMotorista"].ToString()),
                            Nome = dr["Nome"].ToString(),
                            RG = dr["RG"].ToString(),
                            CPF = dr["CPF"].ToString(),
                            Telefone = dr["Telefone"].ToString(),
                            UnitTest = int.Parse(dr["UnitTest"].ToString())
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
                    procedureSQL = "SP_MOTORISTAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstMotoristas;
        }

        private string ValidarCamposObrigatorios(Motorista motorista)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(motorista.Nome))
                Msg += Environment.NewLine + "Nome do Motorista não preenchido";

            if (string.IsNullOrEmpty(motorista.RG ))
                Msg += Environment.NewLine + "RG do Motorista não preenchido";
            
            if (string.IsNullOrEmpty(motorista.CPF))
                Msg += Environment.NewLine + "CPF do Motorista não preenchido";

            if(string.IsNullOrEmpty(motorista.CPF) == false && helper.ValidarCPF(motorista.CPF) == false)
                Msg += Environment.NewLine + "CPF inválido";

            return Msg;
        }

        public string IncluirMotorista(Motorista motorista, out int idMotorista)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(motorista);
                idMotorista = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(motorista);
                    using (DataSet ds = dao.Pesquisar("SP_MOTORISTAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idMotorista = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MOTORISTAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarMotorista(Motorista motorista)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(motorista);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(motorista);
                    dao.Executar("SP_MOTORISTAS_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MOTORISTAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ExcluirMotorista(Motorista motorista)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {   
                lstParametros.Add("@idMotorista", motorista.idMotorista.ToString());
                dao.Executar("SP_MOTORISTAS_ALTERAR_DESATIVAR", lstParametros);                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MOTORISTAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirMotoristaTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_MOTORISTAS_EXCLUIR_TESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MOTORISTAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }


        }
    }
}
