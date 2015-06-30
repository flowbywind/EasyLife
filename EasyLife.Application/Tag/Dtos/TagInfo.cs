using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
    public class TagInfo : IInputDto, IOutputDto
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string tag_name { get; set; }
        /// <summary>
        /// 分类编码
        /// </summary>
        public string tag_code { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public int merchant_id { get; set; }
    }
}
