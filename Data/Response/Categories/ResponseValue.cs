using Data.Models.Categories;
using Data.ViewModels;
using Data.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Response
{
    public class ResponseValue<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }              
    }
}
