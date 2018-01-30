using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZDEnterprise.Web.json.faq
{
    public partial class faqdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //常见问题id
                string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";

                System.Model.System_FAQ faq = _bll.sfbll.GetModel(Utility.Helper.gerInt(id));

                if (faq != null)
                {
                    titles.Text = faq.issue;
                    issue.InnerHtml = "问: " + faq.issue;
                    answer.InnerHtml = "答: " + HttpUtility.HtmlDecode(faq.answer);
                }
            }
        }
    }
}