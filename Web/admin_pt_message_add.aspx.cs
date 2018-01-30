using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Data;
using System.IO;

namespace ZDEnterprise.Web
{
    public partial class admin_pt_message_add : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "2";
                main_menu.menu2 = "2-5";

                if (RolePermissions("2005") == false)
                {
                    Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=5';</script>");
                }

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
        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {



                int jg = bll.Execute("insert into t_message(title,memo,pudate) values('" + this.txtTitle.Text.Trim() + "','" + this.txtMemo.Text.Trim() + "',convert(nvarchar(19),GETDATE(),121))");
                     if (jg > 0)
                     {

                         //string serverHtml3 = "http://getui.vx818.com/index.aspx?";
                         //string strUrl3 = "appid=" + ConfigurationManager.AppSettings["gtappid"] + "&appkey=" + ConfigurationManager.AppSettings["gtappkey"] + "&mastersecret=" + ConfigurationManager.AppSettings["mastersecret"] + "&cid=&mes=" + this.txtMemo.Text.Trim();
                         //string name3 = GetReturn(serverHtml3, strUrl3);


                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('新增消息成功！');window.location.href='admin_pt_message.aspx';", true);
                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('新增消息失败！');window.location.href='admin_pt_message.aspx';", true);
                     }
               

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
            }
        }

    }
}
