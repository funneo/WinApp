using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.FromBody
{
    public class FromBodyBase<T>
    {
        public string Id { get; set; }
        public string TokenKey { get; set; }
        public int? BranchId { get; set; }
        public int? EmployeeId { get; set; }
        public string KeyWord { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string ListId { get; set; }
        public string UserName { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public T Item { get; set; }
    }
}
