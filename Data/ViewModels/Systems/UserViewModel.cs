﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.ViewModels
{
   public class UserViewModel:User
    {      
        public int TotalRows { get; set; }
        public bool flagCheck { get; set; }
    }
}
