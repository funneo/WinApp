using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.ColorPick.Picker;

namespace Common
{
   public static class LibString
    {
        public static string ToNull(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;
            else return s.Trim();
        }

        public static string ToNull(this object s)
        {         
            if (s==null || string.IsNullOrWhiteSpace(s.ToString()))
                return null;
            else return s.ToString().Trim();
        }     
    }

    public static class Convert
    {

        public static string ConvertString(this object s)
        {
            if (s == null || string.IsNullOrWhiteSpace(s.ToString()))
                return null;
            else return s.ToString().Trim();
        }

        public static int? ConvertInt(this object i)
        {
            if (int.TryParse(i.ConvertString(), out int n))
                return n;
            else return null;
        }

        public static float? ConvertFloat(this object f)
        {
            if (float.TryParse(f.ConvertString(), out float n))
                return n;
            else return null;
        }

        public static DateTime? ConvertDateTime(this object d)
        {
            if (DateTime.TryParse(d.ConvertString(), out DateTime n))
                return n;
            else return null;
        }
    }
}
