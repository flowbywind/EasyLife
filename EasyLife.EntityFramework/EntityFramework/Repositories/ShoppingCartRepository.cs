using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using EasyLife.Core.Enum;
using EasyLife.Core.ShoppingCart;

namespace EasyLife.EntityFramework.Repositories
{
    public class ShoppingCartRepository : EasyLifeRepositoryBase<ShoppingCart, int>, IShoppingCartRepository
    {
        public ShoppingCartRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 获取购物车列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <param name="totalCount">总量</param>
        /// <returns></returns>
        public List<ShoppingCartViewModel> QueryShoppingCartList(int userId, int pageNumber, int pageSize, out int totalCount)
        {
            ValidatePaged(pageNumber, pageSize);
            using (var db = new EasyLifeDbContext())
            {
                IQueryable<ShoppingCartViewModel> list = from a in db.ShoppingCart
                                                join b in db.Goods on a.goods_id equals b.Id
                                                where a.IsDeleted == false && a.status == (int)ShoppingCartStatus.Add
                                                         select new ShoppingCartViewModel() {
                                                    Goods = b,
                                                    count = a.count,
                                                    goods_id = b.Id,
                                                    Id = a.Id,
                                                    merchant_id = a.merchant_id,
                                                    user_id = a.user_id,
                                                    status = a.status
                                                };
                totalCount = list.Count();
                list.OrderByDescending(a => a.LastModificationTime).PageBy((pageNumber - 1) * pageSize, pageSize);
                return list.ToList();
            }
        }

        /// <summary>
        /// 查询购物车列表
        /// </summary>
        /// <param name="priFunc"></param>
        /// <returns></returns>
        public IEnumerable<ShoppingCart> QueryShoppingCartList(Func<ShoppingCart,bool> priFunc )
        {
            if (priFunc == null)
            {
                return this.GetAll();
            }
            return  this.GetAll().Where(priFunc);
        }

        /// <summary>
        /// 更新购物车状态
        /// </summary>
        /// <param name="shoppingCartId">购物车ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ShoppingCart UpdateShoppingCartStatus(int shoppingCartId,ShoppingCartStatus status)
        {
           
            var shoppingCart = FirstOrDefault(a => a.Id == shoppingCartId);
            if (shoppingCart != null)
            {
                shoppingCart.status = (int) status;
                 using (var db = new EasyLifeDbContext())
                 {
                     db.ShoppingCart.Attach(shoppingCart);
                     db.SaveChanges();
                 }
                return shoppingCart;
            }
            return null;
        }
    }
}
