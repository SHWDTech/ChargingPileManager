using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ZDEnterprise.Web
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// 定时器间隔毫秒
        /// </summary>
        protected static double period = double.Parse("1000");

        /// <summary>
        /// 定时器触发事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            //要执行的操作

            #region 定时修改订单状态
            string strwhere = @" EXISTS (select id from V_order_details where  paystatus=2 and dateadd(Minute,duration,paydate)<GETDATE() and serialNumber=order_info.serialNumber ) and statuses=2";
            List<System.Model.order_info> oilist = _bll.oibll.GetModelList(strwhere);

            string orderno = "";
            string portid = "";
            if (oilist.Count > 0)
            {
                for (int i = 0; i < oilist.Count; i++)
                {
                    orderno += "'" + oilist[i].serialNumber + "'" + ",";
                    portid += "'" + oilist[i].port + "'" + ",";
                }
                orderno = orderno.TrimEnd(',');
                portid = portid.TrimEnd(',');

                if (orderno.Length > 0)
                {
                    string strsql = "update order_info set statuses=3 where serialNumber in( " + orderno + " )";

                    _bll.pbll.RunSqlW(strsql);
                    strsql = " update facility_port set isEmploy=0  where id in ( " + portid + " ) ";
                    _bll.pbll.RunSqlW(strsql);
                }
            }

            #endregion
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //Application_Start：在HttpApplication 类的第一个实例被创建时，该事件被触发。它允许你创建可以由所有HttpApplication 实例访问的对象。
            System.Timers.Timer timer = new System.Timers.Timer(period);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}