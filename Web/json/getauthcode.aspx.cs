using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;

namespace ZDEnterprise.Web.json
{
    public partial class getauthcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int result = 1;//0.获取验证码成功，1.获取验证码失败，2.系统错误  11.手机号码为空 
                string yzm = "";
                string phone = Request["phone"] != null ? Utility.Helper.Checkstr(Request["phone"]) : "";
                if (phone == null || phone == "")
                {
                    result = 0;
                }
                else
                {
                    try
                    {
                        //这里生成6位数的密码，并通过短信接口发送到手机
                        Random ran = new Random();
                        int RandKey = ran.Next(100000, 999999);

                        //发送短信到手机(互亿无线)
                        //string serverHtml = "http://106.ihuyi.cn/webservice/sms.php?";
                        //string strUrl = "method=Submit&account=" + ConfigurationManager.AppSettings["account"] + "&password=" + ConfigurationManager.AppSettings["password"] + "&mobile=" + phone + "&content=您的密码是：【" + RandKey.ToString() + "】。请妥善保存您的密码，不要泄露给其他人。";
                        //string name = GetReturn(serverHtml, strUrl);
                        
                        //
                        string key = ConfigurationManager.AppSettings["apikey"];
                        string apikey="3238b07e280986f5274b907a2af74238";
                        string message = LUOSIMAO(apikey, phone, RandKey.ToString());


                        if (message.Contains("ok"))
                        {
                            result = 1;
                            yzm = RandKey.ToString();

                            System.Model.verification_code vc = new System.Model.verification_code();
                            vc.code = yzm;
                            vc.edate = System.DateTime.Now.AddMinutes(30);
                            vc.pudate = System.DateTime.Now;
                            vc.type = (int)MyEnum.verificationTypeEnum.手机号验证;
                            vc.verificationMode = phone;
                            _bll.vcbll.Add(vc);


                            //设置20分钟的时间
                            Session["authcode"] = yzm;
                            Session.Timeout = 20;
                        }
                    }
                    catch
                    {
                        result = 2;
                    }
                }
                string jsonStr = "{\"res\":" + result + ",\"authcode\":\"" + yzm + "\"}";
                Response.Write(jsonStr);
                Response.End();
            }
        }





        /// <summary>
        /// LUOSIMAO（螺丝帽短信平台）
        /// </summary>
        /// <param name="apikey">key</param>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        private string LUOSIMAO(string apikey, string phone,string yanzhengma)
        {
            string mobile = phone,
            //message = "Test send message use luosimao! "+yanzhengma+"【铁壳测试】",
            message = "您的验证码是"+yanzhengma+"，请尽快完成验证,且不要告诉任何人【上海卫东】",
            username = "api",
            password = "key-"+apikey,
            url = "http://sms-api.luosimao.com/v1/send.json";

            byte[] byteArray = Encoding.UTF8.GetBytes("mobile=" + mobile + "&message=" + message);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(username + ":" + password));
            webRequest.Headers.Add("Authorization", auth);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;

            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string Message = php.ReadToEnd();

            return Message;
        }



        public string GetReturn(string uriStr, string postData)
        {
            System.Net.WebClient clinet = new System.Net.WebClient();
            //打开URL，GET参数以URL后缀的方式就可以传递过去。
            System.IO.Stream stream = clinet.OpenRead(uriStr + postData);
            //把从HTTP中返回的流读为string
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            string result = reader.ReadToEnd();

            return result;
        }
    }

}