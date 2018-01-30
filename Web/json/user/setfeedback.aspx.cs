using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;

namespace ZDEnterprise.Web.json.user
{
    public partial class setfeedback : System.Web.UI.Page
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

                    string text = Request["text"] != null ? Utility.Helper.Checkstr(Request["text"]) : "";

                    #region 意见反馈

                    if (!string.IsNullOrEmpty(memberid) && !string.IsNullOrEmpty(text))
                    {

                        System.Model.t_custom_feedback tcf = new System.Model.t_custom_feedback();
                        tcf.customId = memberid;
                        tcf.memo = text;
                        tcf.pudate = System.DateTime.Now.ToString();
                        _bll.tcfbll.Add(tcf);

                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "已收到您的反馈,我们会尽快处理";
                       
                        jsonResult["code"] = "";

                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "反馈失败了";
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