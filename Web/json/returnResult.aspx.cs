using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

using ZDEnterprise.Web.json.flow;

namespace ZDEnterprise.Web.json
{
    public partial class returnResult : System.Web.UI.Page
    {

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {
                    //结果类型
                    string resulttype = Request["resulttype"] != null ? Utility.Helper.Checkstr(Request["resulttype"]) : "";
                    //结果
                    string result = Request["result"] != null ? Utility.Helper.Checkstr(Request["result"]) : "";
                    //标识
                    string identify = Request["identify"] != null ? Utility.Helper.Checkstr(Request["identify"]) : "";
                    //接口标识
                    string requestCode = Request["requetCode"] != null ? Utility.Helper.Checkstr(Request["requetCode"]) : "";
                    //requestCode = Request.Form.ToString();
                    //
                    //log.setlog("地址", Request.Url.ToString());
                    //log.setlog("地址", Request.RawUrl);
                    #region 提供服务回调

                    if (!string.IsNullOrEmpty(resulttype) && !string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(identify))
                    {
                        log.setlog("服务回调", "resulttype:" + resulttype + "  result:" + result + "  identify:" + identify + "  requestCode:" + requestCode);




                        //标识   
                        string resultNO = result;
                        List<checkStatus> sd = publicData.orderlist;
                        log.setlog("静态变量数据量", sd.Count.ToString());

                        try
                        {
                            if (sd.Count > 0)
                            {
                                sd = (from s in sd
                                      where s.identifying == requestCode
                                      select s).ToList();



                                if (sd.Count > 0)
                                {
                                    checkStatus sd_0 = sd[0];
                                    if (sd_0.types == 0)
                                    {

                                        #region 自检结果

                                        string customId = sd_0.customId;
                                        System.Model.facility_port fp = _bll.fpbll.GetModel(sd_0.portid);

                                        System.Model.facility_stipple fs = new System.Model.facility_stipple();
                                        System.Model.facility fa = new System.Model.facility();

                                        if (resultNO == "2")
                                        //if (resultNO == "0")
                                        //if (true)
                                        {
                                            fa = _bll.fbll.GetModel(sd[0].facilityid);

                                            //查询网点
                                            fs = _bll.fsbll.GetModel(fa.fid);
                                            //查询设备 折扣
                                            System.Model.facility_type ftype = _bll.ftbll.GetModel(fa.types);

                                            //生成订单
                                            string serialNumber = System.DateTime.Now.ToString("yyyyMMddHHmmss") + Utility.Helper.rnds(8);
                                            //折后价
                                            decimal prices = ftype.price * ftype.discount;

                                            System.Model.order_info oi = new System.Model.order_info();

                                            oi.customid = customId;
                                            oi.serialNumber = serialNumber;
                                            oi.discount = ftype.discount;

                                            oi.price = prices;

                                            oi.port = fp.id;
                                            oi.pudate = System.DateTime.Now;
                                            oi.statuses = 1;
                                            oi.facility = Utility.Helper.gerInt(fa.id);
                                            oi.duration = ftype.time;
                                            oi.stippleid = fs.id;
                                            oi.types = 1;//1快充
                                            if (_bll.oibll.Add(oi) > 0)
                                            {
                                                //生成支付信息

                                                System.Model.Member_Charge_Withdraw mcw = new System.Model.Member_Charge_Withdraw();

                                                mcw.memberid = customId;
                                                mcw.moneyes = prices;
                                                mcw.serialNumber = serialNumber;
                                                mcw.paystatus = 1;
                                                mcw.statusname = "未支付";
                                                //mcw.paytype = "";//支付方式 支付宝 微信 钱包
                                                //paystatus 1 未支付 2已支付
                                                //types  1订单 2充值 3......
                                                mcw.types = 1;
                                                mcw.pudate = System.DateTime.Now;
                                                if (_bll.mcwbll.Add(mcw) > 0)
                                                {

                                                    for (int i = 0; i < publicData.orderlist.Count; i++)
                                                    {
                                                        if (publicData.orderlist[i].identifying == requestCode)
                                                        {
                                                            publicData.orderlist[i].orderid = serialNumber;
                                                            log.setlog("订单产生成功", publicData.orderlist[i].orderid);
                                                        }
                                                    }
                                                    //jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                                                    //jsonResult["msg"] = "下单成功";
                                                    //jsonResult["code"] = "";
                                                    //
                                                    //jsonResult["stipplename"] = fs.name;
                                                    //jsonResult["servertype"] = "快充";
                                                    //jsonResult["price"] = Math.Round(prices, 2).ToString();
                                                    //jsonResult["serialnumber"] = serialNumber;//订单号
                                                }
                                                else
                                                {
                                                    //jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                                    //jsonResult["msg"] = "错误";
                                                    //jsonResult["code"] = "下单失败";
                                                }
                                            }
                                            else
                                            {
                                                //jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                                //jsonResult["msg"] = "错误";
                                                //jsonResult["code"] = "下单失败";
                                            }
                                        }
                                        else
                                        {
                                            //错误
                                            //添加自检错误记录
                                            //
                                            System.Model.self_test st = new System.Model.self_test();

                                            string name = "";
                                            string typeno;
                                            switch (resultNO)
                                            {
                                                case "0":
                                                    name = "正常";
                                                    typeno = "0";
                                                    break;
                                                case "2":
                                                    name = "充电桩和充电枪运行正常";
                                                    typeno = "2";
                                                    break;
                                                case "3":
                                                    name = "充电桩运行异常";
                                                    typeno = "3";
                                                    break;
                                                case "4":
                                                    name = "充电枪运行异常";
                                                    typeno = "4";
                                                    break;
                                                case "5":
                                                    name = "外网电压工作异常";
                                                    typeno = "5";
                                                    break;
                                                case "6":
                                                    name = "电池工作不正常";
                                                    typeno = "6";
                                                    break;
                                                case "7":
                                                    name = "充电枪与电池接触良";
                                                    typeno = "7";
                                                    break;
                                                default:
                                                    name = "系统未知错误";
                                                    typeno = "xxxx";
                                                    break;
                                            }

                                            st.facility = Utility.Helper.gerInt(fa.id);
                                            st.isdispose = 0;
                                            st.port = Utility.Helper.gerInt(fp.fid);
                                            st.errortype = "1";
                                            st.stipple = Utility.Helper.gerInt(fs.id);
                                            st.pudate = System.DateTime.Now;
                                            _bll.stbll.Add(st);


                                            //jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                            //jsonResult["msg"] = "设备故障";
                                            //jsonResult["code"] = "设备故障";
                                        }



                                        #endregion

                                    }
                                    else if (sd_0.types == 1)
                                    {
                                        #region 充电是否开始

                                        if (!string.IsNullOrEmpty(sd_0.orderid))
                                        {
                                            //修改订单充电状态
                                            //开始充电
                                            string strwhere = " serialNumber='" + sd_0.orderid + "'  ";

                                            List<System.Model.order_info> oilist = _bll.oibll.GetModelList(strwhere);

                                            if (oilist.Count == 1)
                                            {
                                                System.Model.order_info oi = oilist[0];
                                                oi.statuses = 2;//充电中
                                                _bll.oibll.Update(oi);
                                            }
                                            else
                                            {

                                            }

                                        }
                                        #endregion
                                    }
                                    else if (sd_0.types == 2)
                                    {
                                        #region 充电是否结束

                                        if (!string.IsNullOrEmpty(sd_0.orderid))
                                        {
                                            //修改订单充电状态
                                            //结束充电
                                            string strwhere = " serialNumber='" + sd_0.orderid + "'  ";

                                            List<System.Model.order_info> oilist = _bll.oibll.GetModelList(strwhere);
                                            if (oilist.Count == 1)
                                            {
                                                System.Model.order_info oi = oilist[0];
                                                oi.statuses = 3;//已完成充电
                                                _bll.oibll.Update(oi);
                                            }
                                            else
                                            {

                                            }

                                        }

                                        #endregion
                                    }
                                    else if (sd_0.types == 3)
                                    {
                                        #region 系统故障类型

                                        #endregion
                                    }
                                    else if (sd_0.types == 4)
                                    {
                                        #region 充电数据


                                        #endregion
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            log.setlog("错误", ex.Message);

                        }
                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "";
                        jsonResult["code"] = "";

                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "";
                        jsonResult["code"] = "参数缺失";
                    }
                    #endregion

                }
                catch (Exception ex)
                {
                    jsonResult["result"] = (int)MyEnum.ResultEnum.系统错误;
                    jsonResult["msg"] = "服务器繁忙，请稍后再试";
                    jsonResult["code"] = ex.Message;
                    log.setlog("错误", ex.Message);
                }
                res = JsonMapper.ToJson(jsonResult);
                res = MyString.UnicodeToString(res);
                Response.Write(res);

            }
        }
    }
}