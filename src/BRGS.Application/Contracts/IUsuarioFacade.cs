using BRGS.Domain;
using System.Collections.Generic;

namespace BRGS.Application.Contracts
{
    interface IUsuarioFacade
    {
        List<Usuario> Pesquisar(Usuario usuario);
        
        Usuario Autenticar(Usuario usuarioLogin);

        string Incluir(Usuario usuario, out int idUsuario);

        string Alterar(Usuario usuario);

        string Excluir(Usuario usuario);

        void AtualizarUltimoAcesso(Usuario usuario);

        string AlterarUsuarioSenha(Usuario usuario);

        List<UsuarioPermissoes> PesquisarPermissoesUsuario(UsuarioPermissoes usuarioPermissoes);
    }
}
