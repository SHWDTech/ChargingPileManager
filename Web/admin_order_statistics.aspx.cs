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
    public partial class admin_order_statistics : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string pageName = "";
        ClassBLL bll = new ClassBLL();
        public string tj = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "7";
                main_menu.menu2 = "7-2";

                try
                {
                    if (RolePermissions("7002") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=5';</script>");
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=5");
                }

                hidSort.Value = "pudate";
                hidOrder.Value = "desc";
                hidCurrentPage.Value = "1";
                BindingData();
            }
        }


        private void BindingData()
        {
            try
            {
                string sort = hidSort.Value;
                string order = hidOrder.Value;
                int currentPage = Convert.ToInt32(hidCurrentPage.Value);
                string where = "  ";

                if (this.txtCx.Text.Trim() != "")
                {
                    where += " and (serialNumber like '%" + this.txtCx.Text.Trim() + "%' or  sname like '%" + this.txtCx.Text.Trim() + "%' or phone like '%" + this.txtCx.Text.Trim() + "%' ) ";
                }

                if (this.ddlZt.SelectedValue != "")
                {
                    where += " and paystatus='" + this.ddlZt.SelectedValue + "' ";
                }
                if (this.TextBox1.Text.Trim() != "")
                {
                    where += " and pudate>='" + this.TextBox1.Text.Trim() + "' ";
                }
                if (this.TextBox2.Text.Trim() != "")
                {
                    where += " and pudate<='" + this.TextBox2.Text.Trim() + "' ";
                }

                string m1 = "0.00"; string m2 = "0.00";

                string sql = "select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDRank from V_order_details where 1=1 " + where + "  ) as IDWithRowNumber where IDRank>=(" + currentPage.ToString() + "-1)*" + this.ddlPage.SelectedValue + "+1 and IDRank<=" + currentPage.ToString() + "*" + this.ddlPage.SelectedValue + "";
                DataSet ds = bll.getDataSet(sql);

                DataTable dt = ds.Tables[0];

                decimal de = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    de += Utility.Helper.gerDecimal(dr["price"]);
                }

                tj = "订单总额：" + de.ToString("0.00") + "元&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

                DataTable tb = ds.Tables[0];
                if (tb.Rows.Count < 1)
                {
                    tb.Clear();
                    this.divWu.Attributes.Add("style", "display:block");
                    lblZs.Text = "0";
                    this.Label2.Text = " 条件下 0 单";
                }
                else
                {
                    this.divWu.Attributes.Add("style", "display:none");
                    int totalCount = Convert.ToInt32(bll.getDataSet("select count(*) as num from V_order_details where 1=1 " + where + "").Tables[0].Rows[0]["num"]);
                    lblZs.Text = totalCount.ToString();
                    Label2.Text = "条件下 " + totalCount.ToString() + " 单";
                    int pageCount = totalCount / Convert.ToInt32(this.ddlPage.SelectedValue) + (totalCount % Convert.ToInt32(this.ddlPage.SelectedValue) == 0 ? 0 : 1);//分页总数
                    this.Label1.Text = "共 " + totalCount + " 单";
                    int s = 1; int x = 1;
                    if (pageCount > 0)
                    {
                        if (currentPage > 1)
                            s = currentPage - 1;

                        if (currentPage < pageCount)
                            x = currentPage + 1;
                        else
                            x = currentPage;
                    }


                    pageName = "<span>总共" + totalCount.ToString() + "个记录</span>";
                    pageName += "<a href=\"javascript:page(1)\">首页</a>";
                    pageName += "<a href=\"" + (currentPage == 1 ? "#" : "javascript:page(" + s.ToString() + ")") + "\">上一页</a>";
                    pageName += "<a href=\"" + (currentPage == pageCount ? "#" : "javascript:page(" + x.ToString() + ")") + "\">下一页</a>";
                    pageName += "<a href=\"javascript:page(" + pageCount + ")\">末页</a>";
                    pageName += "<select onchange=\"page(this.value)\">";
                    for (int i = 1; i <= pageCount; i++)
                    {
                        pageName += "<option " + (i == currentPage ? "selected=\"selected\"" : "") + " value=\"" + i.ToString() + "\" >" + i.ToString() + "</option>";
                    }

                    pageName += "</select>";
                }
                this.rptDetail.DataSource = tb;
                this.rptDetail.DataBind();
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=5");
            }

        }

        protected void btnCx_Click(object sender, EventArgs e)
        {

            hidCurrentPage.Value = "1";
            BindingData();
        }
        protected void btnPage_Click(object sender, EventArgs e)
        {
            BindingData();
        }
        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidCurrentPage.Value = "1";
            BindingData();
        }



        public string getpaystatic(string status)
        {
            string paystatic = "";

            switch (status)
            {

                case "1":
                    paystatic = "<span class='payname1'>未支付</span>";
                    break;
                case "2":
                    paystatic = "<span class='payname2'>已支付</span>";
                    break;
                case "3":
                    paystatic = "<span class='payname3'>已开始充电</span>";
                    break;
                case "4":
                    paystatic = "<span class='payname4'>充电完成</span>";
                    break;
                default:
                    paystatic = "<span class='payname10'>未知</span>";
                    break;
            }

            return paystatic;
        }
    }
}