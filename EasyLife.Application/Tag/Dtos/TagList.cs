using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace EasyLife
{
    public class TagList : IOutputDto
    {
        public List<TagDto> TagDtos { get; set; }
    }
}
