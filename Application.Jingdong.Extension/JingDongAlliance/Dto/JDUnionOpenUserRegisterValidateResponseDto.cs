using Newtonsoft.Json;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 京东注册用户判定返回结果
    /// </summary>
    public class JDUnionOpenUserRegisterValidateResponseDto
    {

        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_union_open_user_register_validate_responce")]
        public UserRegisterValidateResponseDto Response { get; set; } = new UserRegisterValidateResponseDto();


    }

    /// <summary>
    /// 响应信息
    /// </summary>
    public class UserRegisterValidateResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("validateResult")]
        public string ValidateResult { get; set; }
    }



    public class ValidateResultResponseDto
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
        public JDUnionOpenUserRegisterValidateDataResponseDto Data { get; set; } = new JDUnionOpenUserRegisterValidateDataResponseDto();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class JDUnionOpenUserRegisterValidateDataResponseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("userResp")]
        public UserRespResponseDto UserResp { get; set; } = new UserRespResponseDto();
    }

    public class UserRespResponseDto
    {
        /// <summary>
        /// 1、京东注册用户
        /// 2、非京东注册用户（包括未查询到身份的用户）
        /// </summary>
        [JsonProperty("jdUser")]
        public int JdUser { get; set; }
    }
}
