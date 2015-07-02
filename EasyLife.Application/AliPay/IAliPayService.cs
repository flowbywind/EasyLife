using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application
{
  public  interface IAliPayService : IApplicationService
    {
      string AppTradeData(OrderInfoDto input);
    }
}
