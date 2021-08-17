using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 关键字查询Dto
    /// </summary>
    public class JDUnionOpenGoodsQueryResponseDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_goods_query_responce")]
        public ResponseBaseDto Response { get; set; }
    }

    public class QueryResultResponseDto
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
        /// 响应id
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 有效商品总数量，上限1w
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 数据明细
        /// </summary>
        [JsonProperty("data")]
        public List<JDUnionOpenGoodsQueryDataResponseDto> Data { get; set; }

        /// <summary>
        /// 日常top10的热搜词，按小时更新
        /// </summary>
        [JsonProperty("hotWords")]
        public string HotWords { get; set; }

        /// <summary>
        /// 相似推荐商品skuId集合
        /// </summary>
        [JsonProperty("similarSkuList")]
        public List<long> SimilarSkuList { get; set; }
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenGoodsQueryDataResponseDto
    {
        /// <summary>
        /// 品牌Code
        /// </summary>
        [JsonProperty("brandCode")]
        public string BrandCode { get; set; }

        /// <summary>
        /// 品牌名
        /// </summary>
        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        /// <summary>
        /// 类目信息
        /// </summary>
        [JsonProperty("categoryInfo")]
        public CategoryInfoResponseDto CategoryInfo { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        [JsonProperty("comments")]
        public int Comments { get; set; }

        /// <summary>
        /// 佣金信息
        /// </summary>
        [JsonProperty("commissionInfo")]
        public CommissionInfoResponseDto CommissionInfo { get; set; }

        /// <summary>
        /// 优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// </summary>
        [JsonProperty("couponInfo")]
        public CouponInfoResponseDto CouponInfo { get; set; }

        /// <summary>
        /// 商品好评率
        /// </summary>
        [JsonProperty("goodCommentsShare")]
        public string GoodCommentsShare { get; set; }

        /// <summary>
        /// 京东配送 1：是，0：不是
        /// </summary>
        [JsonProperty("deliveryType")]
        public int DeliveryType { get; set; }

        /// <summary>
        /// 资源位17：极速版商品
        /// </summary>
        [JsonProperty("eliteType")]
        public List<int> EliteType { get; set; }

        /// <summary>
        /// 0普通商品
        /// 10微信京东购物小程序禁售
        /// 11微信京喜小程序禁售
        /// </summary>
        [JsonProperty("forbidTypes")]
        public List<int> ForbidTypes { get; set; }

        /// <summary>
        /// 图片信息
        /// </summary>
        [JsonProperty("imageInfo")]
        public ImageInfoResponseDto ImageInfo { get; set; }

        /// <summary>
        /// 30天支出佣金
        /// </summary>
        [JsonProperty("inOrderComm30Days")]
        public double InOrderComm30Days { get; set; }

        /// <summary>
        /// 30天引单数量
        /// </summary>
        [JsonProperty("inOrderCount30Days")]
        public double InOrderCount30Days { get; set; }

        /// <summary>
        /// 已废弃，请勿使用
        /// </summary>
        [JsonProperty("isHot")]
        public int IsHot { get; set; }

        /// <summary>
        /// 京喜商品类型
        /// 1京喜
        /// 2京喜工厂直供
        /// 3京喜优选（包含3时可在京东APP购买）
        /// </summary>
        [JsonProperty("jxFlags")]
        public List<int> JxFlags { get; set; }

        /// <summary>
        /// 商品链接
        /// </summary>
        [JsonProperty("materialUrl")]
        public string MaterialUrl { get; set; }

        /// <summary>
        /// g=自营，p=pop
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 拼购信息
        /// </summary>
        [JsonProperty("pinGouInfo")]
        public PinGouInfoResponseDto PinGouInfo { get; set; }

        /// <summary>
        /// 价格信息
        /// </summary>
        [JsonProperty("priceInfo")]
        public PriceInfoResponseDto PriceInfo { get; set; }

        /// <summary>
        /// 店铺信息
        /// </summary>
        [JsonProperty("shopInfo")]
        public ShopInfoResponseDto ShopInfo { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [JsonProperty("skuId")]
        public long SkuId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("skuName")]
        public string SkuName { get; set; }

        /// <summary>
        /// spuid，其值为同款商品的主skuid
        /// </summary>
        [JsonProperty("spuid")]
        public long Spuid { get; set; }

        /// <summary>
        /// 视频信息
        /// </summary>
        [JsonProperty("videoInfo")]
        public VideoInfoResponseDto VideoInfo { get; set; }

        /// <summary>
        /// 评价信息
        /// </summary>
        [JsonProperty("commentInfo")]
        public CommentInfoResponseDto CommentInfo { get; set; }

        /// <summary>
        /// 段子信息
        /// </summary>
        [JsonProperty("documentInfo")]
        public DocumentInfoResponseDto DocumentInfo { get; set; }

        /// <summary>
        /// 图书信息
        /// </summary>
        [JsonProperty("bookInfo")]
        public BookInfoResponseDto BookInfo { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        [JsonProperty("specInfo")]
        public SpecInfoResponseDto SpecInfo { get; set; }

        /// <summary>
        /// 库存状态：1有货、0无货（供tob选品场景参考，toc场景不适用）
        /// </summary>
        [JsonProperty("stockState")]
        public int StockState { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        [JsonProperty("skuLabelInfo")]
        public SkuLabelInfoResponseDto SkuLabelInfo { get; set; }

        /// <summary>
        /// 商品促销标签集
        /// </summary>
        [JsonProperty("promotionLabelInfoList")]
        public List<PromotionLabelInfoList> PromotionLabelInfoList { get; set; }

        /// <summary>
        /// 双价格
        /// </summary>
        [JsonProperty("secondPriceInfoList")]
        public List<SecondPriceInfoListResponseDto> SecondPriceInfoList { get; set; }

        /// <summary>
        /// 秒杀信息
        /// </summary>
        [JsonProperty("seckillInfo")]
        public SeckillInfoResponseDto SeckillInfo { get; set; }

        /// <summary>
        /// 预售信息
        /// </summary>
        [JsonProperty("preSaleInfo")]
        public PreSaleInfoResponseDto PreSaleInfo { get; set; }
    }

    /// <summary>
    /// 评价信息Dto
    /// </summary>
    public class CommentInfoResponseDto
    {
        /// <summary>
        /// 评价集合
        /// </summary>
        [JsonProperty("commentList")]
        public List<CommentListResponseDto> CommentList { get; set; }

    }

    /// <summary>
    /// 评价集合
    /// </summary>
    public class CommentListResponseDto
    {
        /// <summary>
        /// 评价列表
        /// </summary>
        [JsonProperty("comment")]
        public CommentResponsenDto Comment { get; set; }
    }

    /// <summary>
    /// 评价列表
    /// </summary>
    public class CommentResponsenDto
    {
        /// <summary>
        /// 评价内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 图片集合
        /// </summary>
        [JsonProperty("imageList")]
        public List<ImageListResponseDto> ImageList { get; set; }
    }

    /// <summary>
    /// 图片集合
    /// </summary>
    public class GoodImageListResponseDto
    {
        /// <summary>
        /// 图片集合
        /// </summary>
        [JsonProperty("urlInfo")]
        public UrlInfoResponseDto UrlInfo { get; set; }
    }

    /// <summary>
    /// 图片集合
    /// </summary>
    public class UrlInfoResponseDto
    {
        /// <summary>
        /// 图片链接地址
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// 扩展信息
    /// </summary>
    public class SpecInfoResponseDto
    {

        /// <summary>
        /// 尺寸
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// 自定义属性
        /// </summary>
        [JsonProperty("spec")]
        public string Spec { get; set; }

        /// <summary>
        /// 自定义属性名称
        /// </summary>
        [JsonProperty("specName")]
        public string SpecName { get; set; }

    }


    /// <summary>
    /// 预售信息
    /// </summary>
    public class PreSaleInfoResponseDto
    {
        /// <summary>
        /// 预售价格
        /// </summary>
        [JsonProperty("currentPrice")]
        public double CurrentPrice { get; set; }

        /// <summary>
        /// 订金金额（定金不能超过预售总价的20%）
        /// </summary>
        [JsonProperty("earnest")]
        public int Earnest { get; set; }

        /// <summary>
        /// 预售支付类型：1.仅全款 2.定金、全款均可 5.一阶梯仅定金
        /// </summary>
        [JsonProperty("presalePayType")]
        public int PresalePayType { get; set; }

        /// <summary>
        /// 1: 定金膨胀 2: 定金立减
        /// </summary>
        [JsonProperty("discountType")]
        public int DiscountType { get; set; }

        /// <summary>
        /// 定金膨胀金额（定金可抵XXX）
        /// </summary>
        [JsonProperty("depositWorth")]
        public int DepositWorth { get; set; }

        /// <summary>
        /// 立减金额
        /// </summary>
        [JsonProperty("preAmountDeposit")]
        public int PreAmountDeposit { get; set; }

        /// <summary>
        /// 定金开始时间
        /// </summary>
        [JsonProperty("presaleStartTime")]
        public long PresaleStartTime { get; set; }

        /// <summary>
        /// 定金结束时间
        /// </summary>
        [JsonProperty("presaleEndTime")]
        public long PresaleEndTime { get; set; }

        /// <summary>
        /// 尾款开始时间
        /// </summary>
        [JsonProperty("balanceStartTime")]
        public long BalanceStartTime { get; set; }

        /// <summary>
        /// 尾款结束时间
        /// </summary>
        [JsonProperty("balanceEndTime")]
        public long BalanceEndTime { get; set; }

        /// <summary>
        /// 预计发货时间
        /// </summary>
        [JsonProperty("shipTime")]
        public long ShipTime { get; set; }

        /// <summary>
        /// 预售状态（0 未开始；1 预售中；2 预售结束；3 尾款进行中；4 尾款结束）
        /// </summary>
        [JsonProperty("presaleStatus")]
        public int PresaleStatus { get; set; }
    }
}
