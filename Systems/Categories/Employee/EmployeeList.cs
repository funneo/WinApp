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
    public partial class EmployeeList : ListBase
    {
        IEmployee _employeeRepository;
        List<Data.ViewModels.Categories.EmployeeViewModel> employees;
        public EmployeeList()
        {
            InitializeComponent();
            flagCheck = true;
            _employeeRepository = (IEmployee)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IEmployee));
            employees = new List<Data.ViewModels.Categories.EmployeeViewModel>();
            ListColumn = new List<string>();
            PropertyInfo[] propInfos = typeof(Data.ViewModels.Categories.EmployeeViewModel).GetProperties();
            propInfos.ToList().ForEach(p =>
            ListColumn.Add(p.Name));
        }
       
       
        protected override void cellValueChanged()
        {
            var list = employees.Where(x => x.flagCheck);
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
            var result = _employeeRepository.Get(4,Common.CommonVariable.TokenKey);
            if(result.Code.Equals("401"))//Nếu không có quền thì cho logout ra màn hình chính
            {
                
            }else if(result.Code.Equals("200") || result.Code.Equals("201")){
                employees = result.ListData;
            }else
            {
                employees = result.ListData;
                MessageBox.Show($"{Common.MessageContstants.VIEW_ERR + result.Message}", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

               
            
        }
        protected override void SetData()
        {
            //base.SetData();           
            gridBase.DataSource = employees;
        }

        protected override int Delete(object item)
        {
            var employee = item as Data.ViewModels.Categories.EmployeeViewModel;
            var id = employee.Id;          
            _employeeRepository.Delete(id,Common.CommonVariable.TokenKey);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var x = gridView1.GetRow(i) as Data.ViewModels.Categories.EmployeeViewModel;
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
            frmUI = new EmployeeUI();
        }
    }
}
