using Common.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
   public class CustomerViewModel : Customer
    {       
        public int? TotalRows { get; set; } 
        public bool flagCheck { get; set; }
    }
}
