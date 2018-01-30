using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using HttpWebRequestClient;
using HttpWebRequestClient.Model;

namespace ZDEnterprise.Web.json
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //public static bool IsGood = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            #region  招租题目


            //int[] arr = new int[] { 8, 2, 1, 0, 3 };
            //
            //int[] index = new int[] { 2, 0, 3, 2, 4, 0, 1, 3, 2, 3, 3 };
            //string tel = "";
            //
            ////for(int i:index)
            //for (int j = 0; j < index.Count(); j++)
            //{
            //    tel += arr[index[j]];
            //}
            //string jieguo = tel;
            #endregion

            #region 推送(个推)
            //_bll.InitGeTui();
            //_bll.addpust("1032", "标题", "略略略");
            #endregion



            #region 获取响应头信息
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //int headcount = Request.Headers.Count;
            //for (int i = 0; i < headcount; i++)
            //{
            //    dic.Add(Request.Headers.Get(i), Request.Headers.Keys[i]);
            //}
            #endregion

            #region 模拟请求
            //HttpPost("http://140.206.70.162:8092/login.aspx", "");
            #endregion

            #region 请求充电桩状态 获取返回值
            //var manager = new ApiManager();
            //Response.Write(manager.GetServerInfo() + " " + manager.GetChargingPileInfo("0044151300001"));
            //Response.End();
            var manager = new ApiManager();

            string strinfo = "";
            //测试接口
            strinfo += "<br/>" + manager.GetServerInfo();

            //获取指定充电桩及充电枪状态
            strinfo += "<br/>" + manager.GetChargingPileInfo("0044151300001");

            var dic = new Dictionary<string, string>();
            dic.Add("ShotIndentity", "0044151300001");
            //发送自检指令
            var parsStr = JsonConvert.SerializeObject(dic);
            var selfTestModel = new CommandPostViewModel();
            selfTestModel.CommandName = "SelfTest";
            selfTestModel.TargetIdentity = "0044151300001";
            selfTestModel.Pars = parsStr;
            strinfo += "<br/>" + manager.PostCommand(selfTestModel);

            //发送充电指令
            var chargingModel = new CommandPostViewModel();
            chargingModel.CommandName = "StartCharging";
            chargingModel.TargetIdentity = "0044151300001";
            chargingModel.Pars = parsStr;
            strinfo += "<br/>" + manager.PostCommand(new CommandPostViewModel
            {
                CommandName = "StartCharging",
                TargetIdentity = "0044151300001",
                Pars = JsonConvert.SerializeObject(new Dictionary<string, string>
                {
                    { "ShotIndentity", "0044151300001" }
                })
            });


            Response.Write(strinfo);
            #endregion

        }


        private string HttpPost(string Url, string postDataStr)
        {
            //
            CookieContainer cookie = new CookieContainer();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.Headers.Add("appid:123456");
            request.Headers.Add("appkey:chenyue");
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();



            Dictionary<string, string> dic = new Dictionary<string, string>();
            int headcount = response.Headers.Count;
            for (int i = 0; i < headcount; i++)
            {

                dic.Add(response.Headers.Get(i), response.Headers.Keys[i]);
            }

            return retString;
        }

        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}