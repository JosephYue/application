using System;
using System.Collections.Generic;
using System.Reflection;

namespace Application.Extension.Infrastructure.Extensions
{
    /// <summary>
    /// Distinct指定字段排序
    /// </summary>
    public class PropertyComparerExtension<T> : IEqualityComparer<T>
    {
        private readonly PropertyInfo? propertyInfo;

        /// <summary>
        /// 通过propertyName 获取PropertyInfo对象    
        /// </summary>
        /// <param name="propertyName">仅支持字段名（区分大小写）</param>
        public PropertyComparerExtension(string propertyName)
        {
            propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);

            if (propertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type {1}.",
                    propertyName, typeof(T)));
            }
        }

        #region IEqualityComparer<T> Members

#pragma warning disable CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
        public bool Equals(T x, T y)
#pragma warning restore CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
        {
            if (propertyInfo == null)
            {
                return false;
            }

            object? xValue = propertyInfo.GetValue(x);
            object? yValue = propertyInfo.GetValue(y);

            if (xValue == null)
                return yValue == null;

            return xValue.Equals(yValue);
        }

        public int GetHashCode(T obj)
        {
            if (propertyInfo == null)
            {
                return 0;
            }

            object? propertyValue = propertyInfo.GetValue(obj, null);

            if (propertyValue == null)
                return 0;
            else
                return propertyValue.GetHashCode();
        }

        #endregion
    }
}
