using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife.Application
{
    public class TagDto : EntityDto
    {
        /// <summary>
        /// 商家ID
        /// 主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary> 
        [Display(Name = "标签名称")]
        [MaxLength(50)]
        [Required]
        public string tag_name { get; set; }
        /// <summary>
        /// 标签编码
        /// </summary>
        [Display(Name = "标签编码")]
        [MaxLength(50)]
        [Required]
        public string tag_code { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public int? merchant_id { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        [MaxLength(50)]
        [Required]
        public string icon { get; set; }

        /// <summary>
        /// 下划线图标
        /// </summary>
        public string line_icon { get; set; }
    }
}
