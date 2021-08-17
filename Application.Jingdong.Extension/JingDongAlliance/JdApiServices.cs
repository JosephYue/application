using Application.Jingdong.Extension.JingDongAlliance.Dto;
using Application.Jingdong.Extension.JingDongAlliance.Interface;
using Application.Jingdong.Extension.JingDongAlliance.Param;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Jingdong.Extension.JingDongAlliance
{
    public partial class JdApiServices : IJdApiServices
    {
        const string jdurl = "https://api.jd.com/routerjson";

        private readonly HttpClient _httpclient;

        public JdApiServices(IHttpClientFactory httpClientFactory)
        {
            _httpclient = httpClientFactory.CreateClient();
        }

        #region 推广物料

        /// <summary>
        /// 京粉精选商品查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public GoodsJingFenQueryResultResponseDto JdUnionOpenGoodsJingfenQuery(string appKey, string appSecrect, GoodsJingFenQueryParam param)
        {
            param.Validate();

            var goodsReq = new
            {
                goodsReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.jingfen.query" },
                {"app_key",appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReq) },
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenGoodsJingFenResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<GoodsJingFenQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 关键词商品查询接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public QueryResultResponseDto JDUnionOpenGoodsQuery(string appKey, string appSecrect, GoodsQueryParam param)
        {
            param.Validate();

            var goodsReqDTO = new
            {
                goodsReqDTO = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReqDTO) },
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenGoodsQueryResponseDto>(resultStr);

                return JsonConvert.DeserializeObject<QueryResultResponseDto>(result.Response is null ? "" : result.Response.QueryResult);

            }
            else
            {
                return new QueryResultResponseDto();
            }
        }

        /// <summary>
        /// 猜你喜欢商品推荐
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public MaterialQueryResultResponseDto JDUnionOpenGoodsMaterialQuery(string appKey, string appSecrect, GoodsMaterialQueryParam param)
        {
            param.Validate();

            var goodsReq = new
            {
                goodsReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.material.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReq) },
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JdUnionOpenGoodsMaterialQueryResponseDto>(resultStr);

                return JsonConvert.DeserializeObject<MaterialQueryResultResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new MaterialQueryResultResponseDto();
            }
        }

        /// <summary>
        /// 根据skuid查询商品信息
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public GoodsPromotionGoodsInfoResponseDto JDUnionOpenGoodsPromotiongoodsinfoQuery(string appKey, string appSecrect, GoodsPromotionGoodsInfoqQueryParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.promotiongoodsinfo.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(param)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionGoodsPromotionGoodsInfoqQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<GoodsPromotionGoodsInfoResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new GoodsPromotionGoodsInfoResponseDto();
            }
        }

        /// <summary>
        /// 商品类目查询
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public JDUnionOpenCategoryGoodsDto JDUnionOpenCategoryGoodsGet(string appKey, string appSecrect, GoodsCategoryQueryParam param)
        {
            param.Validate();

            var req = new
            {
                req = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.category.goods.get" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(req)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenCategoryGoodsGetDto>(resultStr);

                return JsonConvert.DeserializeObject<JDUnionOpenCategoryGoodsDto>(result.Response is null ? "" : result.Response.GetResult);
            }
            else
            {
                return new JDUnionOpenCategoryGoodsDto();
            }
        }

        /// <summary>
        /// 商品详情查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public JDUnionOpenGoodsBigfieldQueryResponseDto JDUnionOpenGoodsBigFieldQuery(string appKey, string appSecrect, GoodsBigfieldQueryParam param)
        {
            param.Validate();

            var goodsReq = new
            {
                goodsReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.bigfield.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReq)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenGoodsBigfieldQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<JDUnionOpenGoodsBigfieldQueryResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new JDUnionOpenGoodsBigfieldQueryResponseDto();
            }
        }

        /// <summary>
        /// 优惠券领取情况查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public JDCouponQueryResponseDto JDUnionOpencouponQuery(string appKey, string appSecrect, GoodsCouponQueryParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.coupon.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(param)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenCouponQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<JDCouponQueryResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new JDCouponQueryResponseDto();
            }
        }

        /// <summary>
        /// 活动查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public ActivityQueryInfoResponseDto JDUnionOpenActivityQuery(string appKey, string appSecrect, GoodsActivityQueryParam param)
        {
            param.Validate();

            var activityReq = new
            {
                activityReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.activity.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(activityReq)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenActivityQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<ActivityQueryInfoResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new ActivityQueryInfoResponseDto();
            }
        }

        /// <summary>
        /// 活动推荐接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public JDUnionOpenActivityRecommendDto JDUnionActivityRecommendQuery(string appKey, string appSecrect, GoodsActivityRecommendParam param)
        {
            param.Validate();

            var req = new
            {
                req = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.activity.recommend.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(req)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenActivityRecommendQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<JDUnionOpenActivityRecommendDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new JDUnionOpenActivityRecommendDto();
            }
        }

        #endregion

        #region 营销工具

        /// <summary>
        /// 礼金创建
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public CouponGiftGetGetResultResponseDto JdUnionOpenCouponGiftGetQuery(string appKey, string appSecrect, CouponGiftGetParam param)
        {
            param.Validate();

            var couponReq = new
            {
                couponReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.coupon.gift.get" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(couponReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenCouponGiftGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<CouponGiftGetGetResultResponseDto>(result.Response.GetResult);
        }

        /// <summary>
        /// 礼金停止
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public CouponGiftStopStopResultResponseDto JdUnionOpenCouponGiftStopQuery(string appKey, string appSecrect, CouponGiftStopParam param)
        {
            param.Validate();

            var couponReq = new
            {
                couponReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.coupon.gift.stop" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(couponReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenCouponGiftStopResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<CouponGiftStopStopResultResponseDto>(result.Response.StopResult);
        }

        /// <summary>
        /// 礼金效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public StatisticsGiftCouponQueryQueryResultResponseDto JdUnionOpenStatisticsGiftCouponQuery(string appKey, string appSecrect, StatisticsGiftCouponQueryParam param)
        {
            param.Validate();

            var effectDataReq = new
            {
                effectDataReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.statistics.giftcoupon.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(effectDataReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenStatisticsGiftCouponQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<StatisticsGiftCouponQueryQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 京东注册用户判定接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public ValidateResultResponseDto JdUnionOpenUserRegisterValidateQuery(string appKey, string appSecrect, UserRegisterValidateParam param)
        {
            param.Validate();

            var userStateReq = new
            {
                userStateReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.user.register.validate" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(userStateReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenUserRegisterValidateResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<ValidateResultResponseDto>(result.Response.ValidateResult);
        }

        #endregion

        #region 管理工具

        /// <summary>
        /// 创建推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public PositionCreateCreateResultResponseDto JdUnionOpenPositionCreateQuery(string appKey, string appSecrect, PositionCreateParam param)
        {
            param.Validate();

            var positionReq = new
            {
                positionReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.position.create" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(positionReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPositionCreateResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<PositionCreateCreateResultResponseDto>(result.Response.CreateResult);
        }

        /// <summary>
        /// 查询推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public PositionQueryQueryResultResponseDto JdUnionOpenPositionQuery(string appKey, string appSecrect, PositionQueryParam param)
        {
            param.Validate();

            var positionReq = new
            {
                positionReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.position.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(positionReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPositionQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<PositionQueryQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 获取PId(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public UserPIdGetGetResultResponseDto JdUnionOpenUserPIdGetQuery(string appKey, string appSecrect, UserPIdGetParam param)
        {
            param.Validate();

            var positionReq = new
            {
                positionReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.user.pid.get" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(positionReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenUserPIdGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<UserPIdGetGetResultResponseDto>(result.Response.GetResult);
        }

        #endregion

        #region 推广效果

        /// <summary>
        /// 订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public OrderRowQueryqueryResultResponseDto JdUnionOpenOrderRowQuery(string appKey, string appSecrect, OrderRowQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.row.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenJDUnionOpenOrderRowQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<OrderRowQueryqueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 奖励订单查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public OrderBonusQueryQueryResultResponseDto JdUnionOpenOrderBonusQuery(string appKey, string appSecrect, OrderBonusQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.bonus.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenOrderBonusQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<OrderBonusQueryQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 京享红包效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public StatisticsRedpacketQueryResultResponseDto JdUnionOpenStatisticsRedpacketQuery(string appKey, string appSecrect, StatisticsRedpacketQueryParam param)
        {
            param.Validate();

            var effectDataReq = new
            {
                effectDataReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.statistics.redpacket.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(effectDataReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenStatisticsRedpacketQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<StatisticsRedpacketQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 工具商订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public OrderAgentQueryResultResponseDto JdUnionOpenOrderAgentQuery(string appKey, string appSecrect, OrderAgentQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.agent.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenOrderAgentQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<OrderAgentQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 工具商京享红包效果数据(注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public StatisticsRedpacketAgentQueryResultResponseDto JdUnionOpenStatisticsRedpacketAgentQuery(string appKey, string appSecrect, StatisticsRedpacketAgentQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.statistics.redpacket.agent.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenStatisticsRedpacketAgentQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<StatisticsRedpacketAgentQueryResultResponseDto>(result.Response.QueryResult);
        }

        #region 未测试通过，先注释

        ///// <summary>
        ///// 奖励活动信息查询接口(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //public ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto> JdUnionOpenActivityBonusQuery(string appKey, string appSecrect, ActivityBonusQueryParam param)
        //{
        //    param.Validate();

        //    var req = new
        //    {
        //        req = param
        //    };

        //    IDictionary<string, string> dic = new Dictionary<string, string>
        //    {
        //        {"method","jd.union.open.activity.bonus.query" },
        //        {"app_key",appKey },
        //        {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
        //        { "format","json"},
        //        {"v","1.0" },
        //        {"sign_method","md5" },
        //        {"360buy_param_json",JsonConvert.SerializeObject(req) }
        //    };

        //    dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

        //    var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

        //    return JsonConvert.DeserializeObject<ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto>>(resultStr);
        //}

        ///// <summary>
        ///// 奖励活动奖励金额查询(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //public ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto> JdUnionOpenStatisticsActivityBonusQuery(string appKey, string appSecrect, StatisticsActivityBonusQueryParam param)
        //{
        //    param.Validate();

        //    var req = new
        //    {
        //        req = param
        //    };

        //    IDictionary<string, string> dic = new Dictionary<string, string>
        //    {
        //        {"method","jd.union.open.statistics.activity.bonus.query" },
        //        {"app_key",appKey },
        //        {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
        //        { "format","json"},
        //        {"v","1.0" },
        //        {"sign_method","md5" },
        //        {"360buy_param_json",JsonConvert.SerializeObject(req) }
        //    };

        //    dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

        //    var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

        //    return JsonConvert.DeserializeObject<ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto>>(resultStr);
        //} 

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
        public JDUnionOpenPromotionCommonGetGetResultResponseDto JdUnionOpenPromotionCommonGetQuery(string appKey, string appSecrect, PromotionCommonGetParam param)
        {
            param.Validate();

            var promotionCodeReq = new
            {
                promotionCodeReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.promotion.common.get" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(promotionCodeReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPromotionCommonGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<JDUnionOpenPromotionCommonGetGetResultResponseDto>(result.Response.GetResult);
        }

        /// <summary>
        /// 社交媒体获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto JdUnionOpenPromotionBySubUnionidGetQuery(string appKey, string appSecrect, PromotionBySubUnionidGetParam param)
        {
            param.Validate();

            var promotionCodeReq = new
            {
                promotionCodeReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.promotion.bysubunionid.get" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(promotionCodeReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPromotionBySubUnionidGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto>(result.Response.GetResult);
        }

        /// <summary>
        /// 工具商获取推广链接接口(注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public JDUnionOpenPromotionByUnionidGetGetResultResponseDto JdUnionOpenPromotionByUnionidGetQuery(string appKey, string appSecrect, PromotionByUnionidGetParam param)
        {
            param.Validate();

            var promotionCodeReq = new
            {
                promotionCodeReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.promotion.byunionid.get" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(promotionCodeReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPromotionByUnionidGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<JDUnionOpenPromotionByUnionidGetGetResultResponseDto>(result.Response.GetResult);
        }

        #endregion
    }

    public partial class JdApiServices
    {
        #region 推广物料

        /// <summary>
        /// 京粉精选商品查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<GoodsJingFenQueryResultResponseDto> JdUnionOpenGoodsJingfenQueryAsync(string appKey, string appSecrect, GoodsJingFenQueryParam param)
        {
            param.Validate();

            var goodsReq = new
            {
                goodsReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.order.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReq) },
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenGoodsJingFenResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<GoodsJingFenQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 关键词商品查询接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<QueryResultResponseDto> JDUnionOpenGoodsQueryAsync(string appKey, string appSecrect, GoodsQueryParam param)
        {
            param.Validate();

            var goodsReqDTO = new
            {
                goodsReqDTO = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReqDTO) },
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenGoodsQueryResponseDto>(resultStr);

                return JsonConvert.DeserializeObject<QueryResultResponseDto>(result.Response is null ? "" : result.Response.QueryResult);

            }
            else
            {
                return new QueryResultResponseDto();
            }
        }

        /// <summary>
        /// 猜你喜欢商品推荐
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<MaterialQueryResultResponseDto> JDUnionOpenGoodsMaterialQueryAsync(string appKey, string appSecrect, GoodsMaterialQueryParam param)
        {
            param.Validate();

            var goodsReq = new
            {
                goodsReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.material.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReq) },
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JdUnionOpenGoodsMaterialQueryResponseDto>(resultStr);

                return JsonConvert.DeserializeObject<MaterialQueryResultResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new MaterialQueryResultResponseDto();
            }
        }

        /// <summary>
        /// 根据skuid查询商品信息
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<GoodsPromotionGoodsInfoResponseDto> JDUnionOpenGoodsPromotiongoodsinfoQueryAsync(string appKey, string appSecrect, GoodsPromotionGoodsInfoqQueryParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.promotiongoodsinfo.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(param)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionGoodsPromotionGoodsInfoqQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<GoodsPromotionGoodsInfoResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new GoodsPromotionGoodsInfoResponseDto();
            }
        }

        /// <summary>
        /// 商品类目查询
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenCategoryGoodsDto> JDUnionOpenCategoryGoodsGetAsync(string appKey, string appSecrect, GoodsCategoryQueryParam param)
        {
            param.Validate();

            var req = new
            {
                req = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.category.goods.get" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(req)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenCategoryGoodsGetDto>(resultStr);

                return JsonConvert.DeserializeObject<JDUnionOpenCategoryGoodsDto>(result.Response is null ? "" : result.Response.GetResult);
            }
            else
            {
                return new JDUnionOpenCategoryGoodsDto();
            }
        }

        /// <summary>
        /// 商品详情查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenGoodsBigfieldQueryResponseDto> JDUnionOpenGoodsBigFieldQueryAsnyc(string appKey, string appSecrect, GoodsBigfieldQueryParam param)
        {
            param.Validate();

            var goodsReq = new
            {
                goodsReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.goods.bigfield.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(goodsReq)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenGoodsBigfieldQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<JDUnionOpenGoodsBigfieldQueryResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new JDUnionOpenGoodsBigfieldQueryResponseDto();
            }
        }

        /// <summary>
        /// 优惠券领取情况查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDCouponQueryResponseDto> JDUnionOpencouponQueryAsync(string appKey, string appSecrect, GoodsCouponQueryParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.coupon.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(param.CouponUrls)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenCouponQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<JDCouponQueryResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new JDCouponQueryResponseDto();
            }
        }

        /// <summary>
        /// 活动查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<ActivityQueryInfoResponseDto> JDUnionOpenActivityQueryAsync(string appKey, string appSecrect, GoodsActivityQueryParam param)
        {
            param.Validate();

            var activityReq = new
            {
                activityReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.activity.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(activityReq)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenActivityQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<ActivityQueryInfoResponseDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new ActivityQueryInfoResponseDto();
            }
        }

        /// <summary>
        /// 活动推荐接口【申请】
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenActivityRecommendDto> JDUnionActivityRecommendQueryAsync(string appKey, string appSecrect, GoodsActivityRecommendParam param)
        {
            param.Validate();

            var req = new
            {
                req = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.union.open.activity.recommend.query" },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "v","1.0"},
                { "sign_method","md5" },
                { "360buy_param_json", JsonConvert.SerializeObject(req)},
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                var result = JsonConvert.DeserializeObject<JDUnionOpenActivityRecommendQueryDto>(resultStr);

                return JsonConvert.DeserializeObject<JDUnionOpenActivityRecommendDto>(result.Response is null ? "" : result.Response.QueryResult);
            }
            else
            {
                return new JDUnionOpenActivityRecommendDto();
            }
        }

        #endregion

        #region 营销工具

        /// <summary>
        /// 礼金创建
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenCouponGiftGetResponseDto> JdUnionOpenCouponGiftGetQueryAsync(string appKey, string appSecrect, CouponGiftGetParam param)
        {
            param.Validate();

            var couponReq = new
            {
                couponReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(couponReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            return JsonConvert.DeserializeObject<JDUnionOpenCouponGiftGetResponseDto>(resultStr);
        }

        /// <summary>
        /// 礼金停止
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenCouponGiftStopResponseDto> JdUnionOpenCouponGiftStopQueryAsync(string appKey, string appSecrect, CouponGiftStopParam param)
        {
            param.Validate();

            var couponReq = new
            {
                couponReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(couponReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            return JsonConvert.DeserializeObject<JDUnionOpenCouponGiftStopResponseDto>(resultStr);
        }

        /// <summary>
        /// 礼金效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenStatisticsGiftCouponQueryResponseDto> JdUnionOpenStatisticsGiftCouponQueryAsync(string appKey, string appSecrect, StatisticsGiftCouponQueryParam param)
        {
            param.Validate();

            var effectDataReq = new
            {
                effectDataReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(effectDataReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            return JsonConvert.DeserializeObject<JDUnionOpenStatisticsGiftCouponQueryResponseDto>(resultStr);
        }

        /// <summary>
        /// 京东注册用户判定接口(注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<ValidateResultResponseDto> JdUnionOpenUserRegisterValidateQueryAsync(string appKey, string appSecrect, UserRegisterValidateParam param)
        {
            param.Validate();

            var userStateReq = new
            {
                userStateReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(userStateReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenUserRegisterValidateResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<ValidateResultResponseDto>(result.Response.ValidateResult);
        }

        #endregion

        #region 管理工具

        /// <summary>
        /// 创建推广位(申请)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<PositionCreateCreateResultResponseDto> JdUnionOpenPositionCreateQueryAsync(string appKey, string appSecrect, PositionCreateParam param)
        {
            param.Validate();

            var positionReq = new
            {
                positionReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(positionReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPositionCreateResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<PositionCreateCreateResultResponseDto>(result.Response.CreateResult);
        }

        /// <summary>
        /// 查询推广位(申请 注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<PositionQueryQueryResultResponseDto> JdUnionOpenPositionQueryAsync(string appKey, string appSecrect, PositionQueryParam param)
        {
            param.Validate();

            var positionReq = new
            {
                positionReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(positionReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPositionQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<PositionQueryQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 获取PId(申请 注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<UserPIdGetGetResultResponseDto> JdUnionOpenUserPIdGetQueryAsync(string appKey, string appSecrect, UserPIdGetParam param)
        {
            param.Validate();

            var positionReq = new
            {
                positionReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(positionReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenUserPIdGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<UserPIdGetGetResultResponseDto>(result.Response.GetResult);
        }

        #endregion

        #region 推广效果

        /// <summary>
        /// 订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<OrderRowQueryqueryResultResponseDto> JdUnionOpenOrderRowQueryAsync(string appKey, string appSecrect, OrderRowQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenJDUnionOpenOrderRowQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<OrderRowQueryqueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 奖励订单查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<OrderBonusQueryQueryResultResponseDto> JdUnionOpenOrderBonusQueryAsync(string appKey, string appSecrect, OrderBonusQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenOrderBonusQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<OrderBonusQueryQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 京享红包效果数据
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<StatisticsRedpacketQueryResultResponseDto> JdUnionOpenStatisticsRedpacketQueryAsync(string appKey, string appSecrect, StatisticsRedpacketQueryParam param)
        {
            param.Validate();

            var effectDataReq = new
            {
                effectDataReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(effectDataReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenStatisticsRedpacketQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<StatisticsRedpacketQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 工具商订单行查询接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<OrderAgentQueryResultResponseDto> JdUnionOpenOrderAgentQueryAsync(string appKey, string appSecrect, OrderAgentQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenOrderAgentQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<OrderAgentQueryResultResponseDto>(result.Response.QueryResult);
        }

        /// <summary>
        /// 工具商京享红包效果数据(注：未测试通过)
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<StatisticsRedpacketAgentQueryResultResponseDto> JdUnionOpenStatisticsRedpacketAgentQueryAsync(string appKey, string appSecrect, StatisticsRedpacketAgentQueryParam param)
        {
            param.Validate();

            var orderReq = new
            {
                orderReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(orderReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenStatisticsRedpacketAgentQueryResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<StatisticsRedpacketAgentQueryResultResponseDto>(result.Response.QueryResult);
        }

        #region 未测试通过，先注释

        ///// <summary>
        ///// 奖励活动信息查询接口(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //public async Task<ResponseBaseDto<JDUnionOpenActivityBonusQueryResponseDto>> JdUnionOpenActivityBonusQueryAsync(string appKey, string appSecrect, ActivityBonusQueryParam param)
        //{
        //    param.Validate();

        //    var req = new
        //    {
        //        req = param
        //    };

        //    IDictionary<string, string> dic = new Dictionary<string, string>
        //    {
        //        {"method","jd.union.open.order.query" },
        //        {"app_key",appKey },
        //        {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
        //        { "format","json"},
        //        {"v","1.0" },
        //        {"sign_method","md5" },
        //        {"360buy_param_json",JsonConvert.SerializeObject(req) }
        //    };

        //    dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

        //    var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

        //    return JsonConvert.DeserializeObject<ResponseBaseDto<JDUnionOpenActivityBonusQueryResponseDto>>(resultStr);
        //}

        ///// <summary>
        ///// 奖励活动奖励金额查询(注：未测试通过)
        ///// </summary>
        ///// <param name="appKey">应用标识</param>
        ///// <param name="appSecrect">应用密钥</param>
        ///// <param name="param">参数信息</param>
        ///// <returns></returns>
        //public async Task<ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto>> JdUnionOpenAtatisticsActivityBonusQueryAsync(string appKey, string appSecrect, StatisticsActivityBonusQueryParam param)
        //{
        //    param.Validate();

        //    var req = new
        //    {
        //        req = param
        //    };

        //    IDictionary<string, string> dic = new Dictionary<string, string>
        //    {
        //        {"method","jd.union.open.order.query" },
        //        {"app_key",appKey },
        //        {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
        //        { "format","json"},
        //        {"v","1.0" },
        //        {"sign_method","md5" },
        //        {"360buy_param_json",JsonConvert.SerializeObject(req) }
        //    };

        //    dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

        //    var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

        //    return JsonConvert.DeserializeObject<ResponseBaseDto<JDUnionOpenStatisticsActivityBonusQueryResponseDto>>(resultStr);
        //} 

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
        public async Task<JDUnionOpenPromotionCommonGetGetResultResponseDto> JdUnionOpenPromotionCommonGetQueryAsync(string appKey, string appSecrect, PromotionCommonGetParam param)
        {
            param.Validate();

            var promotionCodeReq = new
            {
                promotionCodeReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(promotionCodeReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPromotionCommonGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<JDUnionOpenPromotionCommonGetGetResultResponseDto>(result.Response.GetResult);
        }

        /// <summary>
        /// 社交媒体获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto> JdUnionOpenPromotionBySubUnionidGetQueryAsync(string appKey, string appSecrect, PromotionBySubUnionidGetParam param)
        {
            param.Validate();

            var promotionCodeReq = new
            {
                promotionCodeReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(promotionCodeReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPromotionBySubUnionidGetResponseDto>(resultStr);

            return JsonConvert.DeserializeObject<JDUnionOpenPromotionBySubUnionidGetGetResultResponseDto>(result.Response.GetResult);
        }

        /// <summary>
        /// 工具商获取推广链接接口
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<JDUnionOpenPromotionByUnionidGetGetResultResponseDto> JdUnionOpenPromotionByUnionidGetQueryAsync(string appKey, string appSecrect, PromotionByUnionidGetParam param)
        {
            param.Validate();

            var promotionCodeReq = new
            {
                promotionCodeReq = param
            };

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"method","jd.union.open.order.query" },
                {"app_key",appKey },
                {"timestamp" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "format","json"},
                {"v","1.0" },
                {"sign_method","md5" },
                {"360buy_param_json",JsonConvert.SerializeObject(promotionCodeReq) }
            };

            dic.Add("sign", Utils.GetJingDongAllianceSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, jdurl, dic);

            var result = JsonConvert.DeserializeObject<JDUnionOpenPromotionByUnionidGetResponseDto>(resultStr);
            return JsonConvert.DeserializeObject<JDUnionOpenPromotionByUnionidGetGetResultResponseDto>(result.Response.GetResult);
        }

        #endregion
    }
}

