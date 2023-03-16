using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Response.Categories
{
   public class BranchResponseValue
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Branch Data { get; set; }
        public List<Branch> ListData { get; set; }
    }
}
