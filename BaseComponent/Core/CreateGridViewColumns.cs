using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace BaseComponent
{
  public static class CreateGridViewColumns
    {
        public static string thisText { get; set; }

        #region Tạo cột cho GridView trong Form
        public static string GetTextForm(string NameClass)
        {
            return new GridViewColumn().GetTitle(NameClass);
        }

        public static void CreateColumns(DevExpress.XtraGrid.Views.Grid.GridView gridView, string NameClass)
        {
           return;
        }

        #endregion

    }
}
