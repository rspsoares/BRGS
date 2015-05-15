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
    public class BIZUsuario
    {
        private BIZLogErro bizLogErro = new BIZLogErro();
        private Helper helper = new Helper();

        #region Usuários

        private Dictionary<string, string> MontarParametrosExecutarUsuario(Usuario usuario)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idUsuario", usuario.idUsuario.ToString());
            lstParametros.Add("@Nome", usuario.Nome);
            lstParametros.Add("@Login", usuario.Login);
            lstParametros.Add("@Bloqueado", usuario.Bloqueado.ToString());
            lstParametros.Add("@Ativo", usuario.Ativo);
            lstParametros.Add("@UnitTest", usuario.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarUsuario(Usuario usuario)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idUsuario", usuario.idUsuario.Equals(0) ? null : usuario.idUsuario.ToString());
            lstParametros.Add("@Nome", string.IsNullOrEmpty(usuario.Nome) ? null : usuario.Nome);
            lstParametros.Add("@Login", string.IsNullOrEmpty(usuario.Login) ? null : usuario.Login);
            lstParametros.Add("@Senha", string.IsNullOrEmpty(usuario.Senha) ? null : usuario.Senha);
            lstParametros.Add("@Bloqueado", usuario.Bloqueado.Equals(0) ? null : usuario.Bloqueado.ToString());
            lstParametros.Add("@Ativo", string.IsNullOrEmpty(usuario.Ativo) ? null : usuario.Ativo);
            lstParametros.Add("@UnitTest", usuario.UnitTest.ToString());

            return lstParametros;
        }

        private string ValidarCamposObrigatorios(Usuario usuario)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            string Msg = string.Empty;

            if (usuario.Nome == null || usuario.Nome == string.Empty)
                Msg += Environment.NewLine + "Nome do usuário não preenchido";

            if (usuario.Login == null || usuario.Login == string.Empty)
                Msg += Environment.NewLine + "Login do usuário não preenchido";

            if (Msg == string.Empty)
            {
                // Verificando duplicidade de logins            
                if (usuario.idUsuario == 0)
                {
                    if (this.PesquisarUsuario(new Usuario() { Login = usuario.Login, Ativo = "S" }).Count > 0)
                        Msg += Environment.NewLine + "Esse Login já existe";
                }
                else
                {
                    lstUsuarios = this.PesquisarUsuario(new Usuario() { Login = usuario.Login, Ativo = "S" });

                    if (lstUsuarios.Exists(user => user.idUsuario != usuario.idUsuario))
                        Msg += Environment.NewLine + "Esse Login já existe";
                }
            }

            return Msg;
        }

        public List<Usuario> PesquisarUsuario(Usuario usuario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<Usuario> lstUsuarios = new List<Usuario>();

            try
            {
                lstParametros = MontarParametrosPesquisarUsuario(usuario);

                using (DataSet dsUsuarios = dao.Pesquisar("SP_USUARIOS_CONSULTAR", lstParametros))
                {
                    foreach (DataRow drUsuario in dsUsuarios.Tables[0].Rows)
                    {
                        Usuario itemUsuario = new Usuario();
                        itemUsuario.idUsuario = int.Parse(drUsuario["idUsuario"].ToString());
                        itemUsuario.Nome = drUsuario["Nome"].ToString();
                        itemUsuario.Login = drUsuario["Login"].ToString();
                        itemUsuario.Senha = drUsuario["Senha"].ToString();
                        itemUsuario.ultimoAcesso = string.IsNullOrEmpty(drUsuario["UltimoAcesso"].ToString()) ? DateTime.MinValue : DateTime.Parse(drUsuario["UltimoAcesso"].ToString());
                        itemUsuario.Bloqueado = int.Parse(drUsuario["Bloqueado"].ToString());
                        itemUsuario.Ativo = drUsuario["Ativo"].ToString();
                        itemUsuario.UnitTest = int.Parse(drUsuario["UnitTest"].ToString());                        
                        itemUsuario.lstUEN = this.PesquisarUENAssociadas(itemUsuario);
                        itemUsuario.lstCC = this.PesquisarCentroCustoAssociados(new UsuarioCentroCusto() { idUsuario = itemUsuario.idUsuario });
                        itemUsuario.lstDespesas = this.PesquisarDespesaAssociadas(itemUsuario);

                        lstUsuarios.Add(itemUsuario);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstUsuarios;
        }

        private List<UsuarioUEN> PesquisarUENAssociadas(Usuario usuario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UsuarioUEN> lstUEN = new List<UsuarioUEN>();

            try
            {
                lstParametros.Add("@idUsuario",usuario.idUsuario.ToString());
                lstParametros.Add("@UnitTest", usuario.UnitTest.ToString());

                using (DataSet ds = dao.Pesquisar("SP_USUARIOSUEN_PESQUISAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UsuarioUEN usuarioUENItem = new UsuarioUEN();

                        usuarioUENItem.idUsuario = int.Parse(dr["idUsuario"].ToString());
                        usuarioUENItem.idUEN = int.Parse(dr["idUEN"].ToString());
                        usuarioUENItem.descricaoUEN = dr["Descricao"].ToString();
                        usuarioUENItem.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        lstUEN.Add(usuarioUENItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOSUEN_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstUEN;
        }

        public List<UsuarioCentroCusto> PesquisarCentroCustoAssociados(UsuarioCentroCusto usuarioCC)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UsuarioCentroCusto> lstCC = new List<UsuarioCentroCusto>();

            try
            {
                lstParametros.Add("@idUsuario", usuarioCC.idUsuario.ToString());
                lstParametros.Add("@idCentroCusto", usuarioCC.idCentroCusto.ToString());
                lstParametros.Add("@UnitTest", usuarioCC.UnitTest.ToString());

                using (DataSet ds = dao.Pesquisar("SP_USUARIOSCENTROCUSTO_PESQUISAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UsuarioCentroCusto usuarioCCItem = new UsuarioCentroCusto();

                        usuarioCCItem.idUsuario = int.Parse(dr["idUsuario"].ToString());
                        usuarioCCItem.nomeUsuario = dr["Nome"].ToString();
                        usuarioCCItem.idCentroCusto = int.Parse(dr["idCentroCusto"].ToString());
                        usuarioCCItem.descricaoCentroCusto = dr["Descricao"].ToString();
                        usuarioCCItem.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        lstCC.Add(usuarioCCItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOSCENTROCUSTO_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstCC;
        }

        private List<UsuarioDespesa> PesquisarDespesaAssociadas(Usuario usuario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UsuarioDespesa> lstDespesas = new List<UsuarioDespesa>();

            try
            {
                lstParametros.Add("@idUsuario", usuario.idUsuario.ToString());
                lstParametros.Add("@UnitTest", usuario.UnitTest.ToString());

                using (DataSet ds = dao.Pesquisar("SP_USUARIOSDESPESA_PESQUISAR", lstParametros))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UsuarioDespesa usuarioCCItem = new UsuarioDespesa();

                        usuarioCCItem.idUsuario = int.Parse(dr["idUsuario"].ToString());
                        usuarioCCItem.idDespesa = int.Parse(dr["idDespesa"].ToString());
                        usuarioCCItem.descricaoDespesa = dr["Descricao"].ToString();
                        usuarioCCItem.UnitTest = int.Parse(dr["UnitTest"].ToString());
                        lstDespesas.Add(usuarioCCItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOSDESPESA_PESQUISAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstDespesas;
        }

        public Usuario AutenticarUsuario(Usuario usuarioLogin)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            Usuario usuarioAutenticado = new Usuario();

            try
            {
                lstParametros = MontarParametrosPesquisarUsuario(usuarioLogin);

                using (DataSet dsUsuarios = dao.Pesquisar("SP_USUARIOS_CONSULTAR", lstParametros))
                {
                    if (dsUsuarios.Tables[0].Rows.Count > 0)
                    {
                        DataRow drUsuario = dsUsuarios.Tables[0].Rows[0];

                        if (usuarioLogin.Senha == drUsuario["Senha"].ToString())
                        {
                            usuarioAutenticado.idUsuario = int.Parse(drUsuario["idUsuario"].ToString());
                            usuarioAutenticado.Nome = drUsuario["Nome"].ToString();
                            usuarioAutenticado.Login = drUsuario["Login"].ToString();
                            usuarioAutenticado.Senha = drUsuario["Senha"].ToString();
                            usuarioAutenticado.ultimoAcesso = string.IsNullOrEmpty(drUsuario["UltimoAcesso"].ToString()) ? DateTime.MinValue : DateTime.Parse(drUsuario["UltimoAcesso"].ToString());
                            usuarioAutenticado.Bloqueado = int.Parse(drUsuario["Bloqueado"].ToString());
                            usuarioAutenticado.lstPermissoes = this.PesquisarPermissoesUsuario(new UsuarioPermissoes() { idUsuario = usuarioAutenticado.idUsuario });
                            usuarioAutenticado.lstUEN = this.PesquisarUENAssociadas(new Usuario() { idUsuario = usuarioAutenticado.idUsuario });
                            usuarioAutenticado.lstCC = this.PesquisarCentroCustoAssociados(new UsuarioCentroCusto() { idUsuario = usuarioAutenticado.idUsuario });
                            usuarioAutenticado.lstDespesas = this.PesquisarDespesaAssociadas(new Usuario() { idUsuario = usuarioAutenticado.idUsuario });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }


            return usuarioAutenticado;
        }

        public string IncluirUsuario(Usuario usuario, out int idUsuario)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;
            idUsuario = 0;

            try
            {
                Msg = ValidarCamposObrigatorios(usuario);

                if (Msg == string.Empty)
                {                   
                    lstParametros = MontarParametrosExecutarUsuario(usuario);

                    using (DataSet ds = dao.Pesquisar("SP_USUARIOS_INCLUIR", lstParametros))
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        idUsuario = int.Parse(dr[0].ToString());
                    }

                    lstComandos.AddRange(this.AlterarPermissoesUsuario(usuario.lstPermissoes, idUsuario));
                    lstComandos.AddRange(this.IncluirUsuarioUEN(idUsuario,usuario.lstUEN));
                    lstComandos.AddRange(this.IncluirUsuarioCentroCusto(idUsuario, usuario.lstCC));
                    lstComandos.AddRange(this.IncluirUsuarioDespesa(idUsuario, usuario.lstDespesas));

                    dao.ExecutarTransacao(lstComandos);
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_INCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string AlterarUsuario(Usuario usuario)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();            
            Dictionary<string, string> lstExclusao = new Dictionary<string, string>();
            
            string Msg = string.Empty;

            try
            {
                Msg = ValidarCamposObrigatorios(usuario);

                if (Msg == string.Empty)
                {
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOS_ALTERAR",
                        lstParametros = MontarParametrosExecutarUsuario(usuario)
                    });

                    lstExclusao.Add("@idUsuario", usuario.idUsuario.ToString());

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOSUEN_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOSCENTROCUSTO_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOSDESPESA_EXCLUIR",
                        lstParametros = lstExclusao
                    });

                    lstComandos.AddRange(this.AlterarPermissoesUsuario(usuario.lstPermissoes, usuario.idUsuario));
                    lstComandos.AddRange(this.IncluirUsuarioUEN(usuario.idUsuario, usuario.lstUEN));
                    lstComandos.AddRange(this.IncluirUsuarioCentroCusto(usuario.idUsuario, usuario.lstCC));
                    lstComandos.AddRange(this.IncluirUsuarioDespesa(usuario.idUsuario, usuario.lstDespesas));

                    dao.ExecutarTransacao(lstComandos);                    
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_ALTERAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        private List<_Transacao> IncluirUsuarioUEN(int idUsuario, List<UsuarioUEN> lstUEN)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (UsuarioUEN itemUEN in lstUEN)
            {
                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idUsuario",idUsuario.ToString());
                lstParametros.Add("@idUEN", itemUEN.idUEN.ToString());
                lstParametros.Add("@UnitTest", itemUEN.UnitTest.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_USUARIOSUEN_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        private List<_Transacao> IncluirUsuarioCentroCusto(int idUsuario, List<UsuarioCentroCusto> lstCC)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (UsuarioCentroCusto itemCC in lstCC)
            {
                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idUsuario", idUsuario.ToString());
                lstParametros.Add("@idCentroCusto", itemCC.idCentroCusto.ToString());
                lstParametros.Add("@UnitTest", itemCC.UnitTest.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_USUARIOSCENTROCUSTO_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        private List<_Transacao> IncluirUsuarioDespesa(int idUsuario, List<UsuarioDespesa> lstDespesas)
        {
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            foreach (UsuarioDespesa itemDespesa in lstDespesas)
            {
                lstParametros = new Dictionary<string, string>();
                lstParametros.Add("@idUsuario", idUsuario.ToString());
                lstParametros.Add("@idDespesa", itemDespesa.idDespesa.ToString());
                lstParametros.Add("@UnitTest", itemDespesa.UnitTest.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_USUARIOSDESPESA_INCLUIR",
                    lstParametros = lstParametros
                });
            }

            return lstComandos;
        }

        public string ExcluirUsuario(Usuario usuario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                lstParametros.Add("@idUsuario", usuario.idUsuario.ToString());
                dao.Executar("SP_USUARIOS_ALTERAR_DESATIVAR", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_ALTERAR_DESATIVAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public string ExcluirUsuarioTeste()
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {               
                dao.Executar("SP_USUARIOS_EXCLUIRTESTES", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_EXCLUIR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        public void AtualizarUltimoAcesso(Usuario usuario, int idUsuario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            try
            {
                lstParametros.Add("@idUsuario", usuario.idUsuario.ToString());
                lstParametros.Add("@UltimoAcesso", usuario.ultimoAcesso.ToString());
                dao.Executar("SP_USUARIOS_ALTERAR_ULTIMOACESSO", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_ALTERAR_ULTIMOACESSO",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }
        }

        public string AlterarUsuarioSenha(Usuario usuario, int idUsuario)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            string Msg = string.Empty;

            try
            {
                lstParametros.Add("@idUsuario", usuario.idUsuario.ToString());
                lstParametros.Add("@Senha", usuario.Senha.ToString());
                dao.Executar("SP_USUARIOS_ALTERAR_SENHA", lstParametros);
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOS_ALTERAR_SENHA",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return Msg;
        }

        #endregion

        #region Permissões de Acesso

        public List<UsuarioPermissoes> PesquisarPermissoesUsuario(UsuarioPermissoes usuarioPermissoes)
        {
            DataAccess dao = new DataAccess();
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();
            List<UsuarioPermissoes> lstPermissoes = new List<UsuarioPermissoes>();

            try
            {
                lstParametros = this.MontarParametrosPesquisarPermissoes(usuarioPermissoes);

                using (DataSet dsPermissoes = dao.Pesquisar("SP_USUARIOSPERMISSOES_CONSULTAR", lstParametros))
                {
                    foreach (DataRow drPermissao in dsPermissoes.Tables[0].Rows)
                    {
                        UsuarioPermissoes itemPermissao = new UsuarioPermissoes();
                        itemPermissao.idUsuario = usuarioPermissoes.idUsuario;
                        itemPermissao.idControle = int.Parse(drPermissao["idControle"].ToString());
                        itemPermissao.idControlePai = int.Parse(drPermissao["idControlePai"].ToString());
                        itemPermissao.nomeFormulario = drPermissao["NomeFormulario"].ToString();
                        itemPermissao.Sequencia = int.Parse(drPermissao["Sequencia"].ToString());
                        itemPermissao.nomeControle = drPermissao["NomeControle"].ToString();
                        itemPermissao.descricaoControle = drPermissao["DescricaoControle"].ToString();
                        itemPermissao.Habilitado = drPermissao["Habilitado"].ToString() == "1" ? true : false;
                        itemPermissao.objetoTela = drPermissao["ObjetoTela"].ToString() == "1" ? true : false;
                        lstPermissoes.Add(itemPermissao);
                    }
                }
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(lstParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOSPERMISSOES_CONSULTAR",
                    parametrosSQL = parametrosSQL,
                    mensagemErro = ex.ToString()
                };

                bizLogErro.IncluirLogErro(log);

                throw ex;
            }

            return lstPermissoes;
        }

        private Dictionary<string, string> MontarParametrosExecutarPermissoes(UsuarioPermissoes usuarioPermissoes)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idUsuario", usuarioPermissoes.idUsuario.ToString());
            lstParametros.Add("@idControle", usuarioPermissoes.idControle.ToString());
            lstParametros.Add("@Habilitado", usuarioPermissoes.Habilitado ? "1" : "0");
            lstParametros.Add("@UnitTest", usuarioPermissoes.UnitTest.ToString());

            return lstParametros;
        }

        private Dictionary<string, string> MontarParametrosPesquisarPermissoes(UsuarioPermissoes usuarioPermissoes)
        {
            Dictionary<string, string> lstParametros = new Dictionary<string, string>();

            lstParametros.Add("@idUsuario", usuarioPermissoes.idUsuario.Equals(0) ? null : usuarioPermissoes.idUsuario.ToString());
            lstParametros.Add("@UnitTest", usuarioPermissoes.UnitTest.Equals(0) ? null : usuarioPermissoes.UnitTest.ToString());
            
            return lstParametros;
        }

        private List<_Transacao> AlterarPermissoesUsuario(List<UsuarioPermissoes> lstPermissoes, int idUsuario)
        {
            DataAccess dao = new DataAccess();
            List<_Transacao> lstComandos = new List<_Transacao>();
            Dictionary<string, string> itemParametros = new Dictionary<string, string>();

            try
            {
                //lstParametros.Add("@idUsuario", idUsuario.ToString());
                //dao.Executar("SP_USUARIOSPERMISSOES_EXCLUIR", lstParametros);


                // Excluir permissões existentes do usuário
                itemParametros.Add("@idUsuario", idUsuario.ToString());

                lstComandos.Add(new _Transacao()
                {
                    nomeProcedure = "SP_USUARIOSPERMISSOES_EXCLUIR",
                    lstParametros = itemParametros
                });

                // Inserir as novas permissões
                foreach (UsuarioPermissoes itemPermissao in lstPermissoes)
                {
                    //lstParametros = new Dictionary<string, string>();

                    itemPermissao.idUsuario = idUsuario;
                    itemParametros = MontarParametrosExecutarPermissoes(itemPermissao);

                    //dao.Executar("SP_USUARIOSPERMISSOES_INCLUIR", lstParametros);
                    lstComandos.Add(new _Transacao()
                    {
                        nomeProcedure = "SP_USUARIOSPERMISSOES_INCLUIR",
                        lstParametros = itemParametros
                    });
                }

                return lstComandos;          
            }
            catch (Exception ex)
            {
                string parametrosSQL = string.Empty;
                parametrosSQL = helper.ConcatenarParametrosSQL(itemParametros);

                LogErro log = new LogErro()
                {
                    procedureSQL = "SP_USUARIOSPERMISSOES_EXCLUIR / SP_USUARIOSPERMISSOES_INCLUIR",
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
