using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace EasyLife
{
    public class GoodsList : IOutputDto
    {
        public List<GoodsDto> GoodsDtos { get; set; }

    }
}
