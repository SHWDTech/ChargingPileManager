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
    public partial class admin_user_statistics : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        public string pageName = "";
        ClassBLL bll = new ClassBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "7";
                main_menu.menu2 = "7-1";

                try
                {
                    if (RolePermissions("7001") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=3&menu2=1';</script>");
                    }

                    //string m = Request.QueryString["m"];
                    //string id = Request.QueryString["id"];
                    //if (m == "del" && id != "")
                    //{
                    //    Dele(id);
                    //}
                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=3&menu2=1");
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


                if (this.TextBox1.Text.Trim() != "")
                {
                    where += " and pudate>='" + this.TextBox1.Text.Trim() + "' ";
                }
                if (this.TextBox2.Text.Trim() != "")
                {
                    where += " and pudate<='" + this.TextBox2.Text.Trim() + "' ";
                }

                if (this.txtCx.Text.Trim() != "")
                {
                    where += " and (name like '%" + this.txtCx.Text.Trim() + "%' or nicheng like '%" + this.txtCx.Text.Trim() + "%' or phone like '%" + this.txtCx.Text.Trim() + "%' or CONVERT(nvarchar,customId) in (select customId from t_custom_adress where zt='1' and (adress like '%" + this.txtCx.Text.Trim() + "%' or city1 in (select provinceID from t_city1 where province like '%" + this.txtCx.Text.Trim() + "%') or city2 in (select cityID from t_city2 where city like '%" + this.txtCx.Text.Trim() + "%') or city3 in (select areaID from t_city3 where area like '%" + this.txtCx.Text.Trim() + "%')))) ";
                }
                DataSet ds = bll.getDataSet("select * from (select *,Row_number() over(order by " + sort + " " + order + ") as IDRank from t_custom where 1=1 " + where + "  ) as IDWithRowNumber where IDRank>=(" + currentPage.ToString() + "-1)*" + this.ddlPage.SelectedValue + "+1 and IDRank<=" + currentPage.ToString() + "*" + this.ddlPage.SelectedValue + "");

                DataTable tb = ds.Tables[0];
                if (tb.Rows.Count < 1)
                {
                    tb.Clear();
                    this.divWu.Attributes.Add("style", "display:block");
                    lblZs.Text = "0";
                    this.Label2.Text = " 时间内新增 0 人";
                }
                else
                {

                    DateTime dts = System.DateTime.Now;
                    DataTable ds2 = bll.getDataSet("select COUNT(1) from t_custom where  pudate >'" + dts.AddDays(-1).ToString() + "' and  pudate <'" + dts.ToString() + "'").Tables[0];

                    DataTable ds3 = bll.getDataSet("select COUNT(1) from t_custom ").Tables[0];



                    this.divWu.Attributes.Add("style", "display:none");
                    int totalCount = Convert.ToInt32(bll.getDataSet("select count(*) as num from t_custom where 1=1 " + where + "").Tables[0].Rows[0]["num"]);
                    lblZs.Text = totalCount.ToString();
                    Label2.Text = " 时间内新增" + totalCount.ToString() + "人";
                    int pageCount = totalCount / Convert.ToInt32(this.ddlPage.SelectedValue) + (totalCount % Convert.ToInt32(this.ddlPage.SelectedValue) == 0 ? 0 : 1);//分页总数


                    this.Label1.Text = "用户共 " + ds3.Rows[0][0].ToString() + " 人,昨日新增 " + ds2.Rows[0][0].ToString() + " 人";

                    this.Label2.Text = " 时间内新增 " + totalCount + " 人";
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
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=3&menu2=1");
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
        public string getAdress(string customId)
        {
            string name = "";
            DataSet ds = bll.getDataSet("select * from t_custom_adress where customId='" + customId + "' and zt='1'");
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                name = getCity1(ds.Tables[0].Rows[0]["city1"].ToString()) + getCity2(ds.Tables[0].Rows[0]["city2"].ToString()) + getCity3(ds.Tables[0].Rows[0]["city3"].ToString()) + ds.Tables[0].Rows[0]["adress"].ToString();
            }
            return name;
        }
        public string getCity1(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_city1 where provinceID='" + id + "' ");
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

        public string getCity2(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_city2 where cityID='" + id + "' ");
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

        public string getCity3(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_city3 where areaID='" + id + "' ");
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
        //protected void btnDel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        for (int i = 0; i < rptDetail.Items.Count; i++)
        //        {
        //            CheckBox chkSelected = (CheckBox)rptDetail.Items[i].FindControl("cbxId");
        //            Label chkSelected1 = (Label)rptDetail.Items[i].FindControl("lblId");
        //            if (chkSelected.Checked == true)
        //            {
        //                Dele(chkSelected1.Text);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=3&menu2=1");
        //    }
        //    hidCurrentPage.Value = "1";
        //    BindingData();
        //}

        //public void Dele(string id)
        //{

        //    bll.Execute("delete from t_users where usersId='" + id + "'");
        //}



    }
}