using Application.Extension.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumCommon
    {
        #region 得到枚举字典（key对应枚举的值，value对应枚举的注释）

        /// <summary>
        /// 得到枚举字典（key对应枚举的值，value对应枚举的注释）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> ToDescriptionDictionary<TEnum>()
        {
            Array arrays = Enum.GetValues(typeof(TEnum));
            Dictionary<int, string> dics = new Dictionary<int, string>();
            foreach (Enum? value in arrays)
            {
                dics.Add(Convert.ToInt32(value), GetDescription(value));
            }

            return dics;
        }

        #endregion

        #region 得到枚举对应的值与自定义属性集合

        /// <summary>
        /// 得到枚举与对应的自定义属性信息
        /// </summary>
        /// <typeparam name="T">自定义属性</typeparam>
        /// <returns></returns>
        public static Dictionary<Enum, T> ToEnumAndAttributes<T>(this Type type) where T : Attribute
        {
            Array arrays = Enum.GetValues(type);
            Dictionary<Enum, T> dics = new Dictionary<Enum, T>();

            foreach (Enum? item in arrays)
            {
                if (item != null)
                {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
                    dics.Add(item, GetCustomerObj<T>(item));
#pragma warning restore CS8604 // 引用类型参数可能为 null。
                }
            }

            return dics;
        }

        #endregion

        #region 得到枚举字典key的集合

        /// <summary>
        /// 得到枚举字典key的集合（例如：enum Gender{
        ///    Boy=0,
        ///    Girl=1
        /// }）//其中Girl与Boy为Key
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<string> GetKeys<TEnum>()
        {
            Array arrays = Enum.GetValues(typeof(TEnum));
            List<string> keys = new List<string>();
            foreach (Enum? key in arrays)
            {
                if (key != null)
                {
                    keys.Add(key.ToString());
                }
            }

            return keys;
        }

        #endregion

        #region 得到枚举字典value的集合

        /// <summary>
        /// 得到枚举字典value的集合
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static List<int> GetValues<TEnum>()
        {
            Array arrays = Enum.GetValues(typeof(TEnum));
            List<int> values = new List<int>();
            foreach (Enum? value in arrays)
            {
                if (value != null)
                {
                    values.Add(Convert.ToInt32(value));
                }
            }

            return values;
        }

        #endregion

        #region 得到枚举字典自定义属性的集合

        /// <summary>
        /// 得到枚举字典自定义属性的集合
        /// </summary>
        /// <param name="type">type必须是枚举</param>
        /// <returns></returns>
        public static List<T> GetCustomerObjects<T>(this Type type) where T : Attribute
        {
            if (!type.IsEnum)
            {
                throw new BusinessException(nameof(type) + "不是枚举");
            }

            Array arrays = Enum.GetValues(type);
            return (from Enum array in arrays
                    select CustomAttributeCommon<T>.GetCustomAttribute(type, nameof(array))).ToList();
        }

        #endregion

        #region 返回枚举项的描述信息

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(Type type, object member)
        {
            return GetCustomerObj<DescriptionAttribute>(type, member)?.Description ?? string.Empty;
        }

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="member">成员名、值、实例均可</param>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription<TEnum>(object member)
        {
            return GetDescription(TypeCommon.GetType<TEnum>(), member);
        }

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(this Enum? value)
        {
            return GetCustomerObj<DescriptionAttribute>(value)?.Description ?? string.Empty;
        }

        #endregion

        #region 得到自定义描述

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="member">成员名、值、实例均可</param>
        /// <typeparam name="T">得到自定义描述</typeparam>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static T? GetCustomerObj<T, TEnum>(object member) where T : Attribute
        {
            return GetCustomerObj<T>(TypeCommon.GetType<TEnum>(), member);
        }

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <typeparam name="T">得到自定义描述</typeparam>
        /// <returns></returns>
        public static T? GetCustomerObj<T>(Type type, object member) where T : Attribute
        {
            if (member.IsExist(type))
            {
                return CustomAttributeCommon<T>
                    .GetCustomAttribute(type, GetKey(type, member));
            }

            return default;
        }

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetCustomerObj<T>(this Enum? value) where T : Attribute
        {
            if (value == null)
            {
                return null;
            }

            return CustomAttributeCommon<T>.GetCustomAttribute(value.GetType(), value.ToString());
        }

        #endregion

        #region 判断值是否在枚举类型中存在

        /// <summary>
        /// 判断值是否在枚举中存在
        /// </summary>
        /// <param name="enumValue">需要判断的参数</param>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static bool IsExist(this object enumValue, Type enumType)
        {
            if (enumValue == null)
            {
                return false;
            }

            return Enum.IsDefined(enumType, enumValue);
        }

        #endregion

        #region 获取枚举的成员名

        /// <summary>
        /// 获取枚举实例
        /// </summary>
        /// <param name="member">枚举类型</param>
        /// <typeparam name="TEnum">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1或者Gender.Boy可获得其key</typeparam>
        /// <returns></returns>
        public static string GetKey<TEnum>(object member)
        {
            return GetKey(TypeCommon.GetType<TEnum>(), member);
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1或者Gender.Boy可获得其Key</param>
        public static string GetKey(Type type, object member)
        {
            if (type == null || member == null || !TypeCommon.IsEnum(type))
                return string.Empty;

            if (member.IsInt())
            {
                return Enum.GetName(type, member.ConvertToInt(0)) ?? string.Empty;
            }

            if (member is string)
            {
                return member.ToString() ?? string.Empty;
            }

            return Enum.GetName(type, member) ?? string.Empty;
        }

        #endregion
    }
}
