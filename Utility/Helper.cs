using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Helper
    {

        #region 经纬度计算

        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;
        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        #endregion


        #region 正则表达式

        /// <summary>   
        /// 取得HTML中所有图片的 URL。   
        /// </summary>   
        /// <param name="sHtmlText">HTML代码</param>   
        /// <returns>图片的URL列表</returns>   
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            return sUrlList;
        }

        #endregion



        #region 字符处理




        /// <summary>
        /// 判断对象是否为空和空字符串
        /// </summary>
        /// <param name="str">对象(字符串,值类型)</param>
        /// <returns>是否为空</returns>
        public static bool IsNotEmptyTrue(object str)
        {
            bool isempty = false;

            if (str != null && gerString(str) != "")
            {
                isempty = true;
            }
            return isempty;
        }

        /// <summary>
        /// 时间字符串
        /// </summary>
        /// <returns></returns>
        public static string getDateString()
        {
            return System.DateTime.Now.ToString();
        }

        /// <summary>
        /// 时间
        /// </summary>
        /// <returns></returns>
        public static DateTime getDate()
        {
            return System.DateTime.Now;
        }

        /// <summary>
        /// 返回字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string gerString(object str)
        {
            return str != null ? str.ToString() : "";
        }

        /// <summary>
        /// decimal 类型数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal gerDecimal(object str)
        {
            decimal a = 0;
            try
            {
                if (str != null)
                {
                    a = str != null ? decimal.Parse(str.ToString()) : 0;
                }
            }
            catch (Exception ex)
            {


            }
            return a;

        }




        /// <summary>
        /// 返回数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int gerInt(object str)
        {
            int a = 0;
            try
            {
                if (str != null)
                {
                    a = str != null ? int.Parse(str.ToString()) : 0;
                }
            }
            catch (Exception ex)
            {


            }
            return a;
        }


        /// <summary>
        /// 返回两位数(01,56)
        /// </summary>
        /// <param name="Numer">数字</param>
        /// <returns></returns>
        public string retDouble(int Numer)
        {
            string str = "00";
            if (Numer < 10)
            {
                str = "0" + Numer;
            }
            else
            {
                str = Numer.ToString();
            }
            return str;
        }


        /// <summary>
        /// 特殊符号过滤
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Checkstr(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(" ", "");
                str = str.Replace(";", "");
                str = str.Replace("&", "&amp;");
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                str = str.Replace("'", "");
                str = str.Replace("--", "");
                str = str.Replace("/", "");
                str = str.Replace("%", "");
            }
            return str;
        }


        /// <summary>
        /// 特殊符号过滤(不过滤空格)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckstrNoTrim(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                //str = str.Replace(" ", "");
                str = str.Replace(";", "");
                str = str.Replace("&", "&amp;");
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                str = str.Replace("'", "");
                str = str.Replace("--", "");
                str = str.Replace("/", "");
                str = str.Replace("%", "");
            }
            return str;
        }


        /// <summary>
        /// 特殊符号过滤(图片路径) 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckstrImg(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(" ", "");
                str = str.Replace(";", "");
                str = str.Replace("&", "&amp;");
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                str = str.Replace("'", "");
                str = str.Replace("--", "");
                //str = str.Replace("/", "");
                str = str.Replace("%", "");
            }
            return str;
        }

        #endregion

        /// <summary>
        /// 获取地址(虚拟地址)
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetHttpUrl(string address)
        {
            return GetConfigAppSettings("VirturlPath") + address;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="appSettingName">key</param>
        /// <returns></returns>
        public static string GetConfigAppSettings(string appSettingName)
        {
            string res = "";
            try
            {
                res = System.Configuration.ConfigurationManager.AppSettings[appSettingName];
            }
            catch { }
            return res;
        }
        #region 时间处理

        /// <summary>
        /// 按时间判断返回个性时间结果
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string getdates(string timestr)
        {
            string date = "";
            if (!string.IsNullOrEmpty(timestr))
            {
                try
                {
                    DateTime time = Convert.ToDateTime(timestr);

                    TimeSpan ts = System.DateTime.Now.Subtract(time);
                    if (ts.Days < 1 && System.DateTime.Now.Day == time.Day)
                    {
                        date = "今天" + time.Hour + ":" + time.Minute;
                    }
                    else if (ts.Days > 1 && System.DateTime.Now.Day > time.Day)
                    {
                        date = "昨天" + time.Hour + ":" + time.Minute;
                    }
                    else if (ts.Days < 1 && System.DateTime.Now.Day > time.Day)
                    {
                        date = "昨天" + time.Hour + ":" + time.Minute;
                    }
                    else if (ts.Days >= 1)
                    {
                        date = time.Month + " " + time.Day + " " + time.Hour + ":" + time.Minute;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return date;
        }

        /// <summary>
        /// 获取与当前时间的时间差
        /// </summary>
        /// <param name="time">对比时间</param>
        /// <param name="Types">1 当前时间大于 2当前时间小于 </param>
        /// <returns></returns>
        public static int AccessTime(DateTime time, int Types)
        {
            int i = 0;

            TimeSpan ts = new TimeSpan();
            switch (Types)
            {
                case 1:
                    ts = System.DateTime.Now.Subtract(time);
                    i = ts.Days;
                    break;
                case 2:
                    ts = time.Subtract(System.DateTime.Now);
                    i = ts.Days;
                    break;
                default:
                    break;
            }
            return i;
        }


        #endregion

        /// <summary>
        /// （处理）返回图片地址
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <returns></returns>
        public static string getImgUrl(object url)
        {
            string RuUrl = "";
            if (url != null)
            {
                string Url = url.ToString();
                if (!string.IsNullOrEmpty(Url))
                {
                    if (Url.Length > 4)
                    {
                        string Url_ = Url.Substring(0, 4);
                        if (Url_ == "http")
                        {
                            RuUrl = Url;
                        }
                        else
                        {
                            RuUrl = Utility.Helper.GetHttpUrl(Url);
                        }
                    }

                }
            }
            return RuUrl;

        }

        #region 获取IP地址
        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public string GetIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "127.0.0.1";
            }
            return result;
        }
        #endregion

        #region 编码

        #region gbk
        //地址编码 gbk
        public static string UrlEncode(string dataStr)
        {
            return HttpUtility.UrlEncode(dataStr, Encoding.GetEncoding("gbk"));
        }

        //地址解码 gbk
        public static string UrlDecode(string dataStr)
        {
            return HttpUtility.UrlDecode(dataStr, Encoding.GetEncoding("gbk"));
        }
        #endregion

        /// <summary>
        /// 编码 (UTF-8,GB2312,)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="types">编码格式</param>
        /// <returns></returns>
        public static string MyEncode(string str, string types)
        {
            return System.Text.Encoding.GetEncoding("GBK").GetString(System.Text.Encoding.Unicode.GetBytes(str));
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static string MyDecoder(string str, string types)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            return Encoding.GetEncoding("GBK").GetString(buffer);
        }

        #endregion

        #region MD5

        /// <summary>
        /// 给一个字符串进行MD5加密(不推荐使用)
        /// </summary>
        /// <param   name="strText">待加密字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }



        /**/
        /// <summary>
        /// MD5 16位加密 加密后密码为大写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /**/
        /// <summary>
        /// MD5 16位加密 加密后密码为小写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5StrLower(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");

            t2 = t2.ToLower();

            return t2;
        }


        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UserMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                pwd = pwd + s[i].ToString("x");

            }
            return pwd;
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="inputString">加密字符串</param>
        /// <returns></returns>
        public static string StringToMD5Hash(string inputString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }

        #endregion


        #region 数据处理

        /// <summary>
        /// datatable去重复(ADO.NET)
        /// </summary>
        /// <param name="SourceDt">datatab</param>
        /// <param name="filedName">字段名</param>
        /// <returns></returns>
        public static DataTable GetDistinctSelf(DataTable SourceDt, string filedName)
        {
            for (int i = SourceDt.Rows.Count - 1; i > 0; i--)
            {
                DataRow[] rows = SourceDt.Select(string.Format("{0}='{1}'", filedName, SourceDt.Rows[i][filedName]));
                if (rows.Length > 1)
                {
                    SourceDt.Rows.RemoveAt(i);
                }
            }
            return SourceDt;

        }

        #endregion


        #region 随机数

        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// 生成随机数
        public static int rnd()
        {
            Random ran = new Random(GetRandomSeed());
            int cnt = ran.Next(0, 59);
            return cnt;
        }


        /// <summary>
        /// 随机数
        /// </summary>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static int rnd(int max)
        {

            Random ran = new Random(GetRandomSeed());
            int cnt = ran.Next(0, max);
            return cnt;
        }


        /// <summary>
        /// 多位随机数
        /// </summary>
        /// <param name="sdk">位数</param>
        /// <returns></returns>
        public static string rnds(int sdk)
        {
            string cnts = "";
            for (int i = 0; i < sdk; i++)
            {
                Random ran = new Random(GetRandomSeed());
                int cnt = ran.Next(0, 9);
                cnts += cnt.ToString();
            }
            return cnts;
        }
        #endregion


    }
}
