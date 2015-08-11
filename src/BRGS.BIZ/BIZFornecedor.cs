using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZFornecedor
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZAuditoria bizAuditoria = new BIZAuditoria();

        #region Fornecedor

        private Dictionary<string, string> MontarParametrosPesquisar(Fornecedor fornecedor)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFornecedor", fornecedor.idFornecedor.Equals(0) ? null : fornecedor.idFornecedor.ToString());
            lstParametros.Add("@idCategoria", fornecedor.idCategoria.Equals(0) ? null : fornecedor.idCategoria.ToString());
            lstParametros.Add("@idAtividade", fornecedor.idAtividade.Equals(0) ? null : fornecedor.idAtividade.ToString());
            lstParametros.Add("@Codigo", string.IsNullOrEmpty(fornecedor.Codigo) ? null : fornecedor.Codigo);
            lstParametros.Add("@Nome", string.IsNullOrEmpty(fornecedor.Nome) ? null : fornecedor.Nome);
            lstParametros.Add("@CPF_CNPJ", string.IsNullOrEmpty(fornecedor.CPF_CNPJ) ? null : fornecedor.CPF_CNPJ);
            lstParametros.Add("@IE", string.IsNullOrEmpty(fornecedor.IE) ? null : fornecedor.IE);
            lstParametros.Add("@ICM", string.IsNullOrEmpty(fornecedor.ICM) ? null : fornecedor.ICM);
            lstParametros.Add("@Endereco", string.IsNullOrEmpty(fornecedor.Endereco) ? null : fornecedor.Endereco);
            lstParametros.Add("@Complemento", string.IsNullOrEmpty(fornecedor.Complemento) ? null : fornecedor.Complemento);
            lstParametros.Add("@Bairro", string.IsNullOrEmpty(fornecedor.Bairro) ? null : fornecedor.Bairro);
            lstParametros.Add("@Cidade", string.IsNullOrEmpty(fornecedor.Cidade) ? null : fornecedor.Cidade);
            lstParametros.Add("@Estado", string.IsNullOrEmpty(fornecedor.Estado) ? null : fornecedor.Estado);
            lstParametros.Add("@CEP", string.IsNullOrEmpty(fornecedor.CEP) ? null : fornecedor.CEP);
            lstParametros.Add("@Pais", string.IsNullOrEmpty(fornecedor.Pais) ? null : fornecedor.Pais);
            lstParametros.Add("@Telefone", string.IsNullOrEmpty(fornecedor.Telefone) ? null : fornecedor.Telefone);
            lstParametros.Add("@Fax", string.IsNullOrEmpty(fornecedor.Fax) ? null : fornecedor.Fax);
            lstParametros.Add("@Email", string.IsNullOrEmpty(fornecedor.Email) ? null : fornecedor.Email);
            lstParametros.Add("@TipoPessoa", string.IsNullOrEmpty(fornecedor.TipoPessoa) ? null : fornecedor.TipoPessoa);
            lstParametros.Add("@Site", string.IsNullOrEmpty(fornecedor.Site) ? null : fornecedor.Site);
            lstParametros.Add("@Observacao", string.IsNullOrEmpty(fornecedor.Observacao) ? null : fornecedor.Observacao);
            lstParametros.Add("@Status", string.IsNullOrEmpty(fornecedor.Status) ? null : fornecedor.Status);
            lstParametros.Add("@UnitTest", fornecedor.UnitTest.Equals(0) ? null : fornecedor.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Fornecedor fornecedor)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFornecedor", fornecedor.idFornecedor.ToString());
            lstParametros.Add("@idCategoria", fornecedor.idCategoria.ToString());
            lstParametros.Add("@idAtividade", fornecedor.idAtividade.ToString());
            lstParametros.Add("@Codigo", fornecedor.Codigo);
            lstParametros.Add("@Nome", fornecedor.Nome);
            lstParametros.Add("@CPF_CNPJ", fornecedor.CPF_CNPJ);
            lstParametros.Add("@IE", fornecedor.IE);
            lstParametros.Add("@ICM", fornecedor.ICM);
            lstParametros.Add("@Endereco", fornecedor.Endereco);
            lstParametros.Add("@Complemento", fornecedor.Complemento);
            lstParametros.Add("@Bairro", fornecedor.Bairro);
            lstParametros.Add("@Cidade", fornecedor.Cidade);
            lstParametros.Add("@Estado", fornecedor.Estado);
            lstParametros.Add("@CEP", fornecedor.CEP);
            lstParametros.Add("@Pais", fornecedor.Pais);
            lstParametros.Add("@Telefone", fornecedor.Telefone);
            lstParametros.Add("@Fax", fornecedor.Fax);
            lstParametros.Add("@Email", fornecedor.Email);
            lstParametros.Add("@TipoPessoa", fornecedor.TipoPessoa);
            lstParametros.Add("@Site", fornecedor.Site);            
            lstParametros.Add("@Observacao", fornecedor.Observacao);
            lstParametros.Add("@Status", fornecedor.Status);
            lstParametros.Add("@UnitTest", fornecedor.UnitTest.ToString());

            return lstParametros;
        }

        public List<Fornecedor> PesquisarFornecedor(Fornecedor fornecedor)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();       
            dynamic lst = new List<Fornecedor>();
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
          
            try
            {
                lstParametros = MontarParametrosPesquisar(fornecedor);

                using (DataSet ds = dao.Pesquisar("SP_FORNECEDORES_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Fornecedor>()                               
                                      select f;
                }

                lstFornecedores.AddRange(lst);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstFornecedores; 
        }

        public List<Fornecedor> PesquisarFornecedorCombo(Fornecedor fornecedor)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();       
            dynamic lst = new List<Fornecedor>();
            List<Fornecedor> lstFornecedores = new List<Fornecedor>();
          
            try
            {
                lstParametros = MontarParametrosPesquisar(fornecedor);

                using (DataSet ds = dao.Pesquisar("SP_FORNECEDORES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Fornecedor itemFornecedor = new Fornecedor();
                        itemFornecedor.idFornecedor = int.Parse(dr["idFornecedor"].ToString());
                        itemFornecedor.Nome = dr["Status"].ToString() == "ATIVO" ? dr["Nome"].ToString() : dr["Nome"].ToString() + " (INATIVO)";

                        lstFornecedores.Add(itemFornecedor);
                    }
                }                
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstFornecedores; 
        }

        private string ValidarCamposObrigatorios(Fornecedor fornecedor)
        {
            string Msg = string.Empty;
            List<Fornecedor> fornecedorDuplicado = new List<Fornecedor>();
            
            if (string.IsNullOrEmpty(fornecedor.Nome))
                Msg += Environment.NewLine + "Nome do Fornecedor não preenchido";

            if (string.IsNullOrEmpty(fornecedor.CPF_CNPJ) || (!helper.ValidarCPF(fornecedor.CPF_CNPJ) && !helper.ValidarCNPJ(fornecedor.CPF_CNPJ)))
                Msg += Environment.NewLine + "Favor informar um CPF / CNPJ válido";

            if (string.IsNullOrEmpty(fornecedor.Status))
                Msg += Environment.NewLine + "Favor selecionar o Status do Fornecedor";

            if (!string.IsNullOrEmpty(fornecedor.Email) && !helper.ValidarEmail(fornecedor.Email))
                Msg += Environment.NewLine + "E-mail inválido";

            if (fornecedor.idFornecedor == 0 && fornecedor.UnitTest == 0)
            {
                fornecedorDuplicado = this.PesquisarFornecedor(new Fornecedor() { Nome = fornecedor.Nome, CPF_CNPJ = fornecedor.CPF_CNPJ });
                if (fornecedorDuplicado.Count > 0)
                    Msg += Environment.NewLine + "Já existe um fornecedor com esse Nome e com esse CPF / CNPJ";
            }

            return Msg;
        }

        public string IncluirFornecedor(Fornecedor fornecedor, out int idFornecedor)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(fornecedor);
                idFornecedor = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(fornecedor);
                    using (DataSet ds = dao.Pesquisar("SP_FORNECEDORES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idFornecedor = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(this.IncluirContato(idFornecedor, fornecedor.lstContatos));

                    //lstComandos.AddRange(this.AtualizarContasBancarias(idFornecedor, fornecedor.lstContasBancarias));

                    dao.ExecutarTransacao(lstComandos);

                    fornecedor.idFornecedor = idFornecedor;
                    bizAuditoria.GerarAuditoriaFornecedor(new Fornecedor(), fornecedor, "INCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarFornecedor(Fornecedor fornecedorOriginal, Fornecedor fornecedorSelecionado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstContatos = new Dictionary<string, string>();
            Dictionary<string, string> lstContasBancarias = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(fornecedorSelecionado);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_FORNECEDORES_ALTERAR",
                        lstParametros = MontarParametrosExecutar(fornecedorSelecionado)
                    });

                    lstContatos.Add("@idFornecedor", fornecedorSelecionado.idFornecedor.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_FORNECEDORES_CONTATOS_EXCLUIR",
                        lstParametros = lstContatos
                    });

                    lstComandos.AddRange(this.IncluirContato(fornecedorSelecionado.idFornecedor, fornecedorSelecionado.lstContatos));

                   // lstComandos.AddRange(this.AtualizarContasBancarias(fornecedorSelecionado.idFornecedor, fornecedorSelecionado.lstContasBancarias));

                    dao.ExecutarTransacao(lstComandos);

                    bizAuditoria.GerarAuditoriaFornecedor(fornecedorOriginal, fornecedorSelecionado, "ALTERAÇÃO");     
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusaoFornecedor(Fornecedor fornecedor)
        {
            string msg = string.Empty;
            BIZOrdemPagamento bizOP = new BIZOrdemPagamento();

            if (bizOP.PesquisarOrdemPagamento(new OrdemPagamento() { idFavorecido = fornecedor.idFornecedor }).Count > 0)
                msg = Environment.NewLine + "Este Fornecedor está sendo utilizado em alguma Ordem de Pagamento";

            return msg;
        }

        public void ExcluirFornecedor(Fornecedor fornecedor)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idFornecedor", fornecedor.idFornecedor.ToString());
                dao.Executar("SP_FORNECEDORES_EXCLUIR", lstParametros);
                bizAuditoria.GerarAuditoriaFornecedor(fornecedor, fornecedor, "EXCLUSÃO");
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void ExcluirFornecedorTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();            

            try
            {
                dao.Executar("SP_FORNECEDORES_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        #endregion

        #region Contatos

        private Dictionary<string, string> MontarParametrosPesquisarContato(FornecedorContato fornecedorContato)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFornecedor", fornecedorContato.idFornecedor.Equals(0) ? null : fornecedorContato.idFornecedor.ToString());
            lstParametros.Add("@Nome", string.IsNullOrEmpty(fornecedorContato.Nome) ? null : fornecedorContato.Nome);
            lstParametros.Add("@UnitTest", fornecedorContato.UnitTest.Equals(0) ? null : fornecedorContato.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarContato(FornecedorContato fornecedorContato)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFornecedor", fornecedorContato.idFornecedor.ToString());
            lstParametros.Add("@Nome", fornecedorContato.Nome);
            lstParametros.Add("@Telefone", fornecedorContato.Telefone);
            lstParametros.Add("@Email", fornecedorContato.Email);
            lstParametros.Add("@UnitTest", fornecedorContato.UnitTest.ToString());

            return lstParametros;
        }

        public List<FornecedorContato> PesquisarFornecedorContato(FornecedorContato fornecedorContato)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<FornecedorContato> lstContatos = new List<FornecedorContato>();

            try
            {
                lstParametros = MontarParametrosPesquisarContato(fornecedorContato);

                using (DataSet ds = dao.Pesquisar("SP_FORNECEDORES_CONTATOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FornecedorContato itemContato = new FornecedorContato();
                        itemContato.idFornecedor = int.Parse(dr["idFornecedor"].ToString());
                        itemContato.Nome = dr["Nome"].ToString();
                        itemContato.Telefone = dr["Telefone"].ToString();
                        itemContato.Email = dr["Email"].ToString();
                        lstContatos.Add(itemContato);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_CONTATOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstContatos;
        }

        private List<_Transacao> IncluirContato(int idFornecedor, List<FornecedorContato> lstContato)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (FornecedorContato itemContato in lstContato)
            {
                itemContato.idFornecedor = idFornecedor;
                lstParametros = MontarParametrosExecutarContato(itemContato);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_FORNECEDORES_CONTATOS_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        #endregion

        #region Contas Bancárias

        private Dictionary<string, string> MontarParametrosPesquisarContaBancaria(FornecedorContaBancaria fornecedorContaBancaria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idContaBancaria", fornecedorContaBancaria.idContaBancaria.Equals(0) ? null : fornecedorContaBancaria.idContaBancaria.ToString());
            lstParametros.Add("@idFornecedor", fornecedorContaBancaria.idFornecedor.Equals(0) ? null : fornecedorContaBancaria.idFornecedor.ToString());
            lstParametros.Add("@UnitTest", fornecedorContaBancaria.UnitTest.Equals(0) ? null : fornecedorContaBancaria.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarContaBancaria(FornecedorContaBancaria fornecedorContaBancaria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idContaBancaria", fornecedorContaBancaria.idContaBancaria.ToString());
            lstParametros.Add("@idFornecedor", fornecedorContaBancaria.idFornecedor.ToString());
            lstParametros.Add("@Banco", fornecedorContaBancaria.Banco);
            lstParametros.Add("@Agencia", fornecedorContaBancaria.Agencia);
            lstParametros.Add("@TipoConta", fornecedorContaBancaria.TipoConta);
            lstParametros.Add("@Conta", fornecedorContaBancaria.Conta);
            lstParametros.Add("@UnitTest", fornecedorContaBancaria.UnitTest.ToString());

            return lstParametros;
        }

        public List<FornecedorContaBancaria> PesquisarFornecedorContaBancaria(FornecedorContaBancaria fornecedorContaBancaria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<FornecedorContaBancaria> lstContas = new List<FornecedorContaBancaria>();

            try
            {
                lstParametros = MontarParametrosPesquisarContaBancaria(fornecedorContaBancaria);

                using (DataSet ds = dao.Pesquisar("SP_FORNECEDORES_CONTASBANCARIAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FornecedorContaBancaria itemConta = new FornecedorContaBancaria();
                        itemConta.idContaBancaria = int.Parse(dr["idContaBancaria"].ToString());
                        itemConta.idFornecedor = int.Parse(dr["idFornecedor"].ToString());
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
                    procedureSQL = "SP_FORNECEDORES_CONTASBANCARIAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstContas;
        }

        public List<FornecedorContaBancaria> PesquisarFornecedorContaBancariaCombo(FornecedorContaBancaria fornecedorContaBancaria)
        {
            List<FornecedorContaBancaria> lstContas = new List<FornecedorContaBancaria>();

            lstContas = this.PesquisarFornecedorContaBancaria(fornecedorContaBancaria);

            foreach (FornecedorContaBancaria itemConta in lstContas.OrderBy(X => X.Banco).ToList())
                itemConta.Banco = "BANCO: " + itemConta.Banco + " - AGÊNCIA: " + itemConta.Agencia + " - CONTA: " + itemConta.Conta + " ( " + itemConta.TipoConta + " )";
            
            return lstContas;
        }
                
        //private List<_Transacao> AtualizarContasBancarias(int idFornecedor, List<FornecedorContaBancaria> lstContas)
        //{
        //    List<_Transacao> lstComandos = new List<_Transacao>();
        //    Dictionary<string, string> lstParam = new Dictionary<string, string>();
            
        //    foreach (FornecedorContaBancaria itemConta in lstContas)
        //    {
        //        lstParam = new Dictionary<string, string>();

        //        itemConta.idFornecedor = idFornecedor;
                
        //        if(itemConta.Excluir == true)
        //        {
        //            lstParam.Add("@idContaBancaria", itemConta.idContaBancaria.ToString());
        //            lstComandos.Add(new _Transacao()
        //            {
        //                nomeProcedure = "SP_FORNECEDORES_CONTASBANCARIAS_EXCLUIR",
        //                lstParametros = lstParam
        //            });
        //        }
        //        else if (itemConta.idContaBancaria == 0)         
        //        {
        //            lstParam = MontarParametrosExecutarContaBancaria(itemConta);
        //            lstComandos.Add(new _Transacao()
        //            {
        //                nomeProcedure = "SP_FORNECEDORES_CONTASBANCARIAS_INCLUIR",
        //                lstParametros = lstParam
        //            });
        //        }                    
        //        else
        //        {
        //            lstParam = MontarParametrosExecutarContaBancaria(itemConta);
        //            lstComandos.Add(new _Transacao()
        //            {
        //                nomeProcedure = "SP_FORNECEDORES_CONTASBANCARIAS_ALTERAR",
        //                lstParametros = lstParam
        //            });
        //        }                    
        //    }

        //    return lstComandos;
        //}

        public void IncluirContaBancaria(FornecedorContaBancaria contaBancaria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros = MontarParametrosExecutarContaBancaria(contaBancaria);
                dao.Executar("SP_FORNECEDORES_CONTASBANCARIAS_INCLUIR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_CONTASBANCARIAS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void ExcluirContaBancaria(int idConta)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idContaBancaria", idConta.ToString());
                dao.Executar("SP_FORNECEDORES_CONTASBANCARIAS_EXCLUIR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FORNECEDORES_CONTASBANCARIAS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        #endregion
    }
}
