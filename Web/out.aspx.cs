using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZDEnterprise.Web
{
    public partial class _out : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                Session.Abandon();
                Session.Clear();
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Remove("users");
                Session.Remove("permissions");
                Response.Redirect("login.aspx");
            }
        
        }
    }
}
