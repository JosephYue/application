using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    public class GoodsCouponQueryParam : ValidateParam
    {
        /// <summary>
        /// 优惠券链接集合；上限10（GET请求）；上限50（POST请求或SDK调用）
        /// </summary>
        [JsonProperty("couponUrls")]
        public List<string>  CouponUrls { get; set; }


        /// <summary>
        /// 优惠券非空验证
        /// </summary>
        internal override void Validate()
        {
            if (CouponUrls.Count == 0)
            {
                throw new ArgumentNullException(nameof(CouponUrls));
            }
        }
    }
}
