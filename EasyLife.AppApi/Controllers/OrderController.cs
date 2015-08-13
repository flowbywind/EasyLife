using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Application.Order;
using EasyLife.Application.Order.Dtos;
using EasyLife.Core.Enum;
using PagedList;

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

        /// <summary>
        /// 获取未完成订单
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        public ActionResult QueryUnfinishOrder(int memberId,int pageNumber,int pageSize)
        {
            ReturnResult<IPagedList<OrderDto>> result = new ReturnResult<IPagedList<OrderDto>>();
            var list = _iOrderService.QueryUnfinishedOrder(memberId, pageNumber, pageSize);
            result.result = list;
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取未已完成订单
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        public ActionResult QueryFinishOrder(int memberId, int pageNumber, int pageSize)
        {
            ReturnResult<IPagedList<OrderDto>> result = new ReturnResult<IPagedList<OrderDto>>();
            var list = _iOrderService.QueryFinishedOrder(memberId, pageNumber, pageSize);
            result.result = list;
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 完成订单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="memberId">会员ID</param>
        /// <returns></returns>
        public ActionResult FinishOrder(int orderId, int memberId)
        {
            ReturnResult<BoolModel> result =new ReturnResult<BoolModel>();
            string msg=string.Empty;
            bool flag = _iOrderService.UpdateOrderStatus(orderId, memberId, OrderStatus.Finish,ref msg);
            result.success = flag;
            result.result=new BoolModel(flag);
            if (flag == false)
            {
                result.error=new Error(ReturnCode.Failure, msg);
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="memberId">会员ID</param>
        /// <returns></returns>
        public ActionResult CancleOrder(int orderId, int memberId)
        {
            ReturnResult<BoolModel> result = new ReturnResult<BoolModel>();
            string msg = string.Empty;
            bool flag = _iOrderService.UpdateOrderStatus(orderId, memberId, OrderStatus.Cancle, ref msg);
            result.success = flag;
            result.result = new BoolModel(flag);
            if (flag == false)
            {
                result.error = new Error(ReturnCode.Failure, msg);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}