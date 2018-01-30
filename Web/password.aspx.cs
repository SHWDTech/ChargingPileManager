using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Configuration;

namespace ZDEnterprise.Web
{
    public partial class password : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "1";
                main_menu.menu2 = "1-1";
               
            }
        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = Session["users"] as DataTable;
                if (tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["pwd"].ToString() != this.txtPwd1.Text.Trim())
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('原始密码输入错误！');", true);
                        return;
                    }
                    if (this.txtPwd2.Text.Trim() != this.txtPwd3.Text.Trim())
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('确认密码输入错误！');", true);
                        return;
                    }

                    int num = bll.Execute("update t_users set pwd='" + this.txtPwd2.Text.Trim() + "' where usersId='" + tb.Rows[0]["usersId"].ToString() + "'");

                    if (num > 0)
                    {
                        Session.Abandon();
                        Session.Clear();
                        System.Web.Security.FormsAuthentication.SignOut();
                        Session.Remove("users");
                        Session.Remove("permissions");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('修改密码成功，请重新登录！');window.location.href='login.aspx'", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('修改密码失败！');", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('登录超时！');window.location.href='login.aspx'", true);
                }
               
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('系统发生故障啦！');", true);
            }
        }
    }
}
