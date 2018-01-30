using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Configuration;

namespace ZDEnterprise.Web
{
    public partial class role_qx : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
 
        ClassBLL bll = new ClassBLL();

        public string data = "";
        public string roleName = "";

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
                    RoleName();

                    DataSet ds2 = bll.getDataSet("select * from t_permissions where classificationId=0 order by permissionsId asc");
                    DataTable tb2 = ds2.Tables[0];
                    if (tb2.Rows.Count > 0)
                    {
                        for (int i = 0; i < tb2.Rows.Count; i++)
                        {
                            data += "<div class=\"col-sm-6\">";
                            data += "<div class=\"widget-box\">";
                            data += "<div class=\"widget-header header-color-blue2\">";
                            data += "<h4 class=\"lighter smaller\">" + tb2.Rows[i]["name"].ToString() + "</h4>";
                            data += "</div>";
                            data += "<div class=\"widget-body\">";
                            data += "<div class=\"widget-main padding-8\">";
                            data += "<div class=\"tree tree-selectable\">";
                            data += "<div style=\"display: block;\">";
                            data += "<div class=\"tree-folder-content\" style=\"display: block;\">";

                            DataSet ds = bll.getDataSet("select tb1.*,(case when tb2.roleId is null then 0 else 1 end) as xz from (select * from t_permissions where classificationId=" + tb2.Rows[i]["permissionsId"].ToString() + ") as tb1 left join (select * from t_role_permissions where roleId="+Request.QueryString["id"]+") as tb2  on tb1.permissionsId=tb2.permissionsId order by tb1.permissionsId asc");
                            DataTable tb = ds.Tables[0];
                            if (tb.Rows.Count > 0)
                            {
                                for (int j = 0; j < tb.Rows.Count; j++)
                                {
                                    data += "<div id=\"s_" + tb2.Rows[i]["permissionsId"].ToString() + "_" + tb.Rows[j]["permissionsId"].ToString() + "\" class=\"tree-item " + (tb.Rows[j]["xz"].ToString() == "1" ? "tree-selected" : "") + "\" style=\"display: block;\" onclick=\"cbx('s_" + tb2.Rows[i]["permissionsId"].ToString() + "_" + tb.Rows[j]["permissionsId"].ToString() + "'," + tb.Rows[j]["permissionsId"].ToString() + "," + Request.QueryString["id"] + ")\">";
                                    data += "    <i id=\"s_" + tb2.Rows[i]["permissionsId"].ToString() + "_" + tb.Rows[j]["permissionsId"].ToString() + "_i\" class=\"icon-" + (tb.Rows[j]["xz"].ToString() == "1" ? "ok" : "remove") + "\"></i>";
                                    data += "    <div class=\"tree-item-name\">" + tb.Rows[j]["name"].ToString() + "</div>";
                                    data += "</div>";
                                }
                            }
 
                            data += "</div>";
                            data += "</div>";
                            data += "</div>";
                            data += "</div>";
                            data += "</div>";
                            data += "</div>";
                            data += "</div>";
                 
                        }
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=1");
                }
            }
        }


        public void RoleName()
        {
            string name = "";
            try
            {
                DataSet ds = bll.getDataSet("select * from t_role where roleId='" + Request.QueryString["id"] + "' ");
                DataTable tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    name = tb.Rows[0]["name"].ToString();
                }
                roleName = name;
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=2");
            }
        }

    }
}
