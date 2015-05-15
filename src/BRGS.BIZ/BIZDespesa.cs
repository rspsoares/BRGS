using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZDespesa
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();      

        private Dictionary<string, string> MontarParametrosPesquisar(Despesa despesa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idDespesa", despesa.idDespesa.Equals(0) ? null : despesa.idDespesa.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(despesa.Descricao) ? null : despesa.Descricao);
            lstParametros.Add("@GastoFixo", despesa.gastoFixo == null ? null : despesa.gastoFixo.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", despesa.UnitTest.Equals(0) ? null : despesa.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Despesa despesa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
                        
            lstParametros.Add("@idDespesa", despesa.idDespesa.ToString());
            lstParametros.Add("@Descricao", despesa.Descricao.ToString());
            lstParametros.Add("@GastoFixo", despesa.gastoFixo.ToString());
            lstParametros.Add("@UnitTest", despesa.UnitTest.ToString());

            return lstParametros;
        }

        public List<Despesa> PesquisarDespesa(Despesa despesa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Despesa> lstDespesas = new List<Despesa>();

            try
            {
                lstParametros = MontarParametrosPesquisar(despesa);

                using (DataSet ds = dao.Pesquisar("SP_DESPESAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstDespesas.Add(new Despesa()
                        {
                            idDespesa = int.Parse(dr["idDespesa"].ToString()),
                            Descricao = dr["Descricao"].ToString(),
                            gastoFixo = int.Parse(dr["GastoFixo"].ToString()),
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
                    procedureSQL = "SP_DESPESAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstDespesas;
        }

        private string ValidarCamposObrigatorios(Despesa despesa)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(despesa.Descricao))
                Msg += Environment.NewLine + "Descrição da Despesa não preenchida";

            return Msg;
        }


        public string IncluirDespesa(int idUsuario, Despesa despesa, out int idDespesa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(despesa);
                idDespesa = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(despesa);
                    using (DataSet ds = dao.Pesquisar("SP_DESPESAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idDespesa = int.Parse(dr[0].ToString());
                    }

                    lstParametros = new Dictionary<string, string>();
                    lstParametros.Add("@idUsuario", idUsuario.ToString());
                    lstParametros.Add("@idDespesa", idDespesa.ToString());
                    lstParametros.Add("@UnitTest", despesa.UnitTest.ToString());

                    dao.Executar("SP_USUARIOSDESPESA_INCLUIR", lstParametros);                
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_DESPESAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarDespesa(Despesa despesa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(despesa);                

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(despesa);
                    dao.Executar("SP_DESPESAS_ALTERAR", lstParametros);                   
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_DESPESAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(Despesa despesa)
        {
            BIZCentroCusto bizCentroCusto = new BIZCentroCusto();
            BIZObra bizObra = new BIZObra();
            string Msg = string.Empty;
            List<CentroCustoDespesa> lstDespesaAssociada = new List<CentroCustoDespesa>();
            List<ObraEtapa> lstObras = new List<ObraEtapa>();
            BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
            List<OrdemPagamentoItem> lstOPItens = new List<OrdemPagamentoItem>();

            lstDespesaAssociada = bizCentroCusto.PesquisarDespesasAssociadas(new CentroCustoDespesa() { idDespesa = despesa.idDespesa });

            if(lstDespesaAssociada.Count > 0)
                Msg += Environment.NewLine + "Esta Despesa está associada a algum Centro de Custo";

            lstObras = bizObra.PesquisarObraEtapaDespesa(despesa.idDespesa);

            if (lstObras.Count > 0)
                Msg += Environment.NewLine + "Esta Despesa está associada a alguma Obra";
            
            lstOPItens = bizOP.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idDespesa = despesa.idDespesa });

            if (lstOPItens.Count > 0)
                Msg += Environment.NewLine + "Esta Despesa está associada a alguma Ordem de Pagamento";            

            return Msg;
        }

        public string ExcluirDespesa(Despesa despesa)
        {
            DataAccess dao = new DataAccess();            
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusao(despesa);

                if (Msg == string.Empty || despesa.UnitTest == 1)
                {
                    lstParametros.Add("@idDespesa", despesa.idDespesa.ToString());
                    lstParametros.Add("@UnitTest", despesa.UnitTest.Equals(0) ? null : despesa.UnitTest.ToString());
                    
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CENTROSCUSTOS_DESPESAS_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_DESPESAS_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_DESPESAS_EXCLUIR",
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
