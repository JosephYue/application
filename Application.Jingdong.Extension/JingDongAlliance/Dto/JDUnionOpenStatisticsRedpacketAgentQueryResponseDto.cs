using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 工具商京享红包效果数据返回结果
    /// </summary>
    public class JDUnionOpenStatisticsRedpacketAgentQueryResponseDto
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_union_open_statistics_redpacket_agent_query_responce")]
        public StatisticsRedpacketAgentQueryResponseDto Response { get; set; } = new StatisticsRedpacketAgentQueryResponseDto();
    }

    /// <summary>
    /// 响应信息
    /// </summary>
    public class StatisticsRedpacketAgentQueryResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 查询结果
        /// </summary>
        [JsonProperty("queryResult")]
        public string QueryResult { get; set; }
    }

    /// <summary>
    /// 查询结果
    /// </summary>
    public class StatisticsRedpacketAgentQueryResultResponseDto
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
        public List<JDUnionOpenStatisticsRedpacketAgentDataResponseDto> Data { get; set; } = new List<JDUnionOpenStatisticsRedpacketAgentDataResponseDto>();

        /// <summary>
        /// 是否还有更多
        /// true：还有数据
        /// false:已查询完毕，没有数据
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenStatisticsRedpacketAgentDataResponseDto
    {
        /// <summary>
        /// 数据日期
        /// </summary>
        [JsonProperty("tjDate")]
        public string TjDate { get; set; }

        /// <summary>
        /// 京享红包活动ID
        /// </summary>
        [JsonProperty("actId")]
        public long ActId { get; set; }

        /// <summary>
        /// 京东联盟id
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 推广位
        /// </summary>
        [JsonProperty("positionId")]
        public long PositionId { get; set; }

        /// <summary>
        /// 推广位名称
        /// </summary>
        [JsonProperty("promotionName")]
        public string PromotionName { get; set; }

        /// <summary>
        /// 京享红包活动页浏览次数
        /// </summary>
        [JsonProperty("showNum")]
        public int ShowNum { get; set; }

        /// <summary>
        /// 京享红包发放数量
        /// </summary>
        [JsonProperty("giveNum")]
        public int GiveNum { get; set; }

        /// <summary>
        /// 京享红包使用数量
        /// </summary>
        [JsonProperty("useNum")]
        public int UseNum { get; set; }

        /// <summary>
        /// 京享红包有效订单数量
        /// </summary>
        [JsonProperty("orderNum")]
        public int OrderNum { get; set; }

        /// <summary>
        /// 京享红包订单有效GMV
        /// </summary>
        [JsonProperty("orderPrice")]
        public decimal OrderPrice { get; set; }

        /// <summary>
        /// 京享红包订单有效预估佣金
        /// </summary>
        [JsonProperty("orderFee")]
        public decimal OrderFee { get; set; }
    }
}
