using Abp.Domain.Repositories;
using EasyLife.Core;
using System.Linq;

namespace EasyLife
{
    public interface IMerchantRepository : IRepository<Merchant, int>
    {
        IQueryable<Merchant> GetMerchants(int pageNumber, int pageSize, out int totalCount);
    }
}
