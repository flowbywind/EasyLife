using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using EasyLife.Core.Enum;
using EasyLife.Core.Order;

namespace EasyLife.EntityFramework.Repositories
{
    public  class OrderRepository:EasyLifeRepositoryBase<Order,int>,IOrderRepository
    {
        public OrderRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider ):base(dbContextProvider)
        {
        }
   
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <param name="orderStatus">订单状态 为空查全部</param>
        /// <param name="totalCount">总量</param>
        /// <returns></returns>
        public List<Order> QueryOrderList(int memberId, int pageNumber, int pageSize, OrderStatus? orderStatus, out int totalCount)
        {
            ValidatePaged(pageNumber, pageSize);
            using (var db = new EasyLifeDbContext())
            {
                IQueryable<Order> list = from a in db.Order
                    where a.IsDeleted == false  select a;
                if (orderStatus != null)
                {
                    int orderstatus = (int)orderStatus;
                    list = list.Where(a => a.order_status == orderstatus);
                }
                totalCount = list.Count();
                var result =list.OrderByDescending(a => a.LastModificationTime).PageBy((pageNumber - 1) * pageSize, pageSize).ToList();
                //获取订单明细
                foreach (var item in result)
                {
                    var orderdetaillist = db.OrderDetail.Where(a => a.order_id == item.Id).ToList();
                    item.OrderDetails = orderdetaillist;
                }

                return list.ToList();
            }

        }
    
    }
}
