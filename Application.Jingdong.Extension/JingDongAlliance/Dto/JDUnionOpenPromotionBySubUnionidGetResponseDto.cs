using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 社交媒体获取推广链接接口返回结果
    /// </summary>
    public class JDUnionOpenPromotionBySubUnionidGetResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_promotion_bysubunionid_get_responce")]
        public PromotionBySubUnionidGetResponseDto Response { get; set; } = new PromotionBySubUnionidGetResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PromotionBySubUnionidGetResponseDto
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
    public class JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto
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

    /// <summary>
    /// 数据明细
    /// </summary>
    public class PromotionBySubUnionidGetGetResultDataResponseDto
    {
        /// <summary>
        /// 生成的推广目标链接，以短链接形式，有效期60天
        /// </summary>
        [JsonProperty("shortURL")]
        public string ShortURL { get; set; }

        /// <summary>
        /// 生成推广目标的长链，长期有效
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
