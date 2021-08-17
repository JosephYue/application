using Application.Jingdong.Extension.JingDongKepler.Dto;
using Application.Jingdong.Extension.JingDongKepler.Param;
using System.Threading.Tasks;

namespace Application.Jingdong.Extension.JingDongKepler.Interface
{
    /// <summary>
    /// 开普勒接口服务
    /// </summary>
    public partial interface IKeplerServices
    {
        /// <summary>
        /// 获取授权
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="redirectUri">回调地址，请填写默认地址即可：http://kepler.jd.com/oauth/code.do</param>
        /// <returns></returns>
        string GetAuth(string appKey, string redirectUri = "http://kepler.jd.com/oauth/code.do");

        /// <summary>
        /// 通过code获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="code">GetAuth中获取的code</param>
        /// <param name="grantType">固定为authorization_code</param>
        /// <returns></returns>
        GetAccessTokenResultDto GetAccessToken(string appKey, string appSecret, string code, string grantType = "authorization_code");

        /// <summary>
        /// 通过refreshtoken获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="refreshToken">通过code获取accesstoken中返回的refreshToken</param>
        /// <param name="grantType">固定为refresh_token</param>
        /// <returns></returns>
        GetAccessTokenResultDto GetAccessTokenByRefreshToken(string appKey, string appSecret, string refreshToken, string grantType = "refresh_token");

        /// <summary>
        /// 券品二合一推广转换接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        ConvertUrlResultDto JdKplOpenPromotionConvertUrl(string appKey, string appSecrect, string accessToken, ConvertUrlParam param);

        /// <summary>
        /// 开普勒推广链接转换接口（开普勒营销能力API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        PidUrlConvertResultDto JdKplOpenPromotionPidUrlConvert(string appKey, string appSecrect, string accessToken, PidUrlConvertParam param);

        /// <summary>
        /// 开普勒订单详情接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        OrderGetListResultDto JdKeplerOrderGetList(string appKey, string appSecrect, string accessToken, QueryOrderParam param);
    }

    /// <summary>
    /// 开普勒接口服务
    /// </summary>
    public partial interface IKeplerServices
    {
        /// <summary>
        /// 获取授权
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="redirectUri">回调地址，请填写默认地址即可：http://kepler.jd.com/oauth/code.do</param>
        /// <returns></returns>
        Task<string> GetAuthAsync(string appKey, string redirectUri = "http://kepler.jd.com/oauth/code.do");

        /// <summary>
        /// 通过code获取access_token
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="code">GetAuth中获取的code</param>
        /// <param name="grantType">固定为authorization_code</param>
        /// <returns></returns>
        Task<GetAccessTokenResultDto> GetAccessTokenAsync(string appKey, string appSecret, string code, string grantType = "authorization_code");

        /// <summary>
        /// 通过refreshtoken获取accesstoken
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="refreshToken">通过code获取accesstoken中返回的refreshToken</param>
        /// <param name="grantType">固定为refresh_token</param>
        /// <returns></returns>
        Task<GetAccessTokenResultDto> GetAccessTokenByRefreshTokenAsync(string appKey, string appSecret, string refreshToken, string grantType = "refresh_token");

        /// <summary>
        /// 券品二合一推广转换接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<ConvertUrlResultDto> JdKplOpenPromotionConvertUrlAsync(string appKey, string appSecrect, string accessToken, ConvertUrlParam param);

        /// <summary>
        /// 开普勒推广链接转换接口（开普勒营销能力API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<PidUrlConvertResultDto> JdKplOpenPromotionPidUrlConvertAsync(string appKey, string appSecrect, string accessToken, PidUrlConvertParam param);

        /// <summary>
        /// 开普勒订单详情接口（开普勒导购模式API）
        /// </summary>
        /// <param name="appKey">应用标识</param>
        /// <param name="appSecrect">应用密钥</param>
        /// <param name="accessToken">授权的accessToken</param>
        /// <param name="param">参数信息</param>
        /// <returns></returns>
        Task<OrderGetListResultDto> JdKeplerOrderGetListAsync(string appKey, string appSecrect, string accessToken, QueryOrderParam param);
    }
}
