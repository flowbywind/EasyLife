using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Core.Enum
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        [Description("提交订单")]
        Submit = 1,
        [Description("完成订单")]
        Finish = 5,
        [Description("取消订单")]
        Cancle = 9
    }
}
