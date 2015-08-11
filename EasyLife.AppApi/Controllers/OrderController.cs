using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Application.Order;
using EasyLife.Application.Order.Dtos;

namespace EasyLife.AppApi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _iOrderService;
        public OrderController(IOrderService service)
        {
            _iOrderService = service;
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <returns></returns>
        public ActionResult SubmitOrder(OrderDto order)
        {
            ReturnResult<BoolModel> result = new ReturnResult<BoolModel>();
            string msg;
            bool flag = _iOrderService.SubmitOrder(order,out msg);
            if (flag == false)
            {
                result.error=new Error(ReturnCode.Failure, msg);
            }
            result.result = new BoolModel(){is_success = flag};
            result.success = flag;
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrder()
        {
            OrderDto dto=new OrderDto();
            dto.OrderDetailDtos=new List<OrderDetailDto>()
            {
                new OrderDetailDto()
                {
                    
                }
            };
            return Json(dto,JsonRequestBehavior.AllowGet);
        }
    }
}