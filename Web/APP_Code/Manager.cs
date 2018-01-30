using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
 

namespace ZDEnterprise.Web
{
    public class Manager : System.Web.UI.Page
    {
        public Manager()
        {
            this.Load += new EventHandler(Manager_Load);
        }

        void Manager_Load(object sender, EventArgs e)
        {
            CheckManageSession();
        }


        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        /// <returns></returns>
        public void CheckManageSession()
        {

            if (Convert.ToString(Session["users"]) == "" || Convert.ToString(Session["permissions"])== "")
            {
                Response.Redirect(ConfigurationManager.AppSettings["VirturlPath"] + "/login.aspx"); 
            }
        }

        public bool RolePermissions(string permissionsId)
        {
            bool bl = false;
            DataTable tb5 = Session["permissions"] as DataTable;
            if (tb5.Rows.Count > 0)
            {
                for (int i = 0; i < tb5.Rows.Count; i++)
                {
                    if (tb5.Rows[i]["permissionsId"].ToString() == permissionsId)
                    {
                        bl = true;
                        break;
                    }
                }
            }
            else
            {
                bl = false;
            }
            return bl;
        }
    }
}
