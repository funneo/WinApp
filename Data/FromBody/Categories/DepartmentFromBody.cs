﻿using Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FromBody.Categories
{
   public class DepartmentFromBody
    {
        public string TokenKey { get; set; }
        public Department Item { get; set; }
    }
}
