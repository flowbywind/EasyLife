using System;
using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using EasyLife.Core;

namespace EasyLife.EntityFramework.Repositories
{
    public class CategoryRepository:EasyLifeRepositoryBase<Category,int>,ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
           
        }
        public IQueryable<Category> GetCategorys(int pageNumber, int pageSize,out int totalCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", (object)pageNumber, "页码不得小于1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", (object)pageSize, "每页大小不得小于1.");
            var list = this.GetAll().Where(a => a.IsDeleted == false);
            totalCount=list.Count();
            list = list.OrderBy(a=>a.Id).PageBy((pageNumber - 1) * pageSize, pageSize);
            return list;
        }

    }
}
