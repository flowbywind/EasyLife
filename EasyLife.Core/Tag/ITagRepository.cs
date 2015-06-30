using Abp.Domain.Repositories;
using EasyLife.Core;
using System.Linq;

namespace EasyLife
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        IQueryable<Tag> GetTagsByMerchantID(int merchantid, int pageNumber, int pageSize, out int totalCount);

    }
}
