using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class ConvertUrlResultDto : KeplerResponse
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_kpl_open_promotion_converturl_responce")]
        public JdKplOpenPromotionConvertUrlResponseDto Response { get; set; }
    }

    public class JdKplOpenPromotionConvertUrlResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 转换链接响应信息
        /// </summary>
        [JsonProperty("converturlResult")]
        public ConvertUrlResultResponseDto ConverturlResult { get; set; }
    }

    public class ConvertUrlResultResponseDto
    {
        /// <summary>
        /// 转换code
        /// </summary>
        [JsonProperty("convertCode")]
        public int ConvertCode { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        [JsonProperty("clickUrl")]
        public ClickUrlResponseDto ClickUrl { get; set; }

        /// <summary>
        /// 转换信息
        /// </summary>
        [JsonProperty("convertMsg")]
        public string ConvertMsg { get; set; }
    }

    public class ClickUrlResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("errCode")]
        public int ErrCode { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 短连接
        /// </summary>
        [JsonProperty("shortUrl")]
        public string ShortUrl { get; set; }

        /// <summary>
        /// 开普勒跳转链接
        /// </summary>
        [JsonProperty("clickURL")]
        public string ClickURL { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
