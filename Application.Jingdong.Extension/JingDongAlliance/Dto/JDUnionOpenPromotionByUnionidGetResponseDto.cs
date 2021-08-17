using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 工具商获取推广链接接口返回结果
    /// </summary>
    public class JDUnionOpenPromotionByUnionidGetResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_promotion_byunionid_get_responce")]
        public PromotionByUnionidGetResponseDto Response { get; set; } = new PromotionByUnionidGetResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PromotionByUnionidGetResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("getResult")]
        public string GetResult { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class JDUnionOpenPromotionByUnionidGetGetResultResponseDto
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
        public PromotionBySubUnionidGetGetResultDataResponseDto Data { get; set; } = new PromotionBySubUnionidGetGetResultDataResponseDto();
    }
}
