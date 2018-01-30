using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Alipay;
using System.Collections.Specialized;
using Aop.Api.Util;

namespace Web.api.pay
{
    public partial class sdk_callback_alipay : System.Web.UI.Page
    {

        //用于支付宝回调
        //System.BLL.Member_Charge_Withdraw mcwbll = new System.BLL.Member_Charge_Withdraw();
        //System.BLL.Order_Info oibll = new System.BLL.Order_Info();
        //System.BLL.Service_Requirement srbll = new System.BLL.Service_Requirement();
        //System.BLL.Service_Require_Fee srfbll = new System.BLL.Service_Require_Fee();
        //System.BLL.Engineer ebll = new System.BLL.Engineer();
        //System.BLL.Service_Competition scbll = new System.BLL.Service_Competition();

        private static string lockAlipayObj = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //log.setlog("", "回调成功");
            try
            {
                SortedDictionary<string, string> sPara = GetRequestPost();

                if (sPara.Count > 0)//判断是否有带返回参数
                {
                    Notify aliNotify = new Notify();
                    //bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
                    bool verifyResult = AlipaySignature.RSACheckV1(sPara, Com.Alipay.Config.Public_key, "UTF-8", Config.Sign_type, false);
                    //log.setlog("是否回调成功", verifyResult.ToString());
                    if (verifyResult)//验证成功
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //请在这里加上商户的业务逻辑程序代码


                        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                        //商户订单号

                        string out_trade_no = Request.Form["out_trade_no"];

                        //支付宝交易号

                        string trade_no = Request.Form["trade_no"];

                        //支付的金额 
                        string price = Request.Form["price"];

                        //交易状态
                        string trade_status = Request.Form["trade_status"];


                        //log.setlog("支付信息", trade_no + "---" + price + "---" + out_trade_no + "---" + trade_status);


                        lock (lockAlipayObj)
                        {
                            if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                            {
                                //查询支付订单是否支付
                                string strwhere = " serialNumber='" + out_trade_no + "' and paystatus=1 ";

                                List<System.Model.Member_Charge_Withdraw> mcwlist = _bll.mcwbll.GetModelList(strwhere);

                                if (mcwlist.Count == 1)
                                {
                                    System.Model.Member_Charge_Withdraw mcw = mcwlist[0];

                                    mcw.paydate = System.DateTime.Now.ToString();
                                    mcw.paystatus = 2;
                                    mcw.paytype = 1;
                                    mcw.statusname = "已支付";
                                    mcw.typename = "支付宝";
                                    mcw.tpSerialNumber = trade_no;
                                    _bll.mcwbll.Update(mcw);


                                    //订单付款
                                    if (mcw.types == 1)
                                    {
                                        strwhere = " serialNumber='" + out_trade_no + "'  ";

                                        List<System.Model.order_info> oilist = _bll.oibll.GetModelList(strwhere);

                                        if (oilist.Count == 1)
                                        {
                                            System.Model.order_info oi = oilist[0];
                                            oi.statuses = 2;
                                            _bll.oibll.Update(oi);
                                            //锁定设备
                                            System.Model.facility_port ports = _bll.fpbll.GetModel(oi.port);
                                            ports.isEmploy = 1;
                                            _bll.fpbll.Update(ports);

                                            //通知设备开始充电
                                            System.Model.facility fa = _bll.fbll.GetModel(oi.facility);
                                            open.opens(fa.identitycode,ports.identitycode,oi.customid, out_trade_no);

                                        }
                                        else
                                        {

                                        }
                                    }
                                    //充值

                                    //



                                }
                                else
                                {
                                    //订单未找到或者已支付
                                }


                                //查询是否支付

                                //查询 订单是否支付

                                //修改订单状态

                                //业务逻辑

                                //判断该笔订单是否在商户网站中已经做过处理
                                //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                                //如果有做过处理，不执行商户的业务程序

                                //注意：
                                //该种交易状态只在两种情况下出现
                                //1、开通了普通即时到账，买家付款成功后。
                                //2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。
                            }
                            else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                            {
                                //判断该笔订单是否在商户网站中已经做过处理
                                //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                                //如果有做过处理，不执行商户的业务程序

                                //注意：
                                //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。

                                //log.setlog("B", "");
                            }
                            else
                            {
                                //log.setlog("C", "");
                            }
                        }

                        //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                        Response.Write("success");  //请不要修改或删除

                        //ms.Dispose();

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    else//验证失败
                    {
                        Response.Write("fail");

                    }
                }
                else
                {
                    Response.Write("无通知参数");

                }
            }
            catch (Exception ex)
            {


            }

        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
    }
}