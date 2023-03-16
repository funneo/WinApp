using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Systems
{
   public class GetParameter
    {
        public string Id { get; set; }
        public int? BranchId { get; set; }
        public string UserName { get; set; }
        public string Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
    }
}
