using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 猜你喜欢商品推荐参数
    /// </summary>
    public class GoodsMaterialQueryParam : ValidateParam
    {

        /// <summary>
        /// 频道ID：
        /// 1.猜你喜欢
        /// 2.实时热销
        /// 3.大额券
        /// 4.9.9包邮
        /// 5.10001选品库
        /// </summary>
        [JsonProperty("eliteId")]
        public int EliteId { get; set; }

        /// <summary>
        /// 页码，默认1
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页数量，默认20，上限50，建议20
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// 该字段无效，请勿传入
        /// </summary>
        [JsonProperty("sortName")]
        public string SortName { get; set; }

        /// <summary>
        /// 该字段无效，请勿传入
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// 联盟id_应用id_推广位id，三段式，联盟子推客身份标识（不能传入接口调用者自己的pid）
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 子渠道标识，（需申请，申请方法请见https://union.jd.com/helpcenter/13246-13247-46301）
        /// 该字段为自定义参数，仅支持传入字母、数字、下划线或中划线，最多80个字符 （不可包含空格）
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// 站点ID是指在联盟后台的推广管理中的网站Id、APPID（
        /// 1、通用转链接口禁止使用社交媒体id入参；
        /// 2、订单来源，即投放链接的网址或应用必须与传入的网站ID/AppID备案一致，否则订单会判“无效-来源与备案网址不符”）
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// 推广位id
        /// </summary>
        [JsonProperty("positionId")]
        public string PositionId { get; set; }

        /// <summary>
        /// 系统扩展参数，无需传入
        /// </summary>
        [JsonProperty("ext1")]
        public string Ext1 { get; set; }

        /// <summary>
        /// 预留字段，请勿传入
        /// </summary>
        [JsonProperty("skuId")]
        public int? SkuId { get; set; }

        /// <summary>
        /// 1：只查询有最优券商品，不传值不做限制
        /// </summary>
        [JsonProperty("hasCoupon")]
        public int? HasCoupon { get; set; }

        /// <summary>
        /// 用户ID类型，传入此参数可获得个性化推荐结果。
        /// 当前userIdType支持的枚举值包括：8、16、32、64、128、32768。
        /// userIdType和userId需同时传入，且一一对应。
        /// userIdType各枚举值对应的userId含义如下：8(安卓移动设备Imei); 16(苹果移动设备Openudid)；32(苹果移动设备idfa); 64(安卓移动设备imei的md5编码，32位，大写，匹配率略低)
        /// 128(苹果移动设备idfa的md5编码，32位，大写，匹配率略低)
        /// 32768(安卓移动设备oaid);
        /// 131072(安卓移动设备oaid的md5编码，32位，大写)
        /// </summary>
        [JsonProperty("userIdType")]
        public int? UserIdType { get; set; }

        /// <summary>
        /// userIdType对应的用户设备ID
        /// 传入此参数可获得个性化推荐结果
        /// userIdType和userId需同时传入
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// 支持出参数据筛选，逗号','分隔
        /// 目前可用：videoInfo(视频信息)
        /// hotWords(热词)
        /// similar(相似推荐商品)
        /// documentInfo(段子信息)
        /// skuLabelInfo（商品标签）
        /// promotionLabelInfo（商品促销标签）
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }

        /// <summary>
        /// 10微信京东购物小程序禁售，11微信京喜小程序禁售
        /// </summary>
        [JsonProperty("forbidTypes")]
        public string ForbidTypes { get; set; }

        /// <summary>
        /// 用户京东联盟订单号（先取订单号，如果订单号未命中、设备号命中，则以设备号为准）
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// 选品库id（仅对eliteId=10001有效，且必传）
        /// </summary>
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }

        /// <summary>
        /// groupId创建者的UnionId
        /// </summary>
        [JsonProperty("ownerUnionId")]
        public int? OwnerUnionId { get; set; }

        /// <summary>
        /// 类型 0:选品库
        /// </summary>
        [JsonProperty("benefitType")]
        public int? BenefitType { get; set; }

        internal override void Validate()
        {
            if (EliteId <= 0)
            {
                throw new ArgumentNullException(nameof(EliteId));
            }
        }
    }
}
