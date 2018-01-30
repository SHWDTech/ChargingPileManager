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
    public partial class role_edit : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "9";
                main_menu.menu2 = "9-1";

                try
                {
                    if (RolePermissions("1001") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=9&menu2=1';</script>");
                    }

                    DataSet ds2 = bll.getDataSet("select * from t_role where roleId=" + Request.QueryString["id"] + " ");
                    DataTable tb2 = ds2.Tables[0];
                    if (tb2.Rows.Count > 0)
                    {
                        this.txtName.Text = tb2.Rows[0]["name"].ToString();
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=1");
                }
            }
        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds2 = bll.getDataSet("select * from t_role where name='" + this.txtName.Text.Trim() + "' and roleId!="+Request.QueryString["id"]+" ");
                DataTable tb2 = ds2.Tables[0];
                if (tb2.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('角色已存在');", true);
                    return;
                }

                int jg = bll.Execute("update t_role set name='" + this.txtName.Text.Trim() + "' where roleId=" + Request.QueryString["id"] + "");
                if (jg > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑角色成功！');window.location.href='role.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑角色失败！');window.location.href='role.aspx';", true);
                }

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=1");
            }
        }

    }
}
