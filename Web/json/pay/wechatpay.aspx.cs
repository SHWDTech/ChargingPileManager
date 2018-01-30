using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.Json.pay
{
    public partial class wechatpay : System.Web.UI.Page
    {


        public static string Appid = Utility.Helper.GetConfigAppSettings("wxappid");
        public static string MchId = Utility.Helper.GetConfigAppSettings("wxmchid");
        public static string MchKey = Utility.Helper.GetConfigAppSettings("wxmchkey");

        //发起微信支付

        protected void Page_Load(object sender, EventArgs e)
        {
            string res = "";

            JsonData jsonResult = new JsonData();
            try
            {
                #region APP微信支付提交订单
                //订单编号
                string serialnumber = Request["serialnumber"] != null ? Utility.Helper.Checkstr(Request["serialnumber"]) : "";

                string memberid = _bll.getUserToke(Utility.Helper.gerString(Request["memberid"]));


                if (!string.IsNullOrEmpty(serialnumber))
                {

                    string strwhere = "  memberid='" + memberid + "' and serialNumber='" + serialnumber + "' ";

                    List<System.Model.Member_Charge_Withdraw> mcwList = _bll.mcwbll.GetModelList(strwhere);


                    if (mcwList.Count == 1)
                    {

                        //获取订单成功 开始发起支付
                        System.Model.Member_Charge_Withdraw mcw = mcwList[0];
                        if (mcw.paystatus == 1)
                        {
                            #region 设置参数，生成微信支付订单
                            string appid = Appid;
                            string mchid = MchId;
                            string mchkey = MchKey;
                            //decimal payamount = mcw.moneyes * 100;
                            decimal payamount = mcw.moneyes ;
                            string out_trade_no = mcw.serialNumber;

                            string body = "购买商品款项";
                            string attach = "购买商品（卫东）";

                            switch (mcw.types)
                            {
                                case 1:
                                    attach = "订单";
                                    body = "订单（卫东）";
                                    break;
                                case 2:
                                    attach = "充值";
                                    body = "充值（卫东）";
                                    break;
                                default:
                                    attach = "订单";
                                    body = "订单（卫东）";
                                    break;
                            }

                            string ip = "127.0.0.1";
                            //Request.UserHostAddress;

                            string notify_url = Utility.Helper.GetHttpUrl("/api/sdk_callback_wechat.aspx");
                            WeChatHelper.PayParam payparam = WeChatHelper.Pay.CreateWechatAppPay(appid, mchid, mchkey, payamount, out_trade_no, body, attach, ip, notify_url);

                            #endregion

                            #region 返回预支付参数
                            if (payparam != null)
                            {
                                jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                                jsonResult["msg"] = "订单生成成功";
                                jsonResult["code"] = "";
                                jsonResult["prepayid"] = payparam.PrepayId;
                                jsonResult["appid"] = payparam.AppId;
                                jsonResult["partnerid"] = payparam.PartnerId;
                                jsonResult["package_value"] = payparam.Package;
                                jsonResult["noncestr"] = payparam.NonceStr;
                                jsonResult["timestamp"] = payparam.TimeStamp;
                                jsonResult["sign"] = payparam.Sign;
                            }
                            else
                            {
                                jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                jsonResult["msg"] = "订单生成失败";
                                jsonResult["sign"] = "";
                                jsonResult["code"] = "订单有误";
                            }
                            #endregion
                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "该订单已支付";
                            jsonResult["sign"] = "";
                            jsonResult["code"] = "订单有误";
                        }
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "当前状态不可发起支付";

                    }

                }
                else
                {
                    jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                    jsonResult["msg"] = "参数不正确";

                }
                #endregion
            }
            catch (Exception ex)
            {
                //jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                //jsonResult["msg"] = "服务器繁忙，请稍后再试";


            }
            res = JsonMapper.ToJson(jsonResult);
            res = MyString.UnicodeToString(res);
            Response.Write(res);

        }
    }
}