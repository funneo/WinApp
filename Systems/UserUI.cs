using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Interfaces;
using Data.Interfaces.Categories;
using Data.Models;
using Data.Repositories;
using DevExpress.Data.Extensions;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Systems
{
    public partial class UserUI : BaseComponent.UIBase
    {
        IUserRepository _userRepository;
        IRoleRepository _roleRepository;
        IBranch _branchRepository;
        IEmployee _employeeRepository;
        string _userId  = "";
        public UserUI()
        {
            InitializeComponent();
            txtUserName.Tag = nameof(Data.Models.User.UserName);
            txtPassword.Tag = nameof(Data.Models.User.Password);
            txtDiaChi.Tag = nameof(Data.Models.User.Address);
            txtEmail.Tag = nameof(Data.Models.User.Email);
            txtFullName.Tag = nameof(Data.Models.User.FullName);
            checkStatus.Tag = nameof(Data.Models.User.Status);
            txtTel.Tag = nameof(Data.Models.User.PhoneNumber);
            lookUpEdit_Employee.Tag= nameof(Data.Models.User.EmployeeId);
            checkStatus.Checked = true;
            _userRepository = (IUserRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IUserRepository));
            _roleRepository= (IRoleRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IRoleRepository));
            _branchRepository = (IBranch)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IBranch));
            _employeeRepository = (IEmployee)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IEmployee));
        }

        protected override void UIBase_Load(object sender, EventArgs e)
        {
            base.UIBase_Load(sender, e);           
            var listRoles = _roleRepository.GetAll().ToList();
            var listBranch = _branchRepository.Get(Common.CommonVariable.TokenKey).ListData;
            var dtRole = new DataTable("Role");
            dtRole.Columns.AddRange(new DataColumn[]{
                new DataColumn("Id",typeof(System.String)),
                new DataColumn("Name",typeof(System.String)),            
                new DataColumn("Description",typeof(System.String))
            });
            listRoles.ForEach(x =>
            {
                var r = dtRole.NewRow();              
                r["Id"] = x.Id.ToString();
                r["Name"] = x.Name;
                r["Description"] = x.Description;
                dtRole.Rows.Add(r);
            });
            Common.BindingData.Load_Combobox(dtRole, repositoryItemLookUpEdit_Role, "Id", "Name");
            Common.BindingData.Load_Combobox(listBranch, lookUpEdit_Branch, "Id", "BranchName");
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{ 
                new DataColumn("Check",typeof(System.Boolean)),
                new DataColumn("BranchId",typeof(System.Int32)),
                new DataColumn("BranchCode",typeof(System.String)),
                new DataColumn("RoleId",typeof(System.String)),
                new DataColumn("AuthLevel",typeof(System.Int32)),
                new DataColumn("AdLevel",typeof(System.Int32)),
                new DataColumn("PmLevel",typeof(System.Int32))                
            });
            listBranch.ForEach(x =>
            {
                var r = dt.NewRow();
                r["Check"] = false;
                r["BranchId"] = x.Id;
                r["BranchCode"] = x.BranchCode;
                r["RoleId"] = null;
                r["AuthLevel"] = 5;
                r["AdLevel"] = 0;
                r["PmLevel"] = 0;
                dt.Rows.Add(r);
            });
            //listRoles.ForEach(item =>
            //{
            //    checkedListBoxRoles.Items.Add(item.Name,item.Description);
            //});
            //checkedListBoxRoles.DataSource = listRoles;
            //checkedListBoxRoles.DisplayMember = nameof(Role.Description);
            //checkedListBoxRoles.ValueMember = nameof(Role.Id);
            if (flagEdit)
            {
                var user = entityData as Data.Models.User;
                _userId = user.Id.ToString();
                user = _userRepository.GetDetail(_userId);
                var roles = user.UserRoles;
                roles.ForEach(r =>
                {
                    var dr = dt.Select($"BranchId={r.BranchId}");
                    if (dr.Length > 0)
                    {
                        dr[0]["Check"] = true;
                        dr[0]["RoleId"] = r.RoleId;
                        dr[0]["AuthLevel"] = r.AuthorisationLevel??5;
                        dr[0]["AdLevel"] = r.AdvanceConfirmLevel??0;
                        dr[0]["PmLevel"] = r.PaymentConfirmLevel??0;
                    }
                });
                //for(int i=0; i<checkedListBoxRoles.ItemCount;i++)              
                //{
                //    var roleName = checkedListBoxRoles.Items[i].Value as string;
                  
                //    if (roles.FindIndex(x => x == roleName) != -1)
                //        checkedListBoxRoles.SetItemCheckState(i, CheckState.Checked);
                //};
            }
            gridControl1.DataSource = dt;

        }

        protected override int Add()
        {          
            var listRoles = new List<string>();            
            Data.Models.User user = new Data.Models.User();
            user.EmployeeId = (int?)lookUpEdit_Employee.EditValue;
            user.Password = txtPassword.Text;
            user.UserName = txtUserName.Text;
            user.Email = txtEmail.Text;
            user.FullName =string.IsNullOrWhiteSpace(txtFullName.Text)?lookUpEdit_Employee.Text: txtFullName.Text;
            user.Address = txtDiaChi.Text;
            user.PhoneNumber = txtTel.Text;
            user.Status = checkStatus.Checked;
            user.Id =new Guid();
            var dt = gridControl1.DataSource as DataTable;
            user.UserRoles = new List<UserRole>();
            foreach (DataRow r in dt.Rows)
            {
                var _userRole = new UserRole();
                if ((bool)r["Check"])
                {
                    _userRole.UserId = user.Id;
                    _userRole.RoleId = new Guid(r["RoleId"].ToString());
                    _userRole.BranchId = int.Parse(r["BranchId"].ToString());
                    _userRole.AuthorisationLevel = int.Parse(r["AuthLevel"].ToString());
                    _userRole.AdvanceConfirmLevel = int.Parse(r["AdLevel"].ToString());
                    _userRole.PaymentConfirmLevel = int.Parse(r["PmLevel"].ToString());
                    user.UserRoles.Add(_userRole);
                }
            }
            //foreach (var item in checkedListBoxRoles.CheckedItems)
            //{
            //    var roleName = (item as CheckedListBoxItem).Value as string;
            //    listRoles.Add(roleName);
            //}
            //user.UserRoles = string.Join(",",listRoles);
            var result = _userRepository.Add(user);
            if (result!=null)
            {
                BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.INSERT_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                flagExit = true;
                return 1;
            }
            else
            {
                BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.INSERT_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                flagExit = false;
                return 0;
            }               
        }

        protected override int Edit()
        {
            var listRoles = new List<string>();
            Data.Models.User user = new Data.Models.User();
            user.EmployeeId = (int?)lookUpEdit_Employee.EditValue;
            user.Password = txtPassword.Text;
            user.UserName = txtUserName.Text;
            user.Email = txtEmail.Text;
            user.FullName = string.IsNullOrWhiteSpace(txtFullName.Text) ? lookUpEdit_Employee.Text : txtFullName.Text;
            user.Address = txtDiaChi.Text;
            user.PhoneNumber = txtTel.Text;
            user.Status = checkStatus.Checked;
            user.Id = new Guid(_userId);
            var dt = gridControl1.DataSource as DataTable;
            user.UserRoles = new List<UserRole>();
            foreach (DataRow r in dt.Rows)
            {
                var _userRole = new UserRole();
                if ((bool)r["Check"])
                {
                    _userRole.UserId = user.Id;
                    _userRole.RoleId = new Guid(r["RoleId"].ToString());
                    _userRole.BranchId = int.Parse(r["BranchId"].ToString());
                    _userRole.AuthorisationLevel = int.Parse(r["AuthLevel"].ToString());
                    _userRole.AdvanceConfirmLevel = int.Parse(r["AdLevel"].ToString());
                    _userRole.PaymentConfirmLevel = int.Parse(r["PmLevel"].ToString());
                    user.UserRoles.Add(_userRole);
                }
            }
            //foreach (var item in checkedListBoxRoles.CheckedItems)
            //{
            //    var roleName = (item as CheckedListBoxItem).Value as string;
            //    listRoles.Add(roleName);
            //}
            //user.UserRoles = string.Join(",", listRoles);
            var result = _userRepository.Update(user);
            if (result!=null)
            {
                BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.UPDATE_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                flagExit = true;
                return 1;
            }
            else
            {
                BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.UPDATE_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                flagExit = false;
                return 0;
            }
        }

        private void lookUpEdit_Branch_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Branch.EditValue != null)
            {
              var _id =(int)lookUpEdit_Branch.EditValue;
              var listEmp= _employeeRepository.Get(_id, Common.CommonVariable.TokenKey).ListData;
              Common.BindingData.Load_Combobox(listEmp, lookUpEdit_Employee, "Id", "EmployeeFullName");
            }
        }

      protected override bool CheckValidField()
        {
            if (txtUserName.Text.Trim().Length < 3)
            {
               BaseComponent.MessageEx.Show("Tên đăng nhập không để trống và nhiều hơn 3 kí tự!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        //private void checkedListBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var checkList = sender as CheckedListBoxControl;

        //    var i= checkList.SelectedIndex;
        //    if (i != -1)
        //    {
        //        if(checkList.Items[i].CheckState==CheckState.Checked)
        //        checkList.Items[i].CheckState = CheckState.Unchecked;   
        //        else
        //            checkList.Items[i].CheckState = CheckState.Checked;
        //    }

        //}
    }
}
