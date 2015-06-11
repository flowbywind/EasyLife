using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace EasyLife
{
    public class GetCategorysOutput : IOutputDto
    {
        public List<CategoryDto> Categorys { get; set; }
    }
}
