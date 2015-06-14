﻿using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using EasyLife;
using System.Collections.Generic;

namespace EasyLife
{
    public class CreateMerchantInput : IInputDto
    {
        [Required]
        [Display(Name = "商户名称")]
        [MaxLength(50)]
        public string merchant_name { get; set; }
        [Required]
        [Display(Name = "银行")]
        [MaxLength(50)]
        public string bank { get; set; }
        [Required]
        [Display(Name = "银行卡号")]
        [MaxLength(50)]
        public string account { get; set; }
        [Required]
        [Display(Name = "城市")]
        [MaxLength(50)]
        public int? city_id { get; set; }
        [Required]
        [Display(Name = "行业分类")]
        [MaxLength(50)]
        public int? cat_id { get; set; }
        [Required]
        [Display(Name = "联系人")]
        [MaxLength(50)]
        public string contact_name { get; set; }
        [Required]
        [Display(Name = "联系电话")]
        [MaxLength(50)]
        public string phone { get; set; }
        [Required]
        [Display(Name = "邮箱")]
        [MaxLength(50)]
        public string email { get; set; }
        [Required]
        [Display(Name = "状态")]
        [MaxLength(50)]
        public Status status { get; set; }
    }
}
