using Newtonsoft.Json;
using System;

namespace Application.ChannelMessage.Extension.Config
{
    internal sealed class Utils
    {
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
                return JsonConvert.DeserializeObject<T>(o);
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
                return JsonConvert.DeserializeObject(o, type);
            }
            catch (Exception)
            {
                return default;
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
    }
}
