using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseComponent
{
   public static class ReadOnly
    {
        #region Thiết lập thuộc tính chỉ đọc cho các điều khiển

        public static void GridViewReadOnly(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
                //col.OptionsColumn.AllowFocus = false;
            }
        }
       
        public static void FormReadOnly(System.Windows.Forms.Form myForm)
        {
            foreach (Control ctls in myForm.Controls)
            {
                FormReadOnly(ctls);
            }
        }

        public static void FormReadOnly(DevExpress.XtraEditors.XtraForm myForm)
        {
            foreach (Control ctls in myForm.Controls)
            {
                FormReadOnly(ctls);
            }
        }

        private static void FormReadOnly(Control ctr)
        {
            Type t = ctr.GetType();
            if (t == typeof(System.Windows.Forms.GroupBox))
            {
                foreach (Control ctls in ctr.Controls)
                {
                    FormReadOnly(ctls);
                }
            }
            else if (t == typeof(DevExpress.XtraTab.XtraTabControl))
            {
                foreach (DevExpress.XtraTab.XtraTabPage tab in ((DevExpress.XtraTab.XtraTabControl)ctr).TabPages)
                {
                    foreach (Control ctls in tab.Controls)
                    {
                        FormReadOnly(ctls);
                    }
                }
            }
            else if (t == typeof(DevExpress.XtraEditors.GroupControl))
            {
                foreach (Control ctls in ctr.Controls)
                {
                    FormReadOnly(ctls);
                }
            }
            else if (t == typeof(System.Windows.Forms.TextBox))
            {
                ((System.Windows.Forms.TextBox)ctr).ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.TextEdit))
            {
                ((DevExpress.XtraEditors.TextEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(System.Windows.Forms.ComboBox))
            {
                ((System.Windows.Forms.ComboBox)ctr).Enabled = false;
            }
            else if (t == typeof(DevExpress.XtraEditors.MemoEdit))
            {
                ((DevExpress.XtraEditors.MemoEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.ComboBoxEdit))
            {
                ((DevExpress.XtraEditors.ComboBoxEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.DateEdit))
            {
                ((DevExpress.XtraEditors.DateEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.LookUpEdit))
            {
                ((DevExpress.XtraEditors.LookUpEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.SearchLookUpEdit))
            {
                ((DevExpress.XtraEditors.SearchLookUpEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.CheckEdit))
            {
                ((DevExpress.XtraEditors.CheckEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(Button))
            {
                ((Button)ctr).Enabled = false;
            }
            else if (t == typeof(DevExpress.XtraEditors.SimpleButton))
            {
                ((DevExpress.XtraEditors.SimpleButton)ctr).Enabled = false;
            }
            else if (t == typeof(DevExpress.XtraEditors.SpinEdit))
            {
                ((DevExpress.XtraEditors.SpinEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.GridLookUpEdit))
            {
                ((DevExpress.XtraEditors.GridLookUpEdit)ctr).Properties.ReadOnly = true;
            }
            else if (t == typeof(DevExpress.XtraEditors.CheckedListBoxControl))
            {
                ((DevExpress.XtraEditors.CheckedListBoxControl)ctr).Enabled = false;
            }
            else if (t == typeof(DevExpress.XtraEditors.ListBoxControl))
            {
                ((DevExpress.XtraEditors.ListBoxControl)ctr).Enabled = false;
            }
            else
                return;
        }
        #endregion
    }
}
