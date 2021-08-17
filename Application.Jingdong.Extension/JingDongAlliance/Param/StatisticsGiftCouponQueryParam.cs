using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 礼金效果数据业务参数
    /// </summary>
    public class StatisticsGiftCouponQueryParam : ValidateParam
    {
        /// <summary>
        /// 查询该SKU您创建的推客礼金，以及该SKU您可推广的联盟礼金。 skuId和giftCouponKey二选一，不可同时入参。
        /// </summary>
        [JsonProperty("skuId")]
        public long? SkuId { get; set; }

        ///// <summary>
        ///// 根据礼金批次ID精确查询礼金信息，请勿和createTime同时传入。 skuId和giftCouponKey二选一，不可同时入参。
        ///// </summary>
        [JsonProperty("giftCouponKey")]
        public string GiftCouponKey { get; set; }

        /// <summary>
        /// 可查询此日期及以后创建的礼金，如不传则不限日期。 格式：yyyy-MM-dd
        /// </summary>
        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 可查询此日期及以后下单的礼金效果数据，如不传则不限日期。 格式：yyyy-MM-dd
        /// </summary>
        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 工具商传入推客的授权key，可帮助该推客查询礼金效果数据。（需联系运营开通工具商权限才能拿到数据）
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (SkuId != null && !string.IsNullOrWhiteSpace(GiftCouponKey))
            {
                throw new ArgumentNullException(nameof(SkuId) + "and" + nameof(GiftCouponKey) + "coexistence is not allowed");
            }
        }
    }
}
