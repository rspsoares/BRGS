using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class Obra
    {
        public int idObra { get; set; }
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }

        [Description("Número da Licitação")]
        public string numeroLicitacao { get; set; }

        public int idCliente { get; set; }

        [Description("Nome do Cliente")]
        public string nomeCliente { get; set; }        

        [Description("Nome do Evento")]
        public string nomeEvento { get; set; }

        public decimal valorContrato { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public int Finalizada { get; set; }
        public List<ObraGastoPrevisto> lstGastosPrevistos { get; set; }
        public List<ObraGastoRealizado> lstGastosRealizados { get; set; }
        public List<ObraFase> lstFases { get; set; }
        public List<ObraFollowUp> lstFollowUps { get; set; }
        
        public int UnitTest { get; set; }
    }
}
