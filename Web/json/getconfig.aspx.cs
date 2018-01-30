using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.json
{
    public partial class getconfig : System.Web.UI.Page
    {

        /// <summary>
        /// 获取配置
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
                    //配置标识
                    string toid = Request["toid"] != null ? Utility.Helper.Checkstr(Request["toid"]) : "";

                    #region 获取系统配置

                    if (!string.IsNullOrEmpty(toid))
                    {
                        string strwhere = "   toid='" + toid + "'  ";

                        List<System.Model.System_Config> sclist = _bll.scbll.GetModelList(strwhere);
                        if (sclist.Count > 0)
                        {

                            string strvalue = sclist[0].value;
                            string msgmemo = sclist[0].msg;


                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "";
                            jsonResult["config"] = strvalue;
                            jsonResult["memo"] = msgmemo;
                            jsonResult["code"] = "";

                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "";
                            jsonResult["config"] = "";
                            jsonResult["memo"] = "";
                            jsonResult["code"] = "未找到该配置";
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