using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;

namespace EasyLife.Core.ShoppingCart
{
    public interface IShoppingCartRepository:IRepository<ShoppingCart,int>
    {
        List<ShoppingCartViewModel> QueryShoppingCartList(int userId, int pageNumber, int pageSize, out int totalCount);

        IEnumerable<ShoppingCart> QueryShoppingCartList(Func<ShoppingCart, bool> priFunc);
    }
}
