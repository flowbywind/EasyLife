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
                base64 = collection["cut-base64"],
                data = imagedata
            };
            var a=22;
            return null;
        }
    }
}