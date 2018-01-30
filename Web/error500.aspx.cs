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
    public partial class error500 : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = Request.QueryString["menu1"];
                main_menu.menu2 = Request.QueryString["menu1"] + "-" + Request.QueryString["menu2"]; 
            }
        }
 

    }
}
