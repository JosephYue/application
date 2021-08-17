using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongKepler.Param
{
    public class CpsLinkParam : ValidateParam
    {
        /// <summary>
        ///批量传入url链接，以逗号进行分隔（支持京东及1号店的首页、商品详情页、频道页、活动页、店铺页）
        /// </summary>
        [JsonProperty("urls")]
        public string Urls { get; set; }

        /// <summary>
        /// 是否唤起APP 1 是 0否
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = "0";

        /// <summary>
        /// 在开普勒平台创建应用生成的appkey值
        /// </summary>
        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 自定义信息，支持数字，字母，下划线，不支持中文及其他符号
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        ///jdShortUrl: 京东短域名标识:默认0 ,返回非京东短域名； 1: 返回推广链接是京东短域名(3.cn)，适合社群传播
        /// </summary>
        [JsonProperty("jdShortUrl")]
        public string JdShortUrl { get; set; } = "0";

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Urls))
            {
                throw new ArgumentNullException(nameof(Urls));
            }

            if (string.IsNullOrWhiteSpace(AppKey))
            {
                throw new ArgumentNullException(nameof(AppKey));
            }
        }
    }
}
