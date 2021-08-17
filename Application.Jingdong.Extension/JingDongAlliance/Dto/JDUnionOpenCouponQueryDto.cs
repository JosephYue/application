using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 优惠券领取情况查询Dto
    /// </summary>
    public class JDUnionOpenCouponQueryDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_coupon_query_responce")]
        public ResponseBaseDto Response { get; set; }
    }

    public class JDCouponQueryResponseDto
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
        public List<JdUnionOpenCouponQueryDataResponseDto> Data { get; set; }
    }

    public class JdUnionOpenCouponQueryDataResponseDto
    {
        /// <summary>
        /// 券领取结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("takeEndTime")]
        public long TakeEndTime { get; set; }

        /// <summary>
        /// 券领取开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("takeBeginTime")]
        public long TakeBeginTime { get; set; }

        /// <summary>
        /// 券剩余张数
        /// </summary>
        [JsonProperty("remainNum")]
        public long RemainNum { get; set; }

        /// <summary>
        /// 券有效状态
        /// </summary>
        [JsonProperty("yn")]
        public string Yn { get; set; }

        /// <summary>
        /// 券总张数
        /// </summary>
        [JsonProperty("num")]
        public long Num { get; set; }

        /// <summary>
        /// 券消费限额
        /// </summary>
        [JsonProperty("quota")]
        public double Quota { get; set; }

        /// <summary>
        /// 券链接
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// 券面额
        /// </summary>
        [JsonProperty("discount")]
        public double Discount { get; set; }

        /// <summary>
        /// 券有效使用开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("beginTime")]
        public long BeginTime { get; set; }

        /// <summary>
        /// 券有效使用结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("endTime")]
        public long EndTime { get; set; }

        /// <summary>
        /// 券使用平台
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }
    }
}
