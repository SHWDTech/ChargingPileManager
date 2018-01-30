using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Text;

namespace ZDEnterprise.Web
{
    public partial class admin_order_info : Manager
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


                if (RolePermissions("5001") == false)
                {
                    Response.Write("<script language='javascript'>window.location.href='errorQx.aspx?menu1=2&menu2=4';</script>");
                }
                else
                {
                    string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";

                    string strwhere = " serialNumber='" + id + "' ";

                    List<System.Model.V_order_details> sqlist = _bll.vobll.GetModelList(strwhere);

                    if (sqlist.Count > 0)
                    {
                        System.Model.V_order_details sq = sqlist[0];
                        this.duration_p.InnerText = sq.duration.ToString()+"分钟";
                        this.ftype_p.InnerText = sq.ftype.ToString();
                        this.fno_p.InnerText = sq.fno.ToString();
                        this.phone_p.InnerText = sq.phone.ToString();
                        this.sname_p.InnerText = sq.sname.ToString();
                        this.serialNumber_p.InnerText = sq.serialNumber.ToString();
                        this.price_p.InnerText = sq.price.ToString("0.00")+"元";
                        this.discount_p.InnerText = sq.discount.ToString();
                        this.pudate_p.InnerText = sq.pudate.ToString();
                        this.paystatus_p.InnerText = getpaystatic(sq.paystatus.ToString());
                        this.typename_p.InnerText = sq.typename.ToString();





                    }
                    else
                    {

                    }
                }
            }
        }

        public string getpaystatic(string status)
        {
            string paystatic = "";

            switch (status)
            {

                case "1":
                    paystatic = "未支付";
                    break;
                case "2":
                    paystatic = "已支付";
                    break;
                case "3":
                    paystatic = "已开始充电";
                    break;
                case "4":
                    paystatic = "充电完成";
                    break;
                default:
                    paystatic = "未知";
                    break;
            }

            return paystatic;
        }
    }
}