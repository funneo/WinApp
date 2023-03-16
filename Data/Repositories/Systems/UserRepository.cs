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
    public interface IUserRepository
    {
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetDetail(string id);
        PagedResult<UserViewModel> GetPaging(string keyword, int pageIndex,
            int pageSize, int? branchId);
        int? Delete(string listId);
        int? Add(User user);
        int? Update(User user);
        int? ChangedPass(ChangedPasswordViewModel model);
        int? ResetPass(ChangedPasswordViewModel model);
    }

    public class UserRepository : IUserRepository
    {
        const string userApi = @"/api/user";
        public IEnumerable<UserViewModel> GetAll()
        {
            return Apibase.Get<IEnumerable<UserViewModel>>($@"{userApi}");
        }

        public UserViewModel GetDetail(string id)
        {
            var modal = new GetParameter();
            modal.Id = id;
            return Apibase.Post<UserViewModel>($@"{userApi}/detail", modal);
        }

        public PagedResult<UserViewModel> GetPaging(string keyword, int pageIndex,
            int pageSize, int? branchId)
        {
            var modal = new GetParameter();
            modal.Keyword = keyword;
            modal.PageIndex = pageIndex;
            modal.PageSize = pageSize;
            modal.BranchId = branchId;
            var result = Apibase.Post<PagedResult<UserViewModel>>($@"{userApi}/paging", modal);
            return result;
        }

        public int? Add(User user)
        {
          return Apibase.Post<int?>($@"{userApi}/Create", user);          
        }

        public int? Update(User user)
        {
            return Apibase.Post<int?>($@"{userApi}/Update", user);
        }

        public int? Delete(string id)
        {
           return Apibase.Delete<int?>($@"{userApi}?id={id}");          
        }

        public int? ChangedPass(ChangedPasswordViewModel model)
        {
            return Apibase.Post<int?>($@"/api/account/changedpass", model);
        }

        public int? ResetPass(ChangedPasswordViewModel model)
        {
            return Apibase.Post<int?>($@"/api/account/resetpass", model);
        }
    }
}
