using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Systems
{
    public class PermissionViewModel
    {
        public Guid RoleId { get; set; }
        public string FunctionId { get; set; }
        public string ActionId { get; set; }
    }
}
