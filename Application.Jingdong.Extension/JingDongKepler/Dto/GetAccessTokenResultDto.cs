using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class GetAccessTokenResultDto 
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; } = 200;

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; } = "";

        /// <summary>
        /// 响应Id
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; } = "";

        /// <summary>
        ///接口调用令牌
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 令牌有效时间, 单位秒
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 授权用户唯一标识
        /// </summary>
        [JsonProperty("open_id")]
        public string OpenId { get; set; }
    }
}
