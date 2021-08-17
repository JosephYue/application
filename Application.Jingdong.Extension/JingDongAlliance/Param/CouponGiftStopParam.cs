using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 礼金停止业务参数
    /// </summary>
    public class CouponGiftStopParam : ValidateParam
    {
        /// <summary>
        /// 礼金批次ID
        /// </summary>
        [JsonProperty("giftCouponKey")]
        public string GiftCouponKey { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(GiftCouponKey))
            {
                throw new ArgumentNullException(nameof(GiftCouponKey));
            }
        }
    }
}
