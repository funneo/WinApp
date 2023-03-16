using Data.FromBody;
using Data.FromBody.Categories;
using Data.Interfaces;
using Data.Models;
using Data.Models.Categories;
using Data.Response;
using Data.Response.Categories;
using Data.ViewModels;
using Data.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Categories
{
    public class CustomerRepository : ICustomer
    {      
        private string tokenKey= Common.CommonVariable.TokenKey;
        public ResponseValue<CustomerViewModel> GetAll(int branhId)
        {
            var urlStr = $"/api/Customer/GetAll";          
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                BranchId = branhId,
                EmployeeId=null
            };
            return ApiClient.ApiClient.Post<ResponseValue<CustomerViewModel>>(urlStr, fromBody);
        }

        public ResponseValue<CustomerViewModel> GetById(int id)
        {
            var urlStr = $"/api/Customer/GetbyId";          
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                Id = id.ToString()
            };
            return ApiClient.ApiClient.Post<ResponseValue<CustomerViewModel>>(urlStr, fromBody);
        }

      public ResponseValue<PagedResult<CustomerViewModel>> GetPaging(string keyword, int pageIndex,
           int pageSize, int? branhId, int? employeeId)
        {
            var urlStr = $"/api/Customer/GetPaging";
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                KeyWord=keyword,
                PageIndex=pageIndex,
                PageSize=pageSize,
                BranchId=branhId,
                EmployeeId=employeeId
            };
            var result = ApiClient.ApiClient.Post<ResponseValue<PagedResult<CustomerViewModel>>>(urlStr, fromBody);
            return result;
        }
      
        public ResponseValue<int> Add(Customer obj)
        {
            var urlStr = $"/api/Customer/Add";
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<ResponseValue<int>>(urlStr, fromBody);
        }

        public ResponseValue<int> Update(Customer obj)
        {
            var urlStr = $"/api/Customer/Update";
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<ResponseValue<int>>(urlStr, fromBody);
        }

        public ResponseValue<int> Delete(string listId)
        {
            var urlStr = $"/api/Customer/Delete";          
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                ListId = listId
            };
            return ApiClient.ApiClient.Post<ResponseValue<int>>(urlStr, fromBody);
        }

        public ResponseValue<int> Accept(int id)
        {
            var urlStr = $"/api/Customer/Accept";
            var fromBody = new FromBodyBase<Customer>()
            {
                TokenKey = tokenKey,
                Id = id.ToString()
            };
            return ApiClient.ApiClient.Post<ResponseValue<int>>(urlStr, fromBody);
        }

    }
}
