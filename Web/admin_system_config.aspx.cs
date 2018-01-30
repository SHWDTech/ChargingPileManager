using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BLL;
using System.Data;

namespace ZDEnterprise.Web
{
    public partial class admin_system_config : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "2";
                main_menu.menu2 = "2-3";

                if (RolePermissions("2003") == false)
                {
                    Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=5';</script>");
                }



                string strwhere = " 1=1 ";
                List<System.Model.System_Config> config = _bll.scbll.GetModelList(strwhere);

                if (config.Count > 0)
                {
                    List<System.Model.System_Config> c = (from cs in config
                                                          where cs.toid == "49970868-E839-4B5A-90EA-7CD8021B8E9D"
                                                          select cs).ToList();
                    if (c.Count > 0)
                    {
                        this.txtTel.Text = c[0].value;
                    }

                    List<System.Model.System_Config> c1 = (from cs in config
                                                           where cs.toid == "78AF3EF9-5676-4EFD-86EB-808BF05518CD"
                                                           select cs).ToList();
                    if (c1.Count > 0)
                    {
                        this.appImg.Src = c1[0].value;
                    }
                }


            }
        }
        
        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                int jg = bll.Execute("update System_Config set value='" + this.txtTel.Text.Trim() + "' where toid='49970868-E839-4B5A-90EA-7CD8021B8E9D'");
                if (jg > 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('修改成功！');window.location.href='admin_system_config.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('修改失败！');window.location.href='admin_system_config.aspx';", true);
                }
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
            }
        }



    }
}