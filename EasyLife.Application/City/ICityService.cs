using Abp.Application.Services;
using EasyLife;
using System.Threading.Tasks;

namespace EasyLife
{
    public interface ICityService : IApplicationService
    {
        void CreateCity(CreateCityInput input);

        GetCitysOutput GetCitys();

        City GetCityByID(int id);

        void UpdateCityByID(CreateCityInput input, int id);

        void DeleteCity(int id);
    }
}
