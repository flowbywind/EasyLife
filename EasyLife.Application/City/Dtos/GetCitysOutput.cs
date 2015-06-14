using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace EasyLife
{
    public class GetCitysOutput : IOutputDto
    {
        public List<CityDto> Citys { get; set; }
    }
}
