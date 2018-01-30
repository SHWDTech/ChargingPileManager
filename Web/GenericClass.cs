using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using LitJson;

namespace ZDEnterprise.Web
{
    public class GenericClass
    {
        public GenericClass()
        {

        }

        #region GET和POST的请求
        /// <summary>
        ///GET 请求
        ///url 发送请求的链接，返回请求值
        /// </summary>
        public static string GetReturn(string uriStr, string postData)
        {
            System.Net.WebClient clinet = new System.Net.WebClient();
            //打开URL，GET参数以URL后缀的方式就可以传递过去。
            System.IO.Stream stream = clinet.OpenRead(uriStr + postData);
            //把从HTTP中返回的流读为string
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            string result = reader.ReadToEnd();

            return result;
        }

        /// <summary>
        ///POST 请求
        ///postData 发送请求的链接，返回请求值
        /// </summary>
        public static string PostReturn(string uriStr, string postData)
        {
            HttpWebRequest requestScore = (HttpWebRequest)WebRequest.Create(uriStr);

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);
            requestScore.Method = "Post";
            requestScore.ContentType = "application/x-www-form-urlencoded";
            requestScore.ContentLength = data.Length;
            requestScore.KeepAlive = true;

            Stream stream = requestScore.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            HttpWebResponse responseSorce;
            try
            {
                responseSorce = (HttpWebResponse)requestScore.GetResponse();
            }
            catch (WebException ex)
            {
                responseSorce = (HttpWebResponse)ex.Response;//得到请求网站的详细错误提示  
            }
            StreamReader reader = new StreamReader(responseSorce.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();

            requestScore.Abort();
            responseSorce.Close();
            responseSorce.Close();
            reader.Dispose();
            stream.Dispose();
            return content;
        }
        #endregion

        #region JSON的各种转换
        public static string JsonString(string result, string name)
        {
            JsonData jd = JsonMapper.ToObject(result);
            return (string)jd[name];
        }

        public static int JsonInt(string result, string name)
        {
            JsonData jd = JsonMapper.ToObject(result);
            return (int)jd[name];
        }

        public static double JsonDouble(string result, string name)
        {
            JsonData jd = JsonMapper.ToObject(result);
            return Convert.ToDouble(jd[name].ToString());
        }

        public static JsonData JsonData(string result, string name)
        {
            JsonData jd = JsonMapper.ToObject(result);
            JsonData jdItems = jd[name];
            return jdItems;
        }

        public static DataTable JsonToDataTable(string strJson)
        {
            //取出表名  
            Regex rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名  
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].ToString();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }

        public static string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName.ToString());
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        #endregion
    }
}
