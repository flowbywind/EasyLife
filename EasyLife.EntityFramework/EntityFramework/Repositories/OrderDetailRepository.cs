using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using EasyLife.Core.Order;

namespace EasyLife.EntityFramework.Repositories
{
   public  class OrderDetailRepository:EasyLifeRepositoryBase<OrderDetail>,IOrderDetailRepository
   {
       public OrderDetailRepository(IDbContextProvider<EasyLifeDbContext> dbContextProvider) : base(dbContextProvider)
       {
           
       }
    }
}
