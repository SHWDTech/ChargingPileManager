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
    public partial class users_edit : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
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

                    DataSet ds2 = bll.getDataSet("select * from t_users where usersId='"+Request.QueryString["id"]+"' ");
                    DataTable tb2 = ds2.Tables[0];
                    if (tb2.Rows.Count > 0)
                    {
                        this.txtName.Text = tb2.Rows[0]["name"].ToString();
                        this.txtCode.Text = tb2.Rows[0]["code"].ToString();
                        this.ddlRole.SelectedValue = tb2.Rows[0]["roleId"].ToString();
                        this.txtPhone.Text = tb2.Rows[0]["phone"].ToString();
 
                        string logo = tb2.Rows[0]["imgUrl"].ToString();
                        hidImg.Value = logo;
                        if (logo == "")
                        {
                            this.imgLogo.ImageUrl = VirturlPath + "/Upload/logo/zw.png";
                        }
                        else
                        {
                            this.imgLogo.ImageUrl =VirturlPath + logo;
                        }
                    }

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
                else
                {
                    imgUrl = hidImg.Value;
                }

                int jg = bll.Execute("update t_users set name='" + this.txtName.Text.Trim() + "'" + (this.txtPwd.Text.Trim() == "" ? "" : ",pwd='" + this.txtPwd.Text.Trim() + "'") + ",roleId='" + this.ddlRole.SelectedValue + "',imgUrl='" + imgUrl + "',phone='" + this.txtPhone.Text.Trim() + "' where usersId='" + Request.QueryString["id"] + "'");
                if (jg > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑用户成功！');window.location.href='users.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑用户失败！');window.location.href='users.aspx';", true);
                }

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=2");
            }
        }

    }
}
