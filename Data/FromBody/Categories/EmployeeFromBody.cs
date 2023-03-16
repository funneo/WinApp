using Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FromBody.Categories
{
   public class EmployeeFromBody
    {
        public string TokenKey { get; set; }
        public Employee Item { get; set; }
    }
}
