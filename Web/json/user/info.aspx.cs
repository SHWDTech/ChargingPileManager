using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.json.user
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {

                    string memberid = _bll.getUserToke(Utility.Helper.gerString(Request["memberid"]));

                    if (!string.IsNullOrEmpty(memberid))
                    {
                        //判断是否有用户




                        System.Model.t_custom tclist = _bll.tcbll.GetModel(Utility.Helper.gerInt(memberid));

                        if (tclist != null)
                        {
                            string strwhere = " customId='" + memberid + "'  ";
                            List<System.Model.apush_token> at = _bll.atbll.GetModelList(strwhere);
                            int ispush = 0;
                            if (at.Count > 0)
                            {
                                ispush = at[0].isstartusing;
                            }

                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "登录成功";
                            jsonResult["memberid"] = memberid;
                            jsonResult["phone"] = tclist.phone;
                            jsonResult["ispust"] = ispush;
                            jsonResult["code"] = "";

                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "未找到用户";
                            jsonResult["memberid"] = "";
                            jsonResult["code"] = "用户信息有误";

                        }
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "登录失败";
                        jsonResult["memberid"] = "";
                        jsonResult["code"] = "参数缺失";

                    }

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