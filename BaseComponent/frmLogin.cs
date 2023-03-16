using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using Data.Repositories;
using System.Security.Cryptography;
using BaseComponent.Core;
using System.Configuration;
using Data.Models;

namespace BaseComponent
{
    public partial class frmLogin : baseForm
    {
        public bool conti = true;
        private int? _branchId = null;
        public frmLogin()
        {
            InitializeComponent();
            Common.AppConfig.URL = ConfigurationManager.AppSettings.Get("ApiUrl");
            var doc = Common.XML.ReadXmlFile("Branchs.xml");
            IEnumerable<XElement> xElements = doc.Elements("Branch");
            var listBranch = new List<Branch>();
            if (xElements != null)
            {
                var _id = xElements.Where(x => x.Attribute("Status").Value == "1").FirstOrDefault()?.Attribute("Id").Value;
                if (int.TryParse(_id, out int b))
                    _branchId = b;
                foreach (XElement el in xElements)
                {
                    var item = new Branch();
                    if (int.TryParse(el.Attribute("Id").Value, out int n))
                    {
                        item.Id = n;
                        item.BranchName = el.Value;
                        listBranch.Add(item);
                    }                       
                }               
            }
            Common.BindingData.Load_Combobox(listBranch, lookUpEdit_Branch, "Id", "BranchName");
            //int encrypted = Properties.Settings.Default.Encrypted;
            //var apiUrl = Properties.Settings.Default.ApiUrl;           
            //if (encrypted == 0)
            //{
            //    Common.AppConfig.URL = apiUrl;               
            //    Properties.Settings.Default.Encrypted = 1;
            //    Properties.Settings.Default.ApiUrl = Common.CryptorEngine.Encrypt(apiUrl, true);               
            //    Properties.Settings.Default.Save();
            //}
            //else
            //{
            //    Common.AppConfig.URL = Common.CryptorEngine.Decrypt(apiUrl, true);
            //}

        }
        int i = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageEx.Show($"Tên đăng nhập không để trống!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageEx.Show($"Mật khẩu không để trống!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lookUpEdit_Branch.EditValue==null)
            {
                MessageEx.Show($"Chưa chọn chi nhánh!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (i > 3)
                Application.Exit();
            var userName = txtUser.Text.Trim();
            var passWord =txtPass.Text.Trim();
            var _branchId = (int)lookUpEdit_Branch.EditValue;
            if (ApiClient.Apibase.Login(userName, passWord,_branchId))
            {
                Permission.UserName = txtUser.Text.Trim();
                var _user = ApiClient.Apibase.GetLoggedInUser();
                Permission.BranchId = _branchId;
                Permission.EmployeeId = _user.EmployeeId;
                Permission.AcountLevel = _user.AuthorisationLevel;
                Permission.User = _user;
                if (chkRemember.Checked)
                {
                    WriteUserINI();
                }
                else
                {
                    string strPath = Application.StartupPath + "\\User.INI";
                    try { File.Delete(Application.StartupPath + "\\User.INI"); }
                    catch { }
                }
                txtPass.Text = "";
                this.Hide();
                if (Application.OpenForms.OfType<baseMain>().Count() == 1)
                {
                    Application.OpenForms.OfType<baseMain>().First().Refresh();
                    //Application.OpenForms.OfType<baseMain>().First().Close();
                }
                else
                {
                    baseMain f = new baseMain();
                    f.Show();
                }
                             
            }
            else
            {
                //MessageEx.Show(Common.MessageContstants.LOGIN_ERR,Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageEx.Show($"{Common.DeltaError.Code}-{Common.DeltaError.Message}", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtPass.Text = "";
                txtPass.Focus();
                i++;
            }
        }
        private void ReadUserINI()
        {
            StreamReader sr;
            string line, param;
            string user="";
            string pass="";

            if (File.Exists("User.INI"))
            {
                sr = File.OpenText("User.INI");
                while (sr.Peek() > -1)
                {
                    line = sr.ReadLine();
                    int index = line.IndexOf("=");
                    if (index > -1)
                    {
                        param = line.Substring(0, index).Trim().ToLower();
                        switch (param)
                        {
                            case "user":
                                user = line.Substring(index + 1).Trim();
                                break;
                            case "password":
                                pass = line.Substring(index + 1).Trim();
                                break;
                        }
                    }
                }
                sr.Close();
                if (user.Length > 0)
                {
                    txtUser.Text = user;
                    if (pass.Length > 0)
                    {
                        txtPass.Text = Common.CryptorEngine.Decrypt(pass, true);
                        chkRemember.Checked = true;
                        btnOk.Focus();
                    }
                    else
                    {
                        txtPass.Focus();
                    }
                }
                else txtUser.Focus();
            }
            else txtUser.Focus();
        }
        // write INI file
        private void WriteUserINI()
        {
            StreamWriter sw;
            try
            {
                sw = File.CreateText("User.INI");
            }
            catch
            {
                //MessageEx.Show(Properties.Resources.CanNotCreateFileLogin, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                sw.WriteLine("user=" + txtUser.Text.Trim());
                sw.WriteLine("password=" + Common.CryptorEngine.Encrypt(txtPass.Text.Trim(),true));  
            }
            catch
            {
                //MessageEx.Show(Properties.Resources.CanNotCreateFileLogin, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sw.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ReadUserINI();
            lookUpEdit_Branch.EditValue = _branchId;
        }       

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            conti = false;
        }      
       
    }
}