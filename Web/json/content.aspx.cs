using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace ZDEnterprise.Web.json
{
    public partial class content : System.Web.UI.Page
    {

        //系统文案
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["id"];
                DataSet ds2 = _bll.pbll.getDataSet("select * from t_content where id=" + id + "");
                DataTable tb2 = ds2.Tables[0];
                if (!(tb2 == null || tb2.Rows.Count < 1))
                {
                    titleString.Text = tb2.Rows[0]["title"].ToString();
                    contenString.InnerHtml = Server.HtmlDecode(tb2.Rows[0]["memo"].ToString());
                }
            }
        }
    }
}