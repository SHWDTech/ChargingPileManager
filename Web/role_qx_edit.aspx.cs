using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;

namespace ZDEnterprise.Web
{
    public partial class role_qx_edit : System.Web.UI.Page
    {
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string m = Request.QueryString["m"];
                    string roleId = Request.QueryString["roleId"];
                    string permissionsId = Request.QueryString["permissionsId"];
                    if (m == "1")
                    {
                        Ins(roleId, permissionsId);
                    }
                    else
                    {
                        Del(roleId, permissionsId);
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=9&menu2=1");
                }
            }
        }


        private void Del(string roleId, string permissionsId)
        {
            string sta = "";
            try
            {
                int jg = bll.Execute("delete t_role_permissions where roleId='" + roleId + "' and permissionsId='" + permissionsId + "' ");
                if (jg > 0)
                {
                    sta = "1";
                }
                else
                {
                    sta = "2";
                }
            }
            catch
            {
                sta = "2";
            }
            Response.Clear();
            Response.ContentType = "application/json";
            Response.Write("{\"sta\":" + sta + "}");
            Response.End();
        }

        private void Ins(string roleId, string permissionsId)
        {
            string sta = "";
            try
            {
                int jg = bll.Execute("insert into t_role_permissions(roleId,permissionsId) values('" + roleId + "','" + permissionsId + "') ");
                if (jg > 0)
                {
                    sta = "1";
                }
                else
                {
                    sta = "2";
                }
            }
            catch
            {
                sta = "2";
            }
            Response.Clear();
            Response.ContentType = "application/json";
            Response.Write("{\"sta\":" + sta + "}");
            Response.End();
        }

    }
}
