using System;
using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace EasyLife.Core.Address
{
    public interface IMemberAddressRepository:IRepository<MemberAddress,int>
    {
        /// <summary>
        /// 查询购物车列表
        /// </summary>
        /// <param name="priFunc"></param>
        /// <returns></returns>
        IEnumerable<MemberAddress> QueryList(Func<MemberAddress, bool> priFunc);

    }
}
