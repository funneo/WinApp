using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Repositories;
using Data.ViewModels.Systems;

namespace Systems
{
    public partial class PermissionUI : BaseComponent.baseForm
    {
        IFunctionRepository  _functionRepository;
        IRoleRepository _roleRepository;
        private List<string> listActionId;
        public PermissionUI()
        {
            InitializeComponent();
            listActionId = new List<string>();
            _functionRepository = (IFunctionRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IFunctionRepository));
            _roleRepository = (IRoleRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IRoleRepository));
        }

        private void PermissionUI_Load(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            var listColumns = new List<Common.ColumProperty>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ParentId", typeof(System.String));
            dt.Columns.Add("FuntionId", typeof(System.String));
            dt.Columns.Add("FuntionName", typeof(System.String));
            listColumns.Add(new Common.ColumProperty("ParentId","Nhóm quyền"));
            listColumns.Add(new Common.ColumProperty("FuntionName", "Chức năng"));
            var listRoles = _roleRepository.GetAll();
            Common.BindingData.Load_Combobox(listRoles, lookUpEdit_NhomQuyen, "Id", "Name");
            var listQuyens = _functionRepository.GetAllWithPermission();
            var listActions = _functionRepository.GetAllAction();
            listActions.ToList().ForEach(a => { 
                dt.Columns.Add(a.Id, typeof(System.Boolean));
                listColumns.Add(new Common.ColumProperty(a.Id, a.Name));
                listActionId.Add(a.Id);
            });

            listQuyens.Where(x=>x.ParentId==null).ToList().ForEach(x =>
            {                             
                listQuyens.Where(z => z.ParentId == x.Id).ToList().ForEach(q =>
                {
                    var r = dt.NewRow();
                    r["ParentId"] = x.Name;
                    r["FuntionId"] = q.Id;
                    r["FuntionName"] = q.Name;
                    q.Actions.ForEach(a =>
                    {
                        r[a.Id] = false;
                    });
                    dt.Rows.Add(r);
                });              
            });
            //Tạo côt
            int i = 0;
            listColumns.ForEach(c => {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = c.FieldName;
                col.Caption = c.Caption;
                col.Width = 100;
                col.VisibleIndex = i;
                if (c.FieldName == "ParentId")
                    col.GroupIndex = 0;
                i++;
                gridView1.Columns.Add(col);
            });
            gridControl1.DataSource = dt;
            gridView1.ExpandAllGroups();
            gridView1.BestFitColumns();
        }

        private void lookUpEdit_NhomQuyen_EditValueChanged(object sender, EventArgs e)
        {
            var dt = gridControl1.DataSource as DataTable;
            foreach (DataRow r in dt.Rows)
            {
                listActionId.ForEach(a =>
                {
                    if (r[a] != null && r[a] != DBNull.Value && (bool)r[a] == true)
                        r[a] = false;
                });
            }
            var roleId = lookUpEdit_NhomQuyen.EditValue.ToString();
            var listPermissions = _functionRepository.GetAllRolePermissions(roleId);
            if (listPermissions.Any())
            {
                foreach (DataRow r in dt.Rows)
                {
                    listPermissions.ToList().ForEach(p =>
                    {
                        if (p.FunctionId == (string)r["FuntionId"])
                        {
                            r[p.ActionId] = true;
                        }
                    });
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var roleId = lookUpEdit_NhomQuyen.EditValue.ToString();
            if(string.IsNullOrWhiteSpace(roleId))
            {
                BaseComponent.MessageEx.Show("Chưa chọn nhóm quyền!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }    
            var dt = gridControl1.DataSource as DataTable;
            var listPermissions = new List<PermissionViewModel>();
            foreach(DataRow r in dt.Rows)
            {
                listActionId.ForEach(a =>
                {
                    if (r[a] != null && r[a] != DBNull.Value && (bool)r[a] == true)
                    {
                        var item = new PermissionViewModel();
                        item.FunctionId = (string)r["FuntionId"];
                        item.ActionId = a;
                        listPermissions.Add(item);
                    }
                });
            }
          var result=  _functionRepository.SavePermissions(roleId, listPermissions);
            if (result != null)
            {
                BaseComponent.MessageEx.Show("Cập nhật thành công!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                BaseComponent.MessageEx.Show("Có lỗi cập nhật dữ liệu!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
