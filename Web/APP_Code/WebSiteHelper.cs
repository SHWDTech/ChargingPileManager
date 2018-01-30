using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ZDEnterprise.Web
{
    public class WebSiteHelper
    {
        public static string WebSiteTitle = ConfigurationManager.AppSettings["websitetitle"];
        public static string WebSiteKeywords = ConfigurationManager.AppSettings["websitekeywords"];
        public static string WebSiteDescription = ConfigurationManager.AppSettings["websitedescription"];
        public static string WebSiteTel = ConfigurationManager.AppSettings["websitetel"];
    }
}
