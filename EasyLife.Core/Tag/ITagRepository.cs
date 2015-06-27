using Abp.Domain.Repositories;
using System.Linq;

namespace EasyLife
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        IQueryable<Tag> GetTagsByMerchantID(int merchantid, int pageNumber, int pageSize, out int totalCount);

    }
}
