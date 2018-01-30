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
    public partial class admin_web_img_add : Manager
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

                if (RolePermissions("2004") == false)
                {
                    Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
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


                     int jg = bll.Execute("insert into t_img(pudate,img,tzId,lx) values(convert(nvarchar(19),GETDATE(),121),'" + imgUrl + "','" + this.txtId.Text.Trim() + "','"+this.ddlLx.SelectedValue+"')");
                     if (jg > 0)
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('新增图片成功！');window.location.href='admin_web_img.aspx';", true);
                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('新增图片失败！');window.location.href='admin_web_img.aspx';", true);
                     }
               

   
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
            }
        }

    }
}
