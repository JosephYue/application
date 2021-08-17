using Application.Jingdong.Extension.JingDongKepler.Dto;
using Application.Jingdong.Extension.JingDongKepler.Interface;
using Application.Jingdong.Extension.JingDongKepler.Param;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Jingdong.Extension.JingDongKepler
{
    public partial class KeplerServices : IKeplerServices
    {
        const string kplurl = "https://api.jd.com/routerjson";
        private readonly HttpClient _httpclient;

        public KeplerServices(IHttpClientFactory httpClientFactory)
        {
            _httpclient = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// 通过code获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="code">GetAuth中获取的code</param>
        /// <param name="grantType">固定为authorization_code</param>
        /// <returns></returns>
        public GetAccessTokenResultDto GetAccessToken(string appKey, string appSecret, string code, string grantType = "authorization_code")
        {
            var jsonStr = Utils.Get(_httpclient, $"https://open-oauth.jd.com/oauth2/access_token?app_key={appKey}&app_secret={appSecret}&grant_type={grantType}&code={code}");

            return JsonConvert.DeserializeObject<GetAccessTokenResultDto>(jsonStr);
        }

        /// <summary>
        /// 通过refreshtoken获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="refreshToken">通过code获取accesstoken中返回的refreshToken</param>
        /// <param name="grantType">固定为refresh_token</param>
        /// <returns></returns>
        public GetAccessTokenResultDto GetAccessTokenByRefreshToken(string appKey, string appSecret, string refreshToken, string grantType = "refresh_token")
        {
            var jsonStr = Utils.Get(_httpclient, $"https://open-oauth.jd.com/oauth2/refresh_token?app_key={appKey}&app_secret={appSecret}&grant_type={grantType}&refresh_token={refreshToken}");

            return JsonConvert.DeserializeObject<GetAccessTokenResultDto>(jsonStr);
        }

        /// <summary>
        /// 获取授权
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="redirectUri">回调地址，请填写默认地址即可：http://kepler.jd.com/oauth/code.do</param>
        /// <returns></returns>
        public string GetAuth(string appKey, string redirectUri = "http://kepler.jd.com/oauth/code.do")
        {
            return $"https://open-oauth.jd.com/oauth2/to_login?app_key={appKey}&response_type=code&redirect_uri={redirectUri}&state=20180416&scope=snsapi_base";
        }

        /// <summary>
        /// 券品二合一推广转换接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public ConvertUrlResultDto JdKplOpenPromotionConvertUrl(string appKey, string appSecrect, string accessToken, ConvertUrlParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.kpl.open.promotion.converturl" },
                { "access_token", accessToken },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "360buy_param_json", JsonConvert.SerializeObject(param) },
                { "v","1.0"}
            };

            dic.Add("sign", Utils.GetJingDongKeplerSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, kplurl, dic);

            return JsonConvert.DeserializeObject<ConvertUrlResultDto>(resultStr);
        }

        /// <summary>
        /// 开普勒推广链接转换接口（开普勒营销能力API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public PidUrlConvertResultDto JdKplOpenPromotionPidUrlConvert(string appKey, string appSecrect, string accessToken, PidUrlConvertParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.kpl.open.promotion.pidurlconvert" },
                { "access_token", accessToken },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "360buy_param_json", JsonConvert.SerializeObject(param) },
                { "v","2.0"}
            };

            dic.Add("sign", Utils.GetJingDongKeplerSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, kplurl, dic);

            return JsonConvert.DeserializeObject<PidUrlConvertResultDto>(resultStr);
        }

        /// <summary>
        /// 开普勒订单详情接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public OrderGetListResultDto JdKeplerOrderGetList(string appKey, string appSecrect, string accessToken, QueryOrderParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.kepler.order.getlist" },
                { "access_token", accessToken },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "360buy_param_json", JsonConvert.SerializeObject(param) },
                { "v","1.0"}
            };

            dic.Add("sign", Utils.GetJingDongKeplerSign(dic, appSecrect));

            var resultStr = Utils.DoPost(_httpclient, kplurl, dic);

            return JsonConvert.DeserializeObject<OrderGetListResultDto>(resultStr);
        }
    }

    public partial class KeplerServices
    {
        /// <summary>
        /// 通过code获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="code">GetAuth中获取的code</param>
        /// <param name="grantType">固定为authorization_code</param>
        /// <returns></returns>
        public async Task<GetAccessTokenResultDto> GetAccessTokenAsync(string appKey, string appSecret, string code, string grantType = "authorization_code")
        {
            var jsonStr = await Utils.GetAsync(_httpclient, $"https://open-oauth.jd.com/oauth2/access_token?app_key={appKey}&app_secret={appSecret}&grant_type={grantType}&code={code}");

            return JsonConvert.DeserializeObject<GetAccessTokenResultDto>(jsonStr);
        }

        /// <summary>
        /// 获取授权
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="redirectUri">回调地址，请填写默认地址即可：http://kepler.jd.com/oauth/code.do</param>
        /// <returns></returns>
        public Task<string> GetAuthAsync(string appKey, string redirectUri = "http://kepler.jd.com/oauth/code.do")
        {
            return Task.Run(() =>
            {
                return $"https://open-oauth.jd.com/oauth2/to_login?app_key={appKey}&response_type=code&redirect_uri={redirectUri}&state=20180416&scope=snsapi_base";
            });
        }

        /// <summary>
        /// 通过refreshtoken获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="refreshToken">通过code获取accesstoken中返回的refreshToken</param>
        /// <param name="grantType">固定为refresh_token</param>
        /// <returns></returns>
        public async Task<GetAccessTokenResultDto> GetAccessTokenByRefreshTokenAsync(string appKey, string appSecret, string refreshToken, string grantType = "refresh_token")
        {
            var jsonStr = await Utils.GetAsync(_httpclient, $"https://open-oauth.jd.com/oauth2/refresh_token?app_key={appKey}&app_secret={appSecret}&grant_type={grantType}&refresh_token={refreshToken}");

            return JsonConvert.DeserializeObject<GetAccessTokenResultDto>(jsonStr);
        }

        /// <summary>
        /// 券品二合一推广转换接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<ConvertUrlResultDto> JdKplOpenPromotionConvertUrlAsync(string appKey, string appSecrect, string accessToken, ConvertUrlParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.kpl.open.promotion.converturl" },
                { "access_token", accessToken },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "360buy_param_json", JsonConvert.SerializeObject(param) },
                { "v","1.0"}
            };

            dic.Add("sign", Utils.GetJingDongKeplerSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, kplurl, dic);

            return JsonConvert.DeserializeObject<ConvertUrlResultDto>(resultStr);
        }

        /// <summary>
        /// 开普勒推广链接转换接口（开普勒营销能力API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<PidUrlConvertResultDto> JdKplOpenPromotionPidUrlConvertAsync(string appKey, string appSecrect, string accessToken, PidUrlConvertParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.kpl.open.promotion.pidurlconvert" },
                { "access_token", accessToken },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "360buy_param_json", JsonConvert.SerializeObject(param) },
                { "v","2.0"}
            };

            dic.Add("sign", Utils.GetJingDongKeplerSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, kplurl, dic);

            return JsonConvert.DeserializeObject<PidUrlConvertResultDto>(resultStr);
        }

        /// <summary>
        /// 开普勒订单详情接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        public async Task<OrderGetListResultDto> JdKeplerOrderGetListAsync(string appKey, string appSecrect, string accessToken, QueryOrderParam param)
        {
            param.Validate();

            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                { "method", "jd.kepler.order.getlist" },
                { "access_token", accessToken },
                { "app_key", appKey },
                { "timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "format", "json" },
                { "360buy_param_json", JsonConvert.SerializeObject(param) },
                { "v","1.0"}
            };

            dic.Add("sign", Utils.GetJingDongKeplerSign(dic, appSecrect));

            var resultStr = await Utils.DoPostAsync(_httpclient, kplurl, dic);

            return JsonConvert.DeserializeObject<OrderGetListResultDto>(resultStr);
        }
    }
}
