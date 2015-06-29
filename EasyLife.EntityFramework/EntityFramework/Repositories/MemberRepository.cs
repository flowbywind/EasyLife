using System;
using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using EasyLife.Core;

namespace EasyLife.EntityFramework.Repositories
{
    public class MemberRepository : EasyLifeRepositoryBase<Member, int>, IMemberRepository
    {
        public MemberRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 根据商家获取所有的会员
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public List<Member> GetAllByMerchantID(int? merchantId)
        {
            var query = GetAll();
            if (merchantId.HasValue)
                query = query.Where(a => a.Id == merchantId);
            return query.OrderByDescending(a => a.CreationTime).ToList();
        }

        /// <summary>
        /// 根据商家获取所有的标签
        /// </summary>
        /// <param name="merchantid"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public IQueryable<Member> GetMembersByMemberID(int merchantid, int pageNumber, int pageSize, out int totalCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", (object)pageNumber, "页码不得小于1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", (object)pageSize, "每页大小不得小于1.");
            var list = this.GetAll().Where(a => a.IsDeleted == false);
            totalCount = list.Count();
            list = list.OrderBy(a => a.Id).PageBy((pageNumber - 1) * pageSize, pageSize);
            return list;
        }
    }
}
