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

        private Dictionary<string, string> MontarParametrosManutencaoExecutar(GeradorManutencao e)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", e.ID.ToString() },
                { "@IdGerador", e.IdGerador.ToString() },
                { "@Data", e.Data.Date.ToString() },
                { "@Valor", e.Valor.ToString() },
                { "@Descricao", e.Descricao }
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Gerador gerador)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", gerador.ID.ToString() },
                { "@IdEmpresa", gerador.IdEmpresa.Equals(0) ? string.Empty : gerador.IdEmpresa.ToString() },
                { "@IdCliente", gerador.IdCliente.Equals(0) ? string.Empty : gerador.IdCliente.ToString() },
                { "@IdObraEtapa", gerador.IdObraEtapa.Equals(0) ? string.Empty : gerador.IdObraEtapa.ToString() },
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

        private Dictionary<string, string> MontarParametrosPesquisarManutencao(GeradorManutencao e)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", e.ID.Equals(0) ? null : e.ID.ToString() },
                { "@IdGerador", e.IdGerador.Equals(0) ? null : e.IdGerador.ToString() },
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarGeradores(Gerador gerador)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", gerador.ID.Equals(0) ? null : gerador.ID.ToString() },
                { "@IdEmpresa", gerador.IdEmpresa.Equals(0) ? null : gerador.IdEmpresa.ToString() },
                { "@IdCliente", gerador.IdCliente.Equals(0) ? null : gerador.IdCliente.ToString() },
                { "@IdObraEtapa", gerador.IdObraEtapa.Equals(0) ? null : gerador.IdObraEtapa.ToString() },
                { "@NumeroSerie", string.IsNullOrEmpty(gerador.NumeroSerie) ? null : gerador.NumeroSerie },
                { "@Combustivel", string.IsNullOrEmpty(gerador.Combustivel) ? null : gerador.Combustivel },
                { "@Modelo", string.IsNullOrEmpty(gerador.Modelo) ? null : gerador.Modelo },
                { "@Marca", string.IsNullOrEmpty(gerador.Marca) ? null : gerador.Marca },
                { "@Lotado", string.IsNullOrEmpty(gerador.Lotado) ? null : gerador.Lotado },
                { "@NotaFiscal", string.IsNullOrEmpty(gerador.NotaFiscal) ? null : gerador.NotaFiscal },
                { "@DataCompra", gerador.DataCompra.Equals(DateTime.MinValue) ? null : gerador.DataCompra.ToString() }
            };

            return lstParametros;
        }

        private string ValidarCamposObrigatorios(Gerador gerador)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(gerador.NumeroSerie))
                Msg += Environment.NewLine + "Número de Série não preenchido";

            if (string.IsNullOrEmpty(gerador.Marca))
                Msg += Environment.NewLine + "Marca não preenchida";

            if (string.IsNullOrEmpty(gerador.Modelo))
                Msg += Environment.NewLine + "Modelo não preenchido";

            if (string.IsNullOrEmpty(gerador.Combustivel))
                Msg += Environment.NewLine + "Combustível não preenchido";

            if (string.IsNullOrEmpty(gerador.Lotado))
                Msg += Environment.NewLine + "Lotado não preenchido";

            if (gerador.IdEmpresa == 0)
                Msg += Environment.NewLine + "Empresa não selecionada";

            return Msg;
        }

        public string IncluirGerador(Gerador gerador, out int ID)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

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

                    lstComandos.AddRange(this.IncluirManutencoes(ID, gerador.lstManutencoes));
                    dao.ExecutarTransacao(lstComandos);
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

        private List<_Transacao> IncluirManutencoes(int id, List<GeradorManutencao> lstManutencoes)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (GeradorManutencao e in lstManutencoes)
            {
                e.IdGerador = id;
                lstParametros = MontarParametrosManutencaoExecutar(e);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_GERADORES_MANUTENCOES_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public string AlterarGerador(Gerador gerador)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(gerador);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(gerador);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_GERADORES_ALTERAR",
                        lstParametros = lstParametros
                    });

                    lstParametros = new Dictionary<string, string>
                    {
                        { "@IdGerador", gerador.ID.ToString() }
                    };

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_GERADORES_MANUTENCOES_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    lstComandos.AddRange(this.IncluirManutencoes(gerador.ID, gerador.lstManutencoes));
                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_GERADORES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ExcluirGerador(Gerador gerador)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                lstParametros = new Dictionary<string, string>
                {
                    { "@IdGerador", gerador.ID.ToString() }
                };

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_GERADORES_MANUTENCOES_EXCLUIR",
                    lstParametros = lstParametros
                });

                lstParametros = new Dictionary<string, string>
                {
                    { "@Id", gerador.ID.ToString() }
                };
                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_GERADORES_EXCLUIR",
                    lstParametros = lstParametros
                });

                dao.ExecutarTransacao(lstComandos);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_GERADORES_EXCLUIR",
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

        public List<GeradorManutencao> PesquisarGeradoresManutencao(GeradorManutencao e)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<GeradorManutencao> lstGeradorManutencao = new List<GeradorManutencao>();
            dynamic lst = new List<GeradorManutencao>();
            try
            {
                lstParametros = MontarParametrosPesquisarManutencao(e);

                using (DataSet ds = dao.Pesquisar("SP_GERADORES_MANUTENCOES_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<GeradorManutencao>()
                          select f;
                }

                lstGeradorManutencao.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_GERADORES_MANUTENCOES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstGeradorManutencao;
        }

        public List<Gerador> PesquisarGeradoresDisponiveisCombo()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Gerador> lstGeradores = new List<Gerador>();
            
            try
            {
                using (DataSet ds = dao.Pesquisar("SP_GERADORES_COMBO_DISPONIVEIS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Gerador e = new Gerador
                        {
                            ID = int.Parse(dr["ID"].ToString()),
                            NumeroSerie = dr["NumeroSerie"].ToString()
                        };
                        lstGeradores.Add(e);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_GERADORES_COMBO_DISPONIVEIS_CONSULTAR",
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
