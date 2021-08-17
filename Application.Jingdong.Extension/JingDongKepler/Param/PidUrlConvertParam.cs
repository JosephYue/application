using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongKepler.Param
{
    public class PidUrlConvertParam : ValidateParam
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
        [JsonProperty("materalId")]
        public string MateralId { get; set; }

        /// <summary>
        ///pid（可不传，此字段需要向联盟申请账号权限）
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 自定义信息，支持数字，字母，下划线，不支持中文及其他符号（需要向运营人员申请后才可使用）
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// 传1表示返回短链接，传0表示返回长链接
        /// </summary>
        [JsonProperty("shortUrl")]
        public int ShortUrl { get; set; }

        /// <summary>
        /// 传1为联盟格式链接，默认不传为开普勒格式链接
        /// </summary>
        [JsonProperty("kplClick")]
        public int KplClick { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(MateralId))
            {
                throw new ArgumentNullException(nameof(MateralId));
            }
        }
    }
}
