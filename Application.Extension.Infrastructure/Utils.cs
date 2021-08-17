using Application.Extension.Infrastructure.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.Extension.Infrastructure
{
    public static class Utils
    {
        #region 读取文本文件

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="url">文本文件路径</param>
        /// <returns></returns>
        public static string ReadText(string url)
        {
            using (StreamReader sr = new StreamReader(url))
            {
                string line = "";

                // 从文件读取并显示行，直到文件的末尾 
                while (string.IsNullOrWhiteSpace(line = sr.ReadLine() ?? string.Empty))
                {
                    return line;
                }

                return line;
            };
        }

        #endregion

        #region 图片合并

        /// <summary>
        /// 图片合并（操作原理，简单的图片叠加）
        /// </summary>
        /// <param name="picOneBase64Str">第一张图（背景图，第二张图需要叠加到第一张上）</param>
        /// <param name="picTwoBase64Str">第二张图（需要比第一张图小）</param>
        /// <param name="x">坐标x</param>
        /// <param name="y">坐标y</param>
        /// <returns></returns>
        public static string MergeImage(string picOneBase64Str, string picTwoBase64Str, int x = 0, int y = 0)
        {
            if (string.IsNullOrEmpty(picOneBase64Str))
            {
                throw new BusinessException("请传入第一张图片base64");
            }

            if (string.IsNullOrEmpty(picTwoBase64Str))
            {
                throw new BusinessException("请传入第二张图片base64");
            }

            if (x < 0 || y < 0)
            {
                throw new BusinessException("坐标不能传入负数");
            }

            try
            {
                byte[] templebytes = Convert.FromBase64String(picOneBase64Str);
                byte[] outputbytes = Convert.FromBase64String(picTwoBase64Str);

                var imagesTemle = Image.Load(templebytes, out IImageFormat format);

                var outputImg = Image.Load(outputbytes);

                if (imagesTemle.Height - (outputImg.Height + y) <= 0)
                {
                    throw new BusinessException("Y坐标高度超限");
                }
                if (imagesTemle.Width - (outputImg.Width + x) <= 0)
                {
                    throw new BusinessException("X坐标宽度超限");
                }

                //进行多图片处理
                imagesTemle.Mutate(img =>
                {
                    //还是合并 
                    img.DrawImage(outputImg, new Point(x, y), 1);
                });

                return imagesTemle.ToBase64String(format);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"合并图片错误，错误原因:{ex.Message}");
            }
        }

        #endregion

        #region 将文字写入图片上

        /// <summary>
        /// 将文字写入图片上
        /// </summary>
        /// <param name="picBase64Str">图片base64编码 注：请将,前面的image字段删除</param>
        /// <param name="fontFunc">委托，用来处理你自己的方法</param>
        /// <param name="textInfos">文本信息 一个文本对应一个坐标对应一个颜色</param>
        /// <param name="typeface">字体 默认微软字体 SIMHEI.TTF（只能使用微软字体）</param>
        /// <returns></returns>
        public static string DrawText(string picBase64Str, Func<FontFamily, Font> fontFunc, string typeface = "SIMHEI.TTF", params ValueTuple<string, Color, int, int>[] textInfos)
        {
            if (string.IsNullOrEmpty(picBase64Str))
            {
                throw new BusinessException("请传入图片信息");
            }

            byte[] templebytes = Convert.FromBase64String(picBase64Str);

            var imagesTemle = Image.Load(templebytes, out IImageFormat format);

            #region 设置字体信息

            FontCollection fonts = new FontCollection();
            //字体的路径
            FontFamily fontfamily = fonts.Install($@"\Application.Extension.Infrastructure\Fonts\{typeface}");
            var funcResult = fontFunc.Invoke(fontfamily);

            #endregion

            foreach (var info in textInfos)
            {
                var (text, color, x, y) = info;

                imagesTemle.Mutate(img =>
                {
                    img.DrawText(text, funcResult, color, new PointF(x, y));
                });
            }

            return imagesTemle.ToBase64String(format);
        }

        #endregion

        #region 获取当前服务器标准时间

        /// <summary>
        /// 获取当前服务器标准时间（假设服务器是utc时间，此方法用来获取标准时间）
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime dtZone = new DateTime(1970, 1, 1, 0, 0, 0);
            double intResult = (utcNow - dtZone).TotalSeconds;

            return ConvertIntDatetime(intResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        static DateTime ConvertIntDatetime(double utc)

        {
            DateTime dtZone = new DateTime(1970, 1, 1, 0, 0, 0);

            dtZone = dtZone.AddSeconds(utc);

            dtZone = dtZone.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )            

            return dtZone;
        }

        #endregion

        #region Json反序列化

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(string o) where T : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(o) ?? new T();
            }
            catch (Exception)
            {
                return new T();
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type">参数类型</param>
        /// <returns></returns>
        public static object JsonDeserialize(string o, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(o, type) ?? new object();
            }
            catch (Exception)
            {
                return Activator.CreateInstance(type) ?? new object();
            }
        }

        #endregion

        #region Json序列化

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string JsonSerializer(object o)
        {
            try
            {
                return JsonConvert.SerializeObject(o);
            }
            catch (Exception)
            {
                return "";
            }
        }

        #endregion

        #region 分页用法

        /// <summary>
        /// 分页用法(获取分页后的页数)
        /// </summary>
        /// <param name="count">总条数</param>
        /// <param name="pageSize">一页多少条（默认一页50条）</param>
        /// <param name="pages">输出参数 一共多少页</param>
        public static void PagesGet(int count, out int pages, int pageSize = 50)
        {
            //分了几页
            if (count <= pageSize)
            {
                //总条数小于 一页查几条 则 分1页查询
                pages = 1;
            }
            else
            {
                //反之分页总数 等于 总条数除以 一页多少条 加上总条数取余 一页显示多少条 取余为0则为0 反之为 1
                pages = count / pageSize + ((count % pageSize == 0) ? 0 : 1);
            }
        }

        /// <summary>
        /// 分页用法(获取分页后的页数)
        /// </summary>
        /// <param name="count">总条数</param>
        /// <param name="pageSize">一页多少条（默认一页50条）</param>
        /// <param name="pages">输出参数 一共多少页</param>
        public static void PagesGet(long count, out long pages, long pageSize = 50)
        {
            //分了几页
            if (count <= pageSize)
            {
                //总条数小于 一页查几条 则 分1页查询
                pages = 1;
            }
            else
            {
                //反之分页总数 等于 总条数除以 一页多少条 加上总条数取余 一页显示多少条 取余为0则为0 反之为 1
                pages = count / pageSize + ((count % pageSize == 0) ? 0 : 1);
            }
        }

        #endregion

        #region MemoryCache

        /// <summary>
        /// 获取本地缓存
        /// </summary>
        /// <returns></returns>
        public static MemoryCache GetMemoryCache()
        {
            return new MemoryCache(new MemoryCacheOptions());
        }

        #endregion

        #region 将字典值进行ASCII排序

        /// <summary>
        /// 将字典值进行ASCII排序
        /// </summary>
        /// <param name="dic">字典值</param>
        /// <returns></returns>
        public static Dictionary<string, string> ASCIIDictionary(this Dictionary<string, string> dic)
        {
            Dictionary<string, string> asciiDic = new Dictionary<string, string>();
            string[] arrKeys = dic.Keys.ToArray();
            Array.Sort(arrKeys, string.CompareOrdinal);
            foreach (var key in arrKeys)
            {
                string value = dic[key];
                asciiDic.Add(key, value);
            }
            return asciiDic;
        }

        #endregion

        #region 获取数组中重复的数字

        /// <summary>
        /// 获取数组中重复的数字
        /// </summary>
        /// <param name="data">数组</param>
        /// <returns></returns>
        public static List<int> FindRepeat(this int[] data)
        {
            List<int> result = new List<int>();

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < data.Length; i++)
            {
                dict[data[i]] = 0;
            }

            for (int i = 0; i < data.Length; i++)
            {
                int key = data[i];
                if (dict[key] == 1)
                {
                    result.Add(key);
                }
                dict[key] = 1;
            }

            return result;
        }

        /// <summary>
        /// 获取数组中重复的数字
        /// </summary>
        /// <param name="data">数组</param>
        /// <returns></returns>
        public static List<int> FindRepeat(this List<int> data)
        {
            List<int> result = new List<int>();

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < data.Count; i++)
            {
                dict[data[i]] = 0;
            }

            for (int i = 0; i < data.Count; i++)
            {
                int key = data[i];
                if (dict[key] == 1)
                {
                    result.Add(key);
                }
                dict[key] = 1;
            }

            return result;
        }

        #endregion
    }
}
