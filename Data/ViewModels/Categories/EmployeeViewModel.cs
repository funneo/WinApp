using Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Categories
{
    public class EmployeeViewModel:Employee
    {
        public List<Contract> Contracts { get; set; }
        public bool flagCheck { get; set; }
    }
}
