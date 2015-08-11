using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using EasyLife.Core.Order;

namespace EasyLife.EntityFramework.Repositories
{
    public  class OrderRepository:EasyLifeRepositoryBase<Order,int>,IOrderRepository
    {
        public OrderRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider ):base(dbContextProvider)
        {

        }


    }
}
