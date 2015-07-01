using Abp.Application.Services;
using EasyLife;
using EasyLife.Application;
using EasyLife.Core;
using PagedList;

namespace EasyLife
{
    public interface ICityService : IApplicationService
    {
        void Create(CreateCityInput input);

        CityList GetCitys();

        IPagedList<CityDto> GetCitys(int pageNumber, int pageSize);

        CityDto GetByID(int id);

        void UpdateByID(CreateCityInput input, int id);

        void Delete(int id);
    }
}
