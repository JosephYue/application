using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 关键字查询参数
    /// </summary>
    public class GoodsQueryParam : ValidateParam
    {
        /// <summary>
        /// 一级类目id
        /// </summary>
        [JsonProperty("cid1")]
        public int? Cid1 { get; set; }

        /// <summary>
        /// 二级类目id
        /// </summary>
        [JsonProperty("cid2")]
        public int? Cid2 { get; set; }

        /// <summary>
        /// 三级类目id
        /// </summary>
        [JsonProperty("cid3")]
        public int? Cid3 { get; set; }

        /// <summary>
        /// 页码，默认1
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页数量，单页数最大30，默认20
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// skuid集合(一次最多支持查询20个sku)，数组类型开发时记得加[]
        /// </summary>
        [JsonProperty("skuIds")]
        public List<long> SkuIds { get; set; }

        /// <summary>
        /// 关键词，字数同京东商品名称一致，目前未限制
        /// </summary>
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// 商品券后价格下限
        /// </summary>
        [JsonProperty("pricefrom")]
        public double? Pricefrom { get; set; }

        /// <summary>
        /// 商品券后价格上限
        /// </summary>
        [JsonProperty("priceto")]
        public double? Priceto { get; set; }

        /// <summary>
        /// 佣金比例区间开始
        /// </summary>
        [JsonProperty("commissionShareStart")]
        public int? CommissionShareStart { get; set; }

        /// <summary>
        /// 佣金比例区间结束
        /// </summary>
        [JsonProperty("commissionShareEnd")]
        public int? CommissionShareEnd { get; set; }

        /// <summary>
        /// 商品类型：自营[g]，POP[p]
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 排序字段(price：单价, 
        /// commissionShare：佣金比例
        /// commission：佣金
        /// inOrderCount30Days：30天引单量
        /// inOrderComm30Days：30天支出佣金)
        /// </summary>
        [JsonProperty("sortName")]
        public string SortName { get; set; }

        /// <summary>
        /// asc,desc升降序,默认降序
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// 是否是优惠券商品
        /// 1：有优惠券
        /// </summary>
        [JsonProperty("isCoupon")]
        public int? IsCoupon { get; set; }

        /// <summary>
        /// 是否是拼购商品
        /// 1：拼购商品
        /// 0：非拼购商品
        /// </summary>
        [JsonProperty("isPG")]
        public int? IsPG { get; set; }

        /// <summary>
        /// 拼购价格区间开始
        /// </summary>
        [JsonProperty("pingouPriceStart")]
        public double? PingouPriceStart { get; set; }

        /// <summary>
        /// 拼购价格区间结束
        /// </summary>
        [JsonProperty("pingouPriceEnd")]
        public double? PingouPriceEnd { get; set; }

        /// <summary>
        /// 品牌code
        /// </summary>
        [JsonProperty("brandCode")]
        public string BrandCode { get; set; }

        /// <summary>
        /// 店铺Id
        /// </summary>
        [JsonProperty("shopId")]
        public long? ShopId { get; set; }

        /// <summary>
        /// 1：查询内容商品；其他值过滤掉此入参条件。
        /// </summary>
        [JsonProperty("hasContent")]
        public int? HasContent { get; set; }

        /// <summary>
        /// 1：查询有最优惠券商品；其他值过滤掉此入参条件。（查询最优券需与isCoupon同时使用）
        /// </summary>
        [JsonProperty("hasBestCoupon")]
        public int? HasBestCoupon { get; set; }

        /// <summary>
        /// 联盟id_应用iD_推广位id
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 支持出参数据筛选，逗号','分隔
        /// 目前可用：videoInfo(视频信息)
        /// hotWords(热词)
        /// similar(相似推荐商品)
        /// documentInfo(段子信息)
        /// skuLabelInfo（商品标签）
        /// promotionLabelInfo（商品促销标签）
        /// stockState（商品库存
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }

        /// <summary>
        /// 10微信京东购物小程序禁售
        /// 11微信京喜小程序禁售
        /// </summary>
        [JsonProperty("forbidTypes")]
        public string ForbidTypes { get; set; }

        /// <summary>
        /// 支持传入0.0、2.5、3.0、3.5、4.0、4.5、4.9，默认为空表示不筛选评分
        /// </summary>
        [JsonProperty("shopLevelFrom")]
        public double? ShopLevelFrom { get; set; }

        /// <summary>
        /// 图书编号
        /// </summary>
        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        /// <summary>
        /// 主商品spuId
        /// </summary>
        [JsonProperty("spuId")]
        public long? SpuId { get; set; }

        /// <summary>
        /// 优惠券链接
        /// </summary>
        [JsonProperty("couponUrl")]
        public string CouponUrl { get; set; }


        /// <summary>
        /// 京东配送 1：是，0：不是
        /// </summary>
        [JsonProperty("deliveryType")]
        public int? DeliveryType { get; set; }

        /// <summary>
        /// 是否秒杀商品。1：是
        /// </summary>
        [JsonProperty("isSeckill")]
        public int? IsSeckill { get; set; }

        /// <summary>
        /// 资源位17：极速版商品
        /// </summary>
        [JsonProperty("eliteType")]
        public int[] EliteType { get; set; }

        internal override void Validate()
        {
            
        }
    }
}
