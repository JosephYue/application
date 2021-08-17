using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Extension.Infrastructure.Extensions
{
    /// <summary>
    /// 可枚举类型扩展
    /// </summary>
    public static class EnumerableExtentions
    {
        /// <summary>
        /// 去除重复数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector">用于去重的表达式，单个字段如：var query = people.DistinctBy(p => p.Id);</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// 按GBK正序排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="memberSelector"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> OrderByGBKAscending<T>(this IEnumerable<T> source, Func<T, string> memberSelector)
        {
            return source.OrderBy(memberSelector, new GBKComparer());
        }

        /// <summary>
        /// 按GBK正序排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="memberSelector"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> ThenByGBK<T>(this IOrderedEnumerable<T> source, Func<T, string> memberSelector)
        {
            return source.ThenBy(memberSelector, new GBKComparer());
        }

        /// <summary>
        /// 随机从指定的List中取出sampleSize个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sampleSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomSample<T>(this IList<T> list, int sampleSize)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (sampleSize > list.Count)
            {
                throw new ArgumentException("sampleSize may not be greater than list count", nameof(sampleSize));
            }

            return GetRandomSampleList(list, sampleSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sampleSize"></param>
        /// <returns></returns>
        static IEnumerable<T> GetRandomSampleList<T>(IList<T> list, int sampleSize)
        {
            var indices = new Dictionary<int, int>();
            int index;
            var rnd = new Random();

            for (int i = 0; i < sampleSize; i++)
            {
                int j = rnd.Next(i, list.Count);

                if (!indices.TryGetValue(j, out index))
                {
                    index = j;
                }

                yield return list[index];

                if (!indices.TryGetValue(i, out index))
                {
                    index = i;
                }

                indices[j] = index;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class GBKComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            Encoding encoding;

            try
            {
                encoding = Encoding.GetEncoding("GBK");
            }
            catch
            {
                encoding = Encoding.GetEncoding("gb2312");
            }

            var xBytes = encoding.GetBytes(x ?? string.Empty);
            var yBytes = encoding.GetBytes(y ?? string.Empty);

            var length = xBytes.Length > yBytes.Length ? yBytes.Length : xBytes.Length;
            for (var i = 0; i < length; i++)
            {
                if (xBytes[i] == yBytes[i])
                {
                    continue;
                }
                return xBytes[i] - yBytes[i];
            }

            return xBytes.Length - yBytes.Length;
        }
    }
}
