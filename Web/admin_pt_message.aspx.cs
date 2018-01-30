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
    public partial class admin_pt_message : Manager
    {
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string pageName = "";
        ClassBLL bll = new ClassBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "2";
                main_menu.menu2 = "2-5";

                try
                {
                    if (RolePermissions("2005") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=5';</script>");
                    }

                    string m = Request.QueryString["m"];
                    string id = Request.QueryString["id"];
                    if (m == "del" && id != "")
                    {
                        Dele(id);
                    }
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
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
                string where = " ";

                if (this.txtCx.Text.Trim() != "")
                {
                    where += " and (title like '%" + this.txtCx.Text.Trim() + "%' or memo  like '%" + this.txtCx.Text.Trim() + "%') ";
                }
                DataSet ds = bll.getDataSet("select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDRank from t_message where 1=1 " + where + "  ) as IDWithRowNumber where IDRank>=(" + currentPage.ToString() + "-1)*" + this.ddlPage.SelectedValue + "+1 and IDRank<=" + currentPage.ToString() + "*" + this.ddlPage.SelectedValue + "");

                DataTable tb = ds.Tables[0];
                if (tb.Rows.Count < 1)
                {
                    tb.Clear();
                    this.divWu.Attributes.Add("style", "display:block");
                    lblZs.Text = "0";
                }
                else
                {
                    this.divWu.Attributes.Add("style", "display:none");
                    int totalCount = Convert.ToInt32(bll.getDataSet("select count(*) as num from t_message where 1=1 " + where + "").Tables[0].Rows[0]["num"]);
                    lblZs.Text = totalCount.ToString();

                    int pageCount = totalCount / Convert.ToInt32(this.ddlPage.SelectedValue) + (totalCount % Convert.ToInt32(this.ddlPage.SelectedValue) == 0 ? 0 : 1);//分页总数
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
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
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

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rptDetail.Items.Count; i++)
                {
                    CheckBox chkSelected = (CheckBox)rptDetail.Items[i].FindControl("cbxId");
                    Label chkSelected1 = (Label)rptDetail.Items[i].FindControl("lblId");
                    if (chkSelected.Checked == true)
                    {
                        Dele(chkSelected1.Text);
                    }
                }
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=5");
            }
            hidCurrentPage.Value = "1";
            BindingData();
        }

        public void Dele(string id)
        {

            bll.Execute("delete from t_message where id='" + id + "'"); 
        }

    }
}
