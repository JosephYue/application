using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.Jingdong.Extension.JingDongKepler.Dto
{
    public class OrderGetListResultDto : KeplerResponse
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_kepler_order_getlist_responce")]
        public JdKeplerOrderGetListResponseDto Response { get; set; }
    }

    public class JdKeplerOrderGetListResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("getlistResult")]
        public GetListResponseDto GetlistResult { get; set; }
    }

    public class GetListResponseDto
    {
        /// <summary>
        ///true还有其他订单，可继续翻页；false没有更多订单了
        /// </summary>
        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// appKey
        /// </summary>
        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 日期 为YYYYMMDDhhmmss格式
        /// </summary>
        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 1成功，0失败
        /// </summary>
        [JsonProperty("success")]
        public int Success { get; set; }

        /// <summary>
        /// 查询页
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 订单集合
        /// </summary>
        [JsonProperty("orders")]
        public List<OrderResponseDto> Orders { get; set; } = new List<OrderResponseDto>();
    }

    public class OrderResponseDto
    {
        /// <summary>
        /// 订单状态
        /// -1 未知 
        /// 1 新订单
        /// 2 等待付款
        /// 3 等待付款确定
        /// 4 延迟付款确定
        /// 5 已付款
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 订单更新时间
        /// </summary>
        [JsonProperty("updateTime")]
        public string UpdateTime { get; set; }

        /// <summary>
        /// 订单类型 参考http://kepler.jd.com/console/docCenterCatalog/docContent?channelId=33
        ///0 一般订单
        ///2 拍卖订单
        ///8 服务产品
        ///11 售后调货
        ///15 返修发货
        ///16 直接赔偿
        ///18 厂商直送
        ///19 客服补件
        ///21 PopFbp
        ///22 PopSop
        ///23 PopLbp
        ///25 POp SOPL
        ///28 团购(虚拟)
        ///33 电子礼品卡
        ///34 游戏点卡
        ///35 机票
        ///36 彩票
        ///37 手机充值(新)
        ///38 电子书订单
        ///39 酒店订单
        ///42 通用合约计划
        ///43 电影票
        ///44 景点门票
        ///45 租车
        ///46 火车票
        ///47 旅游
        ///49 实物礼品卡
        ///51 误购取件费订单
        ///53 票务订单
        ///54 线下礼品卡订单
        ///55 域名订单
        ///56 节能补贴订单
        ///57 应用商店订单
        ///58 数字音乐
        ///61 EPT订单
        ///62 网页游戏
        ///63 POP拍卖
        ///64 非车险保险订单
        ///65 车险订单
        ///66 数字音乐IAP订单
        ///67 电子书IAP订单
        ///68 POP拍卖保证金订单
        ///69 京东服务产品订单
        ///70 软件服务订单
        ///71 培训服务订单
        ///72 模板服务订单
        ///73 需求外包
        ///74 生活缴费订单
        ///75 LOC
        ///76 云产品订单
        ///77 LSP
        ///78 电商云订单
        ///79 电商云平台订单
        ///80 服务市场代销
        ///81 电商云代销
        ///82 汽车票订单
        ///83 国际机票订单
        ///84 拍拍对接快捷支付实物订单
        ///85 拍拍对接快捷支付虚拟订单
        ///86 合约机虚拟订单
        ///87 手机流量充值
        ///88 B2B订单
        ///89 移动仓库订单
        ///90 易车订单
        ///91 会员PLUS
        ///92 客服外包订单
        ///93 会唐商旅订单
        ///94 运营商手机流量充值订单
        ///95 供应商罗盘订单
        ///96 sop虚拟订单
        ///97 京东万象订单
        ///98 一元抢宝订单
        ///99 中石油充值订单
        ///100 年货卡
        ///101 千寻订单
        ///102 自营售码订单
        ///103 拍摄服务
        ///104 京东图库
        ///105 在线视频教育
        ///106 山姆会员虚拟卡售卡订单
        ///107 海外房产订单
        ///108 京东售后服务产品
        ///109 卡密充值
        ///110 问诊单
        ///111 国际酒店
        ///112 FCS
        ///113 捐赠订单
        ///114 京答订单
        ///115 商家资质认证订单
        ///116 场馆预订订单
        ///117 在线问卷调研订单
        ///118 迪士尼订单
        ///119 京麦平台自营订单
        ///120 京麦平台POP订单
        ///121 抢宝自营模式（GO专享）订单
        ///122 车险订单
        ///123 城市一卡通充值订单
        ///124 京东通信能力开放平台订单
        /// </summary>
        [JsonProperty("orderType")]
        public int OrderType { get; set; }

        /// <summary>
        /// 支付方式 参考 http://kepler.jd.com/console/docCenterCatalog/docContent?channelId=32
        ///1 货到付款
        ///2 邮局汇款
        ///3 自提
        ///4 在线支付
        ///5 公司转帐
        ///8 分期付款
        ///12 月结
        ///16 校园自提
        ///17 好邻居自提
        ///18 社区自提
        ///19 自提柜
        ///99 混合支付
        ///165 银联手机支付
        /// </summary>
        [JsonProperty("idPaymentType")]
        public int IdPaymentType { get; set; }

        /// <summary>
        ///支付状态：0未支付，1支付成功
        /// </summary>
        [JsonProperty("idPaymentStatus")]
        public int IdPaymentStatus { get; set; }

        /// <summary>
        /// 配送方式 参考http://kepler.jd.com/console/docCenterCatalog/docContent?channelId=31
        /// </summary>
        [JsonProperty("idShipmentType")]
        public int IdShipmentType { get; set; }

        /// <summary>
        /// 父订单号
        /// </summary>
        [JsonProperty("parentId")]
        public int ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("yn")]
        public int Yn { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        /// <summary>
        /// 配送状态：0新增，1妥投，2拒收
        /// </summary>
        [JsonProperty("idShipmentStatus")]
        public int IdShipmentStatus { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// 原始应付金额
        /// </summary>
        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 商品集合
        /// </summary>
        [JsonProperty("skuInfos")]
        public List<SkuInfoResponseDto> SkuInfos { get; set; } = new List<SkuInfoResponseDto>();
    }

    public class SkuInfoResponseDto
    {
        /// <summary>
        /// 图片url
        /// </summary>
        [JsonProperty("imgUrl")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// skuid
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("num")]
        public int Num { get; set; }

        /// <summary>
        /// 价钱
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        [JsonProperty("cid2")]
        public int Cid2 { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        [JsonProperty("cid")]
        public int Cid { get; set; }
    }
}
