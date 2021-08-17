using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongKepler.Param
{
    public class ConvertUrlParam : ValidateParam
    {
        /// <summary>
        /// App平台需传值，请访问京东联盟media.jd.com，推广管理--APP管理中查找AppId。小程序或微信公众号等非APP端可传0.
        /// </summary>
        [JsonProperty("webId")]
        public string WebId { get; set; }

        /// <summary>
        /// 默认传0
        /// </summary>
        [JsonProperty("positionId")]
        public int PositionId { get; set; } = 0;

        /// <summary>
        /// 需要转换的落地页url
        /// </summary>
        [JsonProperty("materialId")]
        public string MaterialId { get; set; }

        /// <summary>
        /// pid（可不传，此字段需要向联盟申请账号权限）
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; } = "";

        /// <summary>
        /// 自定义信息，支持数字，字母，下划线，不支持中文及其他符号（需要向运营人员申请后才可使用）
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; } = "";

        /// <summary>
        /// shortUrl：1、当 shortUrl传1且kplClick传1返回联盟短链接；2、当shortUrl传0且kplClick传1返回联盟长链接；3、当shortUrl传1且kplClick不传返回开普勒短链接；4、当shortUrl传0且kplClick不传返回开普勒长链接; 5、当shortUrl传2且kplClick不传返回京东短域名链接(3.cn)，适合社群传播
        /// </summary>
        [JsonProperty("shortUrl")]
        public int ShortUrl { get; set; }

        /// <summary>
        /// 传1为联盟格式链接，默认不传为开普勒格式链接 。注：如果需要出参开普勒KM链接，kplClick默认不传且shortUrl不传，则出参clickURL输出开普勒KM链接。
        /// </summary>
        [JsonProperty("kplClick")]
        public int KplClick { get; set; }

        /// <summary>
        /// 优惠券链接
        /// </summary>
        [JsonProperty("couponUrl")]
        public string CouponUrl { get; set; }

        /// <summary>
        /// 验证参数
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(MaterialId))
            {
                throw new ArgumentNullException(nameof(MaterialId));
            }

            if (string.IsNullOrWhiteSpace(CouponUrl))
            {
                throw new ArgumentNullException(nameof(CouponUrl));
            }

            if (string.IsNullOrWhiteSpace(WebId))
            {
                throw new ArgumentNullException(nameof(WebId));
            }
        }
    }
}
