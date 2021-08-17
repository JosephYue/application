using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 猜你喜欢Dto
    /// </summary>
    public class JdUnionOpenGoodsMaterialQueryResponseDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_goods_material_query_responce")]
        public ResponseBaseDto Response { get; set; }

    }
    public class MaterialQueryResultResponseDto
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
        public List<MaterialGoodsResponseDto> Data { get; set; }

    }

    public class MaterialGoodsResponseDto
    {
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
        public CommissionInfoResponse CommissionInfo { get; set; }

        /// <summary>
        /// 优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// </summary>
        [JsonProperty("couponInfo")]
        public CouponInfoResponseDto CouponInfo { get; set; }

        /// <summary>
        /// 商品好评率
        /// </summary>
        [JsonProperty("goodCommentsShare")]
        public double GoodCommentsShare { get; set; }

        /// <summary>
        /// 图片信息
        /// </summary>
        [JsonProperty("imageInfo")]
        public ImageInfoResponseDto ImageInfo { get; set; }

        /// <summary>
        /// 30天引单数量
        /// </summary>
        [JsonProperty("inOrderCount30Days")]
        public int InOrderCount30Days { get; set; }

        /// <summary>
        /// 价格信息
        /// </summary>
        [JsonProperty("priceInfo")]
        public MaterialPriceInfoResponse PriceInfo { get; set; }

        /// <summary>
        /// 店铺信息
        /// </summary>
        [JsonProperty("shopInfo")]
        public MaterialShopInfoResponse ShopInfo { get; set; }

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
        /// 已废弃，请勿使用
        /// </summary>
        [JsonProperty("isHot")]
        public int IsHot { get; set; }

        /// <summary>
        /// spuid，其值为同款商品的主skuid
        /// </summary>
        [JsonProperty("spuid")]
        public long Spuid { get; set; }

        /// <summary>
        /// 品牌名
        /// </summary>
        [JsonProperty("brandCode")]
        public string BrandCode { get; set; }

        /// <summary>
        /// g=自营，p=pop
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 拼购信息
        /// </summary>
        [JsonProperty("pinGouInfo")]
        public object PinGouInfo { get; set; }

        /// <summary>
        /// 资源信息
        /// </summary>
        [JsonProperty("resourceInfo")]
        public MaterialResourceInfoResponse ResourceInfo { get; set; }

        /// <summary>
        /// 秒杀信息
        /// </summary>
        [JsonProperty("seckillInfo")]
        public MaterialSeckillInfoResponse SeckillInfo { get; set; }

        /// <summary>
        /// 京喜商品类型，1京喜、2京喜工厂直供、3京喜优选
        /// </summary>
        [JsonProperty("jxFlags")]
        public List<int> JxFlags { get; set; }

        /// <summary>
        /// 视频信息
        /// </summary>
        [JsonProperty("videoInfo")]
        public MaterialVideoInfoResponse VideoInfo { get; set; }

        /// <summary>
        /// 推广信息
        /// </summary>
        [JsonProperty("promotionInfo")]
        public MaterialPromotionInfoResponse PromotionInfo { get; set; }

        /// <summary>
        /// 图书信息
        /// </summary>
        [JsonProperty("bookInfo")]
        public MaterialbookInfoResponse BookInfo { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        [JsonProperty("skuLabelInfo")]
        public MaterialSkuLabelInfoResponse SkuLabelInfo { get; set; }

        /// <summary>
        /// 商品促销标签集
        /// </summary>
        [JsonProperty("promotionLabelInfoList")]
        public List<MaterialPromotionLabelInfoList> PromotionLabelInfoList { get; set; }

        /// <summary>
        /// 落地页
        /// </summary>
        [JsonProperty("materialUrl")]
        public string MaterialUrl { get; set; }

        /// <summary>
        /// 预售信息
        /// </summary>
        [JsonProperty("preSaleInfo")]
        public MaterialPreSaleInfo PreSaleInfo { get; set; }

        /// <summary>
        /// 有效商品总数量
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// 佣金信息
    /// </summary>
    public class CommissionInfoResponse
    {
        /// <summary>
        /// 佣金
        /// </summary>
        [JsonProperty("commission")]
        public double Commission { get; set; }

        /// <summary>
        /// 佣金比例
        /// </summary>
        [JsonProperty("commissionShare")]
        public double CommissionShare { get; set; }

        /// <summary>
        /// 券后佣金，（促销价-优惠券面额）*佣金比例
        /// </summary>
        [JsonProperty("couponCommission")]
        public double CouponCommission { get; set; }

        /// <summary>
        /// plus佣金比例，plus用户购买推广者能获取到的佣金比例
        /// </summary>
        [JsonProperty("plusCommissionShare")]
        public double PlusCommissionShare { get; set; }
    }

    /// <summary>
    /// 价格信息
    /// </summary>
    public class MaterialPriceInfoResponse
    {
        /// <summary>
        /// 商品价格
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// 促销价
        /// </summary>
        [JsonProperty("lowestPrice")]
        public double LowestPrice { get; set; }

        /// <summary>
        /// 促销价类型，
        /// 1：商品价格
        /// 2：拼购价格
        /// 3：秒杀价格
        /// </summary>
        [JsonProperty("lowestPriceType")]
        public int LowestPriceType { get; set; }

        /// <summary>
        /// 券后价（有无券都返回此字段）
        /// </summary>
        [JsonProperty("lowestCouponPrice")]
        public double LowestCouponPrice { get; set; }

    }

    /// <summary>
    /// 店铺信息
    /// </summary>
    public class MaterialShopInfoResponse
    {
        /// <summary>
        /// 店铺名称（或供应商名称）
        /// </summary>
        [JsonProperty("shopName")]
        public string ShopName { get; set; }

        /// <summary>
        /// 店铺Id
        /// </summary>
        [JsonProperty("shopId")]
        public int ShopId { get; set; }

        /// <summary>
        /// 店铺评分
        /// </summary>
        [JsonProperty("shopLevel")]
        public double ShopLevel { get; set; }

        /// <summary>
        /// 1：京东好店 https://img12.360buyimg.com/schoolbt/jfs/t1/80828/19/2993/908/5d14277aEbb134d76/889d5265315e11ed.png
        /// </summary>
        [JsonProperty("shopLabel")]
        public string ShopLabel { get; set; }

        /// <summary>
        /// 用户评价评分（仅pop店铺有值）
        /// </summary>
        [JsonProperty("userEvaluateScore")]
        public string UserEvaluateScore { get; set; }

        /// <summary>
        /// 用户评价评级（仅pop店铺有值）
        /// </summary>
        [JsonProperty("commentFactorScoreRankGrade")]
        public string CommentFactorScoreRankGrade { get; set; }

        /// <summary>
        /// 物流履约评分（仅pop店铺有值）
        /// </summary>
        [JsonProperty("logisticsLvyueScore")]
        public string LogisticsLvyueScore { get; set; }

        /// <summary>
        /// 物流履约评级（仅pop店铺有值）
        /// </summary>
        [JsonProperty("logisticsFactorScoreRankGrade")]
        public string LogisticsFactorScoreRankGrade { get; set; }

        /// <summary>
        /// 售后服务评分（仅pop店铺有值）
        /// </summary>
        [JsonProperty("afterServiceScore")]
        public string AfterServiceScore { get; set; }

        /// <summary>
        /// 售后服务评级（仅pop店铺有值）
        /// </summary>
        [JsonProperty("afsFactorScoreRankGrade")]
        public string AfsFactorScoreRankGrade { get; set; }

        /// <summary>
        /// 店铺风向标（仅pop店铺有值）
        /// </summary>
        [JsonProperty("scoreRankRate")]
        public string ScoreRankRate { get; set; }

    }

    /// <summary>
    /// 拼购信息
    /// </summary>
    public class MaterialPinGouInfo
    {
        /// <summary>
        /// 拼购价格
        /// </summary>
        [JsonProperty("pingouPrice")]
        public double PingouPrice { get; set; }

        /// <summary>
        /// 拼购成团所需人数
        /// </summary>
        [JsonProperty("pingouTmCount")]
        public int PingouTmCount { get; set; }

        /// <summary>
        /// 拼购开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("pingouStartTime")]
        public long PingouStartTime { get; set; }

        /// <summary>
        /// 拼购结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("pingouEndTime")]
        public long PingouEndTime { get; set; }
    }

    /// <summary>
    /// 资源信息
    /// </summary>
    public class MaterialResourceInfoResponse
    {
        /// <summary>
        /// 频道id
        /// </summary>
        [JsonProperty("eliteId")]
        public int EliteId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonProperty("eliteName")]
        public string EliteName { get; set; }

        /// <summary>
        /// 30天引单数量(sku维度)
        /// </summary>
        [JsonProperty("inOrderCount30DaysSku")]
        public int InOrderCount30DaysSku { get; set; }

    }

    /// <summary>
    /// 秒杀信息
    /// </summary>
    public class MaterialSeckillInfoResponse
    {
        /// <summary>
        /// 秒杀价原价
        /// </summary>
        [JsonProperty("seckillOriPrice")]
        public double SeckillOriPrice { get; set; }

        /// <summary>
        /// 秒杀价
        /// </summary>
        [JsonProperty("seckillPrice")]
        public double SeckillPrice { get; set; }

        /// <summary>
        /// 秒杀开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("seckillStartTime")]
        public long SeckillStartTime { get; set; }

        /// <summary>
        /// 秒杀结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("seckillEndTime")]
        public long SeckillEndTime { get; set; }
    }

    /// <summary>
    /// 视频信息
    /// </summary>
    public class MaterialVideoInfoResponse
    {
        /// <summary>
        /// 视频集合
        /// </summary>
        [JsonProperty("videoList")]
        public List<MaterialvideoListResponse> VideoList { get; set; }
    }

    /// <summary>
    /// 视频集合
    /// </summary>
    public class MaterialvideoListResponse
    {
        /// <summary>
        /// 视频集合
        /// </summary>
        [JsonProperty("video")]
        public MaterialVideoResponse Video { get; set; }
    }

    /// <summary>
    /// 视频合集
    /// </summary>
    public class MaterialVideoResponse
    {
        /// <summary>
        /// 宽
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        [JsonProperty("high")]
        public int High { get; set; }

        /// <summary>
        /// 视频图片地址
        /// </summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 1:主图
        /// 2：商详
        /// </summary>
        [JsonProperty("videoType")]
        public int VideoType { get; set; }

        /// <summary>
        /// low：标清
        /// high：高清
        /// </summary>
        [JsonProperty("playType")]
        public string PlayType { get; set; }

        /// <summary>
        /// 时长(单位:s)
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// 播放地址
        /// </summary>
        [JsonProperty("playUrl")]
        public string PlayUrl { get; set; }

    }

    public class MaterialPromotionInfoResponse
    {
        /// <summary>
        /// 长链推广（转链长链接，无需调用转链接口）
        /// </summary>
        [JsonProperty("clickURL")]
        public string ClickURL { get; set; }
    }

    /// <summary>
    /// 图书信息
    /// </summary>
    public class MaterialbookInfoResponse
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        /// <summary>
        /// 0普通商品
        /// 10微信京东购物小程序禁售
        /// 11微信京喜小程序禁售
        /// </summary>
        [JsonProperty("forbidTypes")]
        public List<int> ForbidTypes { get; set; }

        /// <summary>
        /// 京东配送 1：是，0：不是
        /// </summary>
        [JsonProperty("deliveryType")]
        public int DeliveryType { get; set; }


    }

    public class MaterialSkuLabelInfoResponse
    {
        /// <summary>
        /// 0：不支持
        /// 1或null：支持7天无理由退货
        /// 2：支持90天无理由退货
        /// 4：支持15天无理由退货
        /// 6：支持30天无理由退货
        /// </summary>
        [JsonProperty("is7ToReturn")]
        public int Is7ToReturn { get; set; }

        /// <summary>
        /// 1：放心购商品
        /// </summary>
        [JsonProperty("fxg")]
        public int Fxg { get; set; }

        /// <summary>
        /// 放心购商品子标签集合
        /// </summary>
        [JsonProperty("fxgServiceList")]
        public List<MaterialCharacteristicListServiceInfoResponse> FxgServiceList { get; set; }
    }

    /// <summary>
    /// 放心购商品子标签集合
    /// </summary>
    public class MaterialCharacteristicListServiceInfoResponse
    {
        /// <summary>
        /// 放心购商品子标签，此字段值可能为空
        /// </summary>
        [JsonProperty("characteristicServiceInfo")]
        public MaterialCharacteristicServiceInfoResponse CharacteristicServiceInfo { get; set; }
    }

    /// <summary>
    /// 放心购商品子标签，此字段值可能为空
    /// </summary>
    public class MaterialCharacteristicServiceInfoResponse
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }
    }

    /// <summary>
    /// 商品促销标签集
    /// </summary>
    public class MaterialPromotionLabelInfoList
    {
        /// <summary>
        /// 商品促销标签
        /// </summary>
        [JsonProperty("promotionLabelInfo")]
        public MaterialPromotionLabelInfo PromotionLabelInfo { get; set; }
    }

    /// <summary>
    /// 商品促销标签
    /// </summary>
    public class MaterialPromotionLabelInfo
    {
        /// <summary>
        /// 商品促销文案
        /// </summary>
        [JsonProperty("promotionLabel")]
        public string PromotionLabel { get; set; }

        /// <summary>
        /// 促销标签名称
        /// </summary>
        [JsonProperty("lableName")]
        public string LableName { get; set; }

        /// <summary>
        /// 促销开始时间
        /// </summary>
        [JsonProperty("startTime")]
        public long StartTime { get; set; }

        /// <summary>
        /// 促销结束时间
        /// </summary>
        [JsonProperty("endTime")]
        public long EndTime { get; set; }

        /// <summary>
        /// 促销ID
        /// </summary>
        [JsonProperty("promotionLableId")]
        public long PromotionLableId { get; set; }

    }

    public class MaterialPreSaleInfo
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
        public double Earnest { get; set; }

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
