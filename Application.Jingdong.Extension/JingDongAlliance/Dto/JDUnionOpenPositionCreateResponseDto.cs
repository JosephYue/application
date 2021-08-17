using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 创建推广位(申请)返回结果
    /// </summary>
    public class JDUnionOpenPositionCreateResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("jd_union_open_position_create_responce")]
        public PositionCreateResponseDto Response { get; set; } = new PositionCreateResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PositionCreateResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("createResult")]
        public string CreateResult { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PositionCreateCreateResultResponseDto
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
        [JsonProperty("createResult")]
        public PositionCreateDataResponseDto Data { get; set; } = new PositionCreateDataResponseDto();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class PositionCreateDataResponseDto
    {
        /// <summary>
        /// 推广位结果集合
        /// </summary>
        [JsonProperty("resultList")]
        public PositionCreateResultListResponseDto ResultList { get; set; } = new PositionCreateResultListResponseDto();

        /// <summary>
        /// 站点ID
        /// </summary>
        [JsonProperty("siteId")]
        public int SiteId { get; set; }

        /// <summary>
        /// 站点类型 
        /// 1.网站推广位
        /// 2.APP推广位
        /// 3.导购媒体推广位
        /// 4.聊天工具推广位
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 联盟ID
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// pid结果集
        /// </summary>
        [JsonProperty("pid")]
        public PositionCreatePidResponseDto PId { get; set; } = new PositionCreatePidResponseDto();

    }

    /// <summary>
    /// 推广位结果集合
    /// </summary>
    public class PositionCreateResultListResponseDto
    {
        /// <summary>
        /// 推广位结果，但是对应的pid不能作为母子分佣使用。
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }

    /// <summary>
    /// pid结果集
    /// </summary>
    public class PositionCreatePidResponseDto
    {
        /// <summary>
        /// pid结果，仅uniontype传4时，展示pid
        /// 可用于内容平台推广
        /// </summary>
        [JsonProperty("pid")]
        public string PId { get; set; }
    }

}
