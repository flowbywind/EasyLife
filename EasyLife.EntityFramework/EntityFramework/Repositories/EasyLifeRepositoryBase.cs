using System;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace EasyLife.EntityFramework.Repositories
{
    public abstract class EasyLifeRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EasyLifeDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EasyLifeRepositoryBase(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories

        public void ValidatePaged(int pageNumber,int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", (object)pageNumber, "页码不得小于1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", (object)pageSize, "每页大小不得小于1.");
        }
    }

    public abstract class EasyLifeRepositoryBase<TEntity> : EasyLifeRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected EasyLifeRepositoryBase(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }

  
}
