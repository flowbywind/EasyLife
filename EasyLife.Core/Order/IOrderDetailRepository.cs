﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace EasyLife.Core.Order
{
    public interface IOrderDetailRepository:IRepository<OrderDetail,int>
    {

        /// <summary>
        /// 添加订单明细
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        int Add(OrderDetail orderDetail);
    }
}
