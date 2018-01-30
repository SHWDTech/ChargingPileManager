using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using BLL;

namespace ZDEnterprise.Web
{
    public partial class admin_stipple_edit : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "4";
                main_menu.menu2 = "4-2";

                try
                {
                    if (RolePermissions("4002") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                    }

                    string where = " 1 = 1  ";

                    DataSet ds = bll.getDataSet("select * from t_city1  where  " + where + " order by id asc ");
                    DataTable tb = ds.Tables[0];
                    if (tb.Rows.Count > 0)
                    {
                        city1.DataSource = tb;
                        city1.DataTextField = "province";
                        city1.DataValueField = "provinceID";

                        city1.DataBind();
                    }
                    this.city1.Items.Insert(0, new ListItem("--请选择省--", ""));


                    string id = Request.QueryString["id"];

                    if (!string.IsNullOrEmpty(id))
                    {




                        DataSet ds2 = bll.getDataSet("select * from facility_stipple where id=" + id + " ");
                        DataTable tb2 = ds2.Tables[0];
                        if (tb2.Rows.Count > 0)
                        {

                            city1.SelectedValue = Utility.Helper.gerString(tb2.Rows[0]["city1"]);
                            if (!string.IsNullOrEmpty(this.city1.SelectedValue))
                            {



                                DataSet ds3 = bll.getDataSet("select * from t_city2 where father=" + this.city1.SelectedValue + " order by id asc ");
                                DataTable tb3 = ds3.Tables[0];
                                if (tb3.Rows.Count > 0)
                                {
                                    city2.DataSource = tb3;
                                    city2.DataTextField = "city";
                                    city2.DataValueField = "cityID";
                                    city2.DataBind();
                                }
                                this.city2.Items.Insert(0, new ListItem("--请选择市--", ""));
                            }
                            city2.SelectedValue = Utility.Helper.gerString(tb2.Rows[0]["city2"]);

                            if (!string.IsNullOrEmpty(this.city2.SelectedValue))
                            {
                                DataSet ds4 = bll.getDataSet("select * from t_city3 where father=" + this.city2.SelectedValue + " order by id asc ");
                                DataTable tb4 = ds4.Tables[0];
                                if (tb4.Rows.Count > 0)
                                {
                                    city3.DataSource = tb4;
                                    city3.DataTextField = "area";
                                    city3.DataValueField = "areaID";
                                    city3.DataBind();
                                }
                                this.city3.Items.Insert(0, new ListItem("--请选择区/县--", ""));
                            }
                            city3.SelectedValue = Utility.Helper.gerString(tb2.Rows[0]["city3"]);

                            this.txtname.Text = tb2.Rows[0]["name"].ToString();
                            this.txtlatitude.Text = tb2.Rows[0]["latitude"].ToString();
                            this.txtlongitude.Text = tb2.Rows[0]["longitude"].ToString();
                            this.ddlstatuses.SelectedValue = tb2.Rows[0]["statuses"].ToString();
                            this.txtreferral.Text = tb2.Rows[0]["referral"].ToString();




                            string logo = tb2.Rows[0]["img"].ToString();
                            hidImg.Value = logo;
                            this.imgLogo.ImageUrl = VirturlPath + logo;
                        }

                    }



                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
                }

            }
        }


        protected void city1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.city1.SelectedValue))
            {

                string where = " 1=1";

                DataSet ds2 = bll.getDataSet("select * from t_city2 where " + where + " and father=" + this.city1.SelectedValue + " order by id asc ");
                DataTable tb2 = ds2.Tables[0];
                if (tb2.Rows.Count > 0)
                {
                    city2.DataSource = tb2;
                    city2.DataTextField = "city";
                    city2.DataValueField = "cityID";
                    city2.DataBind();
                }
                this.city2.Items.Insert(0, new ListItem("--请选择市--", ""));
            }
        }

        protected void city2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.city2.SelectedValue))
            {

                string where = " 1=1";

                DataSet ds3 = bll.getDataSet("select * from t_city3 where " + where + " and father=" + this.city2.SelectedValue + " order by id asc ");
                DataTable tb3 = ds3.Tables[0];
                if (tb3.Rows.Count > 0)
                {
                    city3.DataSource = tb3;
                    city3.DataTextField = "area";
                    city3.DataValueField = "areaID";
                    city3.DataBind();
                }
                this.city3.Items.Insert(0, new ListItem("--请选择区/县--", ""));
            }
        }

        protected void city3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {

                string imgUrl = "";
                HttpPostedFile hp = fileLogo.PostedFile;
                if (hp.FileName.ToString() != "")
                {
                    string hz = hp.FileName.ToString().Substring(hp.FileName.ToString().LastIndexOf(".") + 1);
                    if (hz == "jpg" || hz == "png")
                    {
                        string Filename1 = Guid.NewGuid().ToString() + "." + hz;
                        String path = Server.MapPath("Upload/stipple/");
                        hp.SaveAs(Path.Combine(path, Filename1));
                        imgUrl = "/Upload/stipple/" + Filename1;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('请选择jpg或png格式的图片');", true);
                        return;
                    }
                }
                else
                {
                    imgUrl = hidImg.Value;
                }



                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {

                    System.Model.facility_stipple fs = _bll.fsbll.GetModel(Utility.Helper.gerInt(id));

                    if (fs != null)
                    {

                        fs.img = imgUrl;
                        fs.city1 = this.city1.SelectedValue;
                        fs.city2 = this.city2.SelectedValue;
                        fs.city3 = this.city3.SelectedValue;
                        fs.statuses = Utility.Helper.gerInt(this.ddlstatuses.SelectedValue);
                        fs.name = this.txtname.Text;
                        fs.latitude = Utility.Helper.gerDecimal(this.txtlatitude.Text);
                        fs.longitude = Utility.Helper.gerDecimal(this.txtlongitude.Text);
                        fs.referral = this.txtreferral.Text;




                        if (_bll.fsbll.Update(fs))
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑成功！');window.location.href='admin_stipple.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败！');window.location.href='admin_stipple.aspx';", true);
                        }
                    }
                }
                else
                {
                    System.Model.facility_stipple fs = new System.Model.facility_stipple();

                    fs.img = imgUrl;
                    fs.city1 = this.city1.SelectedValue;
                    fs.city2 = this.city2.SelectedValue;
                    fs.city3 = this.city3.SelectedValue;
                    fs.statuses = Utility.Helper.gerInt(this.ddlstatuses.SelectedValue);
                    fs.name = this.txtname.Text;
                    fs.latitude = Utility.Helper.gerDecimal(this.txtlatitude.Text);
                    fs.longitude = Utility.Helper.gerDecimal(this.txtlongitude.Text);
                    fs.referral = this.txtreferral.Text;
                    fs.no = "";
                    fs.isdel = 0;
                    fs.pudate = System.DateTime.Now;
                    if (_bll.fsbll.Add(fs) > 0)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加成功！');window.location.href='admin_stipple.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加失败！');window.location.href='admin_stipple.aspx';", true);
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