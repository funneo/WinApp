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
    public class TitleRepository : ITitle
    {
        public TitleResponseValue Add(Title obj, string tokenKey)
        {
            var urlStr = $"/api/Title/Add";
            var fromBody = new TitleFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<TitleResponseValue>(urlStr, fromBody);
        }

        public TitleResponseValue Delete(int id, string tokenKey)
        {
            var urlStr = $"/api/Title/Delete";
            var obj = new Title()
            {
                Id=id
            };
            var fromBody = new TitleFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<TitleResponseValue>(urlStr, fromBody);
        }

        public TitleResponseValue Get( string tokenKey)
        {
            var urlStr = $"/api/Title/GetByAll";
            var fromBody = new TitleFromBody()
            {
                TokenKey = tokenKey
            };
            return ApiClient.ApiClient.Post<TitleResponseValue>(urlStr, fromBody);
        }

        public TitleResponseValue GetbyId(int id, string tokenKey)
        {
            var urlStr = $"/api/Title/GetById";
            var obj = new Title()
            {
                Id = id
            };
            var fromBody = new TitleFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<TitleResponseValue>(urlStr, fromBody);
        }

        public TitleResponseValue Update(Title obj, string tokenKey)
        {
            var urlStr = $"/api/Title/Update";
            var fromBody = new TitleFromBody()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            return ApiClient.ApiClient.Post<TitleResponseValue>(urlStr, fromBody);
        }
    }
}
