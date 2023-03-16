using Data.Models.Categories;
using Data.Response.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Categories
{
    public interface ITitle
    {
        TitleResponseValue Add(Title obj,string tokenKey);
        TitleResponseValue Update(Title obj, string tokenKey);
        TitleResponseValue Delete(int id, string tokenKey);
        TitleResponseValue Get(string tokenKey);
        TitleResponseValue GetbyId(int id, string tokenKey);
    }
}
