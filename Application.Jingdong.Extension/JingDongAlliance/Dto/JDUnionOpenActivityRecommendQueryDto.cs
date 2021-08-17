using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 活动推荐接口【申请】Dto
    /// </summary>
    public class JDUnionOpenActivityRecommendQueryDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_activity_recommend_query_responce")]
        public ResponseBaseDto Response { get; set; }
    }

    public class JDUnionOpenActivityRecommendDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 数据明细
        /// </summary>
        [JsonProperty("data")]
        public List<RecommendActivityResp> Data { get; set; }
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class RecommendActivityResp
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        [JsonProperty("activityId")]
        public string ActivityId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [JsonProperty("activityName")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 活动落地页-移动端（转链长链接，无需调用转链接口）
        /// </summary>
        [JsonProperty("clickUrlM")]
        public string ClickUrlM { get; set; }

        /// <summary>
        /// 活动落地页-移动端（需调用转链接口）
        /// </summary>
        [JsonProperty("urlM")]
        public string UrlM { get; set; }
    }
}
