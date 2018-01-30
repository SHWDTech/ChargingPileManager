using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;
using ZDEnterprise.Web.json.flow;

namespace ZDEnterprise.Web.json
{
    public partial class circulationget : System.Web.UI.Page
    {
        System.BLL.publicBLL pbll = new System.BLL.publicBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //安卓循环获取订单号码

            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {
                    //条件

                    string identifying = Request["identifying"] != null ? Utility.Helper.Checkstr(Request["identifying"]) : "";

                    if (!string.IsNullOrEmpty(identifying))
                    {

                        List<checkStatus> sd = publicData.orderlist;
                        if (sd.Count > 0)
                        {
                            sd = (from s in sd
                                  where s.identifying == identifying
                                  select s).ToList();
                            string serialnumber = "";
                            if (sd.Count > 0 && !string.IsNullOrEmpty(sd[0].orderid))
                            {
                                serialnumber = sd[0].orderid;
                                jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                                jsonResult["msg"] = "成功";
                                jsonResult["code"] = "";

                                jsonResult["serialnumber"] = serialnumber;

                                string strwhere = " serialNumber='" + serialnumber + "' ";

                                jsonResult["stipplename"] = "";
                                jsonResult["servertype"] = "快充";
                                jsonResult["price"] = "0";
                                List<System.Model.V_order_details> volist = _bll.vobll.GetModelList(strwhere);
                                if (volist.Count > 0)
                                {
                                    System.Model.V_order_details fs = volist[0];
                                    jsonResult["stipplename"] = fs.sname;
                                    jsonResult["servertype"] = "快充";
                                    jsonResult["price"] = Math.Round(fs.price, 2).ToString();
                                }
                            }
                            else
                            {
                                jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                                jsonResult["msg"] = "未找到该订单";
                                jsonResult["code"] = "";
                                jsonResult["serialnumber"] = "";
                            }
                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "系统错误";
                            jsonResult["code"] = "参数有误";
                        }
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "系统错误";
                        jsonResult["code"] = "参数有误";
                    }
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