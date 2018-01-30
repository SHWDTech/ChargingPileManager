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
    public partial class admin_facility_edit : Manager
    {

        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "4";
                main_menu.menu2 = "4-3";

                try
                {
                    if (RolePermissions("4003") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                    }

                    string where = " 1 = 1  ";

                    DataSet ds = bll.getDataSet("select * from facility_stipple  where  " + where + " order by id asc ");
                    DataTable tb = ds.Tables[0];
                    if (tb.Rows.Count > 0)
                    {

                        this.ddlfid.DataSource = tb;
                        ddlfid.DataTextField = "name";
                        ddlfid.DataValueField = "id";
                        ddlfid.DataBind();
                    }
                    this.ddlfid.Items.Insert(0, new ListItem("--请选择网点--", ""));


                    DataSet dstype = bll.getDataSet("select * from facility_type  where  " + where + " order by id asc ");
                    DataTable tbtype = dstype.Tables[0];
                    if (tbtype.Rows.Count > 0)
                    {

                        this.ddltype.DataSource = tbtype;
                        ddltype.DataTextField = "tyoe";
                        ddltype.DataValueField = "id";
                        ddltype.DataBind();
                    }
                    this.ddltype.Items.Insert(0, new ListItem("--请选择类型--", ""));


                    string id = Request.QueryString["id"];

                    if (!string.IsNullOrEmpty(id))
                    {
                        //nohezi.Style["display"] = "none";

                        DataSet ds2 = bll.getDataSet("select * from facility where id=" + id + " ");
                        DataTable tb2 = ds2.Tables[0];
                        if (tb2.Rows.Count > 0)
                        {
                            this.ddlstatuses.SelectedValue = tb2.Rows[0]["statuses"].ToString();
                            this.ddlfid.Text = tb2.Rows[0]["fid"].ToString();
                            this.ddltype.SelectedValue = tb2.Rows[0]["types"].ToString();

                            this.txtno.Enabled = false;
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
                    System.Model.facility fs = _bll.fbll.GetModel(Utility.Helper.gerInt(id));
                    if (fs != null)
                    {
                        fs.statuses = Utility.Helper.gerInt(this.ddlstatuses.SelectedValue);
                        fs.fid = Utility.Helper.gerInt(this.ddlfid.SelectedValue);
                        fs.types = Utility.Helper.gerInt(this.ddltype.SelectedValue);
                        if (fs.identitycode == this.txtno.Text)
                        {
                            fs.identitycode = this.txtno.Text;
                            if (_bll.fbll.Update(fs))
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑成功！');window.location.href='admin_facility.aspx';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败！');window.location.href='admin_facility.aspx';", true);
                            }
                        }
                        else
                        {
                            DataTable tab = bll.getDataSet(" select identitycode from facility where identitycode ='" + this.txtno.Text + "' ").Tables[0];
                            if (tab.Rows.Count == 0)
                            {
                                fs.identitycode = this.txtno.Text;
                                if (_bll.fbll.Update(fs))
                                {
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑成功！');window.location.href='admin_facility.aspx';", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败！');window.location.href='admin_facility.aspx';", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑失败,充电桩标识已存在！');window.location.href='admin_facility.aspx';", true);
                            }
                        }
                    }
                }
                else
                {
                    string strwheres = "  identitycode='" + this.txtno.Text + "' ";

                    List<System.Model.facility> falist = _bll.fbll.GetModelList(strwheres);
                    if (falist.Count == 0)
                    {
                        System.Model.facility fs = new System.Model.facility();
                        fs.statuses = Utility.Helper.gerInt(this.ddlstatuses.SelectedValue);
                        fs.fid = Utility.Helper.gerInt(this.ddlfid.SelectedValue);
                        fs.types = Utility.Helper.gerInt(this.ddltype.SelectedValue);
                        int nos = _bll.fbll.GetMaxId();
                        fs.no = (100000000 + 1 + nos).ToString();

                        fs.isdel = 0;
                        fs.pudate = System.DateTime.Now;
                        fs.identitycode = this.txtno.Text;
                        if (_bll.fbll.Add(fs) > 0)
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加成功！');window.location.href='admin_facility.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加失败！');window.location.href='admin_facility.aspx';", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('充电桩标识已存在！');", true);
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