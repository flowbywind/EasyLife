using EasyLife.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace EasyLife.Web
{
    /// <summary>
    /// 把枚举转换成SelectListItem
    /// </summary>
    public class EnumExt
    {
        /// <summary>
        /// 获取枚举成员的自定义Attribute的一个属性值
        /// </summary>
        /// <param name="e">枚举成员</param>
        /// <returns></returns>
        public static string GetEnumDescription(object e)
        {
            //获取枚举成员的Type对象
            Type t = e.GetType();
            //获取Type对象的所有字段
            FieldInfo[] ms = t.GetFields();
            //遍历所有字段
            foreach (FieldInfo f in ms)
            {
                if (f.Name != e.ToString())
                {
                    continue;
                }
                if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                {
                    return (f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute).DisplayName;
                }
            }
            return e.ToString();
        }
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem { Text = GetEnumDescription(e), Value = (Convert.ToInt32(e)).ToString() });
            }
            return selectList;
        }
    }
}