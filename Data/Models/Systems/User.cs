using System;
using System.Collections.Generic;
using System.Text;
using Common.Enums;

namespace Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool Status { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public bool? Disable { get; set; }      
        public List<UserRole> UserRoles { get; set; }
    }
}
