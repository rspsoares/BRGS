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

        private Dictionary<string, string> MontarParametrosPesquisarUsos(int idEmpilhadeira)
        {
            var lstParametros = new Dictionary<string, string>
            {                
                { "@IdEmpilhadeira", idEmpilhadeira.ToString() }
            };

            return lstParametros;
        }

        public Dictionary<string, string> MontarParametrosAlocar(Empilhadeira e)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", e.ID.ToString() },
                { "@IdCliente", e.IdCliente.ToString() },
                { "@IdObraEtapa", e.IdObraEtapa.ToString() },
                { "@DataAlocacao", e.DataAlocacao.Date.ToString() }
            };

            return lstParametros;
        }

        public Dictionary<string, string> MontarParametrosLiberar(Empilhadeira e)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", e.ID.ToString() },
                { "@IdCliente", e.IdCliente.ToString() },
                { "@IdObraEtapa", e.IdObraEtapa.ToString() }                
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosManutencaoExecutar(EmpilhadeiraManutencao e)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", e.ID.ToString() },
                { "@IdEmpilhadeira", e.IdEmpilhadeira.ToString() },
                { "@Data", e.Data.Date.ToString() },
                { "@Valor", e.Valor.ToString() },
                { "@Descricao", e.Descricao }
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Empilhadeira empilhadeira)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", empilhadeira.ID.ToString() },
                { "@IdEmpresa", empilhadeira.IdEmpresa.ToString() },
                { "@IdCliente", empilhadeira.IdCliente.ToString() },
                { "@IdObraEtapa", empilhadeira.IdObraEtapa.ToString() },
                { "@NumeroSerie", empilhadeira.NumeroSerie },
                { "@Combustivel", empilhadeira.Combustivel },
                { "@Modelo", empilhadeira.Modelo },
                { "@Marca", empilhadeira.Marca },
                { "@Torre", empilhadeira.Torre.ToString() },
                { "@CapacidadeCarga", empilhadeira.CapacidadeCarga.ToString() },
                { "@Lotada", empilhadeira.Lotada },
                { "@NotaFiscal", empilhadeira.NotaFiscal },
                { "@DataCompra", empilhadeira.DataCompra.Date.ToString() },
                { "@Acessorios", empilhadeira.Acessorios }
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarManutencao(EmpilhadeiraManutencao e)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", e.ID.Equals(0) ? null : e.ID.ToString() },
                { "@IdEmpilhadeira", e.IdEmpilhadeira.Equals(0) ? null : e.IdEmpilhadeira.ToString() },                
            };

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarEmpilhadeiras(Empilhadeira empilhadeira)
        {
            var lstParametros = new Dictionary<string, string>
            {
                { "@Id", empilhadeira.ID.Equals(0) ? null : empilhadeira.ID.ToString() },
                { "@IdEmpresa", empilhadeira.IdEmpresa.Equals(0) ? null : empilhadeira.IdEmpresa.ToString() },
                { "@IdCliente", empilhadeira.IdCliente.Equals(0) ? null : empilhadeira.IdCliente.ToString() },
                { "@IdObraEtapa", empilhadeira.IdObraEtapa.Equals(0) ? null : empilhadeira.IdObraEtapa.ToString() },
                { "@NumeroSerie", string.IsNullOrEmpty(empilhadeira.NumeroSerie) ? null : empilhadeira.NumeroSerie },
                { "@Combustivel", string.IsNullOrEmpty(empilhadeira.Combustivel) ? null : empilhadeira.Combustivel },
                { "@Modelo", string.IsNullOrEmpty(empilhadeira.Modelo) ? null : empilhadeira.Modelo },
                { "@Marca", string.IsNullOrEmpty(empilhadeira.Marca) ? null : empilhadeira.Marca },
                { "@Torre", empilhadeira.Torre.Equals(0) ? null : empilhadeira.Torre.ToString() },
                { "@CapacidadeCarga", empilhadeira.CapacidadeCarga.Equals(0) ? null : empilhadeira.CapacidadeCarga.ToString() },
                { "@Lotada", string.IsNullOrEmpty(empilhadeira.Lotada) ? null : empilhadeira.Lotada },
                { "@NotaFiscal", string.IsNullOrEmpty(empilhadeira.NotaFiscal) ? null : empilhadeira.NotaFiscal },
                { "@DataCompra", empilhadeira.DataCompra.Equals(DateTime.MinValue) ? null : empilhadeira.DataCompra.Date.ToString() }
            };

            return lstParametros;
        }

        public void Alocar(Empilhadeira e)
        {
            DataAccess dao = new DataAccess();            
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            lstParametros = MontarParametrosAlocar(e);

            try
            {
                dao.Executar("SP_EMPILHADEIRAS_ALOCAR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_ALOCAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void Liberar(Empilhadeira e)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros = MontarParametrosLiberar(e);

            try
            {
                dao.Executar("SP_EMPILHADEIRAS_LIBERAR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(new Dictionary<string, string>());

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_LIBERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        private string ValidarCamposObrigatorios(Empilhadeira empilhadeira)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(empilhadeira.NumeroSerie))
                Msg += Environment.NewLine + "Número de Série não preenchido";

            if (string.IsNullOrEmpty(empilhadeira.Marca))
                Msg += Environment.NewLine + "Marca não preenchida";

            if (string.IsNullOrEmpty(empilhadeira.Modelo))
                Msg += Environment.NewLine + "Modelo não preenchido";

            if (string.IsNullOrEmpty(empilhadeira.Combustivel))
                Msg += Environment.NewLine + "Combustível não preenchido";

            if (empilhadeira.Torre == 0)
                Msg += Environment.NewLine + "Altura da Torre não preenchida";

            if (empilhadeira.CapacidadeCarga == 0)
                Msg += Environment.NewLine + "Capacidade de Carga não preenchida";

            if (string.IsNullOrEmpty(empilhadeira.Lotada))
                Msg += Environment.NewLine + "Lotada não preenchido";

            if (empilhadeira.IdEmpresa == 0)
                Msg += Environment.NewLine + "Empresa não selecionada";

            return Msg;
        }

        public string IncluirEmpilhadeira(Empilhadeira empilhadeira, out int ID)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

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

                    lstComandos.AddRange(this.IncluirManutencoes(ID, empilhadeira.lstManutencoes));
                    dao.ExecutarTransacao(lstComandos);               
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

        private List<_Transacao> IncluirManutencoes(int id, List<EmpilhadeiraManutencao> lstManutencoes)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (EmpilhadeiraManutencao e in lstManutencoes)
            {
                e.IdEmpilhadeira = id;
                lstParametros = MontarParametrosManutencaoExecutar(e);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_EMPILHADEIRAS_MANUTENCOES_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public string AlterarEmpilhadeira(Empilhadeira empilhadeira)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(empilhadeira);

                if (Msg == string.Empty)
                {   
                    lstParametros = MontarParametrosExecutar(empilhadeira);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_EMPILHADEIRAS_ALTERAR",
                        lstParametros = lstParametros
                    });

                    lstParametros = new Dictionary<string, string>
                    {
                        { "@IdEmpilhadeira", empilhadeira.ID.ToString() }
                    };

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_EMPILHADEIRAS_MANUTENCOES_EXCLUIR",
                        lstParametros = lstParametros
                    });

                    lstComandos.AddRange(this.IncluirManutencoes(empilhadeira.ID, empilhadeira.lstManutencoes));
                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ExcluirEmpilhadeira(Empilhadeira empilhadeira)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                lstParametros = new Dictionary<string, string>
                {
                    { "@IdEmpilhadeira", empilhadeira.ID.ToString() }
                };

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_EMPILHADEIRAS_MANUTENCOES_EXCLUIR",
                    lstParametros = lstParametros
                });

                lstParametros = new Dictionary<string, string>
                {
                    { "@Id", empilhadeira.ID.ToString() }
                };
                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_EMPILHADEIRAS_EXCLUIR",
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
                    procedureSQL = "SP_EMPILHADEIRAS_EXCLUIR",
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

        public List<EmpilhadeiraUso> PesquisarEmpilhadeirasUsoGrid(int idEmpilhadeira)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<EmpilhadeiraUso> lstEmpilhadeiraUso = new List<EmpilhadeiraUso>();
            dynamic lst = new List<EmpilhadeiraUso>();
            try
            {
                lstParametros = MontarParametrosPesquisarUsos(idEmpilhadeira);

                using (DataSet ds = dao.Pesquisar("SP_EMPILHADEIRAS_USOS_GRID", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<EmpilhadeiraUso>()
                          select f;
                }

                lstEmpilhadeiraUso.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_USOS_GRID",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstEmpilhadeiraUso;
        }

        public List<EmpilhadeiraManutencao> PesquisarEmpilhadeirasManutencao(EmpilhadeiraManutencao e)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<EmpilhadeiraManutencao> lstEmpilhadeiraManutencao = new List<EmpilhadeiraManutencao>();
            dynamic lst = new List<EmpilhadeiraManutencao>();
            try
            {
                lstParametros = MontarParametrosPesquisarManutencao(e);

                using (DataSet ds = dao.Pesquisar("SP_EMPILHADEIRAS_MANUTENCOES_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<EmpilhadeiraManutencao>()
                          select f;
                }

                lstEmpilhadeiraManutencao.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_MANUTENCOES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstEmpilhadeiraManutencao;
        }

        public List<Empilhadeira> PesquisarEmpilhadeirasDisponiveisCombo()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Empilhadeira> lstEmpilhadeiras = new List<Empilhadeira>();
            
            try
            {
                using (DataSet ds = dao.Pesquisar("SP_EMPILHADEIRAS_COMBO_DISPONIVEIS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Empilhadeira e = new Empilhadeira
                        {
                            ID = int.Parse(dr["ID"].ToString()),
                            NumeroSerie = dr["NumeroSerie"].ToString()
                        };
                        lstEmpilhadeiras.Add(e);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_EMPILHADEIRAS_COMBO_DISPONIVEIS_CONSULTAR",
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
