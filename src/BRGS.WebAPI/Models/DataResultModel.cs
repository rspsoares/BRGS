using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRGS.WebAPI.Models
{
    public class DataResultModel
    {
        public DataResultModel()
        { }

        public DataResultModel(bool success, string message, string detail)
        {
            Success = success;
            Message = message;
            Detail = detail;
        }

        public DataResultModel(bool success, string message, byte[] result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public DataResultModel(bool success, string message, string detail, Guid? idObject)
            : this(success, message, detail)
        {
            ID_OBJECT = idObject;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public byte[] Result { get; set; }
        public int Total { get; set; }
        public Guid? ID_OBJECT { get; set; }
    }
}
