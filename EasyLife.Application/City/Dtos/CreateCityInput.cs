using Abp.Application.Services.Dto;
using EasyLife.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyLife.Application
{
    public class CreateCityInput : IInputDto
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        [Display(Name = "城市名称")]
        [Required]
        public string city_name { get; set; }

        /// <summary>
        /// 城市名称拼音
        /// </summary>
        [Display(Name = "拼音")]
        [Required]
        public string pin_yin { get; set; }

        /// <summary>
        /// 最热
        /// </summary>
        [Display(Name = "最热")]
        [Required]
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
        [Required]
        public string first_char { get; set; }
    }
}
