using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace ZDEnterprise.Web
{
    public partial class main : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "1";
                main_menu.menu2 = "1-1";
            }
        }
    }
}
