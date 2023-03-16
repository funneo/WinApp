using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Common
{
    public static class ValidateUtils
    {
        /// <summary>
        /// kiem tra dia chi email 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            System.Text.RegularExpressions.Regex _Regex = new System.Text.RegularExpressions.Regex(strRegex);
            if (_Regex.IsMatch(Email))
                return (true);
            else
                return (false);
        }
        /// <summary>
        /// kiem tra string co phai la dang so
        /// </summary>
        /// <param name="inputvalue"></param>
        /// <returns></returns>
        public static bool IsNumeric(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }

        /// <summary>
        /// Kiểm tra chuỗi có phải là số thực không.
        /// </summary>
        /// <param name="inputvalue"></param>
        /// <returns></returns>
        public static bool Isdecimal(string inputvalue)
        {            
            Regex pattern = new Regex("[^0-9].");
            return !pattern.IsMatch(inputvalue);            
        }

        /// <summary>
        /// kiem tra string co phai la dang chi co chu cai va chu so
        /// </summary>
        /// <param name="inputvalue"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(string inputvalue)
        {
            //Regex isNumeric = new Regex("^[0-9a-zA-Z]+$");
           // return !isNumeric.IsMatch(inputvalue);
            Regex pattern = new Regex("[^0-9a-zA-Z]");
            return !pattern.IsMatch(inputvalue);
        }        

        /// <summary>
        /// kiem tra string co phai la double hay khong
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isdecimal(string str)
        {
            decimal Num;
            bool isNum = decimal.TryParse(str, out Num);
            if (isNum){                
                return true;
            }
            else {                
                return false;
            }                
        }     
    }
}
