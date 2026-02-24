using BRGS.Entity.DTO;
using System.Collections.Generic;

namespace BRGS.WebAPI.Models
{
    public class OrdemPagamentoGridModel
    {
        public OrdemPagamentoGridModel()
        {
            OPResults = new List<OrdemPagamentoGridMobileDTO>();
        }

        public List<OrdemPagamentoGridMobileDTO> OPResults { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Total { get; set; }
    }
}