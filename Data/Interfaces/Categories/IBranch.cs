using Data.Response.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Categories
{
   public  interface IBranch
    {
        BranchResponseValue Get(string tokenKey);
    }
}
