using Application.Extension.Infrastructure.Common;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Application.Extension.Infrastructure.Http.RestSharp
{
    public static class RestSharpClient
    {
        #region Post

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">请求url</param>
        /// <param name="data">参数信息</param>
        /// <param name="apiHost">请求域</param>
        /// <param name="headerList">头信息</param>
        /// <param name="dataType">参数类型 默认 json</param>
        /// <returns></returns>
        public static IRestResponse Post(string url, object data, string apiHost, Dictionary<string, string>? headerList = null, string dataType = "json")
        {
            RestClient client = new RestClient(apiHost);

            if (data != null)
            {
                if (data.GetType().Name == "String")
                {
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    data = JsonConvert.DeserializeObject<dynamic>(data?.ToString() ?? string.Empty);
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
            }

            var request = new RestRequest(url, Method.POST);

            if (string.Equals(dataType, "json", StringComparison.OrdinalIgnoreCase))
            {
                request.AddHeader("Accept", "application/json");
            }
            else if (string.Equals(dataType, "xml", StringComparison.OrdinalIgnoreCase))
            {
                request.AddHeader("Accept", "application/xml");
            }

            if (headerList != null)
            {
                foreach (var header in headerList)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (string.Equals(dataType, "json", StringComparison.OrdinalIgnoreCase))
            {
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            }
            else if (string.Equals(dataType, "xml", StringComparison.OrdinalIgnoreCase))
            {
                if (data != null)
                {
                    request.AddXmlBody(data);
                }
            }

            var response = client.Execute(request);
            return response;
        }

        #endregion

        #region Get

        /// <summary>
        /// 发送get请求
        /// </summary>
        /// <param name="url">请求url</param>
        /// <param name="apiHost">请求域</param>
        /// <param name="data">携带参数</param>
        /// <param name="headerList">头信息</param>
        /// <returns></returns>
        public static IRestResponse Get(string url, string apiHost = "", Dictionary<string, string>? data = null,
            Dictionary<string, string>? headerList = null)
        {
            RestClient client;

            if (!string.IsNullOrWhiteSpace(apiHost))
            {
                client = new RestClient(apiHost);
            }
            else
            {
                client = new RestClient();
            }

            var request = new RestRequest(url, Method.GET);
            request.AddHeader("Accept", "application/json");
            if (headerList != null)
            {
                foreach (var header in headerList)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (data != null)
            {
                foreach (var item in data)
                {
                    request.AddQueryParameter(item.Key, item.Value);
                }
            }

            return client.Execute(request);
        }

        #endregion

        #region form-data请求

        /// <summary>
        /// form-data请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求参数</param>
        /// <param name="apiHost">请求域名</param>
        /// <param name="files">流参数信息</param>
        /// <param name="headerList">头信息</param>
        /// <returns></returns>
        public static IRestResponse FormData(string url, object data, string apiHost, Dictionary<string, byte[]>? files = null,
            Dictionary<string, string>? headerList = null)
        {
            RestClient client = new RestClient(apiHost);

            var request = new RestRequest(url, Method.POST)
            {
                AlwaysMultipartFormData = true
            };

            if (headerList != null)
            {
                foreach (var header in headerList)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            foreach (var item in ToMap(data))
            {
                request.AddParameter(item.Key, item.Value);
            }

            if (files != null)
            {
                foreach (var item in files)
                {
                    request.AddFile(item.Key, item.Value, item.Value.GetRandomFileName());
                }
            }

            var response = client.Execute(request);

            return response;

            Dictionary<string, string> ToMap(object o)
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                Type t = o.GetType();
                PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo p in pi)
                {
                    MethodInfo? mi = p.GetGetMethod();
                    if (mi != null && mi.IsPublic)
                    {
                        map.Add(p.Name, mi.Invoke(o, new object[] { })?.ToString() ?? string.Empty);
                    }
                }
                return map;
            }
        }

        #endregion
    }
}
