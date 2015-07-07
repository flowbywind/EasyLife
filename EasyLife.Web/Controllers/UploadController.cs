using EasyLife.Application;
using EasyLife.Core.Enum;
using System.Web.Mvc;
using EasyLife.Application;
using System.Web;
using System.IO;
using System.Drawing.Imaging;

namespace EasyLife.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;
        public UploadController(IUploadService categoryService)
        {
            _uploadService = categoryService;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="collection">上传图片表单参数</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadImg(FormCollection collection)
        {
            var file = Request.Files["up"];
            System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
            MemoryStream memorystream = new MemoryStream();
            byte[] imagedata = null;
            img.Save(memorystream, ImageFormat.Jpeg);
            imagedata = memorystream.GetBuffer();
            UploadImg UploadImg = new UploadImg
            {
                base64 = Request["cut-base64"],
                data = imagedata
            };
            string cutposition = Request["cut-position"];
            string cutType = Request["cut-cutType"];
            var result = new ImgUploadResponse(true, "http://easylife.com/Upload/Desert.jpg", cutType, cutposition, "111");
            return null;
        }
    }
}