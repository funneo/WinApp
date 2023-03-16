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
    public interface IDaiLyRepository
    {
        IEnumerable<DaiLyViewModel> GetAll();
        DaiLyViewModel GetDetail(int id);
        PagedResult<DaiLyViewModel> GetPaging(string keyword, int pageIndex,
            int pageSize, int? idDaiLy);
        int Delete(string listId);
        ResponseValue Add(DaiLy daiLy);
        ResponseValue Update(DaiLy daiLy);
    }
    
   public class DaiLyRepository:IDaiLyRepository
    {
        const string daiLyApi = @"/api/daily";
        public IEnumerable<DaiLyViewModel> GetAll()
        {
            return Apibase.Get<IEnumerable<DaiLyViewModel>>($@"{daiLyApi}");
        }

        public DaiLyViewModel GetDetail(int id)
        {
            var modal = new GetParameter();
            modal.Id =id.ToString();          
            return Apibase.Put<DaiLyViewModel>($@"{daiLyApi}/detail",modal);
        }

        public PagedResult<DaiLyViewModel> GetPaging(string keyword, int pageIndex,
            int pageSize, int? idDaiLy)
        {
            var modal = new GetParameter();
            modal.Keyword = keyword;
            modal.PageIndex = pageIndex;
            modal.PageSize = pageSize;           
            var result= Apibase.Put<PagedResult<DaiLyViewModel>>($@"{daiLyApi}/paging",modal);
            return result;
        }

        public ResponseValue Add(DaiLy daiLy)
        {
            return Apibase.Post<ResponseValue>($@"{daiLyApi}", daiLy);             
        }

        public ResponseValue Update(DaiLy daiLy)
        {
            return Apibase.Put<ResponseValue>($@"{daiLyApi}", daiLy);
        }

        public int Delete(string listId)
        {
          var result=  Apibase.Delete($@"{daiLyApi}?listId={listId}");
            return 1;
          //var meg=  JsonConvert.DeserializeObject<ResponseValue>(result);
          //return meg.Msg == "Ok" ? 1 : -1;
        }
    }
}
