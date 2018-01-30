using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Data;

namespace ZDEnterprise.Web
{
    public partial class admin_type_edit :
       Manager
    {

        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "4";
                main_menu.menu2 = "4-5";

                try
                {
                    if (RolePermissions("4005") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                    }





                    string id = Request.QueryString["id"];

                    if (!string.IsNullOrEmpty(id))
                    {
                        
                        DataSet ds2 = bll.getDataSet("select * from facility_type where id=" + id + " ");
                        DataTable tb2 = ds2.Tables[0];
                        if (tb2.Rows.Count > 0)
                        {
                            this.txtdiscount.Text = tb2.Rows[0]["discount"].ToString();
                            this.txtprice.Text = tb2.Rows[0]["price"].ToString();
                            this.txttime.Text = tb2.Rows[0]["time"].ToString();
                            this.txttyoe.Text = tb2.Rows[0]["tyoe"].ToString();
                        }

                    }



                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
                }

            }
        }





        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {

                    System.Model.facility_type fs = _bll.ftbll.GetModel(Utility.Helper.gerInt(id));

                    if (fs != null)
                    {



                        fs.discount = Utility.Helper.gerDecimal(this.txtdiscount.Text);
                        fs.price = Utility.Helper.gerDecimal(this.txtprice.Text);
                        fs.time = Utility.Helper.gerInt(this.txttime.Text);
                        fs.tyoe = this.txttyoe.Text;





                        if (_bll.ftbll.Update(fs))
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑成功！');window.location.href='admin_type.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败！');window.location.href='admin_type.aspx';", true);
                        }
                    }
                }
                else
                {
                    System.Model.facility_type fs = new System.Model.facility_type();

                    fs.discount = Utility.Helper.gerDecimal(this.txtdiscount.Text);
                    fs.price = Utility.Helper.gerDecimal(this.txtprice.Text);
                    fs.time = Utility.Helper.gerInt(this.txttime.Text);
                    fs.tyoe = this.txttyoe.Text;
                    fs.pudate = System.DateTime.Now;
                    if (_bll.ftbll.Add(fs) > 0)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加成功！');window.location.href='admin_type.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加失败！');window.location.href='admin_type.aspx';", true);
                    }
                }

            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
            }
        }


    }
}