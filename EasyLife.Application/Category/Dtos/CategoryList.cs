using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace EasyLife.Application.Category.Dtos
{
    public class CategoryList : IOutputDto
    {
        public List<CategoryDto> Categorys { get; set; }

    }
}
