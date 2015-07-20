using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
    public class TagDto : IInputDto
    {
        /// <summary>
        /// 主键key
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 标签名
        /// </summary>
        public string tag_name { get; set; }

        /// <summary>
        /// 标签code
        /// </summary>
        public string tag_code { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public int? merchant_id { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 下划线图标
        /// </summary>
        public string line_icon { get; set; }
    }
}
