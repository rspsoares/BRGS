using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public static class Parametrizacao
    {
        public static string servidor_Conexao { get; set; }
        public static string servidor_Endereco { get; set; }
        public static int diasVencimentoOPAlerta { get; set; }
        public static int diasVencimentoOPCritico { get; set; }
        public static int diasVencimentoDocumentacaoVeiculoAlerta { get; set; }
        public static int diasVencimentoDocumentacaoVeiculoCritico { get; set; }
    }
}
