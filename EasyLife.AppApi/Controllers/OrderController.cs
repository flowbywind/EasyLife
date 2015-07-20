using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.AppApi.Controllers
{
    public class OrderController : Controller
    {
   
        /// <summary>
        /// 提交订单
        /// </summary>
        /// <returns></returns>
        public ActionResult SubmitOrder()
        {

            //todo 插入订单表
            //todo 将购物车列表插入订单明细表
            //todo 修改购物车状态 为已插入
            return View();
        }
	}
}