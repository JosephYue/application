using Application.Jingdong.Extension.JingDongAlliance.Dto;
using Application.Jingdong.Extension.JingDongAlliance.Param;
using System.Threading.Tasks;

namespace Application.Jingdong.Extension.JingDongAlliance.Interface
{
    /// <summary>
    /// 京东联盟接口
    /// </summary>
    public partial interface IJdApiServices
    {
        #region 推广物料

        /// <summary>
        /// 京粉精选商品查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        GoodsJingFenQueryResultResponseDto JdUnionOpenGoodsJingfenQuery(string appKey, string appSecrect, GoodsJingFenQueryParam param);

        /// <summary>
        /// 关键词商品查询接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        QueryResultResponseDto JDUnionOpenGoodsQuery(string appKey, string appSecrect, GoodsQueryParam param);

        /// <summary>
        /// 猜你喜欢商品推荐
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        MaterialQueryResultResponseDto JDUnionOpenGoodsMaterialQuery(string appKey, string appSecrect, GoodsMaterialQueryParam param);

        /// <summary>
        /// 根据skuid查询商品信息
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        GoodsPromotionGoodsInfoResponseDto JDUnionOpenGoodsPromotiongoodsinfoQuery(string appKey, string appSecrect, GoodsPromotionGoodsInfoqQueryParam param);

        /// <summary>
        /// 商品类目查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDUnionOpenCategoryGoodsDto JDUnionOpenCategoryGoodsGet(string appKey, string appSecrect, GoodsCategoryQueryParam param);

        /// <summary>
        /// 商品详情查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDUnionOpenGoodsBigfieldQueryResponseDto JDUnionOpenGoodsBigFieldQuery(string appKey, string appSecrect, GoodsBigfieldQueryParam param);

        /// <summary>
        /// 优惠券领取情况查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDCouponQueryResponseDto JDUnionOpencouponQuery(string appKey, string appSecrect, GoodsCouponQueryParam param);

        /// <summary>
        /// 活动查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        ActivityQueryInfoResponseDto JDUnionOpenActivityQuery(string appKey, string appSecrect, GoodsActivityQueryParam param);

        /// <summary>
        /// 活动推荐接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDUnionOpenActivityRecommendDto JDUnionActivityRecommendQuery(string appKey, string appSecrect, GoodsActivityRecommendParam param);

        #endregion

        #region 营销工具

        /// <summary>
        /// 礼金创建
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        CouponGiftGetGetResultResponseDto JdUnionOpenCouponGiftGetQuery(string appKey, string appSecrect, CouponGiftGetParam param);

        /// <summary>
        /// 礼金停止
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        CouponGiftStopStopResultResponseDto JdUnionOpenCouponGiftStopQuery(string appKey, string appSecrect, CouponGiftStopParam param);

        /// <summary>
        /// 礼金效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        StatisticsGiftCouponQueryQueryResultResponseDto JdUnionOpenStatisticsGiftCouponQuery(string appKey, string appSecrect, StatisticsGiftCouponQueryParam param);

        /// <summary>
        /// 京东注册用户判定接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        ValidateResultResponseDto JdUnionOpenUserRegisterValidateQuery(string appKey, string appSecrect, UserRegisterValidateParam param);

        #endregion

        #region 管理工具

        /// <summary>
        /// 创建推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        PositionCreateCreateResultResponseDto JdUnionOpenPositionCreateQuery(string appKey, string appSecrect, PositionCreateParam param);

        /// <summary>
        /// 查询推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        PositionQueryQueryResultResponseDto JdUnionOpenPositionQuery(string appKey, string appSecrect, PositionQueryParam param);

        /// <summary>
        /// 获取PId(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        UserPIdGetGetResultResponseDto JdUnionOpenUserPIdGetQuery(string appKey, string appSecrect, UserPIdGetParam param);

        #endregion

        #region 推广效果

        /// <summary>
        /// 订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        OrderRowQueryqueryResultResponseDto JdUnionOpenOrderRowQuery(string appKey, string appSecrect, OrderRowQueryParam param);

        /// <summary>
        /// 奖励订单查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        OrderBonusQueryQueryResultResponseDto JdUnionOpenOrderBonusQuery(string appKey, string appSecrect, OrderBonusQueryParam param);

        /// <summary>
        /// 京享红包效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        StatisticsRedpacketQueryResultResponseDto JdUnionOpenStatisticsRedpacketQuery(string appKey, string appSecrect, StatisticsRedpacketQueryParam param);

        /// <summary>
        /// 工具商订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        OrderAgentQueryResultResponseDto JdUnionOpenOrderAgentQuery(string appKey, string appSecrect, OrderAgentQueryParam param);

        /// <summary>
        /// 工具商京享红包效果数据(注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        StatisticsRedpacketAgentQueryResultResponseDto JdUnionOpenStatisticsRedpacketAgentQuery(string appKey, string appSecrect, StatisticsRedpacketAgentQueryParam param);

        #region 未通过测试，先注释

        ///// <summary>
        ///// 奖励活动信息查询接口(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto> JdUnionOpenActivityBonusQuery(string appKey, string appSecrect, ActivityBonusQueryParam param);

        ///// <summary>
        ///// 奖励活动奖励金额查询(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto> JdUnionOpenStatisticsActivityBonusQuery(string appKey, string appSecrect, StatisticsActivityBonusQueryParam param); 

        #endregion

        #endregion

        #region 转链能力

        /// <summary>
        /// 网站/APP获取推广链接
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDUnionOpenPromotionCommonGetGetResultResponseDto JdUnionOpenPromotionCommonGetQuery(string appKey, string appSecrect, PromotionCommonGetParam param);

        /// <summary>
        /// 社交媒体获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto JdUnionOpenPromotionBySubUnionidGetQuery(string appKey, string appSecrect, PromotionBySubUnionidGetParam param);

        /// <summary>
        /// 工具商获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        JDUnionOpenPromotionByUnionidGetGetResultResponseDto JdUnionOpenPromotionByUnionidGetQuery(string appKey, string appSecrect, PromotionByUnionidGetParam param);

        #endregion
    }

    /// <summary>
    /// 京东联盟接口
    /// </summary>
    public partial interface IJdApiServices
    {
        #region 推广物料

        /// <summary>
        /// 京粉精选商品查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<GoodsJingFenQueryResultResponseDto> JdUnionOpenGoodsJingfenQueryAsync(string appKey, string appSecrect, GoodsJingFenQueryParam param);

        /// <summary>
        /// 关键词商品查询接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<QueryResultResponseDto> JDUnionOpenGoodsQueryAsync(string appKey, string appSecrect, GoodsQueryParam param);

        /// <summary>
        /// 猜你喜欢商品推荐
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<MaterialQueryResultResponseDto> JDUnionOpenGoodsMaterialQueryAsync(string appKey, string appSecrect, GoodsMaterialQueryParam param);

        /// <summary>
        /// 根据skuid查询商品信息
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<GoodsPromotionGoodsInfoResponseDto> JDUnionOpenGoodsPromotiongoodsinfoQueryAsync(string appKey, string appSecrect, GoodsPromotionGoodsInfoqQueryParam param);

        /// <summary>
        /// 商品类目查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenCategoryGoodsDto> JDUnionOpenCategoryGoodsGetAsync(string appKey, string appSecrect, GoodsCategoryQueryParam param);

        /// <summary>
        /// 商品详情查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenGoodsBigfieldQueryResponseDto> JDUnionOpenGoodsBigFieldQueryAsnyc(string appKey, string appSecrect, GoodsBigfieldQueryParam param);

        /// <summary>
        /// 优惠券领取情况查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDCouponQueryResponseDto> JDUnionOpencouponQueryAsync(string appKey, string appSecrect, GoodsCouponQueryParam param);

        /// <summary>
        /// 活动查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<ActivityQueryInfoResponseDto> JDUnionOpenActivityQueryAsync(string appKey, string appSecrect, GoodsActivityQueryParam param);

        /// <summary>
        /// 活动推荐接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenActivityRecommendDto> JDUnionActivityRecommendQueryAsync(string appKey, string appSecrect, GoodsActivityRecommendParam param);

        #endregion

        #region 营销工具

        /// <summary>
        /// 礼金创建
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenCouponGiftGetResponseDto> JdUnionOpenCouponGiftGetQueryAsync(string appKey, string appSecrect, CouponGiftGetParam param);

        /// <summary>
        /// 礼金停止
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenCouponGiftStopResponseDto> JdUnionOpenCouponGiftStopQueryAsync(string appKey, string appSecrect, CouponGiftStopParam param);

        /// <summary>
        /// 礼金效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenStatisticsGiftCouponQueryResponseDto> JdUnionOpenStatisticsGiftCouponQueryAsync(string appKey, string appSecrect, StatisticsGiftCouponQueryParam param);

        /// <summary>
        /// 京东注册用户判定接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<ValidateResultResponseDto> JdUnionOpenUserRegisterValidateQueryAsync(string appKey, string appSecrect, UserRegisterValidateParam param);

        #endregion

        #region 管理工具

        /// <summary>
        /// 创建推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<PositionCreateCreateResultResponseDto> JdUnionOpenPositionCreateQueryAsync(string appKey, string appSecrect, PositionCreateParam param);

        /// <summary>
        /// 查询推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<PositionQueryQueryResultResponseDto> JdUnionOpenPositionQueryAsync(string appKey, string appSecrect, PositionQueryParam param);

        /// <summary>
        /// 获取PId(申请 注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<UserPIdGetGetResultResponseDto> JdUnionOpenUserPIdGetQueryAsync(string appKey, string appSecrect, UserPIdGetParam param);

        #endregion

        #region 推广效果

        /// <summary>
        /// 订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<OrderRowQueryqueryResultResponseDto> JdUnionOpenOrderRowQueryAsync(string appKey, string appSecrect, OrderRowQueryParam param);

        /// <summary>
        /// 奖励订单查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<OrderBonusQueryQueryResultResponseDto> JdUnionOpenOrderBonusQueryAsync(string appKey, string appSecrect, OrderBonusQueryParam param);

        /// <summary>
        /// 京享红包效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<StatisticsRedpacketQueryResultResponseDto> JdUnionOpenStatisticsRedpacketQueryAsync(string appKey, string appSecrect, StatisticsRedpacketQueryParam param);

        /// <summary>
        /// 工具商订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<OrderAgentQueryResultResponseDto> JdUnionOpenOrderAgentQueryAsync(string appKey, string appSecrect, OrderAgentQueryParam param);

        /// <summary>
        /// 工具商京享红包效果数据(注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<StatisticsRedpacketAgentQueryResultResponseDto> JdUnionOpenStatisticsRedpacketAgentQueryAsync(string appKey, string appSecrect, StatisticsRedpacketAgentQueryParam param);

        #region 未通过测试，先注释

        ///// <summary>
        ///// 奖励活动信息查询接口(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //Task<ResponseBaseDto<JDUnionOpenActivityBonusQueryResponseDto>> JdUnionOpenActivityBonusQueryAsync(string appKey, string appSecrect, ActivityBonusQueryParam param);

        ///// <summary>
        ///// 奖励活动奖励金额查询(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //Task<ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto>> JdUnionOpenAtatisticsActivityBonusQueryAsync(string appKey, string appSecrect, StatisticsActivityBonusQueryParam param); 

        #endregion

        #endregion

        #region 转链能力

        /// <summary>
        /// 网站/APP获取推广链接
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenPromotionCommonGetGetResultResponseDto> JdUnionOpenPromotionCommonGetQueryAsync(string appKey, string appSecrect, PromotionCommonGetParam param);

        /// <summary>
        /// 社交媒体获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto> JdUnionOpenPromotionBySubUnionidGetQueryAsync(string appKey, string appSecrect, PromotionBySubUnionidGetParam param);

        /// <summary>
        /// 工具商获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<JDUnionOpenPromotionByUnionidGetGetResultResponseDto> JdUnionOpenPromotionByUnionidGetQueryAsync(string appKey, string appSecrect, PromotionByUnionidGetParam param);

        #endregion
    }
}
