using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClient;
using Data.ViewModels.Systems;

namespace Data.Repositories
{
    public interface ITaskPaneRepository
    {
        IEnumerable<TaskPaneViewModel> GetByUserName(string userName);
    }
   public class TaskPaneRepository:ITaskPaneRepository
    {
        public IEnumerable<TaskPaneViewModel> GetByUserName(string userName)
        {
            return Apibase.Get<IEnumerable<TaskPaneViewModel>>($@"/api/taskpane?userName={userName}");
        }
    }
}
