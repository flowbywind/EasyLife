using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application
{
    public class UploadService : EasyLifeAppServiceBase, IUploadService
    {

        public string UploadImg(UploadImg input)
        {

            //string[] array = collection["cut-base64"].Split(',');
            //string filetype = array[0].Split(';')[0].Split(':')[1];
            //string name = DateTime.Now.Ticks.ToString();
            //string fileName = "";
            //switch (filetype)
            //{
            //    case "image/jpeg":
            //        fileName = name + ".jpeg";
            //        break;
            //    case "image/jpg":
            //        fileName = name + ".jpg";
            //        break;
            //    case "image/png":
            //        fileName = name + ".png";
            //        break;
            //}
            //string cutposition = collection["cut-position"].RequestToString();
            //string cutType = collection["cut-cutType"].RequestToString();
            //byte[] bytes = Convert.FromBase64String(array[1]);
            //MemoryStream ms = new MemoryStream(bytes);
            //Bitmap bmp = new Bitmap(ms);
            //var jsonObj = new ImgUploadResponse(true, "https://ss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superplus/img/logo_white_ee663702.png", cutType, cutposition, "上传图片");
            ////HttpPostedFile file = collection.Files["up"];
            //return jsonObj.ToString();
            return string.Empty;
        }
    }
}
