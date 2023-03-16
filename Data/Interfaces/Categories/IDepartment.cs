using Data.Models.Categories;
using Data.Response.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Categories
{
    public interface IDepartment
    {
        DepartmentResponseValue Add(Department obj,string tokenKey);
        DepartmentResponseValue Update(Department obj, string tokenKey);
        DepartmentResponseValue Delete(int id, string tokenKey);
        DepartmentResponseValue Get(string tokenKey);
        DepartmentResponseValue GetbyId(int id, string tokenKey);
    }
}
