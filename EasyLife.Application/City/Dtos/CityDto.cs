using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using EasyLife.Core.Enum;

namespace EasyLife.Application
{
    public class CityDto : EntityDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [Display(Name = "城市名称")]
        public string city_name { get; set; }

        /// <summary>
        /// 城市名称拼音
        /// </summary>
        [Display(Name = "拼音")]
        public string pin_yin { get; set; }

        /// <summary>
        /// 最热
        /// </summary>
        [Display(Name = "最热")]
        public HotEnum hot { get; set; }

        /// <summary>
        /// 父城市ID
        /// </summary>
        [Display(Name = "所属地市")]
        public int parent_id { get; set; }

        /// <summary>
        /// 首字母
        /// </summary>
        [Display(Name = "首字母")]
        public int first_char { get; set; }
    }
}
