using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 奖励活动奖励金额查询返回结果
    /// </summary>
    public class JDUnionOpenStatisticsActivityBonusQueryResponseDto
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
        public JDUnionOpenAtatisticsActivityBonusQueryDataResponseDto Data { get; set; } = new JDUnionOpenAtatisticsActivityBonusQueryDataResponseDto();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenAtatisticsActivityBonusQueryDataResponseDto
    {
        /// <summary>
        /// 站长ID
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// 预估有效订单数
        /// </summary>
        [JsonProperty("estimateValidNum")]
        public int EstimateValidNum { get; set; }

        /// <summary>
        /// 预估计佣金额(GMV)
        /// </summary>
        [JsonProperty("estimateCosPrice")]
        public decimal EstimateCosPrice { get; set; }

        /// <summary>
        /// 预估奖励金额
        /// </summary>
        [JsonProperty("estimateBonus")]
        public int EstimateBonus { get; set; }

        /// <summary>
        /// 实际有效订单数
        /// </summary>
        [JsonProperty("actualValidNum")]
        public int ActualValidNum { get; set; }

        /// <summary>
        /// 实际计佣金额(GMV)
        /// </summary>
        [JsonProperty("actualCosPrice")]
        public decimal ActualCosPrice { get; set; }

        /// <summary>
        /// 实际奖励金额
        /// </summary>
        [JsonProperty("actualBonus")]
        public decimal ActualBonus { get; set; }
    }
}
