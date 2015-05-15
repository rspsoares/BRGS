using BRGS.Application.Contracts;
using BRGS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRGS.Application.Bindings
{
    public class UsuarioFacade : IUsuarioFacade
    {
        public virtual List<Usuario> Pesquisar(Usuario usuario)
        {
            return new List<Usuario>();
        }

        public virtual Usuario Autenticar(Usuario usuarioLogin)
        {
            return new Usuario();
        }

        public virtual string Incluir(Usuario usuario, out int idUsuario)
        {
            idUsuario = 0;
            return "";
        }

        public virtual string Alterar(Usuario usuario)
        {
            return "";
        }

        public virtual string Excluir(Usuario usuario)
        {
            return "";
        }

        public virtual void AtualizarUltimoAcesso(Usuario usuario)
        {

        }

        public virtual string AlterarUsuarioSenha(Usuario usuario)
        {
            return "";
        }

        public virtual List<UsuarioPermissoes> PesquisarPermissoesUsuario(UsuarioPermissoes usuarioPermissoes)
        {
            return new List<UsuarioPermissoes>();
        }
    }
}
