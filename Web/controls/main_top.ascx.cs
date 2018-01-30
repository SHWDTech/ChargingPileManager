using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BLL;

namespace ZDEnterprise.Web.controls
{
    public partial class main_top : System.Web.UI.UserControl
    {
        public string name = "";
        public string logo = "";
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        public string orderId = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable tb = Session["users"] as DataTable;
            name = tb.Rows[0]["name"].ToString();
            if (tb.Rows[0]["imgUrl"].ToString() != "")
            {
                logo = VirturlPath+tb.Rows[0]["imgUrl"].ToString();
            }
            else
            {
                logo = VirturlPath + "/Upload/logo/zw.png";
            }
            ClassBLL bll = new ClassBLL();

            
        }
    }
}