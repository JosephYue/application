using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 根据skuid查询商品信息DtO
    /// </summary>
    public class JDUnionGoodsPromotionGoodsInfoqQueryDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_goods_promotiongoodsinfo_query_responce")]
        public ResponseBaseDto Response { get; set; }
    }

    public class GoodsPromotionGoodsInfoResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 数据明细
        /// </summary>
        [JsonProperty("data")]
        public List<PromotionGoodsResponseDto> Data { get; set; }
    }
    /// <summary>
    /// 数据明细
    /// </summary>
    public class PromotionGoodsResponseDto
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [JsonProperty("skuId")]
        public long SkuId { get; set; }

        /// <summary>
        /// 商品单价即京东价
        /// </summary>
        [JsonProperty("unitPrice")]
        public double UnitPrice { get; set; }

        /// <summary>
        /// 商品落地页
        /// </summary>
        [JsonProperty("materialUrl")]
        public string MaterialUrl { get; set; }

        /// <summary>
        /// 推广结束日期(时间戳，毫秒)
        /// </summary>
        [JsonProperty("endDate")]
        public long EndDate { get; set; }

        /// <summary>
        /// 推广开始日期（时间戳，毫秒）
        /// </summary>
        [JsonProperty("startDate")]
        public long StartDate { get; set; }

        /// <summary>
        /// 是否支持运费险(1:是,0:否)
        /// </summary>
        [JsonProperty("isFreeFreightRisk")]
        public int IsFreeFreightRisk { get; set; }

        /// <summary>
        /// 是否包邮(1:是,0:否,2:自营商品遵从主站包邮规则)
        /// </summary>
        [JsonProperty("isFreeShipping")]
        public int IsFreeShipping { get; set; }

        /// <summary>
        /// 无线佣金比例
        /// </summary>
        [JsonProperty("commisionRatioWl")]
        public double CommisionRatioWl { get; set; }

        /// <summary>
        /// PC佣金比例
        /// </summary>
        [JsonProperty("commisionRatioPc")]
        public double CommisionRatioPc { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonProperty("imgUrl")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        [JsonProperty("vid")]
        public long Vid { get; set; }

        /// <summary>
        /// 一级类目名称
        /// </summary>
        [JsonProperty("cidName")]
        public string CidName { get; set; }

        /// <summary>
        /// 一级类目ID
        /// </summary>
        [JsonProperty("cid")]
        public int Cid { get; set; }

        /// <summary>
        /// 商品无线京东价（单价为-1表示未查询到该商品单价）
        /// </summary>
        [JsonProperty("wlUnitPrice")]
        public double WlUnitPrice { get; set; }

        /// <summary>
        /// 二级类目名称
        /// </summary>
        [JsonProperty("cid2Name")]
        public string Cid2Name { get; set; }

        /// <summary>
        /// 二级类目ID
        /// </summary>
        [JsonProperty("cid2")]
        public int Cid2 { get; set; }

        /// <summary>
        /// 是否秒杀(1:是,0:否)
        /// </summary>
        [JsonProperty("isSeckill")]
        public int IsSeckill { get; set; }

        /// <summary>
        /// 三级类目名称
        /// </summary>
        [JsonProperty("cid3Name")]
        public string Cid3Name { get; set; }

        /// <summary>
        /// 三级类目ID
        /// </summary>
        [JsonProperty("cid3")]
        public int Cid3 { get; set; }

        /// <summary>
        /// 30天引单数量
        /// </summary>
        [JsonProperty("inOrderCount")]
        public int InOrderCount { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        [JsonProperty("shopId")]
        public long ShopId { get; set; }

        /// <summary>
        /// 是否自营(1:是,0:否)
        /// </summary>
        [JsonProperty("isJdSale")]
        public int IsJdSale { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("goodsName")]
        public string GoodsName { get; set; }
    }
}
