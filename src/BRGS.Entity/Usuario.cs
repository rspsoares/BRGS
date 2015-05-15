using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        [Description("Nome")]
        public string Nome { get; set; }

        [Description("Login")]
        public string Login { get; set; }

        public string Senha { get; set; }
        public DateTime ultimoAcesso { get; set; }
        public int Bloqueado { get; set; }
        public string Ativo { get; set; }
        public int UnitTest { get; set; }
        public List<UsuarioPermissoes> lstPermissoes { get; set; }
        public List<UsuarioUEN> lstUEN { get; set; }
        public List<UsuarioCentroCusto> lstCC { get; set; }
        public List<UsuarioDespesa> lstDespesas { get; set; }
    }
}
