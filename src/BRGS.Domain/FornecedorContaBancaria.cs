﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class FornecedorContaBancaria
    {
        public int idContaBancaria { get; set; }
        public int idFornecedor { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string TipoConta { get; set; }
        public string Conta { get; set; }
        public bool Excluir { get; set; }
        public int UnitTest { get; set; }
    }
}
