using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using EasyLife.Core.Enum;

namespace EasyLife
{
    public class MemberInfo : IInputDto, IOutputDto
    {
        public string member_name { get; set; }
        public SexEnum member_sex { get; set; }
        public string member_birthday { get; set; }
        public string member_phone { get; set; }
        public string member_address { get; set; }
        public int merchant_id { get; set; }
    }
}
