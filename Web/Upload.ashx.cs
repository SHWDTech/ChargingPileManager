using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace Web
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["FileData"];
            string uploadpath = context.Server.MapPath("Upload/img/");//上传商品图片

            if (file != null)
            {
                if (!Directory.Exists(uploadpath))
                {
                    Directory.CreateDirectory(uploadpath);
                }
                string item = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                string filenewname =  Guid.NewGuid().ToString() ;
                file.SaveAs(uploadpath + filenewname + item);
                context.Response.Write(filenewname + item + "|" + filenewname); //标志位1标识上传成功，后面的可以返回前台的参数，比如上传后的路径等，中间使用|隔开
            }
            else
            {
                context.Response.Write("");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}