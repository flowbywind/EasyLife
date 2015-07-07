using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyLife.Application.ShoppingCart.Dtos;
using EasyLife.Core.ShoppingCart;

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
        public bool AddCart(ShoppingCartDto dto)
        {
            if (dto == null)
            {
                return false;
            }
            Core.ShoppingCart.ShoppingCart cart = Mapper.Map<Core.ShoppingCart.ShoppingCart>(dto);
             var model =  _iShoppingCartRepository.Insert(cart);
            if (model == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
