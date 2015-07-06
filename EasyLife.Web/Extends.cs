using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Web
{
    public static class Extends
    {
        /// <summary>
        /// 对象转化为Int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this object value, int defaultValue = 0)
        {
            if (value == null) return defaultValue;
            var result = defaultValue;
            return int.TryParse(value.ToString(), out result) ? result : defaultValue;
        }
        /// <summary>
        /// 对象转化为Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object value, decimal defaultValue = 0)
        {
            if (value == null) return defaultValue;
            var result = defaultValue;
            return decimal.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        /// <summary>
        /// 返回Request的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string RequestToString(this object obj, string strValue = "")
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                return strValue;
            return obj.ToString();
        }

        /// <summary>
        /// 返回Request的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static int RequestToInt(this object obj, int strValue = 0)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                return strValue;
            int.TryParse(obj.ToString(), out strValue);
            return strValue;
        }

    }
}