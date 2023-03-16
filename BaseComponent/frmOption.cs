using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Xml;
namespace BaseComponent
{
    public partial class frmOption : DevExpress.XtraEditors.XtraForm
    {
        public frmOption()
        {
            InitializeComponent();           
            colName.Visible = false;
            //ColAllowEdit.Visible = false;
        }
        public string ClassName = String.Empty;
        public List<string> ListColumnName = null;      
        private void frmOption_Load(object sender, EventArgs e)
        {
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            return;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow r;
            r = gridView1.GetDataRow(e.RowHandle);
            if (r == null)
                return;
            if (e.Column.FieldName.ToLower() == "visible")
            {
                if ((Boolean)r["visible"] == false)
                {
                    r["visibleIndex"] = -1;
                    //colVisible.OptionsColumn.ReadOnly = true;
                }
                else
                {
                    r["visibleIndex"] = e.RowHandle;
                    //colVisible.OptionsColumn.ReadOnly = false;
                }
            }
            if ((string)r[colName.FieldName] == string.Empty && e.Column == colValue)
            {
                r[colName.FieldName] = r[colValue.FieldName];
            }
            if (e.Column == colName && (string)r[colValue.FieldName] == string.Empty)
            {
                r[colValue.FieldName] = r[colName.FieldName];
            }
            gridView1.UpdateCurrentRow();
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //gridView1.FocusedColumn = colValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            return;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow r;
            r = gridView1.GetDataRow(e.RowHandle);
            r["name"] = string.Empty;
            r["value"] = string.Empty;
            r["visibleIndex"] = gridView1.RowCount;
            r["visible"] = true;
            r["width"] = 100;
            r["type"] = "Chuỗi";
            r["Group"] = false;
            r["Summary"] = "None";
            r["AllowEdit"] = false;
            r["AllowFilter"] = true;
            r["AllowFocus"] = false;
            r["FormatString"] = "None";
        }
    }
}