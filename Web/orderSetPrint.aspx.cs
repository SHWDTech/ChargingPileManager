using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;

namespace ZDEnterprise.Web
{
    public partial class orderSetPrint : System.Web.UI.Page
    {
        ClassBLL bll = new ClassBLL();
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        public string qsName = "";
        public string yf = "";
        public string hj = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                string orderId = Request.QueryString["id"];
                DataSet ds2 = bll.getDataSet("select * from  t_order where orderId='" + orderId + "' ");
                DataTable tb2 = ds2.Tables[0];
                if (tb2 != null && tb2.Rows.Count > 0)
                {
                    lblSj.InnerHtml = getSjName(tb2.Rows[0]["sjId"].ToString());
                    lblAdress.InnerHtml = tb2.Rows[0]["shName"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + tb2.Rows[0]["shPhone"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + tb2.Rows[0]["shAdress"].ToString();
                    lblOrderId.InnerHtml = tb2.Rows[0]["orderId"].ToString();
                    lblTime.InnerHtml = tb2.Rows[0]["pudate"].ToString();
                    lblLy.InnerHtml = tb2.Rows[0]["liuyan"].ToString();
                    yf = Convert.ToDouble(tb2.Rows[0]["yhMoney"]).ToString("0.00");
                    hj = Convert.ToDouble(tb2.Rows[0]["money"]).ToString("0.00");
                    string zffs = "";
                    if (tb2.Rows[0]["zffs"].ToString() == "1")
                    {
                        zffs = "钱包";
                    }
                    else if (tb2.Rows[0]["zffs"].ToString() == "2")
                    {
                        zffs = "支付宝";

                    }
                    else if (tb2.Rows[0]["zffs"].ToString() == "3")
                    {
                        zffs = "微信";

                    }
                    lblZffs.InnerHtml = zffs; 
                }
                DataSet ds3 = bll.getDataSet("select * from t_order_goods where orderId='" + orderId + "' ");
                this.rptDetail.DataSource = ds3.Tables[0];
                this.rptDetail.DataBind();

            }
        }

        public string getSjName(string id)
        {
            string name = "";
            try
            {
                DataSet ds = bll.getDataSet("select * from t_users where usersId='" + id + "' ");
                DataTable tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    name = tb.Rows[0]["name"].ToString();
                }

            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=5");
            }
            return name;
        }
        public string getZtName(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_ztd where id='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0]["name"].ToString();
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string getZtPhone(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_ztd where id='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0]["phone"].ToString();
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string getZtAdress(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_ztd where id='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = GetArea(ds.Tables[0].Rows[0]["areaID"].ToString()) + ds.Tables[0].Rows[0]["adress"].ToString();
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string GetProvince(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from hat_province where provinceID='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0]["province"].ToString();
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string GetCity(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from hat_city where cityID='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["city"].ToString() == "市辖区" || ds.Tables[0].Rows[0]["city"].ToString() == "县")
                        {
                            name = "";
                        }
                        else
                        {
                            name = ds.Tables[0].Rows[0]["city"].ToString();
                        }
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string GetArea(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from hat_area where areaID='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0]["area"].ToString();
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string GetTitle(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_goods where goodsId='" + id + "' ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0]["title"].ToString() + "(" + ds.Tables[0].Rows[0]["ggName"].ToString() + ")";
                    }
                }
            }
            catch
            {

            }
            return name;
        }

        public string GetXhName(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_goods_xh where id=" + id + " ");
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0]["name"].ToString();
                    }
                }
            }
            catch
            {

            }
            return name;
        }
    }
}
