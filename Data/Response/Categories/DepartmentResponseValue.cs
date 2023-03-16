using Data.Models;
using Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Response.Categories
{
   public class DepartmentResponseValue
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Department Data { get; set; }
        public List<Department> ListData { get; set; }
    }
}
