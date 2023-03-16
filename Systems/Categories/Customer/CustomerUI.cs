using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
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
    public partial class CustomerUI : BaseComponent.UIBase
    {
        IEmployee _employeeRepository;
        IBranch _branchRepository;
        IDepartment _departmentRepository;
        ITitle _titleRepository;
        ICustomer _customerRepository;
        int _customerId  = 0;
        public CustomerUI()
        {
            InitializeComponent();
            txtTen.Tag = nameof(Data.Models.Customer.CustomerName);
            txtKiHieu.Tag = nameof(Data.Models.Customer.Symbol);
            lookupEditBranh.Tag= nameof(Data.Models.Customer.BranchId);
            txtMST.Tag = nameof(Data.Models.Customer.TaxCode);
            txtTenE.Tag = nameof(Data.Models.Customer.NameEnglish);
            lookUpEdit_Tinh.Tag= nameof(Data.Models.Customer.ProvinceCode);
            lookUpEdit_QuanHuyen.Tag= nameof(Data.Models.Customer.DistrictCode);
            lookUpEdit_CN.Tag= nameof(Data.Models.Customer.IndustrialZoneId);
            txtDiaChi.Tag= nameof(Data.Models.Customer.Address);
            txtDienThoai.Tag= nameof(Data.Models.Customer.Tel);
            txtWeb.Tag= nameof(Data.Models.Customer.Website);
            txtFax.Tag= nameof(Data.Models.Customer.Fax);
            txtNganHang.Tag= nameof(Data.Models.Customer.BankName);
            txtSoTKNH.Tag= nameof(Data.Models.Customer.BankAccountNumber);
            lookUpEdit_QG.Tag= nameof(Data.Models.Customer.CountryCode);
            lookUpEdit_NhanVien.Tag= nameof(Data.Models.Customer.EmployeeId);
            lookUpEdit_Cha.Tag= nameof(Data.Models.Customer.ParentId);
            txtNguoiLienHe.Tag= nameof(Data.Models.Customer.Contact);
            txtDienThoaiNLH.Tag= nameof(Data.Models.Customer.ContactTel);
            txtChucVu.Tag= nameof(Data.Models.Customer.ContactPosition);
            txtEmailNLH.Tag= nameof(Data.Models.Customer.ContactEmail);
            spinEdit_X.Tag= nameof(Data.Models.Customer.Latitude);
            spinEdit_Y.Tag= nameof(Data.Models.Customer.Longitude);
            checkStatus.Tag= nameof(Data.Models.Customer.Status);
            txtGhiChu.Tag= nameof(Data.Models.Customer.Notes);
            checkStatus.Properties.ReadOnly = true;
            _employeeRepository = (IEmployee)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IEmployee));
            _branchRepository = (IBranch)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IBranch));
            _departmentRepository = (IDepartment)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IDepartment));
            _titleRepository = (ITitle)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(ITitle));
            _customerRepository = (ICustomer)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(ICustomer));
            //visibleSaveAndSave = true;
            //visibleReset = true;
        }

        protected override void UIBase_Load(object sender, EventArgs e)
        {
            if (flagEdit)
            {
                btnSave2.Visible = false;
                var customer = entityData as Customer;
                _customerId = customer.Id;
                entityData = _customerRepository.GetById(_customerId).Data;
            }
            visibleAccept = BaseComponent.Permission.HasPermission("CUSTOMER_ACCEPT") && !(entityData as Customer).Status;
            base.UIBase_Load(sender, e);
            var listBranch = _branchRepository.Get(Common.CommonVariable.TokenKey).ListData;
            var listDepartment = _departmentRepository.Get(Common.CommonVariable.TokenKey).ListData;
            var listTitle = _titleRepository.Get(Common.CommonVariable.TokenKey).ListData;
            Common.BindingData.Load_Combobox(listBranch, lookupEditBranh, "Id", "BranchName");

            FormatControl(spinEdit_X, "###.000");
            FormatControl(spinEdit_Y, "###.000");
         
        }      

        protected override bool CheckValidField()
        {
            if (txtTen.Text.Trim().Length < 1)
            {
               BaseComponent.MessageEx.Show("Tên khách hàng không được để trống, kiểm tra lại!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }
            if (lookupEditBranh.EditValue==null)
            {
                BaseComponent.MessageEx.Show("Không để trống chi nhánh quản lý!!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }
            return true;
        }

        protected override int Add()
        {
            var item = new Customer();
            item.CustomerName = txtTen.Text.Trim();
            item.BranchId = lookupEditBranh.EditValue.ConvertInt();
            item.Symbol = txtKiHieu.EditValue.ConvertString();
            item.NameEnglish = txtTenE.EditValue.ConvertString();
            item.ProvinceCode = lookUpEdit_Tinh.EditValue.ConvertString();
            item.DistrictCode = lookUpEdit_QuanHuyen.EditValue.ConvertString();
            item.IndustrialZoneId = lookUpEdit_CN.EditValue.ConvertInt();
            item.Address = txtDiaChi.EditValue.ConvertString();
            item.TaxCode = txtMST.EditValue.ConvertString();
            item.Tel = txtDienThoai.EditValue.ConvertString();
            item.Fax = txtFax.EditValue.ConvertString();
            item.Website = txtWeb.EditValue.ConvertString();
            item.CountryCode = lookUpEdit_QG.EditValue.ConvertString();
            item.BankName = txtNganHang.EditValue.ConvertString();
            item.BankAccountNumber = txtSoTKNH.EditValue.ConvertString();
            item.EmployeeId = lookUpEdit_NhanVien.EditValue.ConvertInt();
            item.ParentId = lookUpEdit_Cha.EditValue.ConvertInt();
            item.Latitude = spinEdit_X.EditValue.ConvertFloat();
            item.Longitude = spinEdit_Y.EditValue.ConvertFloat();
            item.Contact = txtNguoiLienHe.EditValue.ConvertString();
            item.ContactTel = txtDienThoaiNLH.EditValue.ConvertString();
            item.ContactEmail = txtEmailNLH.EditValue.ConvertString();
            item.ContactPosition = txtChucVu.EditValue.ConvertString();
            item.Notes = txtGhiChu.EditValue.ConvertString();
            item.Status = checkStatus.Checked;
            item.Id = _customerId;
            var rVal = _customerRepository.Add(item);
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
            var item = new Customer();
            item.CustomerName = txtTen.Text.Trim();
            item.BranchId = lookupEditBranh.EditValue.ConvertInt();
            item.Symbol = txtKiHieu.EditValue.ConvertString();
            item.NameEnglish = txtTenE.EditValue.ConvertString();
            item.ProvinceCode = lookUpEdit_Tinh.EditValue.ConvertString();
            item.DistrictCode = lookUpEdit_QuanHuyen.EditValue.ConvertString();
            item.IndustrialZoneId = lookUpEdit_CN.EditValue.ConvertInt();
            item.Address = txtDiaChi.EditValue.ConvertString();
            item.TaxCode = txtMST.EditValue.ConvertString();
            item.Tel = txtDienThoai.EditValue.ConvertString();
            item.Fax = txtFax.EditValue.ConvertString();
            item.Website = txtWeb.EditValue.ConvertString();
            item.CountryCode = lookUpEdit_QG.EditValue.ConvertString();
            item.BankName = txtNganHang.EditValue.ConvertString();
            item.BankAccountNumber = txtSoTKNH.EditValue.ConvertString();
            item.EmployeeId = lookUpEdit_NhanVien.EditValue.ConvertInt();
            item.ParentId = lookUpEdit_Cha.EditValue.ConvertInt();
            item.Latitude = spinEdit_X.EditValue.ConvertFloat();
            item.Longitude = spinEdit_Y.EditValue.ConvertFloat();
            item.Contact = txtNguoiLienHe.EditValue.ConvertString();
            item.ContactTel = txtDienThoaiNLH.EditValue.ConvertString();
            item.ContactEmail = txtEmailNLH.EditValue.ConvertString();
            item.ContactPosition = txtChucVu.EditValue.ConvertString();
            item.Notes = txtGhiChu.EditValue.ConvertString();
            item.Status = checkStatus.Checked;
            item.Id = _customerId;
            var rVal = _customerRepository.Update(item);
            
            switch (rVal.Code)
            {
                case "200":
                    BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.UPDATE_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        protected override int Accept()
        {
            var rVal = _customerRepository.Accept(_customerId);
            switch (rVal.Code)
            {
                case "200":
                    BaseComponent.MessageEx.Show(BaseComponent.Core.MessageContstants.UPDATE_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
