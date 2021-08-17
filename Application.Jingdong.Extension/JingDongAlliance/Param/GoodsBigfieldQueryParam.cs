using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    public class GoodsBigfieldQueryParam : ValidateParam
    {
        /// <summary>
        /// skuId集合，最多支持批量入参10个sku
        /// </summary>
        [JsonProperty("skuIds")]
        public List<long> SkuIds { get; set; }

        /// <summary>
        /// 查询域集合，不填写则查询全部，
        /// 目目前支持：categoryInfo（类目信息）
        /// imageInfo（图片信息）
        /// baseBigFieldInfo（基础大字段信息）
        /// bookBigFieldInfo（图书大字段信息）
        /// videoBigFieldInfo（影音大字段信息）
        /// detailImages（商详图）
        /// </summary>
        [JsonProperty("fields")]
        public List<string> Fields { get; set; }

        internal override void Validate()
        {
            if (SkuIds.Count==0)
            {
                throw new ArgumentNullException(nameof(SkuIds));
            }
        }
    }
}
