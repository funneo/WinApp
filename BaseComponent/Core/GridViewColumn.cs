using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;
using Common;
namespace BaseComponent
{
    public class GridViewProperty
    {
        public bool ShowFooter { get; set; }
        public bool ShowGroupPanel { get; set; }
        public bool ShowAutoFilterRow { get; set; }
        public bool ColumnAutoWidth { get; set; }
        public string Title { get; set; }

        public GridViewProperty()
        { }
        public GridViewProperty(bool _showFooter,bool _showGroupPanel,bool _showAutoFilterRow,bool _columnAutoWidth, string _title)
        {
            ShowFooter = _showFooter;
            ShowGroupPanel = _showGroupPanel;
            ShowAutoFilterRow = _showAutoFilterRow;
            ColumnAutoWidth = _columnAutoWidth;
            Title = _title;
        }
    }

    public class ColumnProperty
    {
        public ColumnProperty()
        { }
        public ColumnProperty(string _FieldName, string _Caption, int _Width, bool _Group, string _Summary, int _VisibleIndex,
         string _Type, bool _AllowFilter, bool _AllowEdit, bool _AllowFocus)
        {
            FieldName = _FieldName;
            Caption = _Caption;
            Width = _Width;
            Summary = _Summary;
            VisibleIndex = _VisibleIndex;
            Type = _Type;
            Group = _Group;
            AllowEdit = _AllowEdit;
            AllowFilter = _AllowFilter;
            AllowFocus = _AllowFocus;           
        }
        public ColumnProperty(string _FieldName, string _Caption, int _Width, bool _Group, string _Summary, int _VisibleIndex,
           string _Type, bool _AllowFilter, bool _AllowEdit, bool _AllowFocus, string _FormatString)
        {
            FieldName = _FieldName;
            Caption = _Caption;
            Width = _Width;
            Summary = _Summary;
            VisibleIndex = _VisibleIndex;
            Type = _Type;
            Group = _Group;
            AllowEdit = _AllowEdit;
            AllowFilter = _AllowFilter;
            AllowFocus = _AllowFocus;
            FormatString = _FormatString;
        }
        public string FieldName
        { get; set; }
        public string Caption
        { get; set; }
        public int Width
        { get; set; }
        public bool Group
        { get; set; }
        public string Summary
        { get; set; }
        public int VisibleIndex
        { get; set; }
        public string Type
        { get; set; }
        public bool AllowFilter
        { get; set; }
        public bool AllowEdit
        { get; set; }
        public bool AllowFocus
        { get; set; }
        public string FormatString
        { get; set; }
    }

    public class GridViewColumn
    {
        private XElement doc; 
        private string fileName = "XmlgridViewColumn.xml";
        public GridViewColumn()
        {
            doc = XML.ReadXmlFile(fileName);
        }

        public string GetGridViewProperty(string classname, string attributes)
        {
            var _output = string.Empty;           
            if (doc.Elements(classname).Count() > 0)
            {
                XElement el = doc.Elements(classname).First();
                if (el != null)
                {
                    _output = el.Attribute(attributes).Value;
                }
            }
            return _output;
        }

        public string GetTitle(string classname)
        {
            var s= GetGridViewProperty(classname, "Text");
            return s==string.Empty? "TCSOFT" : s;
        }

        public GridViewProperty GetGridViewProperty(string ClassName)
        {
            if (doc!=null && doc.Elements(ClassName).Count() > 0)
            {
                XElement el = doc.Elements(ClassName).First();
                if (el != null)
                {
                    try
                    {
                        return new GridViewProperty
                        {
                            Title = el.Attribute("Text").Value,
                            ShowFooter = el.Attribute("ShowFooter").Value == "0" ? false : true,
                            ShowAutoFilterRow = el.Attribute("ShowAutoFilterRow").Value == "0" ? false : true,
                            ShowGroupPanel = el.Attribute("ShowGroupPanel").Value == "0" ? false : true,
                            ColumnAutoWidth = el.Attribute("ColumnAutoWidth").Value == "0" ? false : true,
                        };
                    }
                    catch { return null; }
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }
        
        public List<ColumnProperty> GetColumns(string classname)
        {           
            
            return  new List<ColumnProperty>();
        }

        public void CreateGridViewProperty(string _attributes, string _attributesValue, string classname)
        {
            if (doc.Elements(classname).Count() > 0)
            {
                XElement el = doc.Elements(classname).First();
                if (el != null)
                {
                    if (el.Attribute(_attributes).Value == null)
                        el.Add(new XAttribute(_attributes, _attributesValue));
                    else el.Attribute(_attributes).Value = _attributesValue;
                }
            }
            XML.SaveXmlFile(doc, fileName);
        }
        

        public void EditColum(List<ColumnProperty> listColump, string classname)
        {
           return;
        }

        public void CreateColum(List<ColumnProperty> listColump, string classname)
        {
           return;
        }

        public void DeleteColum(List<ColumnProperty> listColump, string classname)
        {
           return;
        }

        /// <summary>
        /// Khởi tạo mặc định cho GridView
        /// </summary>
        /// <param name="classname"></param>
        public void CreateGridviewProperty(string classname)
        {
           return;
        }
    }
}
