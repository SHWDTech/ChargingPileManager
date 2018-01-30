using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZDEnterprise.Web.json.msg
{
    public partial class msgdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //常见问题id
                string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";

                System.Model.t_msg faq = _bll.tmgbll.GetModel(Utility.Helper.gerInt(id));

                if (faq != null)
                {
                    issueimg.Src = !string.IsNullOrEmpty(faq.img) ? Utility.Helper.getImgUrl(faq.img) : Utility.Helper.getImgUrl("/img/moremg.jpg");
                    titles.Text = faq.title;
                    answer.InnerHtml = HttpUtility.HtmlDecode(faq.memo);
                }
            }
        }
    }
}