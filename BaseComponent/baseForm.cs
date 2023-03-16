using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BaseComponent
{
    public partial class baseForm : DevExpress.XtraEditors.XtraForm
    {
        public string funcId;      
        public baseForm()
        {
            InitializeComponent();
        }

        private void baseForm_KeyDown(object sender, KeyEventArgs e)
        {
            Control c = this.ActiveControl;                     
            Type t = c.GetType();
            if (t == typeof(DevExpress.XtraEditors.TextBoxMaskBox))
            {
                if (((DevExpress.XtraEditors.TextBoxMaskBox)c).OwnerEdit.ToString() == "DevExpress.XtraEditors.MemoEdit" && e.KeyCode != Keys.Escape)
                    return;                
            }
            else if (t == typeof(System.Windows.Forms.RichTextBox))
            {
                return;
            }                         

            if (e.KeyCode == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }           
        }

        protected void setLookupEdit_Filter()
        {
            foreach (Control ctr in this.Controls)
                setLookupEdit_filter(ctr);
        }

        protected void setLookupEdit_filter(Control ctr)
        {
            Type t = ctr.GetType();
            if (t == typeof(System.Windows.Forms.GroupBox))
            {
                foreach (Control ctls in ctr.Controls)
                {
                    setLookupEdit_filter(ctls);
                }
            }
            else if (t == typeof(DevExpress.XtraTab.XtraTabControl))
            {
                foreach (DevExpress.XtraTab.XtraTabPage tab in ((DevExpress.XtraTab.XtraTabControl)ctr).TabPages)
                {
                    foreach (Control ctls in tab.Controls)
                    {
                        setLookupEdit_filter(ctls);
                    }
                }
            }
            else if (t == typeof(DevExpress.XtraEditors.GroupControl))
            {
                foreach (Control ctls in ctr.Controls)
                {
                    setLookupEdit_filter(ctls);
                }
            }

            else if (t == typeof(DevExpress.XtraGrid.GridControl))
            {
                foreach (DevExpress.XtraEditors.Repository.RepositoryItem Item in ((DevExpress.XtraGrid.GridControl)ctr).RepositoryItems)
                {
                    if (Item.GetType() == typeof(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit))
                        ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)Item).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                }            
            }
            if (t == typeof(DevExpress.XtraEditors.LookUpEdit))
            {
                ((DevExpress.XtraEditors.LookUpEdit)ctr).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }

        }

        protected void setLableAll()
        {
            foreach (Control ctr in this.Controls)
                setLable(ctr);
        }

        protected void setLable(Control ctr)
        {           
            Type t = ctr.GetType();
            if (t == typeof(System.Windows.Forms.GroupBox))
            {
                foreach (Control ctls in ctr.Controls)
                {
                    setLable(ctls);
                }
            }
            else if (t == typeof(DevExpress.XtraTab.XtraTabControl))
            {
                foreach (DevExpress.XtraTab.XtraTabPage tab in ((DevExpress.XtraTab.XtraTabControl)ctr).TabPages)
                {
                    foreach (Control ctls in tab.Controls)
                    {
                        setLable(ctls);
                    }
                }
            }
            else if (t == typeof(DevExpress.XtraEditors.GroupControl))
            {
                foreach (Control ctls in ctr.Controls)
                {
                    setLable(ctls);
                }
            }
            else if (t == typeof(DevExpress.XtraEditors.TimeEdit))
            {
                ((DevExpress.XtraEditors.TimeEdit)ctr).EditValue = null;               
            }
            else if (t == typeof(DevExpress.XtraGrid.GridControl))
            {
                foreach (DevExpress.XtraEditors.Repository.RepositoryItem Item in ((DevExpress.XtraGrid.GridControl)ctr).RepositoryItems)
                {
                    if (Item.GetType() == typeof(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit))
                        ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)Item).NullText = string.Empty;
                    else if (Item.GetType() == typeof(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit))
                        ((DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)Item).NullText = string.Empty;
                }
            }
            else if (t == typeof(DevExpress.XtraEditors.LookUpEdit))
            {
                ((DevExpress.XtraEditors.LookUpEdit)ctr).Properties.NullText = string.Empty;
            }

            else if (t == typeof(DevExpress.XtraEditors.SearchLookUpEdit))
            {
                ((DevExpress.XtraEditors.SearchLookUpEdit)ctr).Properties.NullText = string.Empty;
            }
            else if (t == typeof(DevExpress.XtraEditors.GridLookUpEdit))
            {
                ((DevExpress.XtraEditors.GridLookUpEdit)ctr).Properties.NullText = string.Empty;
            }
            else if (t == typeof(DevExpress.XtraEditors.DateEdit))
            {
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.DisplayFormat.FormatString =Common.AppConfig.FORMAT_DATE;
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.EditFormat.FormatString = Common.AppConfig.FORMAT_DATE;
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.Mask.EditMask = Common.AppConfig.FORMAT_DATE;
            }
            else if (t == typeof(DevExpress.XtraEditors.SpinEdit))
            {
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.DisplayFormat.FormatString = Common.AppConfig.FORMAT_VND;
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.EditFormat.FormatString = Common.AppConfig.FORMAT_VND;
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.Mask.EditMask = Common.AppConfig.FORMAT_VND;
            }
        }    

        protected void FormatControl(Control ctr, string format) 
        {
            var t = ctr.GetType();
            if (t == typeof(DevExpress.XtraEditors.SpinEdit))
            {
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.DisplayFormat.FormatString = format;
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.EditFormat.FormatString = format;
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.Mask.EditMask = format;
            }
            else if (t == typeof(DevExpress.XtraEditors.DateEdit))
            {
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.DisplayFormat.FormatString = format;
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.EditFormat.FormatString = format;
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.Mask.EditMask = format;
            }
            else
            {
                return;
            }
        }

        private void baseForm_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo myCIintl = new System.Globalization.CultureInfo("en-US");
            myCIintl.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            myCIintl.NumberFormat.NumberDecimalSeparator = ".";
            myCIintl.NumberFormat.NumberGroupSeparator = ",";
            myCIintl.NumberFormat.NumberDecimalDigits = 2;
            Application.CurrentCulture = myCIintl;          
        
            setLableAll();
            //setLookupEdit_Filter();

            foreach (Control ctr in this.Controls)
            {
                controls_KeyDown(ctr);
            }
        }

        private void controls_KeyDown(Control Ctr)
        {
            if (Ctr.GetType() == typeof(DevExpress.XtraEditors.GroupControl))
            {
                foreach (Control ctr in Ctr.Controls)
                {
                    controls_KeyDown(ctr);
                }
            }
            else if (Ctr.GetType() == typeof(GroupBox))
            {
                foreach (Control ctr in Ctr.Controls)
                {
                    controls_KeyDown(ctr);
                }
            }
            else if (Ctr.GetType() == typeof(DevExpress.XtraTab.XtraTabControl))
            {
                foreach (DevExpress.XtraTab.XtraTabPage tab in ((DevExpress.XtraTab.XtraTabControl)Ctr).TabPages)
                {
                    foreach (Control ctr in tab.Controls)
                    {
                        controls_KeyDown(ctr);
                    }
                }
            }
            else
                Ctr.KeyDown += control_KeyDown;
        }
       
        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            Control ctr = (Control)sender;
            if (e.KeyCode == Keys.Delete)
            {
                if (ctr.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    if (((DevExpress.XtraEditors.LookUpEdit)ctr).Properties.ReadOnly)
                        return;
                    ((DevExpress.XtraEditors.LookUpEdit)ctr).EditValue = null;
                    return;                   
                }
                if (ctr.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    ((DevExpress.XtraEditors.ComboBoxEdit)ctr).SelectedIndex = -1;
                    return;
                }
                if (ctr.GetType() == typeof(DevExpress.XtraEditors.TimeEdit))
                {
                    ((DevExpress.XtraEditors.TimeEdit)ctr).EditValue = null;
                    return;
                }
            }
        }       

        public bool HasAddPermission()
        {
            return true;
        }

        public bool HasEditPermission()
        {
            return true;
        }

        public bool HasDeletePermission()
        {
            return true;
        }

        # region Tạo cột cho GridView trong Form
        protected void CreateColums(DevExpress.XtraGrid.Views.Grid.GridView gridView, string nameClass)
        {
            CreateGridViewColumns.CreateColumns(gridView, nameClass);
        }
        #endregion

        #region Thiết lập thuộc tính chỉ đọc cho các điều khiển
        public void ReadOnly()
        {
            BaseComponent.ReadOnly.FormReadOnly(this);      
        }

        public void GridViewReadOnly(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            BaseComponent.ReadOnly.GridViewReadOnly(grv);
        }

        public void ReadOnlyGrv(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
                //col.OptionsColumn.AllowFocus = false;
            }
        }
        # endregion
    }
}
