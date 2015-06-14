using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
namespace EasyLife
{
    public interface ICategoryRepository:IRepository<Category,int>
    {
        IQueryable<Category> GetCategorys(int pageNumber, int pageSize,out int totalCount);
    }
}
