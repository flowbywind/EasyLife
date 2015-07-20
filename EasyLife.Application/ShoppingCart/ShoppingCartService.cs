using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using EasyLife.Application.ShoppingCart.Dtos;
using EasyLife.Core.Enum;
using EasyLife.Core.ShoppingCart;
using PagedList;

namespace EasyLife.Application.ShoppingCart
{
    public  class ShoppingCartService:EasyLifeAppServiceBase,IShoppingCartService
    {
        private readonly IShoppingCartRepository _iShoppingCartRepository;
        public ShoppingCartService(IShoppingCartRepository iShoppingCartRepository)
        {
            _iShoppingCartRepository = iShoppingCartRepository;
        }

        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ShoppingCartDto AddCart(ShoppingCartDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            Core.ShoppingCart.ShoppingCart model=null;
            //todo 校验商家是否存在
            //todo 校验物品是否存在 并且有效
            //todo 检查购物车是否存在 如果存在则加1 不存在则创建
            var existCart = _iShoppingCartRepository.QueryShoppingCartList(
                a =>
                    a.user_id == dto.user_id && a.merchant_id == dto.merchant_id && a.IsDeleted == false &&
                    a.goods_id == dto.goods_id && a.status == (int) ShoppingCartStatus.Add).FirstOrDefault();
            if (existCart != null) //更新
            {
                Core.ShoppingCart.ShoppingCart cart = existCart;
                cart.LastModificationTime = DateTime.Now;
                cart.LastModifierUserId = cart.user_id;
                cart.count = cart.count + dto.count;
                model = _iShoppingCartRepository.Update(cart);
            }
            else //插入
            {
                Core.ShoppingCart.ShoppingCart cart = Mapper.Map<Core.ShoppingCart.ShoppingCart>(dto);
                cart.CreationTime = DateTime.Now;
                cart.CreatorUserId = cart.user_id;
                cart.LastModificationTime = DateTime.Now;
                cart.LastModifierUserId = cart.user_id;
                model = _iShoppingCartRepository.Insert(cart);
            }

            if (model != null)
            {
                return  Mapper.Map<ShoppingCartDto>(model);
            }
            return null;
        }

        public ShoppingCartDto UpdateCart(ShoppingCartDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            Core.ShoppingCart.ShoppingCart model = null;
            //todo 校验商家是否存在
            //todo 校验物品是否存在 并且有效
            //todo 检查购物车是否存在 如果存在则加1 不存在则创建
            var existCart = _iShoppingCartRepository.QueryShoppingCartList(
                a => a.Id==dto.id
                     && a.IsDeleted == false &&
                     a.status == (int)ShoppingCartStatus.Add).FirstOrDefault();
            if (existCart != null) //更新
            {
                Core.ShoppingCart.ShoppingCart cart = existCart;
                cart.LastModificationTime = DateTime.Now;
                cart.LastModifierUserId = cart.user_id;
         
                cart.count = dto.count;
                model = _iShoppingCartRepository.Update(cart);
            }
            if (model != null)
            {
                return Mapper.Map<ShoppingCartDto>(model);
            }
            return null;
        }

        public ShoppingCartDto DeleteCart(ShoppingCartDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            Core.ShoppingCart.ShoppingCart model = null;
            var existCart = _iShoppingCartRepository.QueryShoppingCartList(
                a => a.Id == dto.id
                     && a.IsDeleted == false &&
                     a.status == (int)ShoppingCartStatus.Add).FirstOrDefault();
            if (existCart != null) //更新
            {
                Core.ShoppingCart.ShoppingCart cart = existCart;
                cart.LastModificationTime = DateTime.Now;
                cart.LastModifierUserId = cart.user_id;
                cart.DeletionTime = DateTime.Now;
                cart.DeleterUserId = cart.user_id;
                cart.status = (int) ShoppingCartStatus.HasDelete;
                cart.IsDeleted = true;
                model = _iShoppingCartRepository.Update(cart);
            }
            if (model != null)
            {
                return Mapper.Map<ShoppingCartDto>(model);
            }
            return null;
        }

        /// <summary>
        /// 获取购物车购物列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>购物车商品列表</returns>
        public IPagedList<ShoppingCartDto> QueryShoppingCartList(int userId, int pageNumber, int pageSize)
        {
            int totalCount;

            var list = _iShoppingCartRepository.QueryShoppingCartList(userId, pageNumber, pageSize, out totalCount);
            List<ShoppingCartDto> result=new List<ShoppingCartDto>(); 
            foreach (var item in list)
            {
                if (item.Goods == null)
                {
                     continue;
                }
                result.Add(new ShoppingCartDto()
                {
                    count = item.count,
                    goods_id = item.goods_id,
                    merchant_id = item.merchant_id,
                    id=item.Id,
                    status=item.status,
                    user_id = item.user_id,
                    goods_pic = item.Goods.goods_pic,
                    price=item.Goods.price,
                    discount_price = item.Goods.discount_price,
                    save_money = item.Goods.save_money,
                    goods_name = item.Goods.name
                });
            }

            var pageList = new StaticPagedList<ShoppingCartDto>(result, pageNumber, pageSize, totalCount);
            return pageList;
        }
    
        
    }
}
