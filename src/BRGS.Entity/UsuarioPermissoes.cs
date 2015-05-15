using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class UsuarioPermissoes
    {
        public int idUsuario { get; set; }
        public int idControle { get; set; }
        public int idControlePai { get; set; }
        public string nomeFormulario { get; set; }
        public int Sequencia { get; set; }
        public string nomeControle { get; set; }
        public string descricaoControle { get; set; }
        public bool Habilitado { get; set; }
        public bool objetoTela { get; set; }
        public int UnitTest { get; set; }
    }
}
