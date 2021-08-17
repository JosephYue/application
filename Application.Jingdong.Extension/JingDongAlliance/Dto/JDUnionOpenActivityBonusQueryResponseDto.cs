using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 奖励活动信息查询接口返回结果
    /// </summary>
    public class JDUnionOpenActivityBonusQueryResponseDto
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
        public JDUnionOpenActivityBonusQueryDataResponseDto Data { get; set; } = new JDUnionOpenActivityBonusQueryDataResponseDto();

        /// <summary>
        /// 是否还有更多
        /// true：还有数据
        /// false:已查询完毕，没有数据
        /// </summary>
        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenActivityBonusQueryDataResponseDto
    {
        /// <summary>
        /// 活动id
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [JsonProperty("activityName")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 预热时间，时间戳（ms）
        /// </summary>
        [JsonProperty("prepareTime")]
        public string PrepareTime { get; set; }

        /// <summary>
        /// 开始时间，时间戳（ms）
        /// </summary>
        [JsonProperty("beginDate")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 结束时间，时间戳（ms）
        /// </summary>
        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// 结算类型：
        /// 1 一次结算
        /// 2 二次结算
        /// </summary>
        [JsonProperty("payType")]
        public int PayType { get; set; }

        /// <summary>
        /// 一次结算时间，时间戳（ms）
        /// </summary>
        [JsonProperty("firstPayTime")]
        public string FirstPayTime { get; set; }

        /// <summary>
        /// 一次结算比例
        /// </summary>
        [JsonProperty("firstPayRate")]
        public float FirstPayRate { get; set; }

        /// <summary>
        /// 二次结算时间，时间戳（ms）
        /// </summary>
        [JsonProperty("secondPayTime")]
        public string SecondPayTime { get; set; }

        /// <summary>
        /// 二次计算比例
        /// </summary>
        [JsonProperty("secondPayRate")]
        public float SecondPayRate { get; set; }

        /// <summary>
        /// 活动规则
        /// </summary>
        [JsonProperty("pcDescUrl")]
        public string PcDescUrl { get; set; }

        /// <summary>
        /// 活动概述
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

    }
}
