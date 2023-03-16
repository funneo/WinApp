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
using Data.ViewModels;

namespace Systems
{
    public partial class RoleList : ListBase
    {
        IRoleRepository _roleRepository;
        List<Data.ViewModels.RoleViewModel> roles;
        public RoleList()
        {
            InitializeComponent();
            flagCheck = true;
            _roleRepository = (IRoleRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IRoleRepository));
            roles = new List<Data.ViewModels.RoleViewModel>();
            ListColumn = new List<string>();
            PropertyInfo[] propInfos = typeof(Data.ViewModels.RoleViewModel).GetProperties();
            propInfos.ToList().ForEach(p =>
            ListColumn.Add(p.Name));
        }
       
       
        protected override void cellValueChanged()
        {
            var list = roles.Where(x => x.flagCheck);
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
            var result = _roleRepository.GetPaging(filter, PageIndex, PageSize);
            if (result!=null)
            {                
                TotalRows = result.TotalRows;
                roles = result.Items;
            }
            else
            {
                MessageEx.Show(BaseComponent.Core.MessageContstants.VIEW_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        protected override void SetData()
        {
            //base.SetData();           
            gridBase.DataSource = roles;
        }

        protected override int Delete(object item)
        {
            var role = item as Data.ViewModels.RoleViewModel;
            var id = role.Id.ToString();          
          var result = _roleRepository.Delete(id.ToString());
            if (result!=null)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var x = gridView1.GetRow(i) as Data.ViewModels.RoleViewModel;
                    if (x.Id.ToString() == id)
                    {
                        rowHandle = i;
                        break;
                    }
                }
                return 1;
            }
            else
            {
                MessageEx.Show(BaseComponent.Core.MessageContstants.DELTE_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
           
        }
        protected override void OpenUI()
        {
            frmUI = new RoleUI();
        }
    }
}
