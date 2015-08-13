using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using EasyLife.Application.Order.Dtos;
using EasyLife.Core.Enum;
using PagedList;

namespace EasyLife.Application.Order
{
    public  interface IOrderService:IApplicationService
    {
        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="order">订单信息</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        bool SubmitOrder(OrderDto order,out string msg);

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="memberId">会员ID</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        bool UpdateOrderStatus(int orderId, int memberId, OrderStatus orderStatus,ref string msg);

        /// <summary>
        /// 获取未完成订单
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        IPagedList<OrderDto> QueryUnfinishedOrder(int memberId, int pageNumber, int pageSize);


        /// <summary>
        /// 获取未完成订单
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        IPagedList<OrderDto> QueryFinishedOrder(int memberId, int pageNumber, int pageSize);
    }
}
