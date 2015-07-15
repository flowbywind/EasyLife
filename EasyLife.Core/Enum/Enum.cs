using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// 启用
        /// </summary>
        [EnumDisplayName("启用")]
        Enable = 0,

        /// <summary>
        /// 禁用
        /// </summary>
        [EnumDisplayName("禁用")]
        Disable = 1
    }

    /// <summary>
    /// 是否最热
    /// </summary>
    public enum HotEnum : byte
    {
        /// <summary>
        /// 是
        /// </summary>
        [EnumDisplayName("是")]
        Yes = 0,
        /// <summary>
        /// 否
        /// </summary>
        [EnumDisplayName("否")]
        No = 1
    }

    public enum SexEnum : byte
    {
        /// <summary>
        /// 是
        /// </summary>
        [EnumDisplayName("男")]
        Male = 0,
        /// <summary>
        /// 否
        /// </summary>
        [EnumDisplayName("女")]
        Female = 1
    }
}
