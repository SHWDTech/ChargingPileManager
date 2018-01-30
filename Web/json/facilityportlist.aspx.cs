using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.json
{
    public partial class facilityportlist : System.Web.UI.Page
    {

        /// <summary>
        /// 设备列表
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
                    //设备nodeid
                    string nodeid = Request["nodeid"] != null ? Utility.Helper.Checkstr(Request["nodeid"]) : "";

                    #region 提供设备信息

                    if (!string.IsNullOrEmpty(nodeid))
                    {

                        string strwhere = " no='" + nodeid + "' ";

                        List<System.Model.facility> flist = _bll.fbll.GetModelList(strwhere);


                        if (flist.Count == 1)
                        {
                            System.Model.facility fac = flist[0];

                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "";
                            jsonResult["code"] = "";
                            jsonResult["nodeid"] = fac.no;
                            jsonResult["identitycode"] = fac.identitycode;

                            jsonResult["port"] = JsonMapper.ToObject("[]");

                            strwhere = " fid=" + fac.id + " order by id asc ";

                            List<System.Model.facility_port> fplist = _bll.fpbll.GetModelList(strwhere);
                            if (fplist.Count > 0)
                            {
                                JsonData jsonport = new JsonData();
                                for (int i = 0; i < fplist.Count; i++)
                                {
                                    JsonData json = new JsonData();
                                    System.Model.facility_port fp = fplist[i];

                                    json["index"] = i + 1;
                                    json["identitycode"] = fp.identitycode;
                                    json["qrimg"] = "{'portid':'" + fp.toid + "'}";
                                    jsonport.Add(json);
                                }

                                jsonResult["port"] = jsonport;
                            }

                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "未找到该设备";
                            jsonResult["code"] = "设备信息异常";
                        }




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
                }
                res = JsonMapper.ToJson(jsonResult);
                res = MyString.UnicodeToString(res);
                Response.Write(res);

            }

        }
    }
}