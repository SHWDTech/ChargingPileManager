using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.json.user
{
    public partial class delete : System.Web.UI.Page
    {
        System.BLL.t_custom t_custombll = new System.BLL.t_custom();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {
                    string id = Request["id"] != null ? Utility.Helper.Checkstr(Request["id"]) : "";
                    #region 删除
                    if (!string.IsNullOrEmpty(id))
                    {
                        if (t_custombll.Delete(int.Parse(id)))
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "删除成功";
                            jsonResult["code"] = "";
                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "删除失败";
                            jsonResult["code"] = "";
                        }
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "删除失败";
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