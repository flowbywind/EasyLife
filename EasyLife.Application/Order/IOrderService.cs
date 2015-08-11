using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using EasyLife.Application.Order.Dtos;

namespace EasyLife.Application.Order
{
    public  interface IOrderService:IApplicationService
    {
         bool SubmitOrder(OrderDto order,out string msg);
    }
}
