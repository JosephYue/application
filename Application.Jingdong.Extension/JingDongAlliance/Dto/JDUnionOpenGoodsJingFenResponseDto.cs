using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 京粉精选商品查询接口返回结果
    /// </summary>
    public class JDUnionOpenGoodsJingFenResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_goods_jingfen_query_responce")]
        public GoodsJingFenResponseDto Response { get; set; } = new GoodsJingFenResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class GoodsJingFenResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 查询结果
        /// </summary>
        [JsonProperty("queryResult")]
        public string QueryResult { get; set; }
    }

    /// <summary>
    /// 查询结果
    /// </summary>
    public class GoodsJingFenQueryResultResponseDto
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
        /// 有效商品总数量，上限1w
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 响应id
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 数据明细
        /// </summary>
        [JsonProperty("data")]
        public List<JDUnionOpenGoodsJingfenQueryDataResponseDto> Data { get; set; }
    }


    public class JDUnionOpenGoodsJingfenQueryDataResponseDto
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
        public long Comments { get; set; }

        /// <summary>
        /// 佣金信息
        /// </summary>
        [JsonProperty("commissionInfo")]
        public CommissionInfoResponseDto CommissionInfo { get; set; }

        /// <summary>
        /// 优惠券信息
        /// </summary>
        [JsonProperty("couponInfo")]
        public CouponInfoResponseDto CouponInfo { get; set; }

        /// <summary>
        /// 商品好评率
        /// </summary>
        [JsonProperty("goodCommentsShare")]
        public double? GoodCommentsShare { get; set; }

        /// <summary>
        /// 图片信息
        /// </summary>
        [JsonProperty("imageInfo")]
        public ImageInfoResponseDto ImageInfo { get; set; }

        /// <summary>
        /// 30天引单数量
        /// </summary>
        [JsonProperty("inOrderCount30Days")]
        public long InOrderCount30Days { get; set; }

        /// <summary>
        /// 商品落地页
        /// </summary>
        [JsonProperty("materialUrl")]
        public string MaterialUrl { get; set; }

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
        /// 已废弃，请勿使用
        /// </summary>
        [JsonProperty("isHot")]
        public int IsHot { get; set; }

        /// <summary>
        ///spuid，其值为同款商品的主skuid
        /// </summary>
        [JsonProperty("spuid")]
        public long Spuid { get; set; }

        /// <summary>
        /// 品牌code
        /// </summary>
        [JsonProperty("brandCode")]
        public string BrandCode { get; set; }

        /// <summary>
        /// 品牌名
        /// </summary>
        [JsonProperty("brandName")]
        public string BrandName { get; set; }

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
        /// 资源信息
        /// </summary>
        [JsonProperty("resourceInfo")]
        public ResourceInfoResponseDto ResourceInfo { get; set; }

        /// <summary>
        /// 30天引单数量(sku维度)
        /// </summary>
        [JsonProperty("inOrderCount30DaysSku")]
        public long InOrderCount30DaysSku { get; set; }

        /// <summary>
        /// 秒杀信息
        /// </summary>
        [JsonProperty("seckillInfo")]
        public SeckillInfoResponseDto SeckillInfo { get; set; }

        /// <summary>
        /// 京喜商品类型，1京喜、2京喜工厂直供、3京喜优选（包含3时可在京东APP购买）
        /// </summary>
        [JsonProperty("jxFlags")]
        public List<int> JxFlags { get; set; } = new List<int>();

        /// <summary>
        /// 视频信息
        /// </summary>
        [JsonProperty("videoInfo")]
        public VideoInfoResponseDto VideoInfo { get; set; }

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
    }

    public class CategoryInfoResponseDto
    {
        /// <summary>
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

    public class CommissionInfoResponseDto
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
    }

    public class CouponInfoResponseDto
    {
        /// <summary>
        /// 优惠券集合
        /// </summary>
        [JsonProperty("couponList")]
        public List<CouponListResponseDto> CouponList { get; set; }
    }

    public class CouponListResponseDto
    {
        /// <summary>
        /// 券种类 (优惠券种类：0 - 全品类，1 - 限品类（自营商品），2 - 限店铺，3 - 店铺限商品券)
        /// </summary>
        [JsonProperty("bindType")]
        public int BindType { get; set; }

        /// <summary>
        /// 券面额
        /// </summary>
        [JsonProperty("discount")]
        public double Discount { get; set; }

        /// <summary>
        /// 券链接
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// 券使用平台 (平台类型：0 - 全平台券，1 - 限平台券)
        /// </summary>
        [JsonProperty("platformType")]
        public int PlatformType { get; set; }

        /// <summary>
        /// 券消费限额
        /// </summary>
        [JsonProperty("quota")]
        public double Quota { get; set; }

        /// <summary>
        /// 领取开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("getStartTime")]
        public long GetStartTime { get; set; }

        /// <summary>
        /// 券领取结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("getEndTime")]
        public long GetEndTime { get; set; }

        /// <summary>
        /// 券有效使用开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("useStartTime")]
        public long UseStartTime { get; set; }

        /// <summary>
        /// 券有效使用结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("useEndTime")]
        public long UseEndTime { get; set; }

        /// <summary>
        /// 最优优惠券，1：是；0：否，购买一件商品可使用的面额最大优惠券
        /// </summary>
        [JsonProperty("isBest")]
        public int IsBest { get; set; }

        /// <summary>
        /// 券热度，值越大热度越高，区间:[0,10]
        /// </summary>
        [JsonProperty("hotValue")]
        public int HotValue { get; set; }
    }

    public class ImageInfoResponseDto
    {
        /// <summary>
        /// 图片合集
        /// </summary>
        [JsonProperty("imageList")]
        public List<ImageListResponseDto> ImageList { get; set; }

        /// <summary>
        /// 白底图
        /// </summary>
        [JsonProperty("whiteImage")]
        public string WhiteImage { get; set; }
    }

    public class ImageListResponseDto
    {
        /// <summary>
        /// 图片链接地址，第一个图片链接为主图链接,修改图片尺寸拼接方法：/s***x***_jfs/，例如：http://img14.360buyimg.com/ads/s300x300_jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class PriceInfoResponseDto
    {
        /// <summary>
        /// 历史最低价天数（例：当前券后价最近180天最低）
        /// </summary>
        [JsonProperty("historyPriceDay")]
        public int HistoryPriceDay { get; set; }

        /// <summary>
        /// 券后价（有无券都返回此字段）
        /// </summary>
        [JsonProperty("lowestCouponPrice")]
        public double LowestCouponPrice { get; set; }

        /// <summary>
        /// 促销价
        /// </summary>
        [JsonProperty("lowestPrice")]
        public double LowestPrice { get; set; }

        /// <summary>
        /// 促销价类型，1：无线价格；2：拼购价格； 3：秒杀价格
        /// </summary>
        [JsonProperty("lowestPriceType")]
        public int LowestPriceType { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }
    }

    public class PinGouInfoResponseDto
    {
        /// <summary>
        /// 拼购价格
        /// </summary>
        [JsonProperty("pingouPrice")]
        public double? PingouPrice { get; set; }

        /// <summary>
        /// 拼购成团所需人数
        /// </summary>
        [JsonProperty("pingouTmCount")]
        public long? PingouTmCount { get; set; }

        /// <summary>
        /// 拼购落地页url
        /// </summary>
        [JsonProperty("pingouUrl")]
        public string PingouUrl { get; set; }

        /// <summary>
        /// 拼购结束时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("pingouEndTime")]
        public long PingouEndTime { get; set; }

        /// <summary>
        /// 拼购开始时间(时间戳，毫秒)
        /// </summary>
        [JsonProperty("pingouStartTime")]
        public long PingouStartTime { get; set; }
    }

    public class ResourceInfoResponseDto
    {
        /// <summary>
        /// 频道id
        /// </summary>
        [JsonProperty("eliteId")]
        public int? EliteId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonProperty("eliteName")]
        public string EliteName { get; set; }
    }

    public class ShopInfoResponseDto
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
        public long ShopId { get; set; }

        /// <summary>
        /// 1：京东好店 https://img12.360buyimg.com/schoolbt/jfs/t1/80828/19/2993/908/5d14277aEbb134d76/889d5265315e11ed.png
        /// </summary>
        [JsonProperty("shopLabel")]
        public string ShopLabel { get; set; }

        /// <summary>
        /// 店铺评分
        /// </summary>
        [JsonProperty("shopLevel")]
        public string ShopLevel { get; set; }
    }

    public class SeckillInfoResponseDto
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

    public class VideoInfoResponseDto
    {
        /// <summary>
        /// 视频集合
        /// </summary>
        [JsonProperty("videoList")]
        public List<VideoListResponseDto> VideoList { get; set; }
    }

    public class VideoListResponseDto
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
        /// 1:主图，2：商详
        /// </summary>
        [JsonProperty("videoType")]
        public int VideoType { get; set; }

        /// <summary>
        /// low：标清，high：高清
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

    public class DocumentInfoResponseDto
    {
        /// <summary>
        /// 描述文案
        /// </summary>
        [JsonProperty("document")]
        public string Document { get; set; }

        /// <summary>
        /// 优惠力度文案
        /// </summary>
        [JsonProperty("discount")]
        public string Discount { get; set; }
    }

    public class BookInfoResponseDto
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        [JsonProperty("isbn")]
        public string Isbn { get; set; }
    }

    public class SkuLabelInfoResponseDto
    {
        /// <summary>
        ///0：不支持；
        ///1或null支持7天无理由退货；
        ///2：支持90天无理由退货； 
        ///4：支持15天无理由退货； 
        ///6：支持30天无理由退货；
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
        public List<FxgServiceListResponseDto> FxgServiceList { get; set; }
    }

    public class FxgServiceListResponseDto
    {
        /// <summary>
        /// 放心购商品子标签，此字段值可能为空
        /// </summary>
        [JsonProperty("characteristicServiceInfo")]
        public CharacteristicServiceInfoResponseDto characteristicServiceInfo { get; set; }
    }

    public class CharacteristicServiceInfoResponseDto
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }
    }

    public class PromotionLabelInfoList
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

    public class SecondPriceInfoListResponseDto
    {
        /// <summary>
        /// 双价格类型：18新人价
        /// </summary>
        [JsonProperty("secondPriceType")]
        public double SecondPriceType { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("secondPrice")]
        public double SecondPrice { get; set; }
    }
}
