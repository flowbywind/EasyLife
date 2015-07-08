
using Abp.Application.Services;
using EasyLife.Application.ShoppingCart.Dtos;

namespace EasyLife.Application.ShoppingCart
{
    public interface IShoppingCartService : IApplicationService
    {
        bool AddCart(ShoppingCartDto dto);

    }
}
