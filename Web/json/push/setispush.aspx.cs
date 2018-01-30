using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.json.push
{
    public partial class setispush : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.BLL.publicBLL pbll = new System.BLL.publicBLL();


            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {

                    string memberid = _bll.getUserToke(Utility.Helper.gerString(Request["memberid"]));
                    string statust = Request["statust"] != null ? Utility.Helper.Checkstr(Request["statust"]) : "0";

                    if (!string.IsNullOrEmpty(memberid))
                    {
                        #region 设置是否接受推送

                        string strwhere = " 1=1 ";

                        strwhere += " and customId='" + memberid + "' ";

                        List<System.Model.apush_token> aplist = _bll.atbll.GetModelList(strwhere);

                        if (aplist.Count > 0)
                        {


                            for (int i = 0; i < aplist.Count; i++)
                            {
                                System.Model.apush_token at = aplist[i];
                                _bll.atbll.Update(at);
                            }

                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "成功";
                            jsonResult["code"] = "";

                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "未找到数据,请重新登录";
                            jsonResult["code"] = "";
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

    }
}