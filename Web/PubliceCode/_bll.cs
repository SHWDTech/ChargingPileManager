using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace System
{
    public class _bll
    {

        /// <summary>
        /// 系统通用
        /// </summary>
        public static System.BLL.publicBLL pbll = new System.BLL.publicBLL();

        /// <summary>
        /// 订单视图
        /// </summary>
        public static System.BLL.V_order_details vobll = new System.BLL.V_order_details();


        /// <summary>
        /// 验证码
        /// </summary>
        public static System.BLL.verification_code vcbll = new BLL.verification_code();

        /// <summary>
        /// 消息
        /// </summary>
        public static System.BLL.t_message tmbll = new System.BLL.t_message();

        /// <summary>
        /// 公告消息
        /// </summary>
        public static System.BLL.t_msg tmgbll = new System.BLL.t_msg();


        /// <summary>
        /// 支付记录
        /// </summary>
        public static System.BLL.Member_Charge_Withdraw mcwbll = new System.BLL.Member_Charge_Withdraw();

        /// <summary>
        /// 订单
        /// </summary>
        public static System.BLL.order_info oibll = new System.BLL.order_info();

        /// <summary>
        /// 自检错误记录
        /// </summary>
        public static System.BLL.self_test stbll = new System.BLL.self_test();

        /// <summary>
        /// 常见问题
        /// </summary>
        public static System.BLL.System_FAQ sfbll = new System.BLL.System_FAQ();

        /// <summary>
        /// 设备报修
        /// </summary>
        public static System.BLL.repairs rebll = new System.BLL.repairs();

        /// <summary>
        /// 设备报修图片
        /// </summary>
        public static System.BLL.repairs_img reibll = new System.BLL.repairs_img();

        /// <summary>
        /// 设备
        /// </summary>
        public static System.BLL.facility fbll = new System.BLL.facility();

        /// <summary>
        /// 设备接口
        /// </summary>
        public static System.BLL.facility_port fpbll = new System.BLL.facility_port();

        /// <summary>
        /// 设备网点
        /// </summary>
        public static System.BLL.facility_stipple fsbll = new System.BLL.facility_stipple();

        /// <summary>
        /// 设备类型
        /// </summary>
        public static System.BLL.facility_type ftbll = new System.BLL.facility_type();

        /// <summary>
        /// 用户个推token
        /// </summary>
        public static System.BLL.apush_token atbll = new System.BLL.apush_token();

        
        /// <summary>
        /// 系统配置
        /// </summary>
        public static System.BLL.System_Config scbll = new System.BLL.System_Config();

        /// <summary>
        /// 用户
        /// </summary>
        public static System.BLL.t_custom tcbll = new System.BLL.t_custom();

        /// <summary>
        /// 用户登录日志
        /// </summary>
        public static System.BLL.t_login_log tllbll = new System.BLL.t_login_log();



        /// <summary>
        /// 用户反馈
        /// </summary>
        public static System.BLL.t_custom_feedback tcfbll = new System.BLL.t_custom_feedback();





        /// <summary>
        /// 验证用户token是否有用
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public static string getUserToke(string memberid)
        {
            string membertoken = "";

            System.Model.t_custom tc = _bll.tcbll.GetModel(Utility.Helper.gerInt(memberid));
            if (tc != null)
            {
                membertoken = tc.id.ToString();
            }
            return membertoken;
        }


        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="memberid">用户id</param>
        /// <param name="sendtitle">标题</param>
        /// <param name="sendmsg">内容</param>
        public static void addpust(string memberid, string sendtitle, string sendmsg)
        {
            #region 给用户推送消息



            string strWhere = "";
            #region 推送消息
            strWhere = " customId='" + memberid + "' ";
            List<System.Model.apush_token> pushChannel = _bll.atbll.GetModelList(strWhere);
            if (pushChannel != null)
            {
                #region 推送消息
                bool isIOS = pushChannel[0].device == "ios";
                bool jieguo = GeTuiHelper.Push.SendNotiMsgToSingle(pushChannel[0].token, sendtitle, sendmsg, isIOS);

                //透传
                //GeTuiHelper.Push.SendTransMsgToSingle(pushChannel[0].token, "tc");

                #endregion
            }
            #endregion

            #endregion
        }


        #region 初始化个推帮助类
        /// <summary>
        /// 初始化个推帮助类
        /// </summary>
        public static void InitGeTui()
        {
            string APPID = "ypw95uhtsP8KIJlVscvVb6";                     //您应用的AppId
            string APPKEY = "Sh23pIPRej9a5gmHWO6Yf3";                    //您应用的AppKey
            string MASTERSECRET = "V5O5NrWdey7gIjetGYxaq2";              //您应用的MasterSecret 
            string LOGOURL = Utility.Helper.getImgUrl("/img/face.png");            //您应用的LOGO网络地址
            GeTuiHelper.Push.PushInit(APPID, APPKEY, MASTERSECRET, LOGOURL);
        }
        #endregion





    }
}