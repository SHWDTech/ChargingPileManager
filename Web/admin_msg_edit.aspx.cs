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
    public partial class admin_msg_edit : Manager
    {


        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "2";
                main_menu.menu2 = "2-4";

                try
                {
                    if (RolePermissions("2004") == false)
                    {
                        Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=1';</script>");
                    }

                    //this.images.Src = Utility.Helper.getImgUrl("/img/moremg.jpg");
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        DataSet ds2 = bll.getDataSet("select * from t_msg where id=" + Request.QueryString["id"]);
                        DataTable tb2 = ds2.Tables[0];
                        if (tb2.Rows.Count > 0)
                        {
                            this.fckContent.Text = Server.HtmlDecode(tb2.Rows[0]["memo"].ToString());
                            this.txtTitle.Text = tb2.Rows[0]["title"].ToString();
                            this.images.Src = Utility.Helper.getImgUrl(tb2.Rows[0]["img"].ToString());
                            this.hidImgName.Value = tb2.Rows[0]["img"].ToString();
                        }
                    }




                }
                catch
                {
                    Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=1");
                }
            }
        }

        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {

                string title = this.txtTitle.Text;
                string imgs = this.hidImgName.Value;


                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    string text = Server.HtmlEncode(this.fckContent.Text.Trim());
                    int jg = bll.Execute("update t_msg set title='" + title + "',img='" + imgs + "', memo='" + text + "'  where id=" + Request.QueryString["id"]);
                    if (jg > 0)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑内容成功！');window.location.href='admin_msg.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑内容失败！');window.location.href='admin_msg.aspx';", true);
                    }
                }
                else
                {
                    string text = Server.HtmlEncode(this.fckContent.Text.Trim());
                    int jg = bll.Execute("insert into t_msg  (title,memo,img,pudate)values ('" + title + "','" + text + "','" + imgs + "','" + System.DateTime.Now + "')");
                    if (jg > 0)
                    {

                        List<string> anzhuolist = new List<string>();
                        List<string> ioslist = new List<string>();
                        List<System.Model.apush_token> pushlist = _bll.atbll.GetModelList("1=1");

                        //安卓
                        if (pushlist.Count > 0)
                        {
                            for (int i = 0; i < pushlist.Count; i++)
                            {
                                System.Model.apush_token at = pushlist[i];

                                if (at.device == "android")
                                {
                                    anzhuolist.Add(at.token);
                                }
                                else if (at.device == "ios")
                                {
                                    ioslist.Add(at.token);
                                }

                            }
                        }

                        _bll.InitGeTui();

                        if (anzhuolist.Count > 0)
                        {
                            //安卓
                            GeTuiHelper.Push.SendNotiMsgToList(anzhuolist, "公告通知", this.txtTitle.Text, false);
                        }

                        if (ioslist.Count > 0)
                        {
                            //IOS
                            GeTuiHelper.Push.SendNotiMsgToList(ioslist, "公告通知", this.txtTitle.Text, true);
                        }
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加内容成功！');window.location.href='admin_msg.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('添加内容失败！');window.location.href='admin_msg.aspx';", true);
                    }
                }
            }
            catch
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/error500.aspx?menu1=2&menu2=1");
            }
        }



    }
}