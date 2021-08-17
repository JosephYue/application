using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 礼金效果数据返回结果
    /// </summary>
    public class JDUnionOpenStatisticsGiftCouponQueryResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_statistics_giftcoupon_query_responce")]
        public StatisticsGiftCouponQueryResponseDto Response { get; set; } = new StatisticsGiftCouponQueryResponseDto();

    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class StatisticsGiftCouponQueryResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("queryResult")]
        public string QueryResult { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class StatisticsGiftCouponQueryQueryResultResponseDto
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
        /// 数据明细Data
        /// </summary>
        [JsonProperty("data")]
        public JDUnionOpenStatisticsGiftCouponQueryDataResponseDto Date { get; set; } = new JDUnionOpenStatisticsGiftCouponQueryDataResponseDto();
    }

    /// <summary>
    /// 数据明细Data
    /// </summary>
    public class JDUnionOpenStatisticsGiftCouponQueryDataResponseDto
    {
        /// <summary>
        /// 礼金批次ID
        /// </summary>
        [JsonProperty("giftCouponKey")]
        public string GiftCouponKey { get; set; }

        /// <summary>
        /// 礼金总张数
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 已发放数量
        /// </summary>
        [JsonProperty("receiveNum")]
        public int ReceiveNum { get; set; }

        /// <summary>
        /// 已使用数量
        /// </summary>
        [JsonProperty("costNum")]
        public int CostNum { get; set; }

        /// <summary>
        /// 预估佣金
        /// </summary>
        [JsonProperty("ygCommission")]
        public int YgCommission { get; set; }

        /// <summary>
        /// 礼金状态（1：正常，2：停止）
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 领取开始日期（yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [JsonProperty("receiveStartTime")]
        public string ReceiveStartTime { get; set; }

        /// <summary>
        /// 领取结束日期（yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [JsonProperty("receiveEndTime")]
        public string ReceiveEndTime { get; set; }

        /// <summary>
        /// 消费者领取后的有效期天数
        /// </summary>
        [JsonProperty("effectiveDays")]
        public int EffectiveDays { get; set; }

        /// <summary>
        /// 礼金实际消耗金额,订单中使用的礼金券面额总和
        /// </summary>
        [JsonProperty("costAmount")]
        public int CostAmount { get; set; }

        /// <summary>
        /// 礼金类型 
        /// 1.联盟礼金
        /// 2.推客礼金
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// skuIdList
        /// </summary>
        [JsonProperty("skuIdList")]
        public long[] SkuIdList { get; set; }

        /// <summary>
        /// 是否限制每个推广链接仅可领取1张礼金：-1不限，1限制
        /// </summary>
        [JsonProperty("share")]
        public int Share { get; set; }

        /// <summary>
        /// 是否允许通过内容平台推广
        /// 0：不允许
        /// 1：允许
        /// 默认为0
        /// </summary>
        [JsonProperty("contentMatch")]
        public int ContentMatch { get; set; }

        /// <summary>
        /// 时间类型：
        /// 1.相对时间
        /// 2.绝对时间
        /// </summary>
        [JsonProperty("expireType")]
        public int ExpireType { get; set; }

        /// <summary>
        /// 使用开始时间(yyyy-MM-dd HH:mi:ss)
        /// </summary>
        [JsonProperty("useStartTime")]
        public string UseStartTime { get; set; }

        /// <summary>
        /// 使用结束时间(yyyy-MM-dd HH:mi:ss)
        /// </summary>
        [JsonProperty("useEndTime")]
        public string UseEndTime { get; set; }

        /// <summary>
        /// 礼金面额
        /// </summary>
        [JsonProperty("denomination")]
        public int Denomination { get; set; }

        /// <summary>
        /// 礼金名称
        /// </summary>
        [JsonProperty("couponTitle")]
        public string CouponTitle { get; set; }

        /// <summary>
        /// 礼金状态
        /// 1：已停止
        /// 2：未开始
        /// 3：发放中
        /// 4：已结束
        /// 5：当天已结束
        /// 6：已抢光
        /// 7：当前时段已抢光
        /// 8：到达发放限额
        /// </summary>
        [JsonProperty("showStatus")]
        public int ShowStatus { get; set; }

        /// <summary>
        /// 限制平台 
        /// 0-京东主站
        /// 1-京东客户端
        /// 3-M版京东
        /// 4-手机QQ
        /// 5-微信
        /// 7-京致衣橱App
        /// </summary>
        [JsonProperty("limitPlatforms")]
        public int[] LimitPlatforms { get; set; }

        /// <summary>
        /// contentMatch = 1 时此字段方生效
        /// 允许推广的媒体类型 -1：全部
        /// 其他枚举值：17: 抖音
        /// 18: 快手
        /// 21: 微博
        /// 22: 知乎
        /// 35: 斗鱼 
        /// 38 : 手机QQ/全民K歌
        /// 43: 百家号图文
        /// 49: 微信小商店/腾讯微视
        /// -1与其他枚举值互斥
        /// </summary>
        [JsonProperty("contentMatchMedias")]
        public int[] ContentMatchMedias { get; set; }
    }


}
