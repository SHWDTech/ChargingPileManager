using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace System
{
    public class MyString
    {

        public static string SubString(object s, int length)
        {
            string text = s.ToString();
            string result;
            if (!string.IsNullOrEmpty(text) && text.Length > length)
            {
                result = text.Substring(text.Length - length, length);
            }
            else
            {
                result = text;
            }
            return result;
        }
        public static string SubstringOfByte(string str, int byteLength)
        {
            string text = "";
            if (Encoding.Default.GetByteCount(str) > byteLength)
            {
                int num = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    string text2 = str[i].ToString();
                    int byteCount = Encoding.Default.GetByteCount(text2);
                    num += byteCount;
                    if (num > byteLength)
                    {
                        break;
                    }
                    text += text2;
                }
            }
            else
            {
                text = str;
            }
            return text;
        }
        public static string CreateRandomString(int length, bool isNumber, bool isLetter)
        {
            string text = "";
            Random random = new Random();
            string text2;
            if (isNumber)
            {
                text2 = "0123456789";
            }
            else
            {
                if (isLetter)
                {
                    text2 = "abcdefghijklmnopqrstuvwxyz";
                }
                else
                {
                    text2 = "0123456789abcdefghijklmnopqrstuvwxyz";
                }
            }
            int length2 = text2.Length;
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, length2);
                text += text2[index];
            }
            return text;
        }
        public static string StringToUnicode(string s)
        {
            char[] array = s.ToCharArray();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(array[i].ToString());
                stringBuilder.Append(string.Format("\\u{0:X2}{1:X2}", bytes[1], bytes[0]));
            }
            return stringBuilder.ToString();
        }
        public static string UnicodeToString(string srcText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string pattern = "\\\\u[0-9a-fA-F]{4}";
            MatchCollection matchCollection = Regex.Matches(srcText, pattern);
            string[] array = Regex.Split(srcText, pattern);
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i]);
                if (i < matchCollection.Count)
                {
                    try
                    {
                        stringBuilder.Append(char.ConvertFromUtf32(int.Parse(matchCollection[i].Value.Substring(2, 4), NumberStyles.HexNumber)));
                    }
                    catch
                    {
                    }
                }
            }
            return stringBuilder.ToString();
        }
        public static string StringToBase64(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }
        public static string Base64ToString(string srcText)
        {
            string result = "";
            try
            {
                byte[] bytes = Convert.FromBase64String(srcText);
                result = Encoding.Default.GetString(bytes);
            }
            catch
            {
            }
            return result;
        }
        public static string ToSBC(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == ' ')
                {
                    array[i] = '\u3000';
                }
                else
                {
                    if (array[i] < '\u007f')
                    {
                        array[i] += 'ﻠ';
                    }
                }
            }
            return new string(array);
        }
        public static string ToDBC(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '\u3000')
                {
                    array[i] = ' ';
                }
                else
                {
                    if (array[i] > '＀' && array[i] < '｟')
                    {
                        array[i] -= 'ﻠ';
                    }
                }
            }
            return new string(array);
        }
        public static bool IsEmail(string input)
        {
            Regex regex = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            return regex.IsMatch(input);
        }
        public static bool IsUrl(string input)
        {
            Regex regex = new Regex("^http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w-./?%&=]*)?$");
            return regex.IsMatch(input);
        }
        public static bool IsChineseChar(string input)
        {
            Regex regex = new Regex("^[一-龥]{0,}$");
            return regex.IsMatch(input);
        }
        public static bool IsLegal(string input)
        {
            Regex regex = new Regex("[^%&',;=?$\"]+");
            return regex.IsMatch(input);
        }
        public static bool IsFixedPhone(string input)
        {
            Regex regex = new Regex("^(\\d{3,4}-)\\d{7,8}$");
            return regex.IsMatch(input);
        }
        public static bool IsMobilePhone(string input)
        {
            Regex regex = new Regex("^[1]+\\d{10}$");
            return regex.IsMatch(input);
        }
        public static string HideSercetInfo(string str, int startindex, int length)
        {
            string result = "";
            try
            {
                if (str.Length >= startindex + length)
                {
                    string text = "";
                    for (int i = 0; i < length; i++)
                    {
                        text += "*";
                    }
                    result = str.Substring(0, startindex) + text + str.Substring(startindex + length);
                }
                else
                {
                    if (str.Length > startindex)
                    {
                        length = str.Length - startindex;
                        string text2 = "";
                        for (int j = 0; j < length; j++)
                        {
                            text2 += "*";
                        }
                        result = str.Substring(0, startindex) + text2;
                    }
                    else
                    {
                        result = str;
                    }
                }
            }
            catch
            {
            }
            return result;
        }
        public static string HideMobile(string mobile)
        {
            return MyString.HideSercetInfo(mobile, 3, 4);
        }
    }
}
