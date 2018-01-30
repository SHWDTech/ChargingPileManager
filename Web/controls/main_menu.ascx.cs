using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace ZDEnterprise.Web.controls
{
    public partial class main_menu : System.Web.UI.UserControl
    {
        public string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];

        public string menuCss1 = "";
        public string menuCss2 = "";
        public string menuString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            menuCss1 = menu1;
            menuCss2 = menu2;
            DataTable tb = Session["users"] as DataTable;
            if (tb != null && tb.Rows.Count > 0)
            {

                menuString += "<li " + (menuCss1 == "2" ? "class=\"active open\"" : "") + ">	<a href=\"#\" class=\"dropdown-toggle\"><i class=\"icon-cog\"></i><span class=\"menu-text\"> 平台设置 </span><b class=\"arrow icon-angle-down\"></b></a>	<ul class=\"submenu\">";
                menuString += "<li " + (menuCss2 == "2-1" ? "class=\"active\"" : "") + "><a href=\"admin_pt_content.aspx\"><i class=\"icon-double-angle-right\"></i>内容管理</a></li>";
                menuString += "<li " + (menuCss2 == "2-4" ? "class=\"active\"" : "") + "><a href=\"admin_msg.aspx\"><i class=\"icon-double-angle-right\"></i>消息管理</a></li>";
                menuString += "<li " + (menuCss2 == "2-5" ? "class=\"active\"" : "") + "><a href=\"admin_pt_message.aspx\"><i class=\"icon-double-angle-right\"></i>公告管理</a></li>";
                menuString += "<li " + (menuCss2 == "2-2" ? "class=\"active\"" : "") + "><a href=\"admin_feedback.aspx\"><i class=\"icon-double-angle-right\"></i>常见问题</a></li>";
                menuString += "<li " + (menuCss2 == "2-3" ? "class=\"active\"" : "") + "><a href=\"admin_system_config.aspx\"><i class=\"icon-double-angle-right\"></i>系统配置</a></li>";
                menuString += "</ul></li>";

                menuString += "<li " + (menuCss1 == "3" ? "class=\"active open\"" : "") + ">	<a href=\"#\" class=\"dropdown-toggle\"><i class=\"icon-group\"></i><span class=\"menu-text\"> 会员管理 </span><b class=\"arrow icon-angle-down\"></b></a><ul class=\"submenu\">";
                menuString += "<li " + (menuCss2 == "3-1" ? "class=\"active\"" : "") + "><a href=\"admin_custom.aspx\"><i class=\"icon-double-angle-right\"></i>查看会员</a></li>";
                menuString += "<li " + (menuCss2 == "3-2" ? "class=\"active\"" : "") + "><a href=\"admin_custom_yj.aspx\"><i class=\"icon-double-angle-right\"></i>意见反馈</a></li>";
                menuString += "</ul></li>";

                menuString += "<li " + (menuCss1 == "4" ? "class=\"active open\"" : "") + ">	<a href=\"#\" class=\"dropdown-toggle\"><i class=\"icon-flag\"></i><span class=\"menu-text\"> 设备管理 </span><b class=\"arrow icon-angle-down\"></b></a>	<ul class=\"submenu\">";
                //menuString += "<li " + (menuCss2 == "4-1" ? "class=\"active\"" : "") + "><a href=\"admin_goods_fl.aspx\"><i class=\"icon-double-angle-right\"></i>分类管理</a></li>";
                menuString += "<li " + (menuCss2 == "4-2" ? "class=\"active\"" : "") + "><a href=\"admin_stipple.aspx\"><i class=\"icon-double-angle-right\"></i>网点管理</a></li>";
                menuString += "<li " + (menuCss2 == "4-3" ? "class=\"active\"" : "") + "><a href=\"admin_facility.aspx\"><i class=\"icon-double-angle-right\"></i>充电桩管理</a></li>";
                menuString += "<li " + (menuCss2 == "4-4" ? "class=\"active\"" : "") + "><a href=\"admin_port.aspx\"><i class=\"icon-double-angle-right\"></i>充电枪管理</a></li>";
                menuString += "<li " + (menuCss2 == "4-5" ? "class=\"active\"" : "") + "><a href=\"admin_type.aspx\"><i class=\"icon-double-angle-right\"></i>充电桩类型</a></li>";

                menuString += " </ul></li>";

                menuString += "<li " + (menuCss1 == "5" ? "class=\"active\"" : "") + ">	<a href=\"admin_order.aspx\"><i class=\"icon-inbox\"></i><span class=\"menu-text\"> 订单管理 </span></a></li>";
                menuString += "<li " + (menuCss1 == "6" ? "class=\"active\"" : "") + ">	<a href=\"admin_repairs.aspx\"><i class=\"icon-inbox\"></i><span class=\"menu-text\"> 报修管理 </span></a></li>";
                //menuString += "<li " + (menuCss1 == "6" ? "class=\"active\"" : "") + ">	<a href=\"admin_order_pj.aspx\"><i class=\"icon-coffee\"></i><span class=\"menu-text\"> 评价管理 </span></a></li>";

                //menuString += "<li " + (menuCss1 == "6" ? "class=\"active open\"" : "") + ">	<a href=\"#\" class=\"dropdown-toggle\"><i class=\"icon-group\"></i><span class=\"menu-text\"> 活动管理 </span><b class=\"arrow icon-angle-down\"></b></a><ul class=\"submenu\">";
                //menuString += "<li " + (menuCss2 == "6-1" ? "class=\"active\"" : "") + "><a href=\"admin_custom.aspx\"><i class=\"icon-double-angle-right\"></i>活动设备</a></li>";
                //menuString += "</ul></li>";

                menuString += "<li " + (menuCss1 == "7" ? "class=\"active open\"" : "") + ">	<a href=\"#\" class=\"dropdown-toggle\"><i class=\"icon-flag\"></i><span class=\"menu-text\"> 数据统计 </span><b class=\"arrow icon-angle-down\"></b></a>	<ul class=\"submenu\">";
                menuString += "<li " + (menuCss2 == "7-1" ? "class=\"active\"" : "") + "><a href=\"admin_user_statistics.aspx\"><i class=\"icon-double-angle-right\"></i>用户统计</a></li>";
                menuString += "<li " + (menuCss2 == "7-2" ? "class=\"active\"" : "") + "><a href=\"admin_order_statistics.aspx\"><i class=\"icon-double-angle-right\"></i>订单统计</a></li>";
                menuString += "<li " + (menuCss2 == "7-3" ? "class=\"active\"" : "") + "><a href=\"admin_branch_statistics.aspx\"><i class=\"icon-double-angle-right\"></i>网点统计</a></li>";



                menuString += " </ul></li>";

                menuString += "<li " + (menuCss1 == "9" ? "class=\"active open\"" : "") + ">	<a href=\"#\" class=\"dropdown-toggle\"><i class=\"icon-legal\"></i><span class=\"menu-text\"> 系统管理 </span><b class=\"arrow icon-angle-down\"></b></a>	<ul class=\"submenu\">";
                menuString += "<li " + (menuCss2 == "9-1" ? "class=\"active\"" : "") + "><a href=\"role.aspx\"><i class=\"icon-double-angle-right\"></i>角色管理</a></li>";
                menuString += "<li " + (menuCss2 == "9-2" ? "class=\"active\"" : "") + "><a href=\"users.aspx\"><i class=\"icon-double-angle-right\"></i>用户管理</a></li>";
                menuString += "</ul></li>";


            }
        }

        private string _menu1;
        private string _menu2;

        public string menu1
        {
            get { return _menu1; }
            set { _menu1 = value; }
        }
        public string menu2
        {
            get { return _menu2; }
            set { _menu2 = value; }
        }

    }
}