using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Customer : Auditable
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string NameEnglish { get; set; }
        public string Symbol { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public int? IndustrialZoneId { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string CountryCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string Contact { get; set; }
        public string ContactPosition { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public int? ParentId { get; set; }
        public string Notes { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
