using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Core.Enum
{
    public enum ShoppingCartStatus
    {
        [Description("加入")]
        Add=0,
        [Description("已提交订单")]
        HasBuy=1,
        [Description("已删除")]
        HasDelete=2
    }
}
