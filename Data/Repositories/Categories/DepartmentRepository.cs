using Data.FromBody.Categories;
using Data.Interfaces.Categories;
using Data.Models.Categories;
using Data.Response.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Categories
{
    public class DepartmentRepository : IDepartment
    {
        public DepartmentResponseValue Add(Department obj, string tokenKey)
        {
            var urlStr = $"/api/Department/Add";
            var fromBody = new DepartmentFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<DepartmentResponseValue>(urlStr, fromBody);
        }

        public DepartmentResponseValue Delete(int id, string tokenKey)
        {
            var urlStr = $"/api/Department/Delete";
            var item = new Department()
            {
                Id = id
            };
            var fromBody = new DepartmentFromBody()
            {
                TokenKey = tokenKey,
                Item=item
            };
            return ApiClient.ApiClient.Post<DepartmentResponseValue>(urlStr, fromBody);
        }

        public DepartmentResponseValue Get( string tokenKey)
        {
            var urlStr = $"/api/Department/GetByAll";
            var fromBody = new DepartmentFromBody()
            {
                TokenKey = tokenKey
            };
            return ApiClient.ApiClient.Post<DepartmentResponseValue>(urlStr, fromBody);
        }

        public DepartmentResponseValue GetbyId(int id, string tokenKey)
        {
            var urlStr = $"/api/Department/GetbyId";
            var item = new Department()
            {
                Id = id
            };
            var fromBody = new DepartmentFromBody()
            {
                TokenKey = tokenKey,
                Item = item
            };
            return ApiClient.ApiClient.Post<DepartmentResponseValue>(urlStr, fromBody);
        }

        public DepartmentResponseValue Update(Department obj, string tokenKey)
        {
            var urlStr = $"/api/Department/Update";
            var fromBody = new DepartmentFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<DepartmentResponseValue>(urlStr, fromBody);
        }
    }
}
