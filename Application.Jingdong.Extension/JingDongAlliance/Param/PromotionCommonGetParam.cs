using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 网站/APP获取推广链接业务参数
    /// </summary>
    public class PromotionCommonGetParam : ValidateParam
    {
        /// <summary>
        /// 推广物料url，例如活动链接、商品链接等
        /// 不支持仅传入skuid
        /// </summary>
        [JsonProperty("materialId")]
        public string MaterialId { get; set; }

        /// <summary>
        /// 网站ID/APP ID
        /// 入口：京东联盟-推广管理-网站管理/APP管理-查看网站ID/APP 
        /// ID 1、接口禁止使用导购媒体id入参
        /// 2、投放链接的网址或应用必须与传入的网站ID/AppID备案一致，否则订单会判“无效-来源与备案网址不符”
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// 推广位id
        /// </summary>
        [JsonProperty("positionId")]
        public int? PositionId { get; set; }

        /// <summary>
        /// 子渠道标识，仅支持传入字母、数字、下划线或中划线，最多80个字符（不可包含空格）
        /// 该参数会在订单行查询接口中展示（需申请权限，申请方法请见https://union.jd.com/helpcenter/13246-13247-46301）
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// 系统扩展参数（需申请权限，申请方法请见https://union.jd.com/helpcenter/13246-13247-46301）
        /// 最多支持40字符，参数会在订单行查询接口中展示
        /// </summary>
        [JsonProperty("ext1")]
        public string Ext1 { get; set; }

        /// <summary>
        /// 联盟子推客身份标识（不能传入接口调用者自己的pid）
        /// </summary>
        [JsonProperty("pid")]
        public string PId { get; set; }

        /// <summary>
        /// 【已废弃】请勿再使用
        /// </summary>
        [JsonProperty("protocol")]
        public int? Protocol { get; set; }

        /// <summary>
        /// 优惠券领取链接，在使用优惠券、商品二合一功能时入参，且materialId须为商品详情页链接
        /// </summary>
        [JsonProperty("couponUrl")]
        public string CouponUrl { get; set; }

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
            if (string.IsNullOrWhiteSpace(SiteId))
            {
                throw new ArgumentNullException(nameof(SiteId));
            }
        }
    }
}
