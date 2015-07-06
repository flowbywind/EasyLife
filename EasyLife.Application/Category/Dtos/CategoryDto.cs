using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using EasyLife.Core.Enum;

namespace EasyLife.Application
{
    public class CategoryDto : IInputDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "行业名称")]
        public string cat_name { get; set; }

        [Required]
        [Display(Name = "行业编码")]
        [MaxLength(20)]
        public string cat_code { get; set; }

        [Display(Name = "状态")]
        public StatusEnum status { get; set; }

    }
}
