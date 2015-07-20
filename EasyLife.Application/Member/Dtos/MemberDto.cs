using Abp.Application.Services.Dto;
using EasyLife.Core.Enum;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyLife.Application
{
    public class MemberDto : IOutputDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        [Display(Name = "名称")]
        [MaxLength(50)]
        [Required]
        public string member_name { get; set; }
        /// <summary>
        /// 会员性别
        /// </summary>
        [Display(Name = "性别")]
        public SexEnum member_sex { get; set; }
        /// <summary>
        /// 会员生日
        /// </summary>
        [Display(Name = "出生日期")]
        [Required]
        public DateTime member_birthday { get; set; }
        /// <summary>
        /// 会员手机号
        /// </summary>
        [Display(Name = "手机号")]
        [MaxLength(50)]
        [Required]
        public string member_phone { get; set; }
        /// <summary>
        /// 会员地址
        /// </summary>
        [Display(Name = "地址")]
        [MaxLength(50)]
        [Required]
        public string member_address { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public int merchant_id { get; set; }
        /// <summary>
        /// 会员密码
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(50)]
        [Required]
        public string member_pwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "状态")]
        public StatusEnum status { get; set; }

    }
}
