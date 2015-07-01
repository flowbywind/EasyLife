using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace EasyLife.Application
{
    public class CategoryList : IOutputDto
    {
        public List<CategoryDto> Categorys { get; set; }

    }
}
