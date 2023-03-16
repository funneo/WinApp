using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BaseComponent
{
    public partial class thamsoUI : baseForm
    {       
        public int? cuahangId { get; set; }
        public DateTime Tungay { get; set; }
        public DateTime Denngay { get; set; }            
        public thamsoUI(int? _cuahangId, DateTime _tungay, DateTime _Denngay)
        {
            InitializeComponent();                  
            cuahangId = _cuahangId;
            Tungay = _tungay;
            Denngay = _Denngay;
          
        }
        public bool Ok;       
        private void btnOK_Click(object sender, EventArgs e)
        {
            Ok = true;
            Tungay = dateEdit1.DateTime;
            Denngay = dateEdit2.DateTime;           
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Ok = false;
            this.Close();
        }

        private void thamsoUI_Load(object sender, EventArgs e)
        {
            //IEnumerable<XElement> cuahang = doc.Elements("dm_Cuahang");
            //List<Common.DataSourceLookUpEdit> L = new List<Common.DataSourceLookUpEdit>();
            //foreach (XElement xl in cuahang)
            //{
            //    L.Add(new Common.DataSourceLookUpEdit(Convert.ToInt32(xl.Element("ID").Value), xl.Element("Name").Value));
            //}
            //Common.BindingData.Load_Combobox(L, lookUpEditCuahang, "ObjValueMember", "ObjDisplayMember");

            //lookUpEditCuahang.EditValue = cuahangId;
            dateEdit1.EditValue = Tungay;
            dateEdit2.EditValue = Denngay;
            //if (Permission.I_quyen > 1)
            //    lookUpEditCuahang.Properties.ReadOnly = true;
        }
    }
}
