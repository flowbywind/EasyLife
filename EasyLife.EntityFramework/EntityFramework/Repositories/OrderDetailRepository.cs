using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using EasyLife.Core.Order;

namespace EasyLife.EntityFramework.Repositories
{
    public class OrderDetailRepository : EasyLifeRepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 添加订单明细
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public int Add(OrderDetail orderDetail)
        {
            using (var db = new EasyLifeDbContext())
            {
                db.OrderDetail.Add(orderDetail);
                return db.SaveChanges();
            }
        }
    }
}
