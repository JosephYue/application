using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 工具商订单行查询接口返回结果
    /// </summary>
    public class JDUnionOpenOrderAgentQueryResponseDto
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_union_open_order_agent_query_responce")]
        public OrderAgentQueryResponseDto Response { get; set; } = new OrderAgentQueryResponseDto();
    }

    /// <summary>
    /// 响应信息
    /// </summary>
    public class OrderAgentQueryResponseDto
    {
        /// <summary>
        /// 返回码
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
    public class OrderAgentQueryResultResponseDto
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
        public List<JDUnionOpenOrderAgentQueryDataResponseDto> Data { get; set; } = new List<JDUnionOpenOrderAgentQueryDataResponseDto>();

        /// <summary>
        /// 是否还有更多
        /// true：还有数据
        /// false:已查询完毕，没有数据
        /// </summary>
        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenOrderAgentQueryDataResponseDto
    {
        /// <summary>
        /// 标记唯一订单行
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// 父单的订单号：如一个订单拆成多个子订单时，原订单号会作为父单号，拆分的订单号为子单号存储在orderid中。若未发生拆单，该字段为0
        /// </summary>
        [JsonProperty("parentId")]
        public long ParentId { get; set; }

        /// <summary>
        /// 下单时间,格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonProperty("orderTime")]
        public string OrderTime { get; set; }

        /// <summary>
        /// 完成时间（购买用户确认收货时间）,格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonProperty("finishTime")]
        public string FinishTime { get; set; }

        /// <summary>
        /// 更新时间,格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonProperty("modifyTime")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 下单设备 1.pc 2.无线
        /// </summary>
        [JsonProperty("orderEmt")]
        public int OrderEmt { get; set; }

        /// <summary>
        /// plus会员 1:是，0:否
        /// </summary>
        [JsonProperty("plus")]
        public int Plus { get; set; }

        /// <summary>
        /// 推客ID
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

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
        /// 商品数量
        /// </summary>
        [JsonProperty("skuNum")]
        public int SkuNum { get; set; }

        /// <summary>
        /// 商品已退货数量
        /// </summary>
        [JsonProperty("skuReturnNum")]
        public int SkuReturnNum { get; set; }

        /// <summary>
        /// 商品售后中数量
        /// </summary>
        [JsonProperty("skuFrozenNum")]
        public int SkuFrozenNum { get; set; }

        /// <summary>
        /// 商品单价
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// 佣金比例(投放的广告主计划比例)
        /// </summary>
        [JsonProperty("commissionRate")]
        public float CommissionRate { get; set; }

        /// <summary>
        /// 一级分成比例
        /// </summary>
        [JsonProperty("subSideRate")]
        public float SubSideRate { get; set; }

        /// <summary>
        /// 一级补贴比例
        /// </summary>
        [JsonProperty("subsidyRate")]
        public float SubsidyRate { get; set; }

        /// <summary>
        /// 最终分佣比例=分成比例+补贴比例 （单位：%）
        /// </summary>
        [JsonProperty("finalRate")]
        public float FinalRate { get; set; }

        /// <summary>
        /// 预估计佣金额：由订单的实付金额拆分至每个商品的预估计佣金额，不包括运费，以及京券、东券、E卡、余额等虚拟资产支付的金额。该字段仅为预估值，实际佣金以actualCosPrice为准进行计算
        /// </summary>
        [JsonProperty("estimateCosPrice")]
        public decimal EstimateCosPrice { get; set; }

        /// <summary>
        /// 推客的预估佣金（预估计佣金额*佣金比例*最终比例），如订单完成前发生退款，此金额也会更新。
        /// </summary>
        [JsonProperty("estimateFee")]
        public decimal EstimateFee { get; set; }

        /// <summary>
        /// 实际计算佣金的金额。订单完成后，会将误扣除的运费券金额更正。如订单完成后发生退款，此金额会更新。
        /// </summary>
        [JsonProperty("actualCosPrice")]
        public decimal ActualCosPrice { get; set; }

        /// <summary>
        /// 推客分得的实际佣金（实际计佣金额*佣金比例*最终比例）。如订单完成后发生退款，此金额会更新。
        /// </summary>
        [JsonProperty("actualFee")]
        public decimal ActualFee { get; set; }

        /// <summary>
        /// sku维度的有效码
        /// -1：未知
        /// 2.无效-拆单
        /// 3.无效-取消
        /// 4.无效-京东帮帮主订单
        /// 5.无效-账号异常
        /// 6.无效-赠品类目不返佣
        /// 7.无效-校园订单
        /// 8.无效-企业订单
        /// 9.无效-团购订单
        /// 11.无效-乡村推广员下单
        /// 13.无效-违规订单
        /// 14.无效-来源与备案网址不符
        /// 15.待付款
        /// 16.已付款
        /// 17.已完成（购买用户确认收货）
        /// 20.无效-此复购订单对应的首购订单无效
        /// 21.无效-云店订单
        /// 22. 无效-PLUS会员佣金比例为0
        /// </summary>
        [JsonProperty("validCode")]
        public int ValidCode { get; set; }

        /// <summary>
        /// 同跨店：
        /// 2同店 
        /// 3跨店
        /// </summary>
        [JsonProperty("traceType")]
        public int TraceType { get; set; }

        /// <summary>
        /// 推广位ID
        /// </summary>
        [JsonProperty("positionId")]
        public int PositionId { get; set; }

        /// <summary>
        /// 应用id（网站id、appid、社交媒体id）
        /// </summary>
        [JsonProperty("siteId")]
        public long SiteId { get; set; }

        /// <summary>
        /// PID所属母账号平台名称（原第三方服务商来源），两方分佣会有该值
        /// </summary>
        [JsonProperty("unionAlias")]
        public string UnionAlias { get; set; }

        /// <summary>
        /// 格式:子推客ID_子站长应用ID_子推客推广位ID
        /// </summary>
        [JsonProperty("pid")]
        public string PId { get; set; }

        /// <summary>
        /// 一级类目id
        /// </summary>
        [JsonProperty("cid1")]
        public long Cid1 { get; set; }

        /// <summary>
        /// 二级类目id
        /// </summary>
        [JsonProperty("cid2")]
        public long Cid2 { get; set; }

        /// <summary>
        /// 三级类目id
        /// </summary>
        [JsonProperty("cid3")]
        public long Cid3 { get; set; }

        /// <summary>
        /// 子联盟ID(需要联系运营开放白名单才能拿到数据)
        /// </summary>
        [JsonProperty("subUnionId")]
        public string SubUnionId { get; set; }

        /// <summary>
        /// 联盟标签数据（32位整型二进制字符串：00000000000000000000000000000001。数据从右向左进行，每一位为1表示符合特征
        /// 第1位：红包
        /// 第2位：组合推广
        /// 第3位：拼购
        /// 第5位：有效首次购（0000000000011XXX表示有效首购，最终奖励活动结算金额会结合订单状态判断，以联盟后台对应活动效果数据报表https://union.jd.com/active为准）
        /// 第8位：复购订单
        /// 第9位：礼金
        /// 第10位：联盟礼金
        /// 第11位：推客礼金
        /// 第12位：京喜APP首购
        /// 第13位：京喜首购
        /// 第14位：京喜复购
        /// 第15位：京喜订单
        /// 第16位：京东极速版APP首购
        /// 第17位白条首购
        /// 第18位校园订单
        /// 第19位是0或1时，均代表普通订单
        /// 第20位：预售订单 例如：00000000000000000000000000000001:红包订单
        /// 00000000000000000000000000000010:组合推广订单
        /// 00000000000000000000000000000100:拼购订单
        /// 00000000000000000000000000011000:有效首购
        /// 00000000000000000000000000000111：红包+组合推广+拼购等） 
        /// 注：一个订单同时使用礼金和红包，仅礼金位数为1，红包位数为0
        /// </summary>
        [JsonProperty("unionTag")]
        public string UnionTag { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        [JsonProperty("popId")]
        public long popId { get; set; }

        /// <summary>
        /// 推客生成推广链接时传入的扩展字段（需要联系运营开放白名单才能拿到数据）
        /// </summary>
        [JsonProperty("ext1")]
        public string Ext1 { get; set; }

        /// <summary>
        /// 预估结算时间，订单完成后才会返回，格式：yyyyMMdd
        /// 默认：0。表示最新的预估结算日期。
        /// 当payMonth为当前的未来时间时，表示该订单可结算
        /// 当payMonth为当前的过去时间时，表示该订单已结算
        /// </summary>
        [JsonProperty("payMonth")]
        public string PayMonth { get; set; }

        /// <summary>
        /// 招商团活动id：当商品参加了招商团会有该值，为0时表示无活动
        /// </summary>
        [JsonProperty("cpActId")]
        public int CpActId { get; set; }

        /// <summary>
        /// 站长角色
        /// 1 推客 
        /// 2 团长
        /// </summary>
        [JsonProperty("unionRole")]
        public int UnionRole { get; set; }

        /// <summary>
        /// 礼金分摊金额：使用礼金的订单会有该值
        /// </summary>
        [JsonProperty("giftCouponOcsAmount")]
        public decimal GiftCouponOcsAmount { get; set; }

        /// <summary>
        /// 礼金批次ID：使用礼金的订单会有该值
        /// </summary>
        [JsonProperty("giftCouponKey")]
        public int GiftCouponKey { get; set; }

        /// <summary>
        /// 计佣扩展信息，表示结算月:每月实际佣金变化情况，格式：{20191020:10,20191120:-2}，注意：有完成时间的，才会有这个值
        /// </summary>
        [JsonProperty("balanceExt")]
        public string BalanceExt { get; set; }

        /// <summary>
        /// 数据签名，用来核对出参数据是否被修改，入参fields中写入sign时返回
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 价保赔付金额：订单申请价保或赔付的金额，实际计佣金额已经减去此金额，您无需处理
        /// </summary>
        [JsonProperty("proPriceAmount")]
        public decimal ProPriceAmount { get; set; }

        /// <summary>
        /// 商品信息，入参传入fields，goodsInfo获取
        /// </summary>
        [JsonProperty("goodsInfo")]
        public OrderAgentQueryDataGoodsInfoResponseDto GoodsInfo { get; set; } = new OrderAgentQueryDataGoodsInfoResponseDto();

        /// <summary>
        /// 类目信息,入参传入fields，categoryInfo获取
        /// </summary>
        [JsonProperty("categoryInfo")]
        public OrderAgentQueryDataCategoryInfoResponseDto CategoryInfo { get; set; } = new OrderAgentQueryDataCategoryInfoResponseDto();

        /// <summary>
        /// 发货状态（10：待发货，20：已发货）
        /// </summary>
        [JsonProperty("expressStatus")]
        public int ExpressStatus { get; set; }
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    public class OrderAgentQueryDataGoodsInfoResponseDto
    {
        /// <summary>
        /// sku主图链接
        /// </summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// g=自营，p=pop
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 自营商品主Id（owner=g取此值）
        /// </summary>
        [JsonProperty("mainSkuId")]
        public long MainSkuId { get; set; }

        /// <summary>
        /// 非自营商品主Id（owner=p取此值）
        /// </summary>
        [JsonProperty("productId")]
        public long ProductId { get; set; }

        /// <summary>
        /// 店铺名称（或供应商名称）
        /// </summary>
        [JsonProperty("shopName")]
        public string ShopName { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        [JsonProperty("shopId")]
        public long ShopId { get; set; }
    }

    /// <summary>
    /// 类目信息
    /// </summary>
    public class OrderAgentQueryDataCategoryInfoResponseDto
    {
        /// <summary>
        /// 一级类目id
        /// </summary>
        [JsonProperty("cid1")]
        public int Cid1 { get; set; }

        /// <summary>
        /// 二级类目id
        /// </summary>
        [JsonProperty("cid2")]
        public int Cid2 { get; set; }

        /// <summary>
        /// 三级类目id
        /// </summary>
        [JsonProperty("cid3")]
        public int Cid3 { get; set; }

        /// <summary>
        /// 一级类目名称
        /// </summary>
        [JsonProperty("cid1Name")]
        public int Cid1Name { get; set; }

        /// <summary>
        /// 二级类目名称
        /// </summary>
        [JsonProperty("cid2Name")]
        public int Cid2Name { get; set; }

        /// <summary>
        ///三级类目名称
        /// </summary>
        [JsonProperty("cid3Name")]
        public int Cid3Name { get; set; }
    }
}
