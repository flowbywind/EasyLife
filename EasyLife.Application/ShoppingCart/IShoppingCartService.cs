
using System.Collections.Generic;
using Abp.Application.Services;
using EasyLife.Application.ShoppingCart.Dtos;
using PagedList;

namespace EasyLife.Application.ShoppingCart
{
    public interface IShoppingCartService : IApplicationService
    {
        ShoppingCartDto AddCart(ShoppingCartDto dto);
        ShoppingCartDto UpdateCart(ShoppingCartDto dto);
        ShoppingCartDto DeleteCart(ShoppingCartDto dto);
        IPagedList<ShoppingCartDto> QueryShoppingCartList(int userId, int pageNumber, int pageSize);

    }
}
