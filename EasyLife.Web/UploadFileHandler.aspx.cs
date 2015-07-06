using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Web
{
    public partial class UploadFileHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = "";
            var operate = string.IsNullOrEmpty(Request["operate"]) ? "" : Request["operate"].ToString();
            switch (operate)
            {
                case "upload":
                    result = UploadFile();
                    break;
            }
            Response.ContentType = "text/json";
            Response.Write(result);
            Response.End();
        }

        /// <summary>
        /// 将位图上传图片服务器
        /// </summary>
        /// <returns></returns>
        private string UploadFile()
        {
            string[] array = Request["cut-base64"].Split(',');
            string filetype = array[0].Split(';')[0].Split(':')[1];
            string name = DateTime.Now.Ticks.ToString();
            string fileName = "";
            switch (filetype)
            {
                case "image/jpeg":
                    fileName = name + ".jpeg";
                    break;
                case "image/jpg":
                    fileName = name + ".jpg";
                    break;
                case "image/png":
                    fileName = name + ".png";
                    break;
            }
            string cutposition = Request["cut-position"].ToString();
            string cutType = Request["cut-cutType"].ToString();
            byte[] bytes = Convert.FromBase64String(array[1]);
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bmp = new Bitmap(ms);
            HttpPostedFile file = Request.Files["up"];
            if (file != null)
            {
                try
                {

                }
                catch (System.Threading.ThreadAbortException)
                {
                }
                catch (Exception)
                {
                }
                return UploadFileErrorHandle("上传图片出错");
            }
            return UploadFileErrorHandle("上传图片出错");
        }

        /// <summary>
        /// 上传图片提示问题。
        /// </summary>
        /// <param name="message"></param>
        private string UploadFileErrorHandle(string message)
        {
            var resultinfo = new resultInfo();
            resultinfo.success = 0;
            resultinfo.info = message;
            return string.Empty;
        }

        /// <summary>
        /// 返回信息实体
        /// </summary>
        public class resultInfo
        {
            public int success { get; set; }

            public string info { get; set; }
        }

        /// <summary>
        /// 将位图上传图片服务器
        /// </summary>
        /// <returns></returns>
        //private string UploadFile()
        //{
        //    string[] array = Request["cut-base64"].Split(',');
        //    string filetype = array[0].Split(';')[0].Split(':')[1];
        //    string name = DateTime.Now.Ticks.ToString();
        //    string fileName = "";
        //    switch (filetype)
        //    {
        //        case "image/jpeg":
        //            fileName = name + ".jpeg";
        //            break;
        //        case "image/jpg":
        //            fileName = name + ".jpg";
        //            break;
        //        case "image/png":
        //            fileName = name + ".png";
        //            break;
        //    }
        //    string cutposition = Request["cut-position"].RequestToString();
        //    string cutType = Request["cut-cutType"].RequestToString();
        //    byte[] bytes = Convert.FromBase64String(array[1]);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    Bitmap bmp = new Bitmap(ms);
        //    HttpPostedFile file = Request.Files["up"];
        //    if (file != null)
        //    {
        //        try
        //        {
        //            //上传原图
        //            System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
        //            MemoryStream memorystream = new MemoryStream();
        //            byte[] imagedata = null;
        //            img.Save(memorystream, ImageFormat.Jpeg);
        //            imagedata = memorystream.GetBuffer();
        //            var responseOri = RemoteUpLoadService.UploadImg(imagedata, "ori" + fileName, "", AllowedFileType.Jpeg | AllowedFileType.Jpg, null, null, 20480);
        //            if (!responseOri.IsSuccess)
        //                return UploadFileErrorHandle(responseOri.Message);

        //            var response = RemoteUpLoadService.UploadImg(bytes, fileName, "", AllowedFileType.Jpeg | AllowedFileType.Jpg, null, null, 20480);
        //            if (!response.IsSuccess)
        //                return UploadFileErrorHandle(response.Message);
        //            var src = "{'src':'" + Config.UploadImgUrl + response.Message + "','orisrc':'" + Config.UploadImgUrl + responseOri.Message + "'}";
        //            var jsonObj = new ImgUploadResponse(response.IsSuccess, src, cutType, cutposition, response.Message);
        //            return Common.Serialize(jsonObj);
        //        }
        //        catch (System.Threading.ThreadAbortException)
        //        {
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        return UploadFileErrorHandle("上传图片出错");
        //    }
        //    return UploadFileErrorHandle("上传图片出错");
        //}

        /// <summary>
        /// 将位图上传图片服务器
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        //private string UploadThumFile()
        //{
        //    string FullFileName = Request["src"];
        //    if (!FullFileName.ToLower().Contains("http://") && FullFileName.ToLower() != "")
        //        FullFileName = Config.ImgServer + FullFileName;
        //    string cutposition = Request["cut-position"].RequestToString();
        //    string cutType = Request["cut-cutType"].RequestToString();
        //    string fileName = "";
        //    string name = DateTime.Now.Ticks.ToString();
        //    int pos = FullFileName.LastIndexOf(".");
        //    string StrType = FullFileName.Substring(pos);
        //    fileName = name + StrType;
        //    try
        //    {
        //        var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(FullFileName);
        //        var webResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
        //        byte[] outBytes;
        //        using (var getStream = webResponse.GetResponseStream())
        //        {
        //            outBytes = ReadFully(getStream);
        //        }
        //        MemoryStream ms = new MemoryStream(outBytes);
        //        Bitmap bmp = new Bitmap(ms);
        //        var responseOri = RemoteUpLoadService.UploadImg(outBytes, "ori" + fileName, "", AllowedFileType.Jpeg | AllowedFileType.Jpg, null, null, 20480);
        //        if (!responseOri.IsSuccess)
        //            UploadFileErrorHandle(responseOri.Message);
        //        var response = RemoteUpLoadService.UploadysImg(bmp, fileName, "", 140, 140, null, null, 20480);
        //        if (!response.IsSuccess)
        //            UploadFileErrorHandle(response.Message);
        //        var src = "{'src':'" + Config.UploadImgUrl + response.Message + "','orisrc':'" + Config.UploadImgUrl + responseOri.Message + "'}";
        //        var jsonObj = new ImgUploadResponse(response.IsSuccess, src, cutType, cutposition, response.Message);
        //        return Common.Serialize(jsonObj);
        //    }
        //    catch (System.Threading.ThreadAbortException)
        //    {
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return UploadFileErrorHandle("上传图片出错");
        //}
    }

}