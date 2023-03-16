using Common.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
   public class DaiLyViewModel:DaiLy
    {       
        public int TotalRows { get; set; } 
        public bool flagCheck { get; set; }
    }
}
