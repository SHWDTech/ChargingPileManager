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
    public partial class admin_port_edit : Manager
    {


        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "4";
                main_menu.menu2 = "4-4";

                try
                {
                    if (RolePermissions("4003") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                    }

                    string where = " ";

                    DataSet ds = bll.getDataSet(" select * from facility_stipple  where  1=1 order by id asc ");
                    DataTable tb = ds.Tables[0];
                    if (tb.Rows.Count > 0)
                    {
                        stipple.DataSource = tb;
                        stipple.DataTextField = "name";
                        stipple.DataValueField = "id";

                        stipple.DataBind();
                    }
                    this.stipple.Items.Insert(0, new ListItem("--请选择网点--", ""));



                    string id = Request.QueryString["id"];

                    if (!string.IsNullOrEmpty(id))
                    {
                        //nohezi.Style["display"] = "none";

                        DataSet ds2 = bll.getDataSet("select * from facility_port where id=" + id + " ");
                        DataTable tb2 = ds2.Tables[0];
                        if (tb2.Rows.Count > 0)
                        {

                            this.stipple.SelectedValue = Utility.Helper.gerString(tb2.Rows[0]["sid"]);


                            if (!string.IsNullOrEmpty(this.stipple.SelectedValue))
                            {

                                this.facility.Items.Clear();

                                DataSet ds3 = bll.getDataSet("select * from facility ");
                                DataTable tb3 = ds3.Tables[0];
                                if (tb3.Rows.Count > 0)
                                {
                                    facility.DataSource = tb3;
                                    facility.DataTextField = "no";
                                    facility.DataValueField = "id";
                                    facility.DataBind();
                                }
                                facility.Items.Insert(0, new ListItem("--请选择设备--", ""));
                                this.facility.SelectedValue = tb2.Rows[0]["fid"].ToString();
                            }


                            this.ddlstatuses.SelectedValue = tb2.Rows[0]["statuses"].ToString();

                            this.imgqrimg.Src = Utility.Helper.gerString(tb2.Rows[0]["qrimg"]);

                            this.txtno.Text = tb2.Rows[0]["identitycode"].ToString();
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
                    System.Model.facility_port fs = _bll.fpbll.GetModel(Utility.Helper.gerInt(id));

                    if (fs != null)
                    {
                        fs.statuses = Utility.Helper.gerInt(this.ddlstatuses.SelectedValue);
                        fs.fid = Utility.Helper.gerInt(this.facility.SelectedValue);
                        fs.sid = Utility.Helper.gerInt(this.stipple.SelectedValue);
                        
                        //string toid = fs.toid;
                        //fs.qrimg = Utility.QrImg.CreateCode_Simple("{'portid':'" + toid + "'}", Server.MapPath("/Upload/qr/"));

                        if (fs.identitycode == this.txtno.Text)
                        {
                            fs.identitycode = this.txtno.Text;
                            if (_bll.fpbll.Update(fs))
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑成功！');window.location.href='admin_port.aspx';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败！');window.location.href='admin_port.aspx';", true);
                            }
                        }
                        else
                        {
                            DataTable tab = bll.getDataSet(" select identitycode from facility_port where identitycode ='" + this.txtno.Text + "' ").Tables[0];
                            if (tab.Rows.Count == 0)
                            {
                                fs.identitycode = this.txtno.Text;
                                if (_bll.fpbll.Update(fs))
                                {
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑成功！');window.location.href='admin_port.aspx';", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败！');window.location.href='admin_port.aspx';", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败,充电枪标识已存在！');window.location.href='admin_port.aspx';", true);
                            }
                        }
                    }
                }
                else
                {

                    string strwheres = "  identitycode='" + this.txtno.Text + "' ";
                    List<System.Model.facility_port> fplist = _bll.fpbll.GetModelList(strwheres);
                    if (fplist.Count == 0)
                    {



                        string toid = System.Guid.NewGuid().ToString();
                        System.Model.facility_port fs = new System.Model.facility_port();
                        fs.statuses = Utility.Helper.gerInt(this.ddlstatuses.SelectedValue);
                        fs.fid = Utility.Helper.gerInt(this.facility.SelectedValue);
                        int nos = _bll.fpbll.GetMaxId();
                        fs.no = (100000000 + 1 + nos).ToString();
                        fs.toid = toid;
                        fs.sid = Utility.Helper.gerInt(this.stipple.SelectedValue);
                        fs.qrimg = Utility.QrImg.CreateCode_Simple("{'portid':'" + toid + "'}", Server.MapPath("/Upload/qr/"));
                        fs.identitycode = this.txtno.Text;
                        fs.isdel = 0;
                        fs.pudate = System.DateTime.Now;
                        if (_bll.fpbll.Add(fs) > 0)
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加成功！');window.location.href='admin_port.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加失败！');window.location.href='admin_port.aspx';", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('充电枪标识已存在！');window.location.href='admin_port.aspx';", true);
                    }
                }
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=4");
            }
        }

        protected void city1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.stipple.SelectedValue))
            {

                string where = " 1=1";

                DataSet ds3 = bll.getDataSet("select * from facility where " + where + " and fid=" + this.stipple.SelectedValue + " order by id asc ");
                DataTable tb3 = ds3.Tables[0];
                if (tb3.Rows.Count > 0)
                {
                    facility.DataSource = tb3;
                    facility.DataTextField = "no";
                    facility.DataValueField = "id";
                    facility.DataBind();
                }
                this.facility.Items.Insert(0, new ListItem("--请选择设备--", ""));
            }
        }

        protected void city2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}