using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Data;

namespace ZDEnterprise.Web
{
    public partial class admin_feedback_edit : Manager
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

                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    DataSet ds2 = bll.getDataSet("select * from System_FAQ where id='" + id + "' ");
                    DataTable tb2 = ds2.Tables[0];
                    if (tb2.Rows.Count > 0)
                    {
                        this.txtTitle.Text = tb2.Rows[0]["issue"].ToString();
                        this.fckContent.Text = Server.HtmlDecode(tb2.Rows[0]["answer"].ToString());
                    }
                }

            }
        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {


                string id = Request.QueryString["id"];
                string text = Server.HtmlEncode(this.fckContent.Text.Trim());
                if (!string.IsNullOrEmpty(id))
                {
                    int jg = bll.Execute("update System_FAQ set issue='" + this.txtTitle.Text.Trim() + "',answer='" + text + "' where id='" + Request.QueryString["id"] + "'");
                    if (jg > 0)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑常见问题成功！');window.location.href='admin_feedback.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑常见问题失败！');window.location.href='admin_feedback.aspx';", true);
                    }
                }
                else
                {

                    System.Model.System_FAQ sf = new System.Model.System_FAQ();

                    sf.issue = this.txtTitle.Text;
                    sf.pudate = System.DateTime.Now;
                    sf.answer = Server.HtmlEncode(this.fckContent.Text);
                    if (_bll.sfbll.Add(sf) > 0)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加常见问题成功！');window.location.href='admin_feedback.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加常见问题失败！');window.location.href='admin_feedback.aspx';", true);
                    }
                }



            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
            }
        }


    }
}