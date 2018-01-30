using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.payload;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;

namespace System.MyUtility
{
    public static class PushGeTuiHelper
    {
        //参数设置 <-----参数需要重新设置----->

        private static String APPID = "zuGyrgYbnm8UpQ0agSSPf1";                     //您应用的AppId
        private static String APPKEY = "OJrMkqVUeaAyWK5MbXqed1";                    //您应用的AppKey
        private static String MASTERSECRET = "P4VmDcWHea8PMRcj6IsMq3";              //您应用的MasterSecret 
        private static String CLIENTID = "";        //您获取的clientID

        //private static String CLIENTID1 = "";
        private static String ALIAS = "请输入别名";
        private static String ALIAS1 = "别名1";
        private static String HOST = "http://sdk.open.api.igexin.com/apiex.htm";    //HOST：OpenService接口地址
        private static String DeviceToken = "";  //填写IOS系统的DeviceToken

        public static void getPushResult()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            //String ret = push.getPushResult("OSA-0312_oPv6vL62zgA3JU942ZO3S");
            //System.Console.WriteLine(ret);

            //System.Console.WriteLine(push.queryAppPushDataByDate(APPID, "20150612"));
            System.Console.WriteLine(push.queryAppUserDataByDate(APPID, "20150525"));


        }

        public static void getUserTags()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.getUserTags(APPID, CLIENTID);
            System.Console.WriteLine(ret);
        }

        public static void bindAlias()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.bindAlias(APPID, ALIAS, CLIENTID);
            System.Console.WriteLine(ret);
        }

        public static void queryAlias()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.queryAlias(APPID, CLIENTID);
            System.Console.WriteLine(ret);
        }

        public static void queryClientId()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.queryClientId(APPID, ALIAS);
            System.Console.WriteLine(ret);
        }

        public static void aliasUnBind()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.unBindAlias(APPID, ALIAS, CLIENTID);
            System.Console.WriteLine(ret);
        }

        public static void bindAliasAll()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            List<com.igetui.api.openservice.igetui.Target> Lcids = new List<com.igetui.api.openservice.igetui.Target>();
            com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
            target.clientId = CLIENTID;
            target.alias = ALIAS;

            com.igetui.api.openservice.igetui.Target target1 = new com.igetui.api.openservice.igetui.Target();
            target1.clientId = "7c6edf411568c5db12e565425e4a381633";
            target1.alias = ALIAS1;


            Lcids.Add(target);
            Lcids.Add(target1);

            String ret = push.bindAlias(APPID, Lcids);
            System.Console.WriteLine(ret);
        }

        public static void aliasUnBindAll()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.unBindAliasAll(APPID, ALIAS);
            System.Console.WriteLine(ret);
        }

        public static void setTag()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);

            List<String> list = new List<String>();
            list.Add("");
            String ret = push.setClientTag(APPID, CLIENTID, list);
            System.Console.WriteLine(ret);
        }


        public static void taskStop()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            Boolean result = push.stop("OSA-0615_XHyhC4s3cgAdRw7CSpaPx3");
            System.Console.WriteLine("-----------------------------------------------");
            System.Console.WriteLine(result);
        }


        public static void apnPush(string title, string text, string iconUrl, List<string> pushChannels)
        {

            //APN简单推送
            //IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            //APNTemplate template = new APNTemplate();
            //APNPayload apnpayload = new APNPayload();
            //SimpleAlertMsg alertMsg = new SimpleAlertMsg("");
            //apnpayload.AlertMsg = alertMsg;
            //apnpayload.Badge = 11;
            //apnpayload.ContentAvailable = 1;
            //apnpayload.Category = "";
            //apnpayload.Sound = "com.gexin.ios.silence";
            //apnpayload.addCustomMsg("", "");
            //template.setAPNInfo(apnpayload);

            //APN高级推送
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            APNTemplate template = new APNTemplate();
            APNPayload apnpayload = new APNPayload();
            DictionaryAlertMsg alertMsg = new DictionaryAlertMsg();
            alertMsg.Body = text;
            alertMsg.ActionLocKey = title;
            alertMsg.LocKey = title;
            alertMsg.addLocArg("");
            alertMsg.LaunchImage = iconUrl;
            //IOS8.2支持字段
            alertMsg.Title = "";
            alertMsg.TitleLocKey = "";
            alertMsg.addTitleLocArg("");

            apnpayload.AlertMsg = alertMsg;
            apnpayload.Badge = 10;
            apnpayload.ContentAvailable = 1;
            apnpayload.Category = "";
            apnpayload.Sound = "";
            apnpayload.addCustomMsg("", "");
            template.setAPNInfo(apnpayload);



            /*单个用户推送接口*/
            //SingleMessage Singlemessage = new SingleMessage();
            //Singlemessage.Data = template;
            //String pushResult = push.pushAPNMessageToSingle(APPID, DeviceToken, Singlemessage);
            //Console.Out.WriteLine(pushResult);

            /*多个用户推送接口*/
            ListMessage listmessage = new ListMessage();
            listmessage.Data = template;
            String contentId = push.getAPNContentId(APPID, listmessage);
            //Console.Out.WriteLine(contentId);
            //List<String> devicetokenlist = new List<string>();
            //devicetokenlist.Add(DeviceToken);
            //String ret = push.pushAPNMessageToList(APPID, contentId, devicetokenlist);
            //Console.Out.WriteLine(ret);
            String ret = push.pushAPNMessageToList(APPID, contentId, pushChannels);
        }

        //PushMessageToSingle接口测试代码
        //public static void PushMessageToSingle()
        //{
        //    // 推送主类
        //    IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);

        //    /*消息模版：
        //        1.TransmissionTemplate:透传模板
        //        2.LinkTemplate:通知链接模板
        //        3.NotificationTemplate：通知透传模板
        //        4.NotyPopLoadTemplate：通知弹框下载模板
        //     */

        //    TransmissionTemplate template = TransmissionTemplateDemo();
        //    //NotificationTemplate template =  NotificationTemplateDemo();
        //    //LinkTemplate template = LinkTemplateDemo();
        //    //NotyPopLoadTemplate template = NotyPopLoadTemplateDemo();


        //    // 单推消息模型
        //    SingleMessage message = new SingleMessage();
        //    message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
        //    message.OfflineExpireTime = 1000 * 3600 * 12;            // 离线有效时间，单位为毫秒，可选
        //    message.Data = template;
        //    //message.PushNetWorkType = 1;        //判断是否客户端是否wifi环境下推送，1为在WIFI环境下，0为非WIFI环境

        //    com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
        //    target.appId = APPID;
        //    target.clientId = CLIENTID;
        //    //target.alias = ALIAS;

        //    try
        //    {
        //        String pushResult = push.pushMessageToSingle(message, target);

        //        System.Console.WriteLine("-----------------------------------------------");
        //        System.Console.WriteLine("-----------------------------------------------");
        //        System.Console.WriteLine("----------------服务端返回结果：" + pushResult);
        //    }
        //    catch (RequestException e)
        //    {
        //        String requestId = e.RequestId;
        //        String pushResult = push.pushMessageToSingle(message, target, requestId);
        //        System.Console.WriteLine("-----------------------------------------------");
        //        System.Console.WriteLine("-----------------------------------------------");
        //        System.Console.WriteLine("----------------服务端返回结果：" + pushResult);
        //    }
        //}

        public static void PushMessageToSingleBatch()
        {
            // 推送主类
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            IBatch Batch = push.getBatch();

            /*消息模版：
                1.TransmissionTemplate:透传模板
                2.LinkTemplate:通知链接模板
                3.NotificationTemplate：通知透传模板
                4.NotyPopLoadTemplate：通知弹框下载模板
             */

            //TransmissionTemplate template = TransmissionTemplateDemo();

            NotificationTemplate template = NotificationTemplateDemo();
            template.Title = "程序推送";
            template.Text = "这是推送的内容";
            //LinkTemplate template = LinkTemplateDemo();
            //NotyPopLoadTemplate template = NotyPopLoadTemplateDemo();


            // 单推消息模型
            SingleMessage message = new SingleMessage();
            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;            // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //message.PushNetWorkType = 1;        //判断是否客户端是否wifi环境下推送，1为在WIFI环境下，0为非WIFI环境

            com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
            target.appId = APPID;
            target.clientId = CLIENTID;

            Batch.add(message, target);

            try
            {
                String pushResult = Batch.submit();

                System.Console.WriteLine("-----------------------------------------------");
                System.Console.WriteLine("-----------------------------------------------");
                System.Console.WriteLine("----------------服务端返回结果：" + pushResult);
            }
            catch (Exception e)
            {
                String pushResult = Batch.retry();
                System.Console.WriteLine("-----------------------------------------------");
                System.Console.WriteLine("-----------------------------------------------");
                System.Console.WriteLine("----------------服务端返回结果：" + pushResult);
            }
        }
        //PushMessageToList接口测试代码推送

        //安卓推送
        public static void PushMessageToList(string title, string text, string transmissioncontent, string iconUrl, List<string> pushChannels)
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);

            ListMessage message = new ListMessage();
            /*消息模版：
                 1.TransmissionTemplate:透传功能模板
                 2.LinkTemplate:通知打开链接功能模板
                 3.NotificationTemplate：通知透传功能模板
                 4.NotyPopLoadTemplate：通知弹框下载功能模板
             */
            NotificationTemplate template = NotificationTemplateDemo();
            template.Title = title;
            template.Text = text;
            template.Logo = "icon.png";
            template.LogoURL = iconUrl;
            template.TransmissionContent = transmissioncontent;

            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;            // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //message.PushNetWorkType = 0;             //判断是否客户端是否wifi环境下推送，1为在WIFI环境下，0为非WIFI环境

            //设置接收者
            List<com.igetui.api.openservice.igetui.Target> targetList = new List<com.igetui.api.openservice.igetui.Target>();
            for (int i = 0; i < pushChannels.Count; i++)
            {
                string clientId = pushChannels[i];
                if (!string.IsNullOrEmpty(clientId))
                {
                    // 如需要，可以设置多个接收者
                    com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
                    target.appId = APPID;
                    target.clientId = clientId;
                    //target1.alias = ALIAS;
                    targetList.Add(target);
                }
            }

            String contentId = push.getContentId(message, "msgpush");
            String pushResult = push.pushMessageToList(contentId, targetList);
        }

        //IOS推送
        public static void PushTCMessageToList(string title, string text, string transmissioncontent, string iconUrl, List<string> pushChannels)
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);

            ListMessage message = new ListMessage();
            /*消息模版：
                 1.TransmissionTemplate:透传功能模板
                 2.LinkTemplate:通知打开链接功能模板
                 3.NotificationTemplate：通知透传功能模板
                 4.NotyPopLoadTemplate：通知弹框下载功能模板
             */

            TransmissionTemplate template = TransmissionTemplateDemo(title, text, transmissioncontent, iconUrl, pushChannels);
            template.TransmissionContent = transmissioncontent;

            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;            // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //message.PushNetWorkType = 0;             //判断是否客户端是否wifi环境下推送，1为在WIFI环境下，0为非WIFI环境

            //设置接收者
            List<com.igetui.api.openservice.igetui.Target> targetList = new List<com.igetui.api.openservice.igetui.Target>();
            for (int i = 0; i < pushChannels.Count; i++)
            {
                string clientId = pushChannels[i];
                if (!string.IsNullOrEmpty(clientId))
                {
                    // 如需要，可以设置多个接收者
                    com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
                    target.appId = APPID;
                    target.clientId = clientId;
                    //target1.alias = ALIAS;
                    targetList.Add(target);
                }
            }

            String contentId = push.getContentId(message, "msgpush");
            String pushResult = push.pushMessageToList(contentId, targetList);
        }

        //pushMessageToApp接口测试代码
        private static void pushMessageToApp()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);

            AppMessage message = new AppMessage();
            /*消息模版：
                1.TransmissionTemplate:透传模板
                2.LinkTemplate:通知链接模板
                3.NotificationTemplate：通知透传模板
                4.NotyPopLoadTemplate：通知弹框下载模板
             */

            //TransmissionTemplate template =  TransmissionTemplateDemo();
            NotificationTemplate template = NotificationTemplateDemo();
            //LinkTemplate template = LinkTemplateDemo();
            //NotyPopLoadTemplate template = NotyPopLoadTemplateDemo();

            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;            // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //message.PushNetWorkType = 0;            //判断是否客户端是否wifi环境下推送，1为在WIFI环境下，0为非WIFI环境
            //message.Speed = 1;

            List<String> appIdList = new List<string>();
            appIdList.Add(APPID);

            List<String> phoneTypeList = new List<string>();    //通知接收者的手机操作系统类型
            //phoneTypeList.Add("ANDROID");
            //phoneTypeList.Add("IOS");

            List<String> provinceList = new List<string>();     //通知接收者所在省份
            //provinceList.Add("浙江");
            //provinceList.Add("上海");
            //provinceList.Add("北京");

            List<String> tagList = new List<string>();
            tagList.Add("中文");

            message.AppIdList = appIdList;
            message.PhoneTypeList = phoneTypeList;
            message.ProvinceList = provinceList;
            message.TagList = tagList;


            String pushResult = push.pushMessageToApp(message, "toAPP任务别名");
            System.Console.WriteLine("-----------------------------------------------");
            System.Console.WriteLine("服务端返回结果：" + pushResult);
        }


        /*
         * 
         * 所有推送接口均支持四个消息模板，依次为透传模板，通知透传模板，通知链接模板，通知弹框下载模板
         * 注：IOS离线推送需通过APN进行转发，需填写pushInfo字段，目前仅不支持通知弹框下载功能
         *
         */
        //透传模板动作内容
        public static TransmissionTemplate TransmissionTemplateDemo(string title, string text, string transmissioncontent, string iconUrl, List<string> pushChannels)
        {
            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            template.TransmissionType = "2";            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionContent = "";  //透传内容
            //iOS简单推送
            //APNPayload apnpayload = new APNPayload();
            //SimpleAlertMsg alertMsg = new SimpleAlertMsg("alertMsg");
            //apnpayload.AlertMsg = alertMsg;
            //apnpayload.Badge = 11;
            //apnpayload.ContentAvailable = 1;
            //apnpayload.Category = "";
            //apnpayload.Sound = "";
            //apnpayload.addCustomMsg("", "");
            //template.setAPNInfo(apnpayload);

            //APN高级推送
            APNPayload apnpayload = new APNPayload();
            DictionaryAlertMsg alertMsg = new DictionaryAlertMsg();
            if (text == "您有一个任务将在1小时后截止，请尽快完成")
            {
                alertMsg.Body = "您有一个任务将在1小时后截止，请尽快完成"; 
            }
            else
            {
                alertMsg.Body = "您有一条新消息"; 
            }
            alertMsg.ActionLocKey = "您有一条新消息";
            alertMsg.LocKey = text;//内容
            alertMsg.addLocArg("LocArg");
            alertMsg.LaunchImage = "LaunchImage";
           
            //IOS8.2支持字段
            alertMsg.Title = "喻佰信息管理指挥系统";
            alertMsg.TitleLocKey = title;//标题
            alertMsg.addTitleLocArg("TitleLocArg");

            apnpayload.AlertMsg = alertMsg;
            apnpayload.Badge = 1;
            apnpayload.ContentAvailable = 1; 
            //apnpayload.Category = "Category";
            apnpayload.Sound = "test1.wav";
            apnpayload.addCustomMsg("payload", transmissioncontent);
            template.setAPNInfo(apnpayload);


            //设置客户端展示时间
            //String begin = "2015-03-06 14:28:10";
            //String end = "2015-03-06 14:38:20";
            //template.setDuration(begin, end);

            return template;
        }

        //通知透传模板动作内容
        public static NotificationTemplate NotificationTemplateDemo()
        {
            NotificationTemplate template = new NotificationTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            template.Title = "请填写通知标题";         //通知栏标题
            template.Text = "请填写通知内容";          //通知栏内容
            template.Logo = "";               //通知栏显示本地图片
            template.LogoURL = "";                    //通知栏显示网络图标

            template.TransmissionType = "2";          //应用启动类型，1：强制应用启动  2：等待应用启动
            template.TransmissionContent = "请填写透传内容";   //透传内容

            //设置客户端展示时间
            //String begin = "2015-03-06 14:36:10";
            //String end = "2015-03-06 14:46:20";
            //template.setDuration(begin, end);

            template.IsRing = true;                //接收到消息是否响铃，true：响铃 false：不响铃
            template.IsVibrate = true;               //接收到消息是否震动，true：震动 false：不震动
            template.IsClearable = true;             //接收到消息是否可清除，true：可清除 false：不可清除
            return template;
        }

        //通知链接动作内容
        public static LinkTemplate LinkTemplateDemo()
        {
            LinkTemplate template = new LinkTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            template.Title = "请填写通知标题";         //通知栏标题
            template.Text = "请填写通知内容";          //通知栏内容
            template.Logo = "";               //通知栏显示本地图片
            template.LogoURL = "";  //通知栏显示网络图标，如无法读取，则显示本地默认图标，可为空
            template.Url = "http://www.baidu.com";      //打开的链接地址
            template.IsRing = true;                 //接收到消息是否响铃，true：响铃 false：不响铃
            template.IsVibrate = true;               //接收到消息是否震动，true：震动 false：不震动
            template.IsClearable = true;             //接收到消息是否可清除，true：可清除 false：不可清除

            return template;
        }

        //通知弹框下载模板动作内容
        public static NotyPopLoadTemplate NotyPopLoadTemplateDemo()
        {
            NotyPopLoadTemplate template = new NotyPopLoadTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            template.NotyTitle = "请填写通知标题";     //通知栏标题
            template.NotyContent = "请填写通知内容";   //通知栏内容
            template.NotyIcon = "icon.png";           //通知栏显示本地图片
            template.LogoURL = "http://www-igexin.qiniudn.com/wp-content/uploads/2013/08/logo_getui1.png";                    //通知栏显示网络图标

            template.PopTitle = "弹框标题";             //弹框显示标题
            template.PopContent = "弹框内容";           //弹框显示内容
            template.PopImage = "";                     //弹框显示图片
            template.PopButton1 = "下载";               //弹框左边按钮显示文本
            template.PopButton2 = "取消";               //弹框右边按钮显示文本

            template.LoadTitle = "下载标题";            //通知栏显示下载标题
            template.LoadIcon = "file://push.png";      //通知栏显示下载图标,可为空
            template.LoadUrl = "http://www.appchina.com/market/d/425201/cop.baidu_0/com.gexin.im.apk";//下载地址，不可为空

            template.IsActived = true;                  //应用安装完成后，是否自动启动
            template.IsAutoInstall = true;              //下载应用完成后，是否弹出安装界面，true：弹出安装界面，false：手动点击弹出安装界面

            template.IsBelled = true;                 //接收到消息是否响铃，true：响铃 false：不响铃
            template.IsVibrationed = true;               //接收到消息是否震动，true：震动 false：不震动
            template.IsCleared = true;             //接收到消息是否可清除，true：可清除 false：不可清除
            return template;
        }

        public static void getUserStatus()
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            String ret = push.getClientIdStatus(APPID, CLIENTID);
            System.Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("用户状态:" + ret);
        }
    }
}
