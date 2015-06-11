using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace EasyLife
{
    public class CategoryDto : IInputDto
    {
        public int id { get; set; }
        public string cat_name { get; set; }

        public string cat_code { get; set; }
    }
}
