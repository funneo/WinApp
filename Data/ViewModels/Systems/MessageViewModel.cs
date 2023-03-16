using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Systems
{
    public class MessageViewModel
    {
        public MessageViewModel(string _code, string _msg)
        {
            Code = _code;
            Message = _msg;
        }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
