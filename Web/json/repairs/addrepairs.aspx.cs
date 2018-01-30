using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data;
using System.IO;

namespace ZDEnterprise.Web.json.repairs
{
    public partial class addrepairs : System.Web.UI.Page
    {
        System.BLL.publicBLL pbll = new System.BLL.publicBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string res = "";
                JsonData jsonResult = new JsonData();
                try
                {
                    //设备编号
                    //string facility = Request["facility"] != null ? Utility.Helper.Checkstr(Request["facility"]) : "";
                    //用户编号
                    string customId = _bll.getUserToke(Utility.Helper.gerString(Request["memberid"]));
                    //原因
                    string cause = Request["cause"] != null ? Utility.Helper.Checkstr(Request["cause"]) : "";
                    //报修类型
                    string type = Request["type"] != null ? Utility.Helper.Checkstr(Request["type"]) : "";


                    #region 报修设备
                    if (!string.IsNullOrEmpty(customId) && !string.IsNullOrEmpty(cause))
                    {

                        string toid = System.Guid.NewGuid().ToString();


                        System.Model.repairs rp = new System.Model.repairs();

                        rp.cause = cause;
                        rp.customId = customId;
                        //rp.facility = facility;
                        rp.pudate = System.DateTime.Now;
                        rp.toid = toid;
                        rp.types = Utility.Helper.gerInt(type);
                        if (_bll.rebll.Add(rp) > 0)
                        {
                            #region 判断是否有图

                            List<FileInfos> fio = UploadFile(Request, "/Upload/", "repairs/");


                            if (fio.Count > 0)
                            {
                                for (int i = 0; i < fio.Count; i++)
                                {
                                    FileInfos fs = fio[i];
                                    System.Model.repairs_img ri = new System.Model.repairs_img();
                                    ri.img = fs.datafilename;
                                    ri.pudate = System.DateTime.Now;
                                    ri.uploader = customId;
                                    ri.guishu = toid;
                                    _bll.reibll.Add(ri);
                                }
                            }

                            #endregion
                        }
                        jsonResult["res"] = (int)MyEnum.ResultEnum.成功;
                        jsonResult["msg"] = "报修成功";
                        jsonResult["code"] = "";

                    }
                    else
                    {
                        jsonResult["res"] = (int)MyEnum.ResultEnum.失败;
                        jsonResult["msg"] = "报修失败";
                        jsonResult["code"] = "参数有误";

                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    jsonResult["res"] = (int)MyEnum.ResultEnum.系统错误;
                    jsonResult["msg"] = "服务器繁忙，请稍后再试";
                    jsonResult["code"] = ex.Message;
                }
                res = JsonMapper.ToJson(jsonResult);
                res = MyString.UnicodeToString(res);
                Response.Write(res);
            }
        }

        /// <summary>
        /// 存储文件
        /// </summary>
        /// <param name="req">文件集合</param>
        /// <param name="RootDirectory">一级路径 如: /Upland/</param>
        /// <param name="MenuS">二级路径 如: repairs/</param>
        /// <returns></returns>
        private List<FileInfos> UploadFile(HttpRequest req, string RootDirectory, string MenuS)
        {

            List<FileInfos> fs = new List<FileInfos>();
            int cout = req.Files.Count;
            //数据库存储路径
            string DataCopyFile = RootDirectory + MenuS;
            //完整物理路径
            string _filedir = Server.MapPath(DataCopyFile);

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

    /// <summary>
    /// 路径集合
    /// </summary>
    internal class FileInfos
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public int type;
        /// <summary>
        /// 完整路径(虚拟路径)
        /// </summary>
        public string filename;
        /// <summary>
        /// 存储路径(数据库存储)
        /// </summary>
        public string datafilename;
        /// <summary>
        /// 大小
        /// </summary>
        public int length;
    }
}