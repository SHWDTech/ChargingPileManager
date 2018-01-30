using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using ZDEnterprise.Web.json.flow;
using HttpWebRequestClient.Model;
using HttpWebRequestClient;

namespace System.Web
{
    public class open
    {

        /// <summary>
        /// 通知设备开始充电
        /// </summary>
        /// <param name="TargetIdentity">充电枪标识 </param>
        /// <param name="ShotIndentity">充电桩标识</param>
        /// <param name="customId">用户id</param>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        public static string opens(string TargetIdentity, string ShotIndentity, string customId, string orderid)
        {
            string info = "";

            var manager = new ApiManager();

            var dic = new Dictionary<string, string>();
            dic.Add("ShotIndentity", ShotIndentity);
            var parsStr = JsonConvert.SerializeObject(dic);
            //发送充电指令
            var chargingModel = new CommandPostViewModel();
            chargingModel.CommandName = "StartCharging";
            chargingModel.TargetIdentity = TargetIdentity;
            chargingModel.Pars = parsStr;
            info = manager.PostCommand(new CommandPostViewModel
            {
                CommandName = "StartCharging",
                TargetIdentity = TargetIdentity,
                Pars = JsonConvert.SerializeObject(new Dictionary<string, string>
                {
                    { "ShotIndentity", ShotIndentity }
                })
            });




            checkStatus sd = new checkStatus();
            sd.customId = customId;//用户名
            sd.orderid = orderid;//订单号
            sd.types = 1;//检查充电支付开始

            publicData.orderlist.Add(sd);

            return info;

        }
    }
}