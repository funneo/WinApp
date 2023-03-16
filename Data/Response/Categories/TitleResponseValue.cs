using Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Response.Categories
{
   public class TitleResponseValue
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Title Data { get; set; }
        public List<Title> ListData { get; set; }
    }
}
