using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.ViewModels;
using ApiClient;
using Data.ViewModels.Systems;

namespace Data.Repositories
{
    public interface IFunctionRepository
    {
        FunctionViewModel GetById(string functionId);
        IEnumerable<FunctionActionViewModel> GetAllWithPermission();
        IEnumerable<PermissionViewModel> GetAllRolePermissions(string roleId);
        IEnumerable<ActionViewModel> GetAllAction();
        int? SavePermissions(string roleId, List<PermissionViewModel> permissionViewModels);
    }
   public class FunctionRepository:IFunctionRepository
    {
      public  FunctionViewModel GetById(string functionId)
        {
            return Apibase.Get<FunctionViewModel>($@"/api/function/{functionId}");
        }

        public IEnumerable<FunctionActionViewModel> GetAllWithPermission()
        {
            return Apibase.Get<IEnumerable<FunctionActionViewModel>>(@"/api/permission/function-actions"); 
        }

        public IEnumerable<PermissionViewModel> GetAllRolePermissions(string roleId)
        {
            return Apibase.Get<IEnumerable<PermissionViewModel>>($@"/api/permission/{roleId}/role-permissions");
        }

        public IEnumerable<ActionViewModel> GetAllAction()
        {
            return Apibase.Get<IEnumerable<ActionViewModel>>($@"/api/permission/getall-action");
        }

        public int? SavePermissions(string roleId,List<PermissionViewModel> permissionViewModels)
        {
            return Apibase.Post<int?>($@"/api/permission/{roleId}/save-permissions", permissionViewModels);
        }
    }
}
