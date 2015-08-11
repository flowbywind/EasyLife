using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyLife.Application.Order.Dtos;
using EasyLife.Core.Enum;
using EasyLife.Core.Order;
using EasyLife.Core.ShoppingCart;

namespace EasyLife.Application.Order
{
    public class OrderService:IOrderService
    {
        private IOrderRepository _iOrderRepository;
        private IOrderDetailRepository _iOrderDetailRepository;
        private IShoppingCartRepository _iShoppingCartRepository;
        public OrderService(IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository,IShoppingCartRepository shoppingCartRepository)
        {
            _iOrderRepository = orderRepository;
            _iOrderDetailRepository = orderDetailRepository;
            _iShoppingCartRepository = shoppingCartRepository;
        }

        public bool  SubmitOrder(OrderDto orderdto,out string msg)
        {
            msg = "";
            if (orderdto == null)
            {
                msg = "订单信息不得为空";
                return false;
            }
            if (orderdto.OrderDetailDtos == null || orderdto.OrderDetailDtos.Any()==false)
            {
                msg = "订单无购物数据";
                return false;
            }
            //todo 插入订单表
            Core.Order.Order order = Mapper.Map<OrderDto, Core.Order.Order>(orderdto);
            order.order_date=DateTime.Now;
            order.CreationTime=DateTime.Now;
            order.CreatorUserId = order.member_id;
            order.LastModifierUserId = order.member_id;
            order.LastModificationTime=DateTime.Now;
            order.Id = _iOrderRepository.InsertAndGetId(order);
            //todo 将购物车列表插入订单明细表
            foreach (var detail in orderdto.OrderDetailDtos)
            {
                OrderDetail orderdetail = Mapper.Map<OrderDetailDto, OrderDetail>(detail);
                orderdetail.order_id = order.Id;
                orderdetail.CreatorUserId = order.member_id;
                orderdetail.CreationTime=DateTime.Now;
                orderdetail.LastModifierUserId = order.member_id;
                orderdetail.LastModificationTime=DateTime.Now;
                 _iOrderDetailRepository.Insert(orderdetail);
                //todo 修改购物车状态 为已插入
                _iShoppingCartRepository.UpdateShoppingCartStatus(orderdetail.shoppingcart_id, ShoppingCartStatus.HasBuy);
            }
            return true;
        }
    }
}
