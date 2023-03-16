using System;
using System.Data;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace Common
{
    public static class XML
    {

        /// <summary>
        /// Đọc từ một file xml vs đường dẫn cụ thể
        /// </summary>
        /// <param name="Xmlfile"></param>
        /// <returns></returns>
        public static DataSet GetDataset(string Xmlfile)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Xmlfile);
                return ds;
            }
            catch { return null; }
        }

        /// <summary>
        /// Đọc từ một file của chương trình
        /// </summary>
        /// <param name="XmlFile"></param>
        /// <returns></returns>
        public static DataSet ReadXmlfiletoDataSet(string XmlFile)
        {
            string strPath = null;
            strPath = Application.StartupPath;
            if (strPath.Length > 4)
            {
                int i = strPath.IndexOf("\\bin");
                if (i > 0)
                {
                    strPath = strPath.Substring(0, i);
                }
            }
            strPath += "\\" + XmlFile;
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(strPath);
                return ds;
            }
            catch { return null; }
        }

        public static DataTable ReadXmlfiletoDataTable(string XmlFile, string tableName)
        {
            DataSet ds = ReadXmlfiletoDataSet(XmlFile);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[tableName];
            else
                return null;
        }

        public static void WirteXmlfile(DataTable dt, string Xmlfile)
        {
            string strPath = null;
            strPath = Application.StartupPath;
            if (strPath.Length > 4)
            {
                int i = strPath.IndexOf("\\bin");
                if (i > 0)
                {
                    strPath = strPath.Substring(0, i);
                }
            }
            strPath += "\\" + Xmlfile;
            try
            {
                dt.WriteXml(strPath);
            }
            catch { return; }
        }

        public static void WirteXmlfile(DataSet ds, string Xmlfile)
        {
            string strPath = null;
            strPath = Application.StartupPath;
            if (strPath.Length > 4)
            {
                int i = strPath.IndexOf("\\bin");
                if (i > 0)
                {
                    strPath = strPath.Substring(0, i);
                }
            }
            strPath += "\\" + Xmlfile;
            if (!System.IO.File.Exists(strPath))
                System.IO.File.Create(strPath);
            try
            {
                ds.WriteXml(strPath);
            }
            catch { return; }
        }

        /// <summary>
        /// Doc file Xml bang Linq
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static XElement ReadXmlFile(string fileName)
        {           
            var strPath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, fileName);
            if (System.IO.File.Exists(strPath))
                return XElement.Load(strPath);
            else
                return null;
        }
        /// <summary>
        /// Ghi file XML
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="fileName"></param>
        public static void SaveXmlFile(XElement doc, string fileName)
        {           
            var strPath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, fileName);
            if (System.IO.File.Exists(strPath))                
                doc.Save(strPath);
        }

    }
}
