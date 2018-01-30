using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ZDEnterprise.Web
{
    public class VirturlPathHelper
    {

        public static string VirturlPath = ConfigurationManager.AppSettings["VirturlPath"];

    }
}
