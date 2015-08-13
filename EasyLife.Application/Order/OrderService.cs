using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EasyLife.Application.Order.Dtos;
using EasyLife.Core.Enum;
using EasyLife.Core.Order;
using EasyLife.Core.ShoppingCart;
using PagedList;

namespace EasyLife.Application.Order
{
    public class OrderService:IOrderService
    {
        private IOrderRepository _iOrderRepository;
        private IOrderDetailRepository _iOrderDetailRepository;
        private IShoppingCartRepository _iShoppingCartRepository;
        private IGoodsRepository _iGoodsRepository;
        public OrderService(IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository,IShoppingCartRepository shoppingCartRepository,IGoodsRepository goodsRepository)
        {
            _iOrderRepository = orderRepository;
            _iOrderDetailRepository = orderDetailRepository;
            _iShoppingCartRepository = shoppingCartRepository;
            _iGoodsRepository = goodsRepository;
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="orderdto">订单</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
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
            EasyLife.Core.Order.Order order = Mapper.Map<OrderDto, EasyLife.Core.Order.Order>(orderdto);
            order.order_status = (int) OrderStatus.Submit;
            order.order_date=DateTime.Now;
            order.CreationTime=DateTime.Now;
            order.CreatorUserId = order.member_id;
            order.LastModifierUserId = order.member_id;
            order.LastModificationTime=DateTime.Now;
            int oderId = _iOrderRepository.InsertAndGetId(order);
            //todo 将购物车列表插入订单明细表
            foreach (var detail in orderdto.OrderDetailDtos)
            {
                OrderDetail orderdetail = Mapper.Map<OrderDetailDto, OrderDetail>(detail);
                var  good = _iGoodsRepository.FirstOrDefault(a=>a.Id==orderdetail.goods_id && a.IsDeleted==false && a.status==(int)GoodStatus.Valid);
                if (good == null)
                {
                    continue;
                }
                var shoppingCart = _iShoppingCartRepository.QueryShoppingCartList(
            a => a.Id == orderdetail.shoppingcart_id
                 && a.IsDeleted == false &&
                 a.status == (int)ShoppingCartStatus.Add).FirstOrDefault();
                if (shoppingCart == null)
                {
                    continue;
                }
                orderdetail.count = shoppingCart.count;
                // 提交订单时 确定价格 和计算节省金额
                orderdetail.price = good.price;
                orderdetail.discount_price = good.discount_price;
                orderdetail.discount = good.discount;
                orderdetail.save_money = Math.Round((good.price - good.discount_price) * shoppingCart.count, 1, MidpointRounding.AwayFromZero); //四舍五入 取1位小数
                orderdetail.goods_name = good.name;
                orderdetail.goods_pic = good.goods_pic;
                orderdetail.order_id = oderId;
                orderdetail.CreatorUserId = order.member_id;
                orderdetail.CreationTime=DateTime.Now;
                orderdetail.LastModifierUserId = order.member_id;
                orderdetail.LastModificationTime=DateTime.Now;
                int num = _iOrderDetailRepository.Add(orderdetail);
                if (num > 0 || num==0)
                {
                    // 修改购物车状态 为已购买
                    EasyLife.Core.ShoppingCart.ShoppingCart cart = shoppingCart;
                    cart.status = (int)ShoppingCartStatus.HasBuy;
                    cart.LastModificationTime = DateTime.Now;
                    cart.LastModifierUserId = order.member_id;
                    cart = _iShoppingCartRepository.UpdateShoppingCartStatus(cart.Id, ShoppingCartStatus.HasBuy);
                }
            }
            return true;
        }

        /// <summary>
        /// 获取未完成订单
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        public IPagedList<OrderDto> QueryUnfinishedOrder(int memberId, int pageNumber, int pageSize)
        {
            int totalCount;
            var list =_iOrderRepository.QueryOrderList(memberId, pageNumber, pageSize, OrderStatus.Submit, out totalCount);
            var result = ConvertOrderToDto(list);
            var pageList = new StaticPagedList<OrderDto>(result, pageNumber, pageSize, totalCount);
            return pageList;
        }

        /// <summary>
        /// 获取未完成订单
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        public IPagedList<OrderDto> QueryFinishedOrder(int memberId, int pageNumber, int pageSize)
        {
            int totalCount;
            var list = _iOrderRepository.QueryOrderList(memberId, pageNumber, pageSize, OrderStatus.Finish, out totalCount);
            var result = ConvertOrderToDto(list);
            var pageList = new StaticPagedList<OrderDto>(result, pageNumber, pageSize, totalCount);
            return pageList;
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="memberId">用户ID</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public bool UpdateOrderStatus(int orderId,int memberId,OrderStatus orderStatus,ref string msg)
        {
            var order =  _iOrderRepository.FirstOrDefault(a=>a.Id==orderId && a.member_id==memberId);
            if (order != null)
            {
                order.order_status = (int)orderStatus;
                _iOrderRepository.Update(order);
                return true;
            }
            msg = "未找到该订单或该订单不属于此用户";
            return false;
        }

        /// <summary>
        /// 转换订单实体类
        /// </summary>
        /// <param name="list">订单集合</param>
        /// <returns></returns>
        private List<OrderDto> ConvertOrderToDto(List<EasyLife.Core.Order.Order> list)
        {
            List<OrderDto> result = new List<OrderDto>();
            if (list != null && list.Any())
            {
                foreach (var order in list)
                {
                    var orderdto = Mapper.Map<EasyLife.Core.Order.Order, OrderDto>(order);
                    orderdto.OrderDetailDtos = Mapper.Map<List<OrderDetail>, List<OrderDetailDto>>(order.OrderDetails);
                    result.Add(orderdto);
                }
            }
            return result;
        }


    }
}
