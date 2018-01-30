using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;

namespace ZDEnterprise.Web.json.order
{
    //订单
    public partial class list : System.Web.UI.Page
    {
        System.BLL.publicBLL pbll = new System.BLL.publicBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {
                    //pn
                    string pn = Request["pn"] != null ? Utility.Helper.Checkstr(Request["pn"]) : "1";
                    //ps
                    string ps = Request["ps"] != null ? Utility.Helper.Checkstr(Request["ps"]) : "10";

                    //用户id
                    string memberid = Request["memberid"] != null ? Utility.Helper.Checkstr(Request["memberid"]) : "";
                    //支付状态
                    string paystatus = Request["paystatus"] != null ? Utility.Helper.Checkstr(Request["paystatus"]) : "";
                    //订单号
                    string serialnumber = Request["serialnumber"] != null ? Utility.Helper.Checkstr(Request["serialnumber"]) : "";
                    //排序值  
                    string strwhere = " ";
                    string strorderby = " id desc ";

                    if (!string.IsNullOrEmpty(paystatus))
                    {

                        if (paystatus == "2")
                        {
                            strwhere += " and (paystatus=2 or paystatus=3 ) ";
                        }
                        else
                        {
                            strwhere += " and paystatus=" + paystatus + " ";
                        }

                    }

                    if (!string.IsNullOrEmpty(memberid))
                    {
                        strwhere += " and memberid='" + memberid + "'  ";
                    }

                    if (!string.IsNullOrEmpty(serialnumber))
                    {
                        strwhere += " and serialnumber='" + serialnumber + "'  ";
                    }

                    #region Member_Charge_Withdraw list

                    string strsql = @" select 
     	    id
     		,moneyes
     		,pudate
     		,paydate
     		,remarks
     		,serialnumber
     		,memberid
     		,paytype
     		,paystatus
     		,typename
     		,statusname
     		,types
     		,tpserialnumber
            ,(select statuses from order_info where order_info.serialNumber=IDWithRowNumber.serialNumber) statices
     		 from  (select *,Row_number() over(order by " + strorderby + " ) as IDRank from Member_Charge_Withdraw where  1=1 " + strwhere + @"  ) as IDWithRowNumber
  where IDRank>(" + pn + "-1)*" + ps + " and IDRank<=" + pn + "*" + ps + "";

                    DataTable tab = pbll.getDataSet(strsql).Tables[0];
                    if (tab.Rows.Count > 0)
                    {
                        JsonData jsondatas = new JsonData();
                        for (int i = 0; i < tab.Rows.Count; i++)
                        {
                            JsonData json = new JsonData();
                            DataRow dr = tab.Rows[i];
                            if (dr != null)
                            {
                                json["id"] = Utility.Helper.gerString(dr["id"]);
                                json["moneyes"] = Utility.Helper.gerDecimal(dr["moneyes"]).ToString("0.00");
                                json["pudate"] = Utility.Helper.gerString(dr["pudate"]);
                                json["paydate"] = Utility.Helper.gerString(dr["paydate"]);
                                json["remarks"] = Utility.Helper.gerString(dr["remarks"]);
                                json["serialnumber"] = Utility.Helper.gerString(dr["serialNumber"]);
                                json["memberid"] = Utility.Helper.gerString(dr["memberid"]);
                                json["paytype"] = Utility.Helper.gerString(dr["paytype"]);
                                json["paystatus"] = Utility.Helper.gerString(dr["paystatus"]);
                                json["typename"] = Utility.Helper.gerString(dr["typename"]);
                                json["statusname"] = Utility.Helper.gerString(dr["statusname"]);
                                json["types"] = Utility.Helper.gerString(dr["types"]);
                                json["chargedState"] = Utility.Helper.gerString(dr["statices"]);
                                json["tpserialnumber"] = Utility.Helper.gerString(dr["tpSerialNumber"]);
                            }
                            jsondatas.Add(json);
                        }
                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "成功";
                        jsonResult["code"] = "";
                        jsonResult["count"] = tab.Rows.Count;
                        jsonResult["elements"] = jsondatas;
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "数据已全部加载";
                        jsonResult["code"] = "";
                        jsonResult["count"] = tab.Rows.Count;
                        jsonResult["elements"] = JsonMapper.ToObject("[]");
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


