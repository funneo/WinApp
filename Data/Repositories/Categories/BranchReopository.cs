using Data.FromBody.Categories;
using Data.Interfaces.Categories;
using Data.Response.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Categories
{
    public class BranchReopository : IBranch
    {
        public BranchResponseValue Get(string tokenKey)
        {
            var urlStr = $"/api/Branch/GetByAll";
            var fromBody = new BranchFromBody()
            {
                TokenKey = tokenKey
            };
            return ApiClient.ApiClient.Post<BranchResponseValue>(urlStr, fromBody);
        }
    }
}
