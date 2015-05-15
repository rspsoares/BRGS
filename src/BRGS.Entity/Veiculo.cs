using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class Veiculo
    {
        public int idVeiculo { get; set; }

        [Description("Descrição")]
        public string Descricao { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public int Modelo { get; set; }
        public string Chassi { get; set; }
        public string Cor { get; set; }
        public string Rastreador { get; set; }
        public int semParar { get; set; }
        public string Seguradora { get; set; }
        public DateTime dataVencimentoSeguro { get; set; }
        public string Renavam { get; set; }
        public DateTime dataVencimentoIPVA {get; set; }
        public DateTime dataVencimentoDPVAT { get; set; }
        public List<Abastecimento> lstAbastecimentos { get; set; }
        public List<Manutencao> lstManutencoes { get; set; }
        public int UnitTest { get; set; }
    }
}
