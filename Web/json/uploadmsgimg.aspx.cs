using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LitJson;

namespace ZDEnterprise.Web.json
{
    public partial class uploadmsgimg : System.Web.UI.Page
    {
        /// <summary>
        /// 根目录
        /// </summary>
        string rootDirectory = "/Upload/";
        /// <summary>
        /// 一级目录
        /// </summary>
        string Menus = "bootpage/";

        protected void Page_Load(object sender, EventArgs e)
        {

            string res = "";
            JsonData jsonResult = new JsonData();
            try
            {
                Menus = Request["filetowname"] != null ? Utility.Helper.Checkstr(Request["filetowname"]) + "/" : Menus;
                List<FileInfos> fs = UploadFile(Request, rootDirectory, Menus);
                if (fs.Count > 0)
                {
                    JsonData data = new JsonData();
                    for (int i = 0; i < fs.Count; i++)
                    {


                        FileInfos fsw = fs[i];
                        JsonData json = new JsonData();
                        json["type"] = fsw.type;
                        json["length"] = fsw.length;
                        json["filename"] = fsw.filename;
                        json["datafilename"] = fsw.datafilename;
                        data.Add(json);
                    }
                    jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                    jsonResult["msg"] = "成功";
                    jsonResult["count"] = fs.Count;
                    jsonResult["code"] = "";
                    jsonResult["Data"] = data;
                }
                else
                {
                    jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                    jsonResult["msg"] = "类型有误";
                    jsonResult["code"] = "";
                }
            }
            catch (Exception ex)
            {
                jsonResult["res"] = (int)MyEnum.ResultEnum.系统错误;
                jsonResult["msg"] = "服务器繁忙，请稍后再试";
                jsonResult["code"] = ex.Message;
            }
            res = JsonMapper.ToJson(jsonResult);
            res = MyString.UnicodeToString(res);
            //log.setlog("返回值", res);
            Response.Write(res);
        }

        /// <summary>
        /// 接收上传的文件
        /// </summary>
        /// <param name="req">文件流</param>
        /// <param name="RootDirectory">根目录</param>
        /// <param name="MenuS">一级目录</param>
        /// <returns></returns>
        private List<FileInfos> UploadFile(HttpRequest req, string RootDirectory, string MenuS)
        {

            //文件信息
            List<FileInfos> fs = new List<FileInfos>();
            int cout = req.Files.Count;
            //数据库存储路径
            string DataCopyFile = RootDirectory + Menus;
            //完整物理路径
            string _filedir = Server.MapPath(RootDirectory + Menus);

            //正式文件路径
            if (!Directory.Exists(_filedir))
            {
                Directory.CreateDirectory(_filedir);
            }
            if (cout > 0)
            {
                HttpFileCollection httpflie = req.Files;
                for (int i = 0; i < httpflie.Count; i++)
                {
                    HttpPostedFile hpf = httpflie[i];
                    if (hpf != null)
                    {
                        string fileExt = Path.GetExtension(hpf.FileName).ToLower();
                        //只能上传文件，过滤不可上传的文件类型    
                        string fileFilt = ".bmp|.gif|.jpg|.php|.jsp|.jpeg|.png|.mp4|.mp3|....";
                        if (fileFilt.ToLower().IndexOf(fileExt) <= -1)
                        {
                            //inputText = "1";
                            continue;
                        }
                        //判断文件大小  
                        int length = hpf.ContentLength;
                        if (length > 104857600)
                        {
                            //inputText = "2";
                            continue;
                        }

                        string newFileName = System.Guid.NewGuid().ToString() + Path.GetExtension(hpf.FileName);
                        ///<summary> 
                        ///完整路径
                        ///<summary> 
                        string fileName = _filedir + newFileName;

                        ///<summary> 
                        ///存储路径
                        ///<summary> 
                        string Name = DataCopyFile + newFileName;
                        //是否裁剪,缩放
                        //计算图片比例

                        hpf.SaveAs(fileName);

                        FileInfos sb = new FileInfos();
                        sb.datafilename = Name;
                        sb.filename = Utility.Helper.getImgUrl(Name);
                        sb.length = length;

                        sb.type = 1;
                        if ((".gif|.jpg|.php|.jsp|.jpeg|.png|").Contains(fileExt.ToLower()))
                        {
                            //文件类型(图片)
                            sb.type = 1;
                        }
                        else if ((".mp4|.mov|").Contains(fileExt.ToLower()))
                        {
                            //文件类型(视频)
                            sb.type = 2;
                        }
                        else if ((".mp3|").Contains(fileExt.ToLower()))
                        {
                            //文件类型(音乐)
                            sb.type = 4;
                        }
                        else if ((".doc|.docx|.xls|.txt|.xlsx|.ppt|.pptx|").Contains(fileExt.ToLower()))
                        {
                            //文件类型(文档)
                            sb.type = 5;
                        }
                        else if ((".zip|.rar|.7z|").Contains(fileExt.ToLower()))
                        {
                            //文件类型(压缩文件)
                            sb.type = 6;
                        }
                        fs.Add(sb);
                    }
                }
                return fs;
            }
            return fs;
        }
    }

}