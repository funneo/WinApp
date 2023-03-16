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
using Data.Interfaces;
using Data.Interfaces.Categories;
using Data.Repositories;

namespace Systems
{
    public partial class CustomerList : ListBase
    {
        ICustomer _customerRepository;
        List<Data.ViewModels.CustomerViewModel> listData;
        public CustomerList()
        {
            InitializeComponent();
            flagCheck = true;
            _customerRepository = (ICustomer)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(ICustomer));
            listData = new List<Data.ViewModels.CustomerViewModel>();
            ListColumn = new List<string>();
            PropertyInfo[] propInfos = typeof(Data.ViewModels.CustomerViewModel).GetProperties();
            propInfos.ToList().ForEach(p =>
            ListColumn.Add(p.Name));
        }       
       
        protected override void cellValueChanged()
        {
            if (rowHandle >-1)
            {
                var item = gridView1.GetRow(rowHandle) as Data.ViewModels.CustomerViewModel;
                listData.FirstOrDefault(x => x.Id == item.Id).flagCheck = !item.flagCheck;
            }

            var list = listData.Where(x => x.flagCheck);
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
            var result = _customerRepository.GetPaging(filter,PageIndex,PageSize,null,null);
            TotalRows = result.Data.TotalRows;
            if (result.Code.Equals("401"))//Nếu không có quền thì cho logout ra màn hình chính
            {
                
            }else if(result.Code.Equals("200") || result.Code.Equals("201")){
                listData = result.Data.Items;
            }else
            {
                listData = result.Data.Items;
                MessageBox.Show($"{Common.MessageContstants.VIEW_ERR + result.Message}", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            
        }
        protected override void SetData()
        {
            //base.SetData();           
            gridBase.DataSource = listData;
        }

        protected override int Delete(object item)
        {
            var obj = item as Data.ViewModels.CustomerViewModel;
            var id = obj.Id;          
            _customerRepository.Delete(id.ToString());
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var x = gridView1.GetRow(i) as Data.ViewModels.CustomerViewModel;
                if (x.Id == id)
                {
                    rowHandle = i;
                    break;
                }
            }
            return 1;
        }
        protected override void OpenUI()
        {
            frmUI = new CustomerUI();
        }
    }
}
