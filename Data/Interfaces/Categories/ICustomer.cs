using Data.FromBody.Categories;
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

namespace Data.Interfaces
{
    public interface ICustomer
    {
        ResponseValue<int> Add(Customer obj);
        ResponseValue<int> Update(Customer obj);
        ResponseValue<CustomerViewModel> GetById(int id);
        ResponseValue<CustomerViewModel> GetAll(int branhId);
        ResponseValue<PagedResult<CustomerViewModel>> GetPaging(string keyword, int pageIndex,
            int pageSize, int? branhId,int? employeeId);
        ResponseValue<int> Delete(string listId);
        ResponseValue<int> Accept(int id);
    }

    
}
