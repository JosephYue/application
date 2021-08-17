using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class ErrorResponseResultDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 中文描述
        /// </summary>
        [JsonProperty("zh_desc")]
        public string ZhDesc { get; set; }

        /// <summary>
        /// 英文描述
        /// </summary>
        [JsonProperty("en_desc")]
        public string EnDesc { get; set; }
    }
}
