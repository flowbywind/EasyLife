
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using EasyLife.Core.Address;

namespace EasyLife.EntityFramework.Repositories
{
    public class MemberAddressRepository:EasyLifeRepositoryBase<MemberAddress,int>,IMemberAddressRepository
    {
        public MemberAddressRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider):base(dbContextProvider)
        {

        }

        /// <summary>
        /// 查询地址列表
        /// </summary>
        /// <param name="priFunc"></param>
        /// <returns></returns>
        public IEnumerable<MemberAddress> QueryList(Func<MemberAddress, bool> priFunc)
        {
            if (priFunc == null)
            {
                return this.GetAll();
            }
            return this.GetAll().Where(priFunc);
        }
       
    }
}
