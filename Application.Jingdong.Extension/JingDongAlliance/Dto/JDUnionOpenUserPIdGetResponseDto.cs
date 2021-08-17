using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 获取PId(申请)返回结果
    /// </summary>
    public class JDUnionOpenUserPIdGetResponseDto
    {
        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("jd_union_open_user_pid_get_response")]
        public UserPIdGetResponseDto Response { get; set; } = new UserPIdGetResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class UserPIdGetResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("getResult")]
        public string GetResult { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class UserPIdGetGetResultResponseDto
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
        public int Message { get; set; }

        /// <summary>
        /// 数据明细
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
