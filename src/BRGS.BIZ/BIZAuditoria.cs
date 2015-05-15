using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BRGS.Entity;
using BRGS.Util;

namespace BRGS.BIZ
{
    public class BIZAuditoria
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();
        
        #region Administrativo
        
        #region Atividade

        private Dictionary<string, string> MontarParametrosExecutarAuditoriaAtividade(Atividade atividadeLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idAtividade", atividadeLog.idAtividade.ToString());            
            lstParametros.Add("@Descricao", atividadeLog.Descricao);
            lstParametros.Add("@idUsuario", atividadeLog.idUsuario.ToString());
            lstParametros.Add("@Acao", atividadeLog.Acao);

            return lstParametros;
        }

        public List<Atividade> PesquisarAuditoriaAtividade(out List<Atividade> lstMaster)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Atividade> lstAtividadesLog = new List<Atividade>();
          
            lstMaster = new List<Atividade>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_ATIVIDADES_AUDITORIA_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstAtividadesLog.Add(new Atividade()
                        {
                            idLog = int.Parse(dr["idLog"].ToString()),
                            idAtividade = int.Parse(dr["idAtividade"].ToString()),
                            Descricao = dr["Descricao"].ToString(),
                            idUsuario = int.Parse(dr["idUsuario"].ToString()),
                            nomeUsuario = dr["NomeUsuario"].ToString(),
                            dataAlteracao = DateTime.Parse(dr["DataAlteracao"].ToString()),
                            Acao = dr["Acao"].ToString()
                        });
                    }
                }

                if (lstAtividadesLog.Count > 0)
                {
                    IEnumerable<int> lstIDs =
                        from e in lstAtividadesLog                       
                        orderby e.idAtividade
                        group e by new { idAtividade = e.idAtividade } into g                        
                        select (g.Key.idAtividade);

                    foreach (int idLog in lstIDs)
                    {
                        lstMaster.Add(new Atividade()
                        {
                            idAtividade = idLog,
                            Descricao = lstAtividadesLog
                            .Where(a => string.IsNullOrEmpty(a.Descricao) == false && a.idAtividade == idLog)
                            .OrderBy(c => c.idAtividade).ThenByDescending(d => d.dataAlteracao)
                            .Select(e => e.Descricao).Distinct().FirstOrDefault()
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
                    procedureSQL = "SP_ATIVIDADES_AUDITORIA_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstAtividadesLog;
        }

        public void GerarAuditoriaAtividade(Atividade atividadeOriginal, Atividade atividadeAtualizada, string acao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametrosAuditoria = new Dictionary<string, string>();
            Atividade atividadeAuditoria = new Atividade();
            bool valorAlterado = false;

            try
            {
                atividadeAuditoria = (Atividade)helper.ObterAlteracoesAuditoria(atividadeOriginal, atividadeAtualizada, new Atividade(), out valorAlterado);

                if (valorAlterado == false && acao != "EXCLUSÃO")
                    return;
                
                atividadeAuditoria.idAtividade = atividadeAtualizada.idAtividade;
                atividadeAuditoria.idUsuario = UsuarioLogado.idUsuario;
                atividadeAuditoria.Acao = acao;

                lstParametrosAuditoria = MontarParametrosExecutarAuditoriaAtividade(atividadeAuditoria);
                dao.Executar("SP_ATIVIDADES_AUDITORIA_INCLUIR", lstParametrosAuditoria);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametrosAuditoria);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ATIVIDADES_AUDITORIA_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }           
        }

        #endregion

        #region Categoria

        private Dictionary<string, string> MontarParametrosExecutarAuditoriaCategoria(Categoria categoriaLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCategoria", categoriaLog.idCategoria.ToString());
            lstParametros.Add("@Descricao", categoriaLog.Descricao);
            lstParametros.Add("@idUsuario", categoriaLog.idUsuario.ToString());
            lstParametros.Add("@Acao", categoriaLog.Acao);

            return lstParametros;
        }

        public List<Categoria> PesquisarAuditoriaCategoria(out List<Categoria> lstMaster)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Categoria> lstCategoriasLog = new List<Categoria>();

            lstMaster = new List<Categoria>();

            try
            {
                using (DataSet ds = dao.Pesquisar("SP_CATEGORIAS_AUDITORIA_CONSULTAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstCategoriasLog.Add(new Categoria()
                        {
                            idLog = int.Parse(dr["idLog"].ToString()),
                            idCategoria = int.Parse(dr["idCategoria"].ToString()),
                            Descricao = dr["Descricao"].ToString(),
                            idUsuario = int.Parse(dr["idUsuario"].ToString()),
                            nomeUsuario = dr["NomeUsuario"].ToString(),
                            dataAlteracao = DateTime.Parse(dr["DataAlteracao"].ToString()),
                            Acao = dr["Acao"].ToString()
                        });
                    }
                }

                if (lstCategoriasLog.Count > 0)
                {
                    IEnumerable<int> lstIDs =
                        from e in lstCategoriasLog
                        orderby e.idCategoria 
                        group e by new { idCategoria = e.idCategoria } into g
                        select (g.Key.idCategoria);

                    foreach (int idLog in lstIDs)
                    {
                        lstMaster.Add(new Categoria()
                        {
                            idCategoria = idLog,
                            Descricao = lstCategoriasLog 
                            .Where(a => string.IsNullOrEmpty(a.Descricao) == false && a.idCategoria == idLog)
                            .OrderBy(c => c.idCategoria).ThenByDescending(d => d.dataAlteracao)
                            .Select(e => e.Descricao).Distinct().FirstOrDefault()
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
                    procedureSQL = "SP_CATEGORIAS_AUDITORIA_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstCategoriasLog;
        }

        public void GerarAuditoriaCategoria(Categoria categoriaOriginal, Categoria categoriaAtualizada, string acao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametrosAuditoria = new Dictionary<string, string>();
            Categoria categoriaAuditoria = new Categoria();
            bool valorAlterado = false;

            try
            {
                categoriaAuditoria = (Categoria)helper.ObterAlteracoesAuditoria(categoriaOriginal, categoriaAtualizada, new Categoria(),out valorAlterado);

                if (valorAlterado == false && acao != "EXCLUSÃO")
                    return;

                categoriaAuditoria.idCategoria = categoriaAtualizada.idCategoria;
                categoriaAuditoria.idUsuario = UsuarioLogado.idUsuario;
                categoriaAuditoria.Acao = acao;

                lstParametrosAuditoria = MontarParametrosExecutarAuditoriaCategoria(categoriaAuditoria);
                dao.Executar("SP_CATEGORIAS_AUDITORIA_INCLUIR", lstParametrosAuditoria);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametrosAuditoria);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_ATIVIDADES_AUDITORIA_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }  
        }

        #endregion
        
        #region Cliente
        
        private Dictionary<string, string> MontarParametrosExecutarAuditoriaCliente(Cliente clienteLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idCliente", clienteLog.idCliente.ToString());
            lstParametros.Add("@idCategoria", clienteLog.idCategoria.ToString());
            lstParametros.Add("@idAtividade", clienteLog.idAtividade.ToString());
            lstParametros.Add("@Codigo",clienteLog.Codigo);
            lstParametros.Add("@Nome", clienteLog.Nome);
            lstParametros.Add("@CPF_CNPJ", clienteLog.CPF_CNPJ);
            lstParametros.Add("@IE", clienteLog.IE);
            lstParametros.Add("@ICM", clienteLog.ICM);
            lstParametros.Add("@Endereco", clienteLog.Endereco);
            lstParametros.Add("@Complemento", clienteLog.Complemento);
            lstParametros.Add("@Bairro", clienteLog.Bairro);
            lstParametros.Add("@Cidade", clienteLog.Cidade);
            lstParametros.Add("@Estado", clienteLog.Estado);
            lstParametros.Add("@CEP", clienteLog.CEP);
            lstParametros.Add("@Pais", clienteLog.Pais);
            lstParametros.Add("@Telefone", clienteLog.Telefone);
            lstParametros.Add("@Fax", clienteLog.Fax);
            lstParametros.Add("@Email", clienteLog.Email);
            lstParametros.Add("@TipoPessoa", clienteLog.TipoPessoa);
            lstParametros.Add("@Site", clienteLog.Site);            
            lstParametros.Add("@Observacao", clienteLog.Observacao);
            lstParametros.Add("@Status", clienteLog.Status);
            lstParametros.Add("@idUsuario", clienteLog.idUsuario.ToString());
            lstParametros.Add("@Acao", clienteLog.Acao);

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarAuditoriaClienteContatos(ClienteContato contatoLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idLogPai", contatoLog.idLog.ToString());
            lstParametros.Add("@idCliente", contatoLog.idCliente.ToString());
            lstParametros.Add("@Nome", contatoLog.Nome);
            lstParametros.Add("@Telefone", contatoLog.Telefone);
            lstParametros.Add("@Email", contatoLog.Email);
            lstParametros.Add("@idUsuario", contatoLog.idUsuario.ToString());
            lstParametros.Add("@Acao", contatoLog.Acao);

            return lstParametros;
        }

        public void GerarAuditoriaCliente(Cliente clienteOriginal, Cliente clienteAtualizado, string acao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametrosAuditoria = new Dictionary<string, string>();
            Cliente clienteAuditoria = new Cliente();
            ClienteContato contatoAuditoria = new ClienteContato();
            int idLogCliente = 0;
            bool valorAlterado = false;

            clienteAuditoria = (Cliente)helper.ObterAlteracoesAuditoria(clienteOriginal, clienteAtualizado, new Cliente(), out valorAlterado);

            if (valorAlterado == false && acao != "EXCLUSÃO")
                return;

            clienteAuditoria.idCliente = clienteAtualizado.idCliente;
            clienteAuditoria.idUsuario = UsuarioLogado.idUsuario;
            clienteAuditoria.Acao = acao;

            lstParametrosAuditoria = MontarParametrosExecutarAuditoriaCliente(clienteAuditoria);

            using (DataSet ds = dao.Pesquisar("SP_CLIENTES_AUDITORIA_INCLUIR", lstParametrosAuditoria))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                idLogCliente = int.Parse(dr[0].ToString());
            }

            if (clienteOriginal.lstContatos == null)
                clienteOriginal.lstContatos = new List<ClienteContato>();

            foreach (ClienteContato contatoNovo in clienteAtualizado.lstContatos)
            {
                if (clienteOriginal.lstContatos.Exists(x => x.Nome == contatoNovo.Nome) == false)
                {
                    contatoAuditoria = (ClienteContato)helper.ObterAlteracoesAuditoria(new ClienteContato(), contatoNovo, new ClienteContato(), out valorAlterado);

                    if (valorAlterado == false && acao != "EXCLUSÃO")
                        return;

                    contatoAuditoria.idLog = idLogCliente;
                    contatoAuditoria.idCliente = clienteAtualizado.idCliente;
                    contatoAuditoria.idUsuario = UsuarioLogado.idUsuario;
                    contatoAuditoria.Acao = "INCLUSÃO";

                    lstParametrosAuditoria = MontarParametrosExecutarAuditoriaClienteContatos(contatoAuditoria);
                    dao.Executar("SP_CLIENTES_CONTATOS_AUDITORIA_INCLUIR", lstParametrosAuditoria);
                }
            }

            foreach (ClienteContato contatoExistente in clienteOriginal.lstContatos)
            {
                if (clienteAtualizado.lstContatos.Exists(x => x.Nome == contatoExistente.Nome) == false)
                {
                    contatoAuditoria = (ClienteContato)helper.ObterAlteracoesAuditoria(new ClienteContato(), contatoExistente, new ClienteContato(), out valorAlterado);

                    if (valorAlterado == false && acao != "EXCLUSÃO")
                        return;

                    contatoAuditoria.idLog = idLogCliente;
                    contatoAuditoria.idCliente = contatoExistente.idCliente;
                    contatoAuditoria.idUsuario = UsuarioLogado.idUsuario;
                    contatoAuditoria.Acao = "EXCLUSÃO";

                    lstParametrosAuditoria = MontarParametrosExecutarAuditoriaClienteContatos(contatoAuditoria);
                    dao.Executar("SP_CLIENTES_CONTATOS_AUDITORIA_INCLUIR", lstParametrosAuditoria);
                }
            }
        }

        #endregion

        #region Feriado

        private Dictionary<string, string> MontarParametrosExecutarAuditoriaFeriado(Feriado feriadoLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFeriado", feriadoLog.idFeriado.ToString());
            lstParametros.Add("@Dia", feriadoLog.Dia.ToString());
            lstParametros.Add("@Mes", feriadoLog.Mes.ToString());
            lstParametros.Add("@Descricao", feriadoLog.Descricao);
            lstParametros.Add("@idUsuario", feriadoLog.idUsuario.ToString());
            lstParametros.Add("@Acao", feriadoLog.Acao);

            return lstParametros;
        }

        public void GerarAuditoriaFeriado(Feriado feriadoOriginal, Feriado feriadoAtualizada, string acao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametrosAuditoria = new Dictionary<string, string>();
            Feriado feriadoAuditoria = new Feriado();
            bool valorAlterado = false;

            try
            {
                feriadoAuditoria = (Feriado)helper.ObterAlteracoesAuditoria(feriadoOriginal, feriadoAtualizada, new Feriado(), out valorAlterado);

                if (valorAlterado == false && acao != "EXCLUSÃO")
                    return;

                feriadoAuditoria.idFeriado = feriadoAtualizada.idFeriado;
                feriadoAuditoria.idUsuario = UsuarioLogado.idUsuario;
                feriadoAuditoria.Acao = acao;

                lstParametrosAuditoria = MontarParametrosExecutarAuditoriaFeriado(feriadoAuditoria);
                dao.Executar("SP_FERIADOS_AUDITORIA_INCLUIR", lstParametrosAuditoria);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametrosAuditoria);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_FERIADOS_AUDITORIA_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        #endregion

        #region Fornecedores
        private Dictionary<string, string> MontarParametrosExecutarAuditoriaFornecedor(Fornecedor fornecedorLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idFornecedor", fornecedorLog.idFornecedor.ToString());
            lstParametros.Add("@idCategoria", fornecedorLog.idCategoria.ToString());
            lstParametros.Add("@idAtividade", fornecedorLog.idAtividade.ToString());
            lstParametros.Add("@Codigo", fornecedorLog.Codigo);
            lstParametros.Add("@Nome", fornecedorLog.Nome);
            lstParametros.Add("@CPF_CNPJ", fornecedorLog.CPF_CNPJ);
            lstParametros.Add("@IE", fornecedorLog.IE);
            lstParametros.Add("@ICM", fornecedorLog.ICM);
            lstParametros.Add("@Endereco", fornecedorLog.Endereco);
            lstParametros.Add("@Complemento", fornecedorLog.Complemento);
            lstParametros.Add("@Bairro", fornecedorLog.Bairro);
            lstParametros.Add("@Cidade", fornecedorLog.Cidade);
            lstParametros.Add("@Estado", fornecedorLog.Estado);
            lstParametros.Add("@CEP", fornecedorLog.CEP);
            lstParametros.Add("@Pais", fornecedorLog.Pais);
            lstParametros.Add("@Telefone", fornecedorLog.Telefone);
            lstParametros.Add("@Fax", fornecedorLog.Fax);
            lstParametros.Add("@Email", fornecedorLog.Email);
            lstParametros.Add("@TipoPessoa", fornecedorLog.TipoPessoa);
            lstParametros.Add("@Site", fornecedorLog.Site);            
            lstParametros.Add("@Observacao", fornecedorLog.Observacao);
            lstParametros.Add("@Status", fornecedorLog.Status);
            lstParametros.Add("@idUsuario", fornecedorLog.idUsuario.ToString());
            lstParametros.Add("@Acao", fornecedorLog.Acao);

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosExecutarAuditoriaFornecedorContatos(FornecedorContato contatoLog)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idLogPai", contatoLog.idLog.ToString());
            lstParametros.Add("@idFornecedor", contatoLog.idFornecedor.ToString());
            lstParametros.Add("@Nome", contatoLog.Nome);
            lstParametros.Add("@Telefone", contatoLog.Telefone);
            lstParametros.Add("@Email", contatoLog.Email);
            lstParametros.Add("@idUsuario", contatoLog.idUsuario.ToString());
            lstParametros.Add("@Acao", contatoLog.Acao);

            return lstParametros;
        }

        public void GerarAuditoriaFornecedor(Fornecedor fornecedorOriginal, Fornecedor fornecedorAtualizado, string acao)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametrosAuditoria = new Dictionary<string, string>();
            Fornecedor fornecedorAuditoria = new Fornecedor();
            FornecedorContato contatoAuditoria = new FornecedorContato();
            int idLogFornecedor = 0;
            bool valorAlterado = false;

            fornecedorAuditoria = (Fornecedor)helper.ObterAlteracoesAuditoria(fornecedorOriginal, fornecedorAtualizado, new Fornecedor(), out valorAlterado);

            if (valorAlterado == false && acao != "EXCLUSÃO")
                return;

            fornecedorAuditoria.idFornecedor = fornecedorAtualizado.idFornecedor;
            fornecedorAuditoria.idUsuario = UsuarioLogado.idUsuario;
            fornecedorAuditoria.Acao = acao;

            lstParametrosAuditoria = MontarParametrosExecutarAuditoriaFornecedor(fornecedorAuditoria);

            using (DataSet ds = dao.Pesquisar("SP_FORNECEDORES_AUDITORIA_INCLUIR", lstParametrosAuditoria))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                idLogFornecedor = int.Parse(dr[0].ToString());
            }

            if (fornecedorOriginal.lstContatos == null)
                fornecedorOriginal.lstContatos = new List<FornecedorContato>();

            foreach (FornecedorContato contatoNovo in fornecedorAtualizado.lstContatos)
            {
                if (fornecedorOriginal.lstContatos.Exists(x => x.Nome == contatoNovo.Nome) == false)
                {
                    contatoAuditoria = (FornecedorContato)helper.ObterAlteracoesAuditoria(new FornecedorContato(), contatoNovo, new FornecedorContato(), out valorAlterado);

                    if (valorAlterado == false && acao != "EXCLUSÃO")
                        return;

                    contatoAuditoria.idLog = idLogFornecedor;
                    contatoAuditoria.idFornecedor = fornecedorAtualizado.idFornecedor;
                    contatoAuditoria.idUsuario = UsuarioLogado.idUsuario;
                    contatoAuditoria.Acao = "INCLUSÃO";

                    lstParametrosAuditoria = MontarParametrosExecutarAuditoriaFornecedorContatos(contatoAuditoria);
                    dao.Executar("SP_FORNECEDORES_CONTATOS_AUDITORIA_INCLUIR", lstParametrosAuditoria);
                }
            }

            foreach (FornecedorContato contatoExistente in fornecedorOriginal.lstContatos)
            {
                if (fornecedorAtualizado.lstContatos.Exists(x => x.Nome == contatoExistente.Nome) == false)
                {
                    contatoAuditoria = (FornecedorContato)helper.ObterAlteracoesAuditoria(new FornecedorContato(), contatoExistente, new FornecedorContato(), out valorAlterado );

                    if (valorAlterado == false && acao != "EXCLUSÃO")
                        return;

                    contatoAuditoria.idLog = idLogFornecedor;
                    contatoAuditoria.idFornecedor = contatoExistente.idFornecedor;
                    contatoAuditoria.idUsuario = UsuarioLogado.idUsuario;
                    contatoAuditoria.Acao = "EXCLUSÃO";

                    lstParametrosAuditoria = MontarParametrosExecutarAuditoriaFornecedorContatos(contatoAuditoria);
                    dao.Executar("SP_FORNECEDORES_CONTATOS_AUDITORIA_INCLUIR", lstParametrosAuditoria);
                }
            }
        }

        #endregion


        #endregion
    }
}
