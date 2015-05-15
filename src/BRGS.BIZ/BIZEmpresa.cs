using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BRGS.Entity;
using System.Data;
using System.Data.SqlClient;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZEmpresa
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();        

        private Dictionary<string, string> MontarParametrosPesquisar(Empresa empresa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idEmpresa", empresa.idEmpresa.Equals(0) ? null : empresa.idEmpresa.ToString());
            lstParametros.Add("@RazaoSocial", string.IsNullOrEmpty(empresa.razaoSocial) ? null : empresa.razaoSocial);
            lstParametros.Add("@NomeFantasia", string.IsNullOrEmpty(empresa.nomeFantasia) ? null : empresa.nomeFantasia);
            lstParametros.Add("@UnitTest", empresa.UnitTest.Equals(0) ? null : empresa.UnitTest.ToString());   

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Empresa empresa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idEmpresa", empresa.idEmpresa.ToString());
            lstParametros.Add("@RazaoSocial", empresa.razaoSocial);
            lstParametros.Add("@NomeFantasia", empresa.nomeFantasia);
            lstParametros.Add("@Atividade", empresa.Atividade);
            lstParametros.Add("@Endereco", empresa.Endereco);
            lstParametros.Add("@Cidade", empresa.Cidade);
            lstParametros.Add("@Estado", empresa.Estado);
            lstParametros.Add("@CNPJ", empresa.CNPJ);
            lstParametros.Add("@ICM", empresa.ICM);
            lstParametros.Add("@InscricaoEstadual", empresa.inscricaoEstadual);
            lstParametros.Add("@UnitTest", empresa.UnitTest.ToString());

            return lstParametros;
        }

        public List<Empresa> PesquisarEmpresa(Empresa empresa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Empresa> lstEmpresas = new List<Empresa>();

            try
            {
                lstParametros = MontarParametrosPesquisar(empresa);

                using (DataSet ds = dao.Pesquisar("SP_EMPRESAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Empresa itemEmpresa = new Empresa();
                        itemEmpresa.idEmpresa = int.Parse(dr["idEmpresa"].ToString());
                        itemEmpresa.razaoSocial = dr["RazaoSocial"].ToString();
                        itemEmpresa.nomeFantasia = dr["NomeFantasia"].ToString();
                        itemEmpresa.Atividade = dr["Atividade"].ToString();
                        itemEmpresa.Endereco = dr["Endereco"].ToString();
                        itemEmpresa.Cidade = dr["Cidade"].ToString();
                        itemEmpresa.Estado = dr["Estado"].ToString();
                        itemEmpresa.CNPJ = dr["CNPJ"].ToString();
                        itemEmpresa.ICM = dr["ICM"].ToString();
                        itemEmpresa.inscricaoEstadual = dr["InscricaoEstadual"].ToString();
                        lstEmpresas.Add(itemEmpresa);
                    }
                }
            }            
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPRESAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstEmpresas;
        }

        private string ValidarCamposObrigatorios(Empresa empresa)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(empresa.razaoSocial))
                Msg += Environment.NewLine + "Razão Social não preenchida";

            if (string.IsNullOrEmpty(empresa.nomeFantasia))
                Msg += Environment.NewLine + "Nome Fantasia não preenchido";

            if (!string.IsNullOrEmpty(empresa.CNPJ) && !helper.ValidarCNPJ(empresa.CNPJ))
                Msg += Environment.NewLine + "Favor informar um CNPJ válido";

            return Msg;
        }

        public string IncluirEmpresa(Empresa empresa, out int idEmpresa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(empresa);
                idEmpresa = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(empresa);
                    using (DataSet ds = dao.Pesquisar("SP_EMPRESAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idEmpresa = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(this.AtualizarContasBancarias(idEmpresa, empresa.lstContasBancarias));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPRESAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarEmpresa(Empresa empresa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(empresa);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_EMPRESAS_ALTERAR",
                        lstParametros = MontarParametrosExecutar(empresa)
                    });

                    lstComandos.AddRange(this.AtualizarContasBancarias(empresa.idEmpresa, empresa.lstContasBancarias));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPRESAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirEmpresaTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {                
                dao.Executar("SP_EMPRESAS_EXCLUIRTESTE", lstParametros);                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPRESAS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        #region Contas Bancárias

        private Dictionary<string, string> MontarParametrosPesquisarContaBancaria(EmpresaContaBancaria empresaContaBancaria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idContaBancaria", empresaContaBancaria.idContaBancaria.Equals(0) ? null : empresaContaBancaria.idContaBancaria.ToString());
            lstParametros.Add("@idEmpresa", empresaContaBancaria.idEmpresa.Equals(0) ? null : empresaContaBancaria.idEmpresa.ToString());
            lstParametros.Add("@UnitTest", empresaContaBancaria.UnitTest.Equals(0) ? null : empresaContaBancaria.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarContaBancaria(EmpresaContaBancaria empresaContaBancaria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idContaBancaria", empresaContaBancaria.idContaBancaria.ToString());
            lstParametros.Add("@idEmpresa", empresaContaBancaria.idEmpresa.ToString());
            lstParametros.Add("@Banco", empresaContaBancaria.Banco);
            lstParametros.Add("@Agencia", empresaContaBancaria.Agencia);
            lstParametros.Add("@TipoConta", empresaContaBancaria.TipoConta);
            lstParametros.Add("@Conta", empresaContaBancaria.Conta);
            lstParametros.Add("@UnitTest", empresaContaBancaria.UnitTest.ToString());

            return lstParametros;
        }

        public List<EmpresaContaBancaria> PesquisarEmpresaContaBancaria(EmpresaContaBancaria empresaContaBancaria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<EmpresaContaBancaria> lstContas = new List<EmpresaContaBancaria>();

            try
            {
                lstParametros = MontarParametrosPesquisarContaBancaria(empresaContaBancaria);

                using (DataSet ds = dao.Pesquisar("SP_EMPRESAS_CONTASBANCARIAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EmpresaContaBancaria itemConta = new EmpresaContaBancaria();
                        itemConta.idContaBancaria = int.Parse(dr["idContaBancaria"].ToString());
                        itemConta.idEmpresa = int.Parse(dr["idEmpresa"].ToString());
                        itemConta.Banco = dr["Banco"].ToString();
                        itemConta.Agencia = dr["Agencia"].ToString();
                        itemConta.TipoConta = dr["TipoConta"].ToString();
                        itemConta.Conta = dr["Conta"].ToString();
                        lstContas.Add(itemConta);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPRESAS_CONTASBANCARIAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstContas;
        }

        public List<EmpresaContaBancaria> PesquisarEmpresaContaBancariaCombo(EmpresaContaBancaria empresaContaBancaria)
        {
            List<EmpresaContaBancaria> lstContas = new List<EmpresaContaBancaria>();

            lstContas = this.PesquisarEmpresaContaBancaria(empresaContaBancaria);

            foreach (EmpresaContaBancaria itemConta in lstContas.OrderBy(X => X.Banco).ToList())
                itemConta.Banco = "BANCO: " + itemConta.Banco + " - AGÊNCIA: " + itemConta.Agencia + " - CONTA: " + itemConta.Conta + " ( " + itemConta.TipoConta + " )";

            return lstContas;
        }

        private List<_Transacao> AtualizarContasBancarias(int idEmpresa, List<EmpresaContaBancaria> lstContas)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParam = new Dictionary<string, string>();

            foreach (EmpresaContaBancaria itemConta in lstContas)
            {
                lstParam = new Dictionary<string, string>();

                itemConta.idEmpresa = idEmpresa;

                if (itemConta.Excluir == true)
                {
                    lstParam.Add("@idContaBancaria", itemConta.idContaBancaria.ToString());
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_EMPRESAS_CONTASBANCARIAS_EXCLUIR",
                        lstParametros = lstParam
                    });
                }
                else if (itemConta.idContaBancaria == 0)
                {
                    lstParam = MontarParametrosExecutarContaBancaria(itemConta);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_EMPRESAS_CONTASBANCARIAS_INCLUIR",
                        lstParametros = lstParam
                    });
                }
                else
                {
                    lstParam = MontarParametrosExecutarContaBancaria(itemConta);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_EMPRESAS_CONTASBANCARIAS_ALTERAR",
                        lstParametros = lstParam
                    });
                }
            }

            return lstComandos;
        }

        #endregion


       
    }
}
