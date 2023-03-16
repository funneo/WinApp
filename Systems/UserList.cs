using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseComponent;
using Common;
using Data.Repositories;

namespace Systems
{
    public partial class UserList : ListBase
    {
        IUserRepository _userRepository;
        List<Data.ViewModels.UserViewModel> users;
        public UserList()
        {
            InitializeComponent();
            flagCheck = true;
            _userRepository = (IUserRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IUserRepository));
            users = new List<Data.ViewModels.UserViewModel>();
            ListColumn = new List<string>();
            PropertyInfo[] propInfos = typeof(Data.ViewModels.UserViewModel).GetProperties();
            propInfos.ToList().ForEach(p =>
            ListColumn.Add(p.Name));
        }
       
       
        protected override void cellValueChanged()
        {
            var list = users.Where(x => x.flagCheck);
            if (list.Count() == 1)
            {
                flagSua = true;
                flagXoa = true;
                entityItem = list.FirstOrDefault();
            }
            else
            {
                flagSua = false;
                flagXoa = false;
            }
        }
        protected override void UpdateData()
        {
            base.UpdateData();
            string filter = null;
            if (barEditItemtextSearch.EditValue != null)
                filter = barEditItemtextSearch.EditValue.ToString().ToNull();
            var result = _userRepository.GetPaging(filter,PageIndex,PageSize,null);
            TotalRows = result.TotalRows;
            users = result.Items;
        }
        protected override void SetData()
        {
            //base.SetData();           
            gridBase.DataSource = users;
        }

        protected override int Delete(object item)
        {
            var user = item as Data.ViewModels.UserViewModel;
            var id = user.Id.ToString();          
            _userRepository.Delete(id.ToString());
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var x = gridView1.GetRow(i) as Data.ViewModels.UserViewModel;
                if (x.Id.ToString() == id)
                {
                    rowHandle = i;
                    break;
                }
            }
            return 1;
        }
        protected override void OpenUI()
        {
            frmUI = new UserUI();
        }
    }
}
