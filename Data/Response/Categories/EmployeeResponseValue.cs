using Data.Models.Categories;
using Data.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Response.Categories
{
    public class EmployeeResponseValue
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public EmployeeViewModel Data { get; set; }
        public List<EmployeeViewModel>ListData { get; set; }
    }
}
