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
    public partial class admin_web_img_edit : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "2";
                main_menu.menu2 = "2-4";

                try
                {
                    if (RolePermissions("2004") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                    }

                    DataSet ds2 = bll.getDataSet("select * from t_img where id=" + Request.QueryString["id"] + " ");
                    DataTable tb2 = ds2.Tables[0];
                    if (tb2.Rows.Count > 0)
                    {
                        this.txtId.Text = tb2.Rows[0]["tzId"].ToString();
                        this.ddlLx.SelectedValue = tb2.Rows[0]["lx"].ToString();
                        string logo = tb2.Rows[0]["img"].ToString();
                        hidImg.Value = logo;
                        this.imgLogo.ImageUrl = VirturlPath + logo;
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
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
                             String path = Server.MapPath("Upload/gg/");
                             hp.SaveAs(Path.Combine(path, Filename1));
                             imgUrl = "/Upload/gg/" + Filename1;
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

                     int jg = bll.Execute("update t_img set img='" + imgUrl + "',tzId='" + this.txtId.Text.Trim() + "',lx='" + this.ddlLx.SelectedValue + "'  where id=" + Request.QueryString["id"] + "");
                     if (jg > 0)
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑图片成功！');window.location.href='admin_web_img.aspx';", true);
                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑图片失败！');window.location.href='admin_web_img.aspx';", true);
                     }
               

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
            }
        }

    }
}
