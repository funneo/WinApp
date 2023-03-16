using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiClient
{
   public class SysUser
    {
        public SysUser() { }
        public SysUser(string _username, string _passwword, int _branchId)
        {
            UserName = _username;
            Password = _passwword;
            BranchId = _branchId;
        }
        public SysUser(string userName,string id,int? _branchId,int? _auLevel,int? _adLevel,int? _pmLevel,int? _employeeId,List<string> roles, List<string> permissions)
        {
            UserName = userName;
            Id = id;
            BranchId = _branchId;
            AuthorisationLevel = _auLevel;
            AdvanceConfirmLevel = _adLevel;
            PaymentConfirmLevel = _pmLevel;
            EmployeeId = _employeeId;
            Roles = roles;
            Permissions = permissions;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }        
        public string FullName { get; set; }      
        public string IdDaiLy { get; set; }      
        public Guid UserId { get; set; }
        public int? BranchId { get; set; }
        public int? AuthorisationLevel { get; set; }
        public int? AdvanceConfirmLevel { get; set; }
        public int? PaymentConfirmLevel { get; set; }
        public int? EmployeeId { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }      

    }
}
