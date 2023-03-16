using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Systems
{
   public class ChangedPasswordViewModel
    {       
        public string UserName { set; get; }      
        public string CurrentPassword { set; get; }       
        public string Password { get; set; }      
        public string ConfirmPassword { get; set; }
    }
}
