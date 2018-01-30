using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.payload;
using LitJson;
using System;
using System.Collections.Generic;

namespace GeTuiHelper
{
    public class Push
    {
        private static string APPID = "";
        private static string APPKEY = "";
        private static string MASTERSECRET = "";
        private static string HOST = "http://sdk.open.api.igexin.com/apiex.htm";
        private static string LOGOURL = "";
        public static string errorMsg = "";
        public static void PushInit(string appid, string appkey, string mastersercet, string logourl)
        {
            Push.APPID = appid;
            Push.APPKEY = appkey;
            Push.MASTERSECRET = mastersercet;
            Push.LOGOURL = logourl;
        }
        public static bool PushMsgToLoginOut(string clientid)
        {
            TransmissionTemplate transTemplate = Push.GetTransTemplate("loginout");
            return Push.PushMsgToSingleDevice(clientid, transTemplate);
        }
        public static bool SendTransMsgToSingle(string clientid, string content)
        {
            TransmissionTemplate transTemplate = Push.GetTransTemplate(content);
            return Push.PushMsgToSingleDevice(clientid, transTemplate);
        }
        public static bool SendNotiMsgToSingle(string clientid, string title, string content, bool isIOS)
        {
            if (isIOS)
            {
                TransmissionTemplate iOSNotiTemplate = Push.GetIOSNotiTemplate(title, content);
                return Push.PushMsgToSingleDevice(clientid, iOSNotiTemplate);
            }
            NotificationTemplate androidNotiTemplate = Push.GetAndroidNotiTemplate(title, content);
            return Push.PushMsgToSingleDevice(clientid, androidNotiTemplate);
        }
        public static bool SendLinkMsgToSingle(string clientid, string title, string content, string linkurl)
        {
            LinkTemplate linkTemplate = Push.GetLinkTemplate(title, content, linkurl);
            return Push.PushMsgToSingleDevice(clientid, linkTemplate);
        }
        public static bool SendNotyPopMsgToSingle(string clientid, string title, string content, string poptitle, string popcontent, string downloadtitle, string downloadurl)
        {
            NotyPopLoadTemplate notyPopTemplate = Push.GetNotyPopTemplate(title, content, poptitle, popcontent, downloadtitle, downloadurl);
            return Push.PushMsgToSingleDevice(clientid, notyPopTemplate);
        }
        public static bool SendTransMsgToList(List<string> clientidlist, string content)
        {
            TransmissionTemplate transTemplate = Push.GetTransTemplate(content);
            return Push.PushMsgToList(clientidlist, transTemplate);
        }
        public static bool SendNotiMsgToList(List<string> clientidlist, string title, string content, bool isIOS)
        {
            if (isIOS)
            {
                TransmissionTemplate iOSNotiTemplate = Push.GetIOSNotiTemplate(title, content);
                return Push.PushMsgToList(clientidlist, iOSNotiTemplate);
            }
            NotificationTemplate androidNotiTemplate = Push.GetAndroidNotiTemplate(title, content);
            return Push.PushMsgToList(clientidlist, androidNotiTemplate);
        }
        public static bool SendLinkMsgToList(List<string> clientidlist, string title, string content, string linkurl)
        {
            LinkTemplate linkTemplate = Push.GetLinkTemplate(title, content, linkurl);
            return Push.PushMsgToList(clientidlist, linkTemplate);
        }
        public static bool SendNotyPopMsgToList(List<string> clientidlist, string title, string content, string poptitle, string popcontent, string downloadtitle, string downloadurl)
        {
            NotyPopLoadTemplate notyPopTemplate = Push.GetNotyPopTemplate(title, content, poptitle, popcontent, downloadtitle, downloadurl);
            return Push.PushMsgToList(clientidlist, notyPopTemplate);
        }
        private static bool PushMsgToSingleDevice(string clientid, ITemplate msgTemplate)
        {
            bool result = false;
            try
            {
                IGtPush gtPush = new IGtPush(Push.HOST, Push.APPKEY, Push.MASTERSECRET);
                IBatch batch = gtPush.getBatch();
                SingleMessage singleMessage = new SingleMessage();
                singleMessage.IsOffline = true;
                singleMessage.OfflineExpireTime = 2073600000L;
                singleMessage.Data = msgTemplate;
                Target target = new Target();
                target.appId = Push.APPID;
                target.clientId = clientid;
                batch.add(singleMessage, target);
                try
                {
                    Push.errorMsg = batch.submit();
                    JsonData jsonData = MyCommon.JsonStrToObj(Push.errorMsg);
                    string jsonObjValue = MyCommon.getJsonObjValue(jsonData, "result");
                    if (jsonObjValue.ToLower() == "ok")
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    Push.errorMsg = batch.retry();
                    JsonData jsonData2 = MyCommon.JsonStrToObj(Push.errorMsg);
                    string jsonObjValue2 = MyCommon.getJsonObjValue(jsonData2, "result");
                    if (jsonObjValue2.ToLower() == "ok")
                    {
                        result = true;
                    }
                    Push.errorMsg += ex.Message;
                }
            }
            catch (Exception ex2)
            {
                Push.errorMsg += ex2.Message;
            }
            return result;
        }
        private static bool PushMsgToList(List<string> clientidlist, ITemplate msgTemplate)
        {
            bool result = false;
            try
            {
                IGtPush gtPush = new IGtPush(Push.HOST, Push.APPKEY, Push.MASTERSECRET);
                ListMessage listMessage = new ListMessage();
                listMessage.IsOffline = true;
                listMessage.OfflineExpireTime = 2073600000L;
                listMessage.Data = msgTemplate;
                List<Target> list = new List<Target>();
                for (int i = 0; i < clientidlist.Count; i++)
                {
                    string text = clientidlist[i];
                    if (!string.IsNullOrEmpty(text))
                    {
                        Target target = new Target();
                        target.appId = Push.APPID;
                        target.clientId = text;
                        list.Add(target);
                    }
                }
                string contentId = gtPush.getContentId(listMessage, "msgpush");
                Push.errorMsg = gtPush.pushMessageToList(contentId, list);
                JsonData jsonData = MyCommon.JsonStrToObj(Push.errorMsg);
                string jsonObjValue = MyCommon.getJsonObjValue(jsonData, "result");
                if (jsonObjValue.ToLower() == "ok")
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Push.errorMsg += ex.Message;
            }
            return result;
        }
        private static TransmissionTemplate GetTransTemplate(string content)
        {
            TransmissionTemplate transmissionTemplate = new TransmissionTemplate();
            transmissionTemplate.AppId = Push.APPID;
            transmissionTemplate.AppKey = Push.APPKEY;
            transmissionTemplate.TransmissionType = "2";
            transmissionTemplate.TransmissionContent = content;
            return transmissionTemplate;
        }
        private static TransmissionTemplate GetIOSNotiTemplate(string title, string content)
        {
            TransmissionTemplate transmissionTemplate = new TransmissionTemplate();
            transmissionTemplate.AppId = Push.APPID;
            transmissionTemplate.AppKey = Push.APPKEY;
            transmissionTemplate.TransmissionType = "2";
            transmissionTemplate.TransmissionContent = "newmsg";
            APNPayload aPNPayload = new APNPayload();
            DictionaryAlertMsg dictionaryAlertMsg = new DictionaryAlertMsg();
            dictionaryAlertMsg.Body = content;
            dictionaryAlertMsg.ActionLocKey = "";
            dictionaryAlertMsg.LocKey = "";
            dictionaryAlertMsg.addLocArg("");
            dictionaryAlertMsg.LaunchImage = "";
            dictionaryAlertMsg.Title = title;
            dictionaryAlertMsg.TitleLocKey = "";
            dictionaryAlertMsg.addTitleLocArg("");
            aPNPayload.AlertMsg = dictionaryAlertMsg;
            aPNPayload.ContentAvailable = 1;
            aPNPayload.Sound = "";
            aPNPayload.addCustomMsg("payload", "payload");
            transmissionTemplate.setAPNInfo(aPNPayload);
            return transmissionTemplate;
        }
        private static NotificationTemplate GetAndroidNotiTemplate(string title, string content)
        {
            NotificationTemplate notificationTemplate = new NotificationTemplate();
            notificationTemplate.AppId = Push.APPID;
            notificationTemplate.AppKey = Push.APPKEY;
            notificationTemplate.Title = title;
            notificationTemplate.Text = content;
            notificationTemplate.Logo = "";
            notificationTemplate.LogoURL = Push.LOGOURL;
            notificationTemplate.TransmissionType = "2";
            notificationTemplate.TransmissionContent = "newmsg";
            notificationTemplate.IsRing = true;
            notificationTemplate.IsVibrate = true;
            notificationTemplate.IsClearable = true;
            return notificationTemplate;
        }
        private static LinkTemplate GetLinkTemplate(string title, string content, string linkurl)
        {
            LinkTemplate linkTemplate = new LinkTemplate();
            linkTemplate.AppId = Push.APPID;
            linkTemplate.AppKey = Push.APPKEY;
            linkTemplate.Title = title;
            linkTemplate.Text = content;
            linkTemplate.Logo = "";
            linkTemplate.LogoURL = Push.LOGOURL;
            linkTemplate.Url = linkurl;
            linkTemplate.IsRing = true;
            linkTemplate.IsVibrate = true;
            linkTemplate.IsClearable = true;
            return linkTemplate;
        }
        private static NotyPopLoadTemplate GetNotyPopTemplate(string title, string content, string poptitle, string popcontent, string downloadtitle, string downloadurl)
        {
            NotyPopLoadTemplate notyPopLoadTemplate = new NotyPopLoadTemplate();
            notyPopLoadTemplate.AppId = Push.APPID;
            notyPopLoadTemplate.AppKey = Push.APPKEY;
            notyPopLoadTemplate.NotyTitle = title;
            notyPopLoadTemplate.NotyContent = content;
            notyPopLoadTemplate.NotyIcon = "";
            notyPopLoadTemplate.LogoURL = Push.LOGOURL;
            notyPopLoadTemplate.PopTitle = poptitle;
            notyPopLoadTemplate.PopContent = popcontent;
            notyPopLoadTemplate.PopImage = "";
            notyPopLoadTemplate.PopButton1 = "下载";
            notyPopLoadTemplate.PopButton2 = "取消";
            notyPopLoadTemplate.LoadTitle = downloadtitle;
            notyPopLoadTemplate.LoadIcon = Push.LOGOURL;
            notyPopLoadTemplate.LoadUrl = downloadurl;
            notyPopLoadTemplate.IsActived = true;
            notyPopLoadTemplate.IsAutoInstall = true;
            notyPopLoadTemplate.IsBelled = true;
            notyPopLoadTemplate.IsVibrationed = true;
            notyPopLoadTemplate.IsCleared = true;
            return notyPopLoadTemplate;
        }
    }

    public static class Version
    {
        public static string curVersion = "1.0.0";
        public static string author = "Daniel Lu";
        public static string qq = "378274946";
        public static string updateDate = "2016-08-10";
        public static string readme = "使用此个推帮助类库请先引用 GetuiServerApiSDK.dll、Google.ProtocolBuffers.dll、log4net.dll、LitJSON.dll、CommonHelper.dll（类库版本1.5及以上-CommonHelper.Version.curVersion值即为CommonHelper类库版本号），感谢您使用此类库";
    }
}