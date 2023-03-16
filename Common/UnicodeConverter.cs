﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Common
{
    public class UnicodeConverter
    {
        private static string[] tcvnchars = new string[] {
            "µ", "¸", "¶", "·", "¹",            //1
            "¨", "»", "¾", "¼", "½", "Æ",       //2
            "©", "Ç", "Ê", "È", "É", "Ë",       //3
            "®", "Ì", "Ð", "Î", "Ï", "Ñ",       //4
            "ª", "Ò", "Õ", "Ó", "Ô", "Ö",       //5
            "×", "Ý", "Ø", "Ü", "Þ",            //6
            "ß", "ã", "á", "â", "ä",            //7
            "«", "å", "è", "æ", "ç", "é",       //8
            "¬", "ê", "í", "ë", "ì", "î",       //9
            "ï", "ó", "ñ", "ò", "ô",            //10
            "­", "õ", "ø", "ö", "÷", "ù",       //11
            "ú", "ý", "û", "ü", "þ",            //12
            "¡", "¢", "§", "£", "¤", "¥", "¦",   //13

            "µ", "¸", "¶", "·", "¹",            //1
            "»", "¾", "¼", "½", "Æ",       //2
            "Ç", "Ê", "È", "É", "Ë",       //3
            "Ì", "Ð", "Î", "Ï", "Ñ",       //4
            "Ò", "Õ", "Ó", "Ô", "Ö",       //5
            "×", "Ý", "Ø", "Ü", "Þ",            //6
            "ß", "ã", "á", "â", "ä",            //7
            "å", "è", "æ", "ç", "é",       //8
            "ê", "í", "ë", "ì", "î",       //9
            "ï", "ó", "ñ", "ò", "ô",            //10
            "õ", "ø", "ö", "÷", "ù",       //11
            "ú", "ý", "û", "ü", "þ",            //12

        };

        private static string[] unichars = new string[]{
            "à", "á", "ả", "ã", "ạ",            //1
            "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ",       //2
            "â", "ầ", "ấ", "ẩ", "ẫ", "ậ",       //3
            "đ", "è", "é", "ẻ", "ẽ", "ẹ",       //4
            "ê", "ề", "ế", "ể", "ễ", "ệ",       //5
            "ì", "í", "ỉ", "ĩ", "ị",            //6
            "ò", "ó", "ỏ", "õ", "ọ",            //7
            "ô", "ồ", "ố", "ổ", "ỗ", "ộ",       //8
            "ơ", "ờ", "ớ", "ở", "ỡ", "ợ",       //9
            "ù", "ú", "ủ", "ũ", "ụ",            //10
            "ư", "ừ", "ứ", "ử", "ữ", "ự",       //11
            "ỳ", "ý", "ỷ", "ỹ", "ỵ",            //12
            "Ă", "Â", "Đ", "Ê", "Ô", "Ơ", "Ư",   //13

            "À", "Á", "Ả", "Ã", "Ạ",            //1
            "Ằ", "Ắ", "Ẳ", "Ẵ", "Ặ",       //2
            "Ầ", "Ấ", "Ẩ", "Ẫ", "Ậ",       //3
            "È", "É", "Ẻ", "Ẽ", "Ẹ",       //4
            "Ề", "Ế", "Ể", "Ễ", "Ệ",       //5
            "Ì", "Í", "Ỉ", "Ĩ", "Ị",            //6
            "Ò", "Ó", "Ỏ", "Õ", "Ọ",            //7
            "Ồ", "Ố", "Ổ", "Ỗ", "Ộ",       //8
            "Ờ", "Ớ", "Ở", "Ỡ", "Ợ",       //9
            "Ù", "Ú", "Ủ", "Ũ", "Ụ",            //10
            "Ừ", "Ứ", "Ử", "Ữ", "Ự",       //11
            "Ỳ", "Ý", "Ỷ", "Ỹ", "Ỵ"            //12
        };

        private static string[] uniCchars = new string[]{
            "&#224;", "&#225;", "&#7843;", "&#227;", "&#7841;",            //1
            "&#259;", "&#7857;", "&#7855;", "&#7859;", "&#7861;", "&#7863;",       //2
            "&#226;", "&#7847;", "&#7845;", "&#7849;", "&#7851;", "&#7853;",       //3
            "&#273;", "&#232;", "&#233;", "&#7867;", "&#7869;", "&#7865;",       //4
            "&#234;", "&#7873;", "&#7871;", "&#7875;", "&#7877;", "&#7879;",       //5
            "&#236;", "&#237;", "&#7881;", "&#297;", "&#7883;",            //6
            "&#242;", "&#243;", "&#7887;", "&#245;", "&#7885;",            //7
            "&#244;", "&#7891;", "&#7889;", "&#7893;", "&#7895;", "&#7897;",       //8
            "&#417;", "&#7901;", "&#7899;", "&#7903;", "&#7905;", "&#7907;",       //9
            "&#249;", "&#250;", "&#7911;", "&#361;", "&#7909;",            //10
            "&#432;", "&#7915;", "&#7913;", "&#7917;", "&#7919;", "&#7921;",       //11
            "&#7923;", "&#253;", "&#7927;", "&#7929;", "&#7925;",            //12
            "&#258;", "&#194;", "&#272;", "&#202;", "&#212;", "&#416;", "&#431;",   //13

            "&#224;", "&#225;", "&#7843;", "&#227;", "&#7841;",            //1
            "&#7857;", "&#7855;", "&#7859;", "&#7861;", "&#7863;",       //2
            "&#7847;", "&#7845;", "&#7849;", "&#7851;", "&#7853;",       //3
            "&#232;", "&#233;", "&#7867;", "&#7869;", "&#7865;",       //4
            "&#7873;", "&#7871;", "&#7875;", "&#7877;", "&#7879;",       //5
            "&#236;", "&#237;", "&#7881;", "&#297;", "&#7883;",            //6
            "&#242;", "&#243;", "&#7887;", "&#245;", "&#7885;",            //7
            "&#7891;", "&#7889;", "&#7893;", "&#7895;", "&#7897;",       //8
            "&#7901;", "&#7899;", "&#7903;", "&#7905;", "&#7907;",       //9
            "&#249;", "&#250;", "&#7911;", "&#361;", "&#7909;",            //10
            "&#7915;", "&#7913;", "&#7917;", "&#7919;", "&#7921;",       //11
            "&#7923;", "&#253;", "&#7927;", "&#7929;", "&#7925;"
        };

        public static string TCVN3ToUnicode(string value)
        {
            if (value == null || value.Length == 0) return value;
            string returnchar = value;
            for (int i = 0; i < uniCchars.Length; i++)
            {
                returnchar = returnchar.Replace(uniCchars[i], unichars[i]);
            }
            return returnchar;
        }

        public static string UnicodeToTCVN3(string value)
        {

            if (value == null || value.Length == 0) return value;
            string returnchar = value;
            for (int i = 0; i < unichars.Length; i++)
            {
                returnchar = returnchar.Replace(unichars[i], tcvnchars[i]);
            }
            return returnchar;
        }

    }
}

