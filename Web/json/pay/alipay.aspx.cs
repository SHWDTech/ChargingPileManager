using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

using Aop.Api.Util;
using Newtonsoft.Json;
using System.Text;

namespace ZDEnterprise.Web.json.pay
{
    public partial class alipay : System.Web.UI.Page
    {
        //开始扫一扫
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {

                    //订单编号
                    string serialnumber = Request["serialnumber"] != null ? Utility.Helper.Checkstr(Request["serialnumber"]) : "";

                    string memberid = _bll.getUserToke(Utility.Helper.gerString(Request["memberid"]));

                    #region 发起支付宝支付
                    if (!string.IsNullOrEmpty(serialnumber) && !string.IsNullOrEmpty(memberid))
                    {
                        #region 发起支付

                        string strwhere = "  memberid='" + memberid + "' and serialNumber='" + serialnumber + "' ";

                        List<System.Model.Member_Charge_Withdraw> mcwList = _bll.mcwbll.GetModelList(strwhere);


                        if (mcwList.Count == 1)
                        {

                            //获取订单成功 开始发起支付
                            System.Model.Member_Charge_Withdraw mcw = mcwList[0];


                            if (mcw.paystatus == 1)//表示未支付的订单
                            {



                                #region 生成签名
                                decimal payamount = mcw.moneyes;
                                string out_trade_no = mcw.serialNumber;

                                string subject = "订单";//charge.TargetType == (int)MyEnum.PayTargetEnum.订单 ? "购买商品款项" : "充值";
                                string body = "订单（卫东）";//= (int)MyEnum.PayTargetEnum.订单 ? "购买商品（大学时代）" : "充值（大学时代）";

                                switch (mcw.types)
                                {
                                    case 1:
                                        subject = "订单";
                                        body = "订单（卫东）";
                                        break;
                                    case 2:
                                        subject = "充值";
                                        body = "充值（卫东）";
                                        break;
                                    default:
                                        subject = "订单";
                                        body = "订单（卫东）";
                                        break;
                                }
                                string sign = RSASign(serialnumber, payamount, subject, body);

                                //string sign = RSASigntext(serialnumber, payamount, subject, body);



                                //Response.Write(sign);


                                #endregion
                                jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                                jsonResult["msg"] = "生成支付宝支付订单成功";
                                jsonResult["sign"] = sign;
                                jsonResult["code"] = "";
                            }
                            else {
                                jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                jsonResult["msg"] = "订单已经支付过啦";
                                jsonResult["code"] = "";
                            }
                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "生成支付宝支付订单失败";
                            jsonResult["sign"] = "";
                            jsonResult["code"] = "订单有误";
                        }

                        #endregion
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "错误";
                        jsonResult["code"] = "参数有误";
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    jsonResult["res"] = (int)MyEnum.ResultEnum.系统错误;
                    jsonResult["msg"] = "服务器繁忙，请稍后再试";
                    jsonResult["code"] = ex.Message;
                }
                res = JsonMapper.ToJson(jsonResult);
                res = MyString.UnicodeToString(res);
                Response.Write(res);
            }
        }




        public string RSASign(string OrderNo, decimal Money, string bodyp, string subjectp)
        {


            string publicKeyPem = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnMZa3HbYp3iK1GNdO4wgWLnpo3FOJYim8QrzhTatE6al7+Gz5WuaUpJEIV4CcFd9lW1n0XuUUIKDznXp4SaX0Yz/J9pA5WQ0Qoq3OwcwmyYGm58VTuF2Kqnu4AnD27z4CsrArvyp760ijgRPEU1CUQLXEvRLV4tvBCukZ3Sx3hRuJvRF3prc7m+GtehkstZUc38os9DqNJE2yBPj6Ae1mXE+Se26vdmQfykyXeQjFpZ4cdELsJAvoHp1HzSQ8l+zCCcndTI/RCOtSensb2wMXSQ1zhSmYjEXtEpPpTZcO5Js9nvjr0/i9hp6Eao0P5ppMtjO2TX3uvFPb5SRVBUACwIDAQAB";
            string privateKeyPem = @"MIIEpAIBAAKCAQEAwEcE+f25SQy8I1EjCgVrTC0xRicTMBl5Wos4MblkDWokw0Z6
8ADPLLkOL/WPae7a9NgRdOMOmBuLDDqaL+KSZ1ALw+rGA0G92TD56QYI4JIhDaUr
ShD/V4kEFbcH/Muws8wlw0Rka7AyZiea4V66TUzG0bDnUZTtMJJTppXfS/qpE4Kg
0MxFb+whBCwyicMVsyHA2ZmBrPPAzETid1iN6ILdtkKgs97U3C7Gz2uB9X5UBShN
G5gIyEV0tlb+C9J+3K1v7CD2Pybs2JG7+olEXIoHfHntoq8S0W6hVxGssLR1eDd0
tfzibiMH6F69TdO0yEHeK5YkdsaH5CzCEqMQiQIDAQABAoIBABWoakEWeUZnLtHz
k7TPQ3TDKmeygxDJ7cdrIxtGvKReLmHokHR0QuHQvm5chJj0FKm7pMu7v6sWfyUT
fMakCMWmWIzq5v766r2KLLw4t8tD6oE095lSLNDZWCJyCW5KK081UZObIoyWvjaP
g3ybRPTsDwETohqoYcc01ENRYmOWWA5hmO5ZDDuyzTkD89iG4+wqHvLD/pqWUTF7
P8sXnePwD/q1OUX0NkGFzA7d7FnFor2mlvG9sPouCrIXQABL086ZTcLyrsoWyDbV
QMxv0P77ebtHQcyT5D5sIF8BZqQ5J06PNCqr4GwgBHea5mgHS2JD0swlHPQERcYE
/sT9M1kCgYEA++98NsZi+8IIHZrbT4ilOIbTcKmU3RWEcvNj42ngu6TueGRNZBoc
/4UXL1Ci1n6O+BopJuAVrG5ko0DehmEmo+kZUxntRSExajZ8osBaqM1VTajU2pRK
pHatP273m5AA5EM3SmsUuYOi49b6/xFi1PLzlXtj7uUMkEkbNtAk+NMCgYEAw2Ek
MU7MhNDPqNYZBhU0dYQKyhaH9ZTWK2IfcYz35Cx8MVgoj+2PMd9yrFlUzMRWwP9F
vCw6eyaEnHb/ks0l6+3sC8AVh8DBwj9nk+6hRqM76hLdbM+iVtTP/UxmuDlUoe6n
bmgJIuG/ByilfnbIAhx+luzRarpCH8D7C28Fd7MCgYEA9mxGPDGKSiR82bBJyZ6n
tQWztWQ6NpHAbsuArcU3S3NEyj+Zr0sXiBs/FUmzLUi3QRgdnmfa60FDcKeXwSsv
p23uFmmquk6AThqjiHHLe4b0ZDS6ll4sMHfgd8ZrrR6KsLrKTyE0MUz/vAngkjMI
T7Cf71u04MvroQnQ86leMH8CgYBxGeDLsmPuVrp/cEDYJppRlPhx+A0Ievpn7sto
/kPaEG5sWi5Q8yI7qrBFWQkf6GCYJK4Hukq4U5ncwX49SwiyxO4p9y3/gfQoMHAT
UMaHj6L1Y6pOfPvq7BLi/MFRz85QV0kRPqRbTvc4e60hwj0SC9C0Ka8o612v6BTr
j39IxQKBgQCLjMw4u1jomTsc+pqpieeay4aGvLlTRoOpsAKMI+YBn1072KjSPY1m
PhqMa50QfsgQtk9f/nHDF03IU7PITyY7K/3gUx3NSkNz789Jjrt7TS+xxBHuBM3C
aRqLacU+wjdieRylky7lwkVwg0mToUQFlxgmJACdibz1ZS0sja9IvQ==";//商户私钥

            string out_trade_no = OrderNo;//订单号
            double total_fee = (double)Money;//交易金额
            string app_id = "2017082808426992";//app支付，支付宝中该应用的ID
            string charset = "utf-8";//utf-8
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string notify_url = Utility.Helper.GetHttpUrl("/api/sdk_callback_alipay.aspx");//服务器异步通知页面路径 ;//回调地址
            string body = bodyp;
            string subject = subjectp;

            Dictionary<string, string> dic = new Dictionary<string, string>();

            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            dic.Add("app_id", app_id);
            dic.Add("method", "alipay.trade.app.pay");
            dic.Add("version", "1.0");
            dic.Add("charset", charset);
            dic.Add("notify_url", notify_url);
            dic.Add("sign_type", "RSA2");
            dic.Add("timestamp", timestamp);

            dic2.Add("out_trade_no", out_trade_no);//商户订单号
            dic2.Add("total_amount", total_fee);//支付金额
            dic2.Add("product_code", "QUICK_MSECURITY_PAY");
            dic2.Add("body", bodyp);
            dic2.Add("subject", subject);

            dic.Add("biz_content", JsonConvert.SerializeObject(dic2));

            //string sign = AlipaySignature.RSASign(dic, privateKeyPem, null, "RSA2");

            //AlipaySignature.RSASign方法是支付宝提供的签名方法，使用这个方法需要注意参数的传入，第一个参数为需要签名的参数，第二个参数为商户私钥，第4个参数如果传入fase,表示支付宝私钥以字符串的形式传入，true表示第二个参数要传存储私钥的文件地址，并且这个文件内容开头和结尾都要加“-----BEGIN RSA PRIVATE KEY----- 私钥 -----END RSA PRIVATE KEY-----” 

            string sign = AlipaySignature.RSASign(dic, privateKeyPem, "utf-8", false, "RSA2");

            sign = HttpUtility.UrlEncode(sign, Encoding.GetEncoding(charset));

            string Parms = string.Empty;
            var testparms = string.Empty;

            //Parms = Aop.Api.Util.AlipaySignature.GetSignContent(dic);

            foreach (KeyValuePair<String, string> k in dic)
            {
                testparms += k.Key + "=" + k.Value + "&";
                if (Parms == string.Empty)
                {
                    Parms = k.Key + "=" + HttpUtility.UrlEncode(k.Value, Encoding.GetEncoding(charset));
                }
                else
                {
                    Parms += "&" + k.Key + "=" + HttpUtility.UrlEncode(k.Value, Encoding.GetEncoding(charset));
                }
            }

            Parms = Parms + "&sign=" + sign;
            //Parms = sign;
            return Parms;
        }




        public string RSASigntext(string OrderNo, decimal Money, string bodyp, string subjectp)
        {

            string publicKeyPem = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAofOvvo2LrP3JIX6QerZ2
jzAgK0JFocOR+MZFCXxCboJ177LEc/LcHh5SsKovlApMqMf6QtpQenP4tFi60WYP
0YJTK122f9o/EccXcgVZZMs5LCTpH8KcnGrT67LxMSwV8akvaw8ifCFovZw35oFc
VJ7R+3xoiYRhzIDpQ+6hwoKBlgDpbGaTww9bW3qrHL91SljYrSgjI9H/jhO6XWlr
Pof6gEhruf8uPhfEG9oGs77IpVNP9xWjAmFnMAqjU0isXItmhkBYmYT89PcccIr5
VCy1rXJmNVylpiVELSCatCq+OP0M5J14pGkez5dEbQbnoJ+3E/T8UD3KUZ35aZCe
eQIDAQAB";//支付宝公钥 
            string privateKeyPem = @"MIIEowIBAAKCAQEAofOvvo2LrP3JIX6QerZ2jzAgK0JFocOR+MZFCXxCboJ177LE
c/LcHh5SsKovlApMqMf6QtpQenP4tFi60WYP0YJTK122f9o/EccXcgVZZMs5LCTp
H8KcnGrT67LxMSwV8akvaw8ifCFovZw35oFcVJ7R+3xoiYRhzIDpQ+6hwoKBlgDp
bGaTww9bW3qrHL91SljYrSgjI9H/jhO6XWlrPof6gEhruf8uPhfEG9oGs77IpVNP
9xWjAmFnMAqjU0isXItmhkBYmYT89PcccIr5VCy1rXJmNVylpiVELSCatCq+OP0M
5J14pGkez5dEbQbnoJ+3E/T8UD3KUZ35aZCeeQIDAQABAoIBAQCPxEXlAL5XqUsd
Qr97T/LblbtY65Ho0jYJA+lRTE+kzodna+jdjWA+FGkPj2SBJMt8oVnWcvsyWTUU
1Bezv8iXEfxG6QATa2jFnVmAzKLYyVdNis6wdRCWAndyKv3Vyu8IAkqn3V2dmALl
H4K4S2ntbLe3am9adHxlEKMCvRo4Ejyf+/dWbVJZpy8ryd6ei1FBXeePVTwwqCbz
NEd+WDnxJCp3hxGG9SaSWg9uEmpV8W929InRRhAY4foSeXo7eUCwMJfCDGDDbvuS
NAWlR0kqZ8wxAjugKAwTY48vT9pX8On+54u4ERYNfH2ALDjVHr7T9d65w2TAXxyX
RutMyx0hAoGBANS1QnqaPsCT1aF5bx3CU7Hmqru7/e6trSu78lJ5p6waEKOtS4N6
SFc7TgT8CBR8T82uhigPX8/ZZ1wOViHOfzyMhxCNvB/jNB7VAKRFT8prvGaGJiu7
vdePFM67RavDBgrMS7MQUpWEINaLc8SU2872Y6WkXgAcrgkcldC19c9VAoGBAMLp
4FOv39mzj9PL4XULUBYYHP8KgcyWuNrYtTneY8OW6s3w+3oVSJ1eikTbd3l0FE1B
rTuXxC5tO9LXV5qa3qm9jDVKmVAdHdZmyqbpbNfK2xD90ZtwKUE0QeXcB5SI15lr
b7IizsfrxpV2QBjK49+d1ODZelHFPPRjvRrpjyqVAoGAH8pzhCV3iYrO3BJtNBJu
NeGW1PY07q5Qen/dqMv77nH62Ku25JCrLTZ047PTdVRbDQ+vh18837DLjOurnePi
CmeqbCPy4QUxLgaB0Qt28HcHsn8MR28I4aXF41wD/rboOUbtbXbcEPKtgcNX6yKg
c59Jp2EYl4Wx0TTPg2Eeuv0CgYB3dStdXv8Mx/YwUlY9i89rmx+6V9AxeXaV+hcn
/lqadxY1XapiqkS03kpT5UYWE8SVjNkFGwDLi3sMv5obUSuCUH9r8eqApTeyPZGa
NpnUr6kPguBCKb2/Dq4MmIu0xyGMD8KHJLoi4Sf2VmD2UPLUDEF6BQ/oqb+v8Kjn
o5lw+QKBgEkDddwDNZoLlomqnfG6KMfgwzh76BHkrCryMxUoaDx75ze+qgPnv77u
a6a+aJqsfrpzh+fYEQV+No1ko1SW7Hv7MX+C9JOYLZIY7ybV0bg9wkiAcWgvtvdu
OwaT6nVyI6JIdQK3RW25fGRFr+Olqd0Dwju2UeH3sTiHLmL5nGPn";//商户私钥

            string out_trade_no = OrderNo;//订单号
            double total_fee = (double)Money;//交易金额
            string app_id = "2017060907457467";//app支付，支付宝中该应用的ID
            string charset = "utf-8";//utf-8
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string notify_url = Utility.Helper.GetHttpUrl("/api/sdk_callback_alipay.aspx");//服务器异步通知页面路径 ;//回调地址
            string body = bodyp;
            string subject = subjectp;

            Dictionary<string, string> dic = new Dictionary<string, string>();

            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            dic.Add("app_id", app_id);
            dic.Add("method", "alipay.trade.app.pay");
            dic.Add("version", "1.0");
            dic.Add("charset", charset);
            dic.Add("notify_url", notify_url);
            dic.Add("sign_type", "RSA2");
            dic.Add("timestamp", timestamp);

            dic2.Add("out_trade_no", out_trade_no);//商户订单号
            dic2.Add("total_amount", total_fee);//支付金额
            dic2.Add("product_code", "QUICK_MSECURITY_PAY");
            dic2.Add("body", bodyp);
            dic2.Add("subject", subject);

            dic.Add("biz_content", JsonConvert.SerializeObject(dic2));

            //string sign = AlipaySignature.RSASign(dic, privateKeyPem, null, "RSA2");

            //AlipaySignature.RSASign方法是支付宝提供的签名方法，使用这个方法需要注意参数的传入，第一个参数为需要签名的参数，第二个参数为商户私钥，第4个参数如果传入fase,表示支付宝私钥以字符串的形式传入，true表示第二个参数要传存储私钥的文件地址，并且这个文件内容开头和结尾都要加“-----BEGIN RSA PRIVATE KEY----- 私钥 -----END RSA PRIVATE KEY-----” 

            string sign = AlipaySignature.RSASign(dic, privateKeyPem, "utf-8", false, "RSA2");

            sign = HttpUtility.UrlEncode(sign, Encoding.GetEncoding(charset));

            string Parms = string.Empty;
            var testparms = string.Empty;

            //Parms = Aop.Api.Util.AlipaySignature.GetSignContent(dic);

            foreach (KeyValuePair<String, string> k in dic)
            {
                testparms += k.Key + "=" + k.Value + "&";
                if (Parms == string.Empty)
                {
                    Parms = k.Key + "=" + HttpUtility.UrlEncode(k.Value, Encoding.GetEncoding(charset));
                }
                else
                {
                    Parms += "&" + k.Key + "=" + HttpUtility.UrlEncode(k.Value, Encoding.GetEncoding(charset));
                }
            }

            Parms = Parms + "&sign=" + sign;

            //Parms = sign;
            return Parms;
        }
    }
}