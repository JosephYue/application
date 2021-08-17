using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Application.DingTalk.Extension
{
    /// <summary>
    /// 工具类
    /// </summary>
    internal static class Utils
    {
        #region 时间转换为时间戳

        /// <summary>
        /// 时间转换为时间戳
        /// </summary>
        /// <param name="time">时间信息</param>
        /// <param name="isMillisecond">是否是毫秒级时间戳</param>
        /// <returns></returns>
        public static long ConvertDateToUnix(this DateTime time, bool isMillisecond = true)
        {
            DateTime Jan1stTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            if (!isMillisecond)
            {
                return (long)(time.AddHours(-8) - Jan1stTime).TotalSeconds;
            }

            return (long)(time.AddHours(-8) - Jan1stTime).TotalMilliseconds;
        }

        #endregion

        #region 加密

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="sign">timestamp+"\n"+密钥</param>
        /// <param name="secret">配置的签名</param>
        /// <returns></returns>
        private static byte[] GetHmac(string sign, string secret)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(secret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(sign);
            using var hmacsha256 = new HMACSHA256(keyByte);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return hashmessage;
        }

        #endregion

        #region 获取自定义机器人请求完整地址

        /// <summary>
        /// 获取自定义机器人请求完整地址
        /// </summary>
        /// <returns></returns>
        public static string GetCustomRobotWebhook()
        {
            if (!string.IsNullOrWhiteSpace(DingTalkContainer.CustomRobotOptions.Signature))
            {
                var timestamp = DateTime.Now.ConvertDateToUnix();

                var sign = timestamp + "\n" + DingTalkContainer.CustomRobotOptions.Signature;

                var base64Str = Convert.ToBase64String(GetHmac(sign, DingTalkContainer.CustomRobotOptions.Signature));

                return $"{DingTalkContainer.CustomRobotOptions.Webhook}&timestamp={timestamp}&sign={HttpUtility.UrlEncode(base64Str)}";
            }

            return DingTalkContainer.CustomRobotOptions.Webhook;
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
                return new object();
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
