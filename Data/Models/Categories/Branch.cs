using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data.DA;

namespace Data.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int ParentId { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string Representative { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Note { get; set; }
    }
}
