using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 网站/APP获取推广链接返回结果
    /// </summary>
    public class JDUnionOpenPromotionCommonGetResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_promotion_common_get_responce")]
        public PromotionCommonGetResponseDto Response { get; set; } = new PromotionCommonGetResponseDto();
    }

    public class PromotionCommonGetResponseDto
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
    public class JDUnionOpenPromotionCommonGetGetResultResponseDto
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
        public PromotionCommonGetGetResultDataResponseDto Data { get; set; } = new PromotionCommonGetGetResultDataResponseDto();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class PromotionCommonGetGetResultDataResponseDto
    {
        /// <summary>
        /// 生成的目标推广链接，长期有效
        /// </summary>
        [JsonProperty("clickURL")]
        public string ClickURL { get; set; }

        /// <summary>
        /// 京口令（匹配到红包活动有效配置才会返回京口令）
        /// </summary>
        [JsonProperty("jCommand")]
        public string JCommand { get; set; }
    }
}
