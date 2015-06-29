using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Core.Enum
{
    /// <summary>
    /// 状态是否可以用
    /// </summary>
    public enum StatusEnum : byte
    {
        /// <summary>
        /// 可用
        /// </summary>
        Enable = 0,
        /// <summary>
        /// 不可用
        /// </summary>
        Disabled = 1
    }

    /// <summary>
    /// 是否最热
    /// </summary>
    public enum HotEnum : byte
    {
        /// <summary>
        /// 是
        /// </summary>
        Yes = 0,
        /// <summary>
        /// 否
        /// </summary>
        No = 1
    }
}
