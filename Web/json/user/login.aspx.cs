using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;

namespace ZDEnterprise.Web.json.user
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {

                    string phone = Request["phone"] != null ? Utility.Helper.Checkstr(Request["phone"]) : "";

                    string authcode = Request["authcode"] != null ? Utility.Helper.Checkstr(Request["authcode"]) : "";

                    string pushtype = Request["pushtype"] != null ? Utility.Helper.Checkstr(Request["pushtype"]) : "";

                    string token = Request["token"] != null ? Utility.Helper.Checkstr(Request["token"]) : "";

                    #region 登录

                    //log.setlog("", phone + " " + authcode + "  " + pushtype + " " + token);

                    if (!string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(authcode))
                    {
                        //判断是否有用户

                        string memberid = "";

                        string strwhere = " phone='" + phone + "' ";


                        string authcodeSession = Session["authcode"] as string;


                        string vcodewhere = " verificationMode ='" + phone + "' and  code='" + authcode + "' and edate> '" + System.DateTime.Now + "' ";

                        List<System.Model.verification_code> vc = _bll.vcbll.GetModelList(vcodewhere);

                        if (vc.Count > 0)
                        {
                            //if (!string.IsNullOrEmpty(authcodeSession))
                            //{
                            List<System.Model.t_custom> tclist = _bll.tcbll.GetModelList(strwhere);

                            if (tclist.Count > 0)
                            {
                                //有 直接登录 添加登录日志

                                memberid = tclist[0].id.ToString();

                                System.Model.t_login_log tll = new System.Model.t_login_log();
                                tll.phone = phone;
                                tll.authcode = authcode;
                                tll.pudate = System.DateTime.Now;
                                _bll.tllbll.Add(tll);
                            }
                            else
                            {
                                //无 添加用户 登录 添加登录日志
                                System.Model.t_custom tc = new System.Model.t_custom();
                                tc.img = "";
                                tc.name = "";
                                tc.nicheng = "";
                                tc.phone = phone;
                                tc.pudate = System.DateTime.Now.ToString();
                                tc.pwd = "";
                                tc.syJf = 0;
                                tc.syMoney = 0;
                                tc.yqm = Utility.Helper.rnds(6);
                                _bll.tcbll.Add(tc);

                                List<System.Model.t_custom> tclist1 = _bll.tcbll.GetModelList(strwhere);

                                if (tclist1.Count > 0)
                                {
                                    memberid = tclist1[0].id.ToString();

                                    System.Model.t_login_log tll = new System.Model.t_login_log();
                                    tll.phone = phone;
                                    tll.authcode = authcode;
                                    tll.pudate = System.DateTime.Now;
                                    _bll.tllbll.Add(tll);
                                }

                            }


                            #region 判断token是否有用

                            if (!string.IsNullOrEmpty(pushtype) && !string.IsNullOrEmpty(token))
                            {
                                addpushtoken(memberid, pushtype, token);
                            }
                            #endregion

                            strwhere = " customId='" + memberid + "' and device='" + pushtype + "'  ";
                            List<System.Model.apush_token> at = _bll.atbll.GetModelList(strwhere);
                            int ispush = 0;
                            if (at.Count > 0)
                            {
                                ispush = at[0].isstartusing;
                            }


                            jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                            jsonResult["msg"] = "登录成功";
                            jsonResult["memberid"] = memberid;
                            jsonResult["phone"] = phone;
                            jsonResult["ispust"] = ispush;
                            jsonResult["code"] = "";

                        }
                        else
                        {
                            jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                            jsonResult["msg"] = "登录失败";
                            jsonResult["memberid"] = "";
                            jsonResult["code"] = "验证码失效";
                        }
                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "登录失败";
                        jsonResult["memberid"] = "";
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







        /// <summary>
        /// 添加推送token(个推)
        /// </summary>
        /// <param name="memberid">用户id</param>
        /// <param name="pushtype">设备类型(android/ios)</param>
        /// <param name="token">token</param>
        /// <returns></returns>
        public bool addpushtoken(string memberid, string pushtype, string token)
        {

            bool ispush = false;


            string strwhere = " 1=1 ";
            int Device = 1;
            if (pushtype == "android")
            {
                Device = 1;
            }
            else if (pushtype == "ios")
            {
                Device = 2;
            }
            strwhere += " and customId='" + memberid + "' and clientType=" + Device + " ";

            List<System.Model.apush_token> aplist = _bll.atbll.GetModelList(strwhere);

            if (aplist.Count > 0)
            {
                System.Model.apush_token at = aplist[0];

                if (token == at.token)
                {
                    ispush = true;
                }
                else
                {
                    at.token = token;
                    _bll.atbll.Update(at);
                    ispush = true;
                }
            }
            else
            {
                System.Model.apush_token at = new System.Model.apush_token();
                at.token = token;
                at.clientType = Device;
                at.customId = memberid;
                at.device = pushtype;
                at.isstartusing = 1;
                _bll.atbll.Add(at);
                ispush = true;
            }
            return ispush;

        }
    }
}