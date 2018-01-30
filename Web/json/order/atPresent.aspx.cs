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
    public partial class atPresent : System.Web.UI.Page
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
                    //条件
                    string strwhere = "  ";
                    string id = Request["memberid"] != null ? Utility.Helper.Checkstr(Request["memberid"]) : "";

                    if (!string.IsNullOrEmpty(id))
                    {
                        strwhere += " and customid=" + id + " and  DATEADD(MINUTE ,duration, paydate)>GETDATE() ";

                        #region V_order_details list

                        string strsql = @" select 
     	    id
            ,duration
     		,paystatus
     		,types
     		,typename
     		,ctype
     		,serialnumber
     		,facility
     		,port
     		,price
     		,discount
     		,customid
     		,pudate
     		,paydate
            ,sname
     		 from  V_order_details where  1=1 " + strwhere;

                        DataTable tab = pbll.getDataSet(strsql).Tables[0];


                        if (tab.Rows.Count > 0)
                        {
                            JsonData jsondatas = new JsonData();
                            DataRow dr = tab.Rows[0];
                            if (dr != null)
                            {
                                jsonResult["id"] = Utility.Helper.gerString(dr["id"]);
                                //jsonResult["paystatus"] = Utility.Helper.gerString(dr["paystatus"]);
                                //jsonResult["types"] = Utility.Helper.gerString(dr["types"]);
                                jsonResult["duration"] = Utility.Helper.gerString(dr["duration"]);

                                jsonResult["sname"] = Utility.Helper.gerString(dr["sname"]);
                                jsonResult["typename"] = Utility.Helper.gerString(dr["typename"]);
                                jsonResult["ctype"] = "快充";
                                jsonResult["serialnumber"] = Utility.Helper.gerString(dr["serialNumber"]);
                                //jsonResult["facility"] = Utility.Helper.gerString(dr["facility"]);
                                //jsonResult["port"] = Utility.Helper.gerString(dr["port"]);
                                jsonResult["price"] = Utility.Helper.gerDecimal(dr["price"]).ToString("0.00");
                                jsonResult["discount"] = Utility.Helper.gerString(dr["discount"]);
                                jsonResult["customid"] = Utility.Helper.gerString(dr["customid"]);
                                jsonResult["pudate"] = Utility.Helper.gerString(dr["pudate"]);
                                jsonResult["paydate"] = Utility.Helper.gerString(dr["paydate"]);


                                jsonResult["startdate"] = Utility.Helper.gerString(dr["paydate"]);

                                jsonResult["enddate"] = "";

                                jsonResult["endminutes"] = 0;//Utility.Helper.gerString(dr["duration"]);
                                jsonResult["endseconds"] = 0;
                                if (dr["paydate"] != null)
                                {
                                    DateTime paydate = Convert.ToDateTime(dr["paydate"]);
                                    DateTime enddate = paydate.AddMinutes(Utility.Helper.gerInt(dr["duration"]));
                                    jsonResult["enddate"] = enddate.ToString();
                                    if (enddate < System.DateTime.Now)
                                    {
                                        jsonResult["endcount"] = 0;
                                    }
                                    else
                                    {
                                        int Minutes = 0;
                                        int Seconds = 0;
                                        AccessTime(out Minutes, out Seconds, enddate, 2);

                                        jsonResult["endminutes"] = Minutes;
                                        jsonResult["endseconds"] = Seconds;
                                    }
                                }
                            }
                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "成功";
                            jsonResult["code"] = "";

                            jsonResult["counts"] = tab.Rows.Count;
                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "未找到该订单";
                            jsonResult["code"] = "";
                            jsonResult["counts"] = 0;
                        }
                        #endregion
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

        /// <summary>
        /// 获取与当前时间的时间差
        /// </summary>
        /// <param name="time">对比时间</param>
        /// <param name="Types">1 当前时间大于 2当前时间小于 </param>
        /// <returns></returns>
        public static void AccessTime(out int Minutes, out int Seconds, DateTime time, int Types)
        {
            Minutes = 0;
            Seconds = 0;
            TimeSpan ts = new TimeSpan();
            switch (Types)
            {
                case 1:
                    ts = System.DateTime.Now.Subtract(time);
                    Minutes = ts.Minutes;
                    Seconds = ts.Seconds;
                    break;
                case 2:
                    ts = time.Subtract(System.DateTime.Now);
                    Minutes = ts.Minutes;
                    Seconds = ts.Seconds;
                    break;
                default:
                    break;
            }
        }
    }
}