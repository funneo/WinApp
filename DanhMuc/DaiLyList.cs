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

namespace WinApp.DanhMuc
{
    public partial class DaiLyList : ListBase
    {
        IDaiLyRepository _daiLyRepository;
        List<Data.ViewModels.DaiLyViewModel> daiLys;
        public DaiLyList()
        {
            InitializeComponent();
            flagCheck = true;           
        }
       
       
        protected override void cellValueChanged()
        {
            var list = daiLys.Where(x => x.flagCheck);
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
            var result = _daiLyRepository.GetPaging(filter,PageIndex,PageSize,null);
            TotalRows = result.TotalRows;
            daiLys = result.Items;
        }
        protected override void SetData()
        {
            //base.SetData();           
            gridBase.DataSource = daiLys;
        }

        protected override int Delete(object item)
        {
            var daiLy = item as Data.ViewModels.DaiLyViewModel;
            int id = daiLy.Id;          
            _daiLyRepository.Delete(id.ToString());
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var x = gridView1.GetRow(i) as Data.ViewModels.DaiLyViewModel;
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
            frmUI = new DaiLyUI();
        }
    }
}
