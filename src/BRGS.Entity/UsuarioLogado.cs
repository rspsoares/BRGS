using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public static class UsuarioLogado
    {
        public static int idUsuario { get; set; }
        public static string Nome { get; set; }
        public static DateTime dataPublicacao { get; set; }
        public static List<UsuarioPermissoes> lstPermissoes { get; set; }
        public static List<UsuarioUEN> lstUEN { get; set; }
        public static List<UsuarioCentroCusto> lstCC { get; set; }
        public static List<UsuarioDespesa> lstDespesas { get; set; }
    }
}
