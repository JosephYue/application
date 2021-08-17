using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    public class ResponseBaseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 查询结果
        /// </summary>
        [JsonProperty("queryResult")]
        public string QueryResult { get; set; }

        
    }
}
