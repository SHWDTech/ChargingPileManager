using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using SHWD.ChargingPileBusiness;
using Newtonsoft.Json;
using HttpWebRequestClient;
using HttpWebRequestClient.Model;

namespace ZDEnterprise.Web.json.flow
{

    public class checkStatus
    {

        /// <summary>
        /// 状态
        /// </summary>
        public bool status = false;
        /// <summary>
        /// 标识
        /// </summary>
        public string identifying = "";
        /// <summary>
        /// 类型
        /// </summary>
        public int types = 0;

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderid = "";

        /// <summary>
        /// 接口使用时间
        /// </summary>
        public DateTime? datetime;

        /// <summary>
        /// 充电枪toid
        /// </summary>
        public string porttoid = "";

        /// <summary>
        /// 充电枪id
        /// </summary>
        public int portid = 0;

        /// <summary>
        /// 充电桩id
        /// </summary>
        public int facilityid = 0;


        public string customId = "";
    }

    public class publicData
    {
        public static List<checkStatus> orderlist = new List<checkStatus>();
    }

    public partial class richscan : System.Web.UI.Page
    {




        //开始扫一扫
        protected void Page_Load(object sender, EventArgs e)
        {
            //网点id
            //string stippleid = Request["stippleid"] != null ? Utility.Helper.Checkstr(Request["stippleid"]) : "";
            //设备id
            //string facilityid = Request["facilityid"] != null ? Utility.Helper.Checkstr(Request["stippleid"]) : "";

            //网点编号
            //string stippleno = Request["stippleno"] != null ? Utility.Helper.Checkstr(Request["stippleno"]) : "";
            //设备编号
            //string facilityno = Request["facilityno"] != null ? Utility.Helper.Checkstr(Request["facilityno"]) : "";
            //接口编号
            //string portno = Request["portno"] != null ? Utility.Helper.Checkstr(Request["portno"]) : "";

            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {

                    //接口id
                    string portid = Request["portid"] != null ? Utility.Helper.Checkstr(Request["portid"]) : "";


                    //用户编号
                    string customId = _bll.getUserToke(Utility.Helper.gerString(Request["memberid"]));

                    #region 扫一扫
                    if (!string.IsNullOrEmpty(customId))
                    {

                        //充电中的 3天以内的订单
                        string strwhere = " customid='" + customId + "' and statuses=2  and pudate >DATEADD( DAY,-1,GETDATE()) ";
                        List<System.Model.order_info> orlist = _bll.oibll.GetModelList(strwhere);
                        //没有以上条件订单的用户可以下单
                        if (orlist.Count == 0)
                        {
                            //接口
                            System.Model.facility_port fp = new System.Model.facility_port();
                            //设备
                            System.Model.facility fa = new System.Model.facility();
                            //网点
                            System.Model.facility_stipple fs = new System.Model.facility_stipple();

                            strwhere = " toid='" + portid + "' and isdel=0  ";
                            List<System.Model.facility_port> fplist = _bll.fpbll.GetModelList(strwhere);

                            if (fplist.Count > 0)
                            {
                                fp = fplist[0];

                                #region 获取充电桩设备数据信息,验证
                                //正常  充电设备正常并且设备没有被使用
                                if (fp != null && fp.isEmploy == 0)
                                {
                                    fa = _bll.fbll.GetModel(fp.fid);
                                    if (fa != null)
                                    {
                                        #region 检测设备是否正常
                                        bool isUsable = false;

                                        //调用设备检测接口
                                        var manager = new ApiManager();
                                        string jsonstr = manager.GetChargingPileInfo(fa.identitycode);

                                        ChargingPileStatusResult jsond = JsonMapper.ToObject<ChargingPileStatusResult>(jsonstr);
                                        if (jsond != null)
                                        {
                                            List<RechargShotStatusResult> statuslist = jsond.RechargeShotStatus;

                                            statuslist = (from s in statuslist
                                                          where s.Identity == fp.identitycode
                                                          select s).ToList();

                                            if (statuslist.Count > 0 && Convert.ToInt32(statuslist[0].Status) == Convert.ToInt32(RunningStatus.OnLine))
                                            {


                                                #region 发送设备自检
                                                //发送设备自检
                                                var dic = new Dictionary<string, string>();
                                                dic.Add("ShotIndentity", fp.identitycode);
                                                var parsStr = JsonConvert.SerializeObject(dic);
                                                var selfTestModel = new CommandPostViewModel();
                                                selfTestModel.CommandName = "SelfTest";
                                                selfTestModel.TargetIdentity = fa.identitycode;
                                                selfTestModel.Pars = parsStr;

                                                //添加标识
                                                checkStatus cs = new checkStatus();
                                                //自检编号
                                                cs.identifying = manager.PostCommand(selfTestModel).Replace("\"", "");
                                                //状态
                                                cs.status = false;
                                                //类型
                                                cs.types = 0;
                                                //是否产生订单
                                                cs.orderid = "";
                                                cs.datetime = System.DateTime.Now;

                                                cs.portid = fp.id;
                                                cs.porttoid = fp.toid;
                                                cs.facilityid = fp.fid;
                                                cs.customId = customId;
                                                //log.setlog("设备自检", cs.identifying);
                                                publicData.orderlist.Add(cs);

                                                isUsable = true;

                                                //等待回调

                                                #endregion

                                                jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                                                jsonResult["identifying"] = cs.identifying;
                                                jsonResult["msg"] = "发送自检成功";
                                                jsonResult["code"] = "发送自检成功";

                                            }
                                            else
                                            {
                                                jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                                jsonResult["msg"] = "错误";
                                                jsonResult["code"] = "自检失败";
                                            }
                                        }
                                        else
                                        {
                                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                            jsonResult["msg"] = "错误";
                                            jsonResult["code"] = "自检失败";
                                        }

                                        #endregion


                                        //返回设备自检标示

                                        #region 注释
                                        //if (isUsable)
                                        //{
                                        //    //查询网点
                                        //    fs = _bll.fsbll.GetModel(fa.fid);
                                        //    //查询设备 折扣
                                        //    System.Model.facility_type ftype = _bll.ftbll.GetModel(fa.types);
                                        //
                                        //    //生成订单
                                        //    string serialNumber = System.DateTime.Now.ToString("yyyyMMddHHmmss") + Utility.Helper.rnds(8);
                                        //    //折后价
                                        //    decimal prices = ftype.price * ftype.discount;
                                        //
                                        //    System.Model.order_info oi = new System.Model.order_info();
                                        //
                                        //    oi.customid = customId;
                                        //    oi.serialNumber = serialNumber;
                                        //    oi.discount = ftype.discount;
                                        //
                                        //    oi.price = prices;
                                        //
                                        //    oi.port = fp.id;
                                        //    oi.pudate = System.DateTime.Now;
                                        //    oi.statuses = 1;
                                        //    oi.facility = Utility.Helper.gerInt(fa.id);
                                        //    oi.duration = ftype.time;
                                        //    oi.stippleid = fs.id;
                                        //    oi.types = 1;//1快充
                                        //    if (_bll.oibll.Add(oi) > 0)
                                        //    {
                                        //        //生成支付信息
                                        //
                                        //        System.Model.Member_Charge_Withdraw mcw = new System.Model.Member_Charge_Withdraw();
                                        //
                                        //        mcw.memberid = customId;
                                        //        mcw.moneyes = prices;
                                        //        mcw.serialNumber = serialNumber;
                                        //        mcw.paystatus = 1;
                                        //        mcw.statusname = "未支付";
                                        //        //mcw.paytype = "";//支付方式 支付宝 微信 钱包
                                        //        //paystatus 1 未支付 2已支付
                                        //        //types  1订单 2充值 3......
                                        //        mcw.types = 1;
                                        //        mcw.pudate = System.DateTime.Now;
                                        //        if (_bll.mcwbll.Add(mcw) > 0)
                                        //        {
                                        //            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                                        //            jsonResult["msg"] = "下单成功";
                                        //            jsonResult["code"] = "";
                                        //
                                        //            jsonResult["stipplename"] = fs.name;
                                        //            jsonResult["servertype"] = "快充";
                                        //            jsonResult["price"] = Math.Round(prices, 2).ToString();
                                        //            jsonResult["serialnumber"] = serialNumber;//订单号
                                        //        }
                                        //        else
                                        //        {
                                        //            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                        //            jsonResult["msg"] = "错误";
                                        //            jsonResult["code"] = "下单失败";
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                        //        jsonResult["msg"] = "错误";
                                        //        jsonResult["code"] = "下单失败";
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //错误
                                        //    //添加自检错误记录
                                        //    //
                                        //    System.Model.self_test st = new System.Model.self_test();
                                        //
                                        //    st.ername = "";
                                        //    st.errortype = "";
                                        //    st.facility = Utility.Helper.gerInt(fa.id);
                                        //    st.isdispose = 0;
                                        //    st.port = Utility.Helper.gerInt(portid);
                                        //    st.errortype = "1";
                                        //    st.stipple = Utility.Helper.gerInt(fs.id);
                                        //    st.pudate = System.DateTime.Now;
                                        //    _bll.stbll.Add(st);
                                        //
                                        //
                                        //    jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                        //    jsonResult["msg"] = "设备故障";
                                        //    jsonResult["code"] = "设备故障";
                                        //}
                                        #endregion
                                    }
                                    else
                                    {
                                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                        jsonResult["msg"] = "错误";
                                        jsonResult["code"] = "自检失败";
                                    }
                                }
                                else
                                {
                                    jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                    jsonResult["msg"] = "设备故障或设备已被使用";
                                    jsonResult["code"] = "设备故障或设备已被使用";
                                }
                                #endregion

                                //提示支付

                            }
                            else
                            {
                                jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                jsonResult["msg"] = "设备已不可用";
                                jsonResult["code"] = "未找到该设备信息";
                            }
                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "用户有订单未完成";
                            jsonResult["code"] = "";
                        }
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
    }
}