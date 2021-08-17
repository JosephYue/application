using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Jingdong.Extension
{
    internal sealed class Utils
    {
        #region 获取开普勒签名

        /// <summary>
        /// 获取开普勒签名
        /// </summary>
        /// <param name="parameters">所有字符型的Jd请求参数</param>
        /// <param name="secret">签名密钥</param>
        /// <returns>签名</returns>
        public static string GetJingDongKeplerSign(IDictionary<string, string> parameters, string secret)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder(secret);
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(value);
                }
            }

            query.Append(secret);

            return GetMd5Hash(query.ToString(), false, isUpper: true);
        }

        #endregion

        #region 获取京东联盟签名

        /// <summary>
        /// 获取京东联盟签名
        /// </summary>
        /// <param name="parameters">所有字符型的Jd请求参数</param>
        /// <param name="secret">签名密钥</param>
        /// <returns>签名</returns>
        public static string GetJingDongAllianceSign(IDictionary<string, string> parameters, string secret)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder(secret);
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(value);
                }
            }

            query.Append(secret);

            // 第三步：使用MD5加密
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));

            // 第四步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }

            return result.ToString();
        }

        #endregion

        #region Http

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="httpClient">httpClient</param>
        /// <param name="url">地址</param>
        /// <param name="data">参数信息</param>
        /// <returns></returns>
        public static string DoPost(HttpClient httpClient, string url, IDictionary<string, string> data)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (data != null)
            {
                var dataStr = string.Join("&", data.ToList().Select(x => x.Key + "=" + HttpUtility.UrlEncode(x.Value)));

                var content = new StringContent(dataStr);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                request.Content = content;
            }

            var response = httpClient.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="httpClient">httpClient</param>
        /// <param name="url">地址</param>
        /// <param name="data">参数信息</param>
        /// <returns></returns>
        public static async Task<string> DoPostAsync(HttpClient httpClient, string url, IDictionary<string, string> data)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (data != null)
            {
                var dataStr = string.Join("&", data.ToList().Select(x => x.Key + "=" + x.Value));

                var content = new StringContent(dataStr);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                request.Content = content;
            }

            var response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="httpClient">httpClient</param>
        /// <param name="url">地址</param>
        /// <param name="query">参数信息</param>
        /// <returns></returns>
        public static string Get(HttpClient httpClient, string url, IDictionary<string, string> query = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (query != null)
            {
                url = FormatQuery(url, query);
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = httpClient.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="httpClient">httpClient</param>
        /// <param name="url">地址</param>
        /// <param name="query">参数信息</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(HttpClient httpClient, string url, IDictionary<string, string> query = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (query != null)
            {
                url = FormatQuery(url, query);
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        #endregion

        #region Private

        /// <summary>
        /// ASCII排序
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        private static Dictionary<string, string> ASCIIDictionary(IDictionary<string, string> dic)
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

        /// <summary>
        /// 获取md5加密信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="is16"></param>
        /// <param name="encoding"></param>
        /// <param name="isUpper"></param>
        /// <returns></returns>
        private static string GetMd5Hash(string input, bool is16, Encoding encoding = null, bool isUpper = true)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            MD5 myMd5 = new MD5CryptoServiceProvider();
            var signed = myMd5.ComputeHash(encoding.GetBytes(input));
            string signResult = is16 ? GetSignResult(signed, 4, 8) : GetSignResult(signed);
            return isUpper ? signResult.ToUpper() : signResult.ToLower();
        }

        /// <summary>
        /// MD5加密方法
        /// startIndex为空为32位加密
        /// </summary>
        /// <param name="signed"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetSignResult(byte[] signed, int? startIndex = null, int? length = null)
        {
            return (startIndex == null
                ? BitConverter.ToString(signed)
                : BitConverter.ToString(signed, (int)startIndex, length ?? default(int))).Replace("-", "");
        }

        private static string FormatQuery(string url, IDictionary<string, string> query)
        {
            if (query != null)
            {
                var builder = new StringBuilder(url);
                builder.Append("?");

                foreach (var q in query)
                {
                    builder.Append($"{q.Key}={ HttpUtility.UrlEncode(q.Value)}&");
                }

                url = builder.ToString().TrimEnd('&');
            }

            return url;
        }

        #endregion
    }
}
