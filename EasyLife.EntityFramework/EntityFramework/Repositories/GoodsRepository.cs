﻿using System;
using System.Linq;
using Abp.EntityFramework;
using Abp.Linq.Extensions;

namespace EasyLife.EntityFramework.Repositories
{
    public class GoodsRepository:EasyLifeRepositoryBase<Goods,int>,IGoodsRepository
    {
        public GoodsRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
           
        }
        public IQueryable<Goods> QueryGoods(int merchantId,int pageNumber, int pageSize,out int totalCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", (object)pageNumber, "页码不得小于1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", (object)pageSize, "每页大小不得小于1.");
            var list = this.GetAll().Where(a => a.IsDeleted == false && a.MerchantId==merchantId);
            totalCount=list.Count();
            list = list.OrderByDescending(a=>a.Id).PageBy((pageNumber - 1) * pageSize, pageSize);
            return list;
        }

    }
}
