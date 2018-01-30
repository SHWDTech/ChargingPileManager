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
    public partial class admin_pt_message_edit : Manager
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
                DataSet ds2 = bll.getDataSet("select * from t_message where id='" + Request.QueryString["id"] + "' ");
                DataTable tb2 = ds2.Tables[0];
                if (tb2.Rows.Count > 0)
                {
                    this.txtTitle.Text = tb2.Rows[0]["title"].ToString();
                    this.txtMemo.Text = tb2.Rows[0]["memo"].ToString();
                   
                }
            }
        }
 
        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {



                int jg = bll.Execute("update t_message set title='" + this.txtTitle.Text.Trim() + "',memo='" + this.txtMemo.Text.Trim() + "' where id='"+Request.QueryString["id"]+"'");
                     if (jg > 0)
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑消息成功！');window.location.href='admin_pt_message.aspx';", true);
                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑消息失败！');window.location.href='admin_pt_message.aspx';", true);
                     }
               

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
            }
        }

    }
}






