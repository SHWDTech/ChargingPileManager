using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;

namespace ZDEnterprise.Web.json.facility
{
    public partial class stipple : System.Web.UI.Page
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
                    string pn = "1";
                    //ps
                    string ps = "1000";
                    //排序值  


                    string strwhere = " and isdel=0 ";



                    string strwhere2 = "  ";

                    //名称
                    string name = Request["name"] != null ? Utility.Helper.Checkstr(Request["name"]) : "";


                    #region 参数组合(按范围)

                    //范围 /公里
                    string scope = Request["scope"] != null ? Utility.Helper.Checkstr(Request["scope"]) : "5";
                    //用户经度
                    string longitude = Request["longitude"] != null ? Utility.Helper.Checkstr(Request["longitude"]) : "121.485462";
                    //用户纬度
                    string latitude = Request["latitude"] != null ? Utility.Helper.Checkstr(Request["latitude"]) : "31.275148";

                    //地图还是列表  地图1 列表2 
                    string islist = Request["islist"] != null ? Utility.Helper.Checkstr(Request["islist"]) : "1";
                    //计算范围内的网点
                    if (!string.IsNullOrEmpty(scope) && !string.IsNullOrEmpty(longitude) && !string.IsNullOrEmpty(latitude))
                    {
                        strwhere2 += "  and jl<= " + scope;
                    }

                    #endregion

                    //id
                    string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";
                    if (!string.IsNullOrEmpty(id))
                    {
                        strwhere += "  and id= " + id + " ";
                    }

                    #region 参数组合(按区域)

                    //省
                    string city1 = Request["city1"] != null ? Utility.Helper.Checkstr(Request["city1"]) : "";
                    //市
                    string city2 = Request["city2"] != null ? Utility.Helper.Checkstr(Request["city2"]) : "";
                    //区
                    string city3 = Request["city3"] != null ? Utility.Helper.Checkstr(Request["city3"]) : "";

                    //计算范围内的网点
                    if (!string.IsNullOrEmpty(city3))
                    {
                        strwhere += "  and city3= '" + city3 + "' ";
                    }
                    if (!string.IsNullOrEmpty(city2))
                    {
                        strwhere += "  and city2= '" + city2 + "' ";
                    }

                    if (!string.IsNullOrEmpty(city1))
                    {
                        strwhere += "  and city1= '" + city1 + "' ";
                    }

                    #endregion


                    if (!string.IsNullOrEmpty(name))
                    {
                        strwhere += " and  name like '%" + name + "%'   ";
                    }

                    string strorderby = " id desc ";

                    #region facility_stipple list

                    if (islist == "1")
                    {
                        //地图模式
                        string strsql = @" select 
     	    id
     		,city3
     		,pudate
     		,isdel
     		,name
     		,no
     		,referral
     		,longitude
     		,latitude
     		,statuses
     		,city1
     		,city2
            ,(select COUNT(1) from facility f where f.fid=IDWithRowNumber.id and  f.isdel=0) facilitynum
            ,(select COUNT(1) from facility f where f.isdel =0 and f.fid in (select id from facility_port fp where fp.fid=IDWithRowNumber.id and fp.isdel=0)) portnum
            from (select *,( 6371 * acos( cos( radians(" + longitude + ") ) * cos( radians( longitude )) * cos( radians( latitude ) - radians(" + latitude + ") ) + sin( radians(" + longitude + ")) * sin( radians( longitude ) ) ) ) as jl ,Row_number() over(order by " + strorderby + " ) as IDRank from facility_stipple where  1=1 " + strwhere + @"  ) as IDWithRowNumber
            where IDRank>(" + pn + "-1)*" + ps + " and IDRank<=" + pn + "*" + ps + "" + strwhere2 + "  order by jl asc ";

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
                                    json["city3"] = Utility.Helper.gerString(dr["city3"]);
                                    json["pudate"] = Utility.Helper.gerString(dr["pudate"]);
                                    //json["jl"] = Utility.Helper.gerString(dr["jl"]);
                                    json["name"] = Utility.Helper.gerString(dr["name"]);
                                    json["no"] = Utility.Helper.gerString(dr["no"]);
                                    json["referral"] = Utility.Helper.gerString(dr["referral"]);
                                    json["longitude"] = Utility.Helper.gerString(dr["longitude"]);
                                    json["latitude"] = Utility.Helper.gerString(dr["latitude"]);
                                    json["statuses"] = Utility.Helper.gerString(dr["statuses"]);
                                    json["city1"] = Utility.Helper.gerString(dr["city1"]);
                                    json["city2"] = Utility.Helper.gerString(dr["city2"]);
                                    json["facilitynum"] = Utility.Helper.gerString(dr["facilitynum"]);
                                    json["portnum"] = Utility.Helper.gerString(dr["portnum"]);
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
                            jsonResult["msg"] = "数据加载成功";
                            jsonResult["code"] = "";
                            jsonResult["count"] = tab.Rows.Count;
                            jsonResult["elements"] = JsonMapper.ToObject("[]");




                        }

                    }
                    else if (islist == "2")
                    {
                        //列表模式
                        //不计算距离
                        strwhere2 = "  ";
                        string strsql = @" select   top 50 
     	    id
     		,city3
     		,pudate
     		,isdel
     		,name
     		,no
     		,referral
     		,longitude
     		,latitude
     		,statuses
     		,city1
     		,city2
            ,(select COUNT(1) from facility f where f.fid=IDWithRowNumber.id and  f.isdel=0) facilitynum
            ,(select COUNT(1) from facility f where f.isdel =0 and f.fid in (select id from facility_port fp where fp.fid=IDWithRowNumber.id and fp.isdel=0)) portnum
            from (select *,( 6371 * acos( cos( radians(" + longitude + ") ) * cos( radians( longitude )) * cos( radians( latitude ) - radians(" + latitude + ") ) + sin( radians(" + longitude + ")) * sin( radians( longitude ) ) ) ) as jl ,Row_number() over(order by " + strorderby + " ) as IDRank from facility_stipple where  1=1 " + strwhere + @"  ) as IDWithRowNumber
            where IDRank>(" + pn + "-1)*" + ps + " and IDRank<=" + pn + "*" + ps + "" + strwhere2 + "  order by jl asc ";

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
                                    json["city3"] = Utility.Helper.gerString(dr["city3"]);
                                    json["pudate"] = Utility.Helper.gerString(dr["pudate"]);
                                    //json["jl"] = Utility.Helper.gerString(dr["jl"]);
                                    json["name"] = Utility.Helper.gerString(dr["name"]);
                                    json["no"] = Utility.Helper.gerString(dr["no"]);
                                    json["referral"] = Utility.Helper.gerString(dr["referral"]);
                                    json["longitude"] = Utility.Helper.gerString(dr["longitude"]);
                                    json["latitude"] = Utility.Helper.gerString(dr["latitude"]);
                                    json["statuses"] = Utility.Helper.gerString(dr["statuses"]);
                                    json["city1"] = Utility.Helper.gerString(dr["city1"]);
                                    json["city2"] = Utility.Helper.gerString(dr["city2"]);
                                    json["facilitynum"] = Utility.Helper.gerString(dr["facilitynum"]);
                                    json["portnum"] = Utility.Helper.gerString(dr["portnum"]);
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
                            jsonResult["msg"] = "数据加载成功";
                            jsonResult["code"] = "";
                            jsonResult["count"] = tab.Rows.Count;
                            jsonResult["elements"] = JsonMapper.ToObject("[]");
                        }
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
