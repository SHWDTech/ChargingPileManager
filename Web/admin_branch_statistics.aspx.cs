using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BLL;
using System.Data;

namespace ZDEnterprise.Web
{
    public partial class admin_branch_statistics : Manager
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
                main_menu.menu2 = "3";

                try
                {
                    if (RolePermissions("7003") == false)
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


                string sql = "select top 100 sname ,COUNT(1) sum from V_order_details  where 1=1 " + where + "  group by sname ";
                DataSet ds = bll.getDataSet(sql);

                DataTable dt = ds.Tables[0];




                DataTable tb = ds.Tables[0];
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




    }
}