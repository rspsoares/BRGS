using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Abastecimento
    {
        public int idAbastecimento { get; set; }

        [Description("Número Abastecimento")]
        public string numeroAbastecimento { get; set; }

        public int idFornecedor { get; set; }
        
        [Description("Nome Posto")]
        public string nomeFornecedor { get; set; }

        public int idVeiculo { get; set; }
        
        [Description("Placa")]
        public string placaVeiculo { get; set; }
        public string descricaoVeiculo { get; set; }
        public int idMotorista { get; set; }

        [Description("Motorista")]
        public string nomeMotorista { get; set; }        
        public int idObraEtapaGastoRealizado { get; set; }
        public int idObraEtapa { get; set; }
        public string nomeObra { get; set; }        
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public int idCentroCusto { get; set; }
        public string descricaoCentroCusto { get; set; }
        public int idDespesa { get; set; }
        public string descricaoDespesa { get; set; }
        public int idOP { get; set; }
        public int idEmissor { get; set; }
        public string numeroOP { get; set; }
        public string statusOP { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal valorTotal { get; set; }
        public int Kilometragem { get; set; }
        public decimal Litros { get; set; }
        public int UnitTest { get; set; }
    }
}
