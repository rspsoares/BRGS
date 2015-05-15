using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        [Description("Razão Social")]
        public string razaoSocial { get; set; }

        [Description("Nome Fantasia")]
        public string nomeFantasia { get; set; }
        public string Atividade { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CNPJ { get; set; }
        public string ICM { get; set; }
        public string inscricaoEstadual { get; set; }        
        public byte[] Logotipo { get; set; }
        public List<EmpresaContaBancaria> lstContasBancarias { get; set; }
        public int UnitTest { get; set; }
    }
}
