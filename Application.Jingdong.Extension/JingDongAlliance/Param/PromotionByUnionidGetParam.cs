using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 工具商获取推广链接接口业务参数
    /// </summary>
    public class PromotionByUnionidGetParam : ValidateParam
    {
        /// <summary>
        /// 推广物料url，例如活动链接、商品链接等
        /// 不支持仅传入skuid
        /// </summary>
        [JsonProperty("materialId")]
        public string MaterialId { get; set; }

        /// <summary>
        /// 目标推客的联盟ID
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 新增推广位id （不填的话，为其默认生成一个唯一此接口推广位-名称：微信手Q短链接）
        /// </summary>
        [JsonProperty("positionId")]
        public int? PositionId { get; set; }

        /// <summary>
        /// 联盟子推客身份标识（不能传入接口调用者自己的pid）
        /// </summary>
        [JsonProperty("pid")]
        public string PId { get; set; }

        /// <summary>
        /// 优惠券领取链接，在使用优惠券、商品二合一功能时入参，且materialId须为商品详情页链接
        /// </summary>
        [JsonProperty("couponUrl")]
        public string CouponUrl { get; set; }

        /// <summary>
        /// 子渠道标识，仅支持传入字母、数字、下划线或中划线，最多80个字符（不可包含空格）
        /// 该参数会在订单行查询接口中展示（需申请权限，申请方法请见https://union.jd.com/helpcenter/13246-13247-46301）
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// 转链类型
        /// 1：长链
        /// 2 ：短链 
        /// 3： 长链+短链
        /// 默认短链，短链有效期60天
        /// </summary>
        [JsonProperty("chainType")]
        public int? ChainType { get; set; }

        /// <summary>
        /// 礼金批次号
        /// </summary>
        [JsonProperty("giftCouponKey")]
        public string GiftCouponKey { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(MaterialId))
            {
                throw new ArgumentNullException(nameof(MaterialId));
            }
            if (UnionId <= 0)
            {
                throw new ArgumentNullException(nameof(UnionId));
            }
        }
    }
}
