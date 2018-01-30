using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ThoughtWorks;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.Drawing;

namespace Utility
{
    public class QrImg
    {

        //生成二维码方法一

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="nr">内容</param>
        /// <param name="flieurl">保存地址文件夹</param>
        /// <returns></returns>
        public static string CreateCode_Simple(string nr, string flieurl)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 7;
            qrCodeEncoder.QRCodeScale = 4;
            if (!System.IO.Directory.Exists(flieurl))
            {
                System.IO.Directory.CreateDirectory(flieurl);//不存在就创建目录 
            }
            System.Drawing.Image image = qrCodeEncoder.Encode(nr, System.Text.Encoding.UTF8);
            string filename = DateTime.Now.ToString("yyyymmddhhmmssfff").ToString() + ".jpg";
            string filepath = flieurl + filename;
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            fs.Close();
            image.Dispose();
            //二维码解码
            //var codeDecoder = CodeDecoder(filepath);
            var url = "/Upload/qr/" + filename;
            return url;
        }

        /// <summary>
        /// 二维码解码
        /// </summary>
        /// <param name="filePath">图片路径</param>
        /// <returns></returns>
        public string CodeDecoder(string filePath)
        {
            string decodedString = "";
            try
            {
                if (!System.IO.File.Exists(filePath))
                    return null;
                Bitmap myBitmap = new Bitmap(Image.FromFile(filePath));
                QRCodeDecoder decoder = new QRCodeDecoder();
                decodedString = decoder.decode(new QRCodeBitmapImage(myBitmap), System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {


            }
            return decodedString;
        }

    }
}
