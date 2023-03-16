using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Common;
using Data.Repositories;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Resizing;

namespace BaseComponent
{
    public partial class UIBase : baseForm
    {
        public bool visibleSaveAndExit = true;
        public bool visibleSaveAndSave = false;
        public bool visibleReset = false;
        public bool visiblePrint = false;
        public bool visibleAccept = false;
       
        public bool flagChanged = false;
        public bool flagView = false;
        public bool flagEdit = false;
        public bool flagExit = true;

        public object entityData = null;      
        Dictionary<string, object> datas;
        public UIBase()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected virtual int Add()
        {
            flagEdit = false;
            return 0;
        }
        protected virtual int Edit()
        {
            return 0;
        }

        protected virtual int Accept()
        {
            return 0;
        }

        #region Xóa dữ liệu trên các điều khiển
        protected void ResetControl(Control ctl)
        {
            Type t = ctl.GetType();
            if (t == typeof(System.Windows.Forms.GroupBox))
            {
                foreach (Control ctls in ctl.Controls)
                {
                    ResetControl(ctls);
                }
            }
            else if (t == typeof(DevExpress.XtraTab.XtraTabControl))
            {
                foreach (DevExpress.XtraTab.XtraTabPage tab in ((DevExpress.XtraTab.XtraTabControl)ctl).TabPages)
                {
                    foreach (Control ctls in tab.Controls)
                    {
                        ResetControl(ctls);
                    }
                }
            }
            else if (t == typeof(DevExpress.XtraEditors.GroupControl))
            {
                foreach (Control ctls in ctl.Controls)
                {
                    ResetControl(ctls);
                }
            }
            else if (t == typeof(System.Windows.Forms.TextBox))
            {
                ((System.Windows.Forms.TextBox)ctl).Text = string.Empty;
            }
            else if (t == typeof(DevExpress.XtraEditors.TextEdit))
            {
                ((DevExpress.XtraEditors.TextEdit)ctl).EditValue = null;
            }
            else if (t == typeof(DevExpress.XtraEditors.ComboBoxEdit))
            {
                ((DevExpress.XtraEditors.ComboBoxEdit)ctl).EditValue = null;
            }
            else if (t == typeof(DevExpress.XtraEditors.DateEdit))
            {
                ((DevExpress.XtraEditors.DateEdit)ctl).EditValue = null;
            }
            else if (t == typeof(DevExpress.XtraEditors.LookUpEdit))
            {
                ((DevExpress.XtraEditors.LookUpEdit)ctl).EditValue = null;
            }
            else if (t == typeof(DevExpress.XtraEditors.MemoEdit))
            {
                ((DevExpress.XtraEditors.MemoEdit)ctl).EditValue = null;
            }
            else if (t == typeof(System.Windows.Forms.NumericUpDown))
            {
                ((System.Windows.Forms.NumericUpDown)ctl).Value = 0;
            }
            else if (t == typeof(DevExpress.XtraEditors.SpinEdit))
            {
                ((DevExpress.XtraEditors.SpinEdit)ctl).EditValue = 0;
            }
            else if (t == typeof(DevExpress.XtraEditors.CheckEdit))
            {
                ((DevExpress.XtraEditors.CheckEdit)ctl).Checked = false;
            }
        }
        protected virtual void ResetAllControl()
        {
            foreach (Control ctls in this.Controls)
            {
                ResetControl(ctls);
            }
        }

        #endregion

        protected virtual void Print() { }     
      
        protected virtual void CreateNewId()
        {
            return;
        }
        protected virtual bool CheckValidField()
        {
            return true;
        }

        protected virtual bool CheckId()
        {
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           return;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {          
           return;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAllControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }       
        protected virtual void UIBase_Load(object sender, EventArgs e)
        {          
           return;
        }
        protected virtual void LoadDataToEdit()
        {
          return;
        }
        #region Hiện thị dữ liệu
        private void LoadDataToEdit(Control ctr)
        {           
          return;
        }
        #endregion

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Accept() >0) flagChanged = true;
            if (flagExit) this.Close();
            else //continue or error
            {

            }
        }
    }
}