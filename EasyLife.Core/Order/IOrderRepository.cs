using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using EasyLife.Core.Enum;

namespace EasyLife.Core.Order
{
    public interface IOrderRepository:IRepository<Order,int>
    {
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <param name="orderStatus">订单状态 为空查全部</param>
        /// <param name="totalCount">总量</param>
        /// <returns></returns>
        List<Order> QueryOrderList(int memberId, int pageNumber, int pageSize, OrderStatus? orderStatus,
            out int totalCount);
    }
}
