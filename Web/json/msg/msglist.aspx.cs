using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;

namespace ZDEnterprise.Web.json.msg
{
    public partial class msglist : System.Web.UI.Page
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
                    //排序值  
                    string strwhere = " ";
                    string strorderby = " id desc ";

                    #region t_msg list

                    string strsql = @" select 
     	    id
     		,title
     		,img
     		,pudate
     		 from  (select *,Row_number() over(order by " + strorderby + " ) as IDRank from t_msg where  1=1 " + strwhere + @"  ) as IDWithRowNumber
  where IDRank>(" + pn + "-1)*" + ps + " and IDRank<=" + pn + "*" + ps + "";

                    DataTable tab = pbll.getDataSet(strsql).Tables[0];

                    //获取分页的条件
                    string numwhere = " select COUNT(1)  from t_msg where  1=1  " + strwhere + @"   ";

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
                                json["title"] = Utility.Helper.gerString(dr["title"]);

                                json["img"] = !string.IsNullOrEmpty(Utility.Helper.gerString(dr["img"])) ? Utility.Helper.getImgUrl(dr["img"]) : Utility.Helper.getImgUrl("/img/moremg.jpg");
                                json["pudate"] = Utility.Helper.gerString(dr["pudate"]);
                            }
                            jsondatas.Add(json);
                        }
                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "成功";
                        jsonResult["code"] = "";
                        jsonResult["count"] = tab.Rows.Count;

                        DataTable tabnum = pbll.getDataSet(numwhere).Tables[0];
                        int numbers = Utility.Helper.gerInt(tabnum.Rows[0][0]);
                        jsonResult["number"] = numbers;
                        jsonResult["totalpages"] = (numbers % int.Parse(ps) == 0 ? numbers / int.Parse(ps) : numbers / int.Parse(ps) + 1);

                        jsonResult["elements"] = jsondatas;
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "数据已全部加载";
                        jsonResult["code"] = "";
                        jsonResult["count"] = tab.Rows.Count;

                        jsonResult["number"] = 0;
                        jsonResult["totalpages"] = 0;
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