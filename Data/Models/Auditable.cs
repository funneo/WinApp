using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Auditable
    {
        public Guid? CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public bool Status { set; get; }
        public bool Delete { get; set; }
    }
}
