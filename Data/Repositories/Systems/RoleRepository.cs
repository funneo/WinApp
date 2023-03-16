using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClient;
using Data.Models;
using Data.ViewModels;
using Data.ViewModels.Systems;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<RoleViewModel> GetAll();
        RoleViewModel GetDetail(string id);
        PagedResult<RoleViewModel> GetPaging(string keyword, int pageIndex,
            int pageSize);
        int? Delete(string id);
        int? Add(Role role);
        int? Update(Role role);
    }

    public class RoleRepository : IRoleRepository
    {
        const string roleApi = @"/api/role";
        public IEnumerable<RoleViewModel> GetAll()
        {
            return Apibase.Get<IEnumerable<RoleViewModel>>($@"{roleApi}");
        }

        public RoleViewModel GetDetail(string id)
        {
            var modal = new GetParameter();
            modal.Id = id;
           return Apibase.Post<RoleViewModel>($@"{roleApi}/detail", modal);           
        }

        public PagedResult<RoleViewModel> GetPaging(string keyword, int pageIndex,
            int pageSize)
        {
            var modal = new GetParameter();
            modal.Keyword = keyword;
            modal.PageIndex = pageIndex;
            modal.PageSize = pageSize;
            return Apibase.Post<PagedResult<RoleViewModel>>($@"{roleApi}/paging", modal);
        }

        public int? Add(Role role)
        {
            return Apibase.Post<int?>($@"{roleApi}/Create", role);
        }

        public int? Update(Role role)
        {
            return Apibase.Post<int?>($@"{roleApi}/Update", role);
        }

        public int? Delete(string id)
        {
            return Apibase.Delete<int?>($@"{roleApi}?id={id}");
        }
    }
}
