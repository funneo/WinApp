using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseComponent;
using Data.Interfaces;
using Data.Interfaces.Categories;
using Data.Models;
using Data.Models.Categories;
using Data.Repositories;
using Data.Repositories.Categories;
using DevExpress.Data.Extensions;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Systems
{
    public partial class EmployeeUI : BaseComponent.UIBase
    {
        IEmployee _employeeRepository;
        IBranch _branchRepository;
        IDepartment _departmentRepository;
        ITitle _titleRepository;
        int _employeeId  = 0;
        public EmployeeUI()
        {
            InitializeComponent();
            _employeeRepository = (IEmployee)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IEmployee));
            _branchRepository = (IBranch)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IBranch));
            _departmentRepository = (IDepartment)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IDepartment));
            _titleRepository = (ITitle)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(ITitle));
        }

        protected override void UIBase_Load(object sender, EventArgs e)
        {
            base.UIBase_Load(sender, e);
            var listBranch = _branchRepository.Get(Common.CommonVariable.TokenKey).ListData;
            var listDepartment = _departmentRepository.Get(Common.CommonVariable.TokenKey).ListData;
            var listTitle = _titleRepository.Get(Common.CommonVariable.TokenKey).ListData;
            Common.BindingData.Load_Combobox(listBranch, lookupEditBranh, "Id", "BranchName");
            Common.BindingData.Load_Combobox(listDepartment, lookUpEditDepartment, "Id", "DepartmentName");
            Common.BindingData.Load_Combobox(listTitle, lookUpEditTitle, "Id", "Titles");

            if (flagEdit)
            {
                btnSave2.Visible = false;
                var employee = entityData as Employee;
                _employeeId = employee.Id;
            }
        }

        private void lookUpEditTitle_Leave(object sender, EventArgs e)
        {

        }

        protected override bool CheckValidField()
        {
            if (txtEmployeeName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên nhân viên không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                return false;
            }
            if (lookupEditBranh.EditValue==null)
            {
                MessageBox.Show("Thông tin Chi nhánh không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookupEditBranh.Focus();
                return false;
            }
            if (lookUpEditDepartment.EditValue == null)
            {
                MessageBox.Show("Thông tin Phòng không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookUpEditDepartment.Focus();
                return false;
            }
            if (lookUpEditTitle.EditValue == null)
            {
                MessageBox.Show("Thông tin Vị trí không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookUpEditTitle.Focus();
                return false;
            }
            if (dateEditDateOfBirth.EditValue == null)
            {
                MessageBox.Show("Thông tin Ngày sinh không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditDateOfBirth.Focus();
                return false;
            }
            if (txtTelephone.EditValue == null)
            {
                MessageBox.Show("Thông tin Số điện thoại không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelephone.Focus();
                return false;
            }
            return true;
        }

        protected override int Add()
        {
            var newItem = new Employee();
            newItem.EmployeeFullName = txtEmployeeName.Text.Trim();
            newItem.BranchId = (int)lookupEditBranh.EditValue;
            newItem.DepartmentId = (int)lookUpEditDepartment.EditValue;
            newItem.TitleId = (int)lookUpEditTitle.EditValue;
            newItem.Sex = cmbSex.SelectedIndex == 0 ? false:true;
            newItem.DateOfBirth = (DateTime)dateEditDateOfBirth.EditValue;
            newItem.IdNumber = txtIdNumber.Text;
            newItem.IssueedDate = dateEditIssueedDate.EditValue==null?(DateTime?)null:(DateTime)dateEditIssueedDate.EditValue;
            newItem.IssueedPlace = txtIssueedPlace.Text;
            newItem.Telephone = txtTelephone.Text;
            newItem.Email = txtEmail.Text;
            newItem.Address = txtAddress.Text;
            newItem.Note = txtNote.Text;
            newItem.TaxCode = txtTaxCode.Text;
            newItem.AccountNumber = txtAccountNumber.Text;
            newItem.Bank = txtBank.Text;
            newItem.StartDate= dateEditStartDate.EditValue == null ? (DateTime?)null : (DateTime)dateEditStartDate.EditValue;
            newItem.ContractDate= dateEditContractDate.EditValue == null ? (DateTime?)null : (DateTime)dateEditContractDate.EditValue;
            newItem.Status = checkStatus.Checked;
            var rVal = _employeeRepository.Add(newItem, Common.CommonVariable.TokenKey);
            switch (rVal.Code)
            {
                case "201":
                    BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.INSERT_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flagExit = true;
                    return 1;
                case "400":
                    BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.INSERT_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flagExit = false;
                    return 0;
                default: 
                    BaseComponent.MessageEx.Show(rVal.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flagExit = false;
                    return 0;
            }
        }

        protected override int Edit()
        {
            var newItem = new Employee();
            newItem.EmployeeFullName = txtEmployeeName.Text.Trim();
            newItem.BranchId = (int)lookupEditBranh.EditValue;
            newItem.DepartmentId = (int)lookUpEditDepartment.EditValue;
            newItem.TitleId = (int)lookUpEditTitle.EditValue;
            newItem.Sex = cmbSex.SelectedIndex == 0 ? false : true;
            newItem.DateOfBirth = (DateTime)dateEditDateOfBirth.EditValue;
            newItem.IdNumber = txtIdNumber.Text;
            newItem.IssueedDate = dateEditIssueedDate.EditValue == null ? (DateTime?)null : (DateTime)dateEditIssueedDate.EditValue;
            newItem.IssueedPlace = txtIssueedPlace.Text;
            newItem.Telephone = txtTelephone.Text;
            newItem.Email = txtEmail.Text;
            newItem.Address = txtAddress.Text;
            newItem.Note = txtNote.Text;
            newItem.TaxCode = txtTaxCode.Text;
            newItem.AccountNumber = txtAccountNumber.Text;
            newItem.Bank = txtBank.Text;
            newItem.StartDate = dateEditStartDate.EditValue == null ? (DateTime?)null : (DateTime)dateEditStartDate.EditValue;
            newItem.ContractDate = dateEditContractDate.EditValue == null ? (DateTime?)null : (DateTime)dateEditContractDate.EditValue;
            newItem.Status = checkStatus.Checked;
            newItem.Id = _employeeId;
            var rVal = _employeeRepository.Update(newItem, Common.CommonVariable.TokenKey);
            
            switch (rVal.Code)
            {
                case "201":
                    BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.INSERT_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flagExit = true;
                    return 1;
                case "400":
                    BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.INSERT_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flagExit = false;
                    return 0;
                default:
                    BaseComponent.MessageEx.Show(rVal.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flagExit = false;
                    return 0;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var frm = new frmAttachFiles();
            frm.FunctionName = "EMPLOYEE";
            frm.FrmName = GetType().Name;
            frm.RefNo = _employeeId.ToString();
            frm.IsApproved = false;
            frm.ShowDialog();

        }
    }
}
