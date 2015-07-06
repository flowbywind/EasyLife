using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application
{
    public class UploadImg
    {
        /// <summary>
        /// 前端裁剪处理后的64编码图片字符串
        /// </summary>
        public string base64 { get; set; }

        /// <summary>
        /// 原图片的字节
        /// </summary>
        public byte[] data { get; set; }

    }
}
