using Abp.Domain.Repositories;
using EasyLife.Core;
using System.Linq;


namespace EasyLife.Core
{
    public interface ICityRepository : IRepository<City, int>
    {
        IQueryable<City> GetCitys(int pageNumber, int pageSize, out int totalCount);
    }
}
