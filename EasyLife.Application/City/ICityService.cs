using Abp.Application.Services;
using EasyLife;
using EasyLife.Application;
using EasyLife.Core;

namespace EasyLife
{
    public interface ICityService : IApplicationService
    {
        void Create(CityDto input);

        CityList GetCitys();

        City GetByID(int id);

        void UpdateByID(CityDto input, int id);

        void Delete(int id);
    }
}
