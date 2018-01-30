using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.api.pay
{
    public partial class sdk_callback_wechat : System.Web.UI.Page
    {
        //用于微信支付回调
        //System.BLL.Member_Charge_Withdraw mcwbll = new System.BLL.Member_Charge_Withdraw();
        //System.BLL.Order_Info oibll = new System.BLL.Order_Info();
        //System.BLL.Service_Requirement srbll = new System.BLL.Service_Requirement();
        //System.BLL.Service_Require_Fee srfbll = new System.BLL.Service_Require_Fee();
        //System.BLL.Engineer ebll = new System.BLL.Engineer();
        //System.BLL.Service_Competition scbll = new System.BLL.Service_Competition();
        private static string lockWechatPayObj = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string res = "";


            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(this.Request.InputStream);
                System.Xml.XmlNodeList nodelist = doc.SelectNodes("//xml");//匹配所有xml节点

                //errordetail = doc.InnerXml;
                if (nodelist.Count > 0)
                {
                    System.Xml.XmlNode msgNode = nodelist[0];
                    if (msgNode != null)
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //请在这里加上商户的业务逻辑程序代码


                        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——

                        //交易状态
                        string result = msgNode.SelectSingleNode("return_code").InnerText;
                        if (result == "SUCCESS")
                        {
                            //判断该笔订单是否在商户网站中已经做过处理
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序

                            //商户订单号
                            string out_trade_no = msgNode.SelectSingleNode("out_trade_no").InnerText;

                            //微信交易号
                            string trade_no = msgNode.SelectSingleNode("transaction_id").InnerText;

                            lock (lockWechatPayObj)
                            {
                                //查询支付订单是否支付
                                string strwhere = " serialNumber='" + out_trade_no + "' and paystatus=1 ";

                                List<System.Model.Member_Charge_Withdraw> mcwlist = _bll.mcwbll.GetModelList(strwhere);

                                if (mcwlist.Count == 1)
                                {
                                    System.Model.Member_Charge_Withdraw mcw = mcwlist[0];

                                    mcw.paydate = System.DateTime.Now.ToString();
                                    mcw.paystatus = 2;
                                    mcw.paytype = 2;//微信
                                    mcw.statusname = "已支付";
                                    mcw.typename = "微信";
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
                                            open.opens(fa.identitycode,ports.identitycode, oi.customid, out_trade_no);

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
                            }
                        }
                        else
                        {

                        }
                        //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    else//验证失败
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {


            }
            Response.Write(res);


        }
    }
}