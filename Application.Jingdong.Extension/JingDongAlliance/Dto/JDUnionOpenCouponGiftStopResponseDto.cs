using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 礼金停止返回结果
    /// </summary>
    public class JDUnionOpenCouponGiftStopResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_coupon_gift_stop_responce")]
        public CouponGiftStopResponseDto Response { get; set; } = new CouponGiftStopResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class CouponGiftStopResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("stopResult")]
        public string StopResult { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class CouponGiftStopStopResultResponseDto
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
    }
}
