using System;
using Abp.Application.Services.Dto;
using EasyLife.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace EasyLife.Application
{
    public class MerchantDto : EntityDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "商户名称")]
        [MaxLength(50)]
        [Required]
        public string merchant_name { get; set; }

        [Display(Name = "开户银行")]
        [MaxLength(50)]
        [Required]
        public string bank { get; set; }

        [Display(Name = "银行卡号")]
        [MaxLength(50)]
        [Required]
        public string account { get; set; }

        [Display(Name = "所在城市")]
        [Required]
        public int city_name { get; set; }

        [Display(Name = "所在城市")]
        [Required]
        public int city_id { get; set; }

        [Display(Name = "所属行业")]
        [Required]
        public int cat_name { get; set; }

        [Display(Name = "所属行业")]
        [Required]
        public int cat_id { get; set; }


        [Display(Name = "联系人")]
        [MaxLength(50)]
        [Required]
        public string contact_name { get; set; }

        [Display(Name = "手机号")]
        [MaxLength(50)]
        [Required]
        public string phone { get; set; }

        [Display(Name = "邮箱")]
        [MaxLength(50)]
        [Required]
        public string email { get; set; }

        [Display(Name = "商户状态")]
        [Required]
        public virtual StatusEnum status { get; set; }
    }
}
