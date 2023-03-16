using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserRole
    {
        public UserRole()
        {
            
        }
        public UserRole(Guid _userid,Guid _roleid)
        {
            UserId = _userid;
            RoleId = _roleid;
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }    
        public int BranchId { get; set; }
        public int? AuthorisationLevel { get; set; }
        public int? AdvanceConfirmLevel { get; set; }
        public int? PaymentConfirmLevel { get; set; }
    }
}
