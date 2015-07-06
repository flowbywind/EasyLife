using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Web
{
    public class ImgUploadResponse
    {
        public ImgUploadResponse(bool success, string src, string cuttype, string cutPosition, string info)
        {
            this.success = success ? "1" : "0";
            this.src = src;
            this.cutType = cuttype;
            this.cutPosition = cutPosition;
            this.info = info;
        }
        /// <summary>
        /// 上传是否成功：1-成功;0-不成功
        /// </summary>
        public string success { get; set; }

        /// <summary>
        /// 上传图片路径
        /// </summary>
        public string src { get; set; }

        /// <summary>
        /// 裁剪类型--bg,guide
        /// </summary>
        public string cutType { get; set; }

        /// <summary>
        /// 裁剪位置
        /// </summary>
        public string cutPosition { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string info { get; set; }
    }
}