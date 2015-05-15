using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRGS.Domain
{
    public class FreteObra
    {
        public int idFreteObra { get; set; }
        public int idFrete { get; set; }
        public int idObra { get; set; }
        public string descricaoObra { get; set; }
        public int idObraGastoRealizado { get; set; }
        public int idOP { get; set; }
        public int idUEN { get; set; }
        public string descricaoUEN { get; set; }
        public int idCentroCusto { get; set; }
        public string descricaoCentroCusto { get; set; }
        public int idDespesa { get; set; }
        public string descricaoDespesa { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }
}
