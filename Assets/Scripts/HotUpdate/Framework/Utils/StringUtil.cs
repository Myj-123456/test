using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ADK
{
    /// <summary>
    ///  author 
    /// </summary>
    public static class StringUtil
    {
        private static TextGenerator textGenerator;
        private static StringBuilder builder = new StringBuilder();

        public static Regex FullTimeStrReg = new Regex("([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-9])))\\s([0-1]?[0-9]|2[0-3]):([0-5]?[0-9]):([0-5]?[0-9])");
        public static string TrimStart(this string str, string trim)
        {
            while (str.StartsWith(trim))
                str = str.Substring(trim.Length);
            return str;
        }

        public static string TrimEnd(this string str, string trim)
        {
            while (str.EndsWith(trim))
            {
                str = str.Substring(0, str.Length - trim.Length);
            }
            return str;
        }
        public static string Trim(this string str, string start, string end = null)
        {
            if (end == null)
                end = start;
            str = TrimStart(str, start);
            str = TrimEnd(str, end);
            return str;
        }

        public static string Trim(string str, Text textField)
        {
            if (textGenerator == null)
                textGenerator = new TextGenerator();
            var seting = textField.GetGenerationSettings(textField.rectTransform.rect.size);
            str = str.Trim();
            try
            {
                textGenerator.Populate(str, seting);
                int startIndex = 0;
                int endIndex = str.Length;
                UICharInfo[] chats = textGenerator.GetCharactersArray();
                for (int i = 0; i < chats.Length; i++)
                {
                    UICharInfo info = chats[i];
                    if (info.charWidth == 0 || (str.Length > i && str[i].ToString().Trim().Length == 0))
                        startIndex = i + 1;
                    else
                        break;
                }

                for (int i = chats.Length - 1; i >= 0; i--)
                {
                    UICharInfo info = chats[i];
                    if (info.charWidth == 0 || (str.Length > i && str[i].ToString().Trim().Length == 0))
                        endIndex = i;
                    else
                        break;
                }
                if (endIndex < startIndex)
                    str = "";
                else
                    str = str.Substring(startIndex, endIndex - startIndex);
            }
            catch (Exception ee)
            {
                Debug.LogError(ee);
            }
            return str;
        }

        public static string Concat(params string[] str)
        {
            for (var i = 0; i < str.Length; i++)
                builder.Append(str[i]);
            var s = builder.ToString();
            builder.Length = 0;
            return s;
        }


        public static string ToByteString(ulong l, int dec = 1)
        {
            if (l < 0)
            {
                return "0";
            }
            var str = string.Empty;
            if (dec == 0)
                str = "{0:0}";
            else if (dec == 1)
                str = "{0:0.0}";
            else
                str = "{0:0.00}";
            if (l >= 1024 * 1024 * 1024) //文件大小大于或等于1024MB
            {
                return string.Format(str + " GB", (double)l / (1024 * 1024 * 1024));
            }
            else if (l >= 1024 * 1024) //文件大小大于或等于1024KB
            {
                return string.Format(str + " MB", (double)l / (1024 * 1024));
            }
            else if (l >= 1024) //文件大小大于等于1024bytes
            {
                return string.Format(str + " KB", (double)l / 1024);
            }
            else if (l >= 1024 / 100 && dec > 0) //文件大小大于等于1024bytes
            {
                return string.Format("{0:0.00} KB", (double)l / 1024);
            }
            else
            {
                return string.Format("{0:0} bytes", l);
            }
        }

        public static void SetBtnTab(FairyGUI.GComponent btn, string txt)
        {
            if (btn.GetChild("titleLab") != null) btn.GetChild("titleLab").text = txt;
        }

        public static void SetBtnCount(FairyGUI.GComponent btn, string txt)
        {
            if (btn.GetChild("countLab") != null) btn.GetChild("countLab").text = txt;
        }

        public static void SetBtnTab3(FairyGUI.GComponent btn, string txt)
        {
            if (btn.GetChild("titleLab1") != null) btn.GetChild("titleLab1").text = txt;
        }

        /// <summary>
        /// 按钮文本拆开显示
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="txt">必须为两个长度字符串</param>
        public static void SetBtnTab2(FairyGUI.GComponent btn, string txt)
        {
            if (txt.Length==2)
            {
                if (btn.GetChild("titleLab") != null) btn.GetChild("titleLab").text = txt.Substring(0,1);
                if (btn.GetChild("titleLab1") != null) btn.GetChild("titleLab1").text = txt.Substring(1,1);
            }
        }

        public static void SetBtnUrl(FairyGUI.GComponent btn, string txt)
        {
            if (btn.GetChild("pic") != null) (btn.GetChild("pic") as FairyGUI.GLoader).url = txt;
        }

        public static Color HexToColor(string hex)
        {
            hex = hex.TrimStart('#');
            int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32((byte)r, (byte)g, (byte)b, 255);
        }

        public static bool VerifyPassword(string password)
        {
            string pattern = @"\d{6}$";
            Regex regex = new Regex(pattern);
            if(password != null && regex.IsMatch(password))
            {
                return true;
            }
            return false;
        }
        #region using NewTonsoft.Json
        public static string SerializeObject(System.Object obj)
        {
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return str;
        }

        public static T DeserializeObject<T>(string str)
        {
            T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
            return obj;
        }
        #endregion
        //public static void SetBtnUrl(FairyGUI.GComponent btn, string txt)
        //{
        //    if (btn.GetChild("pic") != null) btn.GetChild("pic")["url"] = txt;
        //}

    }
}
