using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Entity
{
    public class ObraEtapa
    {
        public int idObraEtapa { get; set; }
        public int idObra { get; set; }
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string Descricao { get; set; }
        public string numeroLicitacao { get; set; }
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }                
        public string nomeEvento { get; set; }
        public decimal valorContrato { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public int Finalizada { get; set; }
        public decimal saldoEtapa { get; set; }
        public decimal totalNotaFiscalGerada { get; set; }
        public List<ObraEtapaGastoPrevisto> lstGastosPrevistos { get; set; }
        public List<ObraEtapaGastoRealizado> lstGastosRealizados { get; set; }
        public List<ObraEtapaFase> lstFases { get; set; }
        public List<ObraEtapaFollowUp> lstFollowUps { get; set; }
        //public List<ObraEtapaPlanejamento> lstPlanejamentos { get; set; }
        public int UnitTest { get; set; }
    }
}
