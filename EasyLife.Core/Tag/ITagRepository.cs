using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        IQueryable<Tag> GetTagsByMerchantID(int merchantid, int pageNumber, int pageSize, out int totalCount);

    }
}
