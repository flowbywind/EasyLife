using EasyLife.Application;
using EasyLife.Core.Enum;
using System.Web.Mvc;
using EasyLife.Application;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System;
using System.Drawing;

namespace EasyLife.Web.Controllers
{
    public class UploadController : Controller
    {
        //private readonly IUploadService _uploadService;
        //public UploadController(IUploadService categoryService)
        //{
        //    _uploadService = categoryService;
        //}

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="collection">上传图片表单参数</param>
        /// <returns></returns>
        [HttpPost]
        public string UploadImg()
        {
            var uploadPath = Server.MapPath("~/upload/");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

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
            string cutposition = Request["cut-position"].RequestToString();
            string cutType = Request["cut-cutType"].RequestToString();
            byte[] bytes = Convert.FromBase64String(array[1]);
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bmp = new Bitmap(ms);
            var srcpath = uploadPath + "/src" + name + fileName;
            var src = "/upload" + "/src" + name + fileName;
            bmp.Save(srcpath);
            var file = Request.Files["up"];
            System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
            var srcoripath = uploadPath + "/srcori" + name + fileName;
            var srcori = "/upload" + "/srcori" + name + fileName;
            img.Save(srcoripath);
            var srcjson = "{'src':'" + src + "','srcori':'" + srcori + "'}";
            var result = new ImgUploadResponse(true, srcjson, cutType, cutposition, "上传成功");
            return JsonHelper.SerializeObject(result);
        }
    }
}