using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyLife.AppApi.Models;
using EasyLife.Application.ShoppingCart;
using EasyLife.Application.ShoppingCart.Dtos;
using PagedList;

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
        /// <param name="merchantId">商家ID</param>
        /// <param name="goodsId">商品ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public ActionResult AddCart(int merchantId, int goodsId, int userId, int count=1)
        {
            ReturnResult<ShoppingCartDto> result = new ReturnResult<ShoppingCartDto>();
            ShoppingCartDto dto = new ShoppingCartDto() {
                merchant_id = merchantId,
                goods_id = goodsId,
                count = count,
                user_id = userId
            };
            var cart = _iShoppingCartService.AddCart(dto);
            result.result = cart;
            result.success = cart!=null? true: false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public ActionResult UpdateCart(int cartId,int userId,int count)
        {
            ReturnResult<ShoppingCartDto> result = new ReturnResult<ShoppingCartDto>();
            ShoppingCartDto dto = new ShoppingCartDto() {
               id=cartId,count = count
            };
            var cart = _iShoppingCartService.UpdateCart(dto);
            result.result = cart;
            result.success = cart != null ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="cartId">购物车</param>
        /// <returns></returns>
        public ActionResult DeleteCart(int cartId,int userId)
        {
            ReturnResult<ShoppingCartDto> result = new ReturnResult<ShoppingCartDto>();
            ShoppingCartDto dto = new ShoppingCartDto() {
                id = cartId,
            };
            var cart = _iShoppingCartService.DeleteCart(dto);
            result.result = cart;
            result.success = cart != null ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取购物车列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageNumber">页码</param>
        /// <returns></returns>
        public ActionResult QueryShoppingCartList(int userId,int pageSize,int pageNumber)
        {
            ReturnResult<IPagedList<ShoppingCartDto>> result=new ReturnResult<IPagedList<ShoppingCartDto>>();
            var list = _iShoppingCartService.QueryShoppingCartList(userId, pageNumber, pageSize);
            result.result = list;
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    

    }
}