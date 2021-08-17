using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    public class GoodsActivityRecommendParam: ValidateParam
    {
        /// <summary>
        /// userIdType对应的用户设备ID，userIdType和userId需同时传入
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// 用户ID类型，传入此参数可获得个性化推荐结果。
        /// 当前userIdType支持的枚举值包括：8、16、32、64、128、32768。userIdType和userId需同时传入，且一一对应。
        /// userIdType各枚举值对应的userId含义如下：
        /// 8(安卓移动设备Imei);
        /// 16(苹果移动设备Openudid)
        /// 32(苹果移动设备idfa)
        /// 64(安卓移动设备imei的md5编码，32位，大写，匹配率略低)
        /// 128(苹果移动设备idfa的md5编码，32位，大写，匹配率略低)
        /// 32768(安卓移动设备oaid);
        /// 131072(安卓移动设备oaid的md5编码，32位，大写)
        /// </summary>
        [JsonProperty("userIdType")]
        public int UserIdType { get; set; }

        /// <summary>
        /// 用户京东订单号
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// 联盟id_应用id_推广位id，三段式
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 子联盟ID（需申请，申请方法请见https://union.jd.com/helpcenter/13246-13247-46301），该字段为自定义参数，建议传入字母数字和下划线的格式
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// 站点ID是指在联盟后台的推广管理中的网站Id
        /// APPID（1、通用转链接口禁止使用社交媒体id入参
        /// 2、订单来源，即投放链接的网址或应用必须与传入的网站ID/AppID备案一致，否则订单会判“无效-来源与备案网址不符”）
        /// </summary>
        [JsonProperty("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// 推广位id
        /// </summary>
        [JsonProperty("positionId")]
        public int PositionId { get; set; }

        /// <summary>
        /// 是否转链,1:转链;0:不转链,默认转链
        /// </summary>
        [JsonProperty("needClickUrl")]
        public int NeedClickUrl { get; set; }

        internal override void Validate()
        {
           
        }
    }
    
}
