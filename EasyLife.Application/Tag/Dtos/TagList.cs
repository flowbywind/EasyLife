using System.Collections.Generic;
using Abp.Application.Services.Dto;
using EasyLife.Application;

namespace EasyLife.Application
{
    public class TagList : IOutputDto
    {
        public List<TagDto> TagDtos { get; set; }
    }
}
