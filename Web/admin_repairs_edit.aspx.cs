using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BLL;
using System.Text;

namespace ZDEnterprise.Web
{
    public partial class admin_repairs_edit : Manager
    {



        /// <summary>
        /// 编辑帖子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public string websitetitle = ConfigurationManager.AppSettings["websitetitle"];
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];
        ClassBLL bll = new ClassBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                main_menu.menu1 = "6";
                main_menu.menu2 = "6";

                if (RolePermissions("6001") == false)
                {
                    Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                }
                else
                {
                    string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";


                    System.Model.repairs sq = _bll.rebll.GetModel(Utility.Helper.gerInt(id));

                    if (sq != null)
                    {
                        member_p.InnerText = sq.customId;

                        type_p.InnerText = getRepairsType(Utility.Helper.gerString(sq.types));
                        cause_p.InnerText = sq.cause;
                        pudate_p.InnerText = sq.pudate.ToString();


                        string strwhere = "  guishu='" + sq.toid + "'  ";

                        List<System.Model.repairs_img> cr = _bll.reibll.GetModelList(strwhere);


                        StringBuilder strHtml = new StringBuilder();

                        if (cr.Count > 0)
                        {
                            for (int i = 0; i < cr.Count; i++)
                            {
                                strHtml.Append("<a class='addsed' href='" + cr[i].img + "'><img src='" + cr[i].img + "' alt=''></a>");
                            }

                            ziyuane_p.InnerHtml = strHtml.ToString();

                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        public string getRepairsType(string type)
        {
            string res = "";
            switch (type)
            {
                case "1":
                    res = "扫码无反应";
                    break;
                case "2":
                    res = "故障报修";
                    break;
                default:
                    res = "未知";
                    break;
            }
            return res;
        }
    }

}