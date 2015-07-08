using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace EasyLife.Core.ShoppingCart
{
    public interface IShoppingCartRepository:IRepository<ShoppingCart,int>
    {

    }
}
