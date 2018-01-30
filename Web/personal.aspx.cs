using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Data;
using System.IO;

namespace ZDEnterprise.Web
{
    public partial class personal : Manager
    {
        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "1";
                main_menu.menu2 = "1-1";

                try
                {
                    DataTable tb = Session["users"] as DataTable;
                    if (tb.Rows.Count > 0)
                    {
                        DataSet ds2 = bll.getDataSet("select * from t_users where usersId='" + tb.Rows[0]["usersId"].ToString() + "' ");
                        DataTable tb2 = ds2.Tables[0];
                        if (tb2.Rows.Count > 0)
                        {
                            this.txtName.Text = tb2.Rows[0]["name"].ToString();
                            this.txtCode.Text = tb2.Rows[0]["code"].ToString();
                            this.txtRole.Text = RoleName(tb2.Rows[0]["roleId"].ToString());
                            this.txtLx.Text = lxName(tb2.Rows[0]["lx"].ToString());
                            this.txtPhone.Text = tb2.Rows[0]["phone"].ToString();
                            this.txtAdress.Text = tb2.Rows[0]["adress"].ToString();

                            this.txtJd.Text = tb2.Rows[0]["jingdu"].ToString();
                            this.txtWd.Text = tb2.Rows[0]["weidu"].ToString();
                            this.txtJs.Text = tb2.Rows[0]["jieshao"].ToString();


                            string logo = tb2.Rows[0]["imgUrl"].ToString();
                            hidImg.Value = logo;
                            this.imgLogo.ImageUrl = VirturlPath + logo;

                            string logo2 = tb2.Rows[0]["hbImg"].ToString();
                            hidImg2.Value = logo2;
                            this.imgLogo2.ImageUrl = VirturlPath + logo2;

                            if (tb2.Rows[0]["roleId"].ToString() == "2")
                            {
                                this.divSj.Attributes.Add("style", "display:block");
                                this.divHb.Attributes.Add("style", "display:block");
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('登录超时！');window.location.href='login.aspx'", true);
                    }

                }
                catch
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('系统发生故障啦！');", true);
                }

            }
        }

        public string RoleName(string id)
        {
            string name = "";
            DataSet ds = bll.getDataSet("select * from t_role where roleId='" + id + "' ");
            DataTable tb = ds.Tables[0];
            if (tb.Rows.Count > 0)
            {
                name = tb.Rows[0]["name"].ToString();
            }
            
            return name;
        }

        public string lxName(string id)
        {
            string name = "";
            try
            {
                if (id != "")
                {
                    DataSet ds = bll.getDataSet("select * from t_shanghu_lx where id=" + id + "");
                    DataTable tb = ds.Tables[0];
                    if (tb.Rows.Count > 0)
                    {
                        name = tb.Rows[0]["name"].ToString();
                    }
                }
            }
            catch
            {
                
            }
            return name;
        }
        protected void btnBc_Click(object sender, EventArgs e)
        {
            try
            {
                 DataTable tb = Session["users"] as DataTable;
                 if (tb.Rows.Count > 0)
                 {

                     string imgUrl = "";
                     HttpPostedFile hp = fileLogo.PostedFile;
                     if (hp.FileName.ToString() != "")
                     {
                         string hz = hp.FileName.ToString().Substring(hp.FileName.ToString().LastIndexOf(".") + 1);
                         if (hz == "jpg" || hz == "png")
                         {
                             string Filename1 = Guid.NewGuid().ToString() + "." + hz;
                             String path = Server.MapPath("Upload/logo/");
                             hp.SaveAs(Path.Combine(path, Filename1));
                             imgUrl = "/Upload/logo/" + Filename1;
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

                     string hbImg = "";
                     HttpPostedFile hp2 = fileLogo2.PostedFile;
                     if (hp2.FileName.ToString() != "")
                     {
                         string hz = hp2.FileName.ToString().Substring(hp2.FileName.ToString().LastIndexOf(".") + 1);
                         if (hz == "jpg" || hz == "png")
                         {
                             string Filename1 = Guid.NewGuid().ToString() + "." + hz;
                             String path = Server.MapPath("Upload/hb/");
                             hp2.SaveAs(Path.Combine(path, Filename1));
                             hbImg = "/Upload/hb/" + Filename1;
                         }
                         else
                         {
                             ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('请选择jpg或png格式的图片');", true);
                             return;
                         }
                     }
                     else
                     {
                         hbImg = hidImg2.Value;
                     }

                     if (this.txtRole.Text.Trim() == "商家")
                     {
                         if (this.txtAdress.Text.Trim() == "")
                         {
                             ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('请输入商家地址');", true);
                             return;
                         }
                         if (this.txtJd.Text.Trim() == "")
                         {
                             ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('请输入商家经度');", true);
                             return;
                         }
                         if (this.txtWd.Text.Trim() == "")
                         {
                             ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('请输入商家纬度');", true);
                             return;
                         }
                     }


                     int jg = bll.Execute("update t_users set jingdu='" + this.txtJd.Text.Trim() + "',weidu='" + this.txtWd.Text.Trim() + "',jieshao='" + this.txtJs.Text.Trim() + "',name='" + this.txtName.Text.Trim() + "',hbImg='" + hbImg + "',imgUrl='" + imgUrl + "',adress='" + this.txtAdress.Text.Trim() + "',phone='" + this.txtPhone.Text.Trim() + "' where usersId='" + tb.Rows[0]["usersId"].ToString() + "'");
                     if (jg > 0)
                     {
                         DataSet ds2 = bll.getDataSet("select * from t_users where usersId='" + tb.Rows[0]["usersId"].ToString() + "' ");
                         DataTable tb2 = ds2.Tables[0];
                         Session["users"] = tb2;

                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "var date = new Date(); var expiresDays = 10;date.setTime(date.getTime() + expiresDays * 24 * 3600 * 1000); document.cookie = \"logo=" + tb2.Rows[0]["imgUrl"].ToString() + "; expires=\" + date.toGMTString();alert('编辑个人资料成功！');window.location.href='personal.aspx';", true);
                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('编辑个人资料失败！');window.location.href='personal.aspx';", true);
                     }
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('登录超时！');window.location.href='login.aspx'", true);
                 }

   
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Test", "alert('系统发生故障啦！');", true);
            }
        }

    }
}
