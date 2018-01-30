using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using BLL;

namespace ZDEnterprise.Web.Json
{
    public partial class zhPwdYzm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int result = 1;//0.获取验证码成功，1.获取验证码失败，2.系统错误  11.手机号码为空 
                string yzm = "";
                string phone = Request.QueryString["phone"];
                if (phone == null || phone == "")
                {
                    result = 11;
                }
                else
                {
                    ClassBLL bll = new ClassBLL();
                    DataSet ds = bll.getDataSet("select * from t_custom where phone='" + phone + "' ");
                    DataTable tb = ds.Tables[0];
                    if (tb == null || tb.Rows.Count < 1)
                    {
                        result = 12;//手机号码已注册
                    }
                    else
                    {
                        try
                        {
                            //这里生成6位数的密码，并通过短信接口发送到手机
                            Random ran = new Random();
                            int RandKey = ran.Next(100000, 999999);

                            //发送短信到手机
                            string serverHtml = "http://106.ihuyi.cn/webservice/sms.php?";
                            string strUrl = "method=Submit&account=" + ConfigurationManager.AppSettings["account"] + "&password=" + ConfigurationManager.AppSettings["password"] + "&mobile=" + phone + "&content=您的密码是：【" + RandKey.ToString() + "】。请妥善保存您的密码，不要泄露给其他人。";
                            string name = GetReturn(serverHtml, strUrl);

                            if (name.IndexOf("提交成功") != -1)
                            {
                                result = 0;
                                yzm = RandKey.ToString();
                            }

                        }
                        catch
                        {
                            result = 2;
                        }
                    }
                }

                string jsonStr = "{\"result\":" + result + ",\"yzm\":\"" + yzm + "\"}";
                Response.Write(jsonStr);
                Response.End();
            }
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
