using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 礼金创建业务参数
    /// </summary>
    public class CouponGiftGetParam : ValidateParam
    {
        /// <summary>
        /// 商品skuId或落地页地址
        /// </summary>
        [JsonProperty("skuMaterialId")]
        public string SkuMaterialId { get; set; }

        /// <summary>
        /// 优惠券面额，最小不可低于1元，最大不可超过pop商品价格的80%，自营商品价格的50%。如：1或者1.00或者1.01
        /// </summary>
        [JsonProperty("discount")]
        public int Discount { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 领取开始时间(yyyy-MM-dd HH)，区间为(创建当天0点直至未来6天内)，系统补充为yyyy-MM-dd HH:00:00
        /// </summary>
        [JsonProperty("receiveStartTime")]
        public string ReceiveStartTime { get; set; }

        /// <summary>
        /// 领取结束时间(yyyy-MM-dd HH)，区间为(创建当前时间点直至未来6天内)，系统补充为yyyy-MM-dd HH:59:59
        /// </summary>
        [JsonProperty("receiveEndTime")]
        public string ReceiveEndTime { get; set; }

        /// <summary>
        /// 消费者领取后n天内可用，时间天数1至7，当expireType=1时，必须设置该字段
        /// </summary>
        [JsonProperty("effectiveDays")]
        public int EffectiveDays { get; set; }

        /// <summary>
        /// 是否绑定同spu商品(1:是;0:否)
        /// 例如skuMaterialId输入一款37码的鞋，当isSpu选择1时，此款鞋的全部尺码均可推广这张礼金
        /// 当isSpu选择0时，此款鞋仅37码可推广这张礼金，其他鞋码不支持
        /// </summary>
        [JsonProperty("isSpu")]
        public int IsSpu { get; set; }

        /// <summary>
        /// 使用时间类型：
        /// 1.相对时间，需配合effectiveDays一同传入
        /// 2.绝对时间，需配合useStartTime和useEndTime一同传入
        /// </summary>
        [JsonProperty("expireType")]
        public int ExpireType { get; set; }

        /// <summary>
        /// 消费者领取后的使用开始时间，格式：yyyy-MM-dd，系统补充为yyyy-MM-dd HH:00:00，当expireType=2时，必须设置该字段
        /// </summary>
        [JsonProperty("useStartTime")]
        public string UseStartTime { get; set; }

        /// <summary>
        /// 消费者领取后的使用结束时间，格式：yyyy-MM-dd，系统补充为yyyy-MM-dd HH:59:59，当expireType=2时，必须设置该字段
        /// </summary>
        [JsonProperty("useEndTime")]
        public string UseEndTime { get; set; }

        /// <summary>
        /// 每个礼金推广链接是否限制仅可领取1张礼金：-1不限，1限制
        /// </summary>
        [JsonProperty("share")]
        public int Share { get; set; }

        /// <summary>
        /// 是否允许通过内容平台推广，0：不允许，1：允许；默认为0
        /// </summary>
        [JsonProperty("contentMatch")]
        public int ContentMatch { get; set; }

        /// <summary>
        /// 礼金名称
        /// </summary>
        [JsonProperty("couponTitle")]
        public string CouponTitle { get; set; }

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

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {

            if (string.IsNullOrWhiteSpace(SkuMaterialId))
            {
                throw new ArgumentNullException(nameof(SkuMaterialId));
            }

            if (Discount < 1)
            {
                throw new ArgumentNullException(nameof(Discount));
            }

            if (Amount < 0)
            {
                throw new ArgumentNullException(nameof(Amount));
            }

            if (string.IsNullOrWhiteSpace(ReceiveStartTime))
            {
                throw new ArgumentNullException(nameof(ReceiveStartTime));
            }

            if (string.IsNullOrWhiteSpace(ReceiveEndTime))
            {
                throw new ArgumentNullException(nameof(ReceiveEndTime));
            }

            if (IsSpu != 0 && IsSpu != 1)
            {
                throw new ArgumentNullException(nameof(IsSpu));
            }

            if (ExpireType != 1 && ExpireType != 2)
            {
                throw new ArgumentNullException(nameof(ExpireType));
            }
            else if (ExpireType == 1)
            {
                if (EffectiveDays == 0)
                {
                    throw new ArgumentNullException(nameof(EffectiveDays));
                }
            }
            else if (ExpireType == 2)
            {
                if (string.IsNullOrWhiteSpace(UseStartTime))
                {
                    throw new ArgumentNullException(nameof(UseStartTime));
                }
                if (string.IsNullOrWhiteSpace(UseEndTime))
                {
                    throw new ArgumentNullException(nameof(UseEndTime));
                }
            }

            if (Share != -1 && Share != 1)
            {
                throw new ArgumentNullException(nameof(Share));
            }
        }
    }
}
