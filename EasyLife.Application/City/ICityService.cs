using Abp.Application.Services;
using EasyLife;
using EasyLife.Application;
using EasyLife.Core;
using PagedList;

namespace EasyLife.Application
{
    public interface ICityService : IApplicationService
    {
        void Create(CityDto input);

        CityList GetList();

        IPagedList<CityDto> GetList(int pageNumber, int pageSize);

        CityDto GetByID(int id);

        void UpdateByID(CityDto input, int id);

        void Delete(int id);
    }
}
