using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 奖励订单查询接口(申请)返回结果
    /// </summary>
    public class JDUnionOpenOrderBonusQueryResponseDto
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_union_open_order_bonus_query_responce")]
        public OrderBonusQueryResponseDto Response = new OrderBonusQueryResponseDto();
    }

    public class OrderBonusQueryResponseDto
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

    public class OrderBonusQueryQueryResultResponseDto
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
        public List<JDUnionOpenOrderBonusQueryDataResponseDto> Data { get; set; } = new List<JDUnionOpenOrderBonusQueryDataResponseDto>();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenOrderBonusQueryDataResponseDto
    {
        /// <summary>
        /// 联盟ID
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 无效状态码
        /// -1:无效
        /// 2:无效-拆单
        /// 3:无效-取消
        /// 4:无效-京东帮帮主订单
        /// 5:无效-账号异常
        /// 6:无效-赠品类目不返佣 等
        /// </summary>
        [JsonProperty("bonusInvalidCode")]
        public string BonusInvalidCode { get; set; }

        /// <summary>
        /// 无效状态码对应的无效状态文案
        /// </summary>
        [JsonProperty("bonusInvalidText")]
        public string BonusInvalidText { get; set; }

        /// <summary>
        /// 实际支付金额
        /// </summary>
        [JsonProperty("payPrice")]
        public double PayPrice { get; set; }

        /// <summary>
        /// 预估计佣金额
        /// </summary>
        [JsonProperty("estimateCosPrice")]
        public double EstimateCosPrice { get; set; }

        /// <summary>
        /// 预估佣金
        /// </summary>
        [JsonProperty("estimateFee")]
        public double EstimateFee { get; set; }

        /// <summary>
        /// 实际计佣金额
        /// </summary>
        [JsonProperty("actualCosPrice")]
        public double ActualCosPrice { get; set; }

        /// <summary>
        /// 实际佣金
        /// </summary>
        [JsonProperty("actualFee")]
        public double ActualFee { get; set; }

        /// <summary>
        /// 下单时间、时间戳（毫秒）
        /// </summary>
        [JsonProperty("orderTime")]
        public long OrderTime { get; set; }

        /// <summary>
        /// 完成时间、时间戳（毫秒）
        /// </summary>
        [JsonProperty("finishTime")]
        public long FinishTime { get; set; }

        /// <summary>
        /// 推广位ID
        /// </summary>
        [JsonProperty("positionId")]
        public long PositionId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// 奖励状态
        /// 0:无效
        /// 1:有效
        /// </summary>
        [JsonProperty("bonusState")]
        public int BonusState { get; set; }

        /// <summary>
        /// 奖励状态文案
        /// </summary>
        [JsonProperty("bonusText")]
        public string BonusText { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("skuName")]
        public string SkuName { get; set; }

        /// <summary>
        /// 佣金比例，单位：%
        /// </summary>
        [JsonProperty("commissionRate")]
        public float CommissionRate { get; set; }

        /// <summary>
        /// 子联盟ID
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// pid
        /// </summary>
        [JsonProperty("pid")]
        public string PId { get; set; }

        /// <summary>
        /// 推客生成推广链接时传入的扩展字段
        /// </summary>
        [JsonProperty("ext1")]
        public string Ext1 { get; set; }

        /// <summary>
        /// 母站长简称
        /// </summary>
        [JsonProperty("unionAlias")]
        public string UnionAlias { get; set; }

        /// <summary>
        /// 分成比例（单位：%）
        /// </summary>
        [JsonProperty("subSideRate")]
        public double SubSideRate { get; set; }

        /// <summary>
        /// 补贴比例（单位：%）
        /// </summary>
        [JsonProperty("subsidyRate")]
        public double SubsidyRate { get; set; }

        /// <summary>
        /// 最终分佣比例=分成比例+补贴比例 （单位：%）
        /// </summary>
        [JsonProperty("finalRate")]
        public double FinalRate { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [JsonProperty("activityName")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 父单的订单号：如一个订单拆成多个子订单时，原订单号会作为父单号，拆分的订单号为子单号存储在orderid中。若未发生拆单，该字段为0
        /// </summary>
        [JsonProperty("parentId")]
        public long ParentId { get; set; }

        /// <summary>
        /// skuId
        /// </summary>
        [JsonProperty("skuId")]
        public long SkuId { get; set; }

        /// <summary>
        /// 预估奖励金额：查询时间范围内，已付款且奖励有效，满足奖励规则的奖励金额
        /// </summary>
        [JsonProperty("estimateBonusFee")]
        public int EstimateBonusFee { get; set; }

        /// <summary>
        /// 实际奖励金额：查询时间范围内，已付款或已完成（视具体规则），奖励有效且满足奖励规则的奖励金额
        /// </summary>
        [JsonProperty("actualBonusFee")]
        public int ActualBonusFee { get; set; }

        /// <summary>
        /// 奖励订单状态
        /// 1:已完成
        /// 2:已付款
        /// 3:待付款
        /// </summary>
        [JsonProperty("orderState")]
        public int OrderState { get; set; }

        /// <summary>
        /// 奖励订单状态，待付款/已付款/已完成
        /// </summary>
        [JsonProperty("orderText")]
        public string OrderText { get; set; }

        /// <summary>
        /// 排序值，按'下单时间'分页查询时使用
        /// </summary>
        [JsonProperty("sortValue")]
        public string SortValue { get; set; }

        /// <summary>
        /// 奖励活动ID
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }
    }
}
