using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LitJson;

namespace ZDEnterprise.Web.json.city
{
    public partial class city : System.Web.UI.Page
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
                    //string pn = Request["pn"] != null ? Utility.Helper.Checkstr(Request["pn"]) : "1";
                    //ps
                    //string ps = Request["ps"] != null ? Utility.Helper.Checkstr(Request["ps"]) : "10";

                    string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";

                    string father = Request["father"] != null ? Utility.Helper.Checkstr(Request["father"]) : "";

                    string name = Request["name"] != null ? Utility.Helper.Checkstr(Request["name"]) : "";



                    //排序值  
                    string strwhere = " ";
                    string strorderby = " id desc ";

                    if (!string.IsNullOrEmpty(id))
                    {
                        strwhere = " and id=" + id + " ";
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        strwhere = " and city like '%" + name + "%' ";
                    }

                    if (!string.IsNullOrEmpty(father))
                    {
                        strwhere = " and father ='" + father + "' ";
                    }

                    #region t_city2 list

                    string strsql = @" select 
            id
     		,cityid
     		,city
     		,father
     		 from  (select *,Row_number() over(order by " + strorderby + " ) as IDRank from t_city2 where  1=1 " + strwhere + @"  ) as IDWithRowNumber ";
                    //where IDRank>(" + pn + "-1)*" + ps + " and IDRank<=" + pn + "*" + ps + "";

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
                                json["cityid"] = Utility.Helper.gerString(dr["cityID"]);
                                json["city"] = Utility.Helper.gerString(dr["city"]);
                                json["father"] = Utility.Helper.gerString(dr["father"]);
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