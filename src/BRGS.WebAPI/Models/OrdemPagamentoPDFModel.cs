namespace BRGS.WebAPI.Models
{
    public class OrdemPagamentoPDFModel
    {
        public byte[] PDFContent { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}