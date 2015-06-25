using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
    public class TagDto : IInputDto
    {
        public int id { get; set; }
        public string tag_name { get; set; }
        public string tag_code { get; set; }
        public int? merchant_id { get; set; }
    }
}
