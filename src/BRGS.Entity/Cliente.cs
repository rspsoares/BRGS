using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Cliente : _Auditoria, ICloneable
    {
        public int idCliente { get; set; }
        public int idCategoria { get; set; }
        public int idAtividade { get; set; }
        
        [Description("Código")]
        public string Codigo { get; set; }

        [Description("Nome")]
        public string Nome { get; set; }

        public string CPF_CNPJ { get; set; }
        public string IE { get; set; }
        public string ICM { get; set; }

        [Description("Endereço")]
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        
        [Description("Bairro")]
        public string Bairro { get; set; }

        [Description("Cidade")]
        public string Cidade { get; set; }
        
        [Description("Estado")]
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TipoPessoa { get; set; }
        public string Site { get; set; }        
        public string Observacao { get; set; }
        
        [Description("Status")]
        public string Status { get; set; }

        public List<ClienteContato> lstContatos { get; set; }
        public List<ClienteContaBancaria> lstContasBancarias { get; set; }
        public int UnitTest { get; set; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Cliente Clone()
        {
            Cliente clienteClone = (Cliente)MemberwiseClone();            
            clienteClone.lstContatos = lstContatos.Select(c => c.Clone()).ToList();
            
            return clienteClone;
        }
    }
}
