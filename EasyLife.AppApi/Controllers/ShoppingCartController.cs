using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Application.ShoppingCart;
using EasyLife.Application.ShoppingCart.Dtos;

namespace EasyLife.AppApi.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartService _iShoppingCartService;
        public ShoppingCartController(IShoppingCartService iShoppingCartService)
        {
            _iShoppingCartService = iShoppingCartService;
        }


        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="goodsId"></param>
        /// <param name="uid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ActionResult AddCart(int merchantId, int goodsId, int uid, int count)
        {
            ReturnResult<bool> result = new ReturnResult<bool>();
            ShoppingCartDto dto = new ShoppingCartDto() {
                merchant_id = merchantId,
                goods_id = goodsId,
                count = count,
                user_id = uid
            };
            bool flag = _iShoppingCartService.AddCart(dto);
            result.result = flag;
            result.success = flag;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}