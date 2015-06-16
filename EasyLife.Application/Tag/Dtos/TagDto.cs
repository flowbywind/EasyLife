using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife.Tag
{
    public class TagDto
    {
        public int id { get; set; }
        public string tag_name { get; set; }
        public string tag_code { get; set; }
        public int? merchant_id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
