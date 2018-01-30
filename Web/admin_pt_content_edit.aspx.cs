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
    public partial class admin_pt_content_edit : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "2";
                main_menu.menu2 = "2-1";

                try
                {
                    if (RolePermissions("2001") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=1';</script>");
                    }
                    DataSet ds2 = bll.getDataSet("select * from t_content where id="+Request.QueryString["id"]);
                    DataTable tb2 = ds2.Tables[0];
                    if (tb2.Rows.Count > 0)
                    {
                        this.fckContent.Text = Server.HtmlDecode(tb2.Rows[0]["memo"].ToString()); 
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=1");
                }
            }
        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Server.HtmlEncode(this.fckContent.Text.Trim());
                int jg = bll.Execute("update t_content set memo='" + text + "'  where id=" + Request.QueryString["id"]);
                if (jg > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑内容成功！');window.location.href='admin_pt_content.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑内容失败！');window.location.href='admin_pt_content.aspx';", true);
                }

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=1");
            }
        }

    }
}
