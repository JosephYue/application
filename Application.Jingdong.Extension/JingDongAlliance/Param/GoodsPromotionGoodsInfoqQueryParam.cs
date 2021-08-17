using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    public class GoodsPromotionGoodsInfoqQueryParam : ValidateParam
    {
        /// <summary>
        /// 京东skuID串，逗号分割，最多100个，开发示例如param_json={'skuIds':'5225346,7275691'}
        /// （非常重要 请大家关注：如果输入的sk串中某个skuID的商品不在推广中[就是没有佣金]，返回结果中不会包含这个商品的信息）
        /// </summary>
        [JsonProperty("skuIds")]
        public string SkuIds { get; set; }
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(SkuIds))
            {
                throw new ArgumentNullException(nameof(SkuIds));
            }
        }
    }
}
