using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class PidUrlConvertResultDto : KeplerResponse
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_kpl_open_promotion_pidurlconvert_responce")]
        public JdKplOpenPromotionPidUrlConvertResponseDto Response { get; set; }
    }

    public class JdKplOpenPromotionPidUrlConvertResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 转换结果信息
        /// </summary>
        [JsonProperty("pidurlconvertResult")]
        public PidUrlConvertResponseDto PidurlconvertResult { get; set; }
    }

    public class PidUrlConvertResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("convertCode")]
        public int ConvertCode { get; set; }

        /// <summary>
        /// 请求链接
        /// </summary>
        [JsonProperty("clickUrl")]
        public ClickUrlResponseDto ClickUrl { get; set; }

        /// <summary>
        /// 转换结果说明
        /// </summary>
        [JsonProperty("convertMsg")]
        public string ConvertMsg { get; set; }
    }
}
