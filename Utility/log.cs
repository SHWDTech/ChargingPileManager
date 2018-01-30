using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace System
{
    public class log
    {

        public static void setlog(string title, string str)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("/log.txt");
            if (!System.IO.File.Exists(path))
            {
                FileStream fsnew = System.IO.File.Create(path);
                fsnew.Close();
            }

            using (FileStream fs = System.IO.File.Open(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("---------------------------------------------------------------------------------------------");
                    sw.WriteLine("备注:{0}", title);
                    sw.WriteLine("记录时间:{0}", DateTime.Now.ToString());
                    sw.WriteLine("内容\n:{0}", str);
                    sw.WriteLine("---------------------------------------------------------------------------------------------");
                    sw.Flush();
                    sw.Close();
                }
            }
        }

    }
}