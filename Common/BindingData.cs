using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Common
{
    public class ColumProperty
    {
        public ColumProperty()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_FieldName"></param>
        /// <param name="_Caption"></param>
        /// <param name="_Width"></param>
        public ColumProperty(string _FieldName, string _Caption, int _Width)
        {
            FieldName = _FieldName;
            Caption = _Caption;
            Width = _Width;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_FieldName"></param>
        /// <param name="_Caption"></param>
        public ColumProperty(string _FieldName, string _Caption)
        {
            FieldName = _FieldName;
            Caption = _Caption;
            Width = 0;
        }
        public string FieldName
        { get; set; }
        public string Caption
        { get; set; }
        public int Width
        { get; set; }      
    }
  
    public static class BindingData
    {

        /// <summary>
        /// Lấy dữ liệu cho LookUpEdit
        /// </summary>
        /// <param name="list<T>"></param>
        /// <param name="lookUpEdit"></param>
        /// <param name="ValueMeber"></param>
        /// <param name="DisplayMeber"></param>
        public static void Load_Combobox(List<object> T, DevExpress.XtraEditors.LookUpEdit lookUpEdit, string ValueMeber, string DisplayMeber)
        {
            //if (T == null)
            //    return;
            lookUpEdit.Properties.DataSource = T;
            lookUpEdit.Properties.DisplayMember = DisplayMeber;
            lookUpEdit.Properties.ValueMember = ValueMeber;
            lookUpEdit.Properties.Columns.Clear();
            lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(DisplayMeber, 20, "Select"));
        }
      

        /// <summary>
        /// Lấy dữ liệu cho LookUpEdit
        /// </summary>
        /// <param name="T"></param>
        /// <param name="lookUpEdit"></param>
        /// <param name="LColumnInfo"></param>
        /// <param name="_ValueMember"></param>
        /// <param name="_DisplayMember"></param>
        public static void Load_Combobox(List<object> T, DevExpress.XtraEditors.LookUpEdit lookUpEdit, List<ColumProperty> LColumnInfo, string _ValueMember, string _DisplayMember)
        {
            //if (T == null)
            //    return;
            lookUpEdit.Properties.DataSource = T;
            lookUpEdit.Properties.DisplayMember = _DisplayMember;
            lookUpEdit.Properties.ValueMember = _ValueMember;
            lookUpEdit.Properties.Columns.Clear();
            foreach (ColumProperty col in LColumnInfo)
            {
                lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(col.FieldName, col.Width, col.Caption));
            }
        }
        public static void Load_Combobox(IEnumerable<object> T, DevExpress.XtraEditors.LookUpEdit lookUpEdit, string ValueMeber, string DisplayMeber)
        {
            //if (T == null)
            //    return;
            lookUpEdit.Properties.DataSource = T;
            lookUpEdit.Properties.DisplayMember = DisplayMeber;
            lookUpEdit.Properties.ValueMember = ValueMeber;
            lookUpEdit.Properties.Columns.Clear();
            lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(DisplayMeber, 20, "Select"));
        }
        public static void Load_Combobox(IEnumerable<object> T, DevExpress.XtraEditors.LookUpEdit lookUpEdit, List<ColumProperty> LColumnInfo, string _ValueMember, string _DisplayMember)
        {
            //if (T == null)
            //    return;
            lookUpEdit.Properties.DataSource = T;
            lookUpEdit.Properties.DisplayMember = _DisplayMember;
            lookUpEdit.Properties.ValueMember = _ValueMember;
            lookUpEdit.Properties.Columns.Clear();
            foreach (ColumProperty col in LColumnInfo)
            {
                lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(col.FieldName, col.Width, col.Caption));
            }
        }

        /// <summary>
        /// Lấy dữ liệu cho LookUpEdit
        /// </summary>
        /// <param name="T"></param>
        /// <param name="lookUpEdit"></param>
        /// <param name="LColumnInfo"></param>
        /// <param name="_ValueMember"></param>
        /// <param name="_DisplayMember"></param>
        public static void Load_Combobox(List<string[]> T, DevExpress.XtraEditors.LookUpEdit lookUpEdit, List<ColumProperty> LColumnInfo, string _ValueMember, string _DisplayMember)
        {
            //if (T == null)
            //    return;
            lookUpEdit.Properties.DataSource = T;
            lookUpEdit.Properties.DisplayMember = _DisplayMember;
            lookUpEdit.Properties.ValueMember = _ValueMember;
            lookUpEdit.Properties.Columns.Clear();
            foreach (ColumProperty col in LColumnInfo)
            {
                lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(col.FieldName, col.Width, col.Caption));
            }
        }  
        /// <summary>
        /// Lấy dữ liệu cho RepositoryItemLookUpEdit
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lookUpEdit"></param>
        public static void Load_Combobox(IEnumerable<object> T, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmahang, string ValueMeber, string DisplayMeber)
        {
            //if (T == null)
            //    return;
            repositoryItemLookUpEditmahang.DataSource = T;
            repositoryItemLookUpEditmahang.DisplayMember = DisplayMeber;
            repositoryItemLookUpEditmahang.ValueMember = ValueMeber;
            repositoryItemLookUpEditmahang.Columns.Clear();
            repositoryItemLookUpEditmahang.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(DisplayMeber, 20, "Select"));
        }

        public static void Load_Combobox(DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmahang, string ValueMeber, string DisplayMeber)
        {
            //if (dt == null)
            //    return;
            repositoryItemLookUpEditmahang.DataSource = dt;
            repositoryItemLookUpEditmahang.DisplayMember = DisplayMeber;
            repositoryItemLookUpEditmahang.ValueMember = ValueMeber;
            repositoryItemLookUpEditmahang.Columns.Clear();
            repositoryItemLookUpEditmahang.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(DisplayMeber, 20, "Select"));
        }
    }
}
