using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class KeplerResponse
    {
        /// <summary>
        /// 错误的响应信息
        /// </summary>
        [JsonProperty("error_response")]
        public ErrorResponseResultDto ErrorResponse { get; set; }
    }
}
