﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class NFServicoItens
    {
        public int idNota { get; set; }
        public int Quantidade { get; set; }
        public string Unidade { get; set; }
        public string Descricao { get; set; }
        public decimal precoUnitario { get; set; }
        public int UnitTest { get; set; }
    }
}
