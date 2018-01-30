using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZDEnterprise.Web.json.message
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //常见问题id
                string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";

                System.Model.t_message faq = _bll.tmbll.GetModel(Utility.Helper.gerInt(id));

                if (faq != null)
                {
                    titles.Text = faq.title;
                    detailss.InnerHtml = faq.memo;
                }
            }
        }
    }
}