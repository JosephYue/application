using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class CpslinkResultDto
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_kpl_open_batch_convert_cpslink_responce")]
        public JdKplOpenBatchConvertCpslinkResponseDto Response { get; set; }

        /// <summary>
        /// 错误的响应信息
        /// </summary>
        [JsonProperty("error_response")]
        public ErrorResponseResultDto ErrorResponse { get; set; }
    }

    public class JdKplOpenBatchConvertCpslinkResponseDto
    {
        /// <summary>
        /// cps链接信息
        /// </summary>
        [JsonProperty("cpslinkResult")]
        public CpslinkResponseDto CpslinkResult { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class CpslinkResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 状态码描述信息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
