using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 查询推广位(申请)返回结果
    /// </summary>
    public class JDUnionOpenPositionQueryResponseDto
    {
        /// <summary>
        /// 响应信息
        /// </summary>
        [JsonProperty("jd_union_open_position_query_responce")]
        public PositionQueryResponseDto Response { get; set; } = new PositionQueryResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PositionQueryResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("queryResult")]
        public string QueryResult { get; set; }
    }

    public class PositionQueryQueryResultResponseDto
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
        public PositionQueryDataResponseDto Data { get; set; } = new PositionQueryDataResponseDto();
    }

    /// <summary>
    /// 数据明细
    /// </summary>
    public class PositionQueryDataResponseDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty("pageNo")]
        public int PageNo { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("Result")]
        public PositionQueryDataResultResponseDto Result { get; set; } = new PositionQueryDataResultResponseDto();

        /// <summary>
        /// 总数
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PositionQueryDataResultResponseDto
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonProperty("positionResp")]
        public PositionQueryDataResultPositionRespResponseDto PositionResp { get; set; } = new PositionQueryDataResultPositionRespResponseDto();
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    public class PositionQueryDataResultPositionRespResponseDto
    {
        /// <summary>
        /// 推广位ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// 站点ID，如网站ID/appID/snsID
        /// </summary>
        [JsonProperty("siteId")]
        public int SiteId { get; set; }

        /// <summary>
        /// 推广位名称
        /// </summary>
        [JsonProperty("spaceName")]
        public string SpaceName { get; set; }

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
        /// pid：仅uniontype传4时，展示pid
        /// 可用于内容平台推广
        /// </summary>
        [JsonProperty("pid")]
        public string PId { get; set; }
    }
}
