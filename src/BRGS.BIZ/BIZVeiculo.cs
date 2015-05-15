using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZVeiculo
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        #region Veículos
        
        private Dictionary<string, string> MontarParametrosPesquisar(Veiculo veiculo)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idVeiculo", veiculo.idVeiculo.Equals(0) ? null : veiculo.idVeiculo.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(veiculo.Descricao) ? null : veiculo.Descricao);
            lstParametros.Add("@UnitTest", veiculo.UnitTest.Equals(0) ? null : veiculo.UnitTest.ToString());
        
            return lstParametros;
        }
        
        private Dictionary<string, string> MontarParametrosExecutar(Veiculo veiculo)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idVeiculo", veiculo.idVeiculo.ToString());
            lstParametros.Add("@Descricao", veiculo.Descricao.ToString());
            lstParametros.Add("@Placa", veiculo.Placa.ToString());
            lstParametros.Add("@Ano", veiculo.Ano.ToString());
            lstParametros.Add("@Modelo", veiculo.Modelo.ToString());
            lstParametros.Add("@Chassi", veiculo.Chassi.ToString());
            lstParametros.Add("@Cor", veiculo.Cor.ToString());
            lstParametros.Add("@Rastreador", veiculo.Rastreador.ToString());
            lstParametros.Add("@SemParar", veiculo.semParar.ToString());
            lstParametros.Add("@Seguradora", veiculo.Seguradora.ToString());
            lstParametros.Add("@DataVencimentoSeguro", veiculo.dataVencimentoSeguro == DateTime.MinValue ? "01/01/1753 00:00:00.000" : veiculo.dataVencimentoSeguro.Date.ToString());
            lstParametros.Add("@Renavam", veiculo.Renavam.ToString());
            lstParametros.Add("@DataVencimentoIPVA", veiculo.dataVencimentoIPVA == DateTime.MinValue ? "01/01/1753 00:00:00.000" : veiculo.dataVencimentoIPVA.Date.ToString());
            lstParametros.Add("@DataVencimentoDPVAT", veiculo.dataVencimentoDPVAT == DateTime.MinValue ? "01/01/1753 00:00:00.000" : veiculo.dataVencimentoDPVAT.Date.ToString());
            lstParametros.Add("@UnitTest", veiculo.UnitTest.ToString());

            return lstParametros;
        }

        public List<Veiculo> PesquisarVeiculos(Veiculo veiculo)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            try
            {
                lstParametros = MontarParametrosPesquisar(veiculo);

                using (DataSet ds = dao.Pesquisar("SP_VEICULOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Veiculo itemVeiculo = new Veiculo();
                        itemVeiculo.idVeiculo = int.Parse(dr["idVeiculo"].ToString());
                        itemVeiculo.Descricao = dr["Descricao"].ToString();
                        itemVeiculo.Placa = dr["Placa"].ToString();
                        itemVeiculo.Ano = int.Parse(dr["Ano"].ToString());
                        itemVeiculo.Modelo = int.Parse(dr["Modelo"].ToString());
                        itemVeiculo.Chassi = dr["Chassi"].ToString();
                        itemVeiculo.Cor = dr["Cor"].ToString();
                        itemVeiculo.Rastreador = dr["Rastreador"].ToString();
                        itemVeiculo.semParar = int.Parse(dr["SemParar"].ToString());
                        itemVeiculo.Seguradora = dr["Seguradora"].ToString();
                        itemVeiculo.dataVencimentoSeguro = DateTime.Parse(dr["DataVencimentoSeguro"].ToString());
                        itemVeiculo.dataVencimentoIPVA = DateTime.Parse(dr["DataVencimentoIPVA"].ToString());
                        itemVeiculo.dataVencimentoDPVAT = DateTime.Parse(dr["DataVencimentoDPVAT"].ToString());
                        itemVeiculo.Renavam = dr["Renavam"].ToString();
                        itemVeiculo.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        itemVeiculo.lstAbastecimentos = this.PesquisarAbastecimentos(new Abastecimento() { idVeiculo = itemVeiculo.idVeiculo });
                        itemVeiculo.lstManutencoes = this.PesquisarManutencoes(new Manutencao() {idVeiculo = itemVeiculo.idVeiculo});
                        lstVeiculos.Add(itemVeiculo);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_VEICULOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstVeiculos;
        }

        public List<Veiculo> PesquisarVeiculoCombo()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Veiculo> lstVeiculos = new List<Veiculo>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_VEICULOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Veiculo veiculoItem = new Veiculo();
                        veiculoItem.idVeiculo = int.Parse(dr["idVeiculo"].ToString());
                        veiculoItem.Placa = dr["Placa"].ToString() + " - " + dr["Descricao"].ToString();
                        lstVeiculos.Add(veiculoItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_OBRAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstVeiculos.OrderBy(x => x.Placa).ToList();
        }

        public DataTable GerarAutorizacao(Abastecimento abastecimento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            DataTable dtAbastecimento = new DataTable();
            
            try
            {
                lstParametros.Add("@idAbastecimento", abastecimento.idAbastecimento.ToString());
                using (DataSet ds = dao.Pesquisar("SP_ABASTECIMENTOS_EMISSAO", lstParametros))
                {
                    dtAbastecimento = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ABASTECIMENTOS_EMISSAO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return dtAbastecimento;
        }    

        private string ValidarCamposObrigatoriosVeiculo(Veiculo veiculo)
        {
            string Msg = string.Empty;

            if (string.IsNullOrEmpty(veiculo.Descricao))
                Msg += Environment.NewLine + "Descrição do Veiculo não preenchida";

            if (string.IsNullOrEmpty(veiculo.Placa))
                Msg += Environment.NewLine + "Placa do Veiculo não preenchida";

            return Msg;
        }

        public string IncluirVeiculo(Veiculo veiculo, out int idVeiculo)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosVeiculo(veiculo);
                idVeiculo = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(veiculo);
                    using (DataSet ds = dao.Pesquisar("SP_VEICULOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idVeiculo = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_VEICULOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarVeiculo(Veiculo veiculo)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosVeiculo(veiculo);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(veiculo);
                    dao.Executar("SP_VEICULOS_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_VEICULOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public List<_Transacao> AtualizarAbastecimentosOrdemPagamento(int idOP, List<Abastecimento> lstAbastecimentos)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (Abastecimento itemAbastecimento in lstAbastecimentos)
            {
                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idAbastecimento", itemAbastecimento.idAbastecimento.ToString());
                lstParametros.Add("@idOrdemPagamento", idOP.ToString());
                lstParametros.Add("@UnitTest", itemAbastecimento.UnitTest.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_ABASTECIMENTOS_ATUALIZAROP",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public void ExcluirVeiculoTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_VEICULOS_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_VEICULOS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string ValidarExclusaoVeiculo(Veiculo veiculo)
        {
            string Msg = string.Empty;

            return Msg;
        }

        public string ExcluirVeiculo(Veiculo veiculo)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusaoVeiculo(veiculo);

                if (Msg == string.Empty)
                {
                    lstParametros.Add("@idVeiculo", veiculo.idVeiculo.ToString());
                    dao.Executar("SP_VEICULOS_EXCLUIR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_VEICULOS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }        

        #endregion

        #region Abastecimentos
        
        private Dictionary<string, string> MontarParametrosPesquisarAbastecimentos(Abastecimento abastecimento)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idAbastecimento", abastecimento.idAbastecimento.Equals(0) ? null : abastecimento.idAbastecimento.ToString());
            lstParametros.Add("@NumeroAbastecimento", string.IsNullOrEmpty(abastecimento.numeroAbastecimento) ? null : abastecimento.numeroAbastecimento);
            lstParametros.Add("@NomePosto", string.IsNullOrEmpty(abastecimento.nomeFornecedor) ? null : abastecimento.nomeFornecedor);
            lstParametros.Add("@Placa", string.IsNullOrEmpty(abastecimento.placaVeiculo) ? null : abastecimento.placaVeiculo);
            lstParametros.Add("@Motorista", string.IsNullOrEmpty(abastecimento.nomeMotorista) ? null : abastecimento.nomeMotorista);            
            lstParametros.Add("@UnitTest", abastecimento.UnitTest.Equals(0) ? null : abastecimento.UnitTest.ToString());
           
            return lstParametros;
        }
        
        private Dictionary<string, string> MontarParametrosExecutarAbastecimento(Abastecimento abastecimento)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idAbastecimento", abastecimento.idAbastecimento.ToString());
            lstParametros.Add("@NumeroAbastecimento", abastecimento.numeroAbastecimento);
            lstParametros.Add("@idFornecedor", abastecimento.idFornecedor.ToString());            
            lstParametros.Add("@idVeiculo", abastecimento.idVeiculo.ToString());
            lstParametros.Add("@idMotorista", abastecimento.idMotorista.ToString());
            lstParametros.Add("@idObraEtapaGastoRealizado", abastecimento.idObraEtapaGastoRealizado.ToString());            
            lstParametros.Add("@idOP", abastecimento.idOP.ToString());            
            lstParametros.Add("@idObraEtapa", abastecimento.idObraEtapa.ToString());            
            lstParametros.Add("@idUEN", abastecimento.idUEN.ToString());            
            lstParametros.Add("@idCentroCusto", abastecimento.idCentroCusto.ToString());            
            lstParametros.Add("@idDespesa", abastecimento.idDespesa.ToString());
            lstParametros.Add("@idEmissor", abastecimento.idEmissor.ToString());   
            lstParametros.Add("@Data", abastecimento.Data.Date.ToString());
            lstParametros.Add("@Valor", abastecimento.Valor.ToString());
            lstParametros.Add("@Desconto", abastecimento.Desconto.ToString());
            lstParametros.Add("@Kilometragem", abastecimento.Kilometragem.ToString());
            lstParametros.Add("@Litros", abastecimento.Litros.ToString());            
            lstParametros.Add("@UnitTest", abastecimento.UnitTest.ToString());

            return lstParametros;
        }

        public List<Abastecimento> PesquisarAbastecimentos(Abastecimento abastecimento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Abastecimento> lstAbastecimentos = new List<Abastecimento>();
            dynamic lst = new List<Abastecimento>();
            try
            {
                lstParametros = MontarParametrosPesquisarAbastecimentos(abastecimento);

                using (DataSet ds = dao.Pesquisar("SP_ABASTECIMENTOS_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Abastecimento>()
                          select f;
                }

                lstAbastecimentos.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ABASTECIMENTOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstAbastecimentos;
        }

        private string ValidarCamposObrigatoriosAbastecimento(Abastecimento abastecimento)
        {
            string Msg = string.Empty;

            if (abastecimento.idVeiculo == 0)
                Msg += Environment.NewLine + "Favor selecionar o Veículo";

            if (abastecimento.idFornecedor == 0)
                Msg += Environment.NewLine + "Favor selecionar o Posto de Combustível";

            if (abastecimento.idMotorista == 0)
                Msg += Environment.NewLine + "Favor selecionar o Motorista";

            if (abastecimento.idUEN == 0)
                Msg += Environment.NewLine + "Favor selecionar a UEN";

            if (abastecimento.idCentroCusto == 0)
                Msg += Environment.NewLine + "Favor selecionar o Centro de Custo";

            if (abastecimento.idDespesa == 0)
                Msg += Environment.NewLine + "Favor selecionar a Despesa";

            return Msg;
        }

        public string IncluirAbastecimentos(Abastecimento abastecimento, out int idAbastecimento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosAbastecimento(abastecimento);
                idAbastecimento = 0;

                if (Msg == string.Empty)
                {
                    using (DataSet ds = dao.Pesquisar("SP_ABASTECIMENTOS_NOVONUMEROABASTECIMENTO", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        abastecimento.numeroAbastecimento = dr[0].ToString();
                    }

                    lstParametros = MontarParametrosExecutarAbastecimento(abastecimento);
                    
                    using (DataSet ds = dao.Pesquisar("SP_ABASTECIMENTOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idAbastecimento = int.Parse(dr[0].ToString());
                    }
                }                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ABASTECIMENTOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarAbastecimento(Abastecimento abastecimento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosAbastecimento(abastecimento);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarAbastecimento(abastecimento);
                    dao.Executar("SP_ABASTECIMENTOS_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ABASTECIMENTOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirAbastecimentoTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_ABASTECIMENTOS_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ABASTECIMENTOS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string ValidarExclusaoAbastecimento(Abastecimento abastecimento)
        {
            string Msg = string.Empty;

            if(abastecimento.idOP > 0)
                Msg += Environment.NewLine + "Já foi gerada uma OP para esse abastecimento";

            return Msg;
        }

        public string ExcluirAbastecimento(Abastecimento abastecimento)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusaoAbastecimento(abastecimento);

                if (Msg == string.Empty)
                {
                    lstParametros.Add("@idAbastecimento", abastecimento.idAbastecimento.ToString());
                    dao.Executar("SP_ABASTECIMENTOS_EXCLUIR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ABASTECIMENTOS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }     

        #endregion

        #region Manutenções

        private Dictionary<string, string> MontarParametrosPesquisarManutencoes(Manutencao manutencao)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idManutencao", manutencao.idManutencao.Equals(0) ? null : manutencao.idManutencao.ToString());
            lstParametros.Add("@idVeiculo", manutencao.idVeiculo.Equals(0) ? null : manutencao.idVeiculo.ToString());
            lstParametros.Add("@NumeroManutencao", string.IsNullOrEmpty(manutencao.numeroManutencao) ? null : manutencao.numeroManutencao);
            lstParametros.Add("@Placa", string.IsNullOrEmpty(manutencao.placaVeiculo) ? null : manutencao.placaVeiculo);
            lstParametros.Add("@UnitTest", manutencao.UnitTest.Equals(0) ? null : manutencao.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarManutencao(Manutencao manutencao)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idManutencao", manutencao.idManutencao.ToString());
            lstParametros.Add("@NumeroManutencao", manutencao.numeroManutencao);
            lstParametros.Add("@idVeiculo", manutencao.idVeiculo.ToString());
            lstParametros.Add("@idOP", manutencao.idOP.ToString());
            lstParametros.Add("@Descricao", manutencao.Descricao);
            lstParametros.Add("@dataManutencao", manutencao.dataManutencao.Date.ToString());
            lstParametros.Add("@Valor", manutencao.Valor.ToString());
            lstParametros.Add("@UnitTest", manutencao.UnitTest.ToString());

            return lstParametros;
        }

        public List<Manutencao> PesquisarManutencoes(Manutencao manutencao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Manutencao> lstManutencoes = new List<Manutencao>();
            dynamic lst = new List<Manutencao>();
            try
            {
                lstParametros = MontarParametrosPesquisarManutencoes(manutencao);

                using (DataSet ds = dao.Pesquisar("SP_MANUTENCOES_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Manutencao>()
                          select f;
                }

                lstManutencoes.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MANUTENCOES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstManutencoes;
        }

        private string ValidarCamposObrigatoriosManutencao(Manutencao manutencao)
        {
            string Msg = string.Empty;

            if (manutencao.idVeiculo == 0)
                Msg += Environment.NewLine + "Favor selecionar o Veículo";

            if (manutencao.Descricao == string.Empty )
                Msg += Environment.NewLine + "Favor informar a Descrição da manutenção";

            if (manutencao.Valor == decimal.Zero)
                Msg += Environment.NewLine + "Favor informar o Valor da manutenção";

            return Msg;
        }

        public string IncluirManutencao(Manutencao manutencao, out int idManutencao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosManutencao(manutencao);
                idManutencao = 0;

                if (Msg == string.Empty)
                {
                    using (DataSet ds = dao.Pesquisar("SP_MANUTENCOES_NOVONUMEROMANUTENCAO", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        manutencao.numeroManutencao = dr[0].ToString();
                    }

                    lstParametros = MontarParametrosExecutarManutencao(manutencao);

                    using (DataSet ds = dao.Pesquisar("SP_MANUTENCOES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idManutencao = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MANUTENCOES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarManutencao(Manutencao manutencao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosManutencao(manutencao);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarManutencao(manutencao);
                    dao.Executar("SP_MANUTENCOES_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MANUTENCOES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void AtualizarManutencaoOrdemPagamento(Manutencao manutencao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idManutencao", manutencao.idManutencao.ToString());
            lstParametros.Add("@idOrdemPagamento", manutencao.idOP.ToString());
            lstParametros.Add("@UnitTest", manutencao.UnitTest.ToString());
            
            try
            {
                dao.Executar("SP_MANUTENCOES_ATUALIZAROP", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MANUTENCOES_ATUALIZAROP",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }        
        }

        public void ExcluirManutencaoTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_MANUTENCOES_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MANUTENCOES_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string ValidarExclusaoManutencao(Manutencao manutencao)
        {
            string Msg = string.Empty;

            if (manutencao.idOP > 0)
                Msg += Environment.NewLine + "Já foi gerada uma OP para essa manutenção";

            return Msg;
        }

        public string ExcluirManutencao(Manutencao manutencao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusaoManutencao(manutencao);

                if (Msg == string.Empty)
                {
                    lstParametros.Add("@idManutencao", manutencao.idManutencao.ToString());
                    dao.Executar("SP_MANUTENCOES_EXCLUIR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MANUTENCOES_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        #endregion

        #region Multas

        private Dictionary<string, string> MontarParametrosPesquisarMultas(Multa multa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idMulta", multa.idMulta.Equals(0) ? null : multa.idMulta.ToString());
            lstParametros.Add("@idGravidade", multa.idGravidade.Equals(0) ? null : multa.idGravidade.ToString());      
            lstParametros.Add("@Codigo", string.IsNullOrEmpty(multa.Codigo) ? null : multa.Codigo);
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(multa.Descricao) ? null : multa.Descricao);
            lstParametros.Add("@UnitTest", multa.UnitTest.Equals(0) ? null : multa.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarMulta(Multa multa)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idMulta", multa.idMulta.ToString());
            lstParametros.Add("@idGravidade", multa.idGravidade.ToString());
            lstParametros.Add("@Codigo", multa.Codigo);
            lstParametros.Add("@Desdobramento", multa.Desdobramento.ToString());
            lstParametros.Add("@Descricao", multa.Descricao);
            lstParametros.Add("@Infrator", multa.Infrator);
            lstParametros.Add("@Pontos", multa.Pontos.ToString());
            lstParametros.Add("@OrgaoCompetente", multa.orgaoCompetente);
            lstParametros.Add("@UnitTest", multa.UnitTest.ToString());

            return lstParametros;
        }

        public List<Multa> PesquisarMultas(Multa multa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Multa> lstMultas = new List<Multa>();
            dynamic lst = new List<Multa>();
            try
            {
                lstParametros = MontarParametrosPesquisarMultas(multa);

                using (DataSet ds = dao.Pesquisar("SP_MULTAS_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Multa>()
                          select f;
                }

                lstMultas.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstMultas;
        }

        private string ValidarCamposObrigatoriosMulta(Multa multa)
        {
            string Msg = string.Empty;

            if (multa.idGravidade == 0)
                Msg += Environment.NewLine + "Favor selecionar a Gravidade da Multa";
            
            if (multa.Codigo == string.Empty)
                Msg += Environment.NewLine + "Favor informar o Código da Multa";

            if (multa.Descricao == string.Empty)
                Msg += Environment.NewLine + "Favor informar a Descrição da Multa";

            if (multa.Infrator == string.Empty)
                Msg += Environment.NewLine + "Favor informar o Infrator da Multa";

            if (multa.Pontos == 0)
                Msg += Environment.NewLine + "Favor informar os Pontos da Multa";

            return Msg;
        }

        public string IncluirMulta(Multa multa, out int idMulta)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosMulta(multa);
                idMulta = 0;

                if (Msg == string.Empty)
                {                   
                    lstParametros = MontarParametrosExecutarMulta(multa);

                    using (DataSet ds = dao.Pesquisar("SP_MULTAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idMulta = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarMulta(Multa multa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosMulta(multa);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarMulta(multa);
                    dao.Executar("SP_MULTAS_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirMultaTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_MULTAS_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTAS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string ExcluirMulta(Multa multa)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                //Msg = this.ValidarExclusaoManutencao(manutencao);

                if (Msg == string.Empty)
                {
                    lstParametros.Add("@idMulta", multa.idMulta.ToString());
                    dao.Executar("SP_MULTAS_EXCLUIR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        #endregion
        
        #region Multas_Gravidade

        private Dictionary<string, string> MontarParametrosPesquisarMultasGravidade(MultaGravidade gravidade)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idGravidade", gravidade.idGravidade.Equals(0) ? null : gravidade.idGravidade.ToString());
            lstParametros.Add("@Descricao", string.IsNullOrEmpty(gravidade.Descricao) ? null : gravidade.Descricao);
            lstParametros.Add("@UnitTest", gravidade.UnitTest.Equals(0) ? null : gravidade.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarMultaGravidade(MultaGravidade gravidade)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idGravidade", gravidade.idGravidade.ToString());
            lstParametros.Add("@Descricao", gravidade.Descricao);            
            lstParametros.Add("@Valor", gravidade.Valor.ToString());
            lstParametros.Add("@UnitTest", gravidade.UnitTest.ToString());

            return lstParametros;
        }

        public List<MultaGravidade> PesquisarMultasGravidade(MultaGravidade gravidade)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<MultaGravidade> lstMultasGravidade = new List<MultaGravidade>();
            dynamic lst = new List<MultaGravidade>();
            try
            {
                lstParametros = MontarParametrosPesquisarMultasGravidade(gravidade);

                using (DataSet ds = dao.Pesquisar("SP_MULTASGRAVIDADE_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<MultaGravidade>()
                          select f;
                }

                lstMultasGravidade.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASGRAVIDADE_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstMultasGravidade;
        }

        private string ValidarCamposObrigatoriosMultaGravidade(MultaGravidade gravidade)
        {
            string Msg = string.Empty;

            if (gravidade.Descricao == string.Empty)
                Msg += Environment.NewLine + "Favor informar a Descrição da Gravidade da Multa";

            if (gravidade.Valor == decimal.Zero)
                Msg += Environment.NewLine + "Favor informar o Valor";

            return Msg;
        }

        public string IncluirMultaGravidade(MultaGravidade gravidade, out int idGravidade)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosMultaGravidade(gravidade);
                idGravidade = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarMultaGravidade(gravidade);

                    using (DataSet ds = dao.Pesquisar("SP_MULTASGRAVIDADE_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idGravidade = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASGRAVIDADE_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarMultaGravidade(MultaGravidade gravidade)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosMultaGravidade(gravidade);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarMultaGravidade(gravidade);
                    dao.Executar("SP_MULTASGRAVIDADE_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASGRAVIDADE_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluirMultaGravidadeTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_MULTASGRAVIDADE_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASGRAVIDADE_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }
        
        public string ExcluirMultaGravidade(MultaGravidade gravidade)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = this.ValidarExclusaoMultaGravidade(gravidade);

                if (Msg == string.Empty)
                {
                    lstParametros.Add("@idGravidade", gravidade.idGravidade.ToString());
                    dao.Executar("SP_MULTASGRAVIDADE_EXCLUIR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASGRAVIDADE_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusaoMultaGravidade(MultaGravidade gravidade)
        {
            List<Multa> lstMultas = new List<Multa>();
            string Msg = string.Empty;

            lstMultas = PesquisarMultas(new Multa() { idGravidade = gravidade.idGravidade });

            if (lstMultas.Count > 0)
                Msg += Environment.NewLine + "Essa gravidade está sendo utilizada no Cadastro de Multas";            

            return Msg;
        }

        #endregion

        #region Uso de Veículos

        private Dictionary<string, string> MontarParametrosPesquisarUso(UsoVeiculo uso)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idUso", uso.idUso.Equals(0) ? null : uso.idUso.ToString());
            lstParametros.Add("@idVeiculo", uso.idVeiculo.Equals(0) ? null : uso.idVeiculo.ToString());
            lstParametros.Add("@Placa", string.IsNullOrEmpty(uso.Placa) ? null : uso.Placa);
            lstParametros.Add("@idMotorista", uso.idMotorista.Equals(0) ? null : uso.idMotorista.ToString());
            lstParametros.Add("@NomeMotorista", string.IsNullOrEmpty(uso.nomeMotorista) ? null : uso.nomeMotorista);
            lstParametros.Add("@DataUso", uso.dataSaida.Equals(DateTime.MinValue) ? null : uso.dataSaida.Date.ToString());
            lstParametros.Add("@UnitTest", uso.UnitTest.Equals(0) ? null : uso.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarUso(UsoVeiculo uso)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idUso", uso.idUso.ToString());
            lstParametros.Add("@idVeiculo", uso.idVeiculo.ToString());
            lstParametros.Add("@idMotorista", uso.idMotorista.ToString());
            lstParametros.Add("@DataSaida", uso.dataSaida.ToString());
            lstParametros.Add("@DataChegada", uso.dataChegada == DateTime.MinValue ? "01/01/1753 00:00:00.000" : uso.dataChegada.ToString());
            lstParametros.Add("@Observacoes", uso.Observacoes);
            lstParametros.Add("@UnitTest", uso.UnitTest.ToString());

            return lstParametros;
        }

        public List<UsoVeiculo> PesquisarUsoVeiculos(UsoVeiculo uso)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UsoVeiculo> lstUso = new List<UsoVeiculo>();
            dynamic lst = new List<UsoVeiculo>();
            try
            {
                lstParametros = MontarParametrosPesquisarUso(uso);

                using (DataSet ds = dao.Pesquisar("SP_USOVEICULOS_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<UsoVeiculo>()
                          select f;
                }

                lstUso.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USOVEICULOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstUso;
        }

        private string ValidarCamposObrigatoriosUso(UsoVeiculo uso)
        {
            string Msg = string.Empty;

            if (uso.idVeiculo == 0)
                Msg += Environment.NewLine + "Favor selecionar o Veículo";

            if (uso.idMotorista == 0)
                Msg += Environment.NewLine + "Favor selecionar o Motorista";

            return Msg;
        }

        public string IncluirUsoVeiculo(UsoVeiculo uso, out int idUso)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosUso(uso);
                idUso = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarUso(uso);

                    using (DataSet ds = dao.Pesquisar("SP_USOVEICULOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idUso = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USOVEICULOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarUsoVeiculo(UsoVeiculo uso)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosUso(uso);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarUso(uso);
                    dao.Executar("SP_USOVEICULOS_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USOVEICULOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void ExcluiUsoVeiculoTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_USOVEICULOS_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USOVEICULOS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string ExcluirUsoVeiculo(UsoVeiculo uso)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {                
                lstParametros.Add("@idUso", uso.idUso.ToString());
                dao.Executar("SP_USOVEICULOS_EXCLUIR", lstParametros);
                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USOVEICULOS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }      

        #endregion

        #region Ocorrêrncias de Multas

        private Dictionary<string, string> MontarParametrosPesquisarMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idOcorrencia", ocorrencia.idOcorrencia.Equals(0) ? null : ocorrencia.idOcorrencia.ToString());
            lstParametros.Add("@CodigoMulta", string.IsNullOrEmpty(ocorrencia.codigoMulta) ? null : ocorrencia.codigoMulta);
            lstParametros.Add("@NomeMotorista", string.IsNullOrEmpty(ocorrencia.nomeMotorista) ? null : ocorrencia.nomeMotorista);
            lstParametros.Add("@Placa", string.IsNullOrEmpty(ocorrencia.Placa) ? null : ocorrencia.Placa);
            lstParametros.Add("@DataMulta", ocorrencia.dataMulta.Equals(DateTime.MinValue) ? null : ocorrencia.dataMulta.Date.ToString());
            lstParametros.Add("@UnitTest", ocorrencia.UnitTest.Equals(0) ? null : ocorrencia.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idOcorrencia", ocorrencia.idOcorrencia.ToString());
            lstParametros.Add("@idMulta", ocorrencia.idMulta.ToString());
            lstParametros.Add("@idVeiculo", ocorrencia.idVeiculo.ToString());
            lstParametros.Add("@idMotorista", ocorrencia.idMotorista.ToString());

            lstParametros.Add("@DataMulta", ocorrencia.dataMulta.ToString());
            lstParametros.Add("@UnitTest", ocorrencia.UnitTest.ToString());

            return lstParametros;
        }

        public List<MultaOcorrencia> PesquisarMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<MultaOcorrencia> lstMultaOcorrencia = new List<MultaOcorrencia>();
            dynamic lst = new List<MultaOcorrencia>();
            try
            {
                lstParametros = MontarParametrosPesquisarMultaOcorrencia(ocorrencia);

                using (DataSet ds = dao.Pesquisar("SP_MULTASOCORRENCIAS_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<MultaOcorrencia>()
                          select f;
                }

                lstMultaOcorrencia.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASOCORRENCIAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstMultaOcorrencia;
        }

        private string ValidarCamposObrigatoriosMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            string Msg = string.Empty;

            if (ocorrencia.idMotorista == 0)
                Msg += Environment.NewLine + "Favor selecionar a Multa";

            if (ocorrencia.idVeiculo == 0)
                Msg += Environment.NewLine + "Favor selecionar o Veículo";

            if (ocorrencia.idMotorista == 0)
                Msg += Environment.NewLine + "Favor selecionar o Motorista";

            return Msg;
        }

        public string IncluirMultaOcorrencia(MultaOcorrencia ocorrencia, out int idOcorrencia)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosMultaOcorrencia(ocorrencia);
                idOcorrencia = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarMultaOcorrencia(ocorrencia);

                    using (DataSet ds = dao.Pesquisar("SP_MULTASOCORRENCIAS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idOcorrencia = int.Parse(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASOCORRENCIAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatoriosMultaOcorrencia(ocorrencia);

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutarMultaOcorrencia(ocorrencia);
                    dao.Executar("SP_MULTASOCORRENCIAS_ALTERAR", lstParametros);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASOCORRENCIAS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void AtualizarMultaOcorrenciaOrdemPagamento(MultaOcorrencia ocorrencia)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros = new Dictionary<string, string>();
            lstParametros.Add("@idOcorrencia", ocorrencia.idOcorrencia.ToString());
            lstParametros.Add("@idOrdemPagamento", ocorrencia.idOP.ToString());
            
            try
            {
                dao.Executar("SP_MULTASOCORRENCIAS_ATUALIZAROP", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASOCORRENCIAS_ATUALIZAROP",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void ExcluiMultaOcorrenciaTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            string Msg = string.Empty;

            try
            {
                dao.Executar("SP_MULTASOCORRENCIAS_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASOCORRENCIAS_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string ValidarExclusaoMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            string Msg = string.Empty;

            if (ocorrencia.idOP > 0)
                Msg += Environment.NewLine + "Já foi gerada uma OP para essa Ocorrência de Multa";

            return Msg;
        }

        public string ExcluirMultaOcorrencia(MultaOcorrencia ocorrencia)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {                
                lstParametros.Add("@idOcorrencia", ocorrencia.idOcorrencia.ToString());
                dao.Executar("SP_MULTASOCORRENCIAS_EXCLUIR", lstParametros);                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_MULTASOCORRENCIAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }      

        #endregion
    }
}