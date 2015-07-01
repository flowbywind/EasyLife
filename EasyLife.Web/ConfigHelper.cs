using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EasyLife.Web
{
    public class ConfigHelper
    {
        /// <summary>
        /// 分页配置
        /// </summary>
        public static int PageSize = ConfigurationManager.AppSettings["PageSize"].ToString().Trim().ToInt();
    }
}