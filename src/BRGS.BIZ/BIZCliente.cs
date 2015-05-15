using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZCliente
    {
        private Helper helper = new Helper();
        private BIZLogErro bizLogErro = new BIZLogErro();
        private BIZAuditoria bizAuditoria = new BIZAuditoria();

        #region Clientes
        
        private Dictionary<string, string> MontarParametrosPesquisar(Cliente cliente)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCliente", cliente.idCliente.Equals(0) ? null : cliente.idCliente.ToString());
            lstParametros.Add("@idCategoria", cliente.idCategoria.Equals(0) ? null : cliente.idCategoria.ToString());
            lstParametros.Add("@idAtividade", cliente.idAtividade.Equals(0) ? null : cliente.idAtividade.ToString());
            lstParametros.Add("@Codigo", string.IsNullOrEmpty(cliente.Codigo) ? null : cliente.Codigo);
            lstParametros.Add("@Nome", string.IsNullOrEmpty(cliente.Nome) ? null : cliente.Nome);
            lstParametros.Add("@CPF_CNPJ", string.IsNullOrEmpty(cliente.CPF_CNPJ) ? null : cliente.CPF_CNPJ);
            lstParametros.Add("@IE", string.IsNullOrEmpty(cliente.IE) ? null : cliente.IE);
            lstParametros.Add("@ICM", string.IsNullOrEmpty(cliente.ICM) ? null : cliente.ICM);
            lstParametros.Add("@Endereco", string.IsNullOrEmpty(cliente.Endereco) ? null : cliente.Endereco);
            lstParametros.Add("@Complemento", string.IsNullOrEmpty(cliente.Complemento) ? null : cliente.Complemento);
            lstParametros.Add("@Bairro", string.IsNullOrEmpty(cliente.Bairro) ? null : cliente.Bairro);
            lstParametros.Add("@Cidade", string.IsNullOrEmpty(cliente.Cidade) ? null : cliente.Cidade);
            lstParametros.Add("@Estado", string.IsNullOrEmpty(cliente.Estado) ? null : cliente.Estado);
            lstParametros.Add("@CEP", string.IsNullOrEmpty(cliente.CEP) ? null : cliente.CEP);
            lstParametros.Add("@Pais", string.IsNullOrEmpty(cliente.Pais) ? null : cliente.Pais);
            lstParametros.Add("@Telefone", string.IsNullOrEmpty(cliente.Telefone) ? null : cliente.Telefone);
            lstParametros.Add("@Fax", string.IsNullOrEmpty(cliente.Fax) ? null : cliente.Fax);
            lstParametros.Add("@Email", string.IsNullOrEmpty(cliente.Email) ? null : cliente.Email);
            lstParametros.Add("@TipoPessoa", string.IsNullOrEmpty(cliente.TipoPessoa) ? null : cliente.TipoPessoa);
            lstParametros.Add("@Site", string.IsNullOrEmpty(cliente.Site) ? null : cliente.Site);
            lstParametros.Add("@Observacao", string.IsNullOrEmpty(cliente.Observacao) ? null : cliente.Observacao);
            lstParametros.Add("@Status", string.IsNullOrEmpty(cliente.Status) ? null : cliente.Status);
            lstParametros.Add("@UnitTest", cliente.UnitTest.Equals(0) ? null : cliente.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutar(Cliente cliente)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCliente", cliente.idCliente.ToString());
            lstParametros.Add("@idCategoria", cliente.idCategoria.ToString());
            lstParametros.Add("@idAtividade", cliente.idAtividade.ToString());
            lstParametros.Add("@Codigo", cliente.Codigo);
            lstParametros.Add("@Nome", cliente.Nome);
            lstParametros.Add("@CPF_CNPJ", cliente.CPF_CNPJ);
            lstParametros.Add("@IE", cliente.IE);
            lstParametros.Add("@ICM", cliente.ICM);
            lstParametros.Add("@Endereco", cliente.Endereco);
            lstParametros.Add("@Complemento", cliente.Complemento);
            lstParametros.Add("@Bairro", cliente.Bairro);
            lstParametros.Add("@Cidade", cliente.Cidade);
            lstParametros.Add("@Estado", cliente.Estado);
            lstParametros.Add("@CEP", cliente.CEP);
            lstParametros.Add("@Pais", cliente.Pais);
            lstParametros.Add("@Telefone", cliente.Telefone);
            lstParametros.Add("@Fax", cliente.Fax);
            lstParametros.Add("@Email", cliente.Email);
            lstParametros.Add("@TipoPessoa", cliente.TipoPessoa);
            lstParametros.Add("@Site", cliente.Site);            
            lstParametros.Add("@Observacao", cliente.Observacao);
            lstParametros.Add("@Status", cliente.Status);
            lstParametros.Add("@UnitTest", cliente.UnitTest.ToString());

            return lstParametros;
        }
       
        public List<Cliente> PesquisarCliente(Cliente cliente)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Cliente> lstClientes = new List<Cliente>();
            dynamic lst = new List<Cliente>();
          
            try
            {
                lstParametros = MontarParametrosPesquisar(cliente);

                using (DataSet ds = dao.Pesquisar("SP_CLIENTES_CONSULTAR", lstParametros))
                {
                    lst = from f in ds.Tables[0].AsEnumerable<Cliente>()
                          select f;                 
                }

                lstClientes.AddRange(lst);
            }            
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CLIENTES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstClientes;
        }

        private string ValidarCamposObrigatorios(Cliente cliente)
        {
            string Msg = string.Empty;
            List<Cliente> clienteDuplicado = new List<Cliente>();


            if (string.IsNullOrEmpty(cliente.Nome))
                Msg += Environment.NewLine + "Nome do Cliente não preenchido";

            if (string.IsNullOrEmpty(cliente.CPF_CNPJ) || (!helper.ValidarCPF(cliente.CPF_CNPJ) && !helper.ValidarCNPJ(cliente.CPF_CNPJ)))
                Msg += Environment.NewLine + "Favor informar um CPF / CNPJ válido";

            if (string.IsNullOrEmpty(cliente.Status))
                Msg += Environment.NewLine + "Favor selecionar o Status do Cliente";

            if (!string.IsNullOrEmpty(cliente.Email) && !helper.ValidarEmail(cliente.Email))
                Msg += Environment.NewLine + "E-mail inválido";

            if (cliente.idCliente == 0 && cliente.UnitTest == 0)
            {
                clienteDuplicado = this.PesquisarCliente(new Cliente() { Nome = cliente.Nome, CPF_CNPJ = cliente.CPF_CNPJ });
                if(clienteDuplicado.Count > 0)
                    Msg += Environment.NewLine + "Já existe um cliente com esse Nome e com esse CPF / CNPJ";
            }
            
            return Msg;
        }
        
        public string IncluirCliente(Cliente cliente, out int idCliente)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(cliente);
                idCliente = 0;

                if (Msg == string.Empty)
                {
                    lstParametros = MontarParametrosExecutar(cliente);
                    using (DataSet ds = dao.Pesquisar("SP_CLIENTES_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idCliente = int.Parse(dr[0].ToString());
                    }
                
                    lstComandos.AddRange(this.IncluirContato(idCliente, cliente.lstContatos));
                    lstComandos.AddRange(this.AtualizarContasBancarias(idCliente, cliente.lstContasBancarias));

                    dao.ExecutarTransacao(lstComandos);

                    cliente.idCliente = idCliente;
                    bizAuditoria.GerarAuditoriaCliente(new Cliente(), cliente, "INCLUSÃO");
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CLIENTES_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarCliente(Cliente clienteOriginal, Cliente clienteAtualizado)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Dictionary<string, string> lstContatos = new Dictionary<string, string>();
            List<_Transacao> lstComandos = new List<_Transacao>();

            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(clienteAtualizado);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CLIENTES_ALTERAR",
                        lstParametros = MontarParametrosExecutar(clienteAtualizado)
                    });

                    lstContatos.Add("@idCliente", clienteAtualizado.idCliente.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CLIENTES_CONTATOS_EXCLUIR",
                        lstParametros = lstContatos
                    });

                    lstComandos.AddRange(this.IncluirContato(clienteAtualizado.idCliente, clienteAtualizado.lstContatos));

                    lstComandos.AddRange(this.AtualizarContasBancarias(clienteAtualizado.idCliente, clienteAtualizado.lstContasBancarias));

                    dao.ExecutarTransacao(lstComandos);

                    bizAuditoria.GerarAuditoriaCliente(clienteOriginal, clienteAtualizado, "ALTERAÇÃO");                
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CLIENTES_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ValidarExclusaoCliente(Cliente cliente)
        {
            string msg = string.Empty;
            BIZNotaFiscal bizNF = new BIZNotaFiscal();
            BIZObra bizObra = new BIZObra();
            
            if (bizNF.PesquisarNotaFiscal(new NotaFiscal() { idCliente = cliente.idCliente }).Count > 0)
                msg += Environment.NewLine + "Este Cliente está sendo utilizado em alguma Nota Fiscal";

            if (bizObra.PesquisarObraEtapa(new ObraEtapa() { idCliente = cliente.idCliente }).Count > 0)
                msg += Environment.NewLine + "Este Cliente está sendo utilizado em alguma Obra";
            
            return msg;
        }

        public void ExcluirCliente(Cliente cliente)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idCliente", cliente.idCliente.ToString());
                dao.Executar("SP_CLIENTES_EXCLUIR", lstParametros);
                bizAuditoria.GerarAuditoriaCliente(cliente, cliente, "EXCLUSÃO");
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CLIENTES_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public void ExcluirClienteTeste()
        {
            DataAccess dao = new DataAccess();            
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            
            try
            {
                dao.Executar("SP_CLIENTES_EXCLUIRTESTE", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_CLIENTES_EXCLUIRTESTE",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }            
        }

        #endregion

        #region Contatos

        private Dictionary<string, string> MontarParametrosPesquisarContato(ClienteContato clienteContato)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCliente", clienteContato.idCliente.Equals(0) ? null : clienteContato.idCliente.ToString());
            lstParametros.Add("@Nome", string.IsNullOrEmpty(clienteContato.Nome) ? null : clienteContato.Nome);           
            lstParametros.Add("@UnitTest", clienteContato.UnitTest.Equals(0) ? null : clienteContato.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarContato(ClienteContato clienteContato)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCliente", clienteContato.idCliente.ToString());
            lstParametros.Add("@Nome", clienteContato.Nome);
            lstParametros.Add("@Telefone", clienteContato.Telefone);
            lstParametros.Add("@Email", clienteContato.Email);
            lstParametros.Add("@UnitTest", clienteContato.UnitTest.ToString());

            return lstParametros;
        }

        public List<ClienteContato> PesquisarClienteContato(ClienteContato clienteContato)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ClienteContato> lstContatos = new List<ClienteContato>();

            try
            {
                lstParametros = MontarParametrosPesquisarContato(clienteContato);

                using (DataSet ds = dao.Pesquisar("SP_CLIENTES_CONTATOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ClienteContato itemContato = new ClienteContato();
                        itemContato.idCliente = int.Parse(dr["idCliente"].ToString());
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
                    procedureSQL = "SP_CLIENTES_CONTATOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstContatos;
        }

        private List<_Transacao> IncluirContato(int idCliente, List<ClienteContato> lstContato)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (ClienteContato itemContato in lstContato)
            {
                itemContato.idCliente = idCliente;
                lstParametros = MontarParametrosExecutarContato(itemContato);

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_CLIENTES_CONTATOS_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        #endregion

        #region Contas Bancárias

        private Dictionary<string, string> MontarParametrosPesquisarContaBancaria(ClienteContaBancaria clienteContaBancaria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idContaBancaria", clienteContaBancaria.idContaBancaria.Equals(0) ? null : clienteContaBancaria.idContaBancaria.ToString());
            lstParametros.Add("@idCliente", clienteContaBancaria.idCliente.Equals(0) ? null : clienteContaBancaria.idCliente.ToString());
            lstParametros.Add("@UnitTest", clienteContaBancaria.UnitTest.Equals(0) ? null : clienteContaBancaria.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarContaBancaria(ClienteContaBancaria clienteContaBancaria)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idContaBancaria", clienteContaBancaria.idContaBancaria.ToString());
            lstParametros.Add("@idCliente", clienteContaBancaria.idCliente.ToString());
            lstParametros.Add("@Banco", clienteContaBancaria.Banco);
            lstParametros.Add("@Agencia", clienteContaBancaria.Agencia);
            lstParametros.Add("@TipoConta", clienteContaBancaria.TipoConta);
            lstParametros.Add("@Conta", clienteContaBancaria.Conta);
            lstParametros.Add("@UnitTest", clienteContaBancaria.UnitTest.ToString());

            return lstParametros;
        }

        public List<ClienteContaBancaria> PesquisarClienteContaBancaria(ClienteContaBancaria clienteContaBancaria)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<ClienteContaBancaria> lstContas = new List<ClienteContaBancaria>();

            try
            {
                lstParametros = MontarParametrosPesquisarContaBancaria(clienteContaBancaria);

                using (DataSet ds = dao.Pesquisar("SP_CLIENTES_CONTASBANCARIAS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ClienteContaBancaria itemConta = new ClienteContaBancaria();
                        itemConta.idContaBancaria = int.Parse(dr["idContaBancaria"].ToString());
                        itemConta.idCliente = int.Parse(dr["idCliente"].ToString());
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
                    procedureSQL = "SP_CLIENTES_CONTASBANCARIAS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstContas;
        }

        public List<ClienteContaBancaria> PesquisarClienteContaBancariaCombo(ClienteContaBancaria clienteContaBancaria)
        {
            List<ClienteContaBancaria> lstContas = new List<ClienteContaBancaria>();

            lstContas = this.PesquisarClienteContaBancaria(clienteContaBancaria);

            foreach (ClienteContaBancaria itemConta in lstContas.OrderBy(X => X.Banco).ToList())
                itemConta.Banco = "BANCO: " + itemConta.Banco + " - AGÊNCIA: " + itemConta.Agencia + " - CONTA: " + itemConta.Conta + " ( " + itemConta.TipoConta + " )";

            return lstContas;
        }

        private List<_Transacao> AtualizarContasBancarias(int idCliente, List<ClienteContaBancaria> lstContas)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParam = new Dictionary<string, string>();

            foreach (ClienteContaBancaria itemConta in lstContas)
            {
                lstParam = new Dictionary<string, string>();

                itemConta.idCliente = idCliente;

                if (itemConta.Excluir == true)
                {
                    lstParam.Add("@idContaBancaria", itemConta.idContaBancaria.ToString());
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CLIENTES_CONTASBANCARIAS_EXCLUIR",
                        lstParametros = lstParam
                    });
                }
                else if (itemConta.idContaBancaria == 0)
                {
                    lstParam = MontarParametrosExecutarContaBancaria(itemConta);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CLIENTES_CONTASBANCARIAS_INCLUIR",
                        lstParametros = lstParam
                    });
                }
                else
                {
                    lstParam = MontarParametrosExecutarContaBancaria(itemConta);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_CLIENTES_CONTASBANCARIAS_ALTERAR",
                        lstParametros = lstParam
                    });
                }
            }

            return lstComandos;
        }

        #endregion
    }
}
 