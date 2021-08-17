using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    public class JDUnionOpenGoodsBigfieldQueryDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_goods_bigfield_query_responce")]
        public ResponseBaseDto Response { get; set; }
    }

    public class JDUnionOpenGoodsBigfieldQueryResponseDto
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
        public List<BigFieldGoodsRespResponseDto> Data { get; set; }
    }
    public class BigFieldGoodsRespResponseDto
    {
        /// <summary>
        /// skuId
        /// </summary>
        [JsonProperty("skuId")]
        public long SkuId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("skuName")]
        public string SkuName { get; set; }

        /// <summary>
        /// 类目信息
        /// </summary>
        [JsonProperty("categoryInfo")]
        public BigFieldCategoryInfoResponse CategoryInfo { get; set; }

        /// <summary>
        /// 图片信息
        /// </summary>
        [JsonProperty("imageInfo")]
        public BigFieldImageInfoResponseDto ImageInfo { get; set; }

        /// <summary>
        /// 基础大字段信息
        /// </summary>
        [JsonProperty("baseBigFieldInfo")]
        public BigFieldInfoResponseDto BaseBigFieldInfo { get; set; }

        /// <summary>
        /// 图书大字段信息
        /// </summary>
        [JsonProperty("bookBigFieldInfo")]
        public BigFieldBookBigFieldInfoDto BookBigFieldInfo { get; set; }

        /// <summary>
        /// 影音大字段信息
        /// </summary>
        [JsonProperty("videoBigFieldInfo")]
        public BigFiledVideoBigFieldInfoDto VideoBigFieldInfo { get; set; }

        /// <summary>
        /// 自营主skuId
        /// </summary>
        [JsonProperty("mainSkuId")]
        public long MainSkuId { get; set; }

        /// <summary>
        /// 非自营商品Id
        /// </summary>
        [JsonProperty("productId")]
        public long ProductId { get; set; }

        /// <summary>
        /// sku上下架状态 
        /// 1：上架(可搜索，可购买)
        /// 0：下架(可通过skuid搜索，不可购买)
        /// 2：可上架（可通过skuid搜索，不可购买）
        /// 10：pop 删除（不可搜索，不可购买））
        /// </summary>
        [JsonProperty("skuStatus")]
        public int SkuStatus { get; set; }

        /// <summary>
        /// g=自营，p=pop
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 商详图
        /// </summary>
        [JsonProperty("detailImages")]
        public string DetailImages { get; set; }

    }

    /// <summary>
    /// 类目信息
    /// </summary>
    public class BigFieldCategoryInfoResponse
    {
        ///<summary>
        /// 一级类目ID
        /// </summary>
        [JsonProperty("cid1")]
        public long Cid1 { get; set; }

        /// <summary>
        /// 一级类目名称
        /// </summary>
        [JsonProperty("cid1Name")]
        public string Cid1Name { get; set; }

        /// <summary>
        /// 二级类目ID
        /// </summary>
        [JsonProperty("cid2")]
        public long Cid2 { get; set; }

        /// <summary>
        /// 二级类目名称
        /// </summary>
        [JsonProperty("cid2Name")]
        public string Cid2Name { get; set; }

        /// <summary>
        /// 三级类目ID
        /// </summary>
        [JsonProperty("cid3")]
        public long Cid3 { get; set; }

        /// <summary>
        /// 三级类目名称
        /// </summary>
        [JsonProperty("cid3Name")]
        public string Cid3Name { get; set; }
    }

    /// <summary>
    /// 图片信息
    /// </summary>
    public class BigFieldImageInfoResponseDto
    {
        /// <summary>
        /// 图片合集
        /// </summary>
        [JsonProperty("imageList")]
        public List<BigFieldImageListResponseDto> ImageList { get; set; }

        /// <summary>
        /// 白底图
        /// </summary>
        [JsonProperty("whiteImage")]
        public string WhiteImage { get; set; }
    }

    /// <summary>
    /// 图片合集
    /// </summary>
    public class BigFieldImageListResponseDto
    {
        /// <summary>
        /// 图片链接地址，第一个图片链接为主图链接,修改图片尺寸拼接方法：/s***x***_jfs/，例如：http://img14.360buyimg.com/ads/s300x300_jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// 基础大字段信息
    /// </summary>
    public class BigFieldInfoResponseDto
    {
        /// <summary>
        /// 商品介绍
        /// </summary>
        [JsonProperty("wdis")]
        public string Wdis { get; set; }

        /// <summary>
        /// 规格参数
        /// </summary>
        [JsonProperty("propCode")]
        public string PropCode { get; set; }

        /// <summary>
        /// 包装清单(仅自营商品)
        /// </summary>
        [JsonProperty("wareQD")]
        public string WareQD { get; set; }
    }

    /// <summary>
    /// 图书大字段信息
    /// </summary>
    public class BigFieldBookBigFieldInfoDto
    {
        /// <summary>
        /// 媒体评论
        /// </summary>
        [JsonProperty("comments")]
    public string Comments { get; set; }

        /// <summary>
        /// 精彩文摘与插图(插图)
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// 内容摘要(内容简介)
        /// </summary>
        [JsonProperty("contentDesc")]
        public string ContentDesc { get; set; }

        /// <summary>
        /// 产品描述(相关商品)
        /// </summary>
        [JsonProperty("relatedProducts")]
        public string RelatedProducts { get; set; }

        /// <summary>
        /// 编辑推荐
        /// </summary>
        [JsonProperty("editerDesc")]
        public string EditerDesc { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        [JsonProperty("catalogue")]
        public string Catalogue { get; set; }

        /// <summary>
        /// 精彩摘要(精彩书摘)
        /// </summary>
        [JsonProperty("bookAbstract")]
        public string BookAbstract { get; set; }

        /// <summary>
        /// 作者简介
        /// </summary>
        [JsonProperty("authorDesc")]
        public string AuthorDesc { get; set; }

        /// <summary>
        /// 前言(前言/序言)
        /// </summary>
        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 产品特色
        /// </summary>
        [JsonProperty("productFeatures")]
        public string ProductFeatures { get; set; }

    }

    /// <summary>
    /// 影音大字段信息
    /// </summary>
    public class BigFiledVideoBigFieldInfoDto
    {
        /// <summary>
        /// 评论
        /// </summary>
        [JsonProperty("comments")]
    public string Comments { get; set; }

        /// <summary>
        /// 商品描述(精彩剧照)
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// 内容摘要(内容简介)
        /// </summary>
        [JsonProperty("contentDesc")]
        public string ContentDesc { get; set; }

        /// <summary>
        /// 编辑推荐
        /// </summary>
        [JsonProperty("editerDesc")]
        public string EditerDesc { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        [JsonProperty("catalogue")]
        public string Catalogue { get; set; }

        /// <summary>
        /// 包装清单
        /// </summary>
        [JsonProperty("box_Contents")]
        public string Box_Contents { get; set; }

        /// <summary>
        /// 特殊说明
        /// </summary>
        [JsonProperty("material_Description")]
        public string Material_Description { get; set; }

        /// <summary>
        /// 说明书
        /// </summary>
        [JsonProperty("manual")]
        public string Manual { get; set; }

        /// <summary>
        /// 产品特色
        /// </summary>
        [JsonProperty("productFeatures")]
        public string ProductFeatures { get; set; }

    }

}
