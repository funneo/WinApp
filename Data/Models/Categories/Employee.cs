using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Categories
{
    public class Employee
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Sex { get; set; }
        public string IdNumber { get; set; }
        public DateTime? IssueedDate { get; set; }
        public string IssueedPlace { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int TitleId { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public bool Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ContractDate { get; set; }
        public string Note { get; set; }
        public string ImagePath { get; set; }
    }
}
