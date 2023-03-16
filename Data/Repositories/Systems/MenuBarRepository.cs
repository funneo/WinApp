using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClient;
using Data.Models.Systems;
using Data.ViewModels.Systems;

namespace Data.Repositories
{
    public interface IMenuBarRepository
    {
        IEnumerable<MenuBarViewModel> GetByUserName(string userName);
    }
   public class MenuBarRepository: IMenuBarRepository
    {
        const string menuApi = @"/api/menubar";
        public IEnumerable<MenuBarViewModel> GetByUserName(string userName)
        {
            var rval= Apibase.Get<IEnumerable<MenuBarViewModel>>($@"{menuApi}?userName={userName}");
            return rval;
        }
    }
}
