using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using EasyLife.Core.ShoppingCart;

namespace EasyLife.EntityFramework.Repositories
{
    public class ShoppingCartRepository : EasyLifeRepositoryBase<ShoppingCart,int>,IShoppingCartRepository
    {
        public ShoppingCartRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider):base(dbContextProvider)
        {

        }
    }
}
