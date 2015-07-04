using System;
using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using EasyLife.Core;
using EasyLife.Core.Enum;

namespace EasyLife.EntityFramework.Repositories
{
    public class MerchantRepository : EasyLifeRepositoryBase<Merchant, int>, IMerchantRepository
    {
        public MerchantRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 获取商户列表
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public IQueryable<Merchant> GetMerchants(int pageNumber, int pageSize, out int totalCount)
        {
            var list = this.GetAll().Where(a => a.IsDeleted == false);
            totalCount = list.Count();
            list = list.OrderBy(a => a.Id).PageBy((pageNumber - 1) * pageSize, pageSize);
            return list;
        }
    }
}
