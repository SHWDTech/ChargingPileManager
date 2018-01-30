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
    public partial class users_add : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "9";
                main_menu.menu2 = "9-2";

                try
                {
                    if (RolePermissions("1002") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=9&menu2=2';</script>");
                    }

                    DataSet ds = bll.getDataSet("select * from t_role where roleId!=2");
                    DataTable tb = ds.Tables[0];
                    if (tb.Rows.Count > 0)
                    {
                        ddlRole.DataSource = tb;
                        ddlRole.DataTextField = "name";
                        ddlRole.DataValueField = "roleId";
                        ddlRole.DataBind();
                    }
                    this.ddlRole.Items.Insert(0, new ListItem("选择角色", ""));
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=2");
                }

            }
        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds2 = bll.getDataSet("select * from t_users where code='" + this.txtCode.Text.Trim() + "' ");
                DataTable tb2 = ds2.Tables[0];
                if (tb2.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('登录帐号已存在');", true);
                    return;
                }


                string imgUrl = "";
                HttpPostedFile hp = fileLogo.PostedFile;
                if (hp.FileName.ToString() != "")
                {
                    string hz = hp.FileName.ToString().Substring(hp.FileName.ToString().LastIndexOf(".") + 1);
                    if (hz == "jpg" || hz == "png")
                    {
                        string Filename1 = Guid.NewGuid().ToString() + "." + hz;
                        String path = Server.MapPath("Upload/logo/");
                        hp.SaveAs(Path.Combine(path, Filename1));
                        imgUrl = "/Upload/logo/" + Filename1;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('请选择jpg或png格式的图片');", true);
                        return;
                    }
                }

                int jg = bll.Execute("insert into t_users(usersId,name,code,pwd,roleId,pudate,imgUrl,phone) values('" + Guid.NewGuid().ToString() + "','" + this.txtName.Text.Trim() + "','" + this.txtCode.Text.Trim() + "','" + this.txtPwd.Text.Trim() + "','" + this.ddlRole.SelectedValue + "',convert(nvarchar(19),GETDATE(),121),'" + imgUrl + "','" + this.txtPhone.Text.Trim() + "')");
                if (jg > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('新增用户成功！');window.location.href='users.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('新增用户失败！');window.location.href='users.aspx';", true);
                }

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=2");
            }
        }

    }
}
