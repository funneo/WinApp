using Data.FromBody.Categories;
using Data.Interfaces;
using Data.Models.Categories;
using Data.Response.Categories;
using Data.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Categories
{
    public class EmployeeRepository : IEmployee
    {
        
        public EmployeeResponseValue Add(Employee obj,string tokenKey)
        {
            var urlStr = $"/api/Employee/Add";
            var fromBody = new EmployeeFromBody()
            {
                TokenKey=tokenKey,
                Item=obj
            };
            return ApiClient.ApiClient.Post<EmployeeResponseValue>(urlStr, fromBody);           
        }

        public EmployeeResponseValue Get(int branhId, string tokenKey)
        {
            var urlStr = $"/api/Employee/GetbyBranchId";
            var obj = new Employee();
            obj.BranchId = branhId;
            var fromBody = new EmployeeFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<EmployeeResponseValue>(urlStr, fromBody);
        }

        public EmployeeResponseValue GetbyId(int id, string tokenKey)
        {
            var urlStr = $"/api/Employee/GetbyId";
            var obj = new Employee();
            obj.Id = id;
            var fromBody = new EmployeeFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<EmployeeResponseValue>(urlStr, fromBody);
        }

        public EmployeeResponseValue Delete(int id,string tokenKey)
        {
            var urlStr = $"/api/Employee/Delete";
            var obj = new Employee();
            obj.Id = id;
            var fromBody = new EmployeeFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<EmployeeResponseValue>(urlStr, fromBody);
        }

        public EmployeeResponseValue Update(Employee obj, string tokenKey)
        {
            var urlStr = $"/api/Employee/Update";
            var fromBody = new EmployeeFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<EmployeeResponseValue>(urlStr, fromBody);
        }
    }
}
