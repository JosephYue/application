using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 礼金创建返回结果
    /// </summary>
    public class JDUnionOpenCouponGiftGetResponseDto
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_union_open_coupon_gift_get_responce")]
        public CouponGiftGetResponseDto Response { get; set; } = new CouponGiftGetResponseDto();
    }

    public class CouponGiftGetResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("getResult")]
        public string GetResult { get; set; }
    }

    /// <summary>
    /// 响应信息
    /// </summary>
    public class CouponGiftGetGetResultResponseDto
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
        public CouponGiftGetGetResultDataResponseDto Data { get; set; } = new CouponGiftGetGetResultDataResponseDto();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class CouponGiftGetGetResultDataResponseDto
    {
        /// <summary>
        /// 礼金批次ID，调用转链接口获取推广链接时，传入此参数可获得礼金推广链接
        /// </summary>
        [JsonProperty("giftCouponKey")]
        public string GiftCouponKey { get;set; }
    }
}
