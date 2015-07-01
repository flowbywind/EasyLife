using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EasyLife.AppApi.Models
{

    public enum ReturnCode
    {

        [Description("未登录")]
        NotLogin = -2,

        [Description("系统异常")]
        Exception = -1,

        [Description("失败")]
        Failure = 0,

        [Description("成功")]
        Success = 1

    }
}