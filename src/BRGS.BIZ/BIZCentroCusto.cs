using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZCentroCusto
    {
        private BIZLogErro bizLogErro = new BIZLogErro();        
        private Helper helper = new Helper();

        private Dictionary<string, string> MontarParametrosPesquisarCentroCusto(CentroCusto centroCusto)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idCentroCusto", centroCusto.idCentroCusto.Equals(0) ? null : centroCusto.idCentroCusto.ToString());
            lstParametros.Add("@Codigo", string.IsNullOrEmpty(centroCusto.Codigo) ? null : centroCusto.Codigo);
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(centroCusto.Descricao) ? null : centroCusto.Descricao);
            lstParametros.Add("@Administrativo", centroCusto.Administrativo == null ? null : centroCusto.Administrativo.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", centroCusto.UnitTest.Equals(0) ? null : centroCusto.UnitTest.ToString());
            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarDespesas(CentroCustoDespesa despesas)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idCentroCusto", despesas.idCentroCusto.Equals(0) ? null : despesas.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", despesas.idDespesa.Equals(0) ? null : despesas.idDespesa.ToString());
            lstParametros.Add("@idUsuario", UsuarioLogado.idUsuario.ToString());
            lstParametros.Add("@UnitTest", despesas.UnitTest.Equals(0) ? null : despesas.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarCentroCusto(CentroCusto centroCusto)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idCentroCusto", centroCusto.idCentroCusto.ToString());
            lstParametros.Add("@Codigo", centroCusto.Codigo.ToString());
            lstParametros.Add("@Descricao", centroCusto.Descricao);
            lstParametros.Add("@Administrativo", centroCusto.Administrativo.ToString());
            lstParametros.Add("@UnitTest", centroCusto.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarDespesa(CentroCustoDespesa despesa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idCentroCusto", despesa.idCentroCusto.ToString());
            lstParametros.Add("@idDespesa", despesa.idDespesa.ToString());
            lstParametros.Add("@UnitTest", despesa.UnitTest.ToString());

            return lstParametros;
        }

        public List<CentroCusto> PesquisarCentroCusto(CentroCusto custo)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<CentroCusto> lstCentroCusto = new List<CentroCusto>();

            try
            {
                lstParametros = MontarParametrosPesquisarCentroCusto(custo);

                using (DataSet ds = dao.Pesquisar("SP_CENTROSCUSTOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CentroCusto itemCentroCusto = new CentroCusto();
                        itemCentroCusto.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        itemCentroCusto.Codigo = dr["Codigo"].ToString();
                        itemCentroCusto.Descricao =  dr["Descricao"].ToString();
                        itemCentroCusto.Administrativo = int.Parse(dr["Administrativo"].ToString());
                        itemCentroCusto.lstDespesas = this.PesquisarDespesasAssociadas(new CentroCustoDespesa() { idCentroCusto = itemCentroCusto.idCentroCusto });
                        itemCentroCusto.lstUsuarios = this.PesquisarUsuariosAssociados(new UsuarioCentroCusto() { idCentroCusto = itemCentroCusto.idCentroCusto });
                        lstCentroCusto.Add(itemCentroCusto);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CENTROSCUSTOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstCentroCusto;
        }

        private List<UsuarioCentroCusto> PesquisarUsuariosAssociados(UsuarioCentroCusto usuarioCC)
        {
            BIZUsuario bizUsuario = new BIZUsuario();
            List<UsuarioCentroCusto> lstUsuariosCC = new List<UsuarioCentroCusto>();

            lstUsuariosCC = bizUsuario.PesquisarCentroCustoAssociados(usuarioCC);

            return lstUsuariosCC;
        }

        public List<CentroCustoDespesa> PesquisarDespesasAssociadas(CentroCustoDespesa despesa)             
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<CentroCustoDespesa> lstDespesas = new List<CentroCustoDespesa>();
            
            try
            {
                lstParametros = MontarParametrosPesquisarDespesas(despesa);

                using (DataSet ds = dao.Pesquisar("SP_CENTROSCUSTOS_DESPESAS_PESQUISAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CentroCustoDespesa despesaItem = new CentroCustoDespesa();

                        despesaItem.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        despesaItem.descricaoCentroCusto = dr["DescricaoCentroCusto"].ToString();
                        despesaItem.idDespesa = int.Parse(dr["idDespesa"].ToString());
                        despesaItem.descricaoDespesa = dr["DescricaoDespesa"].ToString();                        
                        lstDespesas.Add(despesaItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CENTROSCUSTOS_DESPESAS_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstDespesas;
        }
      
        private string ValidarCamposObrigatorios(CentroCusto centroCusto)
        {
            string Msg = string.Empty;

            if(string.IsNullOrEmpty(centroCusto.Codigo))
                Msg += Environment.NewLine + "Favor informar o Código";

            if(string.IsNullOrEmpty(centroCusto.Descricao))
                Msg += Environment.NewLine + "Favor informar a Descrição";           
                    
            return Msg;
        }

        public string IncluirCentroCusto(int idUsuario, CentroCusto centroCusto, out int idCentroCusto)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosDespesa = new Dictionary<string, string>();
            
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarCamposObrigatorios(centroCusto);
                idCentroCusto = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarCentroCusto(centroCusto);

                    using (DataSet ds = dao.Pesquisar("SP_CENTROSCUSTOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idCentroCusto = int.Parse(dr[0].ToString());
                    }
                    
                    lstComandos.AddRange(this.IncluirDespesas(idCentroCusto, centroCusto.lstDespesas));
                    lstComandos.AddRange(this.IncluirUsuario(idCentroCusto, centroCusto.lstUsuarios));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CENTROSCUSTOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        private List<_Transacao> IncluirDespesas(int idCentroCusto, List<CentroCustoDespesa> lstDespesas)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (CentroCustoDespesa itemDespesa in lstDespesas)
            {
                itemDespesa.idCentroCusto = idCentroCusto;
                lstParametros = MontarParametrosExecutarDespesa(itemDespesa);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_CENTROSCUSTOS_DESPESAS_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        private List<_Transacao> IncluirUsuario(int idCentroCusto, List<UsuarioCentroCusto> lstUsuarios)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (UsuarioCentroCusto itemUsuario in lstUsuarios)
            {
                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idCentroCusto", idCentroCusto.ToString());
                lstParametros.Add("@idUsuario", itemUsuario.idUsuario.ToString());
                lstParametros.Add("@UnitTest", itemUsuario.UnitTest.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_USUARIOSCENTROCUSTO_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public string AlterarCentroCustos(CentroCusto centroCusto)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstExclusao = new Dictionary<string, string>();
            Dictionary<string, string> lstParametrosDespesa = new Dictionary<string, string>();
            
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(centroCusto);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CENTROSCUSTOS_ALTERAR",
                        lstParametros = MontarParametrosExecutarCentroCusto(centroCusto)
                    });

                    lstExclusao.Add("@idCentroCusto", centroCusto.idCentroCusto.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CENTROSCUSTOS_DESPESAS_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOSCENTROCUSTO_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.AddRange(this.IncluirDespesas(centroCusto.idCentroCusto, centroCusto.lstDespesas));
                    lstComandos.AddRange(this.IncluirUsuario(centroCusto.idCentroCusto, centroCusto.lstUsuarios));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CENTROSCUSTOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusao(CentroCusto centroCusto)
        {
            BIZObra bizObra = new BIZObra();
            BIZUEN bizUEN = new BIZUEN();            
            string Msg = string.Empty;
            List<UENCentroCusto> lstCentroCustoAssociado = new List<UENCentroCusto>();            
            List<ObraEtapaGastoRealizado> lstObras = new List<ObraEtapaGastoRealizado>();
            BIZOrdemPagamento bizOP = new BIZOrdemPagamento();
            List<OrdemPagamentoItem> lstOPItens = new List<OrdemPagamentoItem>();

            lstCentroCustoAssociado = bizUEN.PesquisarCentrosCustosAssociados(new UENCentroCusto() { idCentroCusto = centroCusto.idCentroCusto });

            if (lstCentroCustoAssociado.Count > 0)
                Msg += Environment.NewLine + "Este Centro de Custo está associado a alguma UEN";

            lstObras = bizObra.PesquisarGastosRealizados(new ObraEtapaGastoRealizado() { idCentroCusto = centroCusto.idCentroCusto });

            if (lstObras.Count > 0)
                Msg += Environment.NewLine + "Este Centro de Custo está associado a alguma Obra";

            lstOPItens = bizOP.PesquisarOrdemPagamentoItem(new OrdemPagamentoItem() { idCentroCusto = centroCusto.idCentroCusto });

            if (lstOPItens.Count > 0)
                Msg += Environment.NewLine + "Este Centro de Custo está associado a alguma Ordem de Pagamento";            

            return Msg;
        }

        public string ExcluirCentroCusto(CentroCusto centroCusto)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusao(centroCusto);

                if (Msg == string.Empty || centroCusto.UnitTest == 1)
                {
                    lstParametros.Add("@idCentroCusto", centroCusto.idCentroCusto.Equals(0) ? null : centroCusto.idCentroCusto.ToString());
                    lstParametros.Add("@UnitTest", centroCusto.UnitTest.Equals(0) ? null : centroCusto.UnitTest.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CENTROSCUSTOS_DESPESAS_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOSCENTROCUSTO_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CENTROSCUSTOS_EXCLUIR",
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
                    procedureSQL = "SP_CENTROSCUSTOS_EXCLUIR",
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
