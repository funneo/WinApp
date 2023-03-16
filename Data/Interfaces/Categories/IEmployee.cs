using Data.FromBody.Categories;
using Data.Models.Categories;
using Data.Response.Categories;
using Data.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IEmployee
    {
        /// <summary>
        /// Tạo mới Nhân viên
        /// </summary>
        /// <param name="obj">Employee</param>
        /// <returns>Employee</returns>
        EmployeeResponseValue Add(Employee obj, string tokenKey);

        /// <summary>
        /// Cập nhật thông tin Nhân viên
        /// </summary>
        /// <param name="obj">Employee</param>
        /// <returns>Employee</returns>
        EmployeeResponseValue Update(Employee obj, string tokenKey);

        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EmployeeViewModel</returns>
        EmployeeResponseValue GetbyId(int id,string tokenKey);

        EmployeeResponseValue Get(int branhId, string tokenKey);


        EmployeeResponseValue Delete(int id, string tokenKey);
    }

    
}
