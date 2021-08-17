using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Application.Extension.Infrastructure.Common
{
    public static class RandomCommon
    {
        /// <summary>
        /// 随机数生成器
        /// </summary>
        public static Random Generator { get; } = new Random(SystemRandomInt());

        /// <summary>
        /// 获取安全的指定长度的随机内容
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] SystemRandomBytes(int length)
        {
            byte[] buffer = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            return buffer;
        }

        /// <summary>
        /// 获取安全的随机数值
        /// </summary>
        /// <returns></returns>
        public static int SystemRandomInt()
        {
            return BitConverter.ToInt32(SystemRandomBytes(4), 0);
        }

        /// <summary>
        /// 获取随机数值
        /// </summary>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public static int RandomInt(int minValue, int maxValue)
        {
            return Generator.Next(minValue, maxValue);
        }

        /// <summary>
        /// 从集合获取随机的元素
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static T RandomSelection<T>(IList<T> values)
        {
            if (!values.Any())
            {
#pragma warning disable CS8603 // 可能返回 null 引用。
                return default;
#pragma warning restore CS8603 // 可能返回 null 引用。
            }

            return values[Generator.Next(0, values.Count - 1)];
        }

        /// <summary>
		/// 从枚举获取随机的值
		/// 如果枚举不包含任何值则返回0
		/// </summary>
		/// <typeparam name="TEnum">枚举类型</typeparam>
		/// <returns></returns>
		public static TEnum RandomEnum<TEnum>()
            where TEnum : struct, IConvertible
        {
            var values = Enum.GetValues(typeof(TEnum)).OfType<TEnum>().ToList();
            return RandomSelection(values);
        }

        /// <summary>
		/// 生成指定长度的随机字符串
		/// </summary>
		/// <param name="length">字符串长度</param>
		/// <param name="chars">从哪些字符串中取值, 默认字符串 a-zA-Z0-9</param>
		/// <returns></returns>
		public static string RandomString(int length, string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            var buffer = new char[length];
            for (int n = 0; n < length; ++n)
            {
                buffer[n] = chars[Generator.Next(chars.Length)];
            }
            return new string(buffer);
        }
    }
}
