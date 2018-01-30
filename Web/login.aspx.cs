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
    public partial class login : System.Web.UI.Page
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
                    string code = Request.QueryString["code"];
                    string pwd = Request.QueryString["pwd"];

                    if (m == "1")
                    {
                        LoginMin(code, pwd);
                    }
                }
                catch
                {

                }
            }
        }

        private void LoginMin(string code, string pwd)
        {
            string sta = "";
            string logo = "";
            try
            {
                DataSet ds = bll.getDataSet("select * from t_users where code='" + code + "' and pwd = '" + pwd + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["users"] = ds.Tables[0];
                    logo = ds.Tables[0].Rows[0]["imgUrl"].ToString();
                    DataSet ds2 = bll.getDataSet("select * from t_role_permissions where roleId='" + ds.Tables[0].Rows[0]["roleId"].ToString() + "' ");

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        Session["permissions"] = ds2.Tables[0];
                    }
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
            Response.Write("{\"sta\":" + sta + ",\"logo\":\"" + logo + "\"}");
            Response.End();
        }
    }
}
