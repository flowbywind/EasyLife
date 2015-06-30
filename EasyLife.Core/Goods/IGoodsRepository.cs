using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using EasyLife.Core;
namespace EasyLife
{
    public interface IGoodsRepository : IRepository<Goods, int>
    {
        IQueryable<Goods> QueryGoods(int merchantId, int? tagId,int pageNumber, int pageSize, out int totalCount);
    }
}
