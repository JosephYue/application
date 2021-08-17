using Application.Extension.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.Http.HttpClientFactory
{
    /// <summary>
    /// 使用此类库需要在StartUp注入AddHttpClient
    /// </summary>
    public class Client
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpClient"></param>
        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Get请求

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <returns></returns>
        public Task<TResult> GetAsync<TResult>(string url)
        {
            return GetAsync<TResult>(url, string.Empty);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="query">查询字符串</param>
        /// <returns></returns>
        public Task<TResult> GetAsync<TResult>(string url, IDictionary<string, string> query)
        {
            return GetAsync<TResult>(url, query, string.Empty);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="jwtToken">Token</param>
        /// <returns></returns>
        public Task<TResult> GetAsync<TResult>(string url, string jwtToken)
        {
            return GetAsync<TResult>(url, null, jwtToken);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="query">查询字符串</param>
        /// <param name="jwtToken">Token</param>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(string url, IDictionary<string, string>? query, string jwtToken)
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
            if (!string.IsNullOrEmpty(jwtToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            var response = await _httpClient.SendAsync(request);
            var resultJsonStr = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // 可能返回 null 引用。
            return JsonConvert.DeserializeObject<TResult>(resultJsonStr);
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="query">查询字符串</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(string url, IDictionary<string, string>? query = null, IDictionary<string, string>? headers = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            url = FormatQuery(url, query);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);

            var resultJsonStr = await response.Content.ReadAsStringAsync();

#pragma warning disable CS8603 // 可能返回 null 引用。
            return JsonConvert.DeserializeObject<TResult>(resultJsonStr);
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        private string FormatQuery(string url, IDictionary<string, string>? query)
        {
            if (query != null)
            {
                var builder = new StringBuilder(url);
                builder.Append("?");

                foreach (var q in query)
                {
                    builder.Append($"{q.Key}={q.Value.UrlEncode()}&");
                }

                url = builder.ToString().TrimEnd('&');
            }

            return url;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <returns></returns>
        public async Task<byte[]> GetByteAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <returns></returns>
        public Task<string> GetStringAsync(string url)
        {
            return GetStringAsync(url, null, null);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <param name="query">查询字符串</param>
        /// <returns></returns>
        public Task<string> GetStringAsync(string url, IDictionary<string, string> query)
        {
            return GetStringAsync(url, query, null);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <param name="query">查询字符串</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public async Task<string> GetStringAsync(string url, IDictionary<string, string>? query, IDictionary<string, string>? headers)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            url = FormatQuery(url, query);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        #endregion

        #region Post请求

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="data">Body数据</param>
        /// <returns></returns>
        public Task<TResult> PostAsync<TResult>(string url, object? data = null)
        {
            return PostAsync<TResult>(url, data, string.Empty);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="data">Body数据</param>
        /// <param name="jwtToken">Token</param>
        /// <returns></returns>
        public async Task<TResult> PostAsync<TResult>(string url, object? data, string jwtToken)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (data != null)
            {
                var jsonStr = JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonStr);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;
            }

            if (!string.IsNullOrEmpty(jwtToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            var response = await _httpClient.SendAsync(request);
            var resultJsonStr = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // 可能返回 null 引用。
            return JsonConvert.DeserializeObject<TResult>(resultJsonStr);
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="data">Body数据</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public async Task<TResult> PostAsync<TResult>(string url, object data, IDictionary<string, string>? headers = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (data != null)
            {
                var jsonStr = JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonStr);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);
            var resultJsonStr = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // 可能返回 null 引用。
            return JsonConvert.DeserializeObject<TResult>(resultJsonStr);
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <param name="data">Body数据</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public async Task<string> PostAsync(string url, object data, IDictionary<string, string>? headers = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (data != null)
            {
                var jsonStr = JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonStr);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);
            var resultJsonStr = await response.Content.ReadAsStringAsync();
            return resultJsonStr;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="TResult">结果对象</typeparam>
        /// <param name="url">请求路径</param>
        /// <param name="data">Body数据</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public async Task<TResult> PostAsync<TResult>(string url, Dictionary<string, string> data, IDictionary<string, string>? headers = null) where TResult : class, new()
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

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);

            var resultJsonStr = await response.Content.ReadAsStringAsync();

#pragma warning disable CS8603 // 可能返回 null 引用。
            return JsonConvert.DeserializeObject<TResult>(resultJsonStr);
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求路径</param>
        /// <param name="data">Body数据</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public async Task<string> PostAsync(string url, Dictionary<string, string> data, IDictionary<string, string>? headers = null)
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

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);

            var resultJsonStr = await response.Content.ReadAsStringAsync();

            return resultJsonStr;
        }

        #endregion 
    }
}
