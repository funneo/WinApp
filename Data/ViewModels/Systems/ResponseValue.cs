using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class ResponseValue
    {
        public ResponseValue(bool _isSuccess, string _code, string _msg, object _data=null)
        {
            IsSuccess = _isSuccess;
            Code = _code;
            Message = _msg;
            Data = _data;
        }
        public bool IsSuccess { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
