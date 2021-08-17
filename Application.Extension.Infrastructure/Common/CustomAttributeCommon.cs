using System;
using System.Reflection;

namespace Application.Extension.Infrastructure.Common
{
    public static class CustomAttributeCommon<T, TSource>
        where T : Attribute
        where TSource : IComparable
    {

    }


    /// <summary>
    /// 自定义属性帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class CustomAttributeCommon<T> where T : Attribute
    {
        #region 得到自定义描述

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="sourceType">类类型</param>
        /// <param name="name">属性名称</param>
        /// <returns></returns>
        public static T? GetCustomAttribute(Type sourceType, string name)
        {
            // 获取枚举常数名称。
            if (!string.IsNullOrEmpty(name))
            {
                // 获取枚举字段。
                FieldInfo? fieldInfo = sourceType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    if (Attribute.GetCustomAttribute(fieldInfo,
                        typeof(T), false) is T attr)
                    {
                        return attr;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
