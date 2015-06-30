using System;
using System.Linq;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using EasyLife.Core;

namespace EasyLife.EntityFramework.Repositories
{
    public class GoodsRepository:EasyLifeRepositoryBase<Goods,int>,IGoodsRepository
    {
        public GoodsRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
           
        }

        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <param name="merchantId">商家ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="totalCount">总数</param>
        /// <param name="tagId">衣物种类ID</param>
        /// <returns></returns>
        public IQueryable<Goods> QueryGoods(int merchantId, int? tagId, int pageNumber, int pageSize, out int totalCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", (object)pageNumber, "页码不得小于1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", (object)pageSize, "每页大小不得小于1.");
            var list = this.GetAll().Where(a => a.IsDeleted == false && a.merchant_id==merchantId);
            if (tagId.HasValue)
            {
                list = list.Where(a => a.tag_id == tagId);
            }
            totalCount=list.Count();
            list = list.OrderByDescending(a=>a.Id).PageBy((pageNumber - 1) * pageSize, pageSize);
            return list;
        }

    }
}
