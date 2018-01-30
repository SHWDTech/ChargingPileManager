﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;

namespace ZDEnterprise.Web.json.city
{
    public partial class province : System.Web.UI.Page
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


                    string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";


                    string name = Request["name"] != null ? Utility.Helper.Checkstr(Request["name"]) : "";
                    //排序值  
                    string strwhere = " ";
                    string strorderby = " id desc ";



                    if (!string.IsNullOrEmpty(id))
                    {
                        strwhere += " and id=" + id + " ";
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        strwhere = " and province like '%" + name + "%' ";
                    }

                    #region t_city1 list

                    string strsql = @" select 
     	     		id
     		        ,provinceid
     		        ,province
     		 from  (select *,Row_number() over(order by " + strorderby + " ) as IDRank from t_city1 where  1=1 " + strwhere + @"  ) as IDWithRowNumber";
                    //" where IDRank>(" + pn + "-1)*" + ps + " and IDRank<=" + pn + "*" + ps + "";

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
                                json["provinceid"] = Utility.Helper.gerString(dr["provinceID"]);
                                json["province"] = Utility.Helper.gerString(dr["province"]);
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





